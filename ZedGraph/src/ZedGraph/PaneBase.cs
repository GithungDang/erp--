namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.Drawing.Text;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    public abstract class PaneBase : ICloneable
    {
        public const int schema = 10;
        protected RectangleF _rect;
        protected GapLabel _title;
        protected ZedGraph.Legend _legend;
        protected object _tag;
        internal ZedGraph.Margin _margin;
        protected bool _isFontsScaled;
        protected bool _isPenWidthScaled;
        protected ZedGraph.Fill _fill;
        protected ZedGraph.Border _border;
        protected ZedGraph.GraphObjList _graphObjList;
        protected float _baseDimension;
        protected float _titleGap;

        public PaneBase() : this("", new RectangleF(0f, 0f, 0f, 0f))
        {
        }

        public PaneBase(PaneBase rhs)
        {
            this._isFontsScaled = rhs._isFontsScaled;
            this._isPenWidthScaled = rhs._isPenWidthScaled;
            this._titleGap = rhs._titleGap;
            this._baseDimension = rhs._baseDimension;
            this._margin = rhs._margin.Clone();
            this._rect = rhs._rect;
            this._fill = rhs._fill.Clone();
            this._border = rhs._border.Clone();
            this._title = rhs._title.Clone();
            this._legend = rhs.Legend.Clone();
            this._title = rhs._title.Clone();
            this._graphObjList = rhs._graphObjList.Clone();
            if (rhs._tag is ICloneable)
            {
                this._tag = ((ICloneable) rhs._tag).Clone();
            }
            else
            {
                this._tag = rhs._tag;
            }
        }

        protected PaneBase(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._rect = (RectangleF) info.GetValue("rect", typeof(RectangleF));
            this._legend = (ZedGraph.Legend) info.GetValue("legend", typeof(ZedGraph.Legend));
            this._title = (GapLabel) info.GetValue("title", typeof(GapLabel));
            this._isFontsScaled = info.GetBoolean("isFontsScaled");
            this._isPenWidthScaled = info.GetBoolean("isPenWidthScaled");
            this._titleGap = info.GetSingle("titleGap");
            this._fill = (ZedGraph.Fill) info.GetValue("fill", typeof(ZedGraph.Fill));
            this._border = (ZedGraph.Border) info.GetValue("border", typeof(ZedGraph.Border));
            this._baseDimension = info.GetSingle("baseDimension");
            this._margin = (ZedGraph.Margin) info.GetValue("margin", typeof(ZedGraph.Margin));
            this._graphObjList = (ZedGraph.GraphObjList) info.GetValue("graphObjList", typeof(ZedGraph.GraphObjList));
            this._tag = info.GetValue("tag", typeof(object));
        }

        public PaneBase(string title, RectangleF paneRect)
        {
            this._rect = paneRect;
            this._legend = new ZedGraph.Legend();
            this._baseDimension = Default.BaseDimension;
            this._margin = new ZedGraph.Margin();
            this._titleGap = Default.TitleGap;
            this._isFontsScaled = Default.IsFontsScaled;
            this._isPenWidthScaled = Default.IsPenWidthScaled;
            this._fill = new ZedGraph.Fill(Default.FillColor);
            this._border = new ZedGraph.Border(Default.IsBorderVisible, Default.BorderColor, Default.BorderPenWidth);
            this._title = new GapLabel(title, Default.FontFamily, Default.FontSize, Default.FontColor, Default.FontBold, Default.FontItalic, Default.FontUnderline);
            this._title._fontSpec.Fill.IsVisible = false;
            this._title._fontSpec.Border.IsVisible = false;
            this._graphObjList = new ZedGraph.GraphObjList();
            this._tag = null;
        }

        public unsafe RectangleF CalcClientRect(Graphics g, float scaleFactor)
        {
            float height = this._title._fontSpec.GetHeight(scaleFactor);
            RectangleF ef = new RectangleF(this._rect.Left + (this._margin.Left * scaleFactor), this._rect.Top + (this._margin.Top * scaleFactor), this._rect.Width - (scaleFactor * (this._margin.Left + this._margin.Right)), this._rect.Height - (scaleFactor * (this._margin.Top + this._margin.Bottom)));
            if (this._title._isVisible && (this._title._text != string.Empty))
            {
                SizeF ef2 = this._title._fontSpec.BoundingBox(g, this._title._text, scaleFactor);
                RectangleF* efPtr1 = &ef;
                efPtr1.Y += ef2.Height + (height * this._titleGap);
                RectangleF* efPtr2 = &ef;
                efPtr2.Height -= ef2.Height + (height * this._titleGap);
            }
            return ef;
        }

        public float CalcScaleFactor()
        {
            if (!this._isFontsScaled)
            {
                return 1f;
            }
            if (this._rect.Height <= 0f)
            {
                return 1f;
            }
            float width = this._rect.Width;
            float num3 = this._rect.Width / this._rect.Height;
            if (num3 > 1.5f)
            {
                width = this._rect.Height * 1.5f;
            }
            if (num3 < 0.6666667f)
            {
                width = this._rect.Width * 1.5f;
            }
            float num = width / (this._baseDimension * 72f);
            if (num < 0.1f)
            {
                num = 0.1f;
            }
            return num;
        }

        public virtual void Draw(Graphics g)
        {
            if ((this._rect.Width > 1f) && (this._rect.Height > 1f))
            {
                float scaleFactor = this.CalcScaleFactor();
                this.DrawPaneFrame(g, scaleFactor);
                g.SetClip(this._rect);
                this._graphObjList.Draw(g, this, scaleFactor, ZOrder.H_BehindAll);
                this.DrawTitle(g, scaleFactor);
                g.ResetClip();
            }
        }

        public void DrawPaneFrame(Graphics g, float scaleFactor)
        {
            this._fill.Draw(g, this._rect);
            RectangleF rect = new RectangleF(this._rect.X, this._rect.Y, this._rect.Width - 1f, this._rect.Height - 1f);
            this._border.Draw(g, this, scaleFactor, rect);
        }

        public void DrawTitle(Graphics g, float scaleFactor)
        {
            if (this._title._isVisible)
            {
                SizeF ef = this._title._fontSpec.BoundingBox(g, this._title._text, scaleFactor);
                this._title._fontSpec.Draw(g, this, this._title._text, (this._rect.Left + this._rect.Right) / 2f, (this._rect.Top + (this._margin.Top * scaleFactor)) + (ef.Height / 2f), AlignH.Center, AlignV.Center, scaleFactor);
            }
        }

        public Bitmap GetImage() => 
            this.GetImage(false);

        public Bitmap GetImage(bool isAntiAlias)
        {
            Bitmap image = new Bitmap((int) this._rect.Width, (int) this._rect.Height);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.TranslateTransform(-this._rect.Left, -this._rect.Top);
                this.Draw(graphics);
            }
            return image;
        }

        public Bitmap GetImage(int width, int height, float dpi) => 
            this.GetImage(width, height, dpi, false);

        public Bitmap GetImage(int width, int height, float dpi, bool isAntiAlias)
        {
            Bitmap image = new Bitmap(width, height);
            image.SetResolution(dpi, dpi);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                this.MakeImage(graphics, width, height, isAntiAlias);
            }
            return image;
        }

        public Metafile GetMetafile()
        {
            Metafile metafile2;
            using (Graphics graphics = Graphics.FromImage(new Bitmap(1, 1)))
            {
                IntPtr hdc = graphics.GetHdc();
                Metafile image = new Metafile(new MemoryStream(), hdc, this._rect, MetafileFrameUnit.Pixel, EmfType.EmfOnly);
                using (Graphics graphics2 = Graphics.FromImage(image))
                {
                    graphics2.TranslateTransform(-this._rect.Left, -this._rect.Top);
                    graphics2.PageUnit = GraphicsUnit.Pixel;
                    PointF tf = new PointF(this._rect.Width, this._rect.Height);
                    PointF[] pts = new PointF[] { tf };
                    graphics2.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, pts);
                    this.Draw(graphics2);
                    graphics.ReleaseHdc(hdc);
                    metafile2 = image;
                }
            }
            return metafile2;
        }

        public Metafile GetMetafile(int width, int height) => 
            this.GetMetafile(width, height, false);

        public Metafile GetMetafile(int width, int height, bool isAntiAlias)
        {
            Metafile metafile2;
            using (Graphics graphics = Graphics.FromImage(new Bitmap(1, 1)))
            {
                IntPtr hdc = graphics.GetHdc();
                Metafile image = new Metafile(new MemoryStream(), hdc, this._rect, MetafileFrameUnit.Pixel, EmfType.EmfPlusDual);
                graphics.ReleaseHdc(hdc);
                using (Graphics graphics2 = Graphics.FromImage(image))
                {
                    graphics2.PageUnit = GraphicsUnit.Pixel;
                    PointF tf = new PointF((float) width, (float) height);
                    PointF[] pts = new PointF[] { tf };
                    graphics2.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, pts);
                    this.MakeImage(graphics2, width, height, isAntiAlias);
                    metafile2 = image;
                }
            }
            return metafile2;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("rect", this._rect);
            info.AddValue("legend", this._legend);
            info.AddValue("title", this._title);
            info.AddValue("isFontsScaled", this._isFontsScaled);
            info.AddValue("isPenWidthScaled", this._isPenWidthScaled);
            info.AddValue("titleGap", this._titleGap);
            info.AddValue("fill", this._fill);
            info.AddValue("border", this._border);
            info.AddValue("baseDimension", this._baseDimension);
            info.AddValue("margin", this._margin);
            info.AddValue("graphObjList", this._graphObjList);
            info.AddValue("tag", this._tag);
        }

        private void MakeImage(Graphics g, int width, int height, bool antiAlias)
        {
            this.SetAntiAliasMode(g, antiAlias);
            PaneBase base2 = this.ShallowClone();
            base2.ReSize(g, new RectangleF(0f, 0f, (float) width, (float) height));
            base2.Draw(g);
            using (Graphics graphics = Graphics.FromImage(new Bitmap(1, 1)))
            {
                this.ReSize(graphics, this.Rect);
                this.SetAntiAliasMode(graphics, antiAlias);
                this.Draw(graphics);
            }
        }

        public virtual void ReSize(Graphics g, RectangleF rect)
        {
            this._rect = rect;
        }

        public float ScaledPenWidth(float penWidth, float scaleFactor) => 
            !this._isPenWidthScaled ? penWidth : (penWidth * scaleFactor);

        internal void SetAntiAliasMode(Graphics g, bool isAntiAlias)
        {
            if (isAntiAlias)
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            }
        }

        public PaneBase ShallowClone() => 
            base.MemberwiseClone() as PaneBase;

        object ICloneable.Clone()
        {
            throw new NotImplementedException("Can't clone an abstract base type -- child types must implement ICloneable");
        }

        internal PointF TransformCoord(double x, double y, CoordType coord)
        {
            if (!(this is GraphPane) && (coord != CoordType.PaneFraction))
            {
                coord = CoordType.PaneFraction;
                x = 0.5;
                y = 0.5;
            }
            GraphPane pane = null;
            RectangleF ef = new RectangleF(0f, 0f, 1f, 1f);
            if (this is GraphPane)
            {
                pane = this as GraphPane;
                ef = pane.Chart._rect;
            }
            PointF tf = new PointF();
            if (coord == CoordType.ChartFraction)
            {
                tf.X = ef.Left + ((float) (x * ef.Width));
                tf.Y = ef.Top + ((float) (y * ef.Height));
            }
            else if (coord == CoordType.AxisXYScale)
            {
                tf.X = pane.XAxis.Scale.Transform(x);
                tf.Y = pane.YAxis.Scale.Transform(y);
            }
            else if (coord == CoordType.AxisXY2Scale)
            {
                tf.X = pane.XAxis.Scale.Transform(x);
                tf.Y = pane.Y2Axis.Scale.Transform(y);
            }
            else if (coord == CoordType.XScaleYChartFraction)
            {
                tf.X = pane.XAxis.Scale.Transform(x);
                tf.Y = ef.Top + ((float) (y * ef.Height));
            }
            else if (coord == CoordType.XChartFractionYScale)
            {
                tf.X = ef.Left + ((float) (x * ef.Width));
                tf.Y = pane.YAxis.Scale.Transform(y);
            }
            else if (coord == CoordType.XChartFractionY2Scale)
            {
                tf.X = ef.Left + ((float) (x * ef.Width));
                tf.Y = pane.Y2Axis.Scale.Transform(y);
            }
            else if (coord == CoordType.XChartFractionYPaneFraction)
            {
                tf.X = ef.Left + ((float) (x * ef.Width));
                tf.Y = this.Rect.Top + ((float) (y * this._rect.Height));
            }
            else if (coord == CoordType.XPaneFractionYChartFraction)
            {
                tf.X = this.Rect.Left + ((float) (x * this._rect.Width));
                tf.Y = ef.Top + ((float) (y * ef.Height));
            }
            else
            {
                tf.X = this._rect.Left + ((float) (x * this._rect.Width));
                tf.Y = this._rect.Top + ((float) (y * this._rect.Height));
            }
            return tf;
        }

        public RectangleF Rect
        {
            get => 
                this._rect;
            set => 
                this._rect = value;
        }

        public ZedGraph.Legend Legend =>
            this._legend;

        public Label Title =>
            this._title;

        public object Tag
        {
            get => 
                this._tag;
            set => 
                this._tag = value;
        }

        public ZedGraph.Border Border
        {
            get => 
                this._border;
            set => 
                this._border = value;
        }

        public ZedGraph.Fill Fill
        {
            get => 
                this._fill;
            set => 
                this._fill = value;
        }

        public ZedGraph.GraphObjList GraphObjList
        {
            get => 
                this._graphObjList;
            set => 
                this._graphObjList = value;
        }

        public ZedGraph.Margin Margin
        {
            get => 
                this._margin;
            set => 
                this._margin = value;
        }

        public float BaseDimension
        {
            get => 
                this._baseDimension;
            set => 
                this._baseDimension = value;
        }

        public float TitleGap
        {
            get => 
                this._titleGap;
            set => 
                this._titleGap = value;
        }

        public bool IsFontsScaled
        {
            get => 
                this._isFontsScaled;
            set => 
                this._isFontsScaled = value;
        }

        public bool IsPenWidthScaled
        {
            get => 
                this._isPenWidthScaled;
            set => 
                this._isPenWidthScaled = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static bool IsShowTitle;
            public static string FontFamily;
            public static float FontSize;
            public static Color FontColor;
            public static bool FontBold;
            public static bool FontItalic;
            public static bool FontUnderline;
            public static bool IsBorderVisible;
            public static Color BorderColor;
            public static Color FillColor;
            public static float BorderPenWidth;
            public static float BaseDimension;
            public static bool IsPenWidthScaled;
            public static bool IsFontsScaled;
            public static float TitleGap;
            static Default()
            {
                IsShowTitle = true;
                FontFamily = "Arial";
                FontSize = 16f;
                FontColor = Color.Black;
                FontBold = true;
                FontItalic = false;
                FontUnderline = false;
                IsBorderVisible = true;
                BorderColor = Color.Black;
                FillColor = Color.White;
                BorderPenWidth = 1f;
                BaseDimension = 8f;
                IsPenWidthScaled = false;
                IsFontsScaled = true;
                TitleGap = 0.5f;
            }
        }
    }
}

