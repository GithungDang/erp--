namespace ZedGraph
{
    using System;
    using System.Reflection;

    [Serializable]
    public class FilteredPointList : IPointList, ICloneable
    {
        private double[] _x;
        private double[] _y;
        private int _maxPts;
        private int _minBoundIndex;
        private int _maxBoundIndex;

        public FilteredPointList(FilteredPointList rhs)
        {
            this._maxPts = -1;
            this._minBoundIndex = -1;
            this._maxBoundIndex = -1;
            this._x = (double[]) rhs._x.Clone();
            this._y = (double[]) rhs._y.Clone();
            this._minBoundIndex = rhs._minBoundIndex;
            this._maxBoundIndex = rhs._maxBoundIndex;
            this._maxPts = rhs._maxPts;
        }

        public FilteredPointList(double[] x, double[] y)
        {
            this._maxPts = -1;
            this._minBoundIndex = -1;
            this._maxBoundIndex = -1;
            this._x = x;
            this._y = y;
        }

        public virtual object Clone() => 
            new FilteredPointList(this);

        public void SetBounds(double min, double max, int maxPts)
        {
            this._maxPts = maxPts;
            int num = Array.BinarySearch<double>(this._x, min);
            int num2 = Array.BinarySearch<double>(this._x, max);
            if (num < 0)
            {
                num = (num != -1) ? ~(num + 1) : 0;
            }
            if (num2 < 0)
            {
                num2 = ~num2;
            }
            this._minBoundIndex = num;
            this._maxBoundIndex = num2;
        }

        public PointPair this[int index]
        {
            get
            {
                if ((this._minBoundIndex >= 0) && ((this._maxBoundIndex >= 0) && (this._maxPts >= 0)))
                {
                    int num = (this._maxBoundIndex - this._minBoundIndex) + 1;
                    index = (num <= this._maxPts) ? (index + this._minBoundIndex) : (this._minBoundIndex + ((int) ((index * num) / ((double) this._maxPts))));
                }
                double x = ((index < 0) || (index >= this._x.Length)) ? double.MaxValue : this._x[index];
                return new PointPair(x, ((index < 0) || (index >= this._y.Length)) ? double.MaxValue : this._y[index], double.MaxValue, null);
            }
            set
            {
                if ((this._minBoundIndex >= 0) && ((this._maxBoundIndex >= 0) && (this._maxPts >= 0)))
                {
                    int num = (this._maxBoundIndex - this._minBoundIndex) + 1;
                    index = (num <= this._maxPts) ? (index + this._minBoundIndex) : (this._minBoundIndex + ((int) ((index * num) / ((double) this._maxPts))));
                }
                if ((index >= 0) && (index < this._x.Length))
                {
                    this._x[index] = value.X;
                }
                if ((index >= 0) && (index < this._y.Length))
                {
                    this._y[index] = value.Y;
                }
            }
        }

        public int Count
        {
            get
            {
                int length = this._x.Length;
                if ((this._minBoundIndex >= 0) && ((this._maxBoundIndex >= 0) && (this._maxPts > 0)))
                {
                    int num2 = (this._maxBoundIndex - this._minBoundIndex) + 1;
                    if (num2 < length)
                    {
                        length = num2;
                    }
                    if (length > this._maxPts)
                    {
                        length = this._maxPts;
                    }
                }
                return length;
            }
        }

        public int MaxPts =>
            this._maxPts;
    }
}

