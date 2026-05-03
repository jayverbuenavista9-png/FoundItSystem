using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class EWalletPanel : UserControl
    {
        private MainForm _parentForm;

        static readonly Color BLUE = Color.FromArgb(74, 144, 226);
        static readonly Color ORANGE = Color.FromArgb(255, 140, 66);
        static readonly Color BG = Color.FromArgb(250, 252, 255);

        public EWalletPanel(MainForm parent)
        {
            _parentForm = parent;
            InitializeComponent();

            // Apply custom rounded-border painting to all 6 tiles
            Button[] tiles = {
                btnRedeem50,  btnRedeem100, btnRedeem200,
                btnRedeem300, btnRedeem500, btnRedeem1000
            };
            foreach (var btn in tiles)
                StyleTileButton(btn);

            // Wire click events to denomination amounts
            btnRedeem50.Click += (s, e) => AttemptRedeem(50);
            btnRedeem100.Click += (s, e) => AttemptRedeem(100);
            btnRedeem200.Click += (s, e) => AttemptRedeem(200);
            btnRedeem300.Click += (s, e) => AttemptRedeem(300);
            btnRedeem500.Click += (s, e) => AttemptRedeem(500);
            btnRedeem1000.Click += (s, e) => AttemptRedeem(1000);

            RefreshBalance();
        }

        // ─────────────────────────────────────────────────────────────
        // Core: Display
        // ─────────────────────────────────────────────────────────────

        public void RefreshBalance()
        {
            int pts = GetCurrentPoints();
            lblBalance.Text = $"⭐  {pts} pts available";
            HighlightAffordableTiles(pts);
        }

        private void HighlightAffordableTiles(int pts)
        {
            SetTileEnabled(btnRedeem50, pts >= 50);
            SetTileEnabled(btnRedeem100, pts >= 100);
            SetTileEnabled(btnRedeem200, pts >= 200);
            SetTileEnabled(btnRedeem300, pts >= 300);
            SetTileEnabled(btnRedeem500, pts >= 500);
            SetTileEnabled(btnRedeem1000, pts >= 1000);
        }

        private void SetTileEnabled(Button btn, bool canAfford)
        {
            btn.Enabled = canAfford;
            btn.ForeColor = canAfford ? BLUE : Color.LightGray;
            btn.Invalidate();
        }

        // ─────────────────────────────────────────────────────────────
        // Core: Redemption Logic
        // ─────────────────────────────────────────────────────────────

        private void AttemptRedeem(int amount)
        {
            int currentPoints = GetCurrentPoints();

            if (currentPoints < amount)
            {
                MessageBox.Show(
                    $"You only have {currentPoints} pts.\n" +
                    $"You need {amount} pts to redeem ₱{amount}.",
                    "Insufficient Points",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Redeem {amount} points for ₱{amount} cash?\n\n" +
                $"This will be sent to your linked account.\n" +
                $"Remaining after: {currentPoints - amount} pts",
                "Confirm Redemption",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.OK) return;

            try
            {
                using (var conn = new SqlConnection(AppConfig.Conn))
                {
                    conn.Open();

                    var cmd = new SqlCommand(
                        "UPDATE Users SET Points = Points - @amt WHERE Username = @u AND Points >= @amt",
                        conn);
                    cmd.Parameters.AddWithValue("@amt", amount);
                    cmd.Parameters.AddWithValue("@u", _parentForm.CurrentUser);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        MessageBox.Show("Redemption failed — balance may have changed. Please try again.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RefreshBalance();
                        return;
                    }
                }

                MessageBox.Show(
                    $"✅ Success!\n\n" +
                    $"{amount} points redeemed for ₱{amount}.\n" +
                    $"Check your linked account.",
                    "Redemption Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                RefreshBalance();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing redemption:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─────────────────────────────────────────────────────────────
        // Database Helper
        // ─────────────────────────────────────────────────────────────

        private int GetCurrentPoints()
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.Conn))
                {
                    conn.Open();
                    var cmd = new SqlCommand(
                        "SELECT Points FROM Users WHERE Username = @u", conn);
                    cmd.Parameters.AddWithValue("@u", _parentForm.CurrentUser);
                    object result = cmd.ExecuteScalar();
                    return (result != null && result != DBNull.Value)
                        ? Convert.ToInt32(result) : 0;
                }
            }
            catch { return 0; }
        }

        public static void AwardPoints(string username, int points)
        {
            if (string.IsNullOrWhiteSpace(username) || points <= 0) return;
            try
            {
                using (var conn = new SqlConnection(AppConfig.Conn))
                {
                    conn.Open();
                    var cmd = new SqlCommand(
                        "UPDATE Users SET Points = Points + @pts WHERE Username = @u", conn);
                    cmd.Parameters.AddWithValue("@pts", points);
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }

        // ─────────────────────────────────────────────────────────────
        // Styling: Rounded tile buttons matching the wireframe
        // ─────────────────────────────────────────────────────────────

        private void StyleTileButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.White;
            btn.ForeColor = BLUE;
            btn.Font = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            btn.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                using (var clip = GraphicsExtensions.RoundedRect(0, 0, btn.Width, btn.Height, 15))
                    btn.Region = new Region(clip);

                e.Graphics.Clear(btn.Enabled ? Color.White : Color.FromArgb(245, 248, 252));

                Color borderCol = btn.Enabled ? BLUE : Color.LightGray;
                using (var pen = new Pen(borderCol, 2))
                using (var borderPath = GraphicsExtensions.RoundedRect(1, 1, btn.Width - 3, btn.Height - 3, 15))
                    e.Graphics.DrawPath(pen, borderPath);

                Color textCol = btn.Enabled ? BLUE : Color.DarkGray;

                // Text formatting for perfect center alignment with newlines
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter |
                                        TextFormatFlags.VerticalCenter |
                                        TextFormatFlags.WordBreak;

                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, textCol, flags);
            };

            btn.MouseEnter += (s, e) =>
            {
                if (btn.Enabled)
                {
                    btn.BackColor = Color.FromArgb(235, 245, 255);
                    btn.Invalidate();
                }
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = Color.White;
                btn.Invalidate();
            };
        }

        private void EWalletPanel_Load(object sender, EventArgs e)
        {

        }

        private void lblBalance_Click(object sender, EventArgs e)
        {

        }
    }
}