namespace Custom_Paint
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.erase_btn = new System.Windows.Forms.Button();
            this.brush_btn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.select_btn = new System.Windows.Forms.Button();
            this.ungroup_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.retangle_btn = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.curve_btn = new System.Windows.Forms.Button();
            this.triangle_btn = new System.Windows.Forms.Button();
            this.polygon_btn = new System.Windows.Forms.Button();
            this.eclipse_btn = new System.Windows.Forms.Button();
            this.circle_btn = new System.Windows.Forms.Button();
            this.square_btn = new System.Windows.Forms.Button();
            this.line_btn = new System.Windows.Forms.Button();
            this.btn_pen = new System.Windows.Forms.Button();
            this.group_btn = new System.Windows.Forms.Button();
            this.draw_panel = new System.Windows.Forms.Panel();
            this.pen_panel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.erase_btn);
            this.panel1.Controls.Add(this.brush_btn);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.select_btn);
            this.panel1.Controls.Add(this.ungroup_btn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btn_pen);
            this.panel1.Controls.Add(this.group_btn);
            this.panel1.Location = new System.Drawing.Point(14, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 884);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(241, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 65);
            this.label1.TabIndex = 6;
            this.label1.Text = "WOM";
            // 
            // erase_btn
            // 
            this.erase_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("erase_btn.BackgroundImage")));
            this.erase_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.erase_btn.Location = new System.Drawing.Point(270, 608);
            this.erase_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.erase_btn.Name = "erase_btn";
            this.erase_btn.Size = new System.Drawing.Size(112, 125);
            this.erase_btn.TabIndex = 2;
            this.erase_btn.UseVisualStyleBackColor = true;
            this.erase_btn.Click += new System.EventHandler(this.erase_btn_Click);
            // 
            // brush_btn
            // 
            this.brush_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("brush_btn.BackgroundImage")));
            this.brush_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.brush_btn.Location = new System.Drawing.Point(151, 608);
            this.brush_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.brush_btn.Name = "brush_btn";
            this.brush_btn.Size = new System.Drawing.Size(112, 125);
            this.brush_btn.TabIndex = 1;
            this.brush_btn.UseVisualStyleBackColor = true;
            this.brush_btn.Click += new System.EventHandler(this.brush_btn_Click);
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel4.BackgroundImage")));
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(16, 22);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(248, 160);
            this.panel4.TabIndex = 0;
            // 
            // select_btn
            // 
            this.select_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("select_btn.BackgroundImage")));
            this.select_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.select_btn.Location = new System.Drawing.Point(32, 740);
            this.select_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(112, 125);
            this.select_btn.TabIndex = 5;
            this.select_btn.UseVisualStyleBackColor = true;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // ungroup_btn
            // 
            this.ungroup_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ungroup_btn.BackgroundImage")));
            this.ungroup_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ungroup_btn.Location = new System.Drawing.Point(270, 740);
            this.ungroup_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ungroup_btn.Name = "ungroup_btn";
            this.ungroup_btn.Size = new System.Drawing.Size(112, 125);
            this.ungroup_btn.TabIndex = 4;
            this.ungroup_btn.UseVisualStyleBackColor = true;
            this.ungroup_btn.Click += new System.EventHandler(this.ungroup_btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RosyBrown;
            this.panel2.Controls.Add(this.retangle_btn);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.curve_btn);
            this.panel2.Controls.Add(this.triangle_btn);
            this.panel2.Controls.Add(this.polygon_btn);
            this.panel2.Controls.Add(this.eclipse_btn);
            this.panel2.Controls.Add(this.circle_btn);
            this.panel2.Controls.Add(this.square_btn);
            this.panel2.Controls.Add(this.line_btn);
            this.panel2.Location = new System.Drawing.Point(16, 190);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(382, 410);
            this.panel2.TabIndex = 1;
            // 
            // retangle_btn
            // 
            this.retangle_btn.AllowDrop = true;
            this.retangle_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("retangle_btn.BackgroundImage")));
            this.retangle_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.retangle_btn.Location = new System.Drawing.Point(254, 9);
            this.retangle_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.retangle_btn.Name = "retangle_btn";
            this.retangle_btn.Size = new System.Drawing.Size(112, 125);
            this.retangle_btn.TabIndex = 5;
            this.retangle_btn.UseVisualStyleBackColor = true;
            this.retangle_btn.Click += new System.EventHandler(this.retangle_btn_Click);
            // 
            // button10
            // 
            this.button10.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button10.BackgroundImage")));
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button10.Location = new System.Drawing.Point(254, 274);
            this.button10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(112, 125);
            this.button10.TabIndex = 10;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // curve_btn
            // 
            this.curve_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("curve_btn.BackgroundImage")));
            this.curve_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.curve_btn.Location = new System.Drawing.Point(135, 274);
            this.curve_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.curve_btn.Name = "curve_btn";
            this.curve_btn.Size = new System.Drawing.Size(112, 125);
            this.curve_btn.TabIndex = 9;
            this.curve_btn.UseVisualStyleBackColor = true;
            this.curve_btn.Click += new System.EventHandler(this.curve_btn_Click);
            // 
            // triangle_btn
            // 
            this.triangle_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("triangle_btn.BackgroundImage")));
            this.triangle_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.triangle_btn.Location = new System.Drawing.Point(16, 274);
            this.triangle_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.triangle_btn.Name = "triangle_btn";
            this.triangle_btn.Size = new System.Drawing.Size(112, 125);
            this.triangle_btn.TabIndex = 8;
            this.triangle_btn.UseVisualStyleBackColor = true;
            this.triangle_btn.Click += new System.EventHandler(this.triangle_btn_Click);
            // 
            // polygon_btn
            // 
            this.polygon_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("polygon_btn.BackgroundImage")));
            this.polygon_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.polygon_btn.Location = new System.Drawing.Point(254, 141);
            this.polygon_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.polygon_btn.Name = "polygon_btn";
            this.polygon_btn.Size = new System.Drawing.Size(112, 125);
            this.polygon_btn.TabIndex = 7;
            this.polygon_btn.UseVisualStyleBackColor = true;
            this.polygon_btn.Click += new System.EventHandler(this.polygon_btn_Click);
            // 
            // eclipse_btn
            // 
            this.eclipse_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("eclipse_btn.BackgroundImage")));
            this.eclipse_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eclipse_btn.Location = new System.Drawing.Point(135, 141);
            this.eclipse_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.eclipse_btn.Name = "eclipse_btn";
            this.eclipse_btn.Size = new System.Drawing.Size(112, 125);
            this.eclipse_btn.TabIndex = 6;
            this.eclipse_btn.UseVisualStyleBackColor = true;
            this.eclipse_btn.Click += new System.EventHandler(this.eclipse_btn_Click);
            // 
            // circle_btn
            // 
            this.circle_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("circle_btn.BackgroundImage")));
            this.circle_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.circle_btn.Location = new System.Drawing.Point(16, 141);
            this.circle_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.circle_btn.Name = "circle_btn";
            this.circle_btn.Size = new System.Drawing.Size(112, 125);
            this.circle_btn.TabIndex = 5;
            this.circle_btn.UseVisualStyleBackColor = true;
            this.circle_btn.Click += new System.EventHandler(this.circle_btn_Click);
            // 
            // square_btn
            // 
            this.square_btn.AllowDrop = true;
            this.square_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("square_btn.BackgroundImage")));
            this.square_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.square_btn.Location = new System.Drawing.Point(135, 9);
            this.square_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.square_btn.Name = "square_btn";
            this.square_btn.Size = new System.Drawing.Size(112, 125);
            this.square_btn.TabIndex = 4;
            this.square_btn.UseVisualStyleBackColor = true;
            this.square_btn.Click += new System.EventHandler(this.square_btn_Click);
            // 
            // line_btn
            // 
            this.line_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("line_btn.BackgroundImage")));
            this.line_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.line_btn.Location = new System.Drawing.Point(16, 9);
            this.line_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.line_btn.Name = "line_btn";
            this.line_btn.Size = new System.Drawing.Size(112, 125);
            this.line_btn.TabIndex = 3;
            this.line_btn.UseVisualStyleBackColor = true;
            this.line_btn.Click += new System.EventHandler(this.line_btn_Click);
            // 
            // btn_pen
            // 
            this.btn_pen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_pen.BackgroundImage")));
            this.btn_pen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_pen.Location = new System.Drawing.Point(32, 608);
            this.btn_pen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_pen.Name = "btn_pen";
            this.btn_pen.Size = new System.Drawing.Size(112, 125);
            this.btn_pen.TabIndex = 1;
            this.btn_pen.UseVisualStyleBackColor = true;
            this.btn_pen.Click += new System.EventHandler(this.btn_pen_Click);
            // 
            // group_btn
            // 
            this.group_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("group_btn.BackgroundImage")));
            this.group_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.group_btn.Location = new System.Drawing.Point(151, 740);
            this.group_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.group_btn.Name = "group_btn";
            this.group_btn.Size = new System.Drawing.Size(112, 125);
            this.group_btn.TabIndex = 3;
            this.group_btn.UseVisualStyleBackColor = true;
            this.group_btn.Click += new System.EventHandler(this.group_btn_Click);
            // 
            // draw_panel
            // 
            this.draw_panel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.draw_panel.Location = new System.Drawing.Point(436, 15);
            this.draw_panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.draw_panel.Name = "draw_panel";
            this.draw_panel.Size = new System.Drawing.Size(1102, 884);
            this.draw_panel.TabIndex = 1;
            this.draw_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.draw_panel_Paint);
            this.draw_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.draw_panel_MouseDown);
            this.draw_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.draw_panel_MouseMove);
            this.draw_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.draw_panel_MouseUp);
            // 
            // pen_panel
            // 
            this.pen_panel.BackColor = System.Drawing.Color.Black;
            this.pen_panel.Location = new System.Drawing.Point(1546, 15);
            this.pen_panel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pen_panel.Name = "pen_panel";
            this.pen_panel.Size = new System.Drawing.Size(166, 884);
            this.pen_panel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1726, 914);
            this.Controls.Add(this.pen_panel);
            this.Controls.Add(this.draw_panel);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button brush_btn;
        private System.Windows.Forms.Button btn_pen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button curve_btn;
        private System.Windows.Forms.Button triangle_btn;
        private System.Windows.Forms.Button polygon_btn;
        private System.Windows.Forms.Button eclipse_btn;
        private System.Windows.Forms.Button circle_btn;
        private System.Windows.Forms.Button square_btn;
        private System.Windows.Forms.Button line_btn;
        private System.Windows.Forms.Button erase_btn;
        private System.Windows.Forms.Panel draw_panel;
        private System.Windows.Forms.Button select_btn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pen_panel;
        private System.Windows.Forms.Button ungroup_btn;
        private System.Windows.Forms.Button group_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button retangle_btn;
    }
}

