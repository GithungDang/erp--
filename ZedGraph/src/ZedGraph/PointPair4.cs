namespace ZedGraph
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class PointPair4 : PointPair, ISerializable
    {
        public const int schema3 = 11;
        public double T;

        public PointPair4()
        {
            this.T = 0.0;
        }

        public PointPair4(PointPair4 rhs) : base(rhs)
        {
            this.T = rhs.T;
        }

        protected PointPair4(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema3");
            this.T = info.GetDouble("T");
        }

        public PointPair4(double x, double y, double z, double t) : base(x, y, z)
        {
            this.T = t;
        }

        public PointPair4(double x, double y, double z, double t, string label) : base(x, y, z, label)
        {
            this.T = t;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 11);
            info.AddValue("T", this.T);
        }

        public string ToString(bool isShowZT) => 
            this.ToString("G", isShowZT);

        public string ToString(string format, bool isShowZT)
        {
            string[] strArray = new string[] { "( ", base.X.ToString(format), ", ", base.Y.ToString(format) };
            strArray[4] = isShowZT ? (", " + base.Z.ToString(format) + ", " + this.T.ToString(format)) : "";
            strArray[5] = " )";
            return string.Concat(strArray);
        }

        public string ToString(string formatX, string formatY, string formatZ, string formatT)
        {
            string[] strArray = new string[] { "( ", base.X.ToString(formatX), ", ", base.Y.ToString(formatY), ", ", base.Z.ToString(formatZ), ", ", this.T.ToString(formatT), " )" };
            return string.Concat(strArray);
        }

        public bool IsInvalid4D =>
            (base.X == double.MaxValue) || ((base.Y == double.MaxValue) || ((base.Z == double.MaxValue) || ((this.T == double.MaxValue) || (double.IsInfinity(base.X) || (double.IsInfinity(base.Y) || (double.IsInfinity(base.Z) || (double.IsInfinity(this.T) || (double.IsNaN(base.X) || (double.IsNaN(base.Y) || (double.IsNaN(base.Z) || double.IsNaN(this.T)))))))))));
    }
}

