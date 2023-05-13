namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public abstract class CurveItem : ISerializable, ICloneable
    {
        public const int schema = 11;
        internal ZedGraph.Label _label;
        protected bool _isX2Axis;
        protected bool _isY2Axis;
        protected int _yAxisIndex;
        protected bool _isVisible;
        protected bool _isSelected;
        protected bool _isSelectable;
        protected bool _isOverrideOrdinal;
        protected IPointList _points;
        public object Tag;
        internal ZedGraph.Link _link;

        public CurveItem()
        {
            this.Init(null);
        }

        public CurveItem(string label) : this(label, null)
        {
        }

        public CurveItem(CurveItem rhs)
        {
            this._label = rhs._label.Clone();
            this._isY2Axis = rhs.IsY2Axis;
            this._isX2Axis = rhs.IsX2Axis;
            this._isVisible = rhs.IsVisible;
            this._isOverrideOrdinal = rhs._isOverrideOrdinal;
            this._yAxisIndex = rhs._yAxisIndex;
            this.Tag = !(rhs.Tag is ICloneable) ? rhs.Tag : ((ICloneable) rhs.Tag).Clone();
            this._points = (IPointList) rhs.Points.Clone();
            this._link = rhs._link.Clone();
        }

        protected CurveItem(SerializationInfo info, StreamingContext context)
        {
            int num = info.GetInt32("schema");
            this._label = (ZedGraph.Label) info.GetValue("label", typeof(ZedGraph.Label));
            this._isY2Axis = info.GetBoolean("isY2Axis");
            this._isX2Axis = (num >= 11) && info.GetBoolean("isX2Axis");
            this._isVisible = info.GetBoolean("isVisible");
            this._isOverrideOrdinal = info.GetBoolean("isOverrideOrdinal");
            this._points = (PointPairList) info.GetValue("points", typeof(PointPairList));
            this.Tag = info.GetValue("Tag", typeof(object));
            this._yAxisIndex = info.GetInt32("yAxisIndex");
            this._link = (ZedGraph.Link) info.GetValue("link", typeof(ZedGraph.Link));
        }

        public CurveItem(string label, IPointList points)
        {
            this.Init(label);
            if (points == null)
            {
                this._points = new PointPairList();
            }
            else
            {
                this._points = points;
            }
        }

        public CurveItem(string label, double[] x, double[] y) : this(label, new PointPairList(x, y))
        {
        }

        public void AddPoint(PointPair point)
        {
            if (this._points == null)
            {
                this.Points = new PointPairList();
            }
            if (!(this._points is IPointListEdit))
            {
                throw new NotImplementedException();
            }
            (this._points as IPointListEdit).Add(point);
        }

        public void AddPoint(double x, double y)
        {
            this.AddPoint(new PointPair(x, y));
        }

        public virtual Axis BaseAxis(GraphPane pane)
        {
            BarBase base2 = ((this is BarItem) || ((this is ErrorBarItem) || (this is HiLowBarItem))) ? pane._barSettings.Base : (this._isX2Axis ? BarBase.X2 : BarBase.X);
            return ((base2 != BarBase.X) ? ((base2 != BarBase.X2) ? ((base2 != BarBase.Y) ? ((Axis) pane.Y2Axis) : ((Axis) pane.YAxis)) : ((Axis) pane.X2Axis)) : ((Axis) pane.XAxis));
        }

        public void Clear()
        {
            if (!(this._points is IPointListEdit))
            {
                throw new NotImplementedException();
            }
            (this._points as IPointListEdit).Clear();
        }

        public abstract void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor);
        public abstract void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor);
        public float GetBarWidth(GraphPane pane)
        {
            float num;
            if (this is ErrorBarItem)
            {
                num = ((ErrorBarItem) this).Bar.Symbol.Size * pane.CalcScaleFactor();
            }
            else
            {
                float numClusterableBars = 1f;
                if (pane._barSettings.Type == BarType.Cluster)
                {
                    numClusterableBars = pane.CurveList.NumClusterableBars;
                }
                float num3 = ((numClusterableBars * (1f + pane._barSettings.MinBarGap)) - pane._barSettings.MinBarGap) + pane._barSettings.MinClusterGap;
                if (num3 <= 0f)
                {
                    num3 = 1f;
                }
                num = pane.BarSettings.GetClusterWidth() / num3;
            }
            return ((num > 0f) ? num : 1f);
        }

        public abstract bool GetCoords(GraphPane pane, int i, out string coords);
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 11);
            info.AddValue("label", this._label);
            info.AddValue("isY2Axis", this._isY2Axis);
            info.AddValue("isX2Axis", this._isX2Axis);
            info.AddValue("isVisible", this._isVisible);
            info.AddValue("isOverrideOrdinal", this._isOverrideOrdinal);
            PointPairList list = !(this._points is PointPairList) ? new PointPairList(this._points) : (this._points as PointPairList);
            info.AddValue("points", list);
            info.AddValue("Tag", this.Tag);
            info.AddValue("yAxisIndex", this._yAxisIndex);
            info.AddValue("link", this._link);
        }

        public virtual void GetRange(out double xMin, out double xMax, out double yMin, out double yMax, bool ignoreInitial, bool isBoundedRanges, GraphPane pane)
        {
            double minValue = double.MinValue;
            double maxValue = double.MaxValue;
            double num3 = double.MinValue;
            double num4 = double.MaxValue;
            xMin = yMin = double.MaxValue;
            xMax = yMax = double.MinValue;
            Axis yAxis = this.GetYAxis(pane);
            Axis xAxis = this.GetXAxis(pane);
            if ((yAxis != null) && (xAxis != null))
            {
                if (isBoundedRanges)
                {
                    minValue = xAxis._scale._lBound;
                    maxValue = xAxis._scale._uBound;
                    num3 = yAxis._scale._lBound;
                    num4 = yAxis._scale._uBound;
                }
                bool flag = this.IsZIncluded(pane);
                bool flag2 = this.IsXIndependent(pane);
                bool isLog = xAxis.Scale.IsLog;
                bool flag4 = yAxis.Scale.IsLog;
                bool isAnyOrdinal = xAxis.Scale.IsAnyOrdinal;
                bool flag6 = yAxis.Scale.IsAnyOrdinal;
                bool flag7 = (flag2 ? ((bool) yAxis) : ((bool) xAxis)).Scale.IsAnyOrdinal;
                for (int i = 0; i < this.Points.Count; i++)
                {
                    bool flag1;
                    PointPair pair = this.Points[i];
                    double num6 = isAnyOrdinal ? ((double) (i + 1)) : pair.X;
                    double num7 = flag6 ? ((double) (i + 1)) : pair.Y;
                    double num8 = flag7 ? ((double) (i + 1)) : pair.Z;
                    if ((((num6 < minValue) || ((num6 > maxValue) || ((num7 < num3) || ((num7 > num4) || (flag && (flag2 && ((num8 < num3) || (num8 > num4)))))))) || (flag && (!flag2 && ((num8 < minValue) || (num8 > maxValue))))) || ((num6 <= 0.0) && isLog))
                    {
                        flag1 = true;
                    }
                    else
                    {
                        flag1 = (num7 <= 0.0) && flag4;
                    }
                    bool flag8 = flag1;
                    if (ignoreInitial && ((num7 != 0.0) && (num7 != double.MaxValue)))
                    {
                        ignoreInitial = false;
                    }
                    if (!ignoreInitial && (!flag8 && ((num6 != double.MaxValue) && (num7 != double.MaxValue))))
                    {
                        if (num6 < xMin)
                        {
                            xMin = num6;
                        }
                        if (num6 > xMax)
                        {
                            xMax = num6;
                        }
                        if (num7 < yMin)
                        {
                            yMin = num7;
                        }
                        if (num7 > yMax)
                        {
                            yMax = num7;
                        }
                        if (flag && (flag2 && (num8 != double.MaxValue)))
                        {
                            if (num8 < yMin)
                            {
                                yMin = num8;
                            }
                            if (num8 > yMax)
                            {
                                yMax = num8;
                            }
                        }
                        else if (flag && (num8 != double.MaxValue))
                        {
                            if (num8 < xMin)
                            {
                                xMin = num8;
                            }
                            if (num8 > xMax)
                            {
                                xMax = num8;
                            }
                        }
                    }
                }
            }
        }

        public Axis GetXAxis(GraphPane pane) => 
            !this._isX2Axis ? ((Axis) pane.XAxis) : ((Axis) pane.X2Axis);

        public Axis GetYAxis(GraphPane pane) => 
            !this._isY2Axis ? ((this._yAxisIndex >= pane.YAxisList.Count) ? ((Axis) pane.YAxisList[0]) : ((Axis) pane.YAxisList[this._yAxisIndex])) : ((this._yAxisIndex >= pane.Y2AxisList.Count) ? ((Axis) pane.Y2AxisList[0]) : ((Axis) pane.Y2AxisList[this._yAxisIndex]));

        public int GetYAxisIndex(GraphPane pane) => 
            ((this._yAxisIndex < 0) || (this._yAxisIndex >= (this._isY2Axis ? pane.Y2AxisList.Count : pane.YAxisList.Count))) ? 0 : this._yAxisIndex;

        private void Init(string label)
        {
            this._label = new ZedGraph.Label(label, null);
            this._isY2Axis = false;
            this._isX2Axis = false;
            this._isVisible = true;
            this._isOverrideOrdinal = false;
            this.Tag = null;
            this._yAxisIndex = 0;
            this._link = new ZedGraph.Link();
        }

        internal abstract bool IsXIndependent(GraphPane pane);
        internal abstract bool IsZIncluded(GraphPane pane);
        public void MakeUnique()
        {
            this.MakeUnique(ColorSymbolRotator.StaticInstance);
        }

        public virtual void MakeUnique(ColorSymbolRotator rotator)
        {
            this.Color = rotator.NextColor;
        }

        public void RemovePoint(int index)
        {
            if (!(this._points is IPointListEdit))
            {
                throw new NotImplementedException();
            }
            (this._points as IPointListEdit).RemoveAt(index);
        }

        object ICloneable.Clone()
        {
            throw new NotImplementedException("Can't clone an abstract base type -- child types must implement ICloneable");
        }

        public virtual Axis ValueAxis(GraphPane pane)
        {
            BarBase base2 = ((this is BarItem) || ((this is ErrorBarItem) || (this is HiLowBarItem))) ? pane._barSettings.Base : BarBase.X;
            return (((base2 == BarBase.X) || (base2 == BarBase.X2)) ? this.GetYAxis(pane) : this.GetXAxis(pane));
        }

        public ZedGraph.Label Label
        {
            get => 
                this._label;
            set => 
                this._label = value;
        }

        public System.Drawing.Color Color
        {
            get => 
                !(this is BarItem) ? ((!(this is LineItem) || !((LineItem) this).Line.IsVisible) ? (!(this is LineItem) ? (!(this is ErrorBarItem) ? (!(this is HiLowBarItem) ? System.Drawing.Color.Empty : ((HiLowBarItem) this).Bar.Fill.Color) : ((ErrorBarItem) this).Bar.Color) : ((LineItem) this).Symbol.Border.Color) : ((LineItem) this).Line.Color) : ((BarItem) this).Bar.Fill.Color;
            set
            {
                switch (this)
                {
                    case (BarItem _):
                        ((BarItem) this).Bar.Fill.Color = value;
                        break;

                    case (LineItem _):
                        ((LineItem) this).Line.Color = value;
                        ((LineItem) this).Symbol.Border.Color = value;
                        ((LineItem) this).Symbol.Fill.Color = value;
                        break;

                    case (ErrorBarItem _):
                        ((ErrorBarItem) this).Bar.Color = value;
                        break;

                    case (HiLowBarItem _):
                        ((HiLowBarItem) this).Bar.Fill.Color = value;
                        break;
                }
            }
        }

        public bool IsVisible
        {
            get => 
                this._isVisible;
            set => 
                this._isVisible = value;
        }

        public bool IsSelected
        {
            get => 
                this._isSelected;
            set => 
                this._isSelected = value;
        }

        public bool IsSelectable
        {
            get => 
                this._isSelectable;
            set => 
                this._isSelectable = value;
        }

        public bool IsOverrideOrdinal
        {
            get => 
                this._isOverrideOrdinal;
            set => 
                this._isOverrideOrdinal = value;
        }

        public bool IsX2Axis
        {
            get => 
                this._isX2Axis;
            set => 
                this._isX2Axis = value;
        }

        public bool IsY2Axis
        {
            get => 
                this._isY2Axis;
            set => 
                this._isY2Axis = value;
        }

        public int YAxisIndex
        {
            get => 
                this._yAxisIndex;
            set => 
                this._yAxisIndex = value;
        }

        public bool IsBar =>
            (this is BarItem) || ((this is HiLowBarItem) || (this is ErrorBarItem));

        public bool IsPie =>
            this is PieItem;

        public bool IsLine =>
            this is LineItem;

        public int NPts =>
            (this._points != null) ? this._points.Count : 0;

        public IPointList Points
        {
            get => 
                this._points;
            set => 
                this._points = value;
        }

        public PointPair this[int index] =>
            (this._points != null) ? this._points[index] : new PointPair(double.MaxValue, double.MaxValue);

        public ZedGraph.Link Link
        {
            get => 
                this._link;
            set => 
                this._link = value;
        }

        public class Comparer : IComparer<CurveItem>
        {
            private int index;
            private SortType sortType;

            public Comparer(SortType type, int index)
            {
                this.sortType = type;
                this.index = index;
            }

            public int Compare(CurveItem l, CurveItem r)
            {
                double num;
                double num2;
                if ((l == null) && (r == null))
                {
                    return 0;
                }
                if ((l == null) && (r != null))
                {
                    return -1;
                }
                if ((l != null) && (r == null))
                {
                    return 1;
                }
                if ((r != null) && (r.NPts <= this.index))
                {
                    r = null;
                }
                if ((l != null) && (l.NPts <= this.index))
                {
                    l = null;
                }
                if (this.sortType == SortType.XValues)
                {
                    num = (l != null) ? Math.Abs(l[this.index].X) : double.MaxValue;
                    num2 = (r != null) ? Math.Abs(r[this.index].X) : double.MaxValue;
                }
                else
                {
                    num = (l != null) ? Math.Abs(l[this.index].Y) : double.MaxValue;
                    num2 = (r != null) ? Math.Abs(r[this.index].Y) : double.MaxValue;
                }
                if ((num == double.MaxValue) || (double.IsInfinity(num) || double.IsNaN(num)))
                {
                    l = null;
                }
                if ((num2 == double.MaxValue) || (double.IsInfinity(num2) || double.IsNaN(num2)))
                {
                    r = null;
                }
                if (((l == null) && (r == null)) || (Math.Abs((double) (num - num2)) < 1E-10))
                {
                    return 0;
                }
                return (((l != null) || (r == null)) ? (((l == null) || (r != null)) ? ((num2 < num) ? -1 : 1) : 1) : -1);
            }
        }
    }
}

