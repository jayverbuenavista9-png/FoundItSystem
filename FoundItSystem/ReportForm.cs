using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class ReportForm : Form
    {
        string currentUser;
        string reportType;
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FoundItDB;Integrated Security=True;";

        public ReportForm(string username, string type)
        {
            InitializeComponent();
            currentUser = username;
            reportType = type;

            txtReporter.Text = currentUser;
            txtReporter.ReadOnly = true;

            // Apply dynamic colors to the custom UI header/button
            if (type == "Lost")
            {
                lblReportTitle.Text = "🔍 Lost Item Report";
                pnlHeader.BackColor = System.Drawing.Color.FromArgb(255, 140, 66);
                btnSubmit.BackColor = System.Drawing.Color.FromArgb(255, 140, 66);
            }
            else if (type == "Found")
            {
                lblReportTitle.Text = "📦 Found Item Report";
                pnlHeader.BackColor = System.Drawing.Color.FromArgb(74, 144, 226);
                btnSubmit.BackColor = System.Drawing.Color.FromArgb(74, 144, 226);
            }

            // Wire up the custom 'X' close button securely
            btnClose.Click += (s, e) => this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemName.Text) || string.IsNullOrWhiteSpace(txtDescription.Text) || cmbCategory.SelectedItem == null)
            {
                MessageBox.Show(this, "Please fill in all fields.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Items (Name, Description, OwnerName, Category, Status) VALUES (@name, @desc, @owner, @category, @status)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtItemName.Text.Trim());
                        cmd.Parameters.AddWithValue("@desc", txtDescription.Text.Trim());
                        cmd.Parameters.AddWithValue("@owner", currentUser);
                        cmd.Parameters.AddWithValue("@category", cmbCategory.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@status", reportType);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show(this, "Report submitted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}