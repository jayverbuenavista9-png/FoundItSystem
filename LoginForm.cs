using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class LoginForm : Form
    {
        static readonly Color BLUE = Color.FromArgb(74, 144, 226);
        static readonly Color ORANGE = Color.FromArgb(255, 140, 66);
        static readonly Color BG = Color.White;

        public LoginForm()
        {
            InitializeComponent();

            // 1. Replace the designer placeholder with the real LogoPanel
            var logo = new LogoPanel(54)
            {
                Left = pnlLogoPlaceholder.Left,
                Top = pnlLogoPlaceholder.Top,
                Width = pnlLogoPlaceholder.Width,
                Height = pnlLogoPlaceholder.Height
            };
            pnlCanvas.Controls.Remove(pnlLogoPlaceholder);
            pnlCanvas.Controls.Add(logo);

            // 2. Attach Events
            pnlCanvas.Paint += Canvas_Paint;

            // Wire up the Login Button
            btnLogin.Click += BtnLogin_Click;

            // Wire up the Register Button (Re-purposing the 'btnCancel' from the designer)
            btnCancel.Text = "REGISTER";
            btnCancel.Click += BtnRegister_Click;

            // Keyboard shortcuts
            txtPass.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnLogin_Click(s, e); };
            txtUser.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) txtPass.Focus(); };

            // 3. Apply Modern Rounded Styling to the Buttons
            StyleButton(btnLogin, BLUE, Color.White, false);
            StyleButton(btnCancel, ORANGE, ORANGE, true); // True makes it an outlined button

            // Better Hover Effects for the buttons
            btnCancel.MouseEnter += (s, e) => { btnCancel.ForeColor = Color.White; btnCancel.Invalidate(); };
            btnCancel.MouseLeave += (s, e) => { btnCancel.ForeColor = ORANGE; btnCancel.Invalidate(); };
            btnLogin.MouseEnter += (s, e) => btnLogin.Invalidate();
            btnLogin.MouseLeave += (s, e) => btnLogin.Invalidate();
        }

        // ==========================================
        // UI DRAWING METHODS
        // ==========================================

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int w = pnlCanvas.Width;
            int h = pnlCanvas.Height;

            // 1. Draw the light blue curve (Matching the Java GeneralPath)
            using (var path = new GraphicsPath())
            {
                path.AddLine(w, 0, w, 0);
                path.AddBezier(w, 0, w * 0.5f, h * 0.3f, w * 0.8f, h * 0.6f, w, h);
                path.AddLine(w, h, w, 0);
                path.CloseFigure();

                using (var br = new SolidBrush(Color.FromArgb(235, 245, 255)))
                {
                    g.FillPath(br, path);
                }
            }

            // 2. Draw the two accent lines in the bottom right
            using (var pen = new Pen(Color.FromArgb(220, 230, 240), 3))
            {
                g.DrawLine(pen, w - 40, h - 20, w - 20, h - 40);
                g.DrawLine(pen, w - 30, h - 10, w - 10, h - 30);
            }

            // 3. Draw custom padded borders around the TextBoxes
            using (var pen = new Pen(BLUE, 1))
            {
                Rectangle userRect = new Rectangle(txtUser.Left - 5, txtUser.Top - 5, txtUser.Width + 10, txtUser.Height + 10);
                Rectangle passRect = new Rectangle(txtPass.Left - 5, txtPass.Top - 5, txtPass.Width + 10, txtPass.Height + 10);
                g.DrawRectangle(pen, userRect);
                g.DrawRectangle(pen, passRect);
            }
        }

        private void StyleButton(Button btn, Color bgColor, Color textColor, bool isOutline)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = textColor;

            // Clip the button to be rounded
            using (var path = GraphicsExtensions.RoundedRect(0, 0, btn.Width, btn.Height, 15))
            {
                btn.Region = new Region(path);
            }

            // Paint the background and text manually
            btn.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                if (isOutline && !btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position)))
                {
                    // Draw Outline state
                    e.Graphics.Clear(Color.White);
                    using (var pen = new Pen(bgColor, 2))
                        e.Graphics.DrawPath(pen, GraphicsExtensions.RoundedRect(1, 1, btn.Width - 2, btn.Height - 2, 15));
                }
                else
                {
                    // Draw Solid fill state (for Login button, or when hovering over Register)
                    using (var brush = new SolidBrush(bgColor))
                        e.Graphics.FillPath(brush, GraphicsExtensions.RoundedRect(0, 0, btn.Width, btn.Height, 15));
                }

                // Draw the text
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };
        }

        // ==========================================
        // DATABASE & LOGIC METHODS
        // ==========================================

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please enter both username and password.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqlConnection(AppConfig.Conn))
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT Password FROM Users WHERE Username = @u", conn);
                    cmd.Parameters.AddWithValue("@u", user);
                    var result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        // NEW LOGIC: Explicitly tell them the account doesn't exist.
                        MessageBox.Show("Account not found. Please click 'REGISTER' to create a new account!", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (result.ToString() != pass)
                    {
                        MessageBox.Show("Invalid password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Success: Route to Main Form
                    bool isAdmin = user.Equals("admin", StringComparison.OrdinalIgnoreCase);
                    var main = new MainForm(user, isAdmin);
                    main.Show();
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Please fill in a Username and Password to register.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqlConnection(AppConfig.Conn))
                {
                    conn.Open();

                    // 1. Check if the username is already taken
                    var checkCmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @u", conn);
                    checkCmd.Parameters.AddWithValue("@u", user);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("This username is already taken. Please login, or choose a different username to register.", "Username Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 2. Ask for confirmation before creating
                    var ans = MessageBox.Show($"Are you sure you want to create a new account for '{user}'?", "Confirm Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (ans == DialogResult.Yes)
                    {
                        // 3. Insert new user into DB
                        var ins = new SqlCommand("INSERT INTO Users (Username, Password) VALUES (@u, @p)", conn);
                        ins.Parameters.AddWithValue("@u", user);
                        ins.Parameters.AddWithValue("@p", pass);
                        ins.ExecuteNonQuery();

                        MessageBox.Show("Account created successfully! Logging you in...", "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 4. Auto-login after successful registration
                        bool isAdmin = user.Equals("admin", StringComparison.OrdinalIgnoreCase);
                        var main = new MainForm(user, isAdmin);
                        main.Show();
                        Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}