using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FoundItSystem
{
    public partial class ProfilePanel : UserControl
    {
        private MainForm _parentForm;

        static readonly Color BLUE = Color.FromArgb(74, 144, 226);
        static readonly Color ORANGE = Color.FromArgb(255, 140, 66);
        static readonly Color BG = Color.FromArgb(250, 252, 255);

        public ProfilePanel(MainForm parent)
        {
            _parentForm = parent;
            InitializeComponent();

            // Populate initial data
            lblProfileName.Text = _parentForm.CurrentUser.ToUpper();
            txtUser.Text = _parentForm.CurrentUser;

            // Optional: disable typing in fields until they click edit
            txtUser.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtEmail.ReadOnly = true;

            // Apply Polish
            StyleButton(btnUpload, ORANGE, true);
            StyleButton(btnRedeem, BLUE, false);
            StyleEditIcon(btnEditUser);
            StyleEditIcon(btnEditPhone);
            StyleEditIcon(btnEditEmail);
        }

        // Applies the rounded corners and custom painting
        private void StyleButton(Button btn, Color color, bool isOutline)
        {
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = isOutline ? color : Color.White;
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            btn.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // FIX: Re-calculate the clipping region every time it paints so it never gets cut off!
                using (var path = GraphicsExtensions.RoundedRect(0, 0, btn.Width, btn.Height, 10))
                {
                    btn.Region = new Region(path);
                }

                if (isOutline)
                {
                    e.Graphics.Clear(BG);
                    using (var pen = new Pen(color, 2))
                    {
                        // Draw slightly inward (-3) so the 2px pen stroke doesn't get clipped by the region
                        e.Graphics.DrawPath(pen, GraphicsExtensions.RoundedRect(1, 1, btn.Width - 3, btn.Height - 3, 10));
                    }
                }
                else
                {
                    e.Graphics.Clear(BG);
                    using (var brush = new SolidBrush(color))
                    {
                        e.Graphics.FillPath(brush, GraphicsExtensions.RoundedRect(0, 0, btn.Width, btn.Height, 10));
                    }
                }

                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, btn.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };
        }

        // Cleans up the pencil icons
        private void StyleEditIcon(Button btn)
        {
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.BackColor = Color.Transparent;
            btn.Font = new Font("Segoe UI Emoji", 14);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Load the image into the PictureBox
                    picAvatar.Image = Image.FromFile(ofd.FileName);
                    // Ensure the image fits nicely
                    picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                    picAvatar.BorderStyle = BorderStyle.None; // Remove the wireframe border
                }
            }
        }
        private void btnEditUser_Click(object sender, EventArgs e)
        {
            ToggleEdit(txtUser, btnEditUser, "Username");
        }

        private void btnEditPhone_Click(object sender, EventArgs e)
        {
            ToggleEdit(txtPhone, btnEditPhone, "Phone");
        }

        private void btnEditEmail_Click(object sender, EventArgs e)
        {
            ToggleEdit(txtEmail, btnEditEmail, "Email");
        }

        private void ToggleEdit(TextBox txt, Button btn, string columnName)
        {
            if (txt.ReadOnly)
            {
                // Start Editing
                txt.ReadOnly = false;
                txt.Focus();
                btn.Text = "✔️"; // Change pencil to a checkmark
                txt.BackColor = Color.FromArgb(245, 250, 255); // Subtle "editing" color
            }
            else
            {
                // Save and Lock
                txt.ReadOnly = true;
                btn.Text = "✏️";
                txt.BackColor = Color.White;

                SaveToDatabase(columnName, txt.Text);

                // Specific logic for Username changes
                if (columnName == "Username")
                {
                    UpdateNameEverywhere(txt.Text);
                }
            }
        }

        private void SaveToDatabase(string column, string value)
        {
            try
            {
                using (var conn = new SqlConnection(AppConfig.Conn))
                {
                    conn.Open();
                    // Note: If adding new columns like Phone/Email, ensure you've added them to your SQL table first!
                    string sql = $"UPDATE Users SET {column} = @val WHERE Username = @oldUser";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@val", value);
                        cmd.Parameters.AddWithValue("@oldUser", _parentForm.CurrentUser);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Error saving: " + ex.Message); }
        }

        private void UpdateNameEverywhere(string newName)
        {
            // 1. Update the big headline in this panel
            lblProfileName.Text = newName.ToUpper();

            // 2. Update the reference in MainForm so other panels know who is logged in
            _parentForm.GetType().GetField("CurrentUser")?.SetValue(_parentForm, newName);

            // 3. Inform the user
            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProfilePanel_Load(object sender, EventArgs e)
        {

        }

        private void btnRedeem_Click(object sender, EventArgs e)
        {
            _parentForm.LoadView(new EWalletPanel(_parentForm));
        }
    }
}