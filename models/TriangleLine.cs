using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Painting.models;

namespace Custom_Paint.models
{
    public class TriangleLine : Shape
    {
        public TriangleLine(Point p1, Point p2, Pen pen, Brush brush, int order)
            : base(p1, p2, pen, brush, order)
        {
        }

        public override void Draw(Graphics g)
        {
            // Calculate the third point
            Point p3 = CalculateThirdPoint();

            // Create an array of points for the triangle vertices
            Point[] points = { p1, p2, p3 };

            // Draw only the outline of the triangle using the pen
            g.DrawPolygon(pen, points);

            // If the triangle is selected, draw selection indicators
            if (IsSelected)
            {
                // Draw small rectangles at each vertex to indicate selection
                int size = 5;
                g.FillRectangle(Brushes.White, p1.X - size, p1.Y - size, 2 * size, 2 * size);
                g.FillRectangle(Brushes.White, p2.X - size, p2.Y - size, 2 * size, 2 * size);
                g.FillRectangle(Brushes.White, p3.X - size, p3.Y - size, 2 * size, 2 * size);
                g.DrawRectangle(Pens.Black, p1.X - size, p1.Y - size, 2 * size, 2 * size);
                g.DrawRectangle(Pens.Black, p2.X - size, p2.Y - size, 2 * size, 2 * size);
                g.DrawRectangle(Pens.Black, p3.X - size, p3.Y - size, 2 * size, 2 * size);
            }
        }

        public override bool isPointInsideShape(Point p)
        {
            // Calculate the third point
            Point p3 = CalculateThirdPoint();

            // Check if point is inside the triangle using barycentric coordinates
            float areaTotal = CalculateTriangleArea(p1, p2, p3);
            float area1 = CalculateTriangleArea(p, p2, p3);
            float area2 = CalculateTriangleArea(p1, p, p3);
            float area3 = CalculateTriangleArea(p1, p2, p);

            // Point is inside if the sum of the three areas equals the total area
            float epsilon = 0.1f;
            return Math.Abs(areaTotal - (area1 + area2 + area3)) < epsilon;
        }

        private Point CalculateThirdPoint()
        {
            // Calculate the third point to form an isosceles triangle
            // Use p1 as the apex and calculate p3 so that p2 and p3 form the base

            // First, find the midpoint of what will be the base
            int midX = (p1.X + p2.X) / 2;
            int midY = (p1.Y + p2.Y) / 2;

            // Calculate the vector from p1 to this midpoint
            int vectorX = midX - p1.X;
            int vectorY = midY - p1.Y;

            // Calculate the perpendicular vector (rotate 90 degrees)
            int perpX = -vectorY;
            int perpY = vectorX;

            // Calculate the third point by applying the perpendicular vector
            // The length of the perpendicular determines the height of the triangle
            int length = (int)Math.Sqrt(vectorX * vectorX + vectorY * vectorY);
            Point p3 = new Point(
                p2.X + (perpX * length / (length > 0 ? length : 1)),
                p2.Y + (perpY * length / (length > 0 ? length : 1))
            );

            return p3;
        }

        private float CalculateTriangleArea(Point a, Point b, Point c)
        {
            // Calculate area using the formula: Area = |Ax(By - Cy) + Bx(Cy - Ay) + Cx(Ay - By)| / 2
            return Math.Abs((a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y)) / 2.0f);
        }
    }
}