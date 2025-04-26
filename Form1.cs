using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Custom_Paint.models;
using Painting.models;

namespace Custom_Paint
{
    public partial class Form1 : Form
    {

        ShapeMode shapeMode;
        DrawingMode drawingMode;
        Pen myPen;
        int penSize = 2;
        Brush myBrush;
        Color myColor;
        Graphics gp;
        List<Shape> objects;
        bool isStart = false;
        Color selectedColor = Color.Black;
        Button selectedButton = null;
        TrackBar trackBarPenSize;
        int order;
        ComboBox cmbPenStyle;
        Button btnChooseColorPen;
        ComboBox cmbBrushStyle;
        Button btnChooseFillColor;
        Button btnChooseBorderBrush;
        bool isSelectShape = false;
        bool isChoosingShape = false;
        bool isResizing = false;
        Point cursorInitialLocation;
        Shape selectedShape;
        List<Shape> selectedShapes;
        List<List<Shape>> groupedList;
        List<Shape> currentChoosenGroup;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.order = 0;
            gp = this.draw_panel.CreateGraphics();
            myColor = Color.Blue;
            this.myPen = new Pen(myColor, 5);
            this.myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.myBrush = new SolidBrush(Color.Blue);
            objects = new List<Shape>();
            this.drawingMode = DrawingMode.PEN;
            this.shapeMode = ShapeMode.Line;
            this.pen_panel.Visible = false;
            this.selectedShapes = new List<Shape>();
            handleChoosingPen();
            handleChoosingBrush();
            this.isChoosingShape = false;
            this.groupedList = new List<List<Shape>>();
            this.currentChoosenGroup = new List<Shape>();
        }

        public void handleChoosingBrush()
        {
            // Label for fill color (Màu nền)
            Label lblFillColor = new Label
            {
                Text = "Màu nền",
                Size = new Size(100, 20),
                Location = new Point(30, 60),
                ForeColor = Color.White,
                Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold)
            };

            // Button for choosing fill color
            btnChooseFillColor = new Button
            {
                Size = new Size(60, 30),
                Location = new Point(30, 90),
                BackColor = ((SolidBrush)myBrush).Color // Show current brush color as button background
            };
            btnChooseFillColor.Click += BtnChooseFillColor_Click;

