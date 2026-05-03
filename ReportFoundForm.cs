using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class ReportFoundForm : Form
    {
        private string _user;
        

        public ReportFoundForm(string user)
        {
            _user = user;
            InitializeComponent();
            txtReporter.Text = _user;
            txtReporter.ReadOnly = true;
            btnCancel.Click += (s, e) => Close();
            btnSubmit.Click += Submit;
        }

        private void Submit(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtDesc.Text)) return;
            using (var conn = new SqlConnection(AppConfig.Conn))
            {
                conn.Open();
                var cmd = new SqlCommand("INSERT INTO Items (Name, Description, OwnerName, Category, Status) VALUES (@n, @d, @o, @c, 'Found')", conn);
                cmd.Parameters.AddWithValue("@n", txtName.Text);
                cmd.Parameters.AddWithValue("@d", txtDesc.Text);
                cmd.Parameters.AddWithValue("@o", _user);
                cmd.Parameters.AddWithValue("@c", cmbCategory.SelectedItem?.ToString() ?? "Others");
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Found Item Reported!");
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}