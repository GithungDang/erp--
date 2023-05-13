namespace ZedGraph
{
    using System;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct PointD
    {
        public double X;
        public double Y;
        public PointD(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

