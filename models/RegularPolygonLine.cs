using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Painting.models
{
    public class RegularPolygonLine : Shape
    {
        private int sides;

        public RegularPolygonLine(Point p1, Point p2, Pen pen, int order, int sides = 5)
            : base(p1, p2, pen, null, order) // Pass null for brush since we're not using it
        {
            this.sides = Math.Max(3, sides);
        }

        public int Sides
        {
            get { return sides; }
            set { sides = Math.Max(3, value); }
        }

        public override void Draw(Graphics g)
        {
            Point[] vertices = GetPolygonPoints(p1, p2, sides);

            g.DrawPolygon(pen, vertices);

            if (IsSelected)
            {
                // Create a highlight pen with a dotted style
                using (Pen highlightPen = new Pen(Color.Black, 5) { DashStyle = DashStyle.Dot })
                {
                    Point[] outerVertices = new Point[vertices.Length];
                    int padding = 5;

                    // Calculate center of the polygon
                    float centerX = (p1.X + p2.X) / 2f;
                    float centerY = (p1.Y + p2.Y) / 2f;

                    // Scale each vertex slightly outward from the center
                    for (int i = 0; i < vertices.Length; i++)
                    {
                        float dx = vertices[i].X - centerX;
                        float dy = vertices[i].Y - centerY;
                        float scale = 1 + padding / (float)Math.Sqrt(dx * dx + dy * dy);

                        outerVertices[i] = new Point(
                            (int)(centerX + dx * scale),
                            (int)(centerY + dy * scale)
                        );
                    }

                    // Draw the outer highlight polygon
                    g.DrawPolygon(highlightPen, outerVertices);
                }
            }
        }

        public override bool isPointInsideShape(Point p)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPolygon(GetPolygonPoints(p1, p2, sides));
                return path.IsVisible(p);
            }
        }

        private Point[] GetPolygonPoints(Point p1, Point p2, int sides)
        {
            List<Point> points = new List<Point>();

            float centerX = (p1.X + p2.X) / 2f;
            float centerY = (p1.Y + p2.Y) / 2f;

            float radiusX = Math.Abs(p2.X - p1.X) / 2f;
            float radiusY = Math.Abs(p2.Y - p1.Y) / 2f;

            double angleStep = 2 * Math.PI / sides;

            for (int i = 0; i < sides; i++)
            {
                double angle = i * angleStep - Math.PI / 2;
                float x = centerX + (float)(radiusX * Math.Cos(angle));
                float y = centerY + (float)(radiusY * Math.Sin(angle));
                points.Add(new Point((int)x, (int)y));
            }

            return points.ToArray();
        }
    }
}
