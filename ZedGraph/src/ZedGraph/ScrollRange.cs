namespace ZedGraph
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct ScrollRange
    {
        private bool _isScrollable;
        private double _min;
        private double _max;
        public ScrollRange(double min, double max, bool isScrollable)
        {
            this._min = min;
            this._max = max;
            this._isScrollable = isScrollable;
        }

        public ScrollRange(bool isScrollable)
        {
            this._min = 0.0;
            this._max = 0.0;
            this._isScrollable = isScrollable;
        }

        public ScrollRange(ScrollRange rhs)
        {
            this._min = rhs._min;
            this._max = rhs._max;
            this._isScrollable = rhs._isScrollable;
        }

        public bool IsScrollable
        {
            get => 
                this._isScrollable;
            set => 
                this._isScrollable = value;
        }
        public double Min
        {
            get => 
                this._min;
            set => 
                this._min = value;
        }
        public double Max
        {
            get => 
                this._max;
            set => 
                this._max = value;
        }
    }
}

