namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class PointPair : PointPairBase, ISerializable, ICloneable
    {
        public const int schema2 = 11;
        public double Z;
        public object Tag;

        public PointPair() : this(0.0, 0.0, 0.0, (string) null)
        {
        }

        public PointPair(PointF pt) : this((double) pt.X, (double) pt.Y, 0.0, (string) null)
        {
        }

        public PointPair(PointPair rhs) : base(rhs)
        {
            this.Z = rhs.Z;
            if (rhs.Tag is ICloneable)
            {
                this.Tag = ((ICloneable) rhs.Tag).Clone();
            }
            else
            {
                this.Tag = rhs.Tag;
            }
        }

        public PointPair(double x, double y) : this(x, y, 0.0, (string) null)
        {
        }

        protected PointPair(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this.Z = info.GetDouble("Z");
            this.Tag = info.GetValue("Tag", typeof(object));
        }

        public PointPair(double x, double y, double z) : this(x, y, z, (string) null)
        {
        }

        public PointPair(double x, double y, string label) : this(x, y, 0.0, label)
        {
        }

        public PointPair(double x, double y, double z, object tag) : base(x, y)
        {
            this.Z = z;
            this.Tag = tag;
        }

        public PointPair(double x, double y, double z, string label) : this(x, y, z, label)
        {
        }

        public PointPair Clone() => 
            new PointPair(this);

        public override bool Equals(object obj)
        {
            PointPair pair = obj as PointPair;
            return ((base.X == pair.X) && ((base.Y == pair.Y) && (this.Z == pair.Z)));
        }

        public override int GetHashCode() => 
            base.GetHashCode();

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 11);
            info.AddValue("Z", this.Z);
            info.AddValue("Tag", this.Tag);
        }

        object ICloneable.Clone() => 
            this.Clone();

        public virtual string ToString(bool isShowZ) => 
            this.ToString("G", isShowZ);

        public virtual string ToString(string format, bool isShowZ)
        {
            string[] strArray = new string[] { "( ", base.X.ToString(format), ", ", base.Y.ToString(format) };
            strArray[4] = isShowZ ? (", " + this.Z.ToString(format)) : "";
            strArray[5] = " )";
            return string.Concat(strArray);
        }

        public string ToString(string formatX, string formatY, string formatZ)
        {
            string[] strArray = new string[] { "( ", base.X.ToString(formatX), ", ", base.Y.ToString(formatY), ", ", this.Z.ToString(formatZ), " )" };
            return string.Concat(strArray);
        }

        public bool IsInvalid3D =>
            (base.X == double.MaxValue) || ((base.Y == double.MaxValue) || ((this.Z == double.MaxValue) || (double.IsInfinity(base.X) || (double.IsInfinity(base.Y) || (double.IsInfinity(this.Z) || (double.IsNaN(base.X) || (double.IsNaN(base.Y) || double.IsNaN(this.Z))))))));

        public double LowValue
        {
            get => 
                this.Z;
            set => 
                this.Z = value;
        }

        public virtual double ColorValue
        {
            get => 
                this.Z;
            set => 
                this.Z = value;
        }

        public class PointPairComparer : IComparer<PointPair>
        {
            private SortType sortType;

            public PointPairComparer(SortType type)
            {
                this.sortType = type;
            }

            public int Compare(PointPair l, PointPair r)
            {
                double x;
                double y;
                if ((l == null) && (r == null))
                {
                    return 0;
                }
                if ((l == null) && (r != null))
                {
                    return -1;
                }
                if ((l != null) && (r == null))
                {
                    return 1;
                }
                if (this.sortType == SortType.XValues)
                {
                    x = l.X;
                    y = r.X;
                }
                else
                {
                    x = l.Y;
                    y = r.Y;
                }
                if ((x == double.MaxValue) || (double.IsInfinity(x) || double.IsNaN(x)))
                {
                    l = null;
                }
                if ((y == double.MaxValue) || (double.IsInfinity(y) || double.IsNaN(y)))
                {
                    r = null;
                }
                if (((l == null) && (r == null)) || (Math.Abs((double) (x - y)) < 1E-100))
                {
                    return 0;
                }
                return (((l != null) || (r == null)) ? (((l == null) || (r != null)) ? ((x < y) ? -1 : 1) : 1) : -1);
            }
        }

        public class PointPairComparerY : IComparer<PointPair>
        {
            public int Compare(PointPair l, PointPair r)
            {
                if ((l == null) && (r == null))
                {
                    return 0;
                }
                if ((l == null) && (r != null))
                {
                    return -1;
                }
                if ((l != null) && (r == null))
                {
                    return 1;
                }
                double y = l.Y;
                double num2 = r.Y;
                return ((Math.Abs((double) (y - num2)) >= 1E-09) ? ((y < num2) ? -1 : 1) : 0);
            }
        }
    }
}

