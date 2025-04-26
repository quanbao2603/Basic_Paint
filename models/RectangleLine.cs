using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting.models
{
    public class RectangleLine : Shape
    {
        public RectangleLine(Point p1, Point p2, Pen pen, Brush brush, int order)
            : base(p1, p2, pen, brush, order) { }

        public override void Draw(Graphics g)
        {
            int width = Math.Abs(p2.X - p1.X);
            int height = Math.Abs(p2.Y - p1.Y);
            g.DrawRectangle(this.pen, p1.X, p1.Y, width, height);
            if (IsSelected)
            {
                // Create a highlight pen with a dotted style
                using (Pen highlightPen = new Pen(Color.Black, 5) { DashStyle = DashStyle.Dot })
                {
                    int padding = 5;
                    g.DrawRectangle(highlightPen, p1.X - padding, p1.Y - padding, width + 2 * padding, height + 2 * padding);
                }
            }
        }

        public override bool isPointInsideShape(Point p)
        {
            int minX = Math.Min(p1.X, p2.X);
            int minY = Math.Min(p1.Y, p2.Y);
            int maxX = Math.Max(p1.X, p2.X);
            int maxY = Math.Max(p1.Y, p2.Y);

            return p.X >= minX && p.X <= maxX && p.Y >= minY && p.Y <= maxY;
        }

    }
}
