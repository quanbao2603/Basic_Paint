using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting.models
{
    public class CircleLine : Shape
    {
        private float radius;

        public CircleLine(Point p1, Point p2, Pen pen, Brush brush, int order)
            : base(p1, p2, pen, brush, order)
        {
        }

        public override void Draw(Graphics g)
        {
            float diagonal = (float)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            this.radius = diagonal / 2;

            // Calculate the center
            float centerX = (p1.X + p2.X) / 2 - radius;
            float centerY = (p1.Y + p2.Y) / 2 - radius;

            // Ensure MyPen and MyBrush exist in the base class
            g.DrawEllipse(this.pen, centerX, centerY, radius * 2, radius * 2);

            if (IsSelected)
            {
                using (Pen selectionPen = new Pen(Color.Black, 4))
                {
                    selectionPen.DashStyle = DashStyle.Dot;
                    Rectangle selectionRect = new Rectangle(
                        (int)(centerX - 5),
                        (int)(centerY - 5),
                        (int)(radius * 2 + 10),
                        (int)(radius * 2 + 10));

                    g.DrawRectangle(selectionPen, selectionRect);

                    // Draw resize handles
                    int handleSize = 8;
                    SolidBrush handleBrush = new SolidBrush(Color.Black);
                    g.FillRectangle(handleBrush, selectionRect.Left - handleSize / 2, selectionRect.Top - handleSize / 2, handleSize, handleSize);
                    g.FillRectangle(handleBrush, selectionRect.Right - handleSize / 2, selectionRect.Top - handleSize / 2, handleSize, handleSize);
                    g.FillRectangle(handleBrush, selectionRect.Left - handleSize / 2, selectionRect.Bottom - handleSize / 2, handleSize, handleSize);
                    g.FillRectangle(handleBrush, selectionRect.Right - handleSize / 2, selectionRect.Bottom - handleSize / 2, handleSize, handleSize);
                }
            }


        }
        public override bool isPointInsideShape(Point p)
        {
            float centerX = (p1.X + p2.X) / 2;
            float centerY = (p1.Y + p2.Y) / 2;
            float distance = (float)Math.Sqrt(Math.Pow(p.X - centerX, 2) + Math.Pow(p.Y - centerY, 2));

            return distance <= radius;
        }

    }
}
