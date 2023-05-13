namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class GasGaugeNeedle : CurveItem, ICloneable, ISerializable
    {
        public const int schema2 = 10;
        private double _needleValue;
        private float _needleWidth;
        private Color _color;
        private float _sweepAngle;
        private ZedGraph.Fill _fill;
        private TextObj _labelDetail;
        private ZedGraph.Border _border;
        private RectangleF _boundingRectangle;
        private GraphicsPath _slicePath;

        public GasGaugeNeedle(GasGaugeNeedle ggn) : base(ggn)
        {
            this.NeedleValue = ggn.NeedleValue;
            this.NeedleColor = ggn.NeedleColor;
            this.NeedleWidth = ggn.NeedleWidth;
            this.SweepAngle = ggn.SweepAngle;
            this._border = ggn.Border.Clone();
            this._labelDetail = ggn.LabelDetail.Clone();
            this._labelDetail.FontSpec.Size = ggn.LabelDetail.FontSpec.Size;
        }

        protected GasGaugeNeedle(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._labelDetail = (TextObj) info.GetValue("labelDetail", typeof(TextObj));
            this._fill = (ZedGraph.Fill) info.GetValue("fill", typeof(ZedGraph.Fill));
            this._border = (ZedGraph.Border) info.GetValue("border", typeof(ZedGraph.Border));
            this._needleValue = info.GetDouble("needleValue");
            this._boundingRectangle = (RectangleF) info.GetValue("boundingRectangle", typeof(RectangleF));
            this._slicePath = (GraphicsPath) info.GetValue("slicePath", typeof(GraphicsPath));
            this._sweepAngle = (float) info.GetDouble("sweepAngle");
            this._color = (Color) info.GetValue("color", typeof(Color));
        }

        public GasGaugeNeedle(string label, double val, Color color) : base(label)
        {
            this.NeedleValue = val;
            this.NeedleColor = color;
            this.NeedleWidth = Default.NeedleWidth;
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
            CalculateGasGaugeParameters(pane);
            foreach (CurveItem item in pane.CurveList)
            {
                if (item is GasGaugeNeedle)
                {
                    ((GasGaugeNeedle) item)._boundingRectangle = ef;
                }
            }
            return ef;
        }

        public static void CalculateGasGaugeParameters(GraphPane pane)
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
                if (item2 is GasGaugeNeedle)
                {
                    GasGaugeNeedle needle = (GasGaugeNeedle) item2;
                    needle.SweepAngle = ((((float) needle.NeedleValue) - ((float) maxValue)) / (((float) minValue) - ((float) maxValue))) * 180f;
                }
            }
        }

        public GasGaugeNeedle Clone() => 
            new GasGaugeNeedle(this);

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
                        Matrix matrix = new Matrix();
                        matrix.Translate(ef.X + (ef.Width / 2f), ef.Y + (ef.Height / 2f), MatrixOrder.Prepend);
                        PointF[] pts = new PointF[] { new PointF(((ef.Height * 0.1f) / 2f) * ((float) Math.Cos((-this.SweepAngle * 3.1415926535897931) / 180.0)), ((ef.Height * 0.1f) / 2f) * ((float) Math.Sin((-this.SweepAngle * 3.1415926535897931) / 180.0))), new PointF((ef.Width / 2f) * ((float) Math.Cos((-this.SweepAngle * 3.1415926535897931) / 180.0)), (ef.Width / 2f) * ((float) Math.Sin((-this.SweepAngle * 3.1415926535897931) / 180.0))) };
                        matrix.TransformPoints(pts);
                        Pen pen = new Pen(this.NeedleColor, (ef.Height * 0.1f) / 2f) {
                            EndCap = LineCap.ArrowAnchor
                        };
                        g.DrawLine(pen, pts[0].X, pts[0].Y, pts[1].X, pts[1].Y);
                        ZedGraph.Fill fill = new ZedGraph.Fill(Color.Black);
                        RectangleF rect = new RectangleF((ef.X + (ef.Width / 2f)) - 1f, (ef.Y + (ef.Height / 2f)) - 1f, 1f, 1f);
                        rect.Inflate(ef.Height * 0.1f, ef.Height * 0.1f);
                        Brush brush = fill.MakeBrush(rect);
                        g.FillPie(brush, rect.X, rect.Y, rect.Width, rect.Height, 0f, -180f);
                        Pen pen2 = new Pen(Color.White, 2f);
                        g.DrawPie(pen2, rect.X, rect.Y, rect.Width, rect.Height, 0f, -180f);
                        g.SmoothingMode = smoothingMode;
                    }
                }
            }
        }

        public override void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
        {
            if (base._isVisible)
            {
                float num = rect.Top + (rect.Height / 2f);
                Pen pen = new Pen(this.NeedleColor, pane.ScaledPenWidth(this.NeedleWidth / 2f, scaleFactor)) {
                    StartCap = LineCap.Round,
                    EndCap = LineCap.ArrowAnchor,
                    DashStyle = DashStyle.Solid
                };
                g.DrawLine(pen, rect.Left, num, rect.Right, num);
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
            info.AddValue("border", this._border);
            info.AddValue("needleValue", this._needleValue);
            info.AddValue("boundingRectangle", this._boundingRectangle);
            info.AddValue("slicePath", this._slicePath);
            info.AddValue("sweepAngle", this._sweepAngle);
        }

        internal override bool IsXIndependent(GraphPane pane) => 
            true;

        internal override bool IsZIncluded(GraphPane pane) => 
            false;

        object ICloneable.Clone() => 
            this.Clone();

        public float NeedleWidth
        {
            get => 
                this._needleWidth;
            set => 
                this._needleWidth = value;
        }

        public ZedGraph.Border Border
        {
            get => 
                this._border;
            set => 
                this._border = value;
        }

        public GraphicsPath SlicePath =>
            this._slicePath;

        public TextObj LabelDetail
        {
            get => 
                this._labelDetail;
            set => 
                this._labelDetail = value;
        }

        public Color NeedleColor
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

        public double NeedleValue
        {
            get => 
                this._needleValue;
            set => 
                this._needleValue = (value > 0.0) ? value : 0.0;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float NeedleWidth;
            public static float BorderWidth;
            public static bool IsBorderVisible;
            public static Color BorderColor;
            public static ZedGraph.FillType FillType;
            public static Color FillColor;
            public static Brush FillBrush;
            public static bool isVisible;
            public static float FontSize;
            static Default()
            {
                NeedleWidth = 10f;
                BorderWidth = 1f;
                IsBorderVisible = true;
                BorderColor = Color.Gray;
                FillType = ZedGraph.FillType.Brush;
                FillColor = Color.Empty;
                FillBrush = null;
                isVisible = true;
                FontSize = 10f;
            }
        }
    }
}

