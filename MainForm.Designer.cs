namespace FoundItSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlNav = new System.Windows.Forms.Panel();
            this.logoPanel1 = new FoundItSystem.LogoPanel();
            this.lblTagline = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnLostItems = new System.Windows.Forms.Button();
            this.btnFoundItems = new System.Windows.Forms.Button();
            this.pnlNavSep = new System.Windows.Forms.Panel();
            this.btnReportLost = new System.Windows.Forms.Button();
            this.btnReportFound = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlNav.Controls.Add(this.logoPanel1);
            this.pnlNav.Controls.Add(this.lblTagline);
            this.pnlNav.Controls.Add(this.btnHome);
            this.pnlNav.Controls.Add(this.btnLostItems);
            this.pnlNav.Controls.Add(this.btnFoundItems);
            this.pnlNav.Controls.Add(this.pnlNavSep);
            this.pnlNav.Controls.Add(this.btnReportLost);
            this.pnlNav.Controls.Add(this.btnReportFound);
            this.pnlNav.Controls.Add(this.panel1);
            this.pnlNav.Controls.Add(this.btnLogout);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(240, 800);
            this.pnlNav.TabIndex = 1;
            this.pnlNav.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlNav_Paint);
            // 
            // logoPanel1
            // 
            this.logoPanel1.BackColor = System.Drawing.Color.Transparent;
            this.logoPanel1.Location = new System.Drawing.Point(21, 117);
            this.logoPanel1.Name = "logoPanel1";
            this.logoPanel1.Size = new System.Drawing.Size(192, 87);
            this.logoPanel1.TabIndex = 8;
            this.logoPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.logoPanel1_Paint);
            // 
            // lblTagline
            // 
            this.lblTagline.AutoSize = true;
            this.lblTagline.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTagline.Location = new System.Drawing.Point(36, 207);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(180, 23);
            this.lblTagline.TabIndex = 1;
            this.lblTagline.Text = "You lose it, we track it!";
            this.lblTagline.Click += new System.EventHandler(this.lblTagline_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnHome.Location = new System.Drawing.Point(16, 292);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(200, 45);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnLostItems
            // 
            this.btnLostItems.BackColor = System.Drawing.Color.Transparent;
            this.btnLostItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLostItems.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.btnLostItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLostItems.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLostItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.btnLostItems.Location = new System.Drawing.Point(16, 344);
            this.btnLostItems.Name = "btnLostItems";
            this.btnLostItems.Size = new System.Drawing.Size(200, 45);
            this.btnLostItems.TabIndex = 3;
            this.btnLostItems.Text = "Lost Items";
            this.btnLostItems.UseVisualStyleBackColor = false;
            this.btnLostItems.Click += new System.EventHandler(this.btnLostItems_Click);
            // 
            // btnFoundItems
            // 
            this.btnFoundItems.BackColor = System.Drawing.Color.Transparent;
            this.btnFoundItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoundItems.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnFoundItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFoundItems.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnFoundItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnFoundItems.Location = new System.Drawing.Point(16, 396);
            this.btnFoundItems.Name = "btnFoundItems";
            this.btnFoundItems.Size = new System.Drawing.Size(200, 45);
            this.btnFoundItems.TabIndex = 4;
            this.btnFoundItems.Text = "Found Items";
            this.btnFoundItems.UseVisualStyleBackColor = false;
            this.btnFoundItems.Click += new System.EventHandler(this.btnFoundItems_Click);
            // 
            // pnlNavSep
            // 
            this.pnlNavSep.BackColor = System.Drawing.Color.DarkKhaki;
            this.pnlNavSep.Location = new System.Drawing.Point(16, 453);
            this.pnlNavSep.Name = "pnlNavSep";
            this.pnlNavSep.Size = new System.Drawing.Size(200, 1);
            this.pnlNavSep.TabIndex = 5;
            // 
            // btnReportLost
            // 
            this.btnReportLost.BackColor = System.Drawing.Color.Transparent;
            this.btnReportLost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportLost.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.btnReportLost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportLost.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnReportLost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.btnReportLost.Location = new System.Drawing.Point(16, 469);
            this.btnReportLost.Name = "btnReportLost";
            this.btnReportLost.Size = new System.Drawing.Size(200, 45);
            this.btnReportLost.TabIndex = 6;
            this.btnReportLost.Text = "Report Lost";
            this.btnReportLost.UseVisualStyleBackColor = false;
            // 
            // btnReportFound
            // 
            this.btnReportFound.BackColor = System.Drawing.Color.Transparent;
            this.btnReportFound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportFound.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnReportFound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportFound.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnReportFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnReportFound.Location = new System.Drawing.Point(16, 520);
            this.btnReportFound.Name = "btnReportFound";
            this.btnReportFound.Size = new System.Drawing.Size(200, 45);
            this.btnReportFound.TabIndex = 7;
            this.btnReportFound.Text = "Report Found";
            this.btnReportFound.UseVisualStyleBackColor = false;
            this.btnReportFound.Click += new System.EventHandler(this.btnReportFound_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkKhaki;
            this.panel1.Location = new System.Drawing.Point(16, 580);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 1);
            this.panel1.TabIndex = 6;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btnLogout.Location = new System.Drawing.Point(16, 597);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 45);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(240, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1040, 800);
            this.pnlContent.TabIndex = 0;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlNav);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FOUNDIT - Search & Claim System";
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel        pnlNav;
        private System.Windows.Forms.Label        lblTagline;
        private System.Windows.Forms.Button       btnHome;
        private System.Windows.Forms.Button       btnLostItems;
        private System.Windows.Forms.Button       btnFoundItems;
        private System.Windows.Forms.Panel        pnlNavSep;
        private System.Windows.Forms.Button       btnReportLost;
        private System.Windows.Forms.Button       btnReportFound;
        private System.Windows.Forms.Button       btnLogout;
        private System.Windows.Forms.Panel pnlContent;
        private LogoPanel logoPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}