            // Label for border color (Màu viền)
            Label lblBorderColor = new Label
            {
                Text = "Màu viền",
                Size = new Size(100, 20),
                Location = new Point(30, 130),
                ForeColor = Color.White,
                Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold)
            };

            // Button for choosing border color
            btnChooseBorderBrush = new Button
            {
                Size = new Size(60, 30),
                Location = new Point(30, 160),
                BackColor = myPen.Color // Show current pen color as button background
            };
            btnChooseBorderBrush.Click += BtnChooseBorderBrush_Click;

            // Label for border style (Kiểu tô)
            Label lblBrushStyle = new Label
            {
                Text = "Kiểu tô",
                Size = new Size(100, 20),
                Location = new Point(30, 200),
                ForeColor = Color.White,
                Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold)
            };

            // Dropdown for border style
            cmbBrushStyle = new ComboBox
            {
                Size = new Size(80, 30),
                Location = new Point(30, 230),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Add border style options
            cmbBrushStyle.Items.Add("Solid");
            cmbBrushStyle.Items.Add("Dash");
            cmbBrushStyle.Items.Add("Dot");
            cmbBrushStyle.Items.Add("DashDot");
            cmbBrushStyle.Items.Add("DashDotDot");
            cmbBrushStyle.SelectedIndex = (int)myPen.DashStyle; // Set to current pen style
            cmbBrushStyle.SelectedIndexChanged += CmbBrushStyle_SelectedIndexChanged;

            // Add all controls to the panel
            this.pen_panel.Controls.Add(lblFillColor);
            this.pen_panel.Controls.Add(btnChooseFillColor);
            this.pen_panel.Controls.Add(lblBorderColor);
            this.pen_panel.Controls.Add(btnChooseBorderBrush);
            this.pen_panel.Controls.Add(lblBrushStyle);
            this.pen_panel.Controls.Add(cmbBrushStyle);
        }

        private void BtnChooseBorderBrush_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = ((SolidBrush)myBrush).Color; // Set current brush color as default

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Dispose old brush to prevent memory leaks
                myBrush.Dispose();

                // Create new brush with selected color
                myBrush = new SolidBrush(colorDialog.Color);
                ((Button)sender).BackColor = colorDialog.Color; // Update button color
            }
        }

        private void CmbBrushStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.SelectedItem == null) return;

            Color currentColor = myPen.Color;
            float currentWidth = myPen.Width;

            myPen.Dispose();
            myPen = new Pen(currentColor, currentWidth);

            string selectedStyle = cmb.SelectedItem.ToString();

            if (selectedStyle == "Solid")
            {
                myPen.DashStyle = DashStyle.Solid;
            }
            else if (selectedStyle == "Dash")
            {
                myPen.DashStyle = DashStyle.Dash;
            }
            else if (selectedStyle == "Dot")
            {
                myPen.DashStyle = DashStyle.Dot;
            }
            else if (selectedStyle == "DashDot")
            {
                myPen.DashStyle = DashStyle.DashDot;
            }
            else if (selectedStyle == "DashDotDot")
            {
                myPen.DashStyle = DashStyle.DashDotDot;
            }
            else
            {
                myPen.DashStyle = DashStyle.Solid;
            }

            Invalidate();

        }

        private void BtnChooseFillColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = ((SolidBrush)myBrush).Color; // Set current brush color as default

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Dispose old brush to prevent memory leaks
                myBrush.Dispose();

                // Create new brush with selected color
                myBrush = new SolidBrush(colorDialog.Color);
                ((Button)sender).BackColor = colorDialog.Color; // Update button color
            }
        }

        public void handleChoosingPen()
        {
            // Pen size trackbar
            trackBarPenSize = new TrackBar
            {
                Minimum = 1,
                Maximum = 20,
                Value = penSize,
                Orientation = Orientation.Vertical,
                Height = 250,
                Width = 60,
                TickFrequency = 1,
                LargeChange = 2,
                SmallChange = 1,
                Visible = true
            };
            trackBarPenSize.Location = new Point(40, 10);
            trackBarPenSize.Scroll += TrackBarPenSize_Scroll;

            // Color choosing button
            btnChooseColorPen = new Button
            {
                Size = new Size(50, 30),
                Location = new Point(35, 270),
                BackColor = myPen.Color // Show current pen color as button background
            };
            btnChooseColorPen.Click += BtnChooseColor_Click;

            // Pen style dropdown (ComboBox)
            cmbPenStyle = new ComboBox
            {
                Size = new Size(100, 30),
                Location = new Point(20, 310),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Add pen style options
            cmbPenStyle.Items.Add("Solid");
            cmbPenStyle.Items.Add("Dash");
            cmbPenStyle.Items.Add("Dot");
            cmbPenStyle.Items.Add("DashDot");
            cmbPenStyle.Items.Add("DashDotDot");
            cmbPenStyle.SelectedIndex = 0; // Default to Solid
            cmbPenStyle.SelectedIndexChanged += CmbPenStyle_SelectedIndexChanged;

            // Add all controls to the panel
            this.pen_panel.Controls.Add(trackBarPenSize);
            this.pen_panel.Controls.Add(btnChooseColorPen);
            this.pen_panel.Controls.Add(cmbPenStyle);
        }

        private void CmbPenStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            switch (cmb.SelectedItem.ToString())
            {
                case "Solid":
                    this.myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    break;
                case "Dash":
                    this.myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    break;
                case "Dot":
                    this.myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    break;
                case "DashDot":
                    this.myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                    break;
                case "DashDotDot":
                    this.myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
                    break;
            }
        }

        private void BtnChooseColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = myPen.Color; // Set current color as default

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.myPen.Color = colorDialog.Color;
                ((Button)sender).BackColor = colorDialog.Color; // Update button color
            }
        }

        private void TrackBarPenSize_Scroll(object sender, EventArgs e)
        {
            this.penSize = trackBarPenSize.Value;
            this.myPen.Width = penSize;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void line_btn_Click(object sender, EventArgs e)
        {
            this.shapeMode = ShapeMode.Line;
        }

        private void square_btn_Click(object sender, EventArgs e)
        {
            if (this.drawingMode == DrawingMode.PEN)
            {
                this.shapeMode = ShapeMode.LineSquare;
            }
            else this.shapeMode = ShapeMode.Square;
        }

        private void retangle_btn_Click(object sender, EventArgs e)
        {
            if (this.drawingMode == DrawingMode.PEN)
            {
                this.shapeMode = ShapeMode.LineRectangle;
            }
            else this.shapeMode = ShapeMode.Rectangle;
        }

        private void circle_btn_Click(object sender, EventArgs e)
        {
            if (this.drawingMode == DrawingMode.PEN)
            {
                this.shapeMode = ShapeMode.LineCircle;
            }
            else this.shapeMode = ShapeMode.Circle;
        }

        private void eclipse_btn_Click(object sender, EventArgs e)
        {
            if (this.drawingMode == DrawingMode.PEN)
            {
                this.shapeMode = ShapeMode.LineEllipse;
            }
            else this.shapeMode = ShapeMode.Ellipse;
        }


        private void curve_btn_Click(object sender, EventArgs e)
        { 
            this.shapeMode = ShapeMode.Curve;

        }



        private void btn_pen_Click(object sender, EventArgs e)
        {
            this.drawingMode = DrawingMode.PEN;
            this.Cursor = Cursors.Cross;
            this.pen_panel.Visible = true;
            this.btnChooseBorderBrush.Visible = false;
            this.btnChooseFillColor.Visible = false;
            this.cmbBrushStyle.Visible = false;
            this.trackBarPenSize.Visible = true;
            this.isSelectShape = false;
            this.cmbPenStyle.Visible = true;
            this.btnChooseColorPen.Visible = true;
            this.isSelectShape = false;
        }

        private void brush_btn_Click(object sender, EventArgs e)
        {
            this.drawingMode = DrawingMode.BRUSH;
            this.pen_panel.Visible = true;
            this.Cursor = Cursors.Cross;
            this.trackBarPenSize.Visible = false;
            this.isSelectShape = false;
            this.cmbPenStyle.Visible = false;
            this.btnChooseColorPen.Visible = false;
            this.btnChooseBorderBrush.Visible = true;
            this.btnChooseFillColor.Visible = true;
            this.cmbBrushStyle.Visible = true;
            this.isSelectShape = false;
        }

        private void erase_btn_Click(object sender, EventArgs e)
        {
            if (this.selectedShapes.Count > 0)
            {
                foreach (Shape shape in this.selectedShapes.ToList()) // Create a copy to avoid modification issues
                {
                    this.objects.Remove(shape);
                }
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to erase the selected shapes?",
                    "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                    return;
                this.selectedShapes.Clear();
                this.draw_panel.Refresh();
            }
            else
            {
                DialogResult clearAllResult = MessageBox.Show(
                    "No shape selected. Do you want to erasGe all shapes?",
                    "Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (clearAllResult == DialogResult.Yes)
                {
                    this.objects.Clear();
                    this.selectedShapes.Clear();
                    this.draw_panel.Refresh();
                }
            }
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            this.isSelectShape = true;
            this.drawingMode = DrawingMode.NONE;
            this.Cursor = Cursors.Hand;
        }

        private void group_btn_Click(object sender, EventArgs e)
        {
            if (this.selectedShapes.Count <= 1) return;
            this.GroupShapes(this.selectedShapes, this.groupedList);
        }

        private void ungroup_btn_Click(object sender, EventArgs e)
        {
            if (currentChoosenGroup == null || currentChoosenGroup.Count == 0)
                return;

            groupedList.Remove(currentChoosenGroup);
            currentChoosenGroup.Clear();
            ClearShapeSelection();
            MessageBox.Show("Ungroup succesfully", "Notification!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.draw_panel.Refresh();
        }

        private void ClearShapeSelection()
        {
            this.selectedShapes.Clear();
            foreach (List<Shape> group in this.groupedList)
            {
                foreach (Shape shapeGroup in group)
                {
                    shapeGroup.IsSelected = false;
                }
            }
        }


        private void draw_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isSelectShape && this.isChoosingShape)
            {

                if (this.isResizing)
                {
                    handleResizingObject(e.Location);
                }
                else
                {
                    handleMovingShape(e.Location);
                }

                this.draw_panel.Refresh();
            }
            else if (this.isStart)
            {
                this.objects[objects.Count - 1].P2 = e.Location;
                this.draw_panel.Refresh();
            }
        }

        private void handleMovingShape(Point currentLocation)
        {
            if (this.currentChoosenGroup != null && this.currentChoosenGroup.Count > 0)
            {
                foreach (Shape currentShape in this.currentChoosenGroup)
                {
                    int x = currentLocation.X - this.cursorInitialLocation.X;
                    int y = currentLocation.Y - this.cursorInitialLocation.Y;
                    currentShape.P1 = new Point(currentShape.P1.X + x, currentShape.P1.Y + y);
                    currentShape.P2 = new Point(currentShape.P2.X + x, currentShape.P2.Y + y);
                }
                this.cursorInitialLocation = currentLocation;
                return;
            }
            if (this.selectedShape == null)
                return;
            int x_dis = currentLocation.X - this.cursorInitialLocation.X;
            int y_dis = currentLocation.Y - this.cursorInitialLocation.Y;
            this.selectedShape.P1 = new Point(this.selectedShape.P1.X + x_dis, this.selectedShape.P1.Y + y_dis);
            this.selectedShape.P2 = new Point(this.selectedShape.P2.X + x_dis, this.selectedShape.P2.Y + y_dis);
            this.cursorInitialLocation = currentLocation;
        }

        private void handleResizingObject(Point currentLocation)
        {
            if (this.currentChoosenGroup != null && this.currentChoosenGroup.Count > 0)
            {
                foreach (Shape currentShape in this.currentChoosenGroup)
                {
                    int x = currentLocation.X - this.cursorInitialLocation.X;
                    int y = currentLocation.Y - this.cursorInitialLocation.Y;
                    currentShape.P2 = new Point(currentShape.P2.X + x, currentShape.P2.Y + y);
                }
                this.cursorInitialLocation = currentLocation;
                return;
            }
            if (this.selectedShape == null || !this.isResizing)
                return;
            int x_dis = currentLocation.X - this.cursorInitialLocation.X;
            int y_dis = currentLocation.Y - this.cursorInitialLocation.Y;
            this.selectedShape.P2 = new Point(this.selectedShape.P2.X + x_dis, this.selectedShape.P2.Y + y_dis);
            this.cursorInitialLocation = currentLocation;
        }

        private void draw_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.isSelectShape && this.isChoosingShape)
            {
                MouseUpAfterSelect();
            }
            else if (this.isStart)
            {
                this.objects[objects.Count - 1].P2 = e.Location;
                this.draw_panel.Refresh();

            }
            this.isStart = false;
        }

        public void MouseUpAfterSelect()
        {
            if (this.currentChoosenGroup != null && this.currentChoosenGroup.Count > 0)
            {
                foreach (Shape shape in currentChoosenGroup)
                {
                    shape.IsSelected = true;
                }
            }
            else
            {
                this.selectedShape.IsSelected = true;
            }
            this.isChoosingShape = false;
            this.isResizing = false;
            this.draw_panel.Refresh();
        }

        private void draw_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.isSelectShape)
            {
                HandleShapeSelection(e);
            }
            else if (this.drawingMode != DrawingMode.NONE)
            {
                StartDrawing(e);
            }

        }

        private void StartDrawing(MouseEventArgs e)
        {
            this.isStart = true;
            this.selectedShapes.Clear();

            Pen newPen = new Pen(this.myPen.Color, this.myPen.Width)
            {
                DashStyle = this.myPen.DashStyle
            };

            Brush newBrush = null;
            if (this.myBrush is SolidBrush solidBrush)
            {
                newBrush = new SolidBrush(solidBrush.Color);
            }
            else if (this.myBrush is HatchBrush hatchBrush)
            {
                newBrush = new HatchBrush(hatchBrush.HatchStyle, hatchBrush.ForegroundColor, hatchBrush.BackgroundColor);
            }

            Shape shape = null;
            if (this.shapeMode == ShapeMode.Line)
            {
                shape = new Line(e.Location, e.Location, newPen, this.order);
            }
            else if (this.shapeMode == ShapeMode.RegularPolygon)
            {
                shape = new RegularPolygon(e.Location, e.Location, newPen, newBrush, this.order);
            }
            else if (this.shapeMode == ShapeMode.RegularPolygonLine)
            {
                shape = new RegularPolygonLine(e.Location, e.Location, newPen, this.order);
            }
            else if (this.shapeMode == ShapeMode.Rectangle)
            {
                shape = new RectangleShape(e.Location, e.Location, newPen, newBrush, this.order);
            }
            else if (this.shapeMode == ShapeMode.Ellipse)
            {
                shape = new Eclipse(e.Location, e.Location, newPen, newBrush, this.order);
            }
            else if (this.shapeMode == ShapeMode.Circle)
            {
                shape = new Circle(e.Location, e.Location, newPen, newBrush, this.order);
            }
            else if (this.shapeMode == ShapeMode.Square)
            {
                shape = new Square(e.Location, e.Location, newPen, newBrush, this.order);
            }
            else if (this.shapeMode == ShapeMode.LineSquare)
            {
                shape = new SquareLine(e.Location, e.Location, newPen, newBrush, this.order);
            }
            else if (this.shapeMode == ShapeMode.LineCircle)
            {
                shape = new CircleLine(e.Location, e.Location, newPen, newBrush, this.order);
            }
            else if (this.shapeMode == ShapeMode.LineEllipse)
            {
                shape = new EclipseLine(e.Location, e.Location, newPen, newBrush, this.order);
            }
            else if (this.shapeMode == ShapeMode.LineRectangle)
            {
                shape = new RectangleLine(e.Location, e.Location, newPen, newBrush, this.order);
            }
            else if (this.shapeMode == ShapeMode.Curve)
            {
                shape = new Curve(e.Location, e.Location, newPen, this.order);
            }
            else if (this.shapeMode == ShapeMode.TriangleLine)
            {
                shape = new TriangleLine(e.Location, e.Location, newPen, newBrush,this.order);
            }
            else if (this.shapeMode == ShapeMode.Triangle)
            {
                shape = new Triangle(e.Location, e.Location, newPen, newBrush,this.order);
            }

            if (shape != null)
            {
                this.objects.Add(shape);
                this.order++;
            }
        }


        private void HandleShapeSelection(MouseEventArgs e)
        {
            bool isCtrlPressed = (Control.ModifierKeys & Keys.Control) == Keys.Control;
            bool isShiftPressed = (Control.ModifierKeys & Keys.Shift) == Keys.Shift;

            if (isShiftPressed)
            {
                this.isResizing = true;
                this.isChoosingShape = true;
            }

            if (!isCtrlPressed)
            {
                DeselectAllShapes();
            }

            if (!isResizing)
            {
                SelectShapeAtPoint(e.Location);
            }

            if (!this.isChoosingShape)
            {
                ClearShapeSelection();
            }

            this.drawingMode = DrawingMode.NONE;
            this.isStart = false;
            this.draw_panel.Refresh();
            this.cursorInitialLocation = e.Location;
        }

        private void SelectShapeAtPoint(Point location)
        {
            foreach (Shape shape in this.objects)
            {
                if (shape.isPointInsideShape(location))
                {
                    if (shape.IsSelected)
                    {
                        shape.IsSelected = false;
                        this.selectedShapes.Remove(shape);
                    }
                    else
                    {
                        shape.IsSelected = true;
                        this.currentChoosenGroup = this.getGroup(shape);
                        if (this.currentChoosenGroup == null || this.currentChoosenGroup.Count == 0)
                        {
                            this.selectedShapes.Add(shape);
                        }

                        this.selectedShape = shape;
                        this.isChoosingShape = true;
                    }
                    this.draw_panel.Refresh();
                    break;
                }
            }
        }

        private List<Shape> getGroup(Shape shape)
        {
            foreach (List<Shape> group in this.groupedList)
            {
                if (group.Contains(shape))
                {
                    foreach (Shape shapeGroup in group)
                    {
                        shapeGroup.IsSelected = true;
                        this.selectedShapes.Add(shapeGroup);
                    }
                    return group;
                }
            }
            return null;
        }
        private void DeselectAllShapes()
        {
            foreach (Shape shape in this.objects)
            {
                shape.IsSelected = false;
            }
            this.selectedShapes.Clear();
        }

        private void draw_panel_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape shape in objects)
            {
                shape.Draw(this.gp);
            }
        }
        public void GroupShapes(List<Shape> selectedShapes, List<List<Shape>> groupedShapes)
        {
            // Check if there are at least two shapes selected to form a group
            if (selectedShapes == null || selectedShapes.Count < 2)
            {
                MessageBox.Show("Please select at least two shapes to group.");
                return;
            }

            // Create a new list to store the shapes being grouped
            List<Shape> newGroup = new List<Shape>();

            // Add all selected shapes to the new group
            foreach (Shape shape in selectedShapes)
            {
                newGroup.Add(shape);
            }

            // Add the new group to the list of grouped shapes
            groupedShapes.Add(newGroup);

            // Optional: Deselect all shapes after grouping
            foreach (Shape shape in selectedShapes)
            {
                shape.IsSelected = false;
            }

            // Optional: Show confirmation message
            MessageBox.Show($"Successfully grouped {selectedShapes.Count} shapes.");
        }

        private void polygon_btn_Click(object sender, EventArgs e)
        {
            if (this.drawingMode == DrawingMode.PEN)
            {
                this.shapeMode = ShapeMode.RegularPolygonLine;
            }
            else this.shapeMode = ShapeMode.RegularPolygon;
        }

        private void triangle_btn_Click(object sender, EventArgs e)
        {


            if (this.drawingMode == DrawingMode.PEN)
            {
                this.shapeMode = ShapeMode.TriangleLine;
            }
            else this.shapeMode = ShapeMode.Triangle;
        }
    }
}
