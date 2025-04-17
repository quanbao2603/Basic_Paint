using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting.models
{
    public class Line : Shape
    {
        public Line(Point p1, Point p2, Pen pen, int order) : base(p1, p2, pen, null, order) { }

        public override void Draw(Graphics g)
        {
            g.DrawLine(this.pen, p1, p2);
            if (IsSelected)
            {
                // Padding around the line
                int padding = 5;

                // Compute bounding box
                int minX = Math.Min(p1.X, p2.X) - padding;
                int minY = Math.Min(p1.Y, p2.Y) - padding;
                int maxX = Math.Max(p1.X, p2.X) + padding;
                int maxY = Math.Max(p1.Y, p2.Y) + padding;

                // Create a rectangle around the line
                Rectangle boundingBox = new Rectangle(minX, minY, maxX - minX, maxY - minY);

                // Draw the dotted border rectangle
                using (Pen highlightPen = new Pen(Color.Black, 2))
                {
                    highlightPen.DashStyle = DashStyle.Dot;
                    g.DrawRectangle(highlightPen, boundingBox);
                }
            }
        }

        public override bool isPointInsideShape(Point p)
        {
            float distance = Math.Abs((p2.Y - p1.Y) * p.X - (p2.X - p1.X) * p.Y + p2.X * p1.Y - p2.Y * p1.X) /
                             (float)Math.Sqrt(Math.Pow(p2.Y - p1.Y, 2) + Math.Pow(p2.X - p1.X, 2));

            return distance <= 3;  // Tolerance for line thickness
        }

    }
}
