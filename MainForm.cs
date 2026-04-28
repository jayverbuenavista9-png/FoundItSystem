using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class MainForm : Form
    {
        static readonly Color BLUE      = Color.FromArgb(74, 144, 226);
        static readonly Color BLUE_DARK = Color.FromArgb(30, 90, 160);
        static readonly Color ORANGE    = Color.FromArgb(255, 140, 66);
        static readonly Color GREEN     = Color.FromArgb(46, 204, 113);
        static readonly Color RED       = Color.FromArgb(231, 76, 60);
        static readonly Color BG_MAIN   = Color.FromArgb(250, 252, 255);
        static readonly Color BG_PANEL  = Color.White;
        static readonly Color NAV_BG    = Color.FromArgb(255, 240, 230);
        static readonly Color TXT       = Color.FromArgb(60, 70, 80);
        static readonly Color TXT_SEC   = Color.FromArgb(100, 100, 100);

        const string CONN = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FoundItDB;Integrated Security=True;";

        readonly string currentUser;
        readonly bool   isAdmin;
        int             selectedId = -1;
        string          _categoryFilter = "";

        Label lblActive, lblLost, lblFound;

        public MainForm(string user, bool admin)
        {
            currentUser = user;
            isAdmin     = admin;

            InitializeComponent();

            // Replace the designer placeholder with the real LogoPanel at runtime
            var logoNav = new LogoPanel(28)
            {
                Left   = pnlLogoPlaceholder.Left,
                Top    = pnlLogoPlaceholder.Top,
                Width  = pnlLogoPlaceholder.Width,
                Height = pnlLogoPlaceholder.Height
            };
            pnlNav.Controls.Remove(pnlLogoPlaceholder);
            pnlNav.Controls.Add(logoNav);

            // Restore emoji labels (stripped in designer for compatibility)
            btnHome.Text        = "🏠  Home";
            btnLostItems.Text   = "🔍  Lost Items";
            btnFoundItems.Text  = "📦  Found Items";
            btnReportLost.Text  = "📢  Report Lost";
            btnReportFound.Text = "🙌  Report Found";
            btnLogout.Text      = "👋  Logout";
            btnBell.Text        = "🔔";
            btnNotifs.Text      = "🔔";
            btnSend.Text        = "▶";

            // Update greeting with actual username
            lblGreeting.Text = $"Hello, {currentUser}!\nWhat are we looking for today?";

            // Background decorative circles on home panel (matches Java version)
            pnlHome.Paint += (s, e) =>
            {
                var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
                int w = pnlHome.Width, h = pnlHome.Height;
                using var br1 = new SolidBrush(Color.FromArgb(20, BLUE));
                using var br2 = new SolidBrush(Color.FromArgb(15, BLUE));
                g.FillEllipse(br1, w - 250, -100, 500, 500);
                g.FillEllipse(br2, 50, h - 200, 300, 300);
            };

            // Wire nav buttons
            btnHome.Click        += (s, e) => ShowHome();
            btnLostItems.Click   += (s, e) => ShowLost();
            btnFoundItems.Click  += (s, e) => ShowFound();
            btnReportLost.Click  += (s, e) => { new ReportForm(currentUser, "Lost").ShowDialog(this);  RefreshAll(); };
            btnReportFound.Click += (s, e) => { new ReportForm(currentUser, "Found").ShowDialog(this); RefreshAll(); };
            btnLogout.Click      += (s, e) => Close();

            // Keep logout pinned to bottom of nav regardless of window height
            pnlNav.Resize += (s, e) => btnLogout.Top = pnlNav.Height - btnLogout.Height - 20;

            btnHome.MouseEnter        += (s,e) => { btnHome.BackColor = BLUE;   btnHome.ForeColor = Color.White; };
            btnHome.MouseLeave        += (s,e) => { btnHome.BackColor = BG_PANEL; btnHome.ForeColor = BLUE; };
            btnLostItems.MouseEnter   += (s,e) => { btnLostItems.BackColor = ORANGE; btnLostItems.ForeColor = Color.White; };
            btnLostItems.MouseLeave   += (s,e) => { btnLostItems.BackColor = BG_PANEL; btnLostItems.ForeColor = ORANGE; };
            btnFoundItems.MouseEnter  += (s,e) => { btnFoundItems.BackColor = GREEN; btnFoundItems.ForeColor = Color.White; };
            btnFoundItems.MouseLeave  += (s,e) => { btnFoundItems.BackColor = BG_PANEL; btnFoundItems.ForeColor = GREEN; };
            btnReportLost.MouseEnter  += (s,e) => { btnReportLost.BackColor = ORANGE; btnReportLost.ForeColor = Color.White; };
            btnReportLost.MouseLeave  += (s,e) => { btnReportLost.BackColor = BG_PANEL; btnReportLost.ForeColor = ORANGE; };
            btnReportFound.MouseEnter += (s,e) => { btnReportFound.BackColor = BLUE; btnReportFound.ForeColor = Color.White; };
            btnReportFound.MouseLeave += (s,e) => { btnReportFound.BackColor = BG_PANEL; btnReportFound.ForeColor = BLUE; };
            btnLogout.MouseEnter      += (s,e) => { btnLogout.BackColor = Color.FromArgb(255,107,107); btnLogout.ForeColor = Color.White; };
            btnLogout.MouseLeave      += (s,e) => { btnLogout.BackColor = BG_PANEL; btnLogout.ForeColor = Color.FromArgb(255,107,107); };

            // Nav gradient paint
            pnlNav.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using var br = new SolidBrush(NAV_BG);
                g.FillRectangle(br, pnlNav.ClientRectangle);
            };

            // Right panel gradient
            pnlRightDetails.Paint += (s, e) =>
            {
                var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
                using var br = new LinearGradientBrush(pnlRightDetails.ClientRectangle, BLUE, BLUE_DARK, LinearGradientMode.Vertical);
                g.FillRectangle(br, pnlRightDetails.ClientRectangle);
            };

            pnlActionBar.Paint += (s, e) => { e.Graphics.DrawLine(new Pen(Color.FromArgb(220, 220, 220)), 0, 0, pnlActionBar.Width, 0); };

            // Wire table/action buttons
            btnSearch.Click    += (s, e) => { _categoryFilter = ""; LoadTable(); };
            txtSearch.KeyDown  += (s, e) => { if (e.KeyCode == Keys.Enter) { _categoryFilter = ""; LoadTable(); } };
            cmbFilter.SelectedIndexChanged += (s, e) => { _categoryFilter = ""; LoadTable(); };
            btnClaimItem.Click += BtnClaim_Click;
            btnApprove.Click   += BtnApprove_Click;
            btnMarkFound.Click += BtnMarkFound_Click;
            btnDelete.Click    += BtnDelete_Click;
            btnNotifs.Click    += (s, e) => ShowNotifications();
            btnBell.Click      += (s, e) => ShowNotifications();
            btnSend.Click      += BtnSendComment_Click;
            txtComment.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) BtnSendComment_Click(s, e); };

            dgv.SelectionChanged += Dgv_SelectionChanged;
            dgv.CellFormatting   += Dgv_CellFormatting;

            // Build stat cards & action cards & category buttons
            BuildStatCards();
            BuildActionCards();
            BuildCategoryButtons();

            FormClosed += (s, e) => { new LoginForm().Show(); };

            ShowHome();
        }

        void BuildStatCards()
        {
            // Use a TableLayoutPanel so cards size correctly from the start
            var tbl = new TableLayoutPanel {
                Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 1,
                BackColor = BG_MAIN, Padding = new Padding(0)
            };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.4f));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            pnlStats.Controls.Clear();
            pnlStats.Controls.Add(tbl);

            lblActive = MakeStatCard(tbl, "Active Items", "0", BLUE,   0);
            lblLost   = MakeStatCard(tbl, "Lost",         "0", ORANGE, 1);
            lblFound  = MakeStatCard(tbl, "Found",        "0", GREEN,  2);
        }

        Label MakeStatCard(TableLayoutPanel tbl, string title, string value, Color col, int col2)
        {
            var card = new Panel { Dock = DockStyle.Fill, Margin = new Padding(0, 0, col2 < 2 ? 15 : 0, 0) };
            card.Paint += (s, e) => {
                var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillRoundRect(Color.White, 0, 0, card.Width, card.Height, 24);
                using var pen = new Pen(Color.FromArgb(50, col), 3);
                g.DrawRoundRect(pen, 2, 2, card.Width-4, card.Height-4, 24);
            };
            var lblVal = new Label { Text = value, Font = new Font("Segoe UI", 36f, FontStyle.Bold),
                                     ForeColor = col, Dock = DockStyle.Fill,
                                     TextAlign = ContentAlignment.MiddleCenter };
            var lblTit = new Label { Text = title, Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                                     ForeColor = TXT_SEC, Dock = DockStyle.Bottom,
                                     Height = 30, TextAlign = ContentAlignment.MiddleCenter };
            card.Controls.Add(lblVal);
            card.Controls.Add(lblTit);
            tbl.Controls.Add(card, col2, 0);
            return lblVal;
        }

        void BuildActionCards()
        {
            var tbl = new TableLayoutPanel {
                Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1,
                BackColor = BG_MAIN, Padding = new Padding(0)
            };
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            pnlActions.Controls.Clear();
            pnlActions.Controls.Add(tbl);

            MakeActionCard(tbl, "I Lost Something",  "Report it now",  ORANGE, 0, false);
            MakeActionCard(tbl, "I Found Something", "Help return it", BLUE,   1, true);
        }

        void MakeActionCard(TableLayoutPanel tbl, string title, string sub, Color col, int col2, bool isFound)
        {
            var card = new Panel { Dock = DockStyle.Fill, Margin = new Padding(0, 0, col2 == 0 ? 10 : 0, 0),
                                   Cursor = Cursors.Hand };
            card.Paint += (s, e) => {
                var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
                g.FillRoundRect(col, 0, 0, card.Width, card.Height, 28);
                using var pen = new Pen(Color.White, 3f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                int cx2 = 48, cy2 = card.Height / 2;
                if (!isFound) {
                    g.DrawEllipse(pen, cx2-14, cy2-14, 24, 24);
                    g.DrawLine(pen, cx2+6, cy2+6, cx2+18, cy2+18);
                } else {
                    g.DrawEllipse(pen, cx2-18, cy2-18, 36, 36);
                    g.DrawLines(pen, new Point[]{ new Point(cx2-8,cy2+2), new Point(cx2-2,cy2+8), new Point(cx2+10,cy2-6) });
                }
            };
            var lblT = new Label { Text = title, Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                                   ForeColor = Color.White, AutoSize = true, Left = 76, Top = 20, BackColor = Color.Transparent };
            var lblS = new Label { Text = sub, Font = new Font("Segoe UI", 11f),
                                   ForeColor = Color.FromArgb(50,60,70), AutoSize = true, Left = 76, Top = 50, BackColor = Color.Transparent };
            card.Controls.Add(lblT); card.Controls.Add(lblS);
            void open(object s, EventArgs e2) => new ReportForm(currentUser, isFound ? "Found" : "Lost").ShowDialog(this);
            card.Click += open; lblT.Click += open; lblS.Click += open;
            tbl.Controls.Add(card, col2, 0);
        }

        void BuildCategoryButtons()
        {
            string[] names  = { "Electronics","Books","Clothing","Accessories","Others","All Items" };
            string[] emojis = { "📱","📚","👕","👜","🎯","📋" };
            Color[]  colors = { BLUE, Color.FromArgb(155,89,182), RED,
                                 Color.FromArgb(243,156,18), Color.FromArgb(22,160,133), Color.Gray };

            var tbl = new TableLayoutPanel {
                Dock = DockStyle.Fill, ColumnCount = 3, RowCount = 2,
                BackColor = BG_MAIN, Padding = new Padding(0), CellBorderStyle = TableLayoutPanelCellBorderStyle.None
            };
            for (int c = 0; c < 3; c++) tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
            for (int r = 0; r < 2; r++) tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

            for (int i = 0; i < names.Length; i++)
            {
                string name = names[i]; string emoji = emojis[i]; Color bg = colors[i];
                var card = new Panel {
                    Dock = DockStyle.Fill,
                    Margin = new Padding(6),
                    Cursor = Cursors.Hand
                };
                card.Paint += (s, e) => {
                    var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias;
                    int w = card.Width, h = card.Height, arc = 18;
                    if (w < 10 || h < 10) return;
                    // Shadow
                    using (var br = new SolidBrush(Color.FromArgb(40, 0, 0, 0)))
                        g.FillRoundRect(Color.FromArgb(40,0,0,0), 4, 4, w-4, h-4, arc);
                    int hw = w - 4, hh = h - 4;
                    int hdrH = (int)(hh * 0.62f);
                    // Coloured header
                    var clip = new System.Drawing.Drawing2D.GraphicsPath();
                    clip.AddArc(0, 0, arc*2, arc*2, 180, 90);
                    clip.AddArc(hw-arc*2, 0, arc*2, arc*2, 270, 90);
                    clip.AddLine(hw, arc, hw, hdrH);
                    clip.AddLine(0, hdrH, 0, arc);
                    clip.CloseFigure();
                    g.FillPath(new SolidBrush(bg), clip);
                    // White footer
                    var foot = new System.Drawing.Drawing2D.GraphicsPath();
                    foot.AddLine(0, hdrH, hw, hdrH);
                    foot.AddLine(hw, hdrH, hw, hh-arc);
                    foot.AddArc(hw-arc*2, hh-arc*2, arc*2, arc*2, 0, 90);
                    foot.AddArc(0, hh-arc*2, arc*2, arc*2, 90, 90);
                    foot.CloseFigure();
                    g.FillPath(Brushes.White, foot);
                    // Emoji + name
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    float scale = Math.Max(8f, h * 0.10f);
                    using var ef = new Font("Segoe UI Emoji", scale);
                    using var nf = new Font("Segoe UI", scale * 0.65f, FontStyle.Bold);
                    var es = g.MeasureString(emoji, ef);
                    var ns = g.MeasureString(name.ToUpper(), nf);
                    float tx = (hw - es.Width - 4 - ns.Width) / 2f;
                    float ty = hdrH / 2f;
                    g.DrawString(emoji, ef, Brushes.White, tx, ty - es.Height/2f);
                    g.DrawString(name.ToUpper(), nf, Brushes.White, tx + es.Width + 4, ty - ns.Height/2f);
                    // Lost/Found footer
                    int fmy = hdrH + (hh - hdrH) / 2;
                    int lx = (int)(hw * 0.10f), fx2 = (int)(hw * 0.55f);
                    using var cf = new Font("Segoe UI", Math.Max(7f, h * 0.065f), FontStyle.Bold);
                    using var rp = new Pen(RED, 2f);
                    g.DrawEllipse(rp, lx, fmy-7, 10, 10);
                    g.DrawLine(rp, lx+8, fmy+3, lx+12, fmy+7);
                    g.DrawString("Lost: " + GetCatCount(name, false), cf, new SolidBrush(TXT), lx+15, fmy-6);
                    g.FillEllipse(new SolidBrush(GREEN), fx2, fmy-7, 13, 13);
                    using var wp = new Pen(Color.White, 1.8f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                    g.DrawLines(wp, new PointF[]{ new PointF(fx2+2,fmy), new PointF(fx2+5,fmy+3), new PointF(fx2+11,fmy-5) });
                    g.DrawString("Found: " + GetCatCount(name, true), cf, new SolidBrush(TXT), fx2+17, fmy-6);
                };
                card.Click += (s, e) => { _categoryFilter = ""; if (name == "All Items") ShowTable(); else ShowTable(categoryFilter: name); };
                tbl.Controls.Add(card, i % 3, i / 3);
            }
            pnlCategories.Controls.Clear();
            pnlCategories.Controls.Add(tbl);
        }

        int GetCatCount(string cat, bool found)
        {
            string status = found ? "Found" : "Lost";
            string where  = cat == "All Items"
                ? $"Status='{status}' AND IsDeleted=0"
                : $"Status='{status}' AND Category='{cat.Replace("'","''")}' AND IsDeleted=0";
            try {
                using var conn = new SqlConnection(CONN); conn.Open();
                return (int)new SqlCommand($"SELECT COUNT(*) FROM Items WHERE {where}", conn).ExecuteScalar();
            } catch { return 0; }
        }

        // ════════════════════════════════════════════════════════════
        //  SHOW VIEWS
        // ════════════════════════════════════════════════════════════
        void ShowHome()
        {
            _categoryFilter           = "";
            pnlRightDetails.Visible   = false;
            pnlRightDetails.Width     = 0;
            pnlActionBar.Visible      = false;
            pnlTableContainer.Visible = false;
            pnlTableContainer.Dock    = DockStyle.None;
            pnlHome.Dock              = DockStyle.Fill;
            pnlHome.Visible           = true;
            LoadDashStats();
        }

        void ShowLost()  => ShowTable(statusFilter: "Lost");
        void ShowFound() => ShowTable(statusFilter: "Found");

        void ShowTable(string statusFilter = "", string categoryFilter = "")
        {
            pnlHome.Visible           = false;
            pnlHome.Dock              = DockStyle.None;
            pnlTableContainer.Dock    = DockStyle.Fill;
            pnlTableContainer.Visible = true;
            pnlActionBar.Visible      = true;

            // Manually position right panel against the right edge
            pnlRightDetails.Width    = 360;
            pnlRightDetails.Height   = pnlCentre.Height;
            pnlRightDetails.Left     = pnlCentre.Width - 360;
            pnlRightDetails.Top      = 0;
            pnlRightDetails.Anchor   = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlRightDetails.Visible  = true;

            if (!string.IsNullOrEmpty(statusFilter))
            {
                int idx = cmbFilter.Items.IndexOf(statusFilter);
                if (idx >= 0) cmbFilter.SelectedIndex = idx;
            }

            _categoryFilter = categoryFilter;
            LoadTable();
        }

        void RefreshAll()
        {
            LoadDashStats();
            if (pnlTableContainer.Visible) LoadTable();
            // Rebuild category cards so Lost/Found counts refresh
            BuildCategoryButtons();
            pnlCategories.Invalidate(true);
        }

        // ════════════════════════════════════════════════════════════
        //  DATA LOADING
        // ════════════════════════════════════════════════════════════
        void LoadDashStats()
        {
            try
            {
                using (var conn = new SqlConnection(CONN))
                {
                    conn.Open();
                    lblActive.Text = Scalar(conn, "SELECT COUNT(*) FROM Items WHERE IsDeleted=0");
                    lblLost.Text   = Scalar(conn, "SELECT COUNT(*) FROM Items WHERE Status='Lost' AND IsDeleted=0");
                    lblFound.Text  = Scalar(conn, "SELECT COUNT(*) FROM Items WHERE Status='Found' AND IsDeleted=0");
                }
            }
            catch { }
        }

        string Scalar(SqlConnection c, string sql) => new SqlCommand(sql, c).ExecuteScalar()?.ToString() ?? "0";

        void LoadTable()
        {
            string search = txtSearch?.Text.Trim() ?? "";
            string status = cmbFilter?.SelectedItem?.ToString() ?? "All";
            string where;
            if (status == "In Trash")  where = "IsDeleted=1";
            else if (status == "All")  where = "IsDeleted=0";
            else                       where = $"Status='{status}' AND IsDeleted=0";

            if (!string.IsNullOrEmpty(_categoryFilter))
                where += $" AND Category='{_categoryFilter.Replace("'", "''")}'";

            if (!string.IsNullOrEmpty(search))
                where += $" AND Name LIKE '%{search.Replace("'", "''")}%'";

            string sql = $"SELECT ID,Name,Description,OwnerName,Category,Status,Claimant FROM Items WHERE {where} ORDER BY ReportedAt DESC";
            try
            {
                using (var conn = new SqlConnection(CONN))
                using (var da = new SqlDataAdapter(sql, conn))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                    if (dgv.Columns["ID"] != null) dgv.Columns["ID"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("Load error: " + ex.Message); }
        }

        void LoadComments(int itemId)
        {
            lbComments.Items.Clear();
            try
            {
                using (var conn = new SqlConnection(CONN))
                {
                    var cmd = new SqlCommand("SELECT Username,Message FROM Comments WHERE ItemID=@id ORDER BY CreatedAt ASC", conn);
                    cmd.Parameters.AddWithValue("@id", itemId);
                    conn.Open();
                    using (var r = cmd.ExecuteReader())
                        while (r.Read())
                            lbComments.Items.Add($"{r["Username"]}: {r["Message"]}");
                }
            }
            catch { }
        }

        // ════════════════════════════════════════════════════════════
        //  GRID EVENTS
        // ════════════════════════════════════════════════════════════
        void Dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            var row = dgv.SelectedRows[0];
            selectedId = Convert.ToInt32(row.Cells["ID"].Value);
            lblDetName.Text   = row.Cells["Name"].Value?.ToString() ?? "";
            txtDetDesc.Text   = row.Cells["Description"].Value?.ToString() ?? "";
            string status     = row.Cells["Status"].Value?.ToString() ?? "";
            string owner      = row.Cells["OwnerName"].Value?.ToString() ?? "";
            string category   = row.Cells["Category"].Value?.ToString() ?? "";
            string claimant   = row.Cells["Claimant"].Value?.ToString() ?? "";
            lblDetStatus.Text = status.ToUpper();
            lblDetPeople.Text = $"📁 {category}   👤 {owner}" + (string.IsNullOrEmpty(claimant) ? "" : $"\n🙋 Claimant: {claimant}");
            Color sc;
            switch (status)
            {
                case "Found":         sc = Color.LightGreen; break;
                case "Lost":          sc = Color.FromArgb(255, 100, 100); break;
                case "Pending Claim": sc = Color.LightYellow; break;
                case "Claimed":       sc = Color.LightBlue; break;
                case "In Trash":      sc = Color.LightGray; break;
                default:              sc = Color.Silver; break;
            }
            lblDetStatus.BackColor = sc;
            LoadComments(selectedId);
            if (claimant == currentUser)     btnClaimItem.Text = "Cancel Claim";
            else if (status == "In Trash")   btnClaimItem.Text = "Restore Item";
            else                             btnClaimItem.Text = "Claim Item";
        }

        void Dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv.Columns.Count == 0) return;
            int statusCol = dgv.Columns["Status"]?.Index ?? -1;
            if (statusCol == -1 || e.ColumnIndex != statusCol) return;
            string status = e.Value?.ToString() ?? "";
            Color bg;
            switch (status)
            {
                case "Lost":          bg = Color.FromArgb(255, 245, 240); break;
                case "Found":         bg = Color.FromArgb(240, 255, 245); break;
                case "Pending Claim": bg = Color.FromArgb(255, 250, 235); break;
                case "In Trash":      bg = Color.FromArgb(230, 230, 230); break;
                default:              bg = Color.White; break;
            }
            if (!dgv.Rows[e.RowIndex].Selected)
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = bg;
        }

        // ════════════════════════════════════════════════════════════
        //  BUTTON ACTIONS
        // ════════════════════════════════════════════════════════════
        void BtnSendComment_Click(object sender, EventArgs e)
        {
            if (selectedId == -1 || string.IsNullOrWhiteSpace(txtComment.Text)) return;
            try
            {
                using (var conn = new SqlConnection(CONN))
                {
                    conn.Open();
                    var cmd = new SqlCommand("INSERT INTO Comments(ItemID,Username,Message) VALUES(@i,@u,@m)", conn);
                    cmd.Parameters.AddWithValue("@i", selectedId);
                    cmd.Parameters.AddWithValue("@u", currentUser);
                    cmd.Parameters.AddWithValue("@m", txtComment.Text.Trim());
                    cmd.ExecuteNonQuery();
                    string owner = dgv.SelectedRows[0].Cells["OwnerName"].Value?.ToString() ?? "";
                    if (!owner.Equals(currentUser, StringComparison.OrdinalIgnoreCase))
                        Notify(conn, owner, $"{currentUser} commented on '{lblDetName.Text}'.");
                    txtComment.Clear();
                    LoadComments(selectedId);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        void BtnClaim_Click(object sender, EventArgs e)
        {
            if (selectedId == -1) { MessageBox.Show("Select an item first."); return; }
            string status   = dgv.SelectedRows[0].Cells["Status"].Value?.ToString() ?? "";
            string claimant = dgv.SelectedRows[0].Cells["Claimant"].Value?.ToString() ?? "";
            string owner    = dgv.SelectedRows[0].Cells["OwnerName"].Value?.ToString() ?? "";

            if (status == "In Trash")
            {
                if (MessageBox.Show("Restore this item?", "Restore", MessageBoxButtons.YesNo) == DialogResult.Yes)
                { RunSQL($"UPDATE Items SET IsDeleted=0, Status='Lost' WHERE ID={selectedId}"); LoadTable(); LoadDashStats(); MessageBox.Show("Item restored."); }
                return;
            }
            if (claimant.Equals(currentUser, StringComparison.OrdinalIgnoreCase))
            {
                if (MessageBox.Show("Cancel your claim on this item?", "Cancel Claim", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    RunSQL($"UPDATE Items SET Claimant=NULL, Status='Found' WHERE ID={selectedId}");
                    using var conn = new SqlConnection(CONN); conn.Open();
                    Notify(conn, owner, $"{currentUser} cancelled their claim on '{lblDetName.Text}'.");
                    LoadTable(); MessageBox.Show("Claim cancelled.");
                }
                return;
            }
            if (status != "Found") { MessageBox.Show("You can only claim items with status 'Found'."); return; }
            if (owner.Equals(currentUser, StringComparison.OrdinalIgnoreCase)) { MessageBox.Show("You cannot claim your own item!"); return; }
            if (!string.IsNullOrEmpty(claimant)) { MessageBox.Show("This item already has a pending claim."); return; }

            string proof = Microsoft.VisualBasic.Interaction.InputBox(
                "Provide a detail to prove ownership:", "Proof of Ownership");
            if (string.IsNullOrWhiteSpace(proof)) { MessageBox.Show("You must provide a detail."); return; }

            RunSQL($"UPDATE Items SET Claimant='{currentUser.Replace("'", "''")}', Status='Pending Claim' WHERE ID={selectedId}");
            using (var conn2 = new SqlConnection(CONN)) { conn2.Open(); Notify(conn2, owner, $"ACTION: {currentUser} is claiming '{lblDetName.Text}'. Proof: \"{proof}\"."); }
            LoadTable(); LoadDashStats();
            MessageBox.Show("Claim sent! The reporter has been notified.");
        }

        void BtnApprove_Click(object sender, EventArgs e)
        {
            if (selectedId == -1) return;
            string status   = dgv.SelectedRows[0].Cells["Status"].Value?.ToString() ?? "";
            string owner    = dgv.SelectedRows[0].Cells["OwnerName"].Value?.ToString() ?? "";
            string claimant = dgv.SelectedRows[0].Cells["Claimant"].Value?.ToString() ?? "";
            if (!isAdmin && !owner.Equals(currentUser, StringComparison.OrdinalIgnoreCase)) { MessageBox.Show("Only the reporter can approve a claim."); return; }
            if (status != "Pending Claim") { MessageBox.Show("No pending claim on this item."); return; }
            if (string.IsNullOrEmpty(claimant)) { MessageBox.Show("No claimant found."); return; }
            if (MessageBox.Show($"Approve claim by {claimant}?", "Approve Claim", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            RunSQL($"UPDATE Items SET Status='Claimed' WHERE ID={selectedId}");
            using (var conn = new SqlConnection(CONN)) { conn.Open(); Notify(conn, claimant, $"Your claim for '{lblDetName.Text}' was approved!"); }
            if (MessageBox.Show("Remove this item from the list?", "Remove?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                RunSQL($"DELETE FROM Items WHERE ID={selectedId}");
            LoadTable(); LoadDashStats();
            MessageBox.Show("Claim approved.");
        }

        void BtnMarkFound_Click(object sender, EventArgs e)
        {
            if (selectedId == -1) return;
            string status = dgv.SelectedRows[0].Cells["Status"].Value?.ToString() ?? "";
            string owner  = dgv.SelectedRows[0].Cells["OwnerName"].Value?.ToString() ?? "";
            if (!isAdmin && !owner.Equals(currentUser, StringComparison.OrdinalIgnoreCase)) { MessageBox.Show("You can only edit your own items."); return; }
            if (status != "Lost") { MessageBox.Show("Item must be 'Lost' to mark as Found."); return; }
            RunSQL($"UPDATE Items SET Status='Found' WHERE ID={selectedId}");
            using (var conn = new SqlConnection(CONN)) { conn.Open(); Notify(conn, owner, $"Your lost item '{lblDetName.Text}' has been found!"); }
            LoadTable(); LoadDashStats();
            MessageBox.Show("Item marked as Found.");
        }

        void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1) { MessageBox.Show("Select an item."); return; }
            string status = dgv.SelectedRows[0].Cells["Status"].Value?.ToString() ?? "";
            string owner  = dgv.SelectedRows[0].Cells["OwnerName"].Value?.ToString() ?? "";
            if (!isAdmin && !owner.Equals(currentUser, StringComparison.OrdinalIgnoreCase)) { MessageBox.Show("Permission denied."); return; }
            if (status != "In Trash")
            {
                if (MessageBox.Show("Move to Recycle Bin?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                { RunSQL($"UPDATE Items SET IsDeleted=1, Status='In Trash' WHERE ID={selectedId}"); LoadTable(); LoadDashStats(); MessageBox.Show("Item moved to Recycle Bin."); }
            }
            else
            {
                var choice = MessageBox.Show("Permanently delete?\n\nYes = Delete Forever\nNo = Restore", "Manage Trash", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (choice == DialogResult.Yes) { RunSQL($"DELETE FROM Items WHERE ID={selectedId}"); LoadTable(); LoadDashStats(); MessageBox.Show("Item permanently deleted."); }
                else if (choice == DialogResult.No) { RunSQL($"UPDATE Items SET IsDeleted=0, Status='Lost' WHERE ID={selectedId}"); LoadTable(); LoadDashStats(); MessageBox.Show("Item restored."); }
            }
        }

        void ShowNotifications()
        {
            try
            {
                using (var conn = new SqlConnection(CONN))
                {
                    conn.Open();
                    var cmd = new SqlCommand("SELECT Message,CreatedAt FROM Notifications WHERE Username=@u AND IsRead=0 ORDER BY CreatedAt DESC", conn);
                    cmd.Parameters.AddWithValue("@u", currentUser);
                    var dt = new DataTable();
                    new SqlDataAdapter(cmd).Fill(dt);
                    if (dt.Rows.Count == 0) { MessageBox.Show("All caught up! No new notifications.", "Notifications"); return; }
                    var sb = new System.Text.StringBuilder();
                    foreach (DataRow r in dt.Rows)
                        sb.AppendLine($"• {r["Message"]}\n   ({r["CreatedAt"]})\n");
                    MessageBox.Show(sb.ToString(), "Your Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new SqlCommand($"UPDATE Notifications SET IsRead=1 WHERE Username='{currentUser.Replace("'", "''")}' AND IsRead=0", conn).ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void lblStatusLbl_Click(object sender, EventArgs e)
        {

        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void RunSQL(string sql)
        {
            using var conn = new SqlConnection(CONN);
            conn.Open();
            new SqlCommand(sql, conn).ExecuteNonQuery();
        }

        static void Notify(SqlConnection conn, string username, string message)
        {
            try
            {
                var cmd = new SqlCommand("INSERT INTO Notifications(Username,Message) VALUES(@u,@m)", conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@m", message);
                cmd.ExecuteNonQuery();
            }
            catch { }
        }
    }

    static class GraphicsExtensions
    {
        public static void FillRoundRect(this Graphics g, Color color, float x, float y, float w, float h, float radius)
        {
            using var path = RoundedRect(x, y, w, h, radius);
            using var br   = new SolidBrush(color);
            g.FillPath(br, path);
        }
        public static void DrawRoundRect(this Graphics g, Pen pen, float x, float y, float w, float h, float radius)
        {
            using var path = RoundedRect(x, y, w, h, radius);
            g.DrawPath(pen, path);
        }
        static System.Drawing.Drawing2D.GraphicsPath RoundedRect(float x, float y, float w, float h, float r)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(x,       y,       r*2, r*2, 180, 90);
            path.AddArc(x+w-r*2, y,       r*2, r*2, 270, 90);
            path.AddArc(x+w-r*2, y+h-r*2, r*2, r*2, 0,   90);
            path.AddArc(x,       y+h-r*2, r*2, r*2, 90,  90);
            path.CloseFigure();
            return path;
        }
    }
}
