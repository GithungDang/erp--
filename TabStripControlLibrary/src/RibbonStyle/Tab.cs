namespace RibbonStyle
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.None), DesignerCategory("code")]
    public class Tab : ToolStripButton
    {
        private RibbonStyle.TabStripPage tabStripPage;
        public bool b_on;
        public bool b_selected;
        public bool b_active;
        public bool b_fading;
        public int o_opacity;
        public int e_opacity;
        public int i_opacity;
        private Timer timer;

        public Tab()
        {
            this.b_fading = true;
            this.o_opacity = 180;
            this.e_opacity = 40;
            this.timer = new Timer();
            this.Initialize();
        }

        public Tab(Image image) : base(null, image, null)
        {
            this.b_fading = true;
            this.o_opacity = 180;
            this.e_opacity = 40;
            this.timer = new Timer();
            this.Initialize();
        }

        public Tab(string text) : base(text, null, null)
        {
            this.b_fading = true;
            this.o_opacity = 180;
            this.e_opacity = 40;
            this.timer = new Timer();
            this.Initialize();
        }

        public Tab(string text, Image image) : base(text, image, null)
        {
            this.b_fading = true;
            this.o_opacity = 180;
            this.e_opacity = 40;
            this.timer = new Timer();
            this.Initialize();
        }

        public Tab(string text, Image image, EventHandler onClick) : base(text, image, onClick)
        {
            this.b_fading = true;
            this.o_opacity = 180;
            this.e_opacity = 40;
            this.timer = new Timer();
            this.Initialize();
        }

        public Tab(string text, Image image, EventHandler onClick, string name) : base(text, image, onClick, name)
        {
            this.b_fading = true;
            this.o_opacity = 180;
            this.e_opacity = 40;
            this.timer = new Timer();
            this.Initialize();
        }

        private void Initialize()
        {
            base.AutoSize = false;
            base.Width = 60;
            this.CheckOnClick = true;
            this.ForeColor = Color.FromArgb(0x2c, 90, 0x9a);
            this.Font = new Font("Segoe UI", 9f);
            base.Margin = new Padding(6, base.Margin.Top, base.Margin.Right, base.Margin.Bottom);
            this.i_opacity = this.o_opacity;
            this.timer.Interval = 1;
            this.timer.Tick += new EventHandler(this.timer_Tick);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.b_on = true;
            this.b_fading = true;
            this.b_selected = true;
            this.timer.Start();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.b_on = false;
            this.b_fading = true;
            this.timer.Start();
            base.OnMouseLeave(e);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.b_on)
            {
                if (this.i_opacity > this.e_opacity)
                {
                    this.i_opacity -= 20;
                    base.Invalidate();
                }
                else
                {
                    this.i_opacity = this.e_opacity;
                    base.Invalidate();
                    this.timer.Stop();
                }
            }
            if (!this.b_on)
            {
                if (this.i_opacity < this.o_opacity)
                {
                    this.i_opacity += 8;
                    base.Invalidate();
                }
                else
                {
                    this.i_opacity = this.o_opacity;
                    this.b_fading = false;
                    base.Invalidate();
                    this.b_selected = false;
                    this.timer.Stop();
                }
            }
        }

        [DefaultValue(true)]
        public bool CheckOnClick
        {
            get => 
                base.CheckOnClick;
            set => 
                base.CheckOnClick = value;
        }

        protected override ToolStripItemDisplayStyle DefaultDisplayStyle =>
            ToolStripItemDisplayStyle.ImageAndText;

        protected override Padding DefaultPadding =>
            new Padding(0x23, 0, 6, 0);

        [DefaultValue("null")]
        public RibbonStyle.TabStripPage TabStripPage
        {
            get => 
                this.tabStripPage;
            set => 
                this.tabStripPage = value;
        }

        public override string Text
        {
            get => 
                base.Text;
            set
            {
                base.Text = value;
                float width = Graphics.FromImage(new Bitmap(100, 100)).MeasureString(this.Text, this.Font).Width;
                base.Width = Convert.ToInt16(width) + 0x1a;
            }
        }
    }
}

