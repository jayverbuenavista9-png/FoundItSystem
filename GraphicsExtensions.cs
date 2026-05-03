using System.Drawing;
using System.Drawing.Drawing2D;

namespace FoundItSystem
{
    /// <summary>Extension methods for drawing rounded rectangles on a Graphics context.</summary>
    public static class GraphicsExtensions
    {
        public static void FillRoundRect(this Graphics g, Color color, float x, float y, float w, float h, float radius)
        {
            using var path = RoundedRect(x, y, w, h, radius);
            using var br = new SolidBrush(color);
            g.FillPath(br, path);
        }

        public static void DrawRoundRect(this Graphics g, Pen pen, float x, float y, float w, float h, float radius)
        {
            using var path = RoundedRect(x, y, w, h, radius);
            g.DrawPath(pen, path);
        }

        // FIX: Changed "private" to "public" so HomePanel.cs can use this to clip the two-tone category cards!
        public static GraphicsPath RoundedRect(float x, float y, float w, float h, float r)
        {
            var path = new GraphicsPath();
            float d = r * 2;
            path.AddArc(x, y, d, d, 180, 90);
            path.AddArc(x + w - d, y, d, d, 270, 90);
            path.AddArc(x + w - d, y + h - d, d, d, 0, 90);
            path.AddArc(x, y + h - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}