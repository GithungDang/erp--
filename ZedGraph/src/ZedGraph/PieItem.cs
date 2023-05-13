namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class PieItem : CurveItem, ICloneable, ISerializable
    {
        public const int schema2 = 10;
        private double _displacement;
        private TextObj _labelDetail;
        private ZedGraph.Fill _fill;
        private ZedGraph.Border _border;
        private double _pieValue;
        private PieLabelType _labelType;
        private PointF _intersectionPoint;
        private RectangleF _boundingRectangle;
        private string _labelStr;
        private PointF _pivotPoint;
        private PointF _endPoint;
        private GraphicsPath _slicePath;
        private float _startAngle;
        private float _sweepAngle;
        private float _midAngle;
        private int _valueDecimalDigits;
        private int _percentDecimalDigits;
        private static ColorSymbolRotator _rotator = new ColorSymbolRotator();

        public PieItem(PieItem rhs) : base(rhs)
        {
            this._pieValue = rhs._pieValue;
            this._fill = rhs._fill.Clone();
            this.Border = rhs._border.Clone();
            this._displacement = rhs._displacement;
            this._labelDetail = rhs._labelDetail.Clone();
            this._labelType = rhs._labelType;
            this._valueDecimalDigits = rhs._valueDecimalDigits;
            this._percentDecimalDigits = rhs._percentDecimalDigits;
        }

        public PieItem(double pieValue, string label) : this(pieValue, _rotator.NextColor, Default.Displacement, label)
        {
        }

        protected PieItem(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._displacement = info.GetDouble("displacement");
            this._labelDetail = (TextObj) info.GetValue("labelDetail", typeof(TextObj));
            this._fill = (ZedGraph.Fill) info.GetValue("fill", typeof(ZedGraph.Fill));
            this._border = (ZedGraph.Border) info.GetValue("border", typeof(ZedGraph.Border));
            this._pieValue = info.GetDouble("pieValue");
            this._labelType = (PieLabelType) info.GetValue("labelType", typeof(PieLabelType));
            this._intersectionPoint = (PointF) info.GetValue("intersectionPoint", typeof(PointF));
            this._boundingRectangle = (RectangleF) info.GetValue("boundingRectangle", typeof(RectangleF));
            this._pivotPoint = (PointF) info.GetValue("pivotPoint", typeof(PointF));
            this._endPoint = (PointF) info.GetValue("endPoint", typeof(PointF));
            this._startAngle = (float) info.GetDouble("startAngle");
            this._sweepAngle = (float) info.GetDouble("sweepAngle");
            this._midAngle = (float) info.GetDouble("midAngle");
            this._labelStr = info.GetString("labelStr");
            this._valueDecimalDigits = info.GetInt32("valueDecimalDigits");
            this._percentDecimalDigits = info.GetInt32("percentDecimalDigits");
        }

        public PieItem(double pieValue, Color color, double displacement, string label) : base(label)
        {
            this._pieValue = pieValue;
            this._fill = new ZedGraph.Fill(color.IsEmpty ? _rotator.NextColor : color);
            this._displacement = displacement;
            this._border = new ZedGraph.Border(Default.BorderColor, Default.BorderWidth);
            this._labelDetail = new TextObj();
            this._labelDetail.FontSpec.Size = Default.FontSize;
            this._labelType = Default.LabelType;
            this._valueDecimalDigits = Default.ValueDecimalDigits;
            this._percentDecimalDigits = Default.PercentDecimalDigits;
            this._slicePath = null;
        }

        public PieItem(double pieValue, Color color1, Color color2, float fillAngle, double displacement, string label) : this(pieValue, color1, displacement, label)
        {
            if (!color1.IsEmpty && !color2.IsEmpty)
            {
                this._fill = new ZedGraph.Fill(color1, color2, fillAngle);
            }
        }

        private static void BuildLabelString(PieItem curve)
        {
            NumberFormatInfo provider = (NumberFormatInfo) NumberFormatInfo.CurrentInfo.Clone();
            provider.NumberDecimalDigits = curve._valueDecimalDigits;
            provider.PercentPositivePattern = 1;
            provider.PercentDecimalDigits = curve._percentDecimalDigits;
            switch (curve._labelType)
            {
                case PieLabelType.Name_Value:
                    curve._labelStr = curve._label._text + ": " + curve._pieValue.ToString("F", provider);
                    return;

                case PieLabelType.Name_Percent:
                    curve._labelStr = curve._label._text + ": " + (curve._sweepAngle / 360f).ToString("P", provider);
                    return;

                case PieLabelType.Name_Value_Percent:
                {
                    string[] strArray = new string[] { curve._label._text, ": ", curve._pieValue.ToString("F", provider), " (", (curve._sweepAngle / 360f).ToString("P", provider), ")" };
                    curve._labelStr = string.Concat(strArray);
                    return;
                }
                case PieLabelType.Value:
                    curve._labelStr = curve._pieValue.ToString("F", provider);
                    return;

                case PieLabelType.Percent:
                    curve._labelStr = (curve._sweepAngle / 360f).ToString("P", provider);
                    return;

                case PieLabelType.Name:
                    curve._labelStr = curve._label._text;
                    break;

                case PieLabelType.None:
                    break;

                default:
                    return;
            }
        }

        private void CalcExplodedRect(ref RectangleF explRect)
        {
            explRect.X += (float) (((this.Displacement * explRect.Width) / 2.0) * Math.Cos((this._midAngle * 3.1415926535897931) / 180.0));
            explRect.Y += (float) (((this.Displacement * explRect.Height) / 2.0) * Math.Sin((this._midAngle * 3.1415926535897931) / 180.0));
        }

        private static void CalcNewBaseRect(double maxDisplacement, ref RectangleF baseRect)
        {
            float num = (float) (maxDisplacement * baseRect.Width);
            float height = baseRect.Height;
            baseRect.Inflate(-(num / 10f), -(num / 10f));
        }

        public static unsafe RectangleF CalcPieRect(Graphics g, GraphPane pane, float scaleFactor, RectangleF chartRect)
        {
            double maxDisplacement = 0.0;
            RectangleF baseRect = chartRect;
            if (pane.CurveList.IsPieOnly)
            {
                if (baseRect.Width < baseRect.Height)
                {
                    baseRect.Inflate(-0.05f * baseRect.Height, -0.05f * baseRect.Width);
                    float num2 = (baseRect.Height - baseRect.Width) / 2f;
                    baseRect.Height = baseRect.Width;
                    RectangleF* efPtr1 = &baseRect;
                    efPtr1.Y += num2;
                }
                else
                {
                    baseRect.Inflate(-0.05f * baseRect.Height, -0.05f * baseRect.Width);
                    float num3 = (baseRect.Width - baseRect.Height) / 2f;
                    baseRect.Width = baseRect.Height;
                    RectangleF* efPtr2 = &baseRect;
                    efPtr2.X += num3;
                }
                double num4 = chartRect.Width / chartRect.Height;
                if (num4 < 1.5)
                {
                    baseRect.Inflate(-((float) ((0.1 * (1.5 / num4)) * baseRect.Width)), -((float) ((0.1 * (1.5 / num4)) * baseRect.Width)));
                }
                CalculatePieChartParams(pane, ref maxDisplacement);
                if (maxDisplacement != 0.0)
                {
                    CalcNewBaseRect(maxDisplacement, ref baseRect);
                }
                foreach (PieItem item in pane.CurveList)
                {
                    item._boundingRectangle = baseRect;
                    if (item.Displacement != 0.0)
                    {
                        RectangleF explRect = baseRect;
                        item.CalcExplodedRect(ref explRect);
                        item._boundingRectangle = explRect;
                    }
                    item.DesignLabel(g, pane, item._boundingRectangle, scaleFactor);
                }
            }
            return baseRect;
        }

        private void CalculateLinePoints(RectangleF rect, double midAngle)
        {
            PointF tf = new PointF(rect.X + (rect.Width / 2f), rect.Y + (rect.Height / 2f));
            this._intersectionPoint = new PointF(tf.X + ((float) ((rect.Width / 2f) * Math.Cos((midAngle * 3.1415926535897931) / 180.0))), tf.Y + ((float) ((rect.Height / 2f) * Math.Sin((midAngle * 3.1415926535897931) / 180.0))));
            this._pivotPoint = new PointF(this._intersectionPoint.X + ((float) ((0.05 * rect.Width) * Math.Cos((midAngle * 3.1415926535897931) / 180.0))), this._intersectionPoint.Y + ((float) ((0.05 * rect.Width) * Math.Sin((midAngle * 3.1415926535897931) / 180.0))));
            if (this._pivotPoint.X >= tf.X)
            {
                this._endPoint = new PointF(this._pivotPoint.X + ((float) (0.05 * rect.Width)), this._pivotPoint.Y);
                this._labelDetail.Location.AlignH = AlignH.Left;
            }
            else
            {
                this._endPoint = new PointF(this._pivotPoint.X - ((float) (0.05 * rect.Width)), this._pivotPoint.Y);
                this._labelDetail.Location.AlignH = AlignH.Right;
            }
            this._midAngle = (float) midAngle;
        }

        private static void CalculatePieChartParams(GraphPane pane, ref double maxDisplacement)
        {
            double num = 0.0;
            foreach (PieItem item in pane.CurveList)
            {
                if (item.IsPie)
                {
                    num += item._pieValue;
                    if (item.Displacement > maxDisplacement)
                    {
                        maxDisplacement = item.Displacement;
                    }
                }
            }
            double num2 = 0.0;
            foreach (PieItem item2 in pane.CurveList)
            {
                string text1 = item2._labelStr;
                item2.StartAngle = (float) num2;
                item2.SweepAngle = (float) ((360.0 * item2.Value) / num);
                item2.MidAngle = item2.StartAngle + (item2.SweepAngle / 2f);
                num2 = item2._startAngle + item2._sweepAngle;
                BuildLabelString(item2);
            }
        }

        public PieItem Clone() => 
            new PieItem(this);

        public void DesignLabel(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
        {
            if (this._labelDetail.IsVisible)
            {
                SizeF ef3 = new SizeF();
                this._labelDetail.LayoutArea = ef3;
                this.CalculateLinePoints(rect, (double) this._midAngle);
                SizeF ef = this._labelDetail.FontSpec.BoundingBox(g, this._labelStr, scaleFactor);
                RectangleF ef2 = pane.Chart._rect;
                float width = 0f;
                if ((this._midAngle > 315f) || (this._midAngle <= 45f))
                {
                    width = ((ef2.X + ef2.Width) - this._endPoint.X) - 5f;
                    if (ef.Width > width)
                    {
                        this._labelDetail.LayoutArea = new SizeF(width, ef.Height * 3f);
                    }
                }
                if ((this._midAngle > 45f) && (this._midAngle <= 135f))
                {
                    width = ((ef2.Y + ef2.Height) - this._endPoint.Y) - 5f;
                    if ((ef.Height / 2f) > width)
                    {
                        if (this._midAngle > 90f)
                        {
                            this.CalculateLinePoints(rect, (double) (this._midAngle + (((this._sweepAngle + this._startAngle) - this._midAngle) / 3f)));
                        }
                        else
                        {
                            this.CalculateLinePoints(rect, (double) (this._midAngle - (this._midAngle - ((this._midAngle - this._startAngle) / 3f))));
                        }
                    }
                }
                if ((this._midAngle > 135f) && (this._midAngle <= 225f))
                {
                    width = (this._endPoint.X - ef2.X) - 5f;
                    if (ef.Width > width)
                    {
                        this._labelDetail.LayoutArea = new SizeF(width, ef.Height * 3f);
                    }
                }
                if ((this._midAngle > 225f) && (this._midAngle <= 315f))
                {
                    width = (this._endPoint.Y - 5f) - ef2.Y;
                    if ((ef.Height / 2f) > width)
                    {
                        if (this._midAngle < 270f)
                        {
                            this.CalculateLinePoints(rect, (double) (this._midAngle - (((this._sweepAngle + this._startAngle) - this._midAngle) / 3f)));
                        }
                        else
                        {
                            this.CalculateLinePoints(rect, (double) (this._midAngle + ((this._midAngle - this._startAngle) / 3f)));
                        }
                    }
                }
                this._labelDetail.Location.AlignV = AlignV.Center;
                this._labelDetail.Location.CoordinateFrame = CoordType.PaneFraction;
                this._labelDetail.Location.X = (this._endPoint.X - pane.Rect.X) / pane.Rect.Width;
                this._labelDetail.Location.Y = (this._endPoint.Y - pane.Rect.Y) / pane.Rect.Height;
                this._labelDetail.Text = this._labelStr;
            }
        }

        public override void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor)
        {
            if ((pane.Chart._rect.Width <= 0f) && (pane.Chart._rect.Height <= 0f))
            {
                this._slicePath = null;
            }
            else
            {
                CalcPieRect(g, pane, scaleFactor, pane.Chart._rect);
                this._slicePath = new GraphicsPath();
                if (base._isVisible)
                {
                    RectangleF rect = this._boundingRectangle;
                    if ((rect.Width >= 1f) && (rect.Height >= 1f))
                    {
                        SmoothingMode smoothingMode = g.SmoothingMode;
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        ZedGraph.Fill fill = this._fill;
                        ZedGraph.Border border = this._border;
                        if (base.IsSelected)
                        {
                            fill = Selection.Fill;
                            border = Selection.Border;
                        }
                        using (Brush brush = fill.MakeBrush(this._boundingRectangle))
                        {
                            g.FillPie(brush, rect.X, rect.Y, rect.Width, rect.Height, this.StartAngle, this.SweepAngle);
                            this._slicePath.AddPie(rect.X, rect.Y, rect.Width, rect.Height, this.StartAngle, this.SweepAngle);
                            if (this.Border.IsVisible)
                            {
                                using (Pen pen = border.GetPen(pane, scaleFactor))
                                {
                                    g.DrawPie(pen, rect.X, rect.Y, rect.Width, rect.Height, this.StartAngle, this.SweepAngle);
                                }
                            }
                            if (this._labelType != PieLabelType.None)
                            {
                                this.DrawLabel(g, pane, rect, scaleFactor);
                            }
                        }
                        g.SmoothingMode = smoothingMode;
                    }
                }
            }
        }

        public void DrawLabel(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
        {
            if (this._labelDetail.IsVisible)
            {
                using (Pen pen = this.Border.GetPen(pane, scaleFactor))
                {
                    g.DrawLine(pen, this._intersectionPoint, this._pivotPoint);
                    g.DrawLine(pen, this._pivotPoint, this._endPoint);
                }
                this._labelDetail.Draw(g, pane, scaleFactor);
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

        public override unsafe bool GetCoords(GraphPane pane, int i, out string coords)
        {
            coords = string.Empty;
            PointF location = this._boundingRectangle.Location;
            PointF* tfPtr1 = &location;
            tfPtr1.X += this._boundingRectangle.Width / 2f;
            PointF* tfPtr2 = &location;
            tfPtr2.Y += this._boundingRectangle.Height / 2f;
            float x = this._boundingRectangle.Width / 2f;
            Matrix matrix = new Matrix();
            matrix.Translate(location.X, location.Y);
            matrix.Rotate(this.StartAngle);
            int num2 = ((int) Math.Floor((double) (this.SweepAngle / 5f))) + 1;
            PointF[] pts = new PointF[2 + num2];
            pts[0] = new PointF(0f, 0f);
            pts[1] = new PointF(x, 0f);
            double num3 = 0.0;
            for (int j = 2; j < (num2 + 2); j++)
            {
                num3 += this.SweepAngle / ((float) num2);
                pts[j] = new PointF(x * ((float) Math.Cos((num3 * 3.1415926535897931) / 180.0)), x * ((float) Math.Sin((num3 * 3.1415926535897931) / 180.0)));
            }
            matrix.TransformPoints(pts);
            coords = $"{pts[0].X:f0},{pts[0].Y:f0},{pts[1].X:f0},{pts[1].Y:f0},";
            for (int k = 2; k < (num2 + 2); k++)
            {
                coords = coords + string.Format((k > num2) ? "{0:f0},{1:f0}" : "{0:f0},{1:f0},", pts[k].X, pts[k].Y);
            }
            return true;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
            info.AddValue("displacement", this._displacement);
            info.AddValue("labelDetail", this._labelDetail);
            info.AddValue("fill", this._fill);
            info.AddValue("border", this._border);
            info.AddValue("pieValue", this._pieValue);
            info.AddValue("labelType", this._labelType);
            info.AddValue("intersectionPoint", this._intersectionPoint);
            info.AddValue("boundingRectangle", this._boundingRectangle);
            info.AddValue("pivotPoint", this._pivotPoint);
            info.AddValue("endPoint", this._endPoint);
            info.AddValue("startAngle", this._startAngle);
            info.AddValue("sweepAngle", this._sweepAngle);
            info.AddValue("midAngle", this._midAngle);
            info.AddValue("labelStr", this._labelStr);
            info.AddValue("valueDecimalDigits", this._valueDecimalDigits);
            info.AddValue("percentDecimalDigits", this._percentDecimalDigits);
        }

        internal override bool IsXIndependent(GraphPane pane) => 
            true;

        internal override bool IsZIncluded(GraphPane pane) => 
            false;

        object ICloneable.Clone() => 
            this.Clone();

        public double Displacement
        {
            get => 
                this._displacement;
            set => 
                this._displacement = (value > 0.5) ? 0.5 : value;
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

        private float MidAngle
        {
            get => 
                this._midAngle;
            set => 
                this._midAngle = value;
        }

        public double Value
        {
            get => 
                this._pieValue;
            set => 
                this._pieValue = (value > 0.0) ? value : 0.0;
        }

        public PieLabelType LabelType
        {
            get => 
                this._labelType;
            set
            {
                this._labelType = value;
                if (value == PieLabelType.None)
                {
                    this.LabelDetail.IsVisible = false;
                }
                else
                {
                    this.LabelDetail.IsVisible = true;
                }
            }
        }

        public int ValueDecimalDigits
        {
            get => 
                this._valueDecimalDigits;
            set => 
                this._valueDecimalDigits = value;
        }

        public int PercentDecimalDigits
        {
            get => 
                this._percentDecimalDigits;
            set => 
                this._percentDecimalDigits = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static double Displacement;
            public static float BorderWidth;
            public static ZedGraph.FillType FillType;
            public static bool IsBorderVisible;
            public static Color BorderColor;
            public static Color FillColor;
            public static Brush FillBrush;
            public static bool isVisible;
            public static PieLabelType LabelType;
            public static float FontSize;
            public static int ValueDecimalDigits;
            public static int PercentDecimalDigits;
            static Default()
            {
                Displacement = 0.0;
                BorderWidth = 1f;
                FillType = ZedGraph.FillType.Brush;
                IsBorderVisible = true;
                BorderColor = Color.Black;
                FillColor = Color.Red;
                FillBrush = null;
                isVisible = true;
                LabelType = PieLabelType.Name;
                FontSize = 10f;
                ValueDecimalDigits = 0;
                PercentDecimalDigits = 2;
            }
        }
    }
}

