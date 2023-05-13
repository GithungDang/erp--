namespace ZedGraph
{
    using System;
    using System.Runtime.InteropServices;

    public class ValueHandler
    {
        private GraphPane _pane;

        public ValueHandler(GraphPane pane, bool initialize)
        {
            this._pane = pane;
            if (initialize)
            {
                using (pane.GetImage())
                {
                }
            }
        }

        public double BarCenterValue(CurveItem curve, float barWidth, int iCluster, double val, int iOrdinal)
        {
            Axis axis = curve.BaseAxis(this._pane);
            if ((curve is ErrorBarItem) || ((curve is HiLowBarItem) || ((curve is OHLCBarItem) || (curve is JapaneseCandleStickItem))))
            {
                return ((!axis._scale.IsAnyOrdinal || ((iCluster < 0) || curve.IsOverrideOrdinal)) ? val : (iCluster + 1.0));
            }
            float clusterWidth = this._pane._barSettings.GetClusterWidth();
            float num2 = this._pane._barSettings.MinClusterGap * barWidth;
            float num3 = barWidth * this._pane._barSettings.MinBarGap;
            if (curve.IsBar && (this._pane._barSettings.Type != BarType.Cluster))
            {
                iOrdinal = 0;
            }
            float pixVal = (((axis.Scale.Transform(curve.IsOverrideOrdinal, iCluster, val) - (clusterWidth / 2f)) + (num2 / 2f)) + (iOrdinal * (barWidth + num3))) + (0.5f * barWidth);
            return axis.Scale.ReverseTransform(pixVal);
        }

        public bool GetValues(CurveItem curve, int iPt, out double baseVal, out double lowVal, out double hiVal) => 
            GetValues(this._pane, curve, iPt, out baseVal, out lowVal, out hiVal);

        public static bool GetValues(GraphPane pane, CurveItem curve, int iPt, out double baseVal, out double lowVal, out double hiVal)
        {
            hiVal = double.MaxValue;
            lowVal = double.MaxValue;
            baseVal = double.MaxValue;
            if ((curve == null) || ((curve.Points.Count <= iPt) || !curve.IsVisible))
            {
                return false;
            }
            Axis axis = curve.BaseAxis(pane);
            Axis axis2 = curve.ValueAxis(pane);
            baseVal = ((axis is XAxis) || (axis is X2Axis)) ? curve.Points[iPt].X : curve.Points[iPt].Y;
            switch (pane._barSettings.Type)
            {
                case ((BarItem _) && ((pane._barSettings.Type == BarType.Stack) || (pane._barSettings.Type == BarType.PercentStack))):
                    break;

                case ((LineItem _) && (pane.LineType == LineType.Stack)):
                    break;

                default:
                    lowVal = ((curve is HiLowBarItem) || (curve is ErrorBarItem)) ? curve.Points[iPt].LowValue : 0.0;
                    hiVal = ((axis is XAxis) || (axis is X2Axis)) ? curve.Points[iPt].Y : curve.Points[iPt].X;
                    if ((curve is BarItem) && (axis2._scale.IsLog && (lowVal == 0.0)))
                    {
                        lowVal = axis2._scale._min;
                    }
                    return ((baseVal != double.MaxValue) && ((hiVal != double.MaxValue) && ((lowVal != double.MaxValue) || (!(curve is ErrorBarItem) && !(curve is HiLowBarItem)))));
                    break;
            }
            double num = 0.0;
            double num2 = 0.0;
            foreach (CurveItem item in pane.CurveList)
            {
                if (item.IsBar && item.IsVisible)
                {
                    double maxValue = double.MaxValue;
                    if (!curve.IsOverrideOrdinal && axis._scale.IsAnyOrdinal)
                    {
                        if (iPt < item.Points.Count)
                        {
                            maxValue = ((axis is XAxis) || (axis is X2Axis)) ? item.Points[iPt].Y : item.Points[iPt].X;
                        }
                    }
                    else
                    {
                        IPointList points = item.Points;
                        int num4 = 0;
                        while (num4 < points.Count)
                        {
                            if (((axis is XAxis) || (axis is X2Axis)) && (points[num4].X == baseVal))
                            {
                                maxValue = points[num4].Y;
                            }
                            else
                            {
                                if ((axis is XAxis) || ((axis is X2Axis) || (points[num4].Y != baseVal)))
                                {
                                    num4++;
                                    continue;
                                }
                                maxValue = points[num4].X;
                            }
                            break;
                        }
                    }
                    if (maxValue == double.MaxValue)
                    {
                        num = double.MaxValue;
                        num2 = double.MaxValue;
                    }
                    if (ReferenceEquals(item, curve))
                    {
                        if (maxValue >= 0.0)
                        {
                            lowVal = num;
                            hiVal = ((maxValue == double.MaxValue) || (num == double.MaxValue)) ? double.MaxValue : (num + maxValue);
                        }
                        else
                        {
                            hiVal = num2;
                            lowVal = ((maxValue == double.MaxValue) || (num2 == double.MaxValue)) ? double.MaxValue : (num2 + maxValue);
                        }
                    }
                    if (maxValue >= 0.0)
                    {
                        num = ((maxValue == double.MaxValue) || (num == double.MaxValue)) ? double.MaxValue : (num + maxValue);
                    }
                    else
                    {
                        num2 = ((maxValue == double.MaxValue) || (num2 == double.MaxValue)) ? double.MaxValue : (num2 + maxValue);
                    }
                }
            }
            if ((pane._barSettings.Type == BarType.PercentStack) && ((hiVal != double.MaxValue) && (lowVal != double.MaxValue)))
            {
                num += Math.Abs(num2);
                if (num != 0.0)
                {
                    lowVal = (lowVal / num) * 100.0;
                    hiVal = (hiVal / num) * 100.0;
                }
                else
                {
                    lowVal = 0.0;
                    hiVal = 0.0;
                }
            }
            return ((baseVal != double.MaxValue) && ((lowVal != double.MaxValue) && (hiVal != double.MaxValue)));
        }
    }
}

