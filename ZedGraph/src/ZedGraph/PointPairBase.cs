namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class PointPairBase : ISerializable
    {
        public const double Missing = double.MaxValue;
        public const string DefaultFormat = "G";
        public const int schema = 11;
        public double X;
        public double Y;

        public PointPairBase() : this((double) 0.0, (double) 0.0)
        {
        }

        public PointPairBase(PointF pt) : this((double) pt.X, (double) pt.Y)
        {
        }

        public PointPairBase(PointPairBase rhs)
        {
            this.X = rhs.X;
            this.Y = rhs.Y;
        }

        public PointPairBase(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        protected PointPairBase(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this.X = info.GetDouble("X");
            this.Y = info.GetDouble("Y");
        }

        public override bool Equals(object obj)
        {
            PointPairBase base2 = obj as PointPairBase;
            return ((this.X == base2.X) && (this.Y == base2.Y));
        }

        public override int GetHashCode() => 
            base.GetHashCode();

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 11);
            info.AddValue("X", this.X);
            info.AddValue("Y", this.Y);
        }

        public static bool IsValueInvalid(double value) => 
            (value == double.MaxValue) || (double.IsInfinity(value) || double.IsNaN(value));

        public static implicit operator PointF(PointPairBase pair) => 
            new PointF((float) pair.X, (float) pair.Y);

        public override string ToString() => 
            this.ToString("G");

        public string ToString(string format)
        {
            string[] strArray = new string[] { "( ", this.X.ToString(format), ", ", this.Y.ToString(format), " )" };
            return string.Concat(strArray);
        }

        public string ToString(string formatX, string formatY)
        {
            string[] strArray = new string[] { "( ", this.X.ToString(formatX), ", ", this.Y.ToString(formatY), " )" };
            return string.Concat(strArray);
        }

        public bool IsMissing =>
            (this.X == double.MaxValue) || (this.Y == double.MaxValue);

        public bool IsInvalid =>
            (this.X == double.MaxValue) || ((this.Y == double.MaxValue) || (double.IsInfinity(this.X) || (double.IsInfinity(this.Y) || (double.IsNaN(this.X) || double.IsNaN(this.Y)))));
    }
}

