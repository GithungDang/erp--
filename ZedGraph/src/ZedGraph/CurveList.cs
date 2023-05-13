namespace ZedGraph
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;

    [Serializable]
    public class CurveList : List<CurveItem>, ICloneable
    {
        private int maxPts;

        public CurveList()
        {
            this.maxPts = 1;
        }

        public CurveList(CurveList rhs)
        {
            this.maxPts = rhs.maxPts;
            foreach (CurveItem item in rhs)
            {
                base.Add((CurveItem) ((ICloneable) item).Clone());
            }
        }

        public CurveList Clone() => 
            new CurveList(this);

        public void Draw(Graphics g, GraphPane pane, float scaleFactor)
        {
            int numBars = this.NumBars;
            if (pane._barSettings.Type == BarType.SortedOverlay)
            {
                CurveList list = new CurveList();
                foreach (CurveItem item in this)
                {
                    if (item.IsBar)
                    {
                        list.Add(item);
                    }
                }
                for (int j = 0; j < this.maxPts; j++)
                {
                    list.Sort((pane._barSettings.Base == BarBase.X) ? SortType.YValues : SortType.XValues, j);
                    foreach (BarItem item2 in list)
                    {
                        item2.Bar.DrawSingleBar(g, pane, item2, item2.BaseAxis(pane), item2.ValueAxis(pane), 0, j, item2.GetBarWidth(pane), scaleFactor);
                    }
                }
            }
            for (int i = base.Count - 1; i >= 0; i--)
            {
                CurveItem item3 = base[i];
                if (item3.IsBar)
                {
                    numBars--;
                }
                if (!item3.IsBar || (pane._barSettings.Type != BarType.SortedOverlay))
                {
                    item3.Draw(g, pane, numBars, scaleFactor);
                }
            }
        }

        public int GetBarItemPos(GraphPane pane, BarItem barItem)
        {
            int num2;
            if ((pane._barSettings.Type == BarType.Overlay) || ((pane._barSettings.Type == BarType.Stack) || (pane._barSettings.Type == BarType.PercentStack)))
            {
                return 0;
            }
            int num = 0;
            using (List<CurveItem>.Enumerator enumerator = base.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        CurveItem current = enumerator.Current;
                        if (!ReferenceEquals(current, barItem))
                        {
                            if (!(current is BarItem))
                            {
                                continue;
                            }
                            num++;
                            continue;
                        }
                        num2 = num;
                    }
                    else
                    {
                        return -1;
                    }
                    break;
                }
            }
            return num2;
        }

        public void GetRange(bool bIgnoreInitial, bool isBoundedRanges, GraphPane pane)
        {
            this.InitScale(pane.XAxis.Scale, isBoundedRanges);
            this.InitScale(pane.X2Axis.Scale, isBoundedRanges);
            foreach (YAxis axis in pane.YAxisList)
            {
                this.InitScale(axis.Scale, isBoundedRanges);
            }
            foreach (Y2Axis axis2 in pane.Y2AxisList)
            {
                this.InitScale(axis2.Scale, isBoundedRanges);
            }
            this.maxPts = 1;
            foreach (CurveItem item in this)
            {
                if (item.IsVisible)
                {
                    double num;
                    double nPts;
                    double num3;
                    double nPts;
                    if (((item is BarItem) && ((pane._barSettings.Type == BarType.Stack) || (pane._barSettings.Type == BarType.PercentStack))) || ((item is LineItem) && (pane.LineType == LineType.Stack)))
                    {
                        this.GetStackRange(pane, item, out num, out num3, out nPts, out nPts);
                    }
                    else
                    {
                        item.GetRange(out num, out nPts, out num3, out nPts, bIgnoreInitial, true, pane);
                    }
                    Scale scale = item.GetYAxis(pane).Scale;
                    Scale scale2 = item.GetXAxis(pane).Scale;
                    bool isAnyOrdinal = scale.IsAnyOrdinal;
                    bool flag2 = scale2.IsAnyOrdinal;
                    if (isAnyOrdinal && !item.IsOverrideOrdinal)
                    {
                        num3 = 1.0;
                        nPts = item.NPts;
                    }
                    if (flag2 && !item.IsOverrideOrdinal)
                    {
                        num = 1.0;
                        nPts = item.NPts;
                    }
                    if (item.IsBar)
                    {
                        if ((pane._barSettings.Base != BarBase.X) && (pane._barSettings.Base != BarBase.X2))
                        {
                            if (!(item is HiLowBarItem))
                            {
                                if (num > 0.0)
                                {
                                    num = 0.0;
                                }
                                else if (nPts < 0.0)
                                {
                                    nPts = 0.0;
                                }
                            }
                            if (!isAnyOrdinal)
                            {
                                num3 -= pane._barSettings._clusterScaleWidth / 2.0;
                                nPts += pane._barSettings._clusterScaleWidth / 2.0;
                            }
                        }
                        else
                        {
                            if (!(item is HiLowBarItem))
                            {
                                if (num3 > 0.0)
                                {
                                    num3 = 0.0;
                                }
                                else if (nPts < 0.0)
                                {
                                    nPts = 0.0;
                                }
                            }
                            if (!flag2)
                            {
                                num -= pane._barSettings._clusterScaleWidth / 2.0;
                                nPts += pane._barSettings._clusterScaleWidth / 2.0;
                            }
                        }
                    }
                    if (item.NPts > this.maxPts)
                    {
                        this.maxPts = item.NPts;
                    }
                    if (num3 < scale._rangeMin)
                    {
                        scale._rangeMin = num3;
                    }
                    if (nPts > scale._rangeMax)
                    {
                        scale._rangeMax = nPts;
                    }
                    if (num < scale2._rangeMin)
                    {
                        scale2._rangeMin = num;
                    }
                    if (nPts > scale2._rangeMax)
                    {
                        scale2._rangeMax = nPts;
                    }
                }
            }
            pane.XAxis.Scale.SetRange(pane, pane.XAxis);
            pane.X2Axis.Scale.SetRange(pane, pane.X2Axis);
            foreach (YAxis axis3 in pane.YAxisList)
            {
                axis3.Scale.SetRange(pane, axis3);
            }
            foreach (Y2Axis axis4 in pane.Y2AxisList)
            {
                axis4.Scale.SetRange(pane, axis4);
            }
        }

        private void GetStackRange(GraphPane pane, CurveItem curve, out double tXMinVal, out double tYMinVal, out double tXMaxVal, out double tYMaxVal)
        {
            tXMinVal = tYMinVal = double.MaxValue;
            tXMaxVal = tYMaxVal = double.MinValue;
            ValueHandler handler = new ValueHandler(pane, false);
            Axis axis = curve.BaseAxis(pane);
            bool flag = (axis is XAxis) || (axis is X2Axis);
            for (int i = 0; i < curve.Points.Count; i++)
            {
                double num;
                double num2;
                double num3;
                handler.GetValues(curve, i, out num2, out num, out num3);
                double num5 = flag ? num2 : num3;
                double num6 = flag ? num3 : num2;
                if ((num5 != double.MaxValue) && ((num6 != double.MaxValue) && (num != double.MaxValue)))
                {
                    if (num5 < tXMinVal)
                    {
                        tXMinVal = num5;
                    }
                    if (num5 > tXMaxVal)
                    {
                        tXMaxVal = num5;
                    }
                    if (num6 < tYMinVal)
                    {
                        tYMinVal = num6;
                    }
                    if (num6 > tYMaxVal)
                    {
                        tYMaxVal = num6;
                    }
                    if (!flag)
                    {
                        if (num < tXMinVal)
                        {
                            tXMinVal = num;
                        }
                        if (num > tXMaxVal)
                        {
                            tXMaxVal = num;
                        }
                    }
                    else
                    {
                        if (num < tYMinVal)
                        {
                            tYMinVal = num;
                        }
                        if (num > tYMaxVal)
                        {
                            tYMaxVal = num;
                        }
                    }
                }
            }
        }

        public bool HasData()
        {
            bool flag;
            using (List<CurveItem>.Enumerator enumerator = base.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        CurveItem current = enumerator.Current;
                        if (current.Points.Count <= 0)
                        {
                            continue;
                        }
                        flag = true;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                }
            }
            return flag;
        }

        public int IndexOf(string label)
        {
            int num2;
            int num = 0;
            using (List<CurveItem>.Enumerator enumerator = base.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        CurveItem current = enumerator.Current;
                        if (string.Compare(current._label._text, label, true) != 0)
                        {
                            num++;
                            continue;
                        }
                        num2 = num;
                    }
                    else
                    {
                        return -1;
                    }
                    break;
                }
            }
            return num2;
        }

        public int IndexOfTag(string tag)
        {
            int num2;
            int num = 0;
            using (List<CurveItem>.Enumerator enumerator = base.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        CurveItem current = enumerator.Current;
                        if (!(current.Tag is string) || (string.Compare((string) current.Tag, tag, true) != 0))
                        {
                            num++;
                            continue;
                        }
                        num2 = num;
                    }
                    else
                    {
                        return -1;
                    }
                    break;
                }
            }
            return num2;
        }

        private void InitScale(Scale scale, bool isBoundedRanges)
        {
            scale._rangeMin = double.MaxValue;
            scale._rangeMax = double.MinValue;
            scale._lBound = (!isBoundedRanges || scale._minAuto) ? double.MinValue : scale._min;
            scale._uBound = (!isBoundedRanges || scale._maxAuto) ? double.MaxValue : scale._max;
        }

        public int Move(int index, int relativePos)
        {
            if ((index < 0) || (index >= base.Count))
            {
                return -1;
            }
            CurveItem item = base[index];
            base.RemoveAt(index);
            index += relativePos;
            if (index < 0)
            {
                index = 0;
            }
            if (index > base.Count)
            {
                index = base.Count;
            }
            base.Insert(index, item);
            return index;
        }

        public void Sort(SortType type, int index)
        {
            base.Sort(new CurveItem.Comparer(type, index));
        }

        object ICloneable.Clone() => 
            this.Clone();

        public int MaxPts =>
            this.maxPts;

        public int NumBars
        {
            get
            {
                int num = 0;
                foreach (CurveItem item in this)
                {
                    if (item.IsBar)
                    {
                        num++;
                    }
                }
                return num;
            }
        }

        public int NumClusterableBars
        {
            get
            {
                int num = 0;
                foreach (CurveItem item in this)
                {
                    if (item.IsBar || (item is HiLowBarItem))
                    {
                        num++;
                    }
                }
                return num;
            }
        }

        public int NumPies
        {
            get
            {
                int num = 0;
                foreach (CurveItem item in this)
                {
                    if (item.IsPie)
                    {
                        num++;
                    }
                }
                return num;
            }
        }

        public bool IsPieOnly
        {
            get
            {
                bool flag2;
                bool flag = false;
                using (List<CurveItem>.Enumerator enumerator = base.GetEnumerator())
                {
                    while (true)
                    {
                        if (enumerator.MoveNext())
                        {
                            CurveItem current = enumerator.Current;
                            if (current.IsPie)
                            {
                                flag = true;
                                continue;
                            }
                            flag2 = false;
                        }
                        else
                        {
                            return flag;
                        }
                        break;
                    }
                }
                return flag2;
            }
        }

        public IEnumerable<CurveItem> Backward
        {
            get
            {
                int iteratorVariable0 = this.Count - 1;
                while (true)
                {
                    if (iteratorVariable0 < 0)
                    {
                        yield break;
                    }
                    yield return this[iteratorVariable0];
                    iteratorVariable0--;
                }
            }
        }

        public IEnumerable<CurveItem> Forward
        {
            get
            {
                int iteratorVariable0 = 0;
                while (true)
                {
                    if (iteratorVariable0 >= this.Count)
                    {
                        yield break;
                    }
                    yield return this[iteratorVariable0];
                    iteratorVariable0++;
                }
            }
        }

        public CurveItem this[string label]
        {
            get
            {
                int index = this.IndexOf(label);
                return ((index < 0) ? null : base[index]);
            }
        }


    }
}

