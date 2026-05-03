namespace FoundItSystem
{
    partial class EWalletPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblChoose = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.btnRedeem50 = new System.Windows.Forms.Button();
            this.btnRedeem100 = new System.Windows.Forms.Button();
            this.btnRedeem200 = new System.Windows.Forms.Button();
            this.btnRedeem300 = new System.Windows.Forms.Button();
            this.btnRedeem500 = new System.Windows.Forms.Button();
            this.btnRedeem1000 = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnBell = new System.Windows.Forms.Button();
            this.btnRedeem = new System.Windows.Forms.Button();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.lblTitle.Location = new System.Drawing.Point(148, 87);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(420, 81);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "📱 E-WALLET";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lblSubtitle.Location = new System.Drawing.Point(266, 168);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(184, 28);
            this.lblSubtitle.TabIndex = 4;
            this.lblSubtitle.Text = "1 POINT = 1 PESO";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.lblBalance.Location = new System.Drawing.Point(46, 29);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(148, 38);
            this.lblBalance.TabIndex = 3;
            this.lblBalance.Text = "⭐0 points";
            this.lblBalance.Click += new System.EventHandler(this.lblBalance_Click);
            // 
            // lblChoose
            // 
            this.lblChoose.AutoSize = true;
            this.lblChoose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblChoose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblChoose.Location = new System.Drawing.Point(254, 216);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(209, 23);
            this.lblChoose.TabIndex = 1;
            this.lblChoose.Text = "Choose amount to redeem:";
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.Transparent;
            this.pnlGrid.Controls.Add(this.btnRedeem50);
            this.pnlGrid.Controls.Add(this.btnRedeem100);
            this.pnlGrid.Controls.Add(this.btnRedeem200);
            this.pnlGrid.Controls.Add(this.btnRedeem300);
            this.pnlGrid.Controls.Add(this.btnRedeem500);
            this.pnlGrid.Controls.Add(this.btnRedeem1000);
            this.pnlGrid.Location = new System.Drawing.Point(53, 264);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(610, 160);
            this.pnlGrid.TabIndex = 0;
            // 
            // btnRedeem50
            // 
            this.btnRedeem50.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRedeem50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnRedeem50.Location = new System.Drawing.Point(0, 0);
            this.btnRedeem50.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRedeem50.Name = "btnRedeem50";
            this.btnRedeem50.Size = new System.Drawing.Size(190, 72);
            this.btnRedeem50.TabIndex = 0;
            this.btnRedeem50.Text = "50 POINTS\n=\n50 CASH";
            this.btnRedeem50.UseVisualStyleBackColor = false;
            // 
            // btnRedeem100
            // 
            this.btnRedeem100.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRedeem100.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnRedeem100.Location = new System.Drawing.Point(210, 0);
            this.btnRedeem100.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRedeem100.Name = "btnRedeem100";
            this.btnRedeem100.Size = new System.Drawing.Size(190, 72);
            this.btnRedeem100.TabIndex = 1;
            this.btnRedeem100.Text = "100 POINTS\n=\n100 CASH";
            this.btnRedeem100.UseVisualStyleBackColor = false;
            // 
            // btnRedeem200
            // 
            this.btnRedeem200.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRedeem200.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnRedeem200.Location = new System.Drawing.Point(420, 0);
            this.btnRedeem200.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRedeem200.Name = "btnRedeem200";
            this.btnRedeem200.Size = new System.Drawing.Size(190, 72);
            this.btnRedeem200.TabIndex = 2;
            this.btnRedeem200.Text = "200 POINTS\n=\n200 CASH";
            this.btnRedeem200.UseVisualStyleBackColor = false;
            // 
            // btnRedeem300
            // 
            this.btnRedeem300.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRedeem300.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnRedeem300.Location = new System.Drawing.Point(0, 88);
            this.btnRedeem300.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRedeem300.Name = "btnRedeem300";
            this.btnRedeem300.Size = new System.Drawing.Size(190, 72);
            this.btnRedeem300.TabIndex = 3;
            this.btnRedeem300.Text = "300 POINTS\n=\n300 CASH";
            this.btnRedeem300.UseVisualStyleBackColor = false;
            // 
            // btnRedeem500
            // 
            this.btnRedeem500.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRedeem500.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnRedeem500.Location = new System.Drawing.Point(210, 88);
            this.btnRedeem500.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRedeem500.Name = "btnRedeem500";
            this.btnRedeem500.Size = new System.Drawing.Size(190, 72);
            this.btnRedeem500.TabIndex = 4;
            this.btnRedeem500.Text = "500 POINTS\n=\n500 CASH";
            this.btnRedeem500.UseVisualStyleBackColor = false;
            // 
            // btnRedeem1000
            // 
            this.btnRedeem1000.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnRedeem1000.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnRedeem1000.Location = new System.Drawing.Point(420, 88);
            this.btnRedeem1000.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRedeem1000.Name = "btnRedeem1000";
            this.btnRedeem1000.Size = new System.Drawing.Size(190, 72);
            this.btnRedeem1000.TabIndex = 5;
            this.btnRedeem1000.Text = "1000 POINTS\n=\n1000 CASH";
            this.btnRedeem1000.UseVisualStyleBackColor = false;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.Transparent;
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI Emoji", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.Location = new System.Drawing.Point(894, 0);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(50, 94);
            this.btnProfile.TabIndex = 19;
            this.btnProfile.Text = "👤";
            this.btnProfile.UseVisualStyleBackColor = false;
            // 
            // btnBell
            // 
            this.btnBell.BackColor = System.Drawing.Color.Transparent;
            this.btnBell.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBell.FlatAppearance.BorderSize = 0;
            this.btnBell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBell.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnBell.Location = new System.Drawing.Point(944, 0);
            this.btnBell.Name = "btnBell";
            this.btnBell.Size = new System.Drawing.Size(50, 94);
            this.btnBell.TabIndex = 18;
            this.btnBell.Text = "🔔";
            this.btnBell.UseVisualStyleBackColor = false;
            // 
            // btnRedeem
            // 
            this.btnRedeem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRedeem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedeem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRedeem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnRedeem.Location = new System.Drawing.Point(46, 459);
            this.btnRedeem.Name = "btnRedeem";
            this.btnRedeem.Size = new System.Drawing.Size(250, 45);
            this.btnRedeem.TabIndex = 21;
            this.btnRedeem.Text = "💰 Linked Account";
            this.btnRedeem.UseVisualStyleBackColor = true;
            // 
            // EWalletPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.btnRedeem);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnBell);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.lblChoose);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EWalletPanel";
            this.Size = new System.Drawing.Size(1040, 800);
            this.Load += new System.EventHandler(this.EWalletPanel_Load);
            this.pnlGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblChoose;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Button btnRedeem50;
        private System.Windows.Forms.Button btnRedeem100;
        private System.Windows.Forms.Button btnRedeem200;
        private System.Windows.Forms.Button btnRedeem300;
        private System.Windows.Forms.Button btnRedeem500;
        private System.Windows.Forms.Button btnRedeem1000;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnBell;
        private System.Windows.Forms.Button btnRedeem;
    }
}