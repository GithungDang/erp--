namespace RibbonStyle
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class RibbonPanel : Panel
    {
        private int X0;
        private int XF;
        private int Y0;
        private int YF;
        private int T = 3;
        private int i_Zero = 180;
        private int i_Sweep = 90;
        private int X;
        private int Y;
        private GraphicsPath path;
        private int D = -1;
        private int R0 = 0xd7;
        private int G0 = 0xe3;
        private int B0 = 0xf2;
        private Color _BaseColor = Color.FromArgb(0xd7, 0xe3, 0xf2);
        private Color _BaseColorOn = Color.FromArgb(0xd7, 0xe3, 0xf2);
        private int i_mode;
        private int i_factor = 8;
        private int i_fR = 1;
        private int i_fG = 1;
        private int i_fB = 1;
        private int i_Op = 0xff;
        private string S_TXT = "";
        private Timer timer1 = new Timer();
        private int activex0;
        private int activexf;
        private bool activestate;

        public RibbonPanel()
        {
            base.Padding = new Padding(0, 3, 0, 0);
            this.timer1.Interval = 1;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            base.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        public void DrawArc()
        {
            this.X = this.X0 - 2;
            this.Y = this.Y0 - 1;
            this.i_Zero = 180;
            this.D++;
            this.path = new GraphicsPath();
            this.path.AddArc(this.X + this.D, this.Y + this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            this.X += this.XF;
            this.path.AddArc(this.X - this.D, this.Y + this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            this.Y += this.YF;
            this.path.AddArc(this.X - this.D, this.Y - this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            this.X -= this.XF;
            this.path.AddArc(this.X + this.D, this.Y - this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            this.Y -= this.YF;
            this.path.AddArc(this.X + this.D, this.Y + this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
        }

        public void DrawArc2(int OF_Y, int SW_Y)
        {
            this.X = this.X0 - 1;
            this.Y = this.Y0 + OF_Y;
            this.i_Zero = 180;
            this.path = new GraphicsPath();
            this.path.AddArc(this.X + this.D, this.Y + this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            this.X += this.XF - 1;
            this.path.AddArc(this.X - this.D, this.Y + this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            this.Y += SW_Y - 20;
            this.path.AddArc(this.X - this.D, this.Y - this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            this.X -= this.XF - 1;
            this.path.AddArc(this.X + this.D, this.Y - this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            this.Y -= SW_Y - 20;
            this.path.AddArc(this.X + this.D, this.Y + this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
        }

        public void DrawFHalfArc()
        {
            this.X = this.X0 - 2;
            this.Y = this.Y0 - 1;
            this.i_Zero = 180;
            this.D++;
            this.path = new GraphicsPath();
            this.path.AddArc(this.X + this.D, this.Y + this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            this.X += this.XF - 1;
            this.path.AddArc(this.X - this.D, this.Y + this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            this.Y += this.YF;
            this.path.AddArc(this.X - this.D, this.Y - this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
        }

        public void DrawSHalfArc()
        {
            this.X = this.X0 - 3;
            this.Y = this.Y0 - 1;
            this.i_Zero = 180;
            this.D++;
            this.path = new GraphicsPath();
            this.i_Zero += 90;
            this.X += this.XF;
            this.path.AddArc(this.X - this.D, this.Y + this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            this.Y += this.YF - 1;
            this.path.AddArc(this.X - this.D, this.Y - this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            this.X -= this.XF - 1;
            this.path.AddArc(this.X + this.D, this.Y - this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
            this.i_Zero += 90;
            this.Y -= this.YF - 1;
            this.path.AddArc(this.X + this.D, this.Y + this.D, this.T, this.T, (float) this.i_Zero, (float) this.i_Sweep);
        }

        public void LinePos(int x0, int xf, bool state)
        {
            this.activex0 = x0;
            this.activexf = xf;
            this.activestate = state;
            this.Refresh();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            Point position = Cursor.Position;
            position = base.PointToClient(position);
            if ((((position.X > 0) | (position.X < base.Width)) | (position.Y > 0)) | (position.Y < base.Height))
            {
                this.i_mode = 0;
                this.timer1.Start();
            }
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Point position = Cursor.Position;
            position = base.PointToClient(position);
            if ((((position.X < 0) | (position.X >= base.Width)) | (position.Y < 0)) | (position.Y >= base.Height))
            {
                this.i_mode = 1;
                this.timer1.Start();
            }
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.X0 = 0;
            this.XF = (base.Width + this.X0) - 3;
            this.Y0 = 0;
            this.YF = (base.Height + this.Y0) - 3;
            this.T = 6;
            Point point = new Point(this.X0, this.Y0 - 1);
            Point point2 = new Point(this.X0, (this.Y0 + this.YF) + 8);
            Pen pen1 = new Pen(Color.FromArgb(this.i_Op, this.R0 - 0x12, this.G0 - 0x11, this.B0 - 0x13));
            Pen black = Pens.Black;
            try
            {
                black = new Pen(Color.FromArgb(this.i_Op, this.R0 - 0x4a, this.G0 - 0x31, this.B0 - 15));
            }
            catch
            {
                black = new Pen(Color.FromArgb(this.i_Op, this.R0 - 0x16, this.G0 - 11, this.B0));
            }
            Pen pen = new Pen(Color.FromArgb(this.i_Op, this.R0 + 0x17, this.G0 + 0x15, this.B0 + 13));
            Pen pen7 = new Pen(Color.FromArgb(this.i_Op, this.R0 + 14, this.G0 + 9, this.B0 + 3));
            Pen pen3 = new Pen(Color.FromArgb(this.i_Op, this.R0 - 8, this.G0 - 4, this.B0 - 2));
            Pen pen4 = new Pen(Color.FromArgb(this.i_Op, this.R0 + 4, this.G0 + 3, this.B0 + 3));
            Pen pen6 = new Pen(Color.FromArgb(this.i_Op, this.R0 + 12, this.G0 + 0x11, this.B0 + 13));
            Pen pen8 = new Pen(Color.FromArgb(this.i_Op, this.R0 - 0x16, this.G0 - 10, this.B0));
            e.Graphics.PageUnit = GraphicsUnit.Pixel;
            Brush brush1 = pen3.Brush;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.X = this.X0;
            this.Y = this.Y0;
            this.i_Zero = 180;
            this.D = 0;
            this.DrawArc();
            e.Graphics.FillPath(pen4.Brush, this.path);
            Rectangle clipRectangle = e.ClipRectangle;
            LinearGradientBrush brush = new LinearGradientBrush(point, point2, new Pen(Color.FromArgb(this.i_Op, this.R0 - 0x10, this.G0 - 11, this.B0 - 5)).Color, pen6.Color);
            this.DrawArc2(0x11, this.YF + 7);
            e.Graphics.FillPath(brush, this.path);
            this.D--;
            this.DrawFHalfArc();
            e.Graphics.DrawPath(black, this.path);
            this.DrawSHalfArc();
            e.Graphics.DrawPath(pen, this.path);
            if (this.activestate)
            {
                e.Graphics.DrawLine(pen4, new Point(this.activex0 + 1, 0), new Point(this.activexf - 9, 0));
            }
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs eventargs)
        {
            this.Refresh();
            base.OnResize(eventargs);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.i_mode == 0)
            {
                this.i_fR = (Math.Abs((int) (this._BaseColorOn.R - this.R0)) <= this.i_factor) ? 1 : this.i_factor;
                this.i_fG = (Math.Abs((int) (this._BaseColorOn.G - this.G0)) <= this.i_factor) ? 1 : this.i_factor;
                this.i_fB = (Math.Abs((int) (this._BaseColorOn.B - this.B0)) <= this.i_factor) ? 1 : this.i_factor;
                if (this._BaseColorOn.R < this.R0)
                {
                    this.R0 -= this.i_fR;
                }
                else if (this._BaseColorOn.R > this.R0)
                {
                    this.R0 += this.i_fR;
                }
                if (this._BaseColorOn.G < this.G0)
                {
                    this.G0 -= this.i_fG;
                }
                else if (this._BaseColorOn.G > this.G0)
                {
                    this.G0 += this.i_fG;
                }
                if (this._BaseColorOn.B < this.B0)
                {
                    this.B0 -= this.i_fB;
                }
                else if (this._BaseColorOn.B > this.B0)
                {
                    this.B0 += this.i_fB;
                }
                if (this._BaseColorOn == Color.FromArgb(this.R0, this.G0, this.B0))
                {
                    this.timer1.Stop();
                }
                else
                {
                    this.Refresh();
                }
            }
            if (this.i_mode == 1)
            {
                this.i_fR = (Math.Abs((int) (this._BaseColor.R - this.R0)) >= this.i_factor) ? this.i_factor : 1;
                this.i_fG = (Math.Abs((int) (this._BaseColor.G - this.G0)) >= this.i_factor) ? this.i_factor : 1;
                this.i_fB = (Math.Abs((int) (this._BaseColor.B - this.B0)) >= this.i_factor) ? this.i_factor : 1;
                if (this._BaseColor.R < this.R0)
                {
                    this.R0 -= this.i_fR;
                }
                else if (this._BaseColor.R > this.R0)
                {
                    this.R0 += this.i_fR;
                }
                if (this._BaseColor.G < this.G0)
                {
                    this.G0 -= this.i_fG;
                }
                else if (this._BaseColor.G > this.G0)
                {
                    this.G0 += this.i_fG;
                }
                if (this._BaseColor.B < this.B0)
                {
                    this.B0 -= this.i_fB;
                }
                else if (this._BaseColor.B > this.B0)
                {
                    this.B0 += this.i_fB;
                }
                if (this._BaseColor == Color.FromArgb(this.R0, this.G0, this.B0))
                {
                    this.timer1.Stop();
                }
                else
                {
                    this.Refresh();
                }
            }
        }

        public Color BaseColor
        {
            get => 
                this._BaseColor;
            set
            {
                this._BaseColor = value;
                this.R0 = this._BaseColor.R;
                this.B0 = this._BaseColor.B;
                this.G0 = this._BaseColor.G;
            }
        }

        public Color BaseColorOn
        {
            get => 
                this._BaseColorOn;
            set
            {
                this._BaseColorOn = value;
                this.R0 = this._BaseColor.R;
                this.B0 = this._BaseColor.B;
                this.G0 = this._BaseColor.G;
            }
        }

        public string Caption
        {
            get => 
                this.S_TXT;
            set
            {
                this.S_TXT = value;
                this.Refresh();
            }
        }

        public int Speed
        {
            get => 
                this.i_factor;
            set => 
                this.i_factor = value;
        }

        public int Opacity
        {
            get => 
                this.i_Op;
            set
            {
                if ((value < 0x100) | (value > -1))
                {
                    this.i_Op = value;
                }
            }
        }
    }
}

