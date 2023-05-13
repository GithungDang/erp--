namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public abstract class Axis : ISerializable, ICloneable
    {
        public const int schema = 10;
        internal ZedGraph.Scale _scale;
        internal ZedGraph.MinorTic _minorTic;
        internal ZedGraph.MajorTic _majorTic;
        internal ZedGraph.MajorGrid _majorGrid;
        internal ZedGraph.MinorGrid _minorGrid;
        internal double _cross;
        internal bool _crossAuto;
        protected bool _isVisible;
        protected bool _isAxisSegmentVisible;
        protected AxisLabel _title;
        public object Tag;
        private float _axisGap;
        private float _minSpace;
        private System.Drawing.Color _color;
        internal float _tmpSpace;
        private ScaleFormatHandler ScaleFormatEvent;
        private ScaleTitleEventHandler ScaleTitleEvent;

        public event ScaleFormatHandler ScaleFormatEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.ScaleFormatEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.ScaleFormatEvent -= value;
            }
        }

        public event ScaleTitleEventHandler ScaleTitleEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.ScaleTitleEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.ScaleTitleEvent -= value;
            }
        }

        public Axis()
        {
            this._scale = new LinearScale(this);
            this._cross = 0.0;
            this._crossAuto = true;
            this._majorTic = new ZedGraph.MajorTic();
            this._minorTic = new ZedGraph.MinorTic();
            this._majorGrid = new ZedGraph.MajorGrid();
            this._minorGrid = new ZedGraph.MinorGrid();
            this._axisGap = Default.AxisGap;
            this._minSpace = Default.MinSpace;
            this._isVisible = true;
            this._isAxisSegmentVisible = Default.IsAxisSegmentVisible;
            this._title = new AxisLabel("", Default.TitleFontFamily, Default.TitleFontSize, Default.TitleFontColor, Default.TitleFontBold, Default.TitleFontUnderline, Default.TitleFontItalic);
            this._title.FontSpec.Fill = new Fill(Default.TitleFillColor, Default.TitleFillBrush, Default.TitleFillType);
            this._title.FontSpec.Border.IsVisible = false;
            this._color = Default.Color;
        }

        public Axis(string title) : this()
        {
            this._title._text = title;
        }

        public Axis(Axis rhs)
        {
            this._scale = rhs._scale.Clone(this);
            this._cross = rhs._cross;
            this._crossAuto = rhs._crossAuto;
            this._majorTic = rhs.MajorTic.Clone();
            this._minorTic = rhs.MinorTic.Clone();
            this._majorGrid = rhs._majorGrid.Clone();
            this._minorGrid = rhs._minorGrid.Clone();
            this._isVisible = rhs.IsVisible;
            this._isAxisSegmentVisible = rhs._isAxisSegmentVisible;
            this._title = rhs.Title.Clone();
            this._axisGap = rhs._axisGap;
            this._minSpace = rhs.MinSpace;
            this._color = rhs.Color;
        }

        protected Axis(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._cross = info.GetDouble("cross");
            this._crossAuto = info.GetBoolean("crossAuto");
            this._majorTic = (ZedGraph.MajorTic) info.GetValue("MajorTic", typeof(ZedGraph.MajorTic));
            this._minorTic = (ZedGraph.MinorTic) info.GetValue("MinorTic", typeof(ZedGraph.MinorTic));
            this._majorGrid = (ZedGraph.MajorGrid) info.GetValue("majorGrid", typeof(ZedGraph.MajorGrid));
            this._minorGrid = (ZedGraph.MinorGrid) info.GetValue("minorGrid", typeof(ZedGraph.MinorGrid));
            this._isVisible = info.GetBoolean("isVisible");
            this._title = (AxisLabel) info.GetValue("title", typeof(AxisLabel));
            this._minSpace = info.GetSingle("minSpace");
            this._color = (System.Drawing.Color) info.GetValue("color", typeof(System.Drawing.Color));
            this._isAxisSegmentVisible = info.GetBoolean("isAxisSegmentVisible");
            this._axisGap = info.GetSingle("axisGap");
            this._scale = (ZedGraph.Scale) info.GetValue("scale", typeof(ZedGraph.Scale));
            this._scale._ownerAxis = this;
        }

        internal float CalcCrossFraction(GraphPane pane)
        {
            float num4;
            if (!this.IsCrossShifted(pane))
            {
                return ((!this.IsPrimary(pane) || !this._scale._isLabelsInside) ? 0f : 1f);
            }
            double num = this.EffectiveCrossValue(pane);
            Axis crossAxis = this.GetCrossAxis(pane);
            double num2 = crossAxis._scale.Linearize(crossAxis._scale._min);
            double num3 = crossAxis._scale.Linearize(crossAxis._scale._max);
            if (((!(this is XAxis) && !(this is YAxis)) || (this._scale._isLabelsInside != crossAxis._scale.IsReverse)) && ((!(this is X2Axis) && !(this is Y2Axis)) || (this._scale._isLabelsInside == crossAxis._scale.IsReverse)))
            {
                num4 = (float) ((num2 - num) / (num2 - num3));
            }
            else
            {
                num4 = (float) ((num - num3) / (num2 - num3));
            }
            if (num4 < 0f)
            {
                num4 = 0f;
            }
            if (num4 > 1f)
            {
                num4 = 1f;
            }
            return num4;
        }

        internal abstract float CalcCrossShift(GraphPane pane);
        public float CalcSpace(Graphics g, GraphPane pane, float scaleFactor, out float fixedSpace)
        {
            float height = this._scale._fontSpec.GetHeight(scaleFactor);
            float num2 = this._majorTic.ScaledTic(scaleFactor);
            float num3 = this._axisGap * scaleFactor;
            float num4 = this._scale._labelGap * height;
            float scaledGap = this._title.GetScaledGap(scaleFactor);
            fixedSpace = 0f;
            this._tmpSpace = 0f;
            if (this._isVisible)
            {
                bool flag = (this.MajorTic.IsOutside || (this.MajorTic._isCrossOutside || this.MinorTic.IsOutside)) || this.MinorTic._isCrossOutside;
                if (flag)
                {
                    this._tmpSpace += num2;
                }
                if (!this.IsPrimary(pane))
                {
                    this._tmpSpace += num3;
                    if (this.MajorTic._isInside || (this.MajorTic._isCrossInside || (this.MinorTic._isInside || this.MinorTic._isCrossInside)))
                    {
                        this._tmpSpace += num2;
                    }
                }
                this._tmpSpace += this._scale.GetScaleMaxSpace(g, pane, scaleFactor, true).Height + num4;
                string str = this.MakeTitle();
                if (!string.IsNullOrEmpty(str) && this._title._isVisible)
                {
                    fixedSpace = this.Title.FontSpec.BoundingBox(g, str, scaleFactor).Height + scaledGap;
                    this._tmpSpace += fixedSpace;
                    fixedSpace += scaledGap;
                }
                if (flag)
                {
                    fixedSpace += num2;
                }
            }
            if ((this.IsPrimary(pane) && (((this is YAxis) && ((!pane.XAxis._scale._isSkipFirstLabel && !pane.XAxis._scale._isReverse) || (!pane.XAxis._scale._isSkipLastLabel && pane.XAxis._scale._isReverse))) || ((this is Y2Axis) && ((!pane.XAxis._scale._isSkipFirstLabel && pane.XAxis._scale._isReverse) || (!pane.XAxis._scale._isSkipLastLabel && !pane.XAxis._scale._isReverse))))) && (pane.XAxis.IsVisible && pane.XAxis._scale._isVisible))
            {
                float num6 = pane.XAxis._scale.GetScaleMaxSpace(g, pane, scaleFactor, true).Width / 2f;
                fixedSpace = Math.Max(num6, fixedSpace);
            }
            this._tmpSpace = Math.Max(this._tmpSpace, this._minSpace * scaleFactor);
            fixedSpace = Math.Max(fixedSpace, this._minSpace * scaleFactor);
            return this._tmpSpace;
        }

        private float CalcTotalShift(GraphPane pane, float scaleFactor, float shiftPos)
        {
            if (!this.IsPrimary(pane))
            {
                if (this.IsCrossShifted(pane))
                {
                    shiftPos = 0f;
                }
                else
                {
                    float num = this._majorTic.ScaledTic(scaleFactor);
                    if (this._scale._isLabelsInside)
                    {
                        shiftPos += this._tmpSpace;
                        if (this._majorTic.IsOutside || (this._majorTic._isCrossOutside || (this._minorTic.IsOutside || this._minorTic._isCrossOutside)))
                        {
                            shiftPos -= num;
                        }
                    }
                    else
                    {
                        shiftPos += this._axisGap * scaleFactor;
                        if (this._majorTic.IsInside || (this._majorTic._isCrossInside || (this._minorTic.IsInside || this._minorTic._isCrossInside)))
                        {
                            shiftPos += num;
                        }
                    }
                }
            }
            float num2 = this.CalcCrossShift(pane);
            shiftPos += num2;
            return shiftPos;
        }

        public void Draw(Graphics g, GraphPane pane, float scaleFactor, float shiftPos)
        {
            Matrix transform = g.Transform;
            this._scale.SetupScaleData(pane, this);
            if (this._isVisible)
            {
                this.SetTransformMatrix(g, pane, scaleFactor);
                shiftPos = this.CalcTotalShift(pane, scaleFactor, shiftPos);
                this._scale.Draw(g, pane, scaleFactor, shiftPos);
                g.Transform = transform;
            }
        }

        internal void DrawGrid(Graphics g, GraphPane pane, float scaleFactor, float shiftPos)
        {
            if (this._isVisible)
            {
                float num2;
                float num3;
                Matrix transform = g.Transform;
                this.SetTransformMatrix(g, pane, scaleFactor);
                double baseVal = this._scale.CalcBaseTic();
                this._scale.GetTopRightPix(pane, out num2, out num3);
                shiftPos = this.CalcTotalShift(pane, scaleFactor, shiftPos);
                this._scale.DrawGrid(g, pane, baseVal, num2, scaleFactor);
                this.DrawMinorTics(g, pane, baseVal, shiftPos, scaleFactor, num2);
                g.Transform = transform;
            }
        }

        public void DrawMinorTics(Graphics g, GraphPane pane, double baseVal, float shift, float scaleFactor, float topPix)
        {
            if ((this.MinorTic.IsOutside || (this.MinorTic.IsOpposite || (this.MinorTic.IsInside || (this.MinorTic._isCrossOutside || (this.MinorTic._isCrossInside || this._minorGrid._isVisible))))) && this._isVisible)
            {
                double num = this._scale._majorStep * this._scale.MajorUnitMultiplier;
                double num2 = this._scale._minorStep * this._scale.MinorUnitMultiplier;
                if (this._scale.IsLog || (num2 < num))
                {
                    float scaledTic = this.MinorTic.ScaledTic(scaleFactor);
                    double num4 = this._scale._minLinTemp;
                    double num5 = this._scale._maxLinTemp;
                    double num6 = num4;
                    int iTic = this._scale.CalcMinorStart(baseVal);
                    int num9 = 0;
                    double num10 = this._scale.CalcMajorTicValue(baseVal, (double) num9);
                    using (Pen pen = new Pen(this._minorTic._color, pane.ScaledPenWidth(this.MinorTic._penWidth, scaleFactor)))
                    {
                        using (Pen pen2 = this._minorGrid.GetPen(pane, scaleFactor))
                        {
                            while ((num6 < num5) && (iTic < 0x1388))
                            {
                                num6 = this._scale.CalcMinorTicValue(baseVal, iTic);
                                if (num6 > num10)
                                {
                                    num10 = this._scale.CalcMajorTicValue(baseVal, (double) (++num9));
                                }
                                if (((((Math.Abs(num6) < 1E-20) && (Math.Abs((double) (num6 - num10)) > 1E-20)) || ((Math.Abs(num6) > 1E-20) && (Math.Abs((double) ((num6 - num10) / num6)) > 1E-10))) && (num6 >= num4)) && (num6 <= num5))
                                {
                                    float pixVal = this._scale.LocalTransform(num6);
                                    this._minorGrid.Draw(g, pen2, pixVal, topPix);
                                    this._minorTic.Draw(g, pane, pen, pixVal, topPix, shift, scaledTic);
                                }
                                iTic++;
                            }
                        }
                    }
                }
            }
        }

        public void DrawTitle(Graphics g, GraphPane pane, float shiftPos, float scaleFactor)
        {
            string str = this.MakeTitle();
            if (this._isVisible && (this._title._isVisible && !string.IsNullOrEmpty(str)))
            {
                float x = (this._scale._maxPix - this._scale._minPix) / 2f;
                float num3 = this._scale._fontSpec.GetHeight(scaleFactor) * this._scale._labelGap;
                float scaledGap = this._title.GetScaledGap(scaleFactor);
                float num5 = (this.MajorTic.ScaledTic(scaleFactor) * ((this._scale._isLabelsInside ? ((this.MajorTic.IsInside || (this.MajorTic._isCrossInside || this.MinorTic.IsInside)) || this.MinorTic._isCrossInside) : ((this.MajorTic.IsOutside || (this.MajorTic._isCrossOutside || this.MinorTic.IsOutside)) || this.MinorTic._isCrossOutside)) ? 1f : 0f)) + (this.Title.FontSpec.BoundingBox(g, str, scaleFactor).Height / 2f);
                float num6 = this._scale._isVisible ? (this._scale.GetScaleMaxSpace(g, pane, scaleFactor, true).Height + num3) : 0f;
                num6 = !this._scale._isLabelsInside ? ((shiftPos + num6) + num5) : ((shiftPos - num6) - num5);
                if (!this._crossAuto && !this._title._isTitleAtCross)
                {
                    num6 = Math.Max(num6, num5);
                }
                this.Title.FontSpec.Draw(g, pane, str, x, num6 + scaledGap, AlignH.Center, AlignV.Center, scaleFactor);
            }
        }

        internal double EffectiveCrossValue(GraphPane pane)
        {
            Axis crossAxis = this.GetCrossAxis(pane);
            double num = crossAxis._scale.Linearize(crossAxis._scale._min);
            double num2 = crossAxis._scale.Linearize(crossAxis._scale._max);
            return (!this._crossAuto ? ((this._cross >= num) ? ((this._cross <= num2) ? this._scale.Linearize(this._cross) : num2) : num) : ((crossAxis._scale.IsReverse != ((this is Y2Axis) || (this is X2Axis))) ? num : num2));
        }

        internal void FixZeroLine(Graphics g, GraphPane pane, float scaleFactor, float left, float right)
        {
            if (this._isVisible && (this._majorGrid._isZeroLine && ((this._scale._min < 0.0) && (this._scale._max > 0.0))))
            {
                float num = this._scale.Transform(0.0);
                using (Pen pen = new Pen(this._color, pane.ScaledPenWidth(this._majorGrid._penWidth, scaleFactor)))
                {
                    g.DrawLine(pen, left, num, right, num);
                }
            }
        }

        public abstract Axis GetCrossAxis(GraphPane pane);
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("cross", this._cross);
            info.AddValue("crossAuto", this._crossAuto);
            info.AddValue("MajorTic", this.MajorTic);
            info.AddValue("MinorTic", this.MinorTic);
            info.AddValue("majorGrid", this._majorGrid);
            info.AddValue("minorGrid", this._minorGrid);
            info.AddValue("isVisible", this._isVisible);
            info.AddValue("title", this._title);
            info.AddValue("minSpace", this._minSpace);
            info.AddValue("color", this._color);
            info.AddValue("isAxisSegmentVisible", this._isAxisSegmentVisible);
            info.AddValue("axisGap", this._axisGap);
            info.AddValue("scale", this._scale);
        }

        internal bool IsCrossShifted(GraphPane pane)
        {
            if (this._crossAuto)
            {
                return false;
            }
            Axis crossAxis = this.GetCrossAxis(pane);
            if ((((this is XAxis) || (this is YAxis)) && !crossAxis._scale.IsReverse) || (((this is X2Axis) || (this is Y2Axis)) && crossAxis._scale.IsReverse))
            {
                return (this._cross > crossAxis._scale._min);
            }
            return (this._cross < crossAxis._scale._max);
        }

        internal abstract bool IsPrimary(GraphPane pane);
        internal string MakeLabelEventWorks(GraphPane pane, int index, double dVal)
        {
            if (this.ScaleFormatEvent != null)
            {
                string str = this.ScaleFormatEvent(pane, this, dVal, index);
                if (str != null)
                {
                    return str;
                }
            }
            return ((this.Scale == null) ? "?" : this._scale.MakeLabel(pane, index, dVal));
        }

        private string MakeTitle()
        {
            this._title._text ??= "";
            if (this.ScaleTitleEvent != null)
            {
                string str = this.ScaleTitleEvent(this);
                if (str != null)
                {
                    return str;
                }
            }
            return (((this._scale._mag == 0) || (this._title._isOmitMag || this._scale.IsLog)) ? this._title._text : (this._title._text + $" (10^{this._scale._mag})"));
        }

        public void ResetAutoScale(GraphPane pane, Graphics g)
        {
            this._scale._minAuto = true;
            this._scale._maxAuto = true;
            this._scale._majorStepAuto = true;
            this._scale._minorStepAuto = true;
            this._crossAuto = true;
            this._scale._magAuto = true;
            this._scale._formatAuto = true;
            pane.AxisChange(g);
        }

        public void SetMinSpaceBuffer(Graphics g, GraphPane pane, float bufferFraction, bool isGrowOnly)
        {
            float num2;
            float minSpace = this.MinSpace;
            this.MinSpace = 0f;
            float num3 = this.CalcSpace(g, pane, 1f, out num2) * bufferFraction;
            if (isGrowOnly)
            {
                num3 = Math.Max(minSpace, num3);
            }
            this.MinSpace = num3;
        }

        public abstract void SetTransformMatrix(Graphics g, GraphPane pane, float scaleFactor);
        object ICloneable.Clone()
        {
            throw new NotImplementedException("Can't clone an abstract base type -- child types must implement ICloneable");
        }

        public ZedGraph.Scale Scale =>
            this._scale;

        public double Cross
        {
            get => 
                this._cross;
            set
            {
                this._cross = value;
                this._crossAuto = false;
            }
        }

        public bool CrossAuto
        {
            get => 
                this._crossAuto;
            set => 
                this._crossAuto = value;
        }

        public float MinSpace
        {
            get => 
                this._minSpace;
            set => 
                this._minSpace = value;
        }

        public System.Drawing.Color Color
        {
            get => 
                this._color;
            set => 
                this._color = value;
        }

        public ZedGraph.MajorTic MajorTic =>
            this._majorTic;

        public ZedGraph.MinorTic MinorTic =>
            this._minorTic;

        public ZedGraph.MajorGrid MajorGrid =>
            this._majorGrid;

        public ZedGraph.MinorGrid MinorGrid =>
            this._minorGrid;

        public bool IsVisible
        {
            get => 
                this._isVisible;
            set => 
                this._isVisible = value;
        }

        public bool IsAxisSegmentVisible
        {
            get => 
                this._isAxisSegmentVisible;
            set => 
                this._isAxisSegmentVisible = value;
        }

        public AxisType Type
        {
            get => 
                this._scale.Type;
            set => 
                this._scale = this.Scale.MakeNewScale(this._scale, value);
        }

        public AxisLabel Title
        {
            get => 
                this._title;
            set => 
                this._title = value;
        }

        public float AxisGap
        {
            get => 
                this._axisGap;
            set => 
                this._axisGap = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float AxisGap;
            public static float TitleGap;
            public static string TitleFontFamily;
            public static float TitleFontSize;
            public static System.Drawing.Color TitleFontColor;
            public static bool TitleFontBold;
            public static bool TitleFontItalic;
            public static bool TitleFontUnderline;
            public static System.Drawing.Color TitleFillColor;
            public static Brush TitleFillBrush;
            public static FillType TitleFillType;
            public static System.Drawing.Color BorderColor;
            public static bool IsAxisSegmentVisible;
            public static AxisType Type;
            public static System.Drawing.Color Color;
            public static float MinSpace;
            static Default()
            {
                AxisGap = 5f;
                TitleGap = 0f;
                TitleFontFamily = "Arial";
                TitleFontSize = 14f;
                TitleFontColor = System.Drawing.Color.Black;
                TitleFontBold = true;
                TitleFontItalic = false;
                TitleFontUnderline = false;
                TitleFillColor = System.Drawing.Color.White;
                TitleFillBrush = null;
                TitleFillType = FillType.None;
                BorderColor = System.Drawing.Color.Black;
                IsAxisSegmentVisible = true;
                Type = AxisType.Linear;
                Color = System.Drawing.Color.Black;
                MinSpace = 0f;
            }
        }

        public delegate string ScaleFormatHandler(GraphPane pane, Axis axis, double val, int index);

        public delegate string ScaleTitleEventHandler(Axis axis);
    }
}

