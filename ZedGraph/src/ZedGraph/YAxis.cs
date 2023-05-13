namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class YAxis : Axis, ICloneable, ISerializable
    {
        public const int schema2 = 10;

        public YAxis() : this("Y Axis")
        {
        }

        public YAxis(string title) : base(title)
        {
            base._isVisible = Default.IsVisible;
            base._majorGrid._isZeroLine = Default.IsZeroLine;
            base._scale._fontSpec.Angle = 90f;
            base._title._fontSpec.Angle = -180f;
        }

        public YAxis(YAxis rhs) : base(rhs)
        {
        }

        protected YAxis(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
        }

        internal override float CalcCrossShift(GraphPane pane)
        {
            double x = base.EffectiveCrossValue(pane);
            return (base._crossAuto ? 0f : (pane.XAxis.Scale._minPix - pane.XAxis.Scale.Transform(x)));
        }

        public YAxis Clone() => 
            new YAxis(this);

        public override Axis GetCrossAxis(GraphPane pane) => 
            pane.XAxis;

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
        }

        internal override bool IsPrimary(GraphPane pane) => 
            ReferenceEquals(this, pane.YAxis);

        public override void SetTransformMatrix(Graphics g, GraphPane pane, float scaleFactor)
        {
            g.TranslateTransform(pane.Chart._rect.Left, pane.Chart._rect.Top);
            g.RotateTransform(90f);
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
                IsZeroLine = true;
            }
        }
    }
}

