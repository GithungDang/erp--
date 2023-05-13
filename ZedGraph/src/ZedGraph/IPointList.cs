namespace ZedGraph
{
    using System;
    using System.Reflection;

    public interface IPointList : ICloneable
    {
        PointPair this[int index] { get; }

        int Count { get; }
    }
}

