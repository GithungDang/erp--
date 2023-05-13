namespace RibbonStyle
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class RibbonButton : Button
    {
        private Timer timer1 = new Timer();
        private Timer timer2 = new Timer();
        private Image _img_on;
        private Image _img_click;
        private Image _img_back;
        private Image _img;
        private Image _img_fad;
        private string s_folder;
        private string s_filename;
        private string _infotitle = "";
        private string _infocomment = "";
        private string _infoimage = "";
        private Color _infocolor = Color.FromArgb(0xc9, 0xd9, 0xef);
        private Color _TextColor = Color.Black;
        private Image _toshow;
        private bool b_fad;
        private int i_fad;
        private int i_value = 0xff;
        private InfoForm info;
        private int t;
        private int t_end = 100;

        public RibbonButton()
        {
            base.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
            base.FlatStyle = FlatStyle.Flat;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            base.FlatAppearance.BorderSize = 0;
            this.TextAlign = ContentAlignment.BottomCenter;
            base.ImageAlign = ContentAlignment.TopCenter;
            base.FlatAppearance.BorderColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            base.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            base.FlatAppearance.MouseOverBackColor = Color.FromArgb(100, 0xff, 0xff, 0xff);
            this._toshow = this._img_back;
            this.timer1.Interval = 10;
            this.timer1.Tick += new EventHandler(this.timer1_Tick);
            this.timer2.Interval = 10;
            this.timer2.Tick += new EventHandler(this.timer2_Tick);
        }

        public Side GetInfoLocation() => 
            ((Cursor.Position.X - Application.OpenForms[0].Location.X) >= (Application.OpenForms[0].Width / 2)) ? Side.UpRight : Side.UpLeft;

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            this.BackgroundImage = this._img_click;
            this._toshow = this._img_click;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (this.b_fad)
            {
                this.i_fad = 1;
                this.timer1.Start();
            }
            else
            {
                this.BackgroundImage = this._img_on;
                this._toshow = this._img_on;
            }
            base.OnMouseEnter(e);
        }

        protected override void OnMouseHover(EventArgs e)
        {
            this.timer2.Start();
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.b_fad)
            {
                this.i_fad = 2;
                this.timer1.Start();
            }
            else
            {
                this.BackgroundImage = this._img_back;
                this._toshow = this._img_back;
            }
            if (this.info != null)
            {
                this.info.Close();
            }
            this.timer2.Stop();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            this.BackgroundImage = this._img_on;
            this._toshow = this._img_on;
            base.OnMouseUp(mevent);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (base.Parent == null)
            {
                base.OnPaint(pevent);
            }
            else
            {
                GraphicsContainer container = pevent.Graphics.BeginContainer();
                pevent.Graphics.TranslateTransform(-((float) base.Left), -((float) base.Top));
                Rectangle clipRectangle = pevent.ClipRectangle;
                clipRectangle.Offset(base.Left, base.Top);
                PaintEventArgs e = new PaintEventArgs(pevent.Graphics, clipRectangle);
                base.InvokePaint(base.Parent, e);
                pevent.Graphics.EndContainer(container);
                Graphics graphics = pevent.Graphics;
                try
                {
                    graphics.DrawImage(this._toshow, pevent.ClipRectangle);
                }
                catch
                {
                }
                Rectangle rectangle2 = pevent.ClipRectangle;
                int x = 4;
                try
                {
                    int width = rectangle2.Width - 8;
                    Point location = new Point(x, 4);
                    Rectangle rect = new Rectangle(location, new Size(width, (width * this._img.Height) / this._img.Width));
                    graphics.DrawImage(this._img, rect);
                }
                catch
                {
                }
                SizeF ef = graphics.MeasureString(this.Text, this.Font);
                Point point2 = new Point(((rectangle2.X + rectangle2.Width) - ((int) ef.Width)) / 2, ((rectangle2.Y + rectangle2.Height) - ((int) ef.Height)) - 2);
                Pen pen = new Pen(this.ForeColor);
                graphics.DrawString(this.Text, this.Font, pen.Brush, (PointF) point2);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (base.Parent == null)
            {
                base.OnPaintBackground(pevent);
            }
            else
            {
                GraphicsContainer container = pevent.Graphics.BeginContainer();
                pevent.Graphics.TranslateTransform(-((float) base.Left), -((float) base.Top));
                Rectangle clipRectangle = pevent.ClipRectangle;
                clipRectangle.Offset(base.Left, base.Top);
                PaintEventArgs e = new PaintEventArgs(pevent.Graphics, clipRectangle);
                base.InvokePaintBackground(base.Parent, e);
                base.InvokePaint(base.Parent, e);
                pevent.Graphics.EndContainer(container);
            }
        }

        public void PaintBackground()
        {
            if (this.b_fad)
            {
                object obj2 = new object();
                if (this.i_fad == 1)
                {
                    obj2 = this._img_on.Clone();
                }
                else if (this.i_fad == 2)
                {
                    obj2 = this._img_back.Clone();
                }
                this._img_fad = (Image) obj2;
                Graphics.FromImage(this._img_fad).FillRectangle(new SolidBrush(Color.FromArgb(this.i_value, 0xff, 0xff, 0xff)), 0, 0, this._img_fad.Width, this._img_fad.Height);
                this.BackgroundImage = this._img_fad;
            }
        }

        public void ShowInfo()
        {
            this.info = new InfoForm();
            this.info.Title = this._infotitle;
            this.info.Comment = this._infocomment;
            this.info.Picture = this._infoimage;
            this.info.FillColor = this._infocolor;
            this.info.Location = (this.GetInfoLocation() != Side.UpLeft) ? new Point(Cursor.Position.X - this.info.Width, (Application.OpenForms[1].Location.Y + base.Bottom) + 80) : new Point(Cursor.Position.X, (Application.OpenForms[1].Location.Y + base.Bottom) + 80);
            this.info.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.i_fad)
            {
                case 1:
                    this.i_value ??= 0xff;
                    if (this.i_value > -1)
                    {
                        this.PaintBackground();
                        this.i_value -= 10;
                        return;
                    }
                    this.i_value = 0;
                    this.PaintBackground();
                    this.timer1.Stop();
                    return;

                case 2:
                    this.i_value ??= 0xff;
                    if (this.i_value > -1)
                    {
                        this.PaintBackground();
                        this.i_value -= 10;
                        return;
                    }
                    this.i_value = 0;
                    this.PaintBackground();
                    this.timer1.Stop();
                    return;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.t < this.t_end)
            {
                this.t++;
            }
            else
            {
                this.timer2.Stop();
                this.t = 0;
                this.ShowInfo();
            }
        }

        public Image img_on
        {
            get => 
                this._img_on;
            set => 
                this._img_on = value;
        }

        public Image img_click
        {
            get => 
                this._img_click;
            set => 
                this._img_click = value;
        }

        public Image img_back
        {
            get => 
                this._img_back;
            set => 
                this._img_back = value;
        }

        public Image img
        {
            get => 
                this._img;
            set
            {
                this._img = value;
                base.Image = this._img;
            }
        }

        public string folder
        {
            get => 
                this.s_folder;
            set
            {
                if (value != null)
                {
                    if (value[value.Length - 1] != '\\')
                    {
                        this.s_folder = value + @"\";
                    }
                    else
                    {
                        this.s_folder = value;
                    }
                }
            }
        }

        public string filename
        {
            get => 
                this.s_filename;
            set
            {
                this.s_filename = value;
                if (!ReferenceEquals(this.s_folder, null) & !ReferenceEquals(this.s_filename, null))
                {
                    this._img = Image.FromFile(this.s_folder + this.s_filename);
                    base.Image = this._img;
                }
            }
        }

        public string InfoTitle
        {
            get => 
                this._infotitle;
            set => 
                this._infotitle = value;
        }

        public string InfoComment
        {
            get => 
                this._infocomment;
            set => 
                this._infocomment = value;
        }

        public string InfoImage
        {
            get => 
                this._infoimage;
            set => 
                this._infoimage = value;
        }

        public Color InfoColor
        {
            get => 
                this._infocolor;
            set => 
                this._infocolor = value;
        }

        public enum Side
        {
            UpLeft,
            UpRight,
            DownLeft,
            DownRight
        }
    }
}

