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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.pnlLogoPlaceholder = new System.Windows.Forms.Panel();
            this.lblTagline = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnLostItems = new System.Windows.Forms.Button();
            this.btnFoundItems = new System.Windows.Forms.Button();
            this.pnlNavSep = new System.Windows.Forms.Panel();
            this.btnReportLost = new System.Windows.Forms.Button();
            this.btnReportFound = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlCentre = new System.Windows.Forms.Panel();
            this.pnlRightDetails = new System.Windows.Forms.Panel();
            this.lblDetName = new System.Windows.Forms.Label();
            this.lblDetStatus = new System.Windows.Forms.Label();
            this.lblDetPeople = new System.Windows.Forms.Label();
            this.lblDescHdr = new System.Windows.Forms.Label();
            this.txtDetDesc = new System.Windows.Forms.TextBox();
            this.lblCommHdr = new System.Windows.Forms.Label();
            this.lbComments = new System.Windows.Forms.ListBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.pnlTableContainer = new System.Windows.Forms.Panel();
            this.pnlGridInner = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblSearchLbl = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblStatusLbl = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.pnlActionBar = new System.Windows.Forms.Panel();
            this.btnClaimItem = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnMarkFound = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNotifs = new System.Windows.Forms.Button();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.homeTbl = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBell = new System.Windows.Forms.Button();
            this.lblGreeting = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.lblQuickFilters = new System.Windows.Forms.Label();
            this.pnlCategories = new System.Windows.Forms.Panel();
            this.pnlNav.SuspendLayout();
            this.pnlCentre.SuspendLayout();
            this.pnlRightDetails.SuspendLayout();
            this.pnlTableContainer.SuspendLayout();
            this.pnlGridInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlTopBar.SuspendLayout();
            this.pnlActionBar.SuspendLayout();
            this.pnlHome.SuspendLayout();
            this.homeTbl.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.pnlNav.Controls.Add(this.pnlLogoPlaceholder);
            this.pnlNav.Controls.Add(this.lblTagline);
            this.pnlNav.Controls.Add(this.btnHome);
            this.pnlNav.Controls.Add(this.btnLostItems);
            this.pnlNav.Controls.Add(this.btnFoundItems);
            this.pnlNav.Controls.Add(this.pnlNavSep);
            this.pnlNav.Controls.Add(this.btnReportLost);
            this.pnlNav.Controls.Add(this.btnReportFound);
            this.pnlNav.Controls.Add(this.btnLogout);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(240, 800);
            this.pnlNav.TabIndex = 1;
            // 
            // pnlLogoPlaceholder
            // 
            this.pnlLogoPlaceholder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.pnlLogoPlaceholder.Location = new System.Drawing.Point(20, 30);
            this.pnlLogoPlaceholder.Name = "pnlLogoPlaceholder";
            this.pnlLogoPlaceholder.Size = new System.Drawing.Size(200, 50);
            this.pnlLogoPlaceholder.TabIndex = 0;
            // 
            // lblTagline
            // 
            this.lblTagline.AutoSize = true;
            this.lblTagline.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTagline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblTagline.Location = new System.Drawing.Point(30, 90);
            this.lblTagline.Name = "lblTagline";
            this.lblTagline.Size = new System.Drawing.Size(180, 23);
            this.lblTagline.TabIndex = 1;
            this.lblTagline.Text = "You lose it, we track it!";
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnHome.Location = new System.Drawing.Point(20, 140);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(200, 45);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.UseVisualStyleBackColor = false;
            // 
            // btnLostItems
            // 
            this.btnLostItems.BackColor = System.Drawing.Color.White;
            this.btnLostItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLostItems.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.btnLostItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLostItems.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLostItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.btnLostItems.Location = new System.Drawing.Point(20, 192);
            this.btnLostItems.Name = "btnLostItems";
            this.btnLostItems.Size = new System.Drawing.Size(200, 45);
            this.btnLostItems.TabIndex = 3;
            this.btnLostItems.Text = "Lost Items";
            this.btnLostItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLostItems.UseVisualStyleBackColor = false;
            // 
            // btnFoundItems
            // 
            this.btnFoundItems.BackColor = System.Drawing.Color.White;
            this.btnFoundItems.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFoundItems.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnFoundItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFoundItems.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnFoundItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnFoundItems.Location = new System.Drawing.Point(20, 244);
            this.btnFoundItems.Name = "btnFoundItems";
            this.btnFoundItems.Size = new System.Drawing.Size(200, 45);
            this.btnFoundItems.TabIndex = 4;
            this.btnFoundItems.Text = "Found Items";
            this.btnFoundItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFoundItems.UseVisualStyleBackColor = false;
            // 
            // pnlNavSep
            // 
            this.pnlNavSep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.pnlNavSep.Location = new System.Drawing.Point(20, 301);
            this.pnlNavSep.Name = "pnlNavSep";
            this.pnlNavSep.Size = new System.Drawing.Size(200, 1);
            this.pnlNavSep.TabIndex = 5;
            // 
            // btnReportLost
            // 
            this.btnReportLost.BackColor = System.Drawing.Color.White;
            this.btnReportLost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportLost.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.btnReportLost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportLost.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnReportLost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.btnReportLost.Location = new System.Drawing.Point(20, 316);
            this.btnReportLost.Name = "btnReportLost";
            this.btnReportLost.Size = new System.Drawing.Size(200, 45);
            this.btnReportLost.TabIndex = 6;
            this.btnReportLost.Text = "Report Lost";
            this.btnReportLost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportLost.UseVisualStyleBackColor = false;
            // 
            // btnReportFound
            // 
            this.btnReportFound.BackColor = System.Drawing.Color.White;
            this.btnReportFound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportFound.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnReportFound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportFound.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnReportFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnReportFound.Location = new System.Drawing.Point(20, 368);
            this.btnReportFound.Name = "btnReportFound";
            this.btnReportFound.Size = new System.Drawing.Size(200, 45);
            this.btnReportFound.TabIndex = 7;
            this.btnReportFound.Text = "Report Found";
            this.btnReportFound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportFound.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btnLogout.Location = new System.Drawing.Point(20, 1395);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 45);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // pnlCentre
            // 
            this.pnlCentre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pnlCentre.Controls.Add(this.pnlRightDetails);
            this.pnlCentre.Controls.Add(this.pnlTableContainer);
            this.pnlCentre.Controls.Add(this.pnlHome);
            this.pnlCentre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCentre.Location = new System.Drawing.Point(240, 0);
            this.pnlCentre.Name = "pnlCentre";
            this.pnlCentre.Size = new System.Drawing.Size(1040, 800);
            this.pnlCentre.TabIndex = 0;
            // 
            // pnlRightDetails
            // 
            this.pnlRightDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.pnlRightDetails.Controls.Add(this.lblDetName);
            this.pnlRightDetails.Controls.Add(this.lblDetStatus);
            this.pnlRightDetails.Controls.Add(this.lblDetPeople);
            this.pnlRightDetails.Controls.Add(this.lblDescHdr);
            this.pnlRightDetails.Controls.Add(this.txtDetDesc);
            this.pnlRightDetails.Controls.Add(this.lblCommHdr);
            this.pnlRightDetails.Controls.Add(this.lbComments);
            this.pnlRightDetails.Controls.Add(this.txtComment);
            this.pnlRightDetails.Controls.Add(this.btnSend);
            this.pnlRightDetails.Dock = System.Windows.Forms.DockStyle.None;
            this.pnlRightDetails.Location = new System.Drawing.Point(680, 0);
            this.pnlRightDetails.Name = "pnlRightDetails";
            this.pnlRightDetails.Padding = new System.Windows.Forms.Padding(15);
            this.pnlRightDetails.Size = new System.Drawing.Size(360, 800);
            this.pnlRightDetails.TabIndex = 0;
            this.pnlRightDetails.Visible = false;
            // 
            // lblDetName
            // 
            this.lblDetName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.lblDetName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDetName.ForeColor = System.Drawing.Color.White;
            this.lblDetName.Location = new System.Drawing.Point(15, 20);
            this.lblDetName.Name = "lblDetName";
            this.lblDetName.Size = new System.Drawing.Size(330, 35);
            this.lblDetName.TabIndex = 0;
            this.lblDetName.Text = "Select an item...";
            // 
            // lblDetStatus
            // 
            this.lblDetStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.lblDetStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDetStatus.ForeColor = System.Drawing.Color.Black;
            this.lblDetStatus.Location = new System.Drawing.Point(15, 60);
            this.lblDetStatus.Name = "lblDetStatus";
            this.lblDetStatus.Size = new System.Drawing.Size(200, 24);
            this.lblDetStatus.TabIndex = 1;
            // 
            // lblDetPeople
            // 
            this.lblDetPeople.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.lblDetPeople.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDetPeople.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.lblDetPeople.Location = new System.Drawing.Point(15, 92);
            this.lblDetPeople.Name = "lblDetPeople";
            this.lblDetPeople.Size = new System.Drawing.Size(330, 40);
            this.lblDetPeople.TabIndex = 2;
            // 
            // lblDescHdr
            // 
            this.lblDescHdr.AutoSize = true;
            this.lblDescHdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.lblDescHdr.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDescHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.lblDescHdr.Location = new System.Drawing.Point(15, 140);
            this.lblDescHdr.Name = "lblDescHdr";
            this.lblDescHdr.Size = new System.Drawing.Size(102, 23);
            this.lblDescHdr.TabIndex = 3;
            this.lblDescHdr.Text = "Description";
            // 
            // txtDetDesc
            // 
            this.txtDetDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.txtDetDesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetDesc.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            this.txtDetDesc.ForeColor = System.Drawing.Color.White;
            this.txtDetDesc.Location = new System.Drawing.Point(15, 165);
            this.txtDetDesc.Multiline = true;
            this.txtDetDesc.Name = "txtDetDesc";
            this.txtDetDesc.ReadOnly = true;
            this.txtDetDesc.Size = new System.Drawing.Size(330, 70);
            this.txtDetDesc.TabIndex = 4;
            // 
            // lblCommHdr
            // 
            this.lblCommHdr.AutoSize = true;
            this.lblCommHdr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.lblCommHdr.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCommHdr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.lblCommHdr.Location = new System.Drawing.Point(15, 245);
            this.lblCommHdr.Name = "lblCommHdr";
            this.lblCommHdr.Size = new System.Drawing.Size(96, 23);
            this.lblCommHdr.TabIndex = 5;
            this.lblCommHdr.Text = "Comments";
            // 
            // lbComments
            // 
            this.lbComments.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.lbComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbComments.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbComments.ItemHeight = 23;
            this.lbComments.Location = new System.Drawing.Point(15, 270);
            this.lbComments.Name = "lbComments";
            this.lbComments.Size = new System.Drawing.Size(330, 207);
            this.lbComments.TabIndex = 6;
            // 
            // txtComment
            // 
            this.txtComment.BackColor = System.Drawing.Color.White;
            this.txtComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComment.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtComment.Location = new System.Drawing.Point(15, 506);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(252, 32);
            this.txtComment.TabIndex = 7;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(273, 500);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(74, 43);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = false;
            // 
            // pnlTableContainer
            // 
            this.pnlTableContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pnlTableContainer.Controls.Add(this.pnlGridInner);
            this.pnlTableContainer.Controls.Add(this.pnlActionBar);
            this.pnlTableContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlTableContainer.Name = "pnlTableContainer";
            this.pnlTableContainer.Size = new System.Drawing.Size(1040, 800);
            this.pnlTableContainer.TabIndex = 1;
            this.pnlTableContainer.Visible = false;
            // 
            // pnlGridInner
            // 
            this.pnlGridInner.Controls.Add(this.dgv);
            this.pnlGridInner.Controls.Add(this.pnlTopBar);
            this.pnlGridInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridInner.Location = new System.Drawing.Point(0, 0);
            this.pnlGridInner.Name = "pnlGridInner";
            this.pnlGridInner.Size = new System.Drawing.Size(1040, 745);
            this.pnlGridInner.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.ColumnHeadersHeight = 40;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(220)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgv.Location = new System.Drawing.Point(0, 60);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 35;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1040, 685);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.Controls.Add(this.lblSearchLbl);
            this.pnlTopBar.Controls.Add(this.txtSearch);
            this.pnlTopBar.Controls.Add(this.btnSearch);
            this.pnlTopBar.Controls.Add(this.lblStatusLbl);
            this.pnlTopBar.Controls.Add(this.cmbFilter);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1040, 60);
            this.pnlTopBar.TabIndex = 1;
            // 
            // lblSearchLbl
            // 
            this.lblSearchLbl.AutoSize = true;
            this.lblSearchLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearchLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.lblSearchLbl.Location = new System.Drawing.Point(10, 20);
            this.lblSearchLbl.Name = "lblSearchLbl";
            this.lblSearchLbl.Size = new System.Drawing.Size(68, 23);
            this.lblSearchLbl.TabIndex = 0;
            this.lblSearchLbl.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Location = new System.Drawing.Point(81, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 32);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(291, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 36);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblStatusLbl
            // 
            this.lblStatusLbl.AutoSize = true;
            this.lblStatusLbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.lblStatusLbl.Location = new System.Drawing.Point(396, 20);
            this.lblStatusLbl.Name = "lblStatusLbl";
            this.lblStatusLbl.Size = new System.Drawing.Size(65, 23);
            this.lblStatusLbl.TabIndex = 3;
            this.lblStatusLbl.Text = "Status:";
            this.lblStatusLbl.Click += new System.EventHandler(this.lblStatusLbl_Click);
            // 
            // cmbFilter
            // 
            this.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilter.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbFilter.Items.AddRange(new object[] {
            "All",
            "Lost",
            "Found",
            "Pending Claim",
            "Claimed",
            "In Trash"});
            this.cmbFilter.Location = new System.Drawing.Point(461, 14);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(160, 33);
            this.cmbFilter.TabIndex = 4;
            this.cmbFilter.SelectedIndexChanged += new System.EventHandler(this.cmbFilter_SelectedIndexChanged);
            // 
            // pnlActionBar
            // 
            this.pnlActionBar.BackColor = System.Drawing.Color.White;
            this.pnlActionBar.Controls.Add(this.btnClaimItem);
            this.pnlActionBar.Controls.Add(this.btnApprove);
            this.pnlActionBar.Controls.Add(this.btnMarkFound);
            this.pnlActionBar.Controls.Add(this.btnDelete);
            this.pnlActionBar.Controls.Add(this.btnNotifs);
            this.pnlActionBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlActionBar.Location = new System.Drawing.Point(0, 745);
            this.pnlActionBar.Name = "pnlActionBar";
            this.pnlActionBar.Size = new System.Drawing.Size(1040, 55);
            this.pnlActionBar.TabIndex = 1;
            this.pnlActionBar.Visible = false;
            // 
            // btnClaimItem
            // 
            this.btnClaimItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(140)))), ((int)(((byte)(66)))));
            this.btnClaimItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClaimItem.FlatAppearance.BorderSize = 0;
            this.btnClaimItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClaimItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClaimItem.ForeColor = System.Drawing.Color.White;
            this.btnClaimItem.Location = new System.Drawing.Point(10, 10);
            this.btnClaimItem.Name = "btnClaimItem";
            this.btnClaimItem.Size = new System.Drawing.Size(115, 36);
            this.btnClaimItem.TabIndex = 0;
            this.btnClaimItem.Text = "Claim Item";
            this.btnClaimItem.UseVisualStyleBackColor = false;
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(130, 10);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(115, 36);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            // 
            // btnMarkFound
            // 
            this.btnMarkFound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnMarkFound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarkFound.FlatAppearance.BorderSize = 0;
            this.btnMarkFound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkFound.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMarkFound.ForeColor = System.Drawing.Color.White;
            this.btnMarkFound.Location = new System.Drawing.Point(260, 10);
            this.btnMarkFound.Name = "btnMarkFound";
            this.btnMarkFound.Size = new System.Drawing.Size(115, 36);
            this.btnMarkFound.TabIndex = 2;
            this.btnMarkFound.Text = "Mark Found";
            this.btnMarkFound.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(380, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(115, 36);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnNotifs
            // 
            this.btnNotifs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.btnNotifs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotifs.FlatAppearance.BorderSize = 0;
            this.btnNotifs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotifs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNotifs.ForeColor = System.Drawing.Color.White;
            this.btnNotifs.Location = new System.Drawing.Point(500, 10);
            this.btnNotifs.Name = "btnNotifs";
            this.btnNotifs.Size = new System.Drawing.Size(115, 36);
            this.btnNotifs.TabIndex = 4;
            this.btnNotifs.Text = "Notifs";
            this.btnNotifs.UseVisualStyleBackColor = false;
            // 
            // pnlHome
            // 
            this.pnlHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pnlHome.Controls.Add(this.homeTbl);
            this.pnlHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHome.Location = new System.Drawing.Point(0, 0);
            this.pnlHome.Name = "pnlHome";
            this.pnlHome.Padding = new System.Windows.Forms.Padding(0);
            this.pnlHome.Size = new System.Drawing.Size(1040, 800);
            this.pnlHome.TabIndex = 2;
            // 
            // homeTbl
            // 
            this.homeTbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.homeTbl.ColumnCount = 1;
            this.homeTbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.homeTbl.Controls.Add(this.pnlHeader, 0, 0);
            this.homeTbl.Controls.Add(this.pnlStats, 0, 1);
            this.homeTbl.Controls.Add(this.pnlActions, 0, 2);
            this.homeTbl.Controls.Add(this.lblQuickFilters, 0, 3);
            this.homeTbl.Controls.Add(this.pnlCategories, 0, 4);
            this.homeTbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homeTbl.Location = new System.Drawing.Point(0, 0);
            this.homeTbl.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.homeTbl.Name = "homeTbl";
            this.homeTbl.RowCount = 5;
            this.homeTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.homeTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.homeTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.homeTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.homeTbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.homeTbl.Size = new System.Drawing.Size(960, 760);
            this.homeTbl.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pnlHeader.Controls.Add(this.btnBell);
            this.pnlHeader.Controls.Add(this.lblGreeting);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(954, 84);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnBell
            // 
            this.btnBell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.btnBell.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBell.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBell.FlatAppearance.BorderSize = 0;
            this.btnBell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBell.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnBell.Location = new System.Drawing.Point(904, 0);
            this.btnBell.Name = "btnBell";
            this.btnBell.Size = new System.Drawing.Size(50, 84);
            this.btnBell.TabIndex = 0;
            this.btnBell.Text = "Bell";
            this.btnBell.UseVisualStyleBackColor = false;
            // 
            // lblGreeting
            // 
            this.lblGreeting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGreeting.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblGreeting.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.lblGreeting.Location = new System.Drawing.Point(0, 0);
            this.lblGreeting.Name = "lblGreeting";
            this.lblGreeting.Size = new System.Drawing.Size(954, 84);
            this.lblGreeting.TabIndex = 1;
            this.lblGreeting.Text = "Hello!\nWhat are we looking for today?";
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStats.Location = new System.Drawing.Point(3, 93);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(954, 114);
            this.pnlStats.TabIndex = 1;
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActions.Location = new System.Drawing.Point(3, 213);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(954, 104);
            this.pnlActions.TabIndex = 2;
            // 
            // lblQuickFilters
            // 
            this.lblQuickFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuickFilters.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblQuickFilters.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(80)))));
            this.lblQuickFilters.Location = new System.Drawing.Point(3, 320);
            this.lblQuickFilters.Name = "lblQuickFilters";
            this.lblQuickFilters.Size = new System.Drawing.Size(954, 28);
            this.lblQuickFilters.TabIndex = 3;
            this.lblQuickFilters.Text = "Quick Filters";
            // 
            // pnlCategories
            // 
            this.pnlCategories.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.pnlCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategories.Location = new System.Drawing.Point(3, 351);
            this.pnlCategories.Name = "pnlCategories";
            this.pnlCategories.Size = new System.Drawing.Size(954, 406);
            this.pnlCategories.TabIndex = 4;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1280, 800);
            this.Controls.Add(this.pnlCentre);
            this.Controls.Add(this.pnlNav);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FOUNDIT - Search & Claim System";
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            this.pnlCentre.ResumeLayout(false);
            this.pnlRightDetails.ResumeLayout(false);
            this.pnlRightDetails.PerformLayout();
            this.pnlTableContainer.ResumeLayout(false);
            this.pnlGridInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlActionBar.ResumeLayout(false);
            this.pnlHome.ResumeLayout(false);
            this.homeTbl.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel        pnlNav;
        private System.Windows.Forms.Panel        pnlLogoPlaceholder;
        private System.Windows.Forms.Label        lblTagline;
        private System.Windows.Forms.Button       btnHome;
        private System.Windows.Forms.Button       btnLostItems;
        private System.Windows.Forms.Button       btnFoundItems;
        private System.Windows.Forms.Panel        pnlNavSep;
        private System.Windows.Forms.Button       btnReportLost;
        private System.Windows.Forms.Button       btnReportFound;
        private System.Windows.Forms.Button       btnLogout;
        private System.Windows.Forms.Panel        pnlCentre;
        private System.Windows.Forms.Panel        pnlHome;
        private System.Windows.Forms.Label        lblGreeting;
        private System.Windows.Forms.Button       btnBell;
        private System.Windows.Forms.Panel        pnlStats;
        private System.Windows.Forms.Panel        pnlActions;
        private System.Windows.Forms.Label        lblQuickFilters;
        private System.Windows.Forms.Panel        pnlCategories;
        private System.Windows.Forms.Panel        pnlTableContainer;
        private System.Windows.Forms.Panel        pnlTopBar;
        private System.Windows.Forms.Label        lblSearchLbl;
        private System.Windows.Forms.TextBox      txtSearch;
        private System.Windows.Forms.Button       btnSearch;
        private System.Windows.Forms.Label        lblStatusLbl;
        private System.Windows.Forms.ComboBox     cmbFilter;
        private System.Windows.Forms.Panel        pnlGridInner;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel        pnlActionBar;
        private System.Windows.Forms.Button       btnClaimItem;
        private System.Windows.Forms.Button       btnApprove;
        private System.Windows.Forms.Button       btnMarkFound;
        private System.Windows.Forms.Button       btnDelete;
        private System.Windows.Forms.Button       btnNotifs;
        private System.Windows.Forms.Panel        pnlRightDetails;
        private System.Windows.Forms.Label        lblDetName;
        private System.Windows.Forms.Label        lblDetStatus;
        private System.Windows.Forms.Label        lblDetPeople;
        private System.Windows.Forms.Label        lblDescHdr;
        private System.Windows.Forms.TextBox      txtDetDesc;
        private System.Windows.Forms.Label        lblCommHdr;
        private System.Windows.Forms.ListBox      lbComments;
        private System.Windows.Forms.TextBox      txtComment;
        private System.Windows.Forms.Button       btnSend;
        private System.Windows.Forms.TableLayoutPanel homeTbl;
        private System.Windows.Forms.Panel pnlHeader;
    }
}
