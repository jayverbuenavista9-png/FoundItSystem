using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class ReportForm : Form
    {
        static readonly Color BLUE   = Color.FromArgb(74, 144, 226);
        static readonly Color ORANGE = Color.FromArgb(255, 140, 66);

        const string CONN = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FoundItDB;Integrated Security=True;";

        readonly string currentUser;
        readonly string reportType;
        readonly Color  headerColor;

        public ReportForm(string user, string type)
        {
            currentUser = user;
            reportType  = type;
            headerColor = type == "Found" ? BLUE : ORANGE;

            InitializeComponent();

            // Set form title and header colour based on type
            this.Text         = type == "Found" ? "Report Found Item" : "Report Lost Item";
            lblTitle.Text     = type == "Found" ? "📦  Found Item Report" : "🔍  Lost Item Report";
            pnlHeader.BackColor = headerColor;
            btnSubmit.BackColor = headerColor;

            txtReporter.Text  = currentUser;

            // Gradient header paint
            pnlHeader.Paint += (s, e) =>
            {
                var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
                using var br = new LinearGradientBrush(pnlHeader.ClientRectangle,
                    headerColor, ControlPaint.Dark(headerColor, 0.2f), LinearGradientMode.Horizontal);
                g.FillRectangle(br, pnlHeader.ClientRectangle);
            };

            btnCancel.Click += (s, e) => Close();
            btnSubmit.Click += BtnSubmit_Click;
        }

        void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqlConnection(CONN))
                {
                    conn.Open();
                    var cmd = new SqlCommand(
                        "INSERT INTO Items (Name,Description,OwnerName,Category,Status) VALUES (@n,@d,@o,@c,@s)", conn);
                    cmd.Parameters.AddWithValue("@n", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@d", txtDesc.Text.Trim());
                    cmd.Parameters.AddWithValue("@o", currentUser);
                    cmd.Parameters.AddWithValue("@c", cmbCategory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@s", reportType);
                    cmd.ExecuteNonQuery();

                    string oppStatus = reportType == "Lost" ? "Found" : "Lost";
                    var chk = new SqlCommand(
                        "SELECT TOP 1 ID, Name, OwnerName FROM Items WHERE Status=@s AND IsDeleted=0 AND Name LIKE @n", conn);
                    chk.Parameters.AddWithValue("@s", oppStatus);
                    chk.Parameters.AddWithValue("@n", "%" + txtName.Text.Trim() + "%");
                    using (var rdr = chk.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            string matchedName  = rdr["Name"].ToString();
                            string matchedOwner = rdr["OwnerName"].ToString();
                            rdr.Close();
                            if (!matchedOwner.Equals(currentUser, StringComparison.OrdinalIgnoreCase))
                                CreateNotification(conn, matchedOwner,
                                    $"POTENTIAL MATCH! Your {oppStatus} item '{matchedName}' matches a new report: '{txtName.Text.Trim()}'.");
                            CreateNotification(conn, currentUser,
                                $"Potential match found for '{txtName.Text.Trim()}': {matchedName} ({oppStatus}).");
                        }
                    }
                }

                MessageBox.Show("Report submitted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void CreateNotification(SqlConnection conn, string username, string message)
        {
            try
            {
                var cmd = new SqlCommand("INSERT INTO Notifications (Username,Message) VALUES (@u,@m)", conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@m", message);
                cmd.ExecuteNonQuery();
            }
            catch { }
        }
    }
}
