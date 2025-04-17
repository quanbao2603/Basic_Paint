using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting.models
{
    public abstract class Shape
    {
        protected Point p1;
        protected Point p2;
        protected Pen pen;
        protected Brush brush;
        protected int order;
        public bool IsSelected { get; set; }
        public Shape(Point p1, Point p2, Pen pen, Brush brush, int order)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.pen = pen;
            this.brush = brush;
            this.order = order;
            this.IsSelected = false;
        }

        // Properties (Getters and Setters)
        public Point P1
        {
            get { return p1; }
            set { p1 = value; }
        }
        public int ORDER
        {
            get { return this.order; }
            set { this.order = value; }
        }
        public Point P2
        {
            get { return p2; }
            set { p2 = value; }
        }

        public Pen Pen
        {
            get { return pen; }
            set { pen = value; }
        }

        public Brush Brush
        {
            get { return brush; }
            set { brush = value; }
        }

        public abstract void Draw(Graphics g);

        public abstract bool isPointInsideShape(Point p);
    }
}
