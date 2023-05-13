namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class GraphPane : PaneBase, ICloneable, ISerializable
    {
        public const int schema2 = 11;
        private AxisChangeEventHandler AxisChangeEvent;
        private ZedGraph.XAxis _xAxis;
        private ZedGraph.X2Axis _x2Axis;
        private ZedGraph.YAxisList _yAxisList;
        private ZedGraph.Y2AxisList _y2AxisList;
        private ZedGraph.CurveList _curveList;
        private ZoomStateStack _zoomStack;
        internal ZedGraph.Chart _chart;
        internal ZedGraph.BarSettings _barSettings;
        private bool _isIgnoreInitial;
        private bool _isIgnoreMissing;
        private bool _isBoundedRanges;
        private bool _isAlignGrids;
        private ZedGraph.LineType _lineType;

        public event AxisChangeEventHandler AxisChangeEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.AxisChangeEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.AxisChangeEvent -= value;
            }
        }

        public GraphPane() : this(new RectangleF(0f, 0f, 500f, 375f), "", "", "")
        {
        }

        public GraphPane(GraphPane rhs) : base(rhs)
        {
            this._isIgnoreInitial = rhs.IsIgnoreInitial;
            this._isBoundedRanges = rhs._isBoundedRanges;
            this._isAlignGrids = rhs._isAlignGrids;
            this._chart = rhs._chart.Clone();
            this._barSettings = new ZedGraph.BarSettings(rhs._barSettings, this);
            this._lineType = rhs.LineType;
            this._xAxis = new ZedGraph.XAxis(rhs.XAxis);
            this._x2Axis = new ZedGraph.X2Axis(rhs.X2Axis);
            this._yAxisList = new ZedGraph.YAxisList(rhs._yAxisList);
            this._y2AxisList = new ZedGraph.Y2AxisList(rhs._y2AxisList);
            this._curveList = new ZedGraph.CurveList(rhs.CurveList);
            this._zoomStack = new ZoomStateStack(rhs._zoomStack);
        }

        protected GraphPane(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            int num = info.GetInt32("schema2");
            this._xAxis = (ZedGraph.XAxis) info.GetValue("xAxis", typeof(ZedGraph.XAxis));
            this._x2Axis = (num < 11) ? new ZedGraph.X2Axis("") : ((ZedGraph.X2Axis) info.GetValue("x2Axis", typeof(ZedGraph.X2Axis)));
            this._yAxisList = (ZedGraph.YAxisList) info.GetValue("yAxisList", typeof(ZedGraph.YAxisList));
            this._y2AxisList = (ZedGraph.Y2AxisList) info.GetValue("y2AxisList", typeof(ZedGraph.Y2AxisList));
            this._curveList = (ZedGraph.CurveList) info.GetValue("curveList", typeof(ZedGraph.CurveList));
            this._chart = (ZedGraph.Chart) info.GetValue("chart", typeof(ZedGraph.Chart));
            this._barSettings = (ZedGraph.BarSettings) info.GetValue("barSettings", typeof(ZedGraph.BarSettings));
            this._barSettings._ownerPane = this;
            this._isIgnoreInitial = info.GetBoolean("isIgnoreInitial");
            this._isBoundedRanges = info.GetBoolean("isBoundedRanges");
            this._isIgnoreMissing = info.GetBoolean("isIgnoreMissing");
            this._isAlignGrids = info.GetBoolean("isAlignGrids");
            this._lineType = (ZedGraph.LineType) info.GetValue("lineType", typeof(ZedGraph.LineType));
            this._zoomStack = new ZoomStateStack();
        }

        public GraphPane(RectangleF rect, string title, string xTitle, string yTitle) : base(title, rect)
        {
            this._xAxis = new ZedGraph.XAxis(xTitle);
            this._x2Axis = new ZedGraph.X2Axis("");
            this._yAxisList = new ZedGraph.YAxisList();
            this._y2AxisList = new ZedGraph.Y2AxisList();
            this._yAxisList.Add(new ZedGraph.YAxis(yTitle));
            this._y2AxisList.Add(new ZedGraph.Y2Axis(string.Empty));
            this._curveList = new ZedGraph.CurveList();
            this._zoomStack = new ZoomStateStack();
            this._isIgnoreInitial = Default.IsIgnoreInitial;
            this._isBoundedRanges = Default.IsBoundedRanges;
            this._isAlignGrids = false;
            this._chart = new ZedGraph.Chart();
            this._barSettings = new ZedGraph.BarSettings(this);
            this._lineType = Default.LineType;
        }

        public BarItem AddBar(string label, IPointList points, Color color)
        {
            BarItem item = new BarItem(label, points, color);
            this._curveList.Add(item);
            return item;
        }

        public BarItem AddBar(string label, double[] x, double[] y, Color color)
        {
            BarItem item = new BarItem(label, x, y, color);
            this._curveList.Add(item);
            return item;
        }

        public LineItem AddCurve(string label, IPointList points, Color color)
        {
            LineItem item = new LineItem(label, points, color, SymbolType.Default);
            this._curveList.Add(item);
            return item;
        }

        public LineItem AddCurve(string label, double[] x, double[] y, Color color)
        {
            LineItem item = new LineItem(label, x, y, color, SymbolType.Default);
            this._curveList.Add(item);
            return item;
        }

        public LineItem AddCurve(string label, IPointList points, Color color, SymbolType symbolType)
        {
            LineItem item = new LineItem(label, points, color, symbolType);
            this._curveList.Add(item);
            return item;
        }

        public LineItem AddCurve(string label, double[] x, double[] y, Color color, SymbolType symbolType)
        {
            LineItem item = new LineItem(label, x, y, color, symbolType);
            this._curveList.Add(item);
            return item;
        }

        public ErrorBarItem AddErrorBar(string label, IPointList points, Color color)
        {
            ErrorBarItem item = new ErrorBarItem(label, points, color);
            this._curveList.Add(item);
            return item;
        }

        public ErrorBarItem AddErrorBar(string label, double[] x, double[] y, double[] baseValue, Color color)
        {
            ErrorBarItem item = new ErrorBarItem(label, new PointPairList(x, y, baseValue), color);
            this._curveList.Add(item);
            return item;
        }

        public HiLowBarItem AddHiLowBar(string label, IPointList points, Color color)
        {
            HiLowBarItem item = new HiLowBarItem(label, points, color);
            this._curveList.Add(item);
            return item;
        }

        public HiLowBarItem AddHiLowBar(string label, double[] x, double[] y, double[] baseVal, Color color)
        {
            HiLowBarItem item = new HiLowBarItem(label, x, y, baseVal, color);
            this._curveList.Add(item);
            return item;
        }

        public JapaneseCandleStickItem AddJapaneseCandleStick(string label, IPointList points)
        {
            JapaneseCandleStickItem item = new JapaneseCandleStickItem(label, points);
            this._curveList.Add(item);
            return item;
        }

        public OHLCBarItem AddOHLCBar(string label, IPointList points, Color color)
        {
            OHLCBarItem item = new OHLCBarItem(label, points, color);
            this._curveList.Add(item);
            return item;
        }

        public PieItem AddPieSlice(double value, Color color, double displacement, string label)
        {
            PieItem item = new PieItem(value, color, displacement, label);
            this.CurveList.Add(item);
            return item;
        }

        public PieItem AddPieSlice(double value, Color color1, Color color2, float fillAngle, double displacement, string label)
        {
            PieItem item = new PieItem(value, color1, color2, fillAngle, displacement, label);
            this.CurveList.Add(item);
            return item;
        }

        public PieItem[] AddPieSlices(double[] values, string[] labels)
        {
            PieItem[] itemArray = new PieItem[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                itemArray[i] = new PieItem(values[i], labels[i]);
                this.CurveList.Add(itemArray[i]);
            }
            return itemArray;
        }

        public StickItem AddStick(string label, IPointList points, Color color)
        {
            StickItem item = new StickItem(label, points, color);
            this._curveList.Add(item);
            return item;
        }

        public StickItem AddStick(string label, double[] x, double[] y, Color color)
        {
            StickItem item = new StickItem(label, x, y, color);
            this._curveList.Add(item);
            return item;
        }

        public int AddY2Axis(string title)
        {
            ZedGraph.Y2Axis item = new ZedGraph.Y2Axis(title) {
                MajorTic = { 
                    IsOpposite = false,
                    IsInside = false
                },
                MinorTic = { 
                    IsOpposite = false,
                    IsInside = false
                }
            };
            this._y2AxisList.Add(item);
            return (this._y2AxisList.Count - 1);
        }

        public int AddYAxis(string title)
        {
            ZedGraph.YAxis item = new ZedGraph.YAxis(title) {
                MajorTic = { 
                    IsOpposite = false,
                    IsInside = false
                },
                MinorTic = { 
                    IsOpposite = false,
                    IsInside = false
                }
            };
            this._yAxisList.Add(item);
            return (this._yAxisList.Count - 1);
        }

        public void AxisChange()
        {
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                this.AxisChange(graphics);
            }
        }

        public void AxisChange(Graphics g)
        {
            this._curveList.GetRange(this._isIgnoreInitial, this._isBoundedRanges, this);
            float scaleFactor = base.CalcScaleFactor();
            if (this.CurveList.IsPieOnly)
            {
                this.XAxis.IsVisible = false;
                this.X2Axis.IsVisible = false;
                this.YAxis.IsVisible = false;
                this.Y2Axis.IsVisible = false;
                this._chart.Border.IsVisible = false;
            }
            if (this._barSettings._clusterScaleWidthAuto)
            {
                this._barSettings._clusterScaleWidth = 1.0;
            }
            if (this._chart._isRectAuto)
            {
                this.PickScale(g, scaleFactor);
                this._chart._rect = this.CalcChartRect(g);
            }
            this.PickScale(g, scaleFactor);
            this._barSettings.CalcClusterScaleWidth();
            if (this.AxisChangeEvent != null)
            {
                this.AxisChangeEvent(this);
            }
        }

        private bool AxisRangesValid()
        {
            bool flag = (this._xAxis._scale._min < this._xAxis._scale._max) && (this._x2Axis._scale._min < this._x2Axis._scale._max);
            foreach (Axis axis in this._yAxisList)
            {
                if (axis._scale._min >= axis._scale._max)
                {
                    flag = false;
                }
            }
            foreach (Axis axis2 in this._y2AxisList)
            {
                if (axis2._scale._min >= axis2._scale._max)
                {
                    flag = false;
                }
            }
            return flag;
        }

        public RectangleF CalcChartRect(Graphics g) => 
            this.CalcChartRect(g, base.CalcScaleFactor());

        public unsafe RectangleF CalcChartRect(Graphics g, float scaleFactor)
        {
            RectangleF ef = base.CalcClientRect(g, scaleFactor);
            float num = 0f;
            float num2 = 0f;
            float num3 = 0f;
            float fixedSpace = 0f;
            float num5 = 0f;
            this._xAxis.CalcSpace(g, this, scaleFactor, out fixedSpace);
            this._x2Axis.CalcSpace(g, this, scaleFactor, out num5);
            foreach (Axis axis in this._yAxisList)
            {
                float num6;
                float num7 = axis.CalcSpace(g, this, scaleFactor, out num6);
                if (axis.IsCrossShifted(this))
                {
                    num += num7;
                }
                num2 += num6;
            }
            foreach (Axis axis2 in this._y2AxisList)
            {
                float num8;
                float num9 = axis2.CalcSpace(g, this, scaleFactor, out num8);
                if (axis2.IsCrossShifted(this))
                {
                    num += num9;
                }
                num3 += num8;
            }
            float spaceNorm = 0f;
            float spaceAlt = 0f;
            float num12 = 0f;
            float num13 = 0f;
            this.SetSpace(this._xAxis, ef.Height - this._xAxis._tmpSpace, ref spaceNorm, ref spaceAlt);
            this.SetSpace(this._x2Axis, ef.Height - this._x2Axis._tmpSpace, ref spaceAlt, ref spaceNorm);
            this._xAxis._tmpSpace = spaceNorm;
            this._x2Axis._tmpSpace = spaceAlt;
            float num14 = 0f;
            float num15 = 0f;
            foreach (Axis axis3 in this._yAxisList)
            {
                this.SetSpace(axis3, ef.Width - num, ref num12, ref num13);
                num3 = Math.Max(num3, num13);
                num14 += num12;
                axis3._tmpSpace = num12;
            }
            foreach (Axis axis4 in this._y2AxisList)
            {
                this.SetSpace(axis4, ef.Width - num, ref num13, ref num12);
                num2 = Math.Max(num2, num12);
                num15 += num13;
                axis4._tmpSpace = num13;
            }
            RectangleF tChartRect = ef;
            num14 = Math.Max(num14, num2);
            spaceAlt = Math.Max(spaceAlt, num5);
            RectangleF* efPtr1 = &tChartRect;
            efPtr1.X += num14;
            RectangleF* efPtr2 = &tChartRect;
            efPtr2.Width -= num14 + Math.Max(num15, num3);
            RectangleF* efPtr3 = &tChartRect;
            efPtr3.Height -= spaceAlt + Math.Max(spaceNorm, fixedSpace);
            RectangleF* efPtr4 = &tChartRect;
            efPtr4.Y += spaceAlt;
            base._legend.CalcRect(g, this, scaleFactor, ref tChartRect);
            return tChartRect;
        }

        public GraphPane Clone() => 
            new GraphPane(this);

        public override void Draw(Graphics g)
        {
            base.Draw(g);
            if ((base._rect.Width > 1f) && (base._rect.Height > 1f))
            {
                g.SetClip(base._rect);
                float scaleFactor = base.CalcScaleFactor();
                if (this._chart._isRectAuto)
                {
                    this._chart._rect = this.CalcChartRect(g, scaleFactor);
                }
                else
                {
                    this.CalcChartRect(g, scaleFactor);
                }
                if ((this._chart._rect.Width >= 1f) && (this._chart._rect.Height >= 1f))
                {
                    bool flag = this.AxisRangesValid();
                    this._xAxis.Scale.SetupScaleData(this, this._xAxis);
                    this._x2Axis.Scale.SetupScaleData(this, this._x2Axis);
                    foreach (Axis axis in this._yAxisList)
                    {
                        axis.Scale.SetupScaleData(this, axis);
                    }
                    foreach (Axis axis2 in this._y2AxisList)
                    {
                        axis2.Scale.SetupScaleData(this, axis2);
                    }
                    if (flag)
                    {
                        base._graphObjList.Draw(g, this, scaleFactor, ZOrder.G_BehindChartFill);
                    }
                    this._chart.Fill.Draw(g, this._chart._rect);
                    if (flag)
                    {
                        base._graphObjList.Draw(g, this, scaleFactor, ZOrder.F_BehindGrid);
                        this.DrawGrid(g, scaleFactor);
                        base._graphObjList.Draw(g, this, scaleFactor, ZOrder.E_BehindCurves);
                        g.SetClip(this._chart._rect);
                        this._curveList.Draw(g, this, scaleFactor);
                        g.SetClip(base._rect);
                    }
                    if (flag)
                    {
                        base._graphObjList.Draw(g, this, scaleFactor, ZOrder.D_BehindAxis);
                        this._xAxis.Draw(g, this, scaleFactor, 0f);
                        this._x2Axis.Draw(g, this, scaleFactor, 0f);
                        float shiftPos = 0f;
                        foreach (Axis axis3 in this._yAxisList)
                        {
                            axis3.Draw(g, this, scaleFactor, shiftPos);
                            shiftPos += axis3._tmpSpace;
                        }
                        shiftPos = 0f;
                        foreach (Axis axis4 in this._y2AxisList)
                        {
                            axis4.Draw(g, this, scaleFactor, shiftPos);
                            shiftPos += axis4._tmpSpace;
                        }
                        base._graphObjList.Draw(g, this, scaleFactor, ZOrder.C_BehindChartBorder);
                    }
                    this._chart.Border.Draw(g, this, scaleFactor, this._chart._rect);
                    if (flag)
                    {
                        base._graphObjList.Draw(g, this, scaleFactor, ZOrder.B_BehindLegend);
                        base._legend.Draw(g, this, scaleFactor);
                        base._graphObjList.Draw(g, this, scaleFactor, ZOrder.A_InFront);
                    }
                    g.ResetClip();
                }
            }
        }

        internal void DrawGrid(Graphics g, float scaleFactor)
        {
            this._xAxis.DrawGrid(g, this, scaleFactor, 0f);
            this._x2Axis.DrawGrid(g, this, scaleFactor, 0f);
            float shiftPos = 0f;
            foreach (ZedGraph.YAxis axis in this._yAxisList)
            {
                axis.DrawGrid(g, this, scaleFactor, shiftPos);
                shiftPos += axis._tmpSpace;
            }
            shiftPos = 0f;
            foreach (ZedGraph.Y2Axis axis2 in this._y2AxisList)
            {
                axis2.DrawGrid(g, this, scaleFactor, shiftPos);
                shiftPos += axis2._tmpSpace;
            }
        }

        public bool FindContainedObjects(RectangleF rectF, Graphics g, out ZedGraph.CurveList containedObjs)
        {
            containedObjs = new ZedGraph.CurveList();
            foreach (CurveItem item in this.CurveList)
            {
                for (int i = 0; i < item.Points.Count; i++)
                {
                    if ((item.Points[i].X > rectF.Left) && ((item.Points[i].X < rectF.Right) && ((item.Points[i].Y > rectF.Bottom) && (item.Points[i].Y < rectF.Top))))
                    {
                        containedObjs.Add(item);
                    }
                }
            }
            return (containedObjs.Count > 0);
        }

        public bool FindLinkableObject(PointF mousePt, Graphics g, float scaleFactor, out object source, out Link link, out int index)
        {
            bool flag;
            index = -1;
            using (List<GraphObj>.Enumerator enumerator = base._graphObjList.GetEnumerator())
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        break;
                    }
                    GraphObj current = enumerator.Current;
                    link = current._link;
                    bool isInFrontOfData = current.IsInFrontOfData;
                    if (link.IsActive && current.PointInBox(mousePt, this, g, scaleFactor))
                    {
                        source = current;
                        return true;
                    }
                }
            }
            using (List<CurveItem>.Enumerator enumerator2 = this._curveList.GetEnumerator())
            {
                while (true)
                {
                    CurveItem item2;
                    if (!enumerator2.MoveNext())
                    {
                        break;
                    }
                    CurveItem current = enumerator2.Current;
                    link = current._link;
                    if (link.IsActive && this.FindNearestPoint(mousePt, current, out item2, out index))
                    {
                        source = current;
                        return true;
                    }
                }
            }
            using (List<GraphObj>.Enumerator enumerator3 = base._graphObjList.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator3.MoveNext())
                    {
                        GraphObj current = enumerator3.Current;
                        link = current._link;
                        bool isInFrontOfData = current.IsInFrontOfData;
                        if (!link.IsActive || !current.PointInBox(mousePt, this, g, scaleFactor))
                        {
                            continue;
                        }
                        source = current;
                        flag = true;
                    }
                    else
                    {
                        source = null;
                        link = null;
                        index = -1;
                        return false;
                    }
                    break;
                }
            }
            return flag;
        }

        public bool FindNearestObject(PointF mousePt, Graphics g, out object nearestObj, out int index)
        {
            nearestObj = null;
            index = -1;
            if (this.AxisRangesValid())
            {
                RectangleF ef;
                float scaleFactor = base.CalcScaleFactor();
                GraphObj obj2 = null;
                int num2 = -1;
                ZOrder zOrder = ZOrder.H_BehindAll;
                RectangleF ef2 = this.CalcChartRect(g, scaleFactor);
                if (base.GraphObjList.FindPoint(mousePt, this, g, scaleFactor, out index))
                {
                    obj2 = base.GraphObjList[index];
                    num2 = index;
                    zOrder = obj2.ZOrder;
                }
                if ((zOrder <= ZOrder.B_BehindLegend) && base.Legend.FindPoint(mousePt, this, scaleFactor, out index))
                {
                    nearestObj = base.Legend;
                    return true;
                }
                SizeF ef3 = base._title._fontSpec.BoundingBox(g, base._title._text, scaleFactor);
                if ((zOrder <= ZOrder.H_BehindAll) && base._title._isVisible)
                {
                    ef = new RectangleF(((base._rect.Left + base._rect.Right) - ef3.Width) / 2f, base._rect.Top + (base._margin.Top * scaleFactor), ef3.Width, ef3.Height);
                    if (ef.Contains(mousePt))
                    {
                        nearestObj = this;
                        return true;
                    }
                }
                float left = ef2.Left;
                int num4 = 0;
                while (true)
                {
                    if (num4 >= this._yAxisList.Count)
                    {
                        left = ef2.Right;
                        int num6 = 0;
                        while (true)
                        {
                            if (num6 >= this._y2AxisList.Count)
                            {
                                CurveItem item;
                                float height = this._xAxis._tmpSpace;
                                ef = new RectangleF(ef2.Left, ef2.Bottom, ef2.Width, height);
                                if ((zOrder <= ZOrder.D_BehindAxis) && ef.Contains(mousePt))
                                {
                                    nearestObj = this.XAxis;
                                    return true;
                                }
                                height = this._x2Axis._tmpSpace;
                                ef = new RectangleF(ef2.Left, ef2.Top - height, ef2.Width, height);
                                if ((zOrder <= ZOrder.D_BehindAxis) && ef.Contains(mousePt))
                                {
                                    nearestObj = this.X2Axis;
                                    return true;
                                }
                                if ((zOrder <= ZOrder.E_BehindCurves) && this.FindNearestPoint(mousePt, out item, out index))
                                {
                                    nearestObj = item;
                                    return true;
                                }
                                if (obj2 == null)
                                {
                                    break;
                                }
                                index = num2;
                                nearestObj = obj2;
                                return true;
                            }
                            Axis axis2 = this._y2AxisList[num6];
                            float num7 = axis2._tmpSpace;
                            if (num7 > 0f)
                            {
                                ef = new RectangleF(left, ef2.Top, num7, ef2.Height);
                                if ((zOrder <= ZOrder.D_BehindAxis) && ef.Contains(mousePt))
                                {
                                    nearestObj = axis2;
                                    index = num6;
                                    return true;
                                }
                                left += num7;
                            }
                            num6++;
                        }
                        break;
                    }
                    Axis axis = this._yAxisList[num4];
                    float width = axis._tmpSpace;
                    if (width > 0f)
                    {
                        ef = new RectangleF(left - width, ef2.Top, width, ef2.Height);
                        if ((zOrder <= ZOrder.D_BehindAxis) && ef.Contains(mousePt))
                        {
                            nearestObj = axis;
                            index = num4;
                            return true;
                        }
                        left -= width;
                    }
                    num4++;
                }
            }
            return false;
        }

        public bool FindNearestPoint(PointF mousePt, out CurveItem nearestCurve, out int iNearest) => 
            this.FindNearestPoint(mousePt, this._curveList, out nearestCurve, out iNearest);

        public bool FindNearestPoint(PointF mousePt, CurveItem targetCurve, out CurveItem nearestCurve, out int iNearest)
        {
            ZedGraph.CurveList targetCurveList = new ZedGraph.CurveList();
            targetCurveList.Add(targetCurve);
            return this.FindNearestPoint(mousePt, targetCurveList, out nearestCurve, out iNearest);
        }

        public bool FindNearestPoint(PointF mousePt, ZedGraph.CurveList targetCurveList, out CurveItem nearestCurve, out int iNearest)
        {
            CurveItem item = null;
            double num2;
            double num3;
            double[] numArray;
            double[] numArray2;
            int num = -1;
            nearestCurve = null;
            iNearest = -1;
            if (!this._chart._rect.Contains(mousePt))
            {
                return false;
            }
            this.ReverseTransform(mousePt, out num2, out num3, out numArray, out numArray2);
            if (!this.AxisRangesValid())
            {
                return false;
            }
            ValueHandler handler = new ValueHandler(this, false);
            double num9 = 1E+20;
            double num12 = 99999.0;
            double num15 = Default.NearestTol * Default.NearestTol;
            int iOrdinal = 0;
            using (List<CurveItem>.Enumerator enumerator = targetCurveList.GetEnumerator())
            {
                double num4;
                double num5;
                double num6;
                double num7;
                double num8;
                CurveItem current;
                Axis yAxis;
                Axis xAxis;
                double num18;
                IPointList points;
                float barWidth;
                double num20;
                bool flag;
                int num21;
                goto TR_002F;
            TR_000E:
                num21++;
            TR_0023:
                while (true)
                {
                    if (num21 >= current.NPts)
                    {
                        if (current.IsBar)
                        {
                            iOrdinal++;
                        }
                        break;
                    }
                    double val = (!xAxis._scale.IsAnyOrdinal || current.IsOverrideOrdinal) ? points[num21].X : (num21 + 1.0);
                    double num11 = (!yAxis._scale.IsAnyOrdinal || current.IsOverrideOrdinal) ? points[num21].Y : (num21 + 1.0);
                    if ((val != double.MaxValue) && (num11 != double.MaxValue))
                    {
                        if (current.IsBar || ((current is ErrorBarItem) || ((current is HiLowBarItem) || ((current is OHLCBarItem) || (current is JapaneseCandleStickItem)))))
                        {
                            double num22;
                            double num23;
                            double num24;
                            handler.GetValues(current, num21, out num22, out num23, out num24);
                            if (num23 > num24)
                            {
                                num23 = num24;
                                num24 = num23;
                            }
                            if (!flag)
                            {
                                double num27 = handler.BarCenterValue(current, barWidth, num21, num11, iOrdinal);
                                if ((num5 < (num27 - num20)) || ((num5 > (num27 + num20)) || ((num8 < num23) || (num8 > num24))))
                                {
                                    goto TR_000E;
                                }
                            }
                            else
                            {
                                double num26 = handler.BarCenterValue(current, barWidth, num21, val, iOrdinal);
                                if ((num8 < (num26 - num20)) || ((num8 > (num26 + num20)) || ((num5 < num23) || (num5 > num24))))
                                {
                                    goto TR_000E;
                                }
                            }
                            if (item == null)
                            {
                                num = num21;
                                item = current;
                            }
                        }
                        else if ((val >= xAxis._scale._min) && ((val <= xAxis._scale._max) && ((num11 >= num6) && (num11 <= num7))))
                        {
                            if ((current is LineItem) && (this._lineType == ZedGraph.LineType.Stack))
                            {
                                double num28;
                                handler.GetValues(current, num21, out val, out num28, out num11);
                            }
                            double num13 = (val - num8) * num18;
                            double num14 = (num11 - num5) * num4;
                            num12 = (num13 * num13) + (num14 * num14);
                            if (num12 < num9)
                            {
                                num9 = num12;
                                iNearest = num21;
                                nearestCurve = current;
                            }
                        }
                    }
                    goto TR_000E;
                }
            TR_002F:
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if ((current is PieItem) && current.IsVisible)
                        {
                            if ((((PieItem) current).SlicePath == null) || !((PieItem) current).SlicePath.IsVisible(mousePt))
                            {
                                continue;
                            }
                            item = current;
                            num = 0;
                            continue;
                        }
                        if (!current.IsVisible)
                        {
                            continue;
                        }
                        int yAxisIndex = current.GetYAxisIndex(this);
                        yAxis = current.GetYAxis(this);
                        xAxis = current.GetXAxis(this);
                        if (current.IsY2Axis)
                        {
                            num5 = numArray2[yAxisIndex];
                            num6 = this._y2AxisList[yAxisIndex]._scale._min;
                            num7 = this._y2AxisList[yAxisIndex]._scale._max;
                        }
                        else
                        {
                            num5 = numArray[yAxisIndex];
                            num6 = this._yAxisList[yAxisIndex]._scale._min;
                            num7 = this._yAxisList[yAxisIndex]._scale._max;
                        }
                        num4 = ((double) this._chart._rect.Height) / (num7 - num6);
                        num18 = ((double) this._chart._rect.Width) / (xAxis._scale._max - xAxis._scale._min);
                        num8 = (xAxis is ZedGraph.XAxis) ? num2 : num3;
                        points = current.Points;
                        barWidth = current.GetBarWidth(this);
                        Axis axis3 = current.BaseAxis(this);
                        flag = (axis3 is ZedGraph.XAxis) || (axis3 is ZedGraph.X2Axis);
                        num20 = !flag ? ((((double) barWidth) / num4) / 2.0) : ((((double) barWidth) / num18) / 2.0);
                        if (points == null)
                        {
                            continue;
                        }
                        num21 = 0;
                    }
                    else
                    {
                        goto TR_0009;
                    }
                    break;
                }
                goto TR_0023;
            }
        TR_0009:
            if (nearestCurve is LineItem)
            {
                float num29 = (((LineItem) nearestCurve).Symbol.Size * base.CalcScaleFactor()) / 2f;
                num9 -= num29 * num29;
                if (num9 < 0.0)
                {
                    num9 = 0.0;
                }
            }
            if ((num9 < num15) || (item == null))
            {
                return (num9 < num15);
            }
            nearestCurve = item;
            iNearest = num;
            return true;
        }

        private void ForceNumTics(Axis axis, int numTics)
        {
            if (axis._scale.MaxAuto)
            {
                int num = axis._scale.CalcNumTics();
                if (num < numTics)
                {
                    axis._scale._maxLinearized += axis._scale._majorStep * (numTics - num);
                }
            }
        }

        public PointF GeneralTransform(PointF ptF, CoordType coord)
        {
            this._xAxis.Scale.SetupScaleData(this, this._xAxis);
            foreach (Axis axis in this._yAxisList)
            {
                axis.Scale.SetupScaleData(this, axis);
            }
            foreach (Axis axis2 in this._y2AxisList)
            {
                axis2.Scale.SetupScaleData(this, axis2);
            }
            return base.TransformCoord((double) ptF.X, (double) ptF.Y, coord);
        }

        public PointF GeneralTransform(double x, double y, CoordType coord)
        {
            this._xAxis.Scale.SetupScaleData(this, this._xAxis);
            foreach (Axis axis in this._yAxisList)
            {
                axis.Scale.SetupScaleData(this, axis);
            }
            foreach (Axis axis2 in this._y2AxisList)
            {
                axis2.Scale.SetupScaleData(this, axis2);
            }
            return base.TransformCoord(x, y, coord);
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 11);
            info.AddValue("xAxis", this._xAxis);
            info.AddValue("x2Axis", this._x2Axis);
            info.AddValue("yAxisList", this._yAxisList);
            info.AddValue("y2AxisList", this._y2AxisList);
            info.AddValue("curveList", this._curveList);
            info.AddValue("chart", this._chart);
            info.AddValue("barSettings", this._barSettings);
            info.AddValue("isIgnoreInitial", this._isIgnoreInitial);
            info.AddValue("isBoundedRanges", this._isBoundedRanges);
            info.AddValue("isIgnoreMissing", this._isIgnoreMissing);
            info.AddValue("isAlignGrids", this._isAlignGrids);
            info.AddValue("lineType", this._lineType);
        }

        private void PickScale(Graphics g, float scaleFactor)
        {
            int numTics = 0;
            this._xAxis._scale.PickScale(this, g, scaleFactor);
            this._x2Axis._scale.PickScale(this, g, scaleFactor);
            foreach (Axis axis in this._yAxisList)
            {
                axis._scale.PickScale(this, g, scaleFactor);
                if (axis._scale.MaxAuto)
                {
                    int num2 = axis._scale.CalcNumTics();
                    numTics = (num2 > numTics) ? num2 : numTics;
                }
            }
            foreach (Axis axis2 in this._y2AxisList)
            {
                axis2._scale.PickScale(this, g, scaleFactor);
                if (axis2._scale.MaxAuto)
                {
                    int num3 = axis2._scale.CalcNumTics();
                    numTics = (num3 > numTics) ? num3 : numTics;
                }
            }
            if (this._isAlignGrids)
            {
                foreach (Axis axis3 in this._yAxisList)
                {
                    this.ForceNumTics(axis3, numTics);
                }
                foreach (Axis axis4 in this._y2AxisList)
                {
                    this.ForceNumTics(axis4, numTics);
                }
            }
        }

        public void ReverseTransform(PointF ptF, out double x, out double y)
        {
            this._xAxis.Scale.SetupScaleData(this, this._xAxis);
            this.YAxis.Scale.SetupScaleData(this, this.YAxis);
            x = this.XAxis.Scale.ReverseTransform(ptF.X);
            y = this.YAxis.Scale.ReverseTransform(ptF.Y);
        }

        public void ReverseTransform(PointF ptF, out double x, out double x2, out double y, out double y2)
        {
            this._xAxis.Scale.SetupScaleData(this, this._xAxis);
            this._x2Axis.Scale.SetupScaleData(this, this._x2Axis);
            this.YAxis.Scale.SetupScaleData(this, this.YAxis);
            this.Y2Axis.Scale.SetupScaleData(this, this.Y2Axis);
            x = this.XAxis.Scale.ReverseTransform(ptF.X);
            x2 = this.X2Axis.Scale.ReverseTransform(ptF.X);
            y = this.YAxis.Scale.ReverseTransform(ptF.Y);
            y2 = this.Y2Axis.Scale.ReverseTransform(ptF.Y);
        }

        public void ReverseTransform(PointF ptF, out double x, out double x2, out double[] y, out double[] y2)
        {
            this._xAxis.Scale.SetupScaleData(this, this._xAxis);
            x = this.XAxis.Scale.ReverseTransform(ptF.X);
            this._x2Axis.Scale.SetupScaleData(this, this._x2Axis);
            x2 = this.X2Axis.Scale.ReverseTransform(ptF.X);
            y = new double[this._yAxisList.Count];
            y2 = new double[this._y2AxisList.Count];
            for (int i = 0; i < this._yAxisList.Count; i++)
            {
                Axis axis = this._yAxisList[i];
                axis.Scale.SetupScaleData(this, axis);
                y[i] = axis.Scale.ReverseTransform(ptF.Y);
            }
            for (int j = 0; j < this._y2AxisList.Count; j++)
            {
                Axis axis = this._y2AxisList[j];
                axis.Scale.SetupScaleData(this, axis);
                y2[j] = axis.Scale.ReverseTransform(ptF.Y);
            }
        }

        public void ReverseTransform(PointF ptF, bool isX2Axis, bool isY2Axis, int yAxisIndex, out double x, out double y)
        {
            Axis axis = this._xAxis;
            if (isX2Axis)
            {
                axis = this._x2Axis;
            }
            axis.Scale.SetupScaleData(this, axis);
            x = axis.Scale.ReverseTransform(ptF.X);
            Axis axis2 = null;
            if (isY2Axis && (this.Y2AxisList.Count > yAxisIndex))
            {
                axis2 = this.Y2AxisList[yAxisIndex];
            }
            else if (!isY2Axis && (this.YAxisList.Count > yAxisIndex))
            {
                axis2 = this.YAxisList[yAxisIndex];
            }
            if (axis2 == null)
            {
                y = double.MaxValue;
            }
            else
            {
                axis2.Scale.SetupScaleData(this, axis2);
                y = axis2.Scale.ReverseTransform(ptF.Y);
            }
        }

        public void SetMinSpaceBuffer(Graphics g, float bufferFraction, bool isGrowOnly)
        {
            this._xAxis.SetMinSpaceBuffer(g, this, bufferFraction, isGrowOnly);
            this._x2Axis.SetMinSpaceBuffer(g, this, bufferFraction, isGrowOnly);
            foreach (Axis axis in this._yAxisList)
            {
                axis.SetMinSpaceBuffer(g, this, bufferFraction, isGrowOnly);
            }
            foreach (Axis axis2 in this._y2AxisList)
            {
                axis2.SetMinSpaceBuffer(g, this, bufferFraction, isGrowOnly);
            }
        }

        private void SetSpace(Axis axis, float clientSize, ref float spaceNorm, ref float spaceAlt)
        {
            float num = axis.CalcCrossFraction(this);
            float num2 = ((num * (1f + num)) * (1f + (num * num))) * clientSize;
            if (!axis.IsPrimary(this) && axis.IsCrossShifted(this))
            {
                axis._tmpSpace = 0f;
            }
            if (axis._tmpSpace < num2)
            {
                axis._tmpSpace = 0f;
            }
            else if (num2 > 0f)
            {
                axis._tmpSpace -= num2;
            }
            if (axis._scale._isLabelsInside && (axis.IsPrimary(this) || ((num != 0.0) && (num != 1.0))))
            {
                spaceAlt = axis._tmpSpace;
            }
            else
            {
                spaceNorm = axis._tmpSpace;
            }
        }

        object ICloneable.Clone() => 
            this.Clone();

        public ZedGraph.CurveList CurveList
        {
            get => 
                this._curveList;
            set => 
                this._curveList = value;
        }

        public ZedGraph.XAxis XAxis =>
            this._xAxis;

        public ZedGraph.X2Axis X2Axis =>
            this._x2Axis;

        public ZedGraph.YAxis YAxis =>
            this._yAxisList[0];

        public ZedGraph.Y2Axis Y2Axis =>
            this._y2AxisList[0];

        public ZedGraph.YAxisList YAxisList =>
            this._yAxisList;

        public ZedGraph.Y2AxisList Y2AxisList =>
            this._y2AxisList;

        public ZedGraph.Chart Chart =>
            this._chart;

        public ZedGraph.BarSettings BarSettings =>
            this._barSettings;

        [NotifyParentProperty(true), Description("Determines whether the auto-ranged scale will include all data points or just the visible data points"), Bindable(true), Browsable(true), Category("Display")]
        public bool IsIgnoreInitial
        {
            get => 
                this._isIgnoreInitial;
            set => 
                this._isIgnoreInitial = value;
        }

        public bool IsBoundedRanges
        {
            get => 
                this._isBoundedRanges;
            set => 
                this._isBoundedRanges = value;
        }

        public bool IsIgnoreMissing
        {
            get => 
                this._isIgnoreMissing;
            set => 
                this._isIgnoreMissing = value;
        }

        public bool IsAlignGrids
        {
            get => 
                this._isAlignGrids;
            set => 
                this._isAlignGrids = value;
        }

        public ZedGraph.LineType LineType
        {
            get => 
                this._lineType;
            set => 
                this._lineType = value;
        }

        public bool IsZoomed =>
            !this._zoomStack.IsEmpty;

        public ZoomStateStack ZoomStack =>
            this._zoomStack;

        public delegate void AxisChangeEventHandler(GraphPane pane);

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static bool IsIgnoreInitial;
            public static bool IsBoundedRanges;
            public static ZedGraph.LineType LineType;
            public static double ClusterScaleWidth;
            public static double NearestTol;
            static Default()
            {
                IsIgnoreInitial = false;
                IsBoundedRanges = false;
                LineType = ZedGraph.LineType.Normal;
                ClusterScaleWidth = 1.0;
                NearestTol = 7.0;
            }
        }
    }
}

