namespace RibbonStyle
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Windows.Forms;

    public class TabStripProfessionalRenderer : ToolStripProfessionalRenderer
    {
        private const int BOTTOM_LEFT = 0;
        private const int TOP_LEFT = 1;
        private const int TOP_RIGHT = 2;
        private const int BOTTOM_RIGHT = 3;
        private Color oncolor;
        private Color onbackcolor;
        private Color basecolor;
        private Color halocolor;
        private int X0;
        private int XF;
        private int Y0;
        private int YF;
        private int T = 2;
        private int i_Zero = 180;
        private int i_Sweep = 90;
        private int X;
        private int Y;
        private GraphicsPath path;
        private int D = -1;

        public TabStripProfessionalRenderer()
        {
            base.RoundedEdges = false;
            this.OnColor = Color.FromArgb(0xe2, 0xd1, 0x9c);
            this.OnBackColor = Color.FromArgb(0xbf, 0xdb, 0xff);
        }

        public void DrawArc(int VOff)
        {
            this.i_Zero = 180;
            this.X0 += this.D;
            this.XF -= this.D;
            this.Y0 += VOff;
            this.path = new GraphicsPath();
            Point point = new Point(this.X0, this.YF);
            Point point2 = new Point(this.X0, this.Y0 + this.T);
            this.path.AddLine(point, point2);
            this.path.AddArc(this.X0, this.Y0, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            point = new Point(this.X0 + this.T, this.Y0);
            point2 = new Point(this.XF - this.T, this.Y0);
            this.path.AddLine(point, point2);
            this.path.AddArc((this.XF - this.T) - 1, this.Y0, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            point = new Point(this.XF - 1, this.Y0 + this.T);
            point2 = new Point(this.XF - 1, this.YF);
            this.path.AddLine(point, point2);
        }

        public void DrawHalo(int _X0, int _Y0, int _XF, int _YF)
        {
            this.path = new GraphicsPath();
            Point point = new Point(_X0 + 5, _YF - 3);
            Point point2 = new Point(_X0 + 6, _Y0 + 3);
            this.path.AddLine(point, point2);
            point = new Point(_X0 + 7, _Y0);
            point2 = new Point(_XF - 8, _Y0);
            this.path.AddLine(point, point2);
            point = new Point(_XF - 7, _Y0 + 3);
            point2 = new Point(_XF - 6, _YF - 3);
            this.path.AddLine(point, point2);
        }

        public void DrawTab(int _X0, int _Y0, int _XF, int _YF)
        {
            this.T = 6;
            this.i_Zero = 90;
            this.path = new GraphicsPath();
            Point point1 = new Point(_X0, _YF);
            Point point2 = new Point(_X0 + this.T, _YF - this.T);
            this.path.AddArc(_X0, _YF - this.T, this.T, this.T, (float) this.i_Zero, -((float) this.i_Sweep));
            this.i_Zero = 180;
            this.path.AddArc(_X0 + this.T, _Y0, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero = 270;
            this.path.AddArc(_XF - (2 * this.T), _Y0, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero = 180;
            this.path.AddArc(_XF - this.T, _YF - this.T, this.T, this.T, (float) this.i_Zero, -((float) this.i_Sweep));
        }

        protected override unsafe void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            TabStrip toolStrip = e.ToolStrip as TabStrip;
            Tab item = e.Item as Tab;
            int num = item.i_opacity;
            if (item == null)
            {
                base.OnRenderButtonBackground(e);
            }
            else
            {
                Rectangle rectangle = new Rectangle(Point.Empty, e.Item.Size);
                Graphics graphics = e.Graphics;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                int num2 = Convert.ToInt16(graphics.MeasureString(item.Text, item.Font).Width) - Convert.ToInt16((int) (item.Text.Length / 3));
                Convert.ToInt16(graphics.MeasureString(item.Text, item.Font).Height);
                if (toolStrip == null)
                {
                    base.OnRenderButtonBackground(e);
                }
                else if (item.b_selected & !item.b_active)
                {
                    Rectangle rect = rectangle;
                    rect.Width = (item.Width - num2) / 2;
                    Rectangle* rectanglePtr1 = &rect;
                    rectanglePtr1.X += 2;
                    Rectangle* rectanglePtr2 = &rect;
                    rectanglePtr2.Width -= 2;
                    Color baseColor = this.BaseColor;
                    baseColor = this.SetTransparency(baseColor, 0);
                    Color haloColor = this.HaloColor;
                    haloColor = this.SetTransparency(haloColor, 0xff - num);
                    graphics.FillRectangle(new LinearGradientBrush(rect, baseColor, haloColor, LinearGradientMode.BackwardDiagonal), rect.X, rect.Y, rect.Width, rect.Height);
                    int x = (rectangle.Width - rect.Width) - 1;
                    rect.Location = new Point(x, 1);
                    graphics.FillRectangle(new LinearGradientBrush(rect, baseColor, haloColor, LinearGradientMode.ForwardDiagonal), x, rect.Y, rect.Width, rect.Height);
                    Rectangle rectangle3 = rectangle;
                    Rectangle* rectanglePtr3 = &rectangle3;
                    rectanglePtr3.X += 2;
                    Rectangle* rectanglePtr4 = &rectangle3;
                    rectanglePtr4.Width -= 2;
                    Rectangle* rectanglePtr5 = &rectangle3;
                    rectanglePtr5.Height /= 2;
                    Color color = this.BaseColor;
                    Color color4 = this.HaloColor;
                    graphics.FillRectangle(new LinearGradientBrush(rectangle3, this.SetTransparency(color, 0xff - num), this.SetTransparency(color4, 0xff - num), LinearGradientMode.Vertical), rectangle3.X, (rectangle3.Y + rectangle3.Height) + 1, rectangle3.Width - rectangle3.X, rectangle3.Height);
                    int num5 = 0;
                    this.X0 = 0;
                    this.XF = item.Width + this.X0;
                    this.YF = item.Height + this.Y0;
                    this.Y0 = 0;
                    Point point1 = new Point(this.X0, this.Y0);
                    Point point5 = new Point(this.X0, this.YF / 2);
                    Color onBackColor = this.OnBackColor;
                    onBackColor = this.SetTransparency(onBackColor, 0);
                    Color white = Color.White;
                    Rectangle rectangle4 = new Rectangle(this.X0, this.Y0 + num5, this.X0 + 1, this.YF / 2);
                    graphics.FillRectangle(new LinearGradientBrush(rectangle4, onBackColor, white, LinearGradientMode.Vertical), this.X0, this.Y0 + num5, rectangle4.Width, rectangle4.Height);
                    rectangle4 = new Rectangle(this.X0, (this.YF / 2) - 1, this.X0 + 1, this.YF - num5);
                    graphics.FillRectangle(new LinearGradientBrush(rectangle4, white, onBackColor, LinearGradientMode.Vertical), this.X0, (this.YF / 2) - 1, rectangle4.Width, rectangle4.Height);
                    Rectangle rectangle5 = new Rectangle(this.XF - 2, this.Y0 + num5, this.XF - 1, this.YF / 2);
                    graphics.FillRectangle(new LinearGradientBrush(rectangle5, onBackColor, white, LinearGradientMode.Vertical), this.XF - 1, this.Y0 + num5, rectangle5.Width, rectangle5.Height);
                    rectangle5 = new Rectangle(this.XF - 2, (this.YF / 2) - 1, this.XF - 1, this.YF - num5);
                    graphics.FillRectangle(new LinearGradientBrush(rectangle5, white, onBackColor, LinearGradientMode.Vertical), this.XF - 1, (this.YF / 2) - 1, rectangle5.Width, rectangle5.Height);
                    this.X0 = 0;
                    this.XF = item.Width + this.X0;
                    this.Y0 = 0;
                    this.YF = item.Height + this.Y0;
                    Point point6 = new Point(this.X0, this.Y0);
                    Point point7 = new Point(this.X0, (this.Y0 + this.YF) - 15);
                    Color color7 = this.BaseColor;
                    this.X = this.X0;
                    this.Y = this.Y0;
                    this.i_Zero = 270;
                    this.D = 1;
                    this.T = 5;
                    this.DrawArc(0);
                    graphics.DrawPath(new Pen(this.SetTransparency(color7, 0xff - num)), this.path);
                    this.X = this.X0;
                    this.Y = this.Y0;
                    this.i_Zero = 270;
                    this.D = 1;
                    this.T = 5;
                    this.DrawArc(1);
                    Color color8 = Color.White;
                    graphics.DrawPath(new Pen(this.SetTransparency(color8, 0xa4 - num)), this.path);
                }
                else if (item.b_active & !item.b_selected)
                {
                    Rectangle rect = new Rectangle(8, 3, rectangle.Width - 0x10, 4);
                    graphics.FillRectangle(new SolidBrush(Color.FromArgb(0xf5, 250, 0xff)), rect);
                    Color baseColor = this.BaseColor;
                    Rectangle rectangle7 = new Rectangle(6, 3, rectangle.Width - 12, rectangle.Height);
                    graphics.FillRectangle(new LinearGradientBrush(rectangle7, Color.FromArgb(baseColor.R + 0x13, baseColor.G + 15, baseColor.B + 10), baseColor, LinearGradientMode.Vertical), rectangle7);
                    Pen white = Pens.White;
                    Pen pen = Pens.White;
                    Pen pen4 = Pens.White;
                    int r = this.BaseColor.R;
                    int g = this.BaseColor.G;
                    int b = this.BaseColor.B;
                    int num9 = 0;
                    int num10 = 0;
                    int width = rectangle.Width;
                    int height = rectangle.Height;
                    if (((r != 0) & (g != 0)) & (b != 0))
                    {
                        if (this.BaseColor.GetBrightness() < 0.5)
                        {
                            white = new Pen(Color.FromArgb(r - 0x16, g - 11, b));
                            pen = new Pen(Color.FromArgb(r + 0x12, g + 0x19, b));
                            pen4 = new Pen(Color.FromArgb(r, g, b));
                        }
                        else
                        {
                            white = new Pen(Color.FromArgb(r - 0x4a, g - 0x31, b - 15));
                            pen = new Pen(Color.FromArgb(r - 8, g - 0x18, b + 10));
                            pen4 = new Pen(Color.FromArgb(r, g, b));
                        }
                        this.DrawTab(num9, num10, width, height);
                        graphics.DrawPath(white, this.path);
                        this.DrawTab(num9 + 1, num10 + 1, width - 1, height);
                        graphics.DrawPath(pen, this.path);
                        this.DrawTab(num9 + 2, num10 + 2, width - 2, height);
                        graphics.DrawPath(pen4, this.path);
                    }
                    Point point = new Point(rectangle.Right - 5, 3);
                    Point point2 = new Point(rectangle.Right - 5, rectangle.Height - 2);
                    graphics.DrawLine(new Pen(this.SetTransparency(Color.Black, 20)), point, point2);
                    point = new Point(rectangle.Right - 4, 4);
                    point2 = new Point(rectangle.Right - 4, rectangle.Height - 1);
                    graphics.DrawLine(new Pen(this.SetTransparency(Color.Black, 10)), point, point2);
                }
                else if (item.b_active & item.b_selected)
                {
                    Rectangle rect = new Rectangle(8, 3, rectangle.Width - 0x10, 4);
                    graphics.FillRectangle(new SolidBrush(Color.FromArgb(0xf5, 250, 0xff)), rect);
                    Color baseColor = this.BaseColor;
                    Rectangle rectangle9 = new Rectangle(6, 3, rectangle.Width - 12, rectangle.Height);
                    graphics.FillRectangle(new LinearGradientBrush(rectangle9, Color.FromArgb(baseColor.R + 0x13, baseColor.G + 15, baseColor.B + 10), baseColor, LinearGradientMode.Vertical), rectangle9);
                    Pen white = Pens.White;
                    Pen pen = Pens.White;
                    Pen pen8 = Pens.White;
                    int r = this.BaseColor.R;
                    int g = this.BaseColor.G;
                    int b = this.BaseColor.B;
                    int num16 = 0;
                    int num17 = 0;
                    int width = rectangle.Width;
                    int height = rectangle.Height;
                    if (((r != 0) & (g != 0)) & (b != 0))
                    {
                        if (this.BaseColor.GetBrightness() < 0.5)
                        {
                            white = new Pen(Color.FromArgb(r - 0x1a, g - 14, b - 3));
                            pen = new Pen(Color.FromArgb(r + 0x12, g + 0x19, b));
                            pen8 = new Pen(Color.FromArgb(r, g, b));
                        }
                        else
                        {
                            white = new Pen(Color.FromArgb(r - 0x4a, g - 0x31, b - 15));
                            pen = new Pen(Color.FromArgb(r - 8, g - 0x18, b + 10));
                            pen8 = new Pen(Color.FromArgb(r, g, b));
                        }
                        this.DrawTab(num16, num17, width, height);
                        graphics.DrawPath(white, this.path);
                        this.DrawTab(num16 + 1, num17 + 1, width - 1, height);
                        graphics.DrawPath(pen, this.path);
                        this.DrawTab(num16 + 2, num17 + 2, width - 2, height);
                        graphics.DrawPath(pen8, this.path);
                    }
                    Point point3 = new Point(rectangle.Right - 5, 3);
                    Point point4 = new Point(rectangle.Right - 5, rectangle.Height - 2);
                    graphics.DrawLine(new Pen(this.SetTransparency(Color.Black, 20)), point3, point4);
                    point3 = new Point(rectangle.Right - 4, 4);
                    point4 = new Point(rectangle.Right - 4, rectangle.Height - 1);
                    graphics.DrawLine(new Pen(this.SetTransparency(Color.Black, 10)), point3, point4);
                    Color halocolor = this.halocolor;
                    halocolor = this.SetTransparency(halocolor, 0xff - num);
                    this.DrawHalo(num16, num17, width, height);
                    graphics.DrawPath(new Pen(halocolor), this.path);
                    this.DrawHalo(num16 + 1, num17 + 1, width + 1, height);
                    graphics.DrawPath(new Pen(halocolor), this.path);
                }
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
        }

        public Color SetTransparency(Color color, int transparency) => 
            !((transparency >= 0) & (transparency <= 0xff)) ? ((transparency <= 0xff) ? Color.FromArgb(0, color.R, color.G, color.B) : Color.FromArgb(0xff, color.R, color.G, color.B)) : Color.FromArgb(transparency, color.R, color.G, color.B);

        public Color OnColor
        {
            get => 
                this.oncolor;
            set => 
                this.oncolor = value;
        }

        public Color OnBackColor
        {
            get => 
                this.onbackcolor;
            set => 
                this.onbackcolor = value;
        }

        public Color BaseColor
        {
            get => 
                this.basecolor;
            set => 
                this.basecolor = value;
        }

        public Color HaloColor
        {
            get => 
                this.halocolor;
            set => 
                this.halocolor = value;
        }
    }
}

