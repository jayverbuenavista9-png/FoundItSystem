using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class HomePanel : UserControl
    {
        private MainForm _parentForm;

        Label lblActiveItems = new Label();
        Label lblLostItems = new Label();
        Label lblFoundItems = new Label();

        public HomePanel(MainForm parent)
        {
            _parentForm = parent;
            InitializeComponent();
            SetupCenteringAndBorders();

            // 1. Tell the master grid to automatically stretch and fill the screen
            homeTbl.Dock = DockStyle.Fill;
            homeTbl.Padding = new Padding(20, 20, 20, 20);

            // 2. Enforce strict row heights so WinForms doesn't squish them
            homeTbl.RowStyles.Clear();
            homeTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 100)); // Row 0: Header 
            homeTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 130)); // Row 1: Stats Cards 
            homeTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 120)); // Row 2: Action Cards 
            homeTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));  // Row 3: "Quick Filters" text 
            homeTbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100));  // Row 4: Categories 

            // 2. Add Black Line Borders to Category Cards
            pnlCatElectronics.Paint += DrawCategoryBorder;
            pnlCatBooks.Paint += DrawCategoryBorder;
            pnlCatClothing.Paint += DrawCategoryBorder;
            pnlCatAccessories.Paint += DrawCategoryBorder;
            panel6.Paint += DrawCategoryBorder; // Others
            panel7.Paint += DrawCategoryBorder; // All

            // 3. Dynamically set the username
            lblUserName.Text = _parentForm.CurrentUser;

            // 4. Make the Action Cards click to open the forms
            pnlActionLost.Click += (s, e) => { new ReportLostForm(_parentForm.CurrentUser).ShowDialog(); RefreshDashboard(); };
            pnlActionFound.Click += (s, e) => { new ReportFoundForm(_parentForm.CurrentUser).ShowDialog(); RefreshDashboard(); };

            // 5. Apply the rounded corners!
            pnlActionLost.Paint += DrawRoundedPanel;
            pnlActionFound.Paint += DrawRoundedPanel;

            pnlStatActive.Paint += DrawStatCardBorder;
            panel1.Paint += DrawStatCardBorder;
            panel2.Paint += DrawStatCardBorder;

            homeTbl.Dock = DockStyle.Fill;
            homeTbl.Padding = new Padding(20, 20, 20, 20);

            // 2. ENFORCE STRICT ROW HEIGHTS SO WINFORMS DOESN'T SQUISH THEM
            homeTbl.RowStyles.Clear();
            homeTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 100)); // Row 0: Header (100px tall)
            homeTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 130)); // Row 1: Stats Cards (130px tall)
            homeTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 120)); // Row 2: Action Cards (120px tall)
            homeTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));  // Row 3: "Quick Filters" text (40px tall)
            homeTbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100));  // Row 4: Categories take whatever space is left!

            // Nudge the bell slightly inward so it visually centers over the last card
            btnBell.Margin = new Padding(0, 10, 10, 0);

            // Complete fix for the bell highlight/outline
            btnBell.Text = "🔔"; // Using the actual emoji character
            btnBell.Font = new Font("Segoe UI Emoji", 16);
            btnBell.FlatStyle = FlatStyle.Flat;
            btnBell.FlatAppearance.BorderSize = 0;
            btnBell.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnBell.FlatAppearance.MouseOverBackColor = Color.Transparent;

            // THIS IS THE KEY: It stops the button from showing the dashed outline box
            btnBell.TabStop = false;
            btnBell.NotifyDefault(false);

            btnBell.Click += (s, e) => new NotificationsForm(_parentForm.CurrentUser).ShowDialog();

            btnProfile.TabStop = false;
            btnProfile.NotifyDefault(false);
            btnProfile.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnProfile.FlatAppearance.MouseOverBackColor = Color.Transparent;

            RefreshDashboard();

        }

        private void DrawStatCardBorder(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color borderColor = Color.LightGray; // Fallback color

            // Matched to the exact component names in your Designer
            if (pnl.Name == "pnlStatActive") borderColor = Color.FromArgb(74, 144, 226); // Blue
            if (pnl.Name == "panel1") borderColor = Color.FromArgb(255, 140, 66);        // Orange
            if (pnl.Name == "panel2") borderColor = Color.FromArgb(46, 204, 113);        // Green

            // Draw the rounded outline (Thickness: 3)
            using (Pen pen = new Pen(borderColor, 3))
            {
                using (var path = GraphicsExtensions.RoundedRect(1, 1, pnl.Width - 3, pnl.Height - 3, 15))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void DrawRoundedPanel(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = GraphicsExtensions.RoundedRect(0, 0, pnl.Width - 1, pnl.Height - 1, 15))
            {
                pnl.Region = new Region(path);
            }
        }

        private void LblGreeting_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            using (var font = new Font("Segoe UI", 22, FontStyle.Bold))
            using (var blueBrush = new SolidBrush(Color.FromArgb(74, 144, 226)))
            using (var orangeBrush = new SolidBrush(Color.FromArgb(255, 140, 66)))
            {
                string part1 = "Hello, ";
                string part2 = _parentForm.CurrentUser;
                string part3 = "!";
                string part4 = "What are we looking for today?";

                float x = 0;
                float y = 0;

                // 1. Draw "Hello, " (Blue)
                e.Graphics.DrawString(part1, font, blueBrush, x, y);
                x += e.Graphics.MeasureString(part1, font, new PointF(0, 0), StringFormat.GenericTypographic).Width;

                // 2. Draw Username (Orange)
                e.Graphics.DrawString(part2, font, orangeBrush, x, y);
                x += e.Graphics.MeasureString(part2, font, new PointF(0, 0), StringFormat.GenericTypographic).Width;

                // 3. Draw "!" (Blue)
                e.Graphics.DrawString(part3, font, blueBrush, x, y);

                // 4. Draw subtitle on the next line (Blue)
                e.Graphics.DrawString(part4, font, blueBrush, 0, y + 40);
            }
        }

        private void SetupCenteringAndBorders()
        {
            // 1. Add Black Borders to Category Cards
            pnlCatElectronics.Paint += DrawCategoryBorder;
            pnlCatBooks.Paint += DrawCategoryBorder;
            pnlCatClothing.Paint += DrawCategoryBorder;
            pnlCatAccessories.Paint += DrawCategoryBorder;
            panel6.Paint += DrawCategoryBorder;
            panel7.Paint += DrawCategoryBorder;

            // 2. Trigger Centering Math when panels resize
            pnlStatActive.Resize += (s, e) => CenterStats(pnlStatActive, lblTotalNum, lblTotalText);
            panel1.Resize += (s, e) => CenterStats(panel1, label5, label4);
            panel2.Resize += (s, e) => CenterStats(panel2, label7, label6);

            pnlActionLost.Resize += (s, e) => CenterActions(pnlActionLost, label8, label9, label10);
            pnlActionFound.Resize += (s, e) => CenterActions(pnlActionFound, label13, label12, label11);

            pnlCatElectronics.Resize += (s, e) => CenterCategory(pnlCatElectronics, lblElecLost, lblElecFound);
            pnlCatBooks.Resize += (s, e) => CenterCategory(pnlCatBooks, lblBooksLost, lblBooksFound);
            pnlCatClothing.Resize += (s, e) => CenterCategory(pnlCatClothing, lblClothingLost, lblClothingFound);
            pnlCatAccessories.Resize += (s, e) => CenterCategory(pnlCatAccessories, lblAccessoriesLost, lblAccessoriesFound);
            panel6.Resize += (s, e) => CenterCategory(panel6, lblOthersLost, lblOthersFound);
            panel7.Resize += (s, e) => CenterCategory(panel7, lblAllLost, lblAllFound);
        }

        private void CenterStats(Panel pnl, Label num, Label title)
        {
            num.Anchor = AnchorStyles.None; title.Anchor = AnchorStyles.None;
            int y = (pnl.Height - (num.Height + title.Height)) / 2;
            num.Location = new Point((pnl.Width - num.Width) / 2, y);
            title.Location = new Point((pnl.Width - title.Width) / 2, y + num.Height);
        }

        private void CenterActions(Panel pnl, Label icon, Label title, Label sub)
        {
            icon.Anchor = AnchorStyles.None; title.Anchor = AnchorStyles.None; sub.Anchor = AnchorStyles.None;
            int textH = title.Height + sub.Height;
            int totalW = icon.Width + 15 + Math.Max(title.Width, sub.Width);
            int totalH = Math.Max(icon.Height, textH);
            int x = (pnl.Width - totalW) / 2;
            int y = (pnl.Height - totalH) / 2;

            icon.Location = new Point(x, y + (totalH - icon.Height) / 2);
            title.Location = new Point(x + icon.Width + 15, y + (totalH - textH) / 2);
            sub.Location = new Point(x + icon.Width + 15, title.Location.Y + title.Height);
        }

        private void CenterCategory(Panel pnl, Label lost, Label found)
        {
            lost.Anchor = AnchorStyles.None; found.Anchor = AnchorStyles.None;
            int x = (pnl.Width - (lost.Width + 20 + found.Width)) / 2;
            int y = pnl.Height - Math.Max(lost.Height, found.Height) - 15;
            lost.Location = new Point(x, y);
            found.Location = new Point(x + lost.Width + 20, y);
        }

        private void DrawCategoryBorder(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, pnl.Width - 1, pnl.Height - 1);
        }
        public void RefreshDashboard()
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.Conn))
                {
                    conn.Open();
                    lblActiveItems.Text = new SqlCommand("SELECT COUNT(*) FROM Items WHERE IsDeleted=0", conn).ExecuteScalar()?.ToString() ?? "0";
                    lblLostItems.Text = new SqlCommand("SELECT COUNT(*) FROM Items WHERE Status='Lost' AND IsDeleted=0", conn).ExecuteScalar()?.ToString() ?? "0";
                    lblFoundItems.Text = new SqlCommand("SELECT COUNT(*) FROM Items WHERE Status='Found' AND IsDeleted=0", conn).ExecuteScalar()?.ToString() ?? "0";

                    // --- THE FIX ---
                    // 1. Give it text so it calculates the correct width/height
                    lblUserName.Text = "Hello, " + _parentForm.CurrentUser + " !";

                    // 2. Hide the default text so our custom paint can draw over it
                    lblUserName.ForeColor = Color.Transparent;

                    // 3. Prevent duplicate painting by unsubscribing first, then subscribing
                    lblUserName.Paint -= DrawCustomGreeting;
                    lblUserName.Paint += DrawCustomGreeting;
                }
            }
            catch { }
        }

        private void DrawCustomGreeting(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            string displayUser = string.IsNullOrWhiteSpace(_parentForm?.CurrentUser) ? "User" : _parentForm.CurrentUser;

            string part1 = "Hello, ";
            string part2 = displayUser;
            string part3 = "!";

            // 3. Actually DRAW the text with the colors
            using (Font f = new Font("Segoe UI", 32, FontStyle.Bold))
            using (Brush blueBrush = new SolidBrush(Color.FromArgb(74, 144, 226)))
            using (Brush orangeBrush = new SolidBrush(Color.FromArgb(255, 140, 66)))
            {
                float x = 0;
                float y = 0;

                e.Graphics.DrawString(part1, f, blueBrush, x, y);
                x += e.Graphics.MeasureString(part1, f, new PointF(0, 0), StringFormat.GenericTypographic).Width + 5;

                e.Graphics.DrawString(part2, f, orangeBrush, x, y);
                x += e.Graphics.MeasureString(part2, f, new PointF(0, 0), StringFormat.GenericTypographic).Width + 2;

                e.Graphics.DrawString(part3, f, blueBrush, x, y);
            }
        }

        private void btnBell_Click(object sender, EventArgs e)
        {

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            _parentForm.LoadView(new ProfilePanel(_parentForm));
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalText_Click(object sender, EventArgs e)
        {

        }
    }
}