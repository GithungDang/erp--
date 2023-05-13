namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class ErrorBarItem : CurveItem, ICloneable, ISerializable
    {
        public const int schema2 = 10;
        private ErrorBar _bar;

        public ErrorBarItem(string label) : base(label)
        {
            this._bar = new ErrorBar();
        }

        public ErrorBarItem(ErrorBarItem rhs) : base(rhs)
        {
            this._bar = new ErrorBar(rhs.Bar);
        }

        protected ErrorBarItem(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._bar = (ErrorBar) info.GetValue("bar", typeof(ErrorBar));
            BarBase base1 = (BarBase) info.GetValue("barBase", typeof(BarBase));
        }

        public ErrorBarItem(string label, IPointList points, Color color) : base(label, points)
        {
            this._bar = new ErrorBar(color);
        }

        public ErrorBarItem(string label, double[] x, double[] y, double[] lowValue, Color color) : this(label, new PointPairList(x, y, lowValue), color)
        {
        }

        public ErrorBarItem Clone() => 
            new ErrorBarItem(this);

        public override void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor)
        {
            if (base._isVisible)
            {
                this._bar.Draw(g, pane, this, this.BaseAxis(pane), this.ValueAxis(pane), scaleFactor);
            }
        }

        public override void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
        {
            float num;
            float top;
            float bottom;
            if (pane._barSettings.Base == BarBase.X)
            {
                num = rect.Left + (rect.Width / 2f);
                top = rect.Top;
                bottom = rect.Bottom;
            }
            else
            {
                num = rect.Top + (rect.Height / 2f);
                top = rect.Right;
                bottom = rect.Left;
            }
            using (Pen pen = new Pen(this._bar.Color, this._bar.PenWidth))
            {
                this.Bar.Draw(g, pane, pane._barSettings.Base == BarBase.X, num, top, bottom, scaleFactor, pen, false, null);
            }
        }

        public override bool GetCoords(GraphPane pane, int i, out string coords)
        {
            double num6;
            double num7;
            double num8;
            coords = string.Empty;
            if ((i < 0) || (i >= base._points.Count))
            {
                return false;
            }
            Axis axis = this.ValueAxis(pane);
            Axis axis2 = this.BaseAxis(pane);
            float num = this._bar.Symbol.Size * pane.CalcScaleFactor();
            pane.BarSettings.GetClusterWidth();
            float barWidth = base.GetBarWidth(pane);
            float minClusterGap = pane._barSettings.MinClusterGap;
            float minBarGap = pane._barSettings.MinBarGap;
            new ValueHandler(pane, false).GetValues(this, i, out num6, out num7, out num8);
            if (base._points[i].IsInvalid3D)
            {
                return false;
            }
            float num4 = axis.Scale.Transform(base._isOverrideOrdinal, i, num7);
            float num3 = axis.Scale.Transform(base._isOverrideOrdinal, i, num8);
            float num9 = axis2.Scale.Transform(base._isOverrideOrdinal, i, num6) - (num / 2f);
            if ((axis2 is XAxis) || (axis2 is X2Axis))
            {
                coords = $"{num9:f0},{num4:f0},{num9 + num:f0},{num3:f0}";
            }
            else
            {
                coords = $"{num4:f0},{num9:f0},{num3:f0},{num9 + num:f0}";
            }
            return true;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
            info.AddValue("bar", this._bar);
            info.AddValue("barBase", BarBase.X);
        }

        internal override bool IsXIndependent(GraphPane pane) => 
            pane._barSettings.Base == BarBase.X;

        internal override bool IsZIncluded(GraphPane pane) => 
            true;

        object ICloneable.Clone() => 
            this.Clone();

        public ErrorBar Bar =>
            this._bar;
    }
}

