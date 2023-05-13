namespace ZedGraph
{
    using System;
    using System.Reflection;

    [Serializable]
    public class BasicArrayPointList : IPointList, ICloneable
    {
        public double[] x;
        public double[] y;

        public BasicArrayPointList(BasicArrayPointList rhs)
        {
            this.x = (double[]) rhs.x.Clone();
            this.y = (double[]) rhs.y.Clone();
        }

        public BasicArrayPointList(double[] x, double[] y)
        {
            this.x = x;
            this.y = y;
        }

        public BasicArrayPointList Clone() => 
            new BasicArrayPointList(this);

        object ICloneable.Clone() => 
            this.Clone();

        public PointPair this[int index]
        {
            get
            {
                double x = ((index < 0) || (index >= this.x.Length)) ? double.MaxValue : this.x[index];
                return new PointPair(x, ((index < 0) || (index >= this.y.Length)) ? double.MaxValue : this.y[index], double.MaxValue, null);
            }
            set
            {
                if ((index >= 0) && (index < this.x.Length))
                {
                    this.x[index] = value.X;
                }
                if ((index >= 0) && (index < this.y.Length))
                {
                    this.y[index] = value.Y;
                }
            }
        }

        public int Count =>
            (this.x.Length > this.y.Length) ? this.x.Length : this.y.Length;
    }
}

