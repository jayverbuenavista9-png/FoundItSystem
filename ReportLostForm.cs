using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class ReportLostForm : Form
    {
        private string _user;

        public ReportLostForm(string user)
        {
            _user = user;
            InitializeComponent();
            txtReporter.Text = _user;
            txtReporter.ReadOnly = true;
            btnCancel.Click += (s, e) => Close();
        }

        private void lbl_pts_Click(object sender, EventArgs e)
        {
        }

        private void btnPoints25_Click(object sender, EventArgs e)
        {
            txtSpecificAmount.Text = "25";
        }

        private void btnPoints50_Click(object sender, EventArgs e)
        {
            txtSpecificAmount.Text = "50";
        }

        private void btnPoints100_Click(object sender, EventArgs e)
        {
            txtSpecificAmount.Text = "100";
        }

        private void btnPoints150_Click(object sender, EventArgs e)
        {
            txtSpecificAmount.Text = "150";
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // 1. VALIDATE TEXT FIELDS 
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtDesc.Text) ||
                string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

          
            // 2. VALIDATE POINTS SECOND
            int rewardFee = 0;
            bool isNumber = int.TryParse(txtSpecificAmount.Text, out rewardFee);

            if (string.IsNullOrWhiteSpace(txtSpecificAmount.Text) || isNumber == false || rewardFee <= 0)
            {
                MessageBox.Show("Please select points", "Invalid Points", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. ASK FOR CONFIRMATION  
            DialogResult confirmResult = MessageBox.Show(
                 "Are you sure you want to submit this report?",
                 "Confirm Submission",
                  MessageBoxButtons.OKCancel,
                  MessageBoxIcon.Question
             );

            if (confirmResult == DialogResult.Cancel)
            {
                return;
            }

           
            // 4. SAVE TO DATABASE
            using (var conn = new SqlConnection(AppConfig.Conn))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Items (Name, Description, OwnerName, Category, Status) VALUES (@n, @d, @o, @c, 'Lost')", conn);
                cmd.Parameters.AddWithValue("@n", txtName.Text);
                cmd.Parameters.AddWithValue("@d", txtDesc.Text);
                cmd.Parameters.AddWithValue("@o", _user);
                cmd.Parameters.AddWithValue("@c", cmbCategory.Text);
                cmd.ExecuteNonQuery();
            }
        
            //5. SHOW SUCCESS MESSAGE & CLOSE
            MessageBox.Show(
                $"Item: {txtName.Text}\nReward: {rewardFee} points",
                "Report Submitted!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.Close();
        }

        private void lbl_pts_Click_1(object sender, EventArgs e)
        {

        }

        private void txtSpecificAmount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}