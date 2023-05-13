namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    [Serializable]
    public class NoDupePointList : List<DataPoint>, IPointListEdit, IPointList, ICloneable
    {
        protected bool _isFiltered;
        protected int _filteredCount;
        protected int[] _visibleIndicies;
        protected int _filterMode;

        public NoDupePointList()
        {
            this._isFiltered = false;
            this._filteredCount = 0;
            this._visibleIndicies = null;
            this._filterMode = 0;
        }

        public NoDupePointList(NoDupePointList rhs)
        {
            int totalCount = rhs.TotalCount;
            for (int i = 0; i < totalCount; i++)
            {
                base.Add(rhs.GetDataPointAt(i));
            }
            this._filteredCount = rhs._filteredCount;
            this._isFiltered = rhs._isFiltered;
            this._filterMode = rhs._filterMode;
            if (rhs._visibleIndicies != null)
            {
                this._visibleIndicies = (int[]) rhs._visibleIndicies.Clone();
            }
            else
            {
                this._visibleIndicies = null;
            }
        }

        public void Add(PointPair pt)
        {
            DataPoint item = new DataPoint {
                X = pt.X,
                Y = pt.Y
            };
            base.Add(item);
        }

        public void Add(double x, double y)
        {
            DataPoint item = new DataPoint {
                X = x,
                Y = y
            };
            base.Add(item);
        }

        public void ClearFilter()
        {
            this._isFiltered = false;
            this._filteredCount = 0;
        }

        public NoDupePointList Clone() => 
            new NoDupePointList(this);

        public void FilterData(GraphPane pane, Axis xAxis, Axis yAxis)
        {
            if ((this._visibleIndicies == null) || (this._visibleIndicies.Length < base.Count))
            {
                this._visibleIndicies = new int[base.Count];
            }
            this._filteredCount = 0;
            this._isFiltered = true;
            int width = (int) pane.Chart.Rect.Width;
            int height = (int) pane.Chart.Rect.Height;
            if ((width <= 0) || (height <= 0))
            {
                throw new IndexOutOfRangeException("Error in FilterData: Chart rect not valid");
            }
            bool[,] flagArray = new bool[width, height];
            int num3 = 0;
            while (num3 < width)
            {
                int num4 = 0;
                while (true)
                {
                    if (num4 >= height)
                    {
                        num3++;
                        break;
                    }
                    flagArray[num3, num4] = false;
                    num4++;
                }
            }
            xAxis.Scale.SetupScaleData(pane, xAxis);
            yAxis.Scale.SetupScaleData(pane, yAxis);
            int num5 = (this._filterMode < 0) ? 0 : this._filterMode;
            int left = (int) pane.Chart.Rect.Left;
            int top = (int) pane.Chart.Rect.Top;
            for (int i = 0; i < base.Count; i++)
            {
                DataPoint point = base[i];
                int num9 = ((int) (xAxis.Scale.Transform(point.X) + 0.5)) - left;
                int num10 = ((int) (yAxis.Scale.Transform(point.Y) + 0.5)) - top;
                if ((num9 >= 0) && ((num9 < width) && ((num10 >= 0) && (num10 < height))))
                {
                    bool flag = false;
                    if (num5 <= 0)
                    {
                        flag = flagArray[num9, num10];
                    }
                    else
                    {
                        int num11 = num9 - num5;
                        while (num11 <= (num9 + num5))
                        {
                            int num12 = num10 - num5;
                            while (true)
                            {
                                if (num12 > (num10 + num5))
                                {
                                    num11++;
                                    break;
                                }
                                flag |= ((num11 >= 0) && ((num11 < width) && ((num12 >= 0) && (num12 < height)))) && flagArray[num11, num12];
                                num12++;
                            }
                        }
                    }
                    if (!flag)
                    {
                        flagArray[num9, num10] = true;
                        this._visibleIndicies[this._filteredCount] = i;
                        this._filteredCount++;
                    }
                }
            }
        }

        protected DataPoint GetDataPointAt(int index) => 
            base[index];

        object ICloneable.Clone() => 
            this.Clone();

        public int FilterMode
        {
            get => 
                this._filterMode;
            set => 
                this._filterMode = value;
        }

        public bool IsFiltered =>
            this._isFiltered;

        public PointPair this[int index]
        {
            get
            {
                int num = index;
                if (this._isFiltered)
                {
                    num = this._visibleIndicies[index];
                }
                DataPoint point = base[num];
                return new PointPair(point.X, point.Y);
            }
            set
            {
                DataPoint point;
                int num = index;
                if (this._isFiltered)
                {
                    num = this._visibleIndicies[index];
                }
                point.X = value.X;
                point.Y = value.Y;
                base[num] = point;
            }
        }

        public int Count =>
            this._isFiltered ? this._filteredCount : base.Count;

        public int TotalCount =>
            base.Count;
    }
}

