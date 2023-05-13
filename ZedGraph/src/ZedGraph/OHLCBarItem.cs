namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class OHLCBarItem : CurveItem, ICloneable, ISerializable
    {
        public const int schema2 = 10;
        protected OHLCBar _bar;

        public OHLCBarItem(string label) : base(label)
        {
            this._bar = new OHLCBar();
        }

        public OHLCBarItem(OHLCBarItem rhs) : base(rhs)
        {
            this._bar = rhs._bar.Clone();
        }

        protected OHLCBarItem(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._bar = (OHLCBar) info.GetValue("stick", typeof(OHLCBar));
        }

        public OHLCBarItem(string label, IPointList points, Color color) : base(label, points)
        {
            this._bar = new OHLCBar(color);
        }

        public OHLCBarItem Clone() => 
            new OHLCBarItem(this);

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
            float num4;
            float num5;
            if (pane._barSettings.Base == BarBase.X)
            {
                num = rect.Left + (rect.Width / 2f);
                top = rect.Top;
                bottom = rect.Bottom;
                num4 = top + (rect.Height / 4f);
                num5 = bottom - (rect.Height / 4f);
            }
            else
            {
                num = rect.Top + (rect.Height / 2f);
                top = rect.Right;
                bottom = rect.Left;
                num4 = top - (rect.Width / 4f);
                num5 = bottom + (rect.Width / 4f);
            }
            float halfSize = 2f * scaleFactor;
            using (Pen pen = new Pen(this._bar.Color, this._bar._width))
            {
                this._bar.Draw(g, pane, pane._barSettings.Base == BarBase.X, num, top, bottom, num4, num5, halfSize, pen);
            }
        }

        public override bool GetCoords(GraphPane pane, int i, out string coords)
        {
            coords = string.Empty;
            if ((i < 0) || (i >= base._points.Count))
            {
                return false;
            }
            Axis axis = this.ValueAxis(pane);
            Axis axis2 = this.BaseAxis(pane);
            float num = this._bar.Size * pane.CalcScaleFactor();
            PointPair pair = base._points[i];
            double x = pair.X;
            double y = pair.Y;
            double z = pair.Z;
            if ((pair.IsInvalid3D || ((x <= 0.0) && axis2._scale.IsLog)) || (((y <= 0.0) || (z <= 0.0)) && axis._scale.IsLog))
            {
                return false;
            }
            float num6 = axis.Scale.Transform(base._isOverrideOrdinal, i, y);
            float num7 = axis.Scale.Transform(base._isOverrideOrdinal, i, z);
            float num8 = axis2.Scale.Transform(base._isOverrideOrdinal, i, x) - num;
            if ((axis2 is XAxis) || (axis2 is X2Axis))
            {
                coords = $"{num8:f0},{num7:f0},{num8 + (num * 2f):f0},{num6:f0}";
            }
            else
            {
                coords = $"{num7:f0},{num8:f0},{num6:f0},{num8 + (num * 2f):f0}";
            }
            return true;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
            info.AddValue("stick", this._bar);
        }

        internal override bool IsXIndependent(GraphPane pane) => 
            pane._barSettings.Base == BarBase.X;

        internal override bool IsZIncluded(GraphPane pane) => 
            true;

        object ICloneable.Clone() => 
            this.Clone();

        public OHLCBar Bar =>
            this._bar;
    }
}

