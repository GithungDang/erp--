namespace RibbonStyle
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class InfoForm : Form
    {
        private string _title = "";
        private string _comment = "";
        private string _picture = "";
        private Color _fillcolor;
        private Image img;
        private int XC = 8;
        private int YC = 20;
        private int WC = 220;
        private int HC = 90;
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
        private OffInfoShadow shadow;
        private Timer timer = new Timer();
        private int ms = 300;
        private int j = 10;
        private bool appearing = true;
        private Pen p = new Pen(Color.Black, 8f);
        private Brush b = new SolidBrush(Color.FromArgb(160, 0, 0xff, 0));

        public InfoForm()
        {
            this.BackColor = Color.Fuchsia;
            base.TransparencyKey = Color.Fuchsia;
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.ShowInTaskbar = false;
            base.SetStyle(ControlStyles.DoubleBuffer, true);
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.ShowInTaskbar = false;
            base.FormBorderStyle = FormBorderStyle.None;
            base.Width = 10;
            base.Height = 10;
            base.Opacity = 0.8;
            base.StartPosition = FormStartPosition.Manual;
            this.timer.Interval = 5;
            this.timer.Tick += new EventHandler(this.timer_Tick);
        }

        public void Close()
        {
            this.appearing = false;
            this.timer.Start();
        }

        public void DrawArc()
        {
            this.X = this.X0;
            this.Y = this.Y0;
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

        protected override void OnLoad(EventArgs e)
        {
            this.shadow = new OffInfoShadow();
            this.shadow.Location = new Point(base.Location.X + 8, base.Location.Y + 12);
            this.shadow.Size = base.Size;
            this.shadow.Show();
            this.timer.Start();
            base.OnLoad(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            this.T = 6;
            this.D = -1;
            this.X0 = 0;
            this.Y0 = 0;
            this.XF = e.ClipRectangle.Width - 10;
            this.YF = e.ClipRectangle.Height - 7;
            Rectangle rect = new Rectangle(this.X0, this.Y0, this.XF, this.YF + 14);
            this.DrawArc();
            try
            {
                LinearGradientBrush brush;
                if (this._fillcolor.GetBrightness() > 0.5)
                {
                    this.ForeColor = Color.FromArgb(0, 0, 0);
                    brush = new LinearGradientBrush(rect, Color.White, this._fillcolor, LinearGradientMode.Vertical);
                }
                else
                {
                    this.ForeColor = Color.FromArgb(220, 220, 220);
                    brush = new LinearGradientBrush(rect, this._fillcolor, Color.FromArgb(60, 60, 60), LinearGradientMode.Vertical);
                }
                e.Graphics.FillPath(brush, this.path);
            }
            catch
            {
            }
            this.T = 6;
            this.D = -1;
            this.X0 = 0;
            this.Y0 = 0;
            this.XF = e.ClipRectangle.Width - 10;
            this.YF = e.ClipRectangle.Height - 7;
            rect = new Rectangle(this.X0, this.Y0, this.XF, this.YF + 14);
            this.DrawArc();
            e.Graphics.DrawPath(new Pen(Color.FromArgb(0x76, 0x76, 0x76)), this.path);
            Point point = new Point(5, 3);
            Font font = new Font(this.Font, FontStyle.Bold);
            Pen pen = new Pen(this.ForeColor);
            graphics.DrawString(this._title, font, pen.Brush, (PointF) point);
            RectangleF layoutRectangle = new RectangleF((float) this.XC, (float) this.YC, (float) this.WC, (float) this.HC);
            graphics.DrawString(this._comment, this.Font, pen.Brush, layoutRectangle);
            if (this.img != null)
            {
                graphics.DrawImage(this.img, 12, 30, this.img.Width, this.img.Height);
                graphics.DrawLine(new Pen(this._fillcolor), 5, 0xa6, 0x174, 0xa6);
                graphics.DrawLine(new Pen(Color.White), 5, 0xa7, 0x174, 0xa7);
            }
            base.OnPaint(e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.appearing)
            {
                if (base.Opacity != 1.0)
                {
                    base.Opacity += 0.1;
                }
                else if (this.j < this.ms)
                {
                    this.j++;
                }
                else
                {
                    this.appearing = !this.appearing;
                }
            }
            if (!this.appearing)
            {
                if (base.Opacity == 0.0)
                {
                    this.Close();
                }
                else
                {
                    base.Opacity -= 0.2;
                    this.shadow.Close();
                }
            }
        }

        public string Title
        {
            get => 
                this._title;
            set
            {
                base.Size = new Size(150, 30);
                this._title = value;
            }
        }

        public string Comment
        {
            get => 
                this._comment;
            set
            {
                if (value != "")
                {
                    base.Size = new Size(240, 100);
                    this._comment = value;
                }
            }
        }

        public string Picture
        {
            get => 
                this._picture;
            set
            {
                if (value != "")
                {
                    base.Size = new Size(380, 180);
                    this.XC = 0x7a;
                    this.YC = 30;
                    this.WC = 240;
                    this.HC = 120;
                    this._picture = value;
                    try
                    {
                        this.img = Image.FromFile(this._picture);
                    }
                    catch
                    {
                    }
                }
            }
        }

        public Color FillColor
        {
            get => 
                this._fillcolor;
            set => 
                this._fillcolor = value;
        }
    }
}

