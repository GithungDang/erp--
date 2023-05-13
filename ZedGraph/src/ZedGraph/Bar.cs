namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class Bar : ICloneable, ISerializable
    {
        public const int schema = 10;
        private ZedGraph.Fill _fill;
        private ZedGraph.Border _border;

        public Bar() : this(Color.Empty)
        {
        }

        public Bar(Color color)
        {
            this._border = new ZedGraph.Border(Default.IsBorderVisible, Default.BorderColor, Default.BorderWidth);
            this._fill = new ZedGraph.Fill(color.IsEmpty ? Default.FillColor : color, Default.FillBrush, Default.FillType);
        }

        public Bar(Bar rhs)
        {
            this._border = rhs.Border.Clone();
            this._fill = rhs.Fill.Clone();
        }

        protected Bar(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._fill = (ZedGraph.Fill) info.GetValue("fill", typeof(ZedGraph.Fill));
            this._border = (ZedGraph.Border) info.GetValue("border", typeof(ZedGraph.Border));
        }

        public Bar Clone() => 
            new Bar(this);

        public void Draw(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor, bool fullFrame, bool isSelected, PointPair dataValue)
        {
            if (isSelected)
            {
                Selection.Fill.Draw(g, rect, dataValue);
                Selection.Border.Draw(g, pane, scaleFactor, rect);
            }
            else
            {
                this._fill.Draw(g, rect, dataValue);
                this._border.Draw(g, pane, scaleFactor, rect);
            }
        }

        public void Draw(Graphics g, GraphPane pane, float left, float right, float top, float bottom, float scaleFactor, bool fullFrame, bool isSelected, PointPair dataValue)
        {
            if (top > bottom)
            {
                float num = top;
                top = bottom;
                bottom = num;
            }
            if (left > right)
            {
                float num2 = right;
                right = left;
                left = num2;
            }
            if (top < -10000f)
            {
                top = -10000f;
            }
            else if (top > 10000f)
            {
                top = 10000f;
            }
            if (left < -10000f)
            {
                left = -10000f;
            }
            else if (left > 10000f)
            {
                left = 10000f;
            }
            if (right < -10000f)
            {
                right = -10000f;
            }
            else if (right > 10000f)
            {
                right = 10000f;
            }
            if (bottom < -10000f)
            {
                bottom = -10000f;
            }
            else if (bottom > 10000f)
            {
                bottom = 10000f;
            }
            RectangleF rect = new RectangleF(left, top, right - left, bottom - top);
            this.Draw(g, pane, rect, scaleFactor, fullFrame, isSelected, dataValue);
        }

        public void DrawBars(Graphics g, GraphPane pane, CurveItem curve, Axis baseAxis, Axis valueAxis, float barWidth, int pos, float scaleFactor)
        {
            BarType type = pane._barSettings.Type;
            if ((type == BarType.Overlay) || ((type == BarType.Stack) || ((type == BarType.PercentStack) || (type == BarType.SortedOverlay))))
            {
                pos = 0;
            }
            for (int i = 0; i < curve.Points.Count; i++)
            {
                this.DrawSingleBar(g, pane, curve, i, pos, baseAxis, valueAxis, barWidth, scaleFactor);
            }
        }

        protected virtual void DrawSingleBar(Graphics g, GraphPane pane, CurveItem curve, int index, int pos, Axis baseAxis, Axis valueAxis, float barWidth, float scaleFactor)
        {
            double num7;
            double num8;
            double num9;
            float clusterWidth = pane.BarSettings.GetClusterWidth();
            float num5 = pane._barSettings.MinClusterGap * barWidth;
            float num6 = barWidth * pane._barSettings.MinBarGap;
            new ValueHandler(pane, false).GetValues(curve, index, out num7, out num8, out num9);
            if (!curve.Points[index].IsInvalid)
            {
                float top = valueAxis.Scale.Transform(curve.IsOverrideOrdinal, index, num8);
                float bottom = valueAxis.Scale.Transform(curve.IsOverrideOrdinal, index, num9);
                float left = ((baseAxis.Scale.Transform(curve.IsOverrideOrdinal, index, num7) - (clusterWidth / 2f)) + (num5 / 2f)) + (pos * (barWidth + num6));
                if (pane._barSettings.Base == BarBase.X)
                {
                    this.Draw(g, pane, left, left + barWidth, top, bottom, scaleFactor, true, curve.IsSelected, curve.Points[index]);
                }
                else
                {
                    this.Draw(g, pane, top, bottom, left, left + barWidth, scaleFactor, true, curve.IsSelected, curve.Points[index]);
                }
            }
        }

        public void DrawSingleBar(Graphics g, GraphPane pane, CurveItem curve, Axis baseAxis, Axis valueAxis, int pos, int index, float barWidth, float scaleFactor)
        {
            if (index < curve.Points.Count)
            {
                if ((pane._barSettings.Type == BarType.Overlay) || ((pane._barSettings.Type == BarType.Stack) || (pane._barSettings.Type == BarType.PercentStack)))
                {
                    pos = 0;
                }
                this.DrawSingleBar(g, pane, curve, index, pos, baseAxis, valueAxis, barWidth, scaleFactor);
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("fill", this._fill);
            info.AddValue("border", this._border);
        }

        object ICloneable.Clone() => 
            this.Clone();

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

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float BorderWidth;
            public static ZedGraph.FillType FillType;
            public static bool IsBorderVisible;
            public static Color BorderColor;
            public static Color FillColor;
            public static Brush FillBrush;
            static Default()
            {
                BorderWidth = 1f;
                FillType = ZedGraph.FillType.Brush;
                IsBorderVisible = true;
                BorderColor = Color.Black;
                FillColor = Color.Red;
                FillBrush = null;
            }
        }
    }
}

