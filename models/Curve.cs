using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painting.models
{
    public class Curve : Shape
    {
        private Point controlPoint1;
        private Point controlPoint2;

        public Curve(Point p1, Point p2, Pen pen, int order)
            : base(p1, p2, pen, null, order) { }

        public override void Draw(Graphics g)
        {
            // Define control points for Bezier curve
            controlPoint1 = new Point(
                p1.X + (p2.X - p1.X) / 3,
                p1.Y + (p2.Y - p1.Y) / 3 + 30);
            controlPoint2 = new Point(
                p1.X + 2 * (p2.X - p1.X) / 3,
                p1.Y + 2 * (p2.Y - p1.Y) / 3 - 30);

            g.DrawBezier(this.pen, p1, controlPoint1, controlPoint2, p2);

            if (IsSelected)
            {
                int padding = 10; // Make the selection box slightly bigger
                // Calculate the bounding rectangle
                int minX = Math.Min(Math.Min(p1.X, p2.X), Math.Min(controlPoint1.X, controlPoint2.X)) - padding;
                int minY = Math.Min(Math.Min(p1.Y, p2.Y), Math.Min(controlPoint1.Y, controlPoint2.Y)) - padding;
                int maxX = Math.Max(Math.Max(p1.X, p2.X), Math.Max(controlPoint1.X, controlPoint2.X)) + padding;
                int maxY = Math.Max(Math.Max(p1.Y, p2.Y), Math.Max(controlPoint1.Y, controlPoint2.Y)) + padding;
                int width = maxX - minX;
                int height = maxY - minY;
                // Create a dotted black border
                using (Pen highlightPen = new Pen(Color.Black, 2) { DashStyle = DashStyle.Dot })
                {
                    g.DrawRectangle(highlightPen, minX, minY, width, height);
                }
            }
        }

        public override bool isPointInsideShape(Point p)
        {
            // Make sure control points are initialized
            if (controlPoint1.IsEmpty || controlPoint2.IsEmpty)
            {
                // Initialize control points if they haven't been set yet
                controlPoint1 = new Point(
                    p1.X + (p2.X - p1.X) / 3,
                    p1.Y + (p2.Y - p1.Y) / 3 + 30);
                controlPoint2 = new Point(
                    p1.X + 2 * (p2.X - p1.X) / 3,
                    p1.Y + 2 * (p2.Y - p1.Y) / 3 - 30);
            }

            // Sample points along the Bezier curve
            int segments = 100; // Higher number increases accuracy
            PointF prevPoint = p1;
            for (int i = 1; i <= segments; i++)
            {
                float t = i / (float)segments;
                PointF bezierPoint = GetBezierPoint(t, p1, controlPoint1, controlPoint2, p2);
                // Check if the click is near the curve (distance <= tolerance)
                if (Distance(p, bezierPoint) <= 5)  // 5-pixel tolerance
                    return true;
                prevPoint = bezierPoint;
            }
            return false;
        }

        private PointF GetBezierPoint(float t, Point p0, Point p1, Point p2, Point p3)
        {
            float x = (float)(Math.Pow(1 - t, 3) * p0.X +
                              3 * Math.Pow(1 - t, 2) * t * p1.X +
                              3 * (1 - t) * Math.Pow(t, 2) * p2.X +
                              Math.Pow(t, 3) * p3.X);
            float y = (float)(Math.Pow(1 - t, 3) * p0.Y +
                              3 * Math.Pow(1 - t, 2) * t * p1.Y +
                              3 * (1 - t) * Math.Pow(t, 2) * p2.Y +
                              Math.Pow(t, 3) * p3.Y);
            return new PointF(x, y);
        }

        private float Distance(Point p, PointF bezierPoint)
        {
            return (float)Math.Sqrt(Math.Pow(bezierPoint.X - p.X, 2) + Math.Pow(bezierPoint.Y - p.Y, 2));
        }
    }
}