namespace ZedGraph
{
    using System;
    using System.Collections;
    using System.Reflection;

    [Serializable]
    public class SamplePointList : IPointList, ICloneable
    {
        public SampleType XType;
        public SampleType YType;
        private ArrayList list;

        public SamplePointList()
        {
            this.XType = SampleType.Time;
            this.YType = SampleType.Position;
            this.list = new ArrayList();
        }

        public SamplePointList(SamplePointList rhs)
        {
            this.XType = rhs.XType;
            this.YType = rhs.YType;
            this.list = rhs.list;
        }

        public int Add(Sample sample) => 
            this.list.Add(sample);

        public SamplePointList Clone() => 
            new SamplePointList(this);

        public double GetValue(Sample sample, SampleType type)
        {
            switch (type)
            {
                case SampleType.Time:
                    return sample.Time.ToOADate();

                case SampleType.Position:
                    return sample.Position;

                case SampleType.VelocityInst:
                    return sample.Velocity;

                case SampleType.TimeDiff:
                    return (sample.Time.ToOADate() - ((Sample) this.list[0]).Time.ToOADate());

                case SampleType.VelocityAvg:
                {
                    double num = sample.Time.ToOADate() - ((Sample) this.list[0]).Time.ToOADate();
                    return ((num > 0.0) ? ((sample.Position - ((Sample) this.list[0]).Position) / num) : double.MaxValue);
                }
            }
            return double.MaxValue;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public PointPair this[int index]
        {
            get
            {
                PointPair pair = new PointPair();
                Sample sample = (Sample) this.list[index];
                pair.X = this.GetValue(sample, this.XType);
                pair.Y = this.GetValue(sample, this.YType);
                return pair;
            }
        }

        public int Count =>
            this.list.Count;
    }
}

