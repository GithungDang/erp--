namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class XAxis : Axis, ICloneable, ISerializable
    {
        public const int schema2 = 10;

        public XAxis() : this("X Axis")
        {
        }

        public XAxis(string title) : base(title)
        {
            base._isVisible = Default.IsVisible;
            base._majorGrid._isZeroLine = Default.IsZeroLine;
            base._scale._fontSpec.Angle = 0f;
        }

        public XAxis(XAxis rhs) : base(rhs)
        {
        }

        protected XAxis(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
        }

        internal override float CalcCrossShift(GraphPane pane)
        {
            double x = base.EffectiveCrossValue(pane);
            return (base._crossAuto ? 0f : (pane.YAxis.Scale.Transform(x) - pane.YAxis.Scale._maxPix));
        }

        public XAxis Clone() => 
            new XAxis(this);

        public override Axis GetCrossAxis(GraphPane pane) => 
            pane.YAxis;

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
        }

        internal override bool IsPrimary(GraphPane pane) => 
            ReferenceEquals(this, pane.XAxis);

        public override void SetTransformMatrix(Graphics g, GraphPane pane, float scaleFactor)
        {
            g.TranslateTransform(pane.Chart._rect.Left, pane.Chart._rect.Bottom);
        }

        object ICloneable.Clone() => 
            this.Clone();

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static bool IsVisible;
            public static bool IsZeroLine;
            static Default()
            {
                IsVisible = true;
                IsZeroLine = false;
            }
        }
    }
}

