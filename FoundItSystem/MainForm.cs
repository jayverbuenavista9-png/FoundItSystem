using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class MainForm : Form
    {
        string currentUser;
        int selectedItemId = -1;
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FoundItDB;Integrated Security=True;";

        public MainForm(string username)
        {
            InitializeComponent();
            currentUser = username;
            lblGreeting.Text = $"Hello, {currentUser}!\nWhat are we looking for today?";

            pnlTableContainer.Visible = false;
            pnlRightDetails.Visible = false;
            pnlHome.Visible = true;

            LoadDashboardStats();
        }

        private void LoadDashboardStats()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    lblActiveItems.Text = new SqlCommand("SELECT COUNT(*) FROM Items WHERE IsDeleted = 0", conn).ExecuteScalar().ToString();
                    lblLostItems.Text = new SqlCommand("SELECT COUNT(*) FROM Items WHERE Status = 'Lost' AND IsDeleted = 0", conn).ExecuteScalar().ToString();
                    lblFoundItems.Text = new SqlCommand("SELECT COUNT(*) FROM Items WHERE Status = 'Found' AND IsDeleted = 0", conn).ExecuteScalar().ToString();
                }
                catch { }
            }
        }

        private void LoadTableData(string statusFilter)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = statusFilter == "All" ? "SELECT ID, Name, Description, OwnerName, Claimant, Status FROM Items WHERE IsDeleted = 0"
                                                     : "SELECT ID, Name, Description, OwnerName, Claimant, Status FROM Items WHERE Status = @status AND IsDeleted = 0";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                if (statusFilter != "All") da.SelectCommand.Parameters.AddWithValue("@status", statusFilter);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvItems.DataSource = dt;
            }
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count == 0) return;

            selectedItemId = Convert.ToInt32(dgvItems.SelectedRows[0].Cells["ID"].Value);
            lblDetailName.Text = dgvItems.SelectedRows[0].Cells["Name"].Value.ToString();
            txtDetailDescription.Text = dgvItems.SelectedRows[0].Cells["Description"].Value.ToString();
            lblDetailStatus.Text = "Status: " + dgvItems.SelectedRows[0].Cells["Status"].Value.ToString();

            string owner = dgvItems.SelectedRows[0].Cells["OwnerName"].Value.ToString();
            string claimant = dgvItems.SelectedRows[0].Cells["Claimant"].Value.ToString();
            lblDetailPeople.Text = $"Reporter: {owner} | Claimant: {(string.IsNullOrEmpty(claimant) ? "None" : claimant)}";

            LoadComments(selectedItemId);
        }

        private void LoadComments(int itemId)
        {
            lstComments.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Username, Message FROM Comments WHERE ItemID = @id ORDER BY CreatedAt ASC", conn);
                cmd.Parameters.AddWithValue("@id", itemId);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) lstComments.Items.Add($"{reader["Username"]}: {reader["Message"]}");
                }
                catch { }
            }
        }

        private void btnSendComment_Click(object sender, EventArgs e)
        {
            if (selectedItemId == -1 || string.IsNullOrWhiteSpace(txtNewComment.Text)) return;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Comments (ItemID, Username, Message) VALUES (@itemId, @user, @msg)", conn);
                cmd.Parameters.AddWithValue("@itemId", selectedItemId);
                cmd.Parameters.AddWithValue("@user", currentUser);
                cmd.Parameters.AddWithValue("@msg", txtNewComment.Text.Trim());

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    string owner = dgvItems.SelectedRows[0].Cells["OwnerName"].Value.ToString();
                    if (owner != currentUser) CreateNotification(owner, $"{currentUser} commented on {lblDetailName.Text}.");

                    txtNewComment.Clear();
                    LoadComments(selectedItemId);
                }
                catch { }
            }
        }

        private void btnClaimItem_Click(object sender, EventArgs e)
        {
            if (selectedItemId == -1 || dgvItems.SelectedRows[0].Cells["Status"].Value.ToString() != "Found") return;

            Form prompt = new Form() { Width = 400, Height = 150, Text = "Proof of Ownership", StartPosition = FormStartPosition.CenterParent };
            TextBox txtInput = new TextBox() { Left = 20, Top = 20, Width = 340 };
            Button btnOk = new Button() { Text = "Submit", Left = 260, Top = 60, DialogResult = DialogResult.OK };
            prompt.Controls.Add(txtInput); prompt.Controls.Add(btnOk);

            if (prompt.ShowDialog(this) == DialogResult.OK && !string.IsNullOrWhiteSpace(txtInput.Text))
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Items SET Claimant = @claimant, Status = 'Pending Claim' WHERE ID = @id", conn);
                    cmd.Parameters.AddWithValue("@claimant", currentUser);
                    cmd.Parameters.AddWithValue("@id", selectedItemId);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    CreateNotification(dgvItems.SelectedRows[0].Cells["OwnerName"].Value.ToString(), $"{currentUser} is claiming {lblDetailName.Text}. Proof: {txtInput.Text}");

                    LoadTableData("All");
                    LoadDashboardStats();
                }
            }
        }

        private void btnSoftDelete_Click(object sender, EventArgs e)
        {
            if (selectedItemId == -1 || MessageBox.Show(this, "Move to Recycle Bin?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Items SET IsDeleted = 1, Status = 'In Trash' WHERE ID = @id", conn);
                cmd.Parameters.AddWithValue("@id", selectedItemId);
                conn.Open();
                cmd.ExecuteNonQuery();

                LoadTableData("All");
                LoadDashboardStats();
            }
        }

        private void CreateNotification(string username, string message)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Notifications (Username, Message) VALUES (@user, @msg)", conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@msg", message);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Message FROM Notifications WHERE Username = @user AND IsRead = 0", conn);
                cmd.Parameters.AddWithValue("@user", currentUser);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    string notifs = "";
                    foreach (DataRow row in dt.Rows) notifs += $"- {row["Message"]}\n\n";
                    MessageBox.Show(this, notifs, "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SqlCommand updateCmd = new SqlCommand("UPDATE Notifications SET IsRead = 1 WHERE Username = @user", conn);
                    updateCmd.Parameters.AddWithValue("@user", currentUser);
                    updateCmd.ExecuteNonQuery();
                }
                else MessageBox.Show(this, "No new notifications.", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --- BUTTON ROUTING ---
        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlTableContainer.Visible = false;
            pnlRightDetails.Visible = false;
            pnlHome.Visible = true;
            LoadDashboardStats();
        }

        private void btnLostItems_Click(object sender, EventArgs e)
        {
            pnlHome.Visible = false;
            pnlTableContainer.Visible = true;
            pnlRightDetails.Visible = true;
            cmbStatusFilter.SelectedItem = "Lost";
            LoadTableData("Lost");
        }

        private void btnFoundItems_Click(object sender, EventArgs e)
        {
            pnlHome.Visible = false;
            pnlTableContainer.Visible = true;
            pnlRightDetails.Visible = true;
            cmbStatusFilter.SelectedItem = "Found";
            LoadTableData("Found");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Close();
        }

        private void btnReportLost_Click(object sender, EventArgs e)
        {
            new ReportForm(currentUser, "Lost").ShowDialog(this);
            LoadDashboardStats();
        }

        private void btnReportFound_Click(object sender, EventArgs e)
        {
            new ReportForm(currentUser, "Found").ShowDialog(this);
            LoadDashboardStats();
        }

        private void btnCenterReportLost_Click(object sender, EventArgs e) => btnReportLost_Click(sender, e);
        private void btnCenterReportFound_Click(object sender, EventArgs e) => btnReportFound_Click(sender, e);

        // --- NOW PROPERLY INSIDE THE CLASS ---
        private void btnApproveClaim_Click(object sender, EventArgs e)
        {
            if (selectedItemId == -1 || dgvItems.SelectedRows[0].Cells["Status"].Value.ToString() != "Pending Claim")
            {
                MessageBox.Show(this, "Please select an item with a 'Pending Claim' status to approve.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // Update status to Claimed
                SqlCommand cmd = new SqlCommand("UPDATE Items SET Status = 'Claimed' WHERE ID = @id", conn);
                cmd.Parameters.AddWithValue("@id", selectedItemId);
                conn.Open();
                cmd.ExecuteNonQuery();

                // Notify the claimant
                string claimant = dgvItems.SelectedRows[0].Cells["Claimant"].Value.ToString();
                CreateNotification(claimant, $"Your claim for '{lblDetailName.Text}' has been officially approved!");

                LoadTableData(cmbStatusFilter.SelectedItem.ToString());
                LoadDashboardStats();
            }
        }

        private void btnMarkFound_Click(object sender, EventArgs e)
        {
            if (selectedItemId == -1 || dgvItems.SelectedRows[0].Cells["Status"].Value.ToString() != "Lost")
            {
                MessageBox.Show(this, "Please select a 'Lost' item to mark it as found.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                // Change status from Lost to Found
                SqlCommand cmd = new SqlCommand("UPDATE Items SET Status = 'Found' WHERE ID = @id", conn);
                cmd.Parameters.AddWithValue("@id", selectedItemId);
                conn.Open();
                cmd.ExecuteNonQuery();

                // Notify the original reporter
                string owner = dgvItems.SelectedRows[0].Cells["OwnerName"].Value.ToString();
                CreateNotification(owner, $"Great news! Your lost item '{lblDetailName.Text}' has been found.");

                LoadTableData(cmbStatusFilter.SelectedItem.ToString());
                LoadDashboardStats();
            }
        }
    }
}