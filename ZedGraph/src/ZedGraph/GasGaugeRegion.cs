namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class GasGaugeRegion : CurveItem, ICloneable, ISerializable
    {
        public const int schema2 = 10;
        private double _minValue;
        private double _maxValue;
        private Color _color;
        private float _startAngle;
        private float _sweepAngle;
        private ZedGraph.Fill _fill;
        private TextObj _labelDetail;
        private ZedGraph.Border _border;
        private RectangleF _boundingRectangle;
        private GraphicsPath _slicePath;

        public GasGaugeRegion(GasGaugeRegion ggr) : base(ggr)
        {
            this._minValue = ggr._minValue;
            this._maxValue = ggr._maxValue;
            this._color = ggr._color;
            this._startAngle = ggr._startAngle;
            this._sweepAngle = ggr._sweepAngle;
            this._border = ggr._border.Clone();
            this._labelDetail = ggr._labelDetail.Clone();
        }

        protected GasGaugeRegion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._labelDetail = (TextObj) info.GetValue("labelDetail", typeof(TextObj));
            this._fill = (ZedGraph.Fill) info.GetValue("fill", typeof(ZedGraph.Fill));
            this._border = (ZedGraph.Border) info.GetValue("border", typeof(ZedGraph.Border));
            this._color = (Color) info.GetValue("color", typeof(Color));
            this._minValue = info.GetDouble("minValue");
            this._maxValue = info.GetDouble("maxValue");
            this._startAngle = (float) info.GetDouble("startAngle");
            this._sweepAngle = (float) info.GetDouble("sweepAngle");
            this._boundingRectangle = (RectangleF) info.GetValue("boundingRectangle", typeof(RectangleF));
            this._slicePath = (GraphicsPath) info.GetValue("slicePath", typeof(GraphicsPath));
        }

        public GasGaugeRegion(string label, double minVal, double maxVal, Color color) : base(label)
        {
            this.MinValue = minVal;
            this.MaxValue = maxVal;
            this.RegionColor = color;
            this.StartAngle = 0f;
            this.SweepAngle = 0f;
            this._border = new ZedGraph.Border(Default.BorderColor, Default.BorderWidth);
            this._labelDetail = new TextObj();
            this._labelDetail.FontSpec.Size = Default.FontSize;
            this._slicePath = null;
        }

        public static unsafe RectangleF CalcRectangle(Graphics g, GraphPane pane, float scaleFactor, RectangleF chartRect)
        {
            RectangleF ef = chartRect;
            if ((2f * ef.Height) <= ef.Width)
            {
                ef.Height *= 2f;
            }
            else
            {
                float num = ((ef.Height * 2f) - ef.Width) / (ef.Height * 2f);
                ef.Height = (ef.Height * 2f) - ((ef.Height * 2f) * num);
            }
            ef.Width = ef.Height;
            float num2 = (chartRect.Width / 2f) - (ef.Width / 2f);
            RectangleF* efPtr1 = &ef;
            efPtr1.X += num2;
            ef.Inflate(-0.05f * ef.Height, -0.05f * ef.Width);
            CalculateGasGuageParameters(pane);
            foreach (CurveItem item in pane.CurveList)
            {
                if (item is GasGaugeRegion)
                {
                    ((GasGaugeRegion) item)._boundingRectangle = ef;
                }
            }
            return ef;
        }

        public static void CalculateGasGuageParameters(GraphPane pane)
        {
            double maxValue = double.MaxValue;
            double minValue = double.MinValue;
            foreach (CurveItem item in pane.CurveList)
            {
                if (item is GasGaugeRegion)
                {
                    GasGaugeRegion region = (GasGaugeRegion) item;
                    if (minValue < region.MaxValue)
                    {
                        minValue = region.MaxValue;
                    }
                    if (maxValue > region.MinValue)
                    {
                        maxValue = region.MinValue;
                    }
                }
            }
            foreach (CurveItem item2 in pane.CurveList)
            {
                if (item2 is GasGaugeRegion)
                {
                    GasGaugeRegion region2 = (GasGaugeRegion) item2;
                    float num3 = ((((float) region2.MinValue) - ((float) maxValue)) / (((float) minValue) - ((float) maxValue))) * 180f;
                    float num4 = (((((float) region2.MaxValue) - ((float) maxValue)) / (((float) minValue) - ((float) maxValue))) * 180f) - num3;
                    region2.Fill = new ZedGraph.Fill(Color.White, region2.RegionColor, -(num4 / 2f));
                    region2.StartAngle = num3;
                    region2.SweepAngle = num4;
                }
            }
        }

        public GasGaugeRegion Clone() => 
            new GasGaugeRegion(this);

        public override void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor)
        {
            if ((pane.Chart._rect.Width <= 0f) && (pane.Chart._rect.Height <= 0f))
            {
                this._slicePath = null;
            }
            else
            {
                CalcRectangle(g, pane, scaleFactor, pane.Chart._rect);
                this._slicePath = new GraphicsPath();
                if (base._isVisible)
                {
                    RectangleF ef = this._boundingRectangle;
                    if ((ef.Width >= 1f) && (ef.Height >= 1f))
                    {
                        SmoothingMode smoothingMode = g.SmoothingMode;
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        this._slicePath.AddPie(ef.X, ef.Y, ef.Width, ef.Height, 0f, -180f);
                        g.FillPie(this.Fill.MakeBrush(this._boundingRectangle), ef.X, ef.Y, ef.Width, ef.Height, -this.StartAngle, -this.SweepAngle);
                        if (this.Border.IsVisible)
                        {
                            Pen pen = this._border.GetPen(pane, scaleFactor);
                            g.DrawPie(pen, ef.X, ef.Y, ef.Width, ef.Height, 0f, -180f);
                            pen.Dispose();
                        }
                        g.SmoothingMode = smoothingMode;
                    }
                }
            }
        }

        public override void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
        {
            if (base._isVisible)
            {
                if (this._fill.IsVisible)
                {
                    using (Brush brush = this._fill.MakeBrush(rect))
                    {
                        g.FillRectangle(brush, rect);
                    }
                }
                if (!this._border.Color.IsEmpty)
                {
                    this._border.Draw(g, pane, scaleFactor, rect);
                }
            }
        }

        public override bool GetCoords(GraphPane pane, int i, out string coords)
        {
            coords = string.Empty;
            return false;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
            info.AddValue("labelDetail", this._labelDetail);
            info.AddValue("fill", this._fill);
            info.AddValue("color", this._color);
            info.AddValue("border", this._border);
            info.AddValue("minVal", this._minValue);
            info.AddValue("maxVal", this._maxValue);
            info.AddValue("startAngle", this._startAngle);
            info.AddValue("sweepAngle", this._sweepAngle);
            info.AddValue("boundingRectangle", this._boundingRectangle);
            info.AddValue("slicePath", this._slicePath);
        }

        internal override bool IsXIndependent(GraphPane pane) => 
            true;

        internal override bool IsZIncluded(GraphPane pane) => 
            false;

        object ICloneable.Clone() => 
            this.Clone();

        public GraphicsPath SlicePath =>
            this._slicePath;

        public TextObj LabelDetail
        {
            get => 
                this._labelDetail;
            set => 
                this._labelDetail = value;
        }

        public ZedGraph.Border Border
        {
            get => 
                this._border;
            set => 
                this._border = value;
        }

        public Color RegionColor
        {
            get => 
                this._color;
            set
            {
                this._color = value;
                this.Fill = new ZedGraph.Fill(this._color);
            }
        }

        public ZedGraph.Fill Fill
        {
            get => 
                this._fill;
            set => 
                this._fill = value;
        }

        private float SweepAngle
        {
            get => 
                this._sweepAngle;
            set => 
                this._sweepAngle = value;
        }

        private float StartAngle
        {
            get => 
                this._startAngle;
            set => 
                this._startAngle = value;
        }

        public double MinValue
        {
            get => 
                this._minValue;
            set => 
                this._minValue = (value > 0.0) ? value : 0.0;
        }

        public double MaxValue
        {
            get => 
                this._maxValue;
            set => 
                this._maxValue = (value > 0.0) ? value : 0.0;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float BorderWidth;
            public static ZedGraph.FillType FillType;
            public static bool IsBorderVisible;
            public static Color BorderColor;
            public static Color FillColor;
            public static Brush FillBrush;
            public static bool isVisible;
            public static float FontSize;
            static Default()
            {
                BorderWidth = 1f;
                FillType = ZedGraph.FillType.Brush;
                IsBorderVisible = true;
                BorderColor = Color.Gray;
                FillColor = Color.Empty;
                FillBrush = null;
                isVisible = true;
                FontSize = 10f;
            }
        }
    }
}

