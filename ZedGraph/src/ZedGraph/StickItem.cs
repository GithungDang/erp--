namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class StickItem : LineItem, ICloneable, ISerializable
    {
        public const int schema3 = 10;

        public StickItem(string label) : base(label)
        {
            base._symbol.IsVisible = false;
        }

        public StickItem(StickItem rhs) : base(rhs)
        {
        }

        protected StickItem(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema3");
        }

        public StickItem(string label, IPointList points, Color color) : this(label, points, color, LineBase.Default.Width)
        {
        }

        public StickItem(string label, double[] x, double[] y, Color color) : this(label, new PointPairList(x, y), color)
        {
        }

        public StickItem(string label, IPointList points, Color color, float lineWidth) : base(label, points, color, Symbol.Default.Type, lineWidth)
        {
            base._symbol.IsVisible = false;
        }

        public StickItem(string label, double[] x, double[] y, Color color, float lineWidth) : this(label, new PointPairList(x, y), color, lineWidth)
        {
        }

        public StickItem Clone() => 
            new StickItem(this);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema3", 10);
        }

        internal override bool IsXIndependent(GraphPane pane) => 
            true;

        internal override bool IsZIncluded(GraphPane pane) => 
            base._symbol.IsVisible;

        object ICloneable.Clone() => 
            this.Clone();
    }
}

