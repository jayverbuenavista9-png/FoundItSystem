using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class LoginForm : Form
    {
        static readonly Color BLUE   = Color.FromArgb(74, 144, 226);
        static readonly Color ORANGE = Color.FromArgb(255, 140, 66);
        static readonly Color BG     = Color.White;

        const string CONN = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FoundItDB;Integrated Security=True;";

        public LoginForm()
        {
            InitializeComponent();

            // Replace the designer placeholder with the real LogoPanel at runtime
            var logo = new LogoPanel(54)
            {
                Left   = pnlLogoPlaceholder.Left,
                Top    = pnlLogoPlaceholder.Top,
                Width  = pnlLogoPlaceholder.Width,
                Height = pnlLogoPlaceholder.Height
            };
            pnlCanvas.Controls.Remove(pnlLogoPlaceholder);
            pnlCanvas.Controls.Add(logo);

            pnlCanvas.Paint += Canvas_Paint;
            btnLogin.Click  += BtnLogin_Click;
            btnCancel.Click += (s, e) => Application.Exit();
            txtPass.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnLogin_Click(s, e); };
            txtUser.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) txtPass.Focus(); };
            btnCancel.MouseEnter += (s, e) => { btnCancel.BackColor = ORANGE; btnCancel.ForeColor = Color.White; };
            btnCancel.MouseLeave += (s, e) => { btnCancel.BackColor = BG;     btnCancel.ForeColor = ORANGE; };
        }

        void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var pts = new PointF[]
            {
                new PointF(520, 0),
                new PointF(520 * 0.5f, 520 * 0.3f),
                new PointF(520, 520 * 0.6f)
            };
            using (var br = new SolidBrush(Color.FromArgb(30, BLUE)))
                g.FillPolygon(br, pts);
        }

        void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter both username and password.", "Input Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqlConnection(CONN))
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT Password FROM Users WHERE Username = @u", conn);
                    cmd.Parameters.AddWithValue("@u", user);
                    var result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        if (result.ToString() != pass)
                        {
                            MessageBox.Show("Invalid password.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        var ans = MessageBox.Show("No account found. Create new account?", "New User",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (ans == DialogResult.Yes)
                        {
                            var ins = new SqlCommand(
                                "INSERT INTO Users (Username,Password) VALUES (@u,@p)", conn);
                            ins.Parameters.AddWithValue("@u", user);
                            ins.Parameters.AddWithValue("@p", pass);
                            ins.ExecuteNonQuery();
                            MessageBox.Show("Account created! Logging you in...", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else return;
                    }

                    bool isAdmin = user.Equals("admin", StringComparison.OrdinalIgnoreCase);
                    var main = new MainForm(user, isAdmin);
                    main.Show();
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }
    }
}
