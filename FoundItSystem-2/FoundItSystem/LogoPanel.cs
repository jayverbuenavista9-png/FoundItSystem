using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FoundItSystem
{
    /// <summary>Draws the FOUNDIT logo (F + magnifying-glass + UNDIT) just like the Java version.</summary>
    public class LogoPanel : Panel
    {
        static readonly Color BLUE   = Color.FromArgb(74, 144, 226);
        static readonly Color ORANGE = Color.FromArgb(255, 140, 66);

        readonly int fontSize;

        // Parameterless constructor required by the Visual Studio Designer
        public LogoPanel() : this(32) { }

        public LogoPanel(int fontSize)
        {
            this.fontSize = fontSize;
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint  |
                     ControlStyles.UserPaint             |
                     ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.Clip = new Region(new Rectangle(0, 0, Width, Height));
            g.SmoothingMode         = SmoothingMode.AntiAlias;
            g.TextRenderingHint     = System.Drawing.Text.TextRenderingHint.AntiAlias;

            using var font  = new Font("Segoe UI", fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
            var sf   = StringFormat.GenericDefault;
            var fm   = g.MeasureString("F", font);
            var fm2  = g.MeasureString("UNDIT", font);

            float capH        = fm.Height * 0.78f;
            float glassDiam   = capH * 0.95f;
            float strokeW     = Math.Max(3, fontSize / 6f);
            float gap         = fontSize * 0.01f;
            float glassTotalW = glassDiam * 1.05f;

            float totalW  = fm.Width + gap + glassTotalW + gap + fm2.Width;
            float startX  = Math.Max(0, (Width - totalW) / 2f);
            float baseline = (Height + capH) / 2f - capH * 0.15f;

            // "F"
            g.DrawString("F", font, new SolidBrush(BLUE), startX, baseline - capH);

            // Magnifying glass (orange handle, blue circle)
            float glassX  = startX + fm.Width + gap;
            float centerY = baseline - capH / 2f;
            float circleX = glassX;
            float circleY = centerY - glassDiam / 2f;
            float r       = glassDiam / 2f;
            float cx      = circleX + r;
            float cy      = circleY + r;

            double angle   = Math.PI / 4;
            float  handleL = glassDiam * 0.6f;
            float  hx1     = cx + (float)(Math.Cos(angle) * r * 0.5);
            float  hy1     = cy + (float)(Math.Sin(angle) * r * 0.5);
            float  hx2     = hx1 + (float)(Math.Cos(angle) * handleL);
            float  hy2     = hy1 + (float)(Math.Sin(angle) * handleL);

            using (var pen = new Pen(ORANGE, strokeW * 1.5f) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                g.DrawLine(pen, hx1, hy1, hx2, hy2);

            using (var pen = new Pen(BLUE, strokeW))
                g.DrawEllipse(pen, circleX, circleY, glassDiam, glassDiam);

            g.FillEllipse(new SolidBrush(Color.FromArgb(150, 135, 206, 250)),
                circleX + strokeW, circleY + strokeW, glassDiam - strokeW * 2, glassDiam - strokeW * 2);

            g.FillEllipse(Brushes.White,
                circleX + glassDiam / 4f, circleY + glassDiam / 4f, glassDiam / 4f, glassDiam / 4f);

            // "UNDIT"
            g.DrawString("UNDIT", font, new SolidBrush(BLUE),
                glassX + glassTotalW + gap, baseline - capH);
        }
    }
}
