namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class HiLowBarItem : BarItem, ICloneable, ISerializable
    {
        public const int schema3 = 11;

        public HiLowBarItem(HiLowBarItem rhs) : base(rhs)
        {
            base._bar = rhs._bar.Clone();
        }

        protected HiLowBarItem(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema3");
        }

        public HiLowBarItem(string label, IPointList points, Color color) : base(label, points, color)
        {
        }

        public HiLowBarItem(string label, double[] x, double[] y, double[] baseVal, Color color) : this(label, new PointPairList(x, y, baseVal), color)
        {
        }

        public HiLowBarItem Clone() => 
            new HiLowBarItem(this);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        object ICloneable.Clone() => 
            this.Clone();
    }
}

