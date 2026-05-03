using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class NotificationsForm : Form
    {
        private string _user;

        public NotificationsForm(string user)
        {
            _user = user;
            InitializeComponent();

            // Wire up the Clear All button you just created in the designer
            btnClearAll.Click += BtnClearAll_Click;

            LoadNotifications();
        }

        private void LoadNotifications()
        {
            flpNotifications.Controls.Clear();

            using (var conn = new SqlConnection(AppConfig.Conn))
            {
                var dt = new DataTable();
                new SqlDataAdapter($"SELECT Message, CreatedAt FROM Notifications WHERE Username='{_user}' ORDER BY CreatedAt DESC", conn).Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    // Draw the "All caught up" empty state if there are no messages
                    var emptyLabel = new Label
                    {
                        Text = "All caught up! No new notifications.",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 12),
                        ForeColor = Color.FromArgb(100, 100, 100),
                        Margin = new Padding(20, 50, 0, 0)
                    };
                    flpNotifications.Controls.Add(emptyLabel);
                }
                else
                {
                    // Draw a card for each notification
                    foreach (DataRow row in dt.Rows)
                    {
                        var pnl = new Panel
                        {
                            Width = flpNotifications.Width - 25,
                            Height = 70,
                            BackColor = Color.FromArgb(225, 240, 255),
                            Margin = new Padding(5)
                        };
                        var lbl = new Label
                        {
                            Text = $"{row["Message"]}\n({row["CreatedAt"]})",
                            Dock = DockStyle.Fill,
                            Font = new Font("Segoe UI", 10),
                            Padding = new Padding(10)
                        };
                        pnl.Controls.Add(lbl);
                        flpNotifications.Controls.Add(pnl);
                    }

                    // Mark as read in the database
                    conn.Open();
                    new SqlCommand($"UPDATE Notifications SET IsRead=1 WHERE Username='{_user}'", conn).ExecuteNonQuery();
                }
            }
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(AppConfig.Conn))
            {
                conn.Open();
                new SqlCommand($"DELETE FROM Notifications WHERE Username='{_user}'", conn).ExecuteNonQuery();
            }
            // Reload to show the empty state
            LoadNotifications();
        }

        private void flpNotifications_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}