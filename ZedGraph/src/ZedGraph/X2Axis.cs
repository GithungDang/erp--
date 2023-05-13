namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class X2Axis : Axis, ICloneable, ISerializable
    {
        public const int schema2 = 11;

        public X2Axis() : this("X2 Axis")
        {
        }

        public X2Axis(string title) : base(title)
        {
            base._isVisible = Default.IsVisible;
            base._majorGrid._isZeroLine = Default.IsZeroLine;
            base._scale._fontSpec.Angle = 180f;
            base._title._fontSpec.Angle = 180f;
        }

        public X2Axis(X2Axis rhs) : base(rhs)
        {
        }

        protected X2Axis(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
        }

        internal override float CalcCrossShift(GraphPane pane)
        {
            double x = base.EffectiveCrossValue(pane);
            return (base._crossAuto ? 0f : (pane.YAxis.Scale.Transform(x) - pane.YAxis.Scale._maxPix));
        }

        public X2Axis Clone() => 
            new X2Axis(this);

        public override Axis GetCrossAxis(GraphPane pane) => 
            pane.YAxis;

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 11);
        }

        internal override bool IsPrimary(GraphPane pane) => 
            ReferenceEquals(this, pane.X2Axis);

        public override void SetTransformMatrix(Graphics g, GraphPane pane, float scaleFactor)
        {
            g.TranslateTransform(pane.Chart._rect.Right, pane.Chart._rect.Top);
            g.RotateTransform(180f);
        }

        object ICloneable.Clone() => 
            this.Clone();

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static bool IsVisible;
            public static bool IsZeroLine;
        }
    }
}

