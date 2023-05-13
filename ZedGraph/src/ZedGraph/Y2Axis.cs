namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class Y2Axis : Axis, ICloneable, ISerializable
    {
        public const int schema2 = 10;

        public Y2Axis() : this("Y2 Axis")
        {
        }

        public Y2Axis(string title) : base(title)
        {
            base._isVisible = Default.IsVisible;
            base._majorGrid._isZeroLine = Default.IsZeroLine;
            base._scale._fontSpec.Angle = -90f;
        }

        public Y2Axis(Y2Axis rhs) : base(rhs)
        {
        }

        protected Y2Axis(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
        }

        internal override float CalcCrossShift(GraphPane pane)
        {
            double x = base.EffectiveCrossValue(pane);
            return (base._crossAuto ? 0f : (pane.XAxis.Scale.Transform(x) - pane.XAxis.Scale._maxPix));
        }

        public Y2Axis Clone() => 
            new Y2Axis(this);

        public override Axis GetCrossAxis(GraphPane pane) => 
            pane.XAxis;

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
        }

        internal override bool IsPrimary(GraphPane pane) => 
            ReferenceEquals(this, pane.Y2Axis);

        public override void SetTransformMatrix(Graphics g, GraphPane pane, float scaleFactor)
        {
            g.TranslateTransform(pane.Chart._rect.Right, pane.Chart._rect.Bottom);
            g.RotateTransform(-90f);
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
                IsVisible = false;
                IsZeroLine = true;
            }
        }
    }
}

