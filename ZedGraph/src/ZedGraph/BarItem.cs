namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class BarItem : CurveItem, ICloneable, ISerializable
    {
        public const int schema2 = 10;
        protected ZedGraph.Bar _bar;

        public BarItem(string label) : base(label)
        {
            this._bar = new ZedGraph.Bar();
        }

        public BarItem(BarItem rhs) : base(rhs)
        {
            this._bar = rhs._bar.Clone();
        }

        protected BarItem(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._bar = (ZedGraph.Bar) info.GetValue("bar", typeof(ZedGraph.Bar));
        }

        public BarItem(string label, IPointList points, Color color) : base(label, points)
        {
            this._bar = new ZedGraph.Bar(color);
        }

        public BarItem(string label, double[] x, double[] y, Color color) : this(label, new PointPairList(x, y), color)
        {
        }

        public BarItem Clone() => 
            new BarItem(this);

        public static void CreateBarLabels(GraphPane pane, bool isBarCenter, string valueFormat)
        {
            CreateBarLabels(pane, isBarCenter, valueFormat, TextObj.Default.FontFamily, TextObj.Default.FontSize, TextObj.Default.FontColor, TextObj.Default.FontBold, TextObj.Default.FontItalic, TextObj.Default.FontUnderline);
        }

        public static void CreateBarLabels(GraphPane pane, bool isBarCenter, string valueFormat, string fontFamily, float fontSize, Color fontColor, bool isBold, bool isItalic, bool isUnderline)
        {
            bool flag = pane.BarSettings.Base == BarBase.X;
            int iOrdinal = 0;
            ValueHandler handler = new ValueHandler(pane, true);
            foreach (CurveItem item in pane.CurveList)
            {
                BarItem curve = item as BarItem;
                if (curve != null)
                {
                    IPointList points = item.Points;
                    Scale scale = item.ValueAxis(pane).Scale;
                    float num2 = ((float) (scale._max - scale._min)) * 0.015f;
                    int iPt = 0;
                    while (true)
                    {
                        double num4;
                        double num5;
                        double num6;
                        if (iPt >= points.Count)
                        {
                            iOrdinal++;
                            break;
                        }
                        handler.GetValues(item, iPt, out num4, out num5, out num6);
                        float num7 = (float) handler.BarCenterValue(curve, curve.GetBarWidth(pane), iPt, num4, iOrdinal);
                        string text = (flag ? points[iPt].Y : points[iPt].X).ToString(valueFormat);
                        float num8 = !isBarCenter ? ((num6 < 0.0) ? (((float) num6) - num2) : (((float) num6) + num2)) : (((float) (num6 + num5)) / 2f);
                        TextObj obj2 = !flag ? new TextObj(text, (double) num8, (double) num7) : new TextObj(text, (double) num7, (double) num8);
                        obj2.FontSpec.Family = fontFamily;
                        obj2.Location.CoordinateFrame = (!flag || !item.IsY2Axis) ? CoordType.AxisXYScale : CoordType.AxisXY2Scale;
                        obj2.FontSpec.Size = fontSize;
                        obj2.FontSpec.FontColor = fontColor;
                        obj2.FontSpec.IsItalic = isItalic;
                        obj2.FontSpec.IsBold = isBold;
                        obj2.FontSpec.IsUnderline = isUnderline;
                        obj2.FontSpec.Angle = flag ? ((float) 90) : ((float) 0);
                        obj2.Location.AlignH = isBarCenter ? AlignH.Center : ((num6 >= 0.0) ? AlignH.Left : AlignH.Right);
                        obj2.Location.AlignV = AlignV.Center;
                        obj2.FontSpec.Border.IsVisible = false;
                        obj2.FontSpec.Fill.IsVisible = false;
                        pane.GraphObjList.Add(obj2);
                        iPt++;
                    }
                }
            }
        }

        public override void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor)
        {
            if (base._isVisible)
            {
                this._bar.DrawBars(g, pane, this, this.BaseAxis(pane), this.ValueAxis(pane), base.GetBarWidth(pane), pos, scaleFactor);
            }
        }

        public override void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
        {
            this._bar.Draw(g, pane, rect, scaleFactor, true, false, null);
        }

        public override bool GetCoords(GraphPane pane, int i, out string coords)
        {
            double num8;
            double num9;
            double num10;
            coords = string.Empty;
            if ((i < 0) || (i >= base._points.Count))
            {
                return false;
            }
            Axis axis = this.ValueAxis(pane);
            Axis axis2 = this.BaseAxis(pane);
            float clusterWidth = pane.BarSettings.GetClusterWidth();
            float barWidth = base.GetBarWidth(pane);
            float num6 = pane._barSettings.MinClusterGap * barWidth;
            float num7 = barWidth * pane._barSettings.MinBarGap;
            new ValueHandler(pane, false).GetValues(this, i, out num8, out num9, out num10);
            if (base._points[i].IsInvalid3D)
            {
                return false;
            }
            float num3 = axis.Scale.Transform(base._isOverrideOrdinal, i, num9);
            float num2 = axis.Scale.Transform(base._isOverrideOrdinal, i, num10);
            float num11 = ((axis2.Scale.Transform(base._isOverrideOrdinal, i, num8) - (clusterWidth / 2f)) + (num6 / 2f)) + (pane.CurveList.GetBarItemPos(pane, this) * (barWidth + num7));
            if ((axis2 is XAxis) || (axis2 is X2Axis))
            {
                coords = $"{num11:f0},{num3:f0},{num11 + barWidth:f0},{num2:f0}";
            }
            else
            {
                coords = $"{num3:f0},{num11:f0},{num2:f0},{num11 + barWidth:f0}";
            }
            return true;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
            info.AddValue("bar", this._bar);
        }

        internal override bool IsXIndependent(GraphPane pane) => 
            (pane._barSettings.Base == BarBase.X) || (pane._barSettings.Base == BarBase.X2);

        internal override bool IsZIncluded(GraphPane pane) => 
            this is HiLowBarItem;

        object ICloneable.Clone() => 
            this.Clone();

        public ZedGraph.Bar Bar =>
            this._bar;
    }
}

