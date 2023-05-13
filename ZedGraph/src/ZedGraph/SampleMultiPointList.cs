namespace ZedGraph
{
    using System;
    using System.Collections;
    using System.Reflection;

    [Serializable]
    public class SampleMultiPointList : IPointList, ICloneable
    {
        private ArrayList DataCollection;
        public PerfDataType XData;
        public PerfDataType YData;

        public SampleMultiPointList()
        {
            this.XData = PerfDataType.Time;
            this.YData = PerfDataType.Distance;
            this.DataCollection = new ArrayList();
        }

        public SampleMultiPointList(SampleMultiPointList rhs)
        {
            this.DataCollection = rhs.DataCollection;
            this.XData = rhs.XData;
            this.YData = rhs.YData;
        }

        public int Add(PerformanceData perfData) => 
            this.DataCollection.Add(perfData);

        public SampleMultiPointList Clone() => 
            new SampleMultiPointList(this);

        public void Insert(int index, PerformanceData perfData)
        {
            this.DataCollection.Insert(index, perfData);
        }

        public void RemoveAt(int index)
        {
            this.DataCollection.RemoveAt(index);
        }

        object ICloneable.Clone() => 
            this.Clone();

        public PointPair this[int index]
        {
            get
            {
                double maxValue;
                double num2;
                if ((index < 0) || (index >= this.Count))
                {
                    maxValue = double.MaxValue;
                    num2 = double.MaxValue;
                }
                else
                {
                    PerformanceData data = (PerformanceData) this.DataCollection[index];
                    maxValue = data[this.XData];
                    num2 = data[this.YData];
                }
                return new PointPair(maxValue, num2, double.MaxValue, null);
            }
        }

        public int Count =>
            this.DataCollection.Count;
    }
}

