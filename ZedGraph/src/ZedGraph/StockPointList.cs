namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    [Serializable]
    public class StockPointList : List<StockPt>, IPointListEdit, IPointList, ICloneable
    {
        public StockPointList()
        {
        }

        public StockPointList(StockPointList rhs)
        {
            for (int i = 0; i < rhs.Count; i++)
            {
                StockPt point = new StockPt(rhs[i]);
                this.Add(point);
            }
        }

        public void Add(PointPair point)
        {
            base.Add(new StockPt(point));
        }

        public void Add(StockPt point)
        {
            base.Add(new StockPt(point));
        }

        public void Add(double date, double high)
        {
            this.Add(new StockPt(date, high, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue));
        }

        public void Add(double date, double high, double low, double open, double close, double vol)
        {
            StockPt point = new StockPt(date, high, low, open, close, vol);
            this.Add(point);
        }

        public StockPointList Clone() => 
            new StockPointList(this);

        public StockPt GetAt(int index) => 
            base[index];

        object ICloneable.Clone() => 
            this.Clone();

        public PointPair this[int index]
        {
            get => 
                base[index];
            set => 
                base[index] = new StockPt(value);
        }
    }
}

