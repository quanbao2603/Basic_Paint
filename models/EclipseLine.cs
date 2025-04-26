using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting.models
{
    public class EclipseLine : Shape
    {
        public EclipseLine(Point p1, Point p2, Pen pen, Brush brush, int order)
            : base(p1, p2, pen, brush, order) { }

        public override void Draw(Graphics g)
        {
            int width = Math.Abs(p2.X - p1.X);
            int height = Math.Abs(p2.Y - p1.Y);
            g.DrawEllipse(this.pen, p1.X, p1.Y, width, height);
            if (IsSelected)
            {
                Pen dashedPen = new Pen(Color.Black,4) { DashStyle = DashStyle.Dot };
                g.DrawRectangle(dashedPen, p1.X - 5, p1.Y - 5, width + 10, height + 10);
            }
        }

        public override bool isPointInsideShape(Point p)
        {
            float centerX = (p1.X + p2.X) / 2;
            float centerY = (p1.Y + p2.Y) / 2;
            float a = Math.Abs(p2.X - p1.X) / 2;
            float b = Math.Abs(p2.Y - p1.Y) / 2;

            float equation = (float)((Math.Pow(p.X - centerX, 2) / Math.Pow(a, 2)) + (Math.Pow(p.Y - centerY, 2) / Math.Pow(b, 2)));
            return equation <= 1;
        }


    }
}
