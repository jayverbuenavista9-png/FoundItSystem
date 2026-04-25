using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class LoginForm : Form
    {
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FoundItDB;Integrated Security=True;";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show(this, "Please enter both a username and a password.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Password FROM Users WHERE Username = @user";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            if (result.ToString() == password)
                            {
                                MainForm main = new MainForm(username);
                                main.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show(this, "Invalid password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            DialogResult newAccountPrompt = MessageBox.Show(this,
                                "Create new account?",
                                "New User",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (newAccountPrompt == DialogResult.Yes)
                            {
                                string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@user, @pass)";
                                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                                {
                                    insertCmd.Parameters.AddWithValue("@user", username);
                                    insertCmd.Parameters.AddWithValue("@pass", password);
                                    insertCmd.ExecuteNonQuery();

                                    MessageBox.Show(this, "Account created successfully! You can now click Login again.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Application.Exit();
    }
}