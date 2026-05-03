namespace FoundItSystem
{
    partial class ReportLostForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.txtSpecificAmount = new System.Windows.Forms.TextBox();
            this.lbl_pts = new System.Windows.Forms.Label();
            this.lblSpecificAmount = new System.Windows.Forms.Label();
            this.btnPoints150 = new System.Windows.Forms.Button();
            this.btnPoints100 = new System.Windows.Forms.Button();
            this.btnPoints50 = new System.Windows.Forms.Button();
            this.btnPoints25 = new System.Windows.Forms.Button();
            this.lbl_reporter = new System.Windows.Forms.Label();
            this.lblNameLbl = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescLbl = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblCatLbl = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtReporter = new System.Windows.Forms.TextBox();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(480, 60);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(27, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(234, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Lost Item Report";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.txtSpecificAmount);
            this.pnlBody.Controls.Add(this.lbl_pts);
            this.pnlBody.Controls.Add(this.lblSpecificAmount);
            this.pnlBody.Controls.Add(this.btnPoints150);
            this.pnlBody.Controls.Add(this.btnPoints100);
            this.pnlBody.Controls.Add(this.btnPoints50);
            this.pnlBody.Controls.Add(this.btnPoints25);
            this.pnlBody.Controls.Add(this.lbl_reporter);
            this.pnlBody.Controls.Add(this.lblNameLbl);
            this.pnlBody.Controls.Add(this.txtName);
            this.pnlBody.Controls.Add(this.lblDescLbl);
            this.pnlBody.Controls.Add(this.txtDesc);
            this.pnlBody.Controls.Add(this.lblCatLbl);
            this.pnlBody.Controls.Add(this.cmbCategory);
            this.pnlBody.Controls.Add(this.txtReporter);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 60);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(480, 485);
            this.pnlBody.TabIndex = 2;
            // 
            // txtSpecificAmount
            // 
            this.txtSpecificAmount.BackColor = System.Drawing.Color.White;
            this.txtSpecificAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpecificAmount.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpecificAmount.Location = new System.Drawing.Point(188, 380);
            this.txtSpecificAmount.Name = "txtSpecificAmount";
            this.txtSpecificAmount.Size = new System.Drawing.Size(64, 30);
            this.txtSpecificAmount.TabIndex = 17;
            this.txtSpecificAmount.TextChanged += new System.EventHandler(this.txtSpecificAmount_TextChanged);
            // 
            // lbl_pts
            // 
            this.lbl_pts.AutoSize = true;
            this.lbl_pts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_pts.ForeColor = System.Drawing.Color.Gray;
            this.lbl_pts.Location = new System.Drawing.Point(21, 308);
            this.lbl_pts.Name = "lbl_pts";
            this.lbl_pts.Size = new System.Drawing.Size(180, 23);
            this.lbl_pts.TabIndex = 16;
            this.lbl_pts.Text = "Points for the Finder:";
            this.lbl_pts.Click += new System.EventHandler(this.lbl_pts_Click_1);
            // 
            // lblSpecificAmount
            // 
            this.lblSpecificAmount.AutoSize = true;
            this.lblSpecificAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSpecificAmount.ForeColor = System.Drawing.Color.Gray;
            this.lblSpecificAmount.Location = new System.Drawing.Point(25, 382);
            this.lblSpecificAmount.Name = "lblSpecificAmount";
            this.lblSpecificAmount.Size = new System.Drawing.Size(148, 23);
            this.lblSpecificAmount.TabIndex = 15;
            this.lblSpecificAmount.Text = "Specific Amount:";
            // 
            // btnPoints150
            // 
            this.btnPoints150.BackColor = System.Drawing.Color.PeachPuff;
            this.btnPoints150.Location = new System.Drawing.Point(377, 334);
            this.btnPoints150.Name = "btnPoints150";
            this.btnPoints150.Size = new System.Drawing.Size(68, 36);
            this.btnPoints150.TabIndex = 14;
            this.btnPoints150.Text = "150";
            this.btnPoints150.UseVisualStyleBackColor = false;
            this.btnPoints150.Click += new System.EventHandler(this.btnPoints150_Click);
            // 
            // btnPoints100
            // 
            this.btnPoints100.BackColor = System.Drawing.Color.PeachPuff;
            this.btnPoints100.Location = new System.Drawing.Point(264, 334);
            this.btnPoints100.Name = "btnPoints100";
            this.btnPoints100.Size = new System.Drawing.Size(68, 36);
            this.btnPoints100.TabIndex = 13;
            this.btnPoints100.Text = "100";
            this.btnPoints100.UseVisualStyleBackColor = false;
            this.btnPoints100.Click += new System.EventHandler(this.btnPoints100_Click);
            // 
            // btnPoints50
            // 
            this.btnPoints50.BackColor = System.Drawing.Color.PeachPuff;
            this.btnPoints50.Location = new System.Drawing.Point(141, 334);
            this.btnPoints50.Name = "btnPoints50";
            this.btnPoints50.Size = new System.Drawing.Size(68, 36);
            this.btnPoints50.TabIndex = 12;
            this.btnPoints50.Text = "50";
            this.btnPoints50.UseVisualStyleBackColor = false;
            this.btnPoints50.Click += new System.EventHandler(this.btnPoints50_Click);
            // 
            // btnPoints25
            // 
            this.btnPoints25.BackColor = System.Drawing.Color.PeachPuff;
            this.btnPoints25.Location = new System.Drawing.Point(25, 334);
            this.btnPoints25.Name = "btnPoints25";
            this.btnPoints25.Size = new System.Drawing.Size(68, 36);
            this.btnPoints25.TabIndex = 11;
            this.btnPoints25.Text = "25";
            this.btnPoints25.UseVisualStyleBackColor = false;
            this.btnPoints25.Click += new System.EventHandler(this.btnPoints25_Click);
            // 
            // lbl_reporter
            // 
            this.lbl_reporter.AutoSize = true;
            this.lbl_reporter.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_reporter.ForeColor = System.Drawing.Color.Gray;
            this.lbl_reporter.Location = new System.Drawing.Point(21, 237);
            this.lbl_reporter.Name = "lbl_reporter";
            this.lbl_reporter.Size = new System.Drawing.Size(81, 23);
            this.lbl_reporter.TabIndex = 10;
            this.lbl_reporter.Text = "Reporter";
            // 
            // lblNameLbl
            // 
            this.lblNameLbl.AutoSize = true;
            this.lblNameLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNameLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblNameLbl.Location = new System.Drawing.Point(21, 11);
            this.lblNameLbl.Name = "lblNameLbl";
            this.lblNameLbl.Size = new System.Drawing.Size(99, 23);
            this.lblNameLbl.TabIndex = 0;
            this.lblNameLbl.Text = "Item Name";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtName.Location = new System.Drawing.Point(25, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(420, 34);
            this.txtName.TabIndex = 1;
            // 
            // lblDescLbl
            // 
            this.lblDescLbl.AutoSize = true;
            this.lblDescLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblDescLbl.Location = new System.Drawing.Point(21, 85);
            this.lblDescLbl.Name = "lblDescLbl";
            this.lblDescLbl.Size = new System.Drawing.Size(102, 23);
            this.lblDescLbl.TabIndex = 2;
            this.lblDescLbl.Text = "Description";
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.White;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDesc.Location = new System.Drawing.Point(25, 111);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(420, 34);
            this.txtDesc.TabIndex = 3;
            // 
            // lblCatLbl
            // 
            this.lblCatLbl.AutoSize = true;
            this.lblCatLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCatLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblCatLbl.Location = new System.Drawing.Point(21, 160);
            this.lblCatLbl.Name = "lblCatLbl";
            this.lblCatLbl.Size = new System.Drawing.Size(84, 23);
            this.lblCatLbl.TabIndex = 4;
            this.lblCatLbl.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.White;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbCategory.Items.AddRange(new object[] {
            "Electronics",
            "Books",
            "Clothing",
            "Accessories",
            "Others"});
            this.cmbCategory.Location = new System.Drawing.Point(25, 186);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(420, 36);
            this.cmbCategory.TabIndex = 5;
            // 
            // txtReporter
            // 
            this.txtReporter.BackColor = System.Drawing.Color.White;
            this.txtReporter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReporter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtReporter.Location = new System.Drawing.Point(25, 263);
            this.txtReporter.Name = "txtReporter";
            this.txtReporter.ReadOnly = true;
            this.txtReporter.Size = new System.Drawing.Size(420, 34);
            this.txtReporter.TabIndex = 7;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSubmit);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 483);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(480, 62);
            this.pnlFooter.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Gray;
            this.btnCancel.Location = new System.Drawing.Point(259, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(103, 40);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(368, 10);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 40);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // ReportLostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 545);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.MaximizeBox = false;
            this.Name = "ReportLostForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportLostForm";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblNameLbl;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescLbl;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblCatLbl;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtReporter;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lbl_reporter;
        private System.Windows.Forms.Button btnPoints25;
        private System.Windows.Forms.Button btnPoints150;
        private System.Windows.Forms.Button btnPoints100;
        private System.Windows.Forms.Button btnPoints50;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSpecificAmount;
        private System.Windows.Forms.Label lbl_pts;
        private System.Windows.Forms.TextBox txtSpecificAmount;
    }
}