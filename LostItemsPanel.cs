using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class LostItemsPanel : UserControl
    {
        private MainForm _parentForm;
        private int _selectedId = -1;
        private string _attachedImagePath = "";

        public LostItemsPanel(MainForm parent)
        {
            _parentForm = parent;
            InitializeComponent();

            // 1. Show the correct panels
            pnlTableContainer.Visible = true;
            pnlRightDetails.Visible = true;
            pnlHome.Visible = false;

            // 2. Fix the Docking Z-Order so they NEVER overlap
            pnlRightDetails.Dock = DockStyle.Right;
            pnlRightDetails.SendToBack();

            pnlTableContainer.Dock = DockStyle.Fill;
            pnlTableContainer.BringToFront();

            // 3. Grid Styling
            dgv.Dock = DockStyle.Fill;
            dgv.BringToFront();
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;

            // Paints the rounded background
            pnlTableContainer.BackColor = Color.Transparent;
            pnlTableContainer.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillRoundRect(Color.White, 0, 0, pnlTableContainer.Width - 1, pnlTableContainer.Height - 1, 15);
            };

            btnSearch.Click += (s, e) => LoadTable();
            dgv.SelectionChanged += Dgv_SelectionChanged;

            btnMarkFound.Click += (s, e) => ExecuteAction($"UPDATE Items SET Status='Recovered' WHERE ID={_selectedId}", "Item marked as Recovered!");
            btnDelete.Click += (s, e) => ExecuteAction($"UPDATE Items SET IsDeleted=1, Status='In Trash' WHERE ID={_selectedId}", "Item moved to trash (Soft Delete).");
            btnSend.Click += BtnSendComment_Click;

            LoadTable();
        }

        public void LoadTable()
        {
            string search = txtSearch.Text.Trim();
            string where = "Status='Lost' AND IsDeleted=0";
            if (!string.IsNullOrEmpty(search)) where += $" AND Name LIKE '%{search.Replace("'", "''")}%'";

            using (var conn = new SqlConnection(AppConfig.Conn))
            {
                // FIX: Pulling the actual RewardFee from the database instead of hardcoding 0
                string sqlQuery = $"SELECT ID, Name AS [NAME], Description AS [DESCRIPTION], OwnerName AS [OWNER/FINDER], Category AS [CATEGORY], Status AS [STATUS], ISNULL(RewardFee, 0) AS [FEE] FROM Items WHERE {where} ORDER BY ReportedAt DESC";

                using (var da = new SqlDataAdapter(sqlQuery, conn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                    if (dgv.Columns["ID"] != null) dgv.Columns["ID"].Visible = false;
                }
            }
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            var row = dgv.SelectedRows[0];

            _selectedId = Convert.ToInt32(row.Cells["ID"].Value);

            lblItemName.Text = row.Cells["NAME"].Value?.ToString();
            txtDetDesc.Text = row.Cells["DESCRIPTION"].Value?.ToString();

            lblItemStatus.Text = row.Cells["STATUS"].Value?.ToString();
            lblCategory.Text = "CATEGORY: " + row.Cells["CATEGORY"].Value?.ToString();
            lblReporter.Text = "REPORTER: " + row.Cells["OWNER/FINDER"].Value?.ToString();

            // FIX: This will now properly display the dynamic fee we pulled from the query above
            lblFee.Text = "FEE: " + row.Cells["FEE"].Value?.ToString();

            LoadComments();
        }

        // CHAT FEED & IMAGE SYSTEM
        private void LoadComments()
        {
            flpComments.Controls.Clear();

            using (var conn = new SqlConnection(AppConfig.Conn))
            {
                var cmd = new SqlCommand($"SELECT Username, Message FROM Comments WHERE ItemID={_selectedId} ORDER BY CreatedAt ASC", conn);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        AddCommentToFeed(r["Username"].ToString(), r["Message"].ToString(), "");
                    }
                }
            }
        }

        private void AddCommentToFeed(string username, string message, string imagePath)
        {
            Panel commentContainer = new Panel();
            commentContainer.Width = flpComments.Width - 25;
            commentContainer.AutoSize = true;

            int currentY = 5;

            if (!string.IsNullOrWhiteSpace(message))
            {
                Label lblText = new Label();
                lblText.Text = $"{username}: {message}";
                lblText.AutoSize = true;
                lblText.Location = new Point(5, currentY);
                lblText.Font = new Font("Segoe UI", 9, FontStyle.Regular);

                commentContainer.Controls.Add(lblText);
                currentY += 25;
            }

            if (!string.IsNullOrEmpty(imagePath))
            {
                PictureBox pic = new PictureBox();
                pic.Image = Image.FromFile(imagePath);
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pic.Width = 150;
                pic.Height = 150;
                pic.Location = new Point(5, currentY);

                commentContainer.Controls.Add(pic);
            }

            flpComments.Controls.Add(commentContainer);
            flpComments.ScrollControlIntoView(commentContainer);
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _attachedImagePath = openFileDialog.FileName;
                }
            }
        }

        private void BtnSendComment_Click(object sender, EventArgs e)
        {
            if (_selectedId == -1 || (string.IsNullOrWhiteSpace(txtComment.Text) && string.IsNullOrEmpty(_attachedImagePath))) return;

            AddCommentToFeed(_parentForm.CurrentUser, txtComment.Text, _attachedImagePath);

            using (var conn = new SqlConnection(AppConfig.Conn))
            {
                conn.Open();
                new SqlCommand($"INSERT INTO Comments(ItemID, Username, Message) VALUES({_selectedId}, '{_parentForm.CurrentUser}', '{txtComment.Text.Replace("'", "''")}')", conn).ExecuteNonQuery();
            }

            txtComment.Clear();
            _attachedImagePath = "";
        }

        private void ExecuteAction(string sql, string successMessage)
        {
            if (_selectedId == -1) return;
            using (var conn = new SqlConnection(AppConfig.Conn)) { conn.Open(); new SqlCommand(sql, conn).ExecuteNonQuery(); }
            LoadTable();
            MessageBox.Show(successMessage);
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblDescHdr_Click(object sender, EventArgs e)
        {

        }

        private void lblFee_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }
    }
}