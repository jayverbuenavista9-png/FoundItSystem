namespace FoundItSystem
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.lblNameLbl = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescLbl = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblCatLbl = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblRepLbl = new System.Windows.Forms.Label();
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
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(480, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(27, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(173, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Item Report";
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.lblNameLbl);
            this.pnlBody.Controls.Add(this.txtName);
            this.pnlBody.Controls.Add(this.lblDescLbl);
            this.pnlBody.Controls.Add(this.txtDesc);
            this.pnlBody.Controls.Add(this.lblCatLbl);
            this.pnlBody.Controls.Add(this.cmbCategory);
            this.pnlBody.Controls.Add(this.lblRepLbl);
            this.pnlBody.Controls.Add(this.txtReporter);
            this.pnlBody.Location = new System.Drawing.Point(0, 60);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(480, 415);
            this.pnlBody.TabIndex = 1;
            // 
            // lblNameLbl
            // 
            this.lblNameLbl.AutoSize = true;
            this.lblNameLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNameLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblNameLbl.Location = new System.Drawing.Point(30, 67);
            this.lblNameLbl.Name = "lblNameLbl";
            this.lblNameLbl.Size = new System.Drawing.Size(99, 23);
            this.lblNameLbl.TabIndex = 0;
            this.lblNameLbl.Text = "Item Name";
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtName.Location = new System.Drawing.Point(30, 91);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(420, 34);
            this.txtName.TabIndex = 1;
            // 
            // lblDescLbl
            // 
            this.lblDescLbl.AutoSize = true;
            this.lblDescLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblDescLbl.Location = new System.Drawing.Point(30, 141);
            this.lblDescLbl.Name = "lblDescLbl";
            this.lblDescLbl.Size = new System.Drawing.Size(102, 23);
            this.lblDescLbl.TabIndex = 2;
            this.lblDescLbl.Text = "Description";
            // 
            // txtDesc
            // 
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtDesc.Location = new System.Drawing.Point(30, 165);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(420, 34);
            this.txtDesc.TabIndex = 3;
            // 
            // lblCatLbl
            // 
            this.lblCatLbl.AutoSize = true;
            this.lblCatLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCatLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblCatLbl.Location = new System.Drawing.Point(30, 215);
            this.lblCatLbl.Name = "lblCatLbl";
            this.lblCatLbl.Size = new System.Drawing.Size(84, 23);
            this.lblCatLbl.TabIndex = 4;
            this.lblCatLbl.Text = "Category";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbCategory.Items.AddRange(new object[] {
            "Electronics",
            "Books",
            "Clothing",
            "Accessories",
            "Others"});
            this.cmbCategory.Location = new System.Drawing.Point(30, 239);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(420, 36);
            this.cmbCategory.TabIndex = 5;
            // 
            // lblRepLbl
            // 
            this.lblRepLbl.AutoSize = true;
            this.lblRepLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRepLbl.ForeColor = System.Drawing.Color.Gray;
            this.lblRepLbl.Location = new System.Drawing.Point(30, 289);
            this.lblRepLbl.Name = "lblRepLbl";
            this.lblRepLbl.Size = new System.Drawing.Size(81, 23);
            this.lblRepLbl.TabIndex = 6;
            this.lblRepLbl.Text = "Reporter";
            // 
            // txtReporter
            // 
            this.txtReporter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtReporter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReporter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtReporter.Location = new System.Drawing.Point(30, 313);
            this.txtReporter.Name = "txtReporter";
            this.txtReporter.ReadOnly = true;
            this.txtReporter.Size = new System.Drawing.Size(420, 34);
            this.txtReporter.TabIndex = 7;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(250)))));
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnSubmit);
            this.pnlFooter.Location = new System.Drawing.Point(0, 475);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(480, 70);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Gray;
            this.btnCancel.Location = new System.Drawing.Point(268, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 40);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(365, 15);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 40);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // ReportForm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 545);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report Item";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel    pnlHeader;
        private System.Windows.Forms.Label    lblTitle;
        private System.Windows.Forms.Panel    pnlBody;
        private System.Windows.Forms.Label    lblNameLbl;
        private System.Windows.Forms.TextBox  txtName;
        private System.Windows.Forms.Label    lblDescLbl;
        private System.Windows.Forms.TextBox  txtDesc;
        private System.Windows.Forms.Label    lblCatLbl;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label    lblRepLbl;
        private System.Windows.Forms.TextBox  txtReporter;
        private System.Windows.Forms.Panel    pnlFooter;
        private System.Windows.Forms.Button   btnCancel;
        private System.Windows.Forms.Button   btnSubmit;
    }
}
