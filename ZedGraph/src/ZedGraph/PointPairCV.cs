namespace ZedGraph
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    public class PointPairCV : PointPair
    {
        public const int schema3 = 11;
        private double _colorValue;

        protected PointPairCV(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema3");
            this.ColorValue = info.GetDouble("ColorValue");
        }

        public PointPairCV(double x, double y, double z) : base(x, y, z, (string) null)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema3", 11);
            info.AddValue("ColorValue", this.ColorValue);
        }

        public override double ColorValue
        {
            get => 
                this._colorValue;
            set => 
                this._colorValue = value;
        }
    }
}

