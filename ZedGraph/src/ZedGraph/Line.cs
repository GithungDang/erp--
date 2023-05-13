namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class Line : LineBase, ICloneable, ISerializable
    {
        public const int schema = 14;
        private bool _isSmooth;
        private float _smoothTension;
        private ZedGraph.StepType _stepType;
        private ZedGraph.Fill _fill;
        private bool _isOptimizedDraw;

        public Line() : this(Color.Empty)
        {
        }

        public Line(Color color)
        {
            this._color = color.IsEmpty ? Default.Color : color;
            this._stepType = Default.StepType;
            this._isSmooth = Default.IsSmooth;
            this._smoothTension = Default.SmoothTension;
            this._fill = new ZedGraph.Fill(Default.FillColor, Default.FillBrush, Default.FillType);
            this._isOptimizedDraw = Default.IsOptimizedDraw;
        }

        public Line(Line rhs) : base(rhs)
        {
            base._color = rhs._color;
            this._stepType = rhs._stepType;
            this._isSmooth = rhs._isSmooth;
            this._smoothTension = rhs._smoothTension;
            this._fill = rhs._fill.Clone();
            this._isOptimizedDraw = rhs._isOptimizedDraw;
        }

        protected Line(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            int num = info.GetInt32("schema");
            this._stepType = (ZedGraph.StepType) info.GetValue("stepType", typeof(ZedGraph.StepType));
            this._isSmooth = info.GetBoolean("isSmooth");
            this._smoothTension = info.GetSingle("smoothTension");
            this._fill = (ZedGraph.Fill) info.GetValue("fill", typeof(ZedGraph.Fill));
            if (num >= 13)
            {
                this._isOptimizedDraw = info.GetBoolean("isOptimizedDraw");
            }
        }

        public bool BuildLowPointsArray(GraphPane pane, CurveItem curve, out PointF[] arrPoints, out int count)
        {
            arrPoints = null;
            count = 0;
            IPointList points = curve.Points;
            if (!base.IsVisible || (base.Color.IsEmpty || (points == null)))
            {
                return false;
            }
            int index = 0;
            float num4 = 0f;
            float num5 = 0f;
            ValueHandler handler = new ValueHandler(pane, false);
            arrPoints = new PointF[((((this._stepType == ZedGraph.StepType.NonStep) ? 1 : 2) * ((pane.LineType == LineType.Stack) ? 2 : 1)) * points.Count) + 1];
            for (int i = points.Count - 1; i >= 0; i--)
            {
                if (!points[i].IsInvalid)
                {
                    double num6;
                    double num7;
                    double num8;
                    handler.GetValues(curve, i, out num6, out num7, out num8);
                    if ((num6 != double.MaxValue) && (num7 != double.MaxValue))
                    {
                        float num2 = curve.GetXAxis(pane).Scale.Transform(curve.IsOverrideOrdinal, i, num6);
                        float num3 = curve.GetYAxis(pane).Scale.Transform(curve.IsOverrideOrdinal, i, num7);
                        if (this._isSmooth || ((index == 0) || (this.StepType == ZedGraph.StepType.NonStep)))
                        {
                            arrPoints[index].X = num2;
                            arrPoints[index].Y = num3;
                        }
                        else if (this.StepType == ZedGraph.StepType.ForwardStep)
                        {
                            arrPoints[index].X = num2;
                            arrPoints[index].Y = num5;
                            index++;
                            arrPoints[index].X = num2;
                            arrPoints[index].Y = num3;
                        }
                        else if (this.StepType == ZedGraph.StepType.RearwardStep)
                        {
                            arrPoints[index].X = num4;
                            arrPoints[index].Y = num3;
                            index++;
                            arrPoints[index].X = num2;
                            arrPoints[index].Y = num3;
                        }
                        num4 = num2;
                        num5 = num3;
                        index++;
                    }
                }
            }
            if (index == 0)
            {
                return false;
            }
            arrPoints[index] = arrPoints[index - 1];
            index++;
            count = index;
            return true;
        }

        public bool BuildPointsArray(GraphPane pane, CurveItem curve, out PointF[] arrPoints, out int count)
        {
            arrPoints = null;
            count = 0;
            IPointList points = curve.Points;
            if (!base.IsVisible || (base.Color.IsEmpty || (points == null)))
            {
                return false;
            }
            int index = 0;
            float num4 = 0f;
            float num5 = 0f;
            ValueHandler handler = new ValueHandler(pane, false);
            arrPoints = new PointF[(((this._stepType == ZedGraph.StepType.NonStep) ? 1 : 2) * points.Count) + 1];
            for (int i = 0; i < points.Count; i++)
            {
                if (!points[i].IsInvalid)
                {
                    double x;
                    double y;
                    if (pane.LineType == LineType.Stack)
                    {
                        double num8;
                        handler.GetValues(curve, i, out x, out num8, out y);
                    }
                    else
                    {
                        x = points[i].X;
                        y = points[i].Y;
                    }
                    if ((x != double.MaxValue) && (y != double.MaxValue))
                    {
                        float num2 = curve.GetXAxis(pane).Scale.Transform(curve.IsOverrideOrdinal, i, x);
                        float num3 = curve.GetYAxis(pane).Scale.Transform(curve.IsOverrideOrdinal, i, y);
                        if ((num2 >= -1000000f) && ((num3 >= -1000000f) && ((num2 <= 1000000f) && (num3 <= 1000000f))))
                        {
                            if (this._isSmooth || ((index == 0) || (this.StepType == ZedGraph.StepType.NonStep)))
                            {
                                arrPoints[index].X = num2;
                                arrPoints[index].Y = num3;
                            }
                            else if ((this.StepType == ZedGraph.StepType.ForwardStep) || (this.StepType == ZedGraph.StepType.ForwardSegment))
                            {
                                arrPoints[index].X = num2;
                                arrPoints[index].Y = num5;
                                index++;
                                arrPoints[index].X = num2;
                                arrPoints[index].Y = num3;
                            }
                            else if ((this.StepType == ZedGraph.StepType.RearwardStep) || (this.StepType == ZedGraph.StepType.RearwardSegment))
                            {
                                arrPoints[index].X = num4;
                                arrPoints[index].Y = num3;
                                index++;
                                arrPoints[index].X = num2;
                                arrPoints[index].Y = num3;
                            }
                            num4 = num2;
                            num5 = num3;
                            index++;
                        }
                    }
                }
            }
            if (index == 0)
            {
                return false;
            }
            arrPoints[index] = arrPoints[index - 1];
            index++;
            count = index;
            return true;
        }

        public Line Clone() => 
            new Line(this);

        public void CloseCurve(GraphPane pane, CurveItem curve, PointF[] arrPoints, int count, double yMin, GraphicsPath path)
        {
            if (pane.LineType != LineType.Stack)
            {
                float num = curve.GetYAxis(pane).Scale.Transform(yMin);
                path.AddLine(arrPoints[count - 1].X, arrPoints[count - 1].Y, arrPoints[count - 1].X, num);
                path.AddLine(arrPoints[count - 1].X, num, arrPoints[0].X, num);
                path.AddLine(arrPoints[0].X, num, arrPoints[0].X, arrPoints[0].Y);
            }
            else
            {
                PointF[] tfArray;
                int num2;
                float tension = this._isSmooth ? this._smoothTension : 0f;
                int index = pane.CurveList.IndexOf(curve);
                if (index > 0)
                {
                    for (int i = index - 1; i >= 0; i--)
                    {
                        CurveItem item = pane.CurveList[i];
                        if (item is LineItem)
                        {
                            tension = ((LineItem) item).Line.IsSmooth ? ((LineItem) item).Line.SmoothTension : 0f;
                            break;
                        }
                    }
                }
                this.BuildLowPointsArray(pane, curve, out tfArray, out num2);
                path.AddCurve(tfArray, 0, num2 - 2, tension);
            }
        }

        public void Draw(Graphics g, GraphPane pane, CurveItem curve, float scaleFactor)
        {
            if (base.IsVisible)
            {
                SmoothingMode smoothingMode = g.SmoothingMode;
                if (base._isAntiAlias)
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                }
                if (curve is StickItem)
                {
                    this.DrawSticks(g, pane, curve, scaleFactor);
                }
                else if (!this.IsSmooth && !this.Fill.IsVisible)
                {
                    this.DrawCurve(g, pane, curve, scaleFactor);
                }
                else
                {
                    this.DrawSmoothFilledCurve(g, pane, curve, scaleFactor);
                }
                g.SmoothingMode = smoothingMode;
            }
        }

        public void DrawCurve(Graphics g, GraphPane pane, CurveItem curve, float scaleFactor)
        {
            Line line = this;
            if (curve.IsSelected)
            {
                line = Selection.Line;
            }
            int num3 = 0x7fffffff;
            int num4 = 0x7fffffff;
            PointPair lastPt = new PointPair();
            bool flag = true;
            IPointList points = curve.Points;
            ValueHandler handler = new ValueHandler(pane, false);
            Axis yAxis = curve.GetYAxis(pane);
            Axis xAxis = curve.GetXAxis(pane);
            bool isLog = xAxis._scale.IsLog;
            bool flag3 = yAxis._scale.IsLog;
            int left = (int) pane.Chart.Rect.Left;
            int right = (int) pane.Chart.Rect.Right;
            int top = (int) pane.Chart.Rect.Top;
            int bottom = (int) pane.Chart.Rect.Bottom;
            using (Pen pen = line.GetPen(pane, scaleFactor))
            {
                int num;
                int num2;
                PointPair pair;
                bool flag4;
                bool flag5;
                bool[,] flagArray;
                int num12;
                if (points == null)
                {
                    return;
                }
                else if (base._color.IsEmpty)
                {
                    return;
                }
                else if (!base.IsVisible)
                {
                    return;
                }
                else
                {
                    flag5 = this._isOptimizedDraw && (points.Count > 0x3e8);
                    flagArray = null;
                    if (flag5)
                    {
                        flagArray = new bool[right + 1, bottom + 1];
                    }
                    num12 = 0;
                }
                goto TR_0032;
            TR_0004:
                num12++;
                goto TR_0032;
            TR_0005:
                lastPt = pair;
                num3 = num;
                num4 = num2;
                flag = false;
                goto TR_0004;
            TR_0024:
                flag4 = (((num < left) && (num3 < left)) || (((num > right) && (num3 > right)) || ((num2 < top) && (num4 < top)))) || ((num2 > bottom) && (num4 > bottom));
                if (!flag)
                {
                    try
                    {
                        if ((num3 > 0x4c4b40) || ((num3 < -5000000) || ((num4 > 0x4c4b40) || ((num4 < -5000000) || ((num > 0x4c4b40) || ((num < -5000000) || ((num2 > 0x4c4b40) || (num2 < -5000000))))))))
                        {
                            this.InterpolatePoint(g, pane, curve, lastPt, scaleFactor, pen, (float) num3, (float) num4, (float) num, (float) num2);
                        }
                        else if (!flag4)
                        {
                            if (curve.IsSelected || !base._gradientFill.IsGradientValueType)
                            {
                                if (this.StepType == ZedGraph.StepType.NonStep)
                                {
                                    g.DrawLine(pen, num3, num4, num, num2);
                                }
                                else if (this.StepType == ZedGraph.StepType.ForwardStep)
                                {
                                    g.DrawLine(pen, num3, num4, num, num4);
                                    g.DrawLine(pen, num, num4, num, num2);
                                }
                                else if (this.StepType == ZedGraph.StepType.RearwardStep)
                                {
                                    g.DrawLine(pen, num3, num4, num3, num2);
                                    g.DrawLine(pen, num3, num2, num, num2);
                                }
                                else if (this.StepType == ZedGraph.StepType.ForwardSegment)
                                {
                                    g.DrawLine(pen, num3, num4, num, num4);
                                }
                                else if (this.StepType == ZedGraph.StepType.RearwardSegment)
                                {
                                    g.DrawLine(pen, num3, num2, num, num2);
                                }
                            }
                            else
                            {
                                using (Pen pen2 = base.GetPen(pane, scaleFactor, lastPt))
                                {
                                    if (this.StepType == ZedGraph.StepType.NonStep)
                                    {
                                        g.DrawLine(pen2, num3, num4, num, num2);
                                    }
                                    else if (this.StepType == ZedGraph.StepType.ForwardStep)
                                    {
                                        g.DrawLine(pen2, num3, num4, num, num4);
                                        g.DrawLine(pen2, num, num4, num, num2);
                                    }
                                    else if (this.StepType == ZedGraph.StepType.RearwardStep)
                                    {
                                        g.DrawLine(pen2, num3, num4, num3, num2);
                                        g.DrawLine(pen2, num3, num2, num, num2);
                                    }
                                    else if (this.StepType == ZedGraph.StepType.ForwardSegment)
                                    {
                                        g.DrawLine(pen2, num3, num4, num, num4);
                                    }
                                    else
                                    {
                                        g.DrawLine(pen2, num3, num2, num, num2);
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        this.InterpolatePoint(g, pane, curve, lastPt, scaleFactor, pen, (float) num3, (float) num4, (float) num, (float) num2);
                    }
                }
                goto TR_0005;
            TR_0032:
                while (true)
                {
                    double x;
                    double y;
                    if (num12 >= points.Count)
                    {
                        break;
                    }
                    pair = points[num12];
                    if (pane.LineType != LineType.Stack)
                    {
                        x = pair.X;
                        y = pair.Y;
                    }
                    else
                    {
                        double num7;
                        if (!handler.GetValues(curve, num12, out x, out num7, out y))
                        {
                            x = double.MaxValue;
                            y = double.MaxValue;
                        }
                    }
                    if (((x == double.MaxValue) || ((y == double.MaxValue) || (double.IsNaN(x) || (double.IsNaN(y) || (double.IsInfinity(x) || (double.IsInfinity(y) || (isLog && (x <= 0.0)))))))) || (flag3 && (y <= 0.0)))
                    {
                        flag = flag || !pane.IsIgnoreMissing;
                        flag4 = true;
                    }
                    else
                    {
                        num = (int) xAxis.Scale.Transform(curve.IsOverrideOrdinal, num12, x);
                        num2 = (int) yAxis.Scale.Transform(curve.IsOverrideOrdinal, num12, y);
                        if (!flag5 || ((num < left) || ((num > right) || ((num2 < top) || (num2 > bottom)))))
                        {
                            goto TR_0024;
                        }
                        else if (!flagArray[num, num2])
                        {
                            flagArray[num, num2] = true;
                            goto TR_0024;
                        }
                    }
                    goto TR_0004;
                }
            }
        }

        public void DrawCurveOriginal(Graphics g, GraphPane pane, CurveItem curve, float scaleFactor)
        {
            Line line = this;
            if (curve.IsSelected)
            {
                line = Selection.Line;
            }
            float maxValue = float.MaxValue;
            float lastY = float.MaxValue;
            PointPair lastPt = new PointPair();
            bool flag = true;
            IPointList points = curve.Points;
            ValueHandler handler = new ValueHandler(pane, false);
            Axis yAxis = curve.GetYAxis(pane);
            Axis xAxis = curve.GetXAxis(pane);
            bool isLog = xAxis._scale.IsLog;
            bool flag3 = yAxis._scale.IsLog;
            float left = pane.Chart.Rect.Left;
            float right = pane.Chart.Rect.Right;
            float top = pane.Chart.Rect.Top;
            float bottom = pane.Chart.Rect.Bottom;
            using (Pen pen = line.GetPen(pane, scaleFactor))
            {
                float num;
                float num2;
                PointPair pair;
                int num12;
                if (points == null)
                {
                    return;
                }
                else if (base._color.IsEmpty)
                {
                    return;
                }
                else if (!base.IsVisible)
                {
                    return;
                }
                else
                {
                    num12 = 0;
                }
                goto TR_002E;
            TR_0004:
                num12++;
                goto TR_002E;
            TR_0005:
                lastPt = pair;
                maxValue = num;
                lastY = num2;
                flag = false;
                goto TR_0004;
            TR_002E:
                while (true)
                {
                    double x;
                    double y;
                    bool flag4;
                    if (num12 >= points.Count)
                    {
                        break;
                    }
                    pair = points[num12];
                    if (pane.LineType != LineType.Stack)
                    {
                        x = pair.X;
                        y = pair.Y;
                    }
                    else
                    {
                        double num7;
                        if (!handler.GetValues(curve, num12, out x, out num7, out y))
                        {
                            x = double.MaxValue;
                            y = double.MaxValue;
                        }
                    }
                    if (((x == double.MaxValue) || ((y == double.MaxValue) || (double.IsNaN(x) || (double.IsNaN(y) || (double.IsInfinity(x) || (double.IsInfinity(y) || (isLog && (x <= 0.0)))))))) || (flag3 && (y <= 0.0)))
                    {
                        flag = flag || !pane.IsIgnoreMissing;
                        flag4 = true;
                        goto TR_0004;
                    }
                    else
                    {
                        num = xAxis.Scale.Transform(curve.IsOverrideOrdinal, num12, x);
                        num2 = yAxis.Scale.Transform(curve.IsOverrideOrdinal, num12, y);
                        flag4 = (((num < left) && (maxValue < left)) || (((num > right) && (maxValue > right)) || ((num2 < top) && (lastY < top)))) || ((num2 > bottom) && (lastY > bottom));
                        if (!flag)
                        {
                            try
                            {
                                if ((maxValue > 5000000f) || ((maxValue < -5000000f) || ((lastY > 5000000f) || ((lastY < -5000000f) || ((num > 5000000f) || ((num < -5000000f) || ((num2 > 5000000f) || (num2 < -5000000f))))))))
                                {
                                    this.InterpolatePoint(g, pane, curve, lastPt, scaleFactor, pen, maxValue, lastY, num, num2);
                                }
                                else if (!flag4)
                                {
                                    if (curve.IsSelected || !base._gradientFill.IsGradientValueType)
                                    {
                                        if (this.StepType == ZedGraph.StepType.NonStep)
                                        {
                                            g.DrawLine(pen, maxValue, lastY, num, num2);
                                        }
                                        else if (this.StepType == ZedGraph.StepType.ForwardStep)
                                        {
                                            g.DrawLine(pen, maxValue, lastY, num, lastY);
                                            g.DrawLine(pen, num, lastY, num, num2);
                                        }
                                        else if (this.StepType == ZedGraph.StepType.RearwardStep)
                                        {
                                            g.DrawLine(pen, maxValue, lastY, maxValue, num2);
                                            g.DrawLine(pen, maxValue, num2, num, num2);
                                        }
                                        else if (this.StepType == ZedGraph.StepType.ForwardSegment)
                                        {
                                            g.DrawLine(pen, maxValue, lastY, num, lastY);
                                        }
                                        else if (this.StepType == ZedGraph.StepType.RearwardSegment)
                                        {
                                            g.DrawLine(pen, maxValue, num2, num, num2);
                                        }
                                    }
                                    else
                                    {
                                        using (Pen pen2 = base.GetPen(pane, scaleFactor, lastPt))
                                        {
                                            if (this.StepType == ZedGraph.StepType.NonStep)
                                            {
                                                g.DrawLine(pen2, maxValue, lastY, num, num2);
                                            }
                                            else if (this.StepType == ZedGraph.StepType.ForwardStep)
                                            {
                                                g.DrawLine(pen2, maxValue, lastY, num, lastY);
                                                g.DrawLine(pen2, num, lastY, num, num2);
                                            }
                                            else if (this.StepType == ZedGraph.StepType.RearwardStep)
                                            {
                                                g.DrawLine(pen2, maxValue, lastY, maxValue, num2);
                                                g.DrawLine(pen2, maxValue, num2, num, num2);
                                            }
                                            else if (this.StepType == ZedGraph.StepType.ForwardSegment)
                                            {
                                                g.DrawLine(pen2, maxValue, lastY, num, lastY);
                                            }
                                            else
                                            {
                                                g.DrawLine(pen2, maxValue, num2, num, num2);
                                            }
                                        }
                                    }
                                }
                            }
                            catch
                            {
                                this.InterpolatePoint(g, pane, curve, lastPt, scaleFactor, pen, maxValue, lastY, num, num2);
                            }
                        }
                    }
                    goto TR_0005;
                }
            }
        }

        public void DrawSegment(Graphics g, GraphPane pane, float x1, float y1, float x2, float y2, float scaleFactor)
        {
            if (base._isVisible && !base.Color.IsEmpty)
            {
                using (Pen pen = base.GetPen(pane, scaleFactor))
                {
                    g.DrawLine(pen, x1, y1, x2, y2);
                }
            }
        }

        public void DrawSmoothFilledCurve(Graphics g, GraphPane pane, CurveItem curve, float scaleFactor)
        {
            PointF[] tfArray;
            int num;
            Line line = this;
            if (curve.IsSelected)
            {
                line = Selection.Line;
            }
            IPointList points = curve.Points;
            if (base.IsVisible && (!base.Color.IsEmpty && ((points != null) && (this.BuildPointsArray(pane, curve, out tfArray, out num) && (num > 2)))))
            {
                float tension = this._isSmooth ? this._smoothTension : 0f;
                if (this.Fill.IsVisible)
                {
                    Axis yAxis = curve.GetYAxis(pane);
                    using (GraphicsPath path = new GraphicsPath(FillMode.Winding))
                    {
                        path.AddCurve(tfArray, 0, num - 2, tension);
                        this.CloseCurve(pane, curve, tfArray, num, (yAxis._scale._min < 0.0) ? 0.0 : yAxis._scale._min, path);
                        RectangleF bounds = path.GetBounds();
                        using (Brush brush = line._fill.MakeBrush(bounds))
                        {
                            if ((pane.LineType != LineType.Stack) || ((yAxis.Scale._min >= 0.0) || !this.IsFirstLine(pane, curve)))
                            {
                                g.FillPath(brush, path);
                            }
                            else
                            {
                                RectangleF rect = pane.Chart._rect;
                                rect.Height = yAxis.Scale.Transform(0.0) - rect.Top;
                                if (rect.Height > 0f)
                                {
                                    Region clip = g.Clip;
                                    g.SetClip(rect);
                                    g.FillPath(brush, path);
                                    g.SetClip(pane.Chart._rect);
                                }
                            }
                        }
                        yAxis.FixZeroLine(g, pane, scaleFactor, bounds.Left, bounds.Right);
                    }
                }
                if (!this._isSmooth)
                {
                    this.DrawCurve(g, pane, curve, scaleFactor);
                }
                else
                {
                    using (Pen pen = base.GetPen(pane, scaleFactor))
                    {
                        g.DrawCurve(pen, tfArray, 0, num - 2, tension);
                    }
                }
            }
        }

        public void DrawSticks(Graphics g, GraphPane pane, CurveItem curve, float scaleFactor)
        {
            Line line = this;
            if (curve.IsSelected)
            {
                line = Selection.Line;
            }
            Axis yAxis = curve.GetYAxis(pane);
            Axis xAxis = curve.GetXAxis(pane);
            float num = yAxis.Scale.Transform(0.0);
            using (Pen pen = line.GetPen(pane, scaleFactor))
            {
                for (int i = 0; i < curve.Points.Count; i++)
                {
                    PointPair dataValue = curve.Points[i];
                    if (((dataValue.X != double.MaxValue) && ((dataValue.Y != double.MaxValue) && (!double.IsNaN(dataValue.X) && (!double.IsNaN(dataValue.Y) && (!double.IsInfinity(dataValue.X) && (!double.IsInfinity(dataValue.Y) && (!xAxis._scale.IsLog || (dataValue.X > 0.0)))))))) && (!yAxis._scale.IsLog || (dataValue.Y > 0.0)))
                    {
                        float bottom = yAxis.Scale.Transform(curve.IsOverrideOrdinal, i, dataValue.Y);
                        float num4 = xAxis.Scale.Transform(curve.IsOverrideOrdinal, i, dataValue.X);
                        if ((num4 >= pane.Chart._rect.Left) && (num4 <= pane.Chart._rect.Right))
                        {
                            if (bottom > pane.Chart._rect.Bottom)
                            {
                                bottom = pane.Chart._rect.Bottom;
                            }
                            if (bottom < pane.Chart._rect.Top)
                            {
                                bottom = pane.Chart._rect.Top;
                            }
                            if (curve.IsSelected || !base._gradientFill.IsGradientValueType)
                            {
                                g.DrawLine(pen, num4, bottom, num4, num);
                            }
                            else
                            {
                                using (Pen pen2 = base.GetPen(pane, scaleFactor, dataValue))
                                {
                                    g.DrawLine(pen2, num4, bottom, num4, num);
                                }
                            }
                        }
                    }
                }
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema", 14);
            info.AddValue("stepType", this._stepType);
            info.AddValue("isSmooth", this._isSmooth);
            info.AddValue("smoothTension", this._smoothTension);
            info.AddValue("fill", this._fill);
            info.AddValue("isOptimizedDraw", this._isOptimizedDraw);
        }

        private void InterpolatePoint(Graphics g, GraphPane pane, CurveItem curve, PointPair lastPt, float scaleFactor, Pen pen, float lastX, float lastY, float tmpX, float tmpY)
        {
            try
            {
                RectangleF ef = pane.Chart._rect;
                bool flag2 = ef.Contains(tmpX, tmpY);
                if (!ef.Contains(lastX, lastY))
                {
                    float num;
                    float num2;
                    if (Math.Abs(lastX) > Math.Abs(lastY))
                    {
                        num = (lastX < 0f) ? ef.Left : ef.Right;
                        num2 = lastY + (((tmpY - lastY) * (num - lastX)) / (tmpX - lastX));
                    }
                    else
                    {
                        num2 = (lastY < 0f) ? ef.Top : ef.Bottom;
                        num = lastX + (((tmpX - lastX) * (num2 - lastY)) / (tmpY - lastY));
                    }
                    lastX = num;
                    lastY = num2;
                }
                if (!flag2)
                {
                    float num3;
                    float num4;
                    if (Math.Abs(tmpX) > Math.Abs(tmpY))
                    {
                        num3 = (tmpX < 0f) ? ef.Left : ef.Right;
                        num4 = tmpY + (((lastY - tmpY) * (num3 - tmpX)) / (lastX - tmpX));
                    }
                    else
                    {
                        num4 = (tmpY < 0f) ? ef.Top : ef.Bottom;
                        num3 = tmpX + (((lastX - tmpX) * (num4 - tmpY)) / (lastY - tmpY));
                    }
                    tmpX = num3;
                    tmpY = num4;
                }
                if (curve.IsSelected || !base._gradientFill.IsGradientValueType)
                {
                    if (this.StepType == ZedGraph.StepType.NonStep)
                    {
                        g.DrawLine(pen, lastX, lastY, tmpX, tmpY);
                    }
                    else if (this.StepType == ZedGraph.StepType.ForwardStep)
                    {
                        g.DrawLine(pen, lastX, lastY, tmpX, lastY);
                        g.DrawLine(pen, tmpX, lastY, tmpX, tmpY);
                    }
                    else if (this.StepType == ZedGraph.StepType.RearwardStep)
                    {
                        g.DrawLine(pen, lastX, lastY, lastX, tmpY);
                        g.DrawLine(pen, lastX, tmpY, tmpX, tmpY);
                    }
                    else if (this.StepType == ZedGraph.StepType.ForwardSegment)
                    {
                        g.DrawLine(pen, lastX, lastY, tmpX, lastY);
                    }
                    else if (this.StepType == ZedGraph.StepType.RearwardSegment)
                    {
                        g.DrawLine(pen, lastX, tmpY, tmpX, tmpY);
                    }
                }
                else
                {
                    using (Pen pen2 = base.GetPen(pane, scaleFactor, lastPt))
                    {
                        if (this.StepType == ZedGraph.StepType.NonStep)
                        {
                            g.DrawLine(pen2, lastX, lastY, tmpX, tmpY);
                        }
                        else if (this.StepType == ZedGraph.StepType.ForwardStep)
                        {
                            g.DrawLine(pen2, lastX, lastY, tmpX, lastY);
                            g.DrawLine(pen2, tmpX, lastY, tmpX, tmpY);
                        }
                        else if (this.StepType == ZedGraph.StepType.RearwardStep)
                        {
                            g.DrawLine(pen2, lastX, lastY, lastX, tmpY);
                            g.DrawLine(pen2, lastX, tmpY, tmpX, tmpY);
                        }
                        else if (this.StepType == ZedGraph.StepType.ForwardSegment)
                        {
                            g.DrawLine(pen2, lastX, lastY, tmpX, lastY);
                        }
                        else
                        {
                            g.DrawLine(pen2, lastX, tmpY, tmpX, tmpY);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private bool IsFirstLine(GraphPane pane, CurveItem curve)
        {
            CurveList curveList = pane.CurveList;
            for (int i = 0; i < curveList.Count; i++)
            {
                CurveItem objA = curveList[i];
                if ((objA is LineItem) && ((objA.IsY2Axis == curve.IsY2Axis) && (objA.YAxisIndex == curve.YAxisIndex)))
                {
                    return ReferenceEquals(objA, curve);
                }
            }
            return false;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public bool IsSmooth
        {
            get => 
                this._isSmooth;
            set => 
                this._isSmooth = value;
        }

        public float SmoothTension
        {
            get => 
                this._smoothTension;
            set => 
                this._smoothTension = value;
        }

        public ZedGraph.StepType StepType
        {
            get => 
                this._stepType;
            set => 
                this._stepType = value;
        }

        public ZedGraph.Fill Fill
        {
            get => 
                this._fill;
            set => 
                this._fill = value;
        }

        public bool IsOptimizedDraw
        {
            get => 
                this._isOptimizedDraw;
            set => 
                this._isOptimizedDraw = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static System.Drawing.Color Color;
            public static System.Drawing.Color FillColor;
            public static Brush FillBrush;
            public static ZedGraph.FillType FillType;
            public static bool IsSmooth;
            public static float SmoothTension;
            public static bool IsOptimizedDraw;
            public static ZedGraph.StepType StepType;
            static Default()
            {
                Color = System.Drawing.Color.Red;
                FillColor = System.Drawing.Color.Red;
                FillBrush = null;
                FillType = ZedGraph.FillType.None;
                IsSmooth = false;
                SmoothTension = 0.5f;
                IsOptimizedDraw = false;
                StepType = ZedGraph.StepType.NonStep;
            }
        }
    }
}

