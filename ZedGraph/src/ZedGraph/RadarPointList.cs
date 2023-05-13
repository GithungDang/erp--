namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    [Serializable]
    public class RadarPointList : List<PointPair>, IPointListEdit, IPointList, ICloneable
    {
        private bool _clockwise;
        private double _rotation;

        public RadarPointList()
        {
            this._clockwise = true;
            this._rotation = 90.0;
        }

        public RadarPointList(RadarPointList rhs)
        {
            this._clockwise = true;
            this._rotation = 90.0;
            for (int i = 0; i < rhs.Count; i++)
            {
                base.Add(rhs.GetAt(i));
            }
        }

        public void Add(double r, double z)
        {
            base.Add(new PointPair(double.MaxValue, r, z));
        }

        public RadarPointList Clone() => 
            new RadarPointList(this);

        private PointPair GetAt(int index) => 
            base[index];

        object ICloneable.Clone() => 
            this.Clone();

        public PointPair this[int index]
        {
            get
            {
                int count = this.Count;
                if (index == (count - 1))
                {
                    index = 0;
                }
                if ((index < 0) || (index >= count))
                {
                    return null;
                }
                PointPair pair = base[index];
                double d = ((this._rotation * 3.1415926535897931) / 180.0) + ((this._clockwise ? -1.0 : 1.0) * (((((double) index) / ((double) (count - 1))) * 2.0) * 3.1415926535897931));
                return new PointPair(pair.Y * Math.Cos(d), pair.Y * Math.Sin(d), pair.Z, (string) pair.Tag);
            }
            set
            {
                int count = this.Count;
                if (index == (count - 1))
                {
                    index = 0;
                }
                if ((index >= 0) && (index < count))
                {
                    base[index].Y = Math.Sqrt((value.X * value.X) + (value.Y * value.Y));
                }
            }
        }

        public bool Clockwise
        {
            get => 
                this._clockwise;
            set => 
                this._clockwise = value;
        }

        public double Rotation
        {
            get => 
                this._rotation;
            set => 
                this._rotation = value;
        }

        public int Count =>
            base.Count + 1;
    }
}

