using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class MainForm : Form
    {
        public readonly string CurrentUser;
        public readonly bool IsAdmin;

        // This tracks which tab is currently selected
        private Button _activeButton;

        public MainForm(string user, bool admin)
        {
            CurrentUser = user;
            IsAdmin = admin;
            InitializeComponent();

            // 1. Setup Sidebar Hover & Active Indicators
            Button[] navButtons = { btnHome, btnLostItems, btnFoundItems, btnReportLost, btnReportFound };
            foreach (var btn in navButtons)
            {
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatStyle = FlatStyle.Flat;
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.FromArgb(60, 70, 80); // Default dark gray text
                btn.Cursor = Cursors.Hand;

                // When the mouse enters the button (Hover)
                btn.MouseEnter += (s, e) =>
                {
                    if (btn != _activeButton) // Only hover if it's not the currently active tab
                    {
                        btn.BackColor = Color.FromArgb(255, 225, 210); // Light orange background
                        btn.ForeColor = Color.FromArgb(255, 140, 66);  // Orange text
                    }
                };

                // When the mouse leaves the button
                btn.MouseLeave += (s, e) =>
                {
                    if (btn != _activeButton)
                    {
                        btn.BackColor = Color.Transparent;
                        btn.ForeColor = Color.FromArgb(60, 70, 80);
                    }
                };
            }

            // Custom hover specifically for the Logout button (turns red)
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.MouseEnter += (s, e) => { btnLogout.BackColor = Color.FromArgb(231, 76, 60); btnLogout.ForeColor = Color.White; };
            btnLogout.MouseLeave += (s, e) => { btnLogout.BackColor = Color.Transparent; btnLogout.ForeColor = Color.FromArgb(60, 70, 80); };

            // 2. Keep the Navigation Gradient
            pnlNav.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var br = new SolidBrush(Color.FromArgb(255, 255, 192));
                e.Graphics.FillRectangle(br, pnlNav.ClientRectangle);
            };

            // 3. Force Panels to Load on Click
            btnHome.Click += (s, e) => { SetActiveTab(btnHome); LoadView(new HomePanel(this)); };
            btnLostItems.Click += (s, e) => { SetActiveTab(btnLostItems); LoadView(new LostItemsPanel(this)); };
            btnFoundItems.Click += (s, e) => { SetActiveTab(btnFoundItems); LoadView(new FoundItemsPanel(this)); };

            btnReportLost.Click += (s, e) => { new ReportLostForm(CurrentUser).ShowDialog(); LoadCurrentView(); };
            btnReportFound.Click += (s, e) => { new ReportFoundForm(CurrentUser).ShowDialog(); LoadCurrentView(); };
            btnLogout.Click += (s, e) => { new LoginForm().Show(); this.Hide(); };


            SetActiveTab(btnHome);
            LoadView(new HomePanel(this));
        }

        // Helper method to change colors of the clicked button
        private void SetActiveTab(Button clickedBtn)
        {
            // Reset the old active button back to normal
            if (_activeButton != null)
            {
                _activeButton.BackColor = Color.Transparent;
                _activeButton.ForeColor = Color.FromArgb(60, 70, 80);
            }

            // Light up the new clicked button
            _activeButton = clickedBtn;
            _activeButton.BackColor = Color.FromArgb(255, 140, 66); // Solid Orange Background
            _activeButton.ForeColor = Color.White; // White text
        }

        public void LoadView(UserControl view)
        {
            pnlContent.Controls.Clear();
            view.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(view);
            view.BringToFront(); // FORCES the panel to the very front so it cannot hide!
            view.Show();
        }

        public void LoadCurrentView()
        {
            if (pnlContent.Controls.Count > 0 && pnlContent.Controls[0] is HomePanel home) home.RefreshDashboard();
            else if (pnlContent.Controls.Count > 0 && pnlContent.Controls[0] is LostItemsPanel lost) lost.LoadTable();
            else if (pnlContent.Controls.Count > 0 && pnlContent.Controls[0] is FoundItemsPanel found) found.LoadTable();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit(); // Forces the entire application to shut down, including the hidden login form
        }

        private void btnReportFound_Click(object sender, EventArgs e)
        {

        }

        private void pnlNav_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logoPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTagline_Click(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {

        }

        private void btnLostItems_Click(object sender, EventArgs e)
        {

        }

        private void btnFoundItems_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }
    }
}