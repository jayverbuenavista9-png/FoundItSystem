using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class FoundItemsPanel : UserControl
    {
        private MainForm _parentForm;
        private int _selectedId = -1;

        public FoundItemsPanel(MainForm parent)
        {
            _parentForm = parent;
            InitializeComponent();

            pnlTableContainer.Visible = true; // Show the table
            pnlRightDetails.Visible = true;   // Show the right chat/details sidebar
            pnlHome.Visible = false;          // Hide the leftover home panel

            // 1. Show the correct panels
            pnlTableContainer.Visible = true;
            pnlRightDetails.Visible = true;
            pnlHome.Visible = false;

            // 2. Fix the Docking Z-Order so they NEVER overlap
            pnlRightDetails.Dock = DockStyle.Right;
            pnlRightDetails.SendToBack();     // Claims the right edge FIRST

            pnlTableContainer.Dock = DockStyle.Fill;
            pnlTableContainer.BringToFront(); // Fills the remaining space safely

            // Forces the table grid to the very front of the panel and paints it white
            dgv.Dock = DockStyle.Fill;
            dgv.BringToFront();
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
            string where = "(Status='Found' OR Status='Pending Claim' OR Status='Claimed') AND IsDeleted=0";
            if (!string.IsNullOrEmpty(search)) where += $" AND Name LIKE '%{search.Replace("'", "''")}%'";

            using (var conn = new SqlConnection(AppConfig.Conn))
            using (var da = new SqlDataAdapter($"SELECT ID, Name, Description, OwnerName, Category, Status, Claimant FROM Items WHERE {where} ORDER BY ReportedAt DESC", conn))
            {
                var dt = new DataTable(); da.Fill(dt);
                dgv.DataSource = dt;
                if (dgv.Columns["ID"] != null) dgv.Columns["ID"].Visible = false;
            }
        }

        private void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            var row = dgv.SelectedRows[0];
            _selectedId = Convert.ToInt32(row.Cells["ID"].Value);
            txtDetDesc.Text = row.Cells["Description"].Value?.ToString();
            LoadComments();
        }

        private void LoadComments()
        {
            using (var conn = new SqlConnection(AppConfig.Conn))
            {
                var cmd = new SqlCommand($"SELECT Username, Message FROM Comments WHERE ItemID={_selectedId} ORDER BY CreatedAt ASC", conn);
                conn.Open();
            }
        }

        private void BtnSendComment_Click(object sender, EventArgs e)
        {
            if (_selectedId == -1 || string.IsNullOrWhiteSpace(txtComment.Text)) return;
            using (var conn = new SqlConnection(AppConfig.Conn))
            {
                conn.Open();
                new SqlCommand($"INSERT INTO Comments(ItemID, Username, Message) VALUES({_selectedId}, '{_parentForm.CurrentUser}', '{txtComment.Text.Replace("'", "''")}')", conn).ExecuteNonQuery();
            }
            txtComment.Clear(); LoadComments();
        }

        private void ExecuteAction(string sql, string successMessage)
        {
            if (_selectedId == -1) return;
            using (var conn = new SqlConnection(AppConfig.Conn)) { conn.Open(); new SqlCommand(sql, conn).ExecuteNonQuery(); }
            LoadTable(); MessageBox.Show(successMessage);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblItemName_Click(object sender, EventArgs e)
        {

        }

        private void txtComments_Click(object sender, EventArgs e)
        {

        }
    }
}