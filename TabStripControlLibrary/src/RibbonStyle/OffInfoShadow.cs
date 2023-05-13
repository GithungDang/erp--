namespace RibbonStyle
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class OffInfoShadow : Form
    {
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

        public OffInfoShadow()
        {
            base.ShowInTaskbar = false;
            this.BackColor = Color.FromArgb(0xff, 0xff, 0xff);
            base.TransparencyKey = Color.FromArgb(0xff, 0xff, 0xff);
            base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            base.SetStyle(ControlStyles.ResizeRedraw, true);
            base.SetStyle(ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.Opacity = 0.5;
            base.FormBorderStyle = FormBorderStyle.None;
            base.StartPosition = FormStartPosition.Manual;
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

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            this.T = 12;
            this.D = -1;
            this.X0 = -2;
            this.Y0 = -2;
            this.XF = e.ClipRectangle.Width - 14;
            this.YF = e.ClipRectangle.Height - 14;
            Rectangle rectangle1 = new Rectangle(this.X0, this.Y0, this.XF, this.YF);
            this.DrawArc();
            PathGradientBrush brush = new PathGradientBrush(this.path) {
                CenterColor = Color.FromArgb(0xff, 100, 100, 100)
            };
            brush.SurroundColors = new Color[] { Color.FromArgb(120, 100, 100, 100) };
            brush.FocusScales = new PointF(0.96f, 0.92f);
            graphics.FillPath(brush, this.path);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                System.Windows.Forms.CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x20;
                return createParams;
            }
        }
    }
}

