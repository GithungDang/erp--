namespace ZedGraph
{
    using System;
    using System.Reflection;

    public interface IPointListEdit : IPointList, ICloneable
    {
        void Add(PointPair point);
        void Add(double x, double y);
        void Clear();
        void RemoveAt(int index);

        PointPair this[int index] { get; set; }
    }
}

