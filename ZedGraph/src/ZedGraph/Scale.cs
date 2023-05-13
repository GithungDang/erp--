namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public abstract class Scale : ISerializable
    {
        public const int schema = 11;
        internal double _min;
        internal double _max;
        internal double _majorStep;
        internal double _minorStep;
        internal double _exponent;
        internal double _baseTic;
        internal bool _minAuto;
        internal bool _maxAuto;
        internal bool _majorStepAuto;
        internal bool _minorStepAuto;
        internal bool _magAuto;
        internal bool _formatAuto;
        internal double _minGrace;
        internal double _maxGrace;
        internal int _mag;
        internal bool _isReverse;
        internal bool _isPreventLabelOverlap;
        internal bool _isUseTenPower;
        internal bool _isLabelsInside;
        internal bool _isSkipFirstLabel;
        internal bool _isSkipLastLabel;
        internal bool _isSkipCrossLabel;
        internal bool _isVisible;
        internal string[] _textLabels;
        internal string _format;
        internal DateUnit _majorUnit;
        internal DateUnit _minorUnit;
        internal AlignP _align;
        internal ZedGraph.AlignH _alignH;
        internal ZedGraph.FontSpec _fontSpec;
        internal float _labelGap;
        internal double _rangeMin;
        internal double _rangeMax;
        internal double _lBound;
        internal double _uBound;
        internal float _minPix;
        internal float _maxPix;
        internal double _minLinTemp;
        internal double _maxLinTemp;
        internal Axis _ownerAxis;

        public Scale(Axis ownerAxis)
        {
            this._ownerAxis = ownerAxis;
            this._min = 0.0;
            this._max = 1.0;
            this._majorStep = 0.1;
            this._minorStep = 0.1;
            this._exponent = 1.0;
            this._mag = 0;
            this._baseTic = double.MaxValue;
            this._minGrace = Default.MinGrace;
            this._maxGrace = Default.MaxGrace;
            this._minAuto = true;
            this._maxAuto = true;
            this._majorStepAuto = true;
            this._minorStepAuto = true;
            this._magAuto = true;
            this._formatAuto = true;
            this._isReverse = Default.IsReverse;
            this._isUseTenPower = true;
            this._isPreventLabelOverlap = true;
            this._isVisible = true;
            this._isSkipFirstLabel = false;
            this._isSkipLastLabel = false;
            this._isSkipCrossLabel = false;
            this._majorUnit = DateUnit.Day;
            this._minorUnit = DateUnit.Day;
            this._format = null;
            this._textLabels = null;
            this._isLabelsInside = Default.IsLabelsInside;
            this._align = Default.Align;
            this._alignH = Default.AlignH;
            this._fontSpec = new ZedGraph.FontSpec(Default.FontFamily, Default.FontSize, Default.FontColor, Default.FontBold, Default.FontUnderline, Default.FontItalic, Default.FillColor, Default.FillBrush, Default.FillType);
            this._fontSpec.Border.IsVisible = false;
            this._labelGap = Default.LabelGap;
        }

        protected Scale(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._min = info.GetDouble("min");
            this._max = info.GetDouble("max");
            this._majorStep = info.GetDouble("majorStep");
            this._minorStep = info.GetDouble("minorStep");
            this._exponent = info.GetDouble("exponent");
            this._baseTic = info.GetDouble("baseTic");
            this._minAuto = info.GetBoolean("minAuto");
            this._maxAuto = info.GetBoolean("maxAuto");
            this._majorStepAuto = info.GetBoolean("majorStepAuto");
            this._minorStepAuto = info.GetBoolean("minorStepAuto");
            this._magAuto = info.GetBoolean("magAuto");
            this._formatAuto = info.GetBoolean("formatAuto");
            this._minGrace = info.GetDouble("minGrace");
            this._maxGrace = info.GetDouble("maxGrace");
            this._mag = info.GetInt32("mag");
            this._isReverse = info.GetBoolean("isReverse");
            this._isPreventLabelOverlap = info.GetBoolean("isPreventLabelOverlap");
            this._isUseTenPower = info.GetBoolean("isUseTenPower");
            this._isVisible = true;
            this._isVisible = info.GetBoolean("isVisible");
            this._isSkipFirstLabel = info.GetBoolean("isSkipFirstLabel");
            this._isSkipLastLabel = info.GetBoolean("isSkipLastLabel");
            this._isSkipCrossLabel = info.GetBoolean("isSkipCrossLabel");
            this._textLabels = (string[]) info.GetValue("textLabels", typeof(string[]));
            this._format = info.GetString("format");
            this._majorUnit = (DateUnit) info.GetValue("majorUnit", typeof(DateUnit));
            this._minorUnit = (DateUnit) info.GetValue("minorUnit", typeof(DateUnit));
            this._isLabelsInside = info.GetBoolean("isLabelsInside");
            this._align = (AlignP) info.GetValue("align", typeof(AlignP));
            this._alignH = (ZedGraph.AlignH) info.GetValue("alignH", typeof(ZedGraph.AlignH));
            this._fontSpec = (ZedGraph.FontSpec) info.GetValue("fontSpec", typeof(ZedGraph.FontSpec));
            this._labelGap = info.GetSingle("labelGap");
        }

        public Scale(Scale rhs, Axis owner)
        {
            this._ownerAxis = owner;
            this._min = rhs._min;
            this._max = rhs._max;
            this._majorStep = rhs._majorStep;
            this._minorStep = rhs._minorStep;
            this._exponent = rhs._exponent;
            this._baseTic = rhs._baseTic;
            this._minAuto = rhs._minAuto;
            this._maxAuto = rhs._maxAuto;
            this._majorStepAuto = rhs._majorStepAuto;
            this._minorStepAuto = rhs._minorStepAuto;
            this._magAuto = rhs._magAuto;
            this._formatAuto = rhs._formatAuto;
            this._minGrace = rhs._minGrace;
            this._maxGrace = rhs._maxGrace;
            this._mag = rhs._mag;
            this._isUseTenPower = rhs._isUseTenPower;
            this._isReverse = rhs._isReverse;
            this._isPreventLabelOverlap = rhs._isPreventLabelOverlap;
            this._isVisible = rhs._isVisible;
            this._isSkipFirstLabel = rhs._isSkipFirstLabel;
            this._isSkipLastLabel = rhs._isSkipLastLabel;
            this._isSkipCrossLabel = rhs._isSkipCrossLabel;
            this._majorUnit = rhs._majorUnit;
            this._minorUnit = rhs._minorUnit;
            this._format = rhs._format;
            this._isLabelsInside = rhs._isLabelsInside;
            this._align = rhs._align;
            this._alignH = rhs._alignH;
            this._fontSpec = rhs._fontSpec.Clone();
            this._labelGap = rhs._labelGap;
            if (rhs._textLabels != null)
            {
                this._textLabels = (string[]) rhs._textLabels.Clone();
            }
            else
            {
                this._textLabels = null;
            }
        }

        internal virtual double CalcBaseTic() => 
            (this._baseTic == double.MaxValue) ? (!this.IsAnyOrdinal ? (Math.Ceiling((double) ((this._min / this._majorStep) - 1E-08)) * this._majorStep) : 1.0) : this._baseTic;

        protected double CalcBoundedStepSize(double range, double maxSteps)
        {
            double d = range / maxSteps;
            double num3 = Math.Pow(10.0, Math.Floor(Math.Log10(d)));
            double num4 = Math.Ceiling((double) (d / num3));
            if (num4 > 5.0)
            {
                num4 = 10.0;
            }
            else if (num4 > 2.0)
            {
                num4 = 5.0;
            }
            else if (num4 > 1.0)
            {
                num4 = 2.0;
            }
            return (num4 * num3);
        }

        internal virtual double CalcMajorTicValue(double baseVal, double tic) => 
            baseVal + (this._majorStep * tic);

        public int CalcMaxLabels(Graphics g, GraphPane pane, float scaleFactor)
        {
            SizeF ef = this.GetScaleMaxSpace(g, pane, scaleFactor, false);
            float num = 1000f;
            float num2 = 1000f;
            float num3 = (float) Math.Abs(Math.Cos((this._fontSpec.Angle * 3.1415926535897931) / 180.0));
            float num4 = (float) Math.Abs(Math.Sin((this._fontSpec.Angle * 3.1415926535897931) / 180.0));
            if (num3 > 0.001)
            {
                num = ef.Width / num3;
            }
            if (num4 > 0.001)
            {
                num2 = ef.Height / num4;
            }
            if (num2 < num)
            {
                num = num2;
            }
            if (num <= 0f)
            {
                num = 1f;
            }
            RectangleF ef2 = pane.Chart._rect;
            double num5 = ((this._ownerAxis is XAxis) || (this._ownerAxis is X2Axis)) ? ((ef2.Width == 0f) ? (pane.Rect.Width * 0.75) : ((double) ef2.Width)) : ((ef2.Height == 0f) ? (pane.Rect.Height * 0.75) : ((double) ef2.Height));
            int num6 = (int) (num5 / ((double) num));
            if (num6 <= 0)
            {
                num6 = 1;
            }
            return num6;
        }

        internal virtual int CalcMinorStart(double baseVal) => 
            (int) ((this._min - baseVal) / this._minorStep);

        internal virtual double CalcMinorTicValue(double baseVal, int iTic) => 
            baseVal + (this._minorStep * iTic);

        internal virtual int CalcNumTics()
        {
            int num = 1;
            num = ((int) (((this._max - this._min) / this._majorStep) + 0.01)) + 1;
            if (num < 1)
            {
                num = 1;
            }
            else if (num > 0x3e8)
            {
                num = 0x3e8;
            }
            return num;
        }

        protected static double CalcStepSize(double range, double targetSteps)
        {
            double d = range / targetSteps;
            double num3 = Math.Pow(10.0, Math.Floor(Math.Log10(d)));
            double num4 = (int) ((d / num3) + 0.5);
            if (num4 > 5.0)
            {
                num4 = 10.0;
            }
            else if (num4 > 2.0)
            {
                num4 = 5.0;
            }
            else if (num4 > 1.0)
            {
                num4 = 2.0;
            }
            return (num4 * num3);
        }

        public abstract Scale Clone(Axis owner);
        public virtual double DeLinearize(double val) => 
            val;

        internal void Draw(Graphics g, GraphPane pane, float scaleFactor, float shiftPos)
        {
            float num;
            float num2;
            MajorGrid grid = this._ownerAxis._majorGrid;
            MajorTic tic = this._ownerAxis._majorTic;
            MinorTic tic1 = this._ownerAxis._minorTic;
            this.GetTopRightPix(pane, out num2, out num);
            int nTics = this.CalcNumTics();
            double baseVal = this.CalcBaseTic();
            using (Pen pen = new Pen(this._ownerAxis.Color, pane.ScaledPenWidth(tic._penWidth, scaleFactor)))
            {
                if (this._ownerAxis.IsAxisSegmentVisible)
                {
                    g.DrawLine(pen, 0f, shiftPos, num, shiftPos);
                }
                if ((grid._isZeroLine && (this._min < 0.0)) && (this._max > 0.0))
                {
                    float num5 = this.LocalTransform(0.0);
                    g.DrawLine(pen, num5, 0f, num5, num2);
                }
            }
            this.DrawLabels(g, pane, baseVal, nTics, num2, shiftPos, scaleFactor);
            this._ownerAxis.DrawTitle(g, pane, shiftPos, scaleFactor);
        }

        internal void DrawGrid(Graphics g, GraphPane pane, double baseVal, float topPix, float scaleFactor)
        {
            MajorTic tic = this._ownerAxis._majorTic;
            MajorGrid grid = this._ownerAxis._majorGrid;
            int num = this.CalcNumTics();
            using (Pen pen = grid.GetPen(pane, scaleFactor))
            {
                float num5;
                double num6 = (this._maxLinTemp - this._minLinTemp) * 0.001;
                int num7 = (int) (((this._minLinTemp - baseVal) / this._majorStep) + 0.99);
                if (num7 < 0)
                {
                    num7 = 0;
                }
                int num8 = num7;
                goto TR_0014;
            TR_0004:
                num8++;
            TR_0014:
                while (true)
                {
                    if (num8 < (num + num7))
                    {
                        double x = this.CalcMajorTicValue(baseVal, (double) num8);
                        if (x < this._minLinTemp)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            if (x <= (this._maxLinTemp + num6))
                            {
                                double num3;
                                float num4 = this.LocalTransform(x);
                                if (!tic._isBetweenLabels || !this.IsText)
                                {
                                    num5 = num4;
                                    break;
                                }
                                if (num8 == 0)
                                {
                                    num3 = this.CalcMajorTicValue(baseVal, -0.5);
                                    if (num3 >= this._minLinTemp)
                                    {
                                        grid.Draw(g, pen, this.LocalTransform(num3), topPix);
                                    }
                                }
                                num3 = this.CalcMajorTicValue(baseVal, num8 + 0.5);
                                if (num3 <= this._maxLinTemp)
                                {
                                    num5 = this.LocalTransform(num3);
                                    break;
                                }
                            }
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                    break;
                }
                grid.Draw(g, pen, num5, topPix);
                goto TR_0004;
            }
        }

        internal void DrawLabel(Graphics g, GraphPane pane, int i, double dVal, float pixVal, float shift, float maxSpace, float scaledTic, float charHeight, float scaleFactor)
        {
            float num = !this._ownerAxis.MajorTic.IsOutside ? (charHeight * this._labelGap) : (scaledTic + (charHeight * this._labelGap));
            string text = this._ownerAxis.MakeLabelEventWorks(pane, i, dVal);
            float num3 = (!this.IsLog || !this._isUseTenPower) ? this._fontSpec.BoundingBox(g, text, scaleFactor).Height : this._fontSpec.BoundingBoxTenPower(g, text, scaleFactor).Height;
            float y = (this._align != AlignP.Center) ? ((this._align != AlignP.Outside) ? (num + (num3 / 2f)) : ((num + maxSpace) - (num3 / 2f))) : (num + (maxSpace / 2f));
            y = !this._isLabelsInside ? (shift + y) : (shift - y);
            AlignV center = AlignV.Center;
            ZedGraph.AlignH alignH = ZedGraph.AlignH.Center;
            if ((this._ownerAxis is XAxis) || (this._ownerAxis is X2Axis))
            {
                alignH = this._alignH;
            }
            else
            {
                center = (this._alignH == ZedGraph.AlignH.Left) ? AlignV.Top : ((this._alignH == ZedGraph.AlignH.Right) ? AlignV.Bottom : AlignV.Center);
            }
            if (this.IsLog && this._isUseTenPower)
            {
                this._fontSpec.DrawTenPower(g, pane, text, pixVal, y, alignH, center, scaleFactor);
            }
            else
            {
                this._fontSpec.Draw(g, pane, text, pixVal, y, alignH, center, scaleFactor);
            }
        }

        internal void DrawLabels(Graphics g, GraphPane pane, double baseVal, int nTics, float topPix, float shift, float scaleFactor)
        {
            MajorTic tic = this._ownerAxis._majorTic;
            float scaledTic = tic.ScaledTic(scaleFactor);
            Math.Pow(10.0, (double) this._mag);
            using (Pen pen = tic.GetPen(pane, scaleFactor))
            {
                double num;
                float num3;
                float num4;
                bool flag1;
                SizeF ef = this.GetScaleMaxSpace(g, pane, scaleFactor, true);
                float height = this._fontSpec.GetHeight(scaleFactor);
                float maxSpace = ef.Height;
                float num8 = Default.EdgeTolerance * scaleFactor;
                double num9 = (this._maxLinTemp - this._minLinTemp) * 0.001;
                int num10 = (int) (((this._minLinTemp - baseVal) / this._majorStep) + 0.99);
                if (num10 < 0)
                {
                    num10 = 0;
                }
                float num11 = -10000f;
                int i = num10;
                goto TR_001C;
            TR_0004:
                i++;
            TR_001C:
                while (true)
                {
                    if (i < (nTics + num10))
                    {
                        num = this.CalcMajorTicValue(baseVal, (double) i);
                        if (num < this._minLinTemp)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            if (num <= (this._maxLinTemp + num9))
                            {
                                double num2;
                                num3 = this.LocalTransform(num);
                                if (!tic._isBetweenLabels || !this.IsText)
                                {
                                    num4 = num3;
                                    break;
                                }
                                if (i == 0)
                                {
                                    num2 = this.CalcMajorTicValue(baseVal, -0.5);
                                    if (num2 >= this._minLinTemp)
                                    {
                                        tic.Draw(g, pane, pen, this.LocalTransform(num2), topPix, shift, scaledTic);
                                    }
                                }
                                num2 = this.CalcMajorTicValue(baseVal, i + 0.5);
                                if (num2 <= this._maxLinTemp)
                                {
                                    num4 = this.LocalTransform(num2);
                                    break;
                                }
                            }
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                    break;
                }
                tic.Draw(g, pane, pen, num4, topPix, shift, scaledTic);
                bool flag = ((!(this._ownerAxis is XAxis) && !(this._ownerAxis is Y2Axis)) || this.IsReverse) ? ((this._ownerAxis is Y2Axis) && this.IsReverse) : true;
                if (((!this._isSkipFirstLabel || !flag) && (!this._isSkipLastLabel || flag)) || (num3 >= num8))
                {
                    flag1 = ((this._isSkipLastLabel && flag) || (this._isSkipFirstLabel && !flag)) ? (num3 > ((this._maxPix - this._minPix) - num8)) : false;
                }
                else
                {
                    flag1 = true;
                }
                bool flag2 = flag1;
                bool flag3 = (this._isSkipCrossLabel && !this._ownerAxis._crossAuto) && (Math.Abs((double) (this._ownerAxis._cross - num)) < (num9 * 10.0));
                flag2 = flag2 || flag3;
                if (this._isVisible && (!flag2 && (!this.IsPreventLabelOverlap || (Math.Abs((float) (num3 - num11)) >= ef.Width))))
                {
                    this.DrawLabel(g, pane, i, num, num3, shift, maxSpace, scaledTic, height, scaleFactor);
                    num11 = num3;
                }
                goto TR_0004;
            }
        }

        public float GetClusterWidth(double clusterScaleWidth)
        {
            double x = this._min;
            return Math.Abs((float) (this.Transform(x + clusterScaleWidth) - this.Transform(x)));
        }

        public float GetClusterWidth(GraphPane pane)
        {
            double x = this._min;
            return Math.Abs((float) (this.Transform(x + (this.IsAnyOrdinal ? 1.0 : pane._barSettings._clusterScaleWidth)) - this.Transform(x)));
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 11);
            info.AddValue("min", this._min);
            info.AddValue("max", this._max);
            info.AddValue("majorStep", this._majorStep);
            info.AddValue("minorStep", this._minorStep);
            info.AddValue("exponent", this._exponent);
            info.AddValue("baseTic", this._baseTic);
            info.AddValue("minAuto", this._minAuto);
            info.AddValue("maxAuto", this._maxAuto);
            info.AddValue("majorStepAuto", this._majorStepAuto);
            info.AddValue("minorStepAuto", this._minorStepAuto);
            info.AddValue("magAuto", this._magAuto);
            info.AddValue("formatAuto", this._formatAuto);
            info.AddValue("minGrace", this._minGrace);
            info.AddValue("maxGrace", this._maxGrace);
            info.AddValue("mag", this._mag);
            info.AddValue("isReverse", this._isReverse);
            info.AddValue("isPreventLabelOverlap", this._isPreventLabelOverlap);
            info.AddValue("isUseTenPower", this._isUseTenPower);
            info.AddValue("isVisible", this._isVisible);
            info.AddValue("isSkipFirstLabel", this._isSkipFirstLabel);
            info.AddValue("isSkipLastLabel", this._isSkipLastLabel);
            info.AddValue("isSkipCrossLabel", this._isSkipCrossLabel);
            info.AddValue("textLabels", this._textLabels);
            info.AddValue("format", this._format);
            info.AddValue("majorUnit", this._majorUnit);
            info.AddValue("minorUnit", this._minorUnit);
            info.AddValue("isLabelsInside", this._isLabelsInside);
            info.AddValue("align", this._align);
            info.AddValue("alignH", this._alignH);
            info.AddValue("fontSpec", this._fontSpec);
            info.AddValue("labelGap", this._labelGap);
        }

        internal SizeF GetScaleMaxSpace(Graphics g, GraphPane pane, float scaleFactor, bool applyAngle)
        {
            if (!this._isVisible)
            {
                return new SizeF(0f, 0f);
            }
            Math.Pow(10.0, (double) this._mag);
            float angle = this._fontSpec.Angle;
            if (!applyAngle)
            {
                this._fontSpec.Angle = 0f;
            }
            int num4 = this.CalcNumTics();
            double baseVal = this.CalcBaseTic();
            SizeF ef = new SizeF(0f, 0f);
            for (int i = 0; i < num4; i++)
            {
                double dVal = this.CalcMajorTicValue(baseVal, (double) i);
                string text = this._ownerAxis.MakeLabelEventWorks(pane, i, dVal);
                SizeF ef2 = (!this.IsLog || !this._isUseTenPower) ? this._fontSpec.BoundingBox(g, text, scaleFactor) : this._fontSpec.BoundingBoxTenPower(g, text, scaleFactor);
                if (ef2.Height > ef.Height)
                {
                    ef.Height = ef2.Height;
                }
                if (ef2.Width > ef.Width)
                {
                    ef.Width = ef2.Width;
                }
            }
            this._fontSpec.Angle = angle;
            return ef;
        }

        internal void GetTopRightPix(GraphPane pane, out float topPix, out float rightPix)
        {
            if ((this._ownerAxis is XAxis) || (this._ownerAxis is X2Axis))
            {
                rightPix = pane.Chart._rect.Width;
                topPix = -pane.Chart._rect.Height;
            }
            else
            {
                rightPix = pane.Chart._rect.Height;
                topPix = -pane.Chart._rect.Width;
            }
            if (((this._min < this._max) && !this.IsLog) && ((this._majorStep > 0.0) && (this._minorStep > 0.0)))
            {
                double num2 = (this._max - this._min) / (this._minorStep * this.MinorUnitMultiplier);
                MinorTic tic = this._ownerAxis._minorTic;
                if (((((this._max - this._min) / (this._majorStep * this.MajorUnitMultiplier)) <= 1000.0) && (tic.IsOutside || (tic.IsInside || tic.IsOpposite))) && (num2 <= 5000.0))
                {
                }
            }
        }

        public virtual double Linearize(double val) => 
            val;

        public float LocalTransform(double x)
        {
            double num = (x - this._minLinTemp) / (this._maxLinTemp - this._minLinTemp);
            return ((this._isReverse != ((this._ownerAxis is YAxis) || (this._ownerAxis is X2Axis))) ? ((float) ((this._maxPix - this._minPix) * (1.0 - num))) : ((float) ((this._maxPix - this._minPix) * num)));
        }

        internal virtual string MakeLabel(GraphPane pane, int index, double dVal)
        {
            this._format ??= Default.Format;
            double num = Math.Pow(10.0, (double) this._mag);
            return (dVal / num).ToString(this._format);
        }

        public Scale MakeNewScale(Scale oldScale, AxisType type)
        {
            switch (type)
            {
                case AxisType.Linear:
                    return new LinearScale(oldScale, this._ownerAxis);

                case AxisType.Log:
                    return new LogScale(oldScale, this._ownerAxis);

                case AxisType.Date:
                    return new DateScale(oldScale, this._ownerAxis);

                case AxisType.Text:
                    return new TextScale(oldScale, this._ownerAxis);

                case AxisType.Ordinal:
                    return new OrdinalScale(oldScale, this._ownerAxis);

                case AxisType.DateAsOrdinal:
                    return new DateAsOrdinalScale(oldScale, this._ownerAxis);

                case AxisType.LinearAsOrdinal:
                    return new LinearAsOrdinalScale(oldScale, this._ownerAxis);

                case AxisType.Exponent:
                    return new ExponentScale(oldScale, this._ownerAxis);
            }
            throw new Exception("Implementation Error: Invalid AxisType");
        }

        protected double MyMod(double x, double y)
        {
            if (y == 0.0)
            {
                return 0.0;
            }
            double d = x / y;
            return (y * (d - Math.Floor(d)));
        }

        public virtual void PickScale(GraphPane pane, Graphics g, float scaleFactor)
        {
            double d = this._rangeMin;
            double num2 = this._rangeMax;
            if (double.IsInfinity(d) || (double.IsNaN(d) || (d == double.MaxValue)))
            {
                d = 0.0;
            }
            if (double.IsInfinity(num2) || (double.IsNaN(num2) || (num2 == double.MaxValue)))
            {
                num2 = 0.0;
            }
            double num3 = num2 - d;
            bool flag = !this.IsAnyOrdinal;
            if (this._minAuto)
            {
                this._min = d;
                if (flag && ((this._min < 0.0) || ((d - (this._minGrace * num3)) >= 0.0)))
                {
                    this._min = d - (this._minGrace * num3);
                }
            }
            if (this._maxAuto)
            {
                this._max = num2;
                if (flag && ((this._max > 0.0) || ((num2 + (this._maxGrace * num3)) <= 0.0)))
                {
                    this._max = num2 + (this._maxGrace * num3);
                }
            }
            if ((this._max == this._min) && (this._maxAuto && this._minAuto))
            {
                if (Math.Abs(this._max) > 1E-100)
                {
                    this._max *= (this._min < 0.0) ? 0.95 : 1.05;
                    this._min *= (this._min < 0.0) ? 1.05 : 0.95;
                }
                else
                {
                    this._max = 1.0;
                    this._min = -1.0;
                }
            }
            if (this._max <= this._min)
            {
                if (this._maxAuto)
                {
                    this._max = this._min + 1.0;
                }
                else if (this._minAuto)
                {
                    this._min = this._max - 1.0;
                }
            }
        }

        public double ReverseTransform(float pixVal)
        {
            double val = (this._isReverse != ((this._ownerAxis is XAxis) || (this._ownerAxis is X2Axis))) ? (((((double) (pixVal - this._minPix)) / ((double) (this._maxPix - this._minPix))) * (this._maxLinTemp - this._minLinTemp)) + this._minLinTemp) : (((((double) (pixVal - this._maxPix)) / ((double) (this._minPix - this._maxPix))) * (this._maxLinTemp - this._minLinTemp)) + this._minLinTemp);
            return this.DeLinearize(val);
        }

        public static double SafeExp(double x, double exponent) => 
            (x <= 1E-20) ? 0.0 : Math.Pow(x, exponent);

        public static double SafeLog(double x) => 
            (x <= 1E-20) ? 0.0 : Math.Log10(x);

        internal void SetRange(GraphPane pane, Axis axis)
        {
            if ((this._rangeMin >= double.MaxValue) || (this._rangeMax <= double.MinValue))
            {
                if (!ReferenceEquals(axis, pane.XAxis) && (!ReferenceEquals(axis, pane.X2Axis) && ((pane.YAxis.Scale._rangeMin < double.MaxValue) && (pane.YAxis.Scale._rangeMax > double.MinValue))))
                {
                    this._rangeMin = pane.YAxis.Scale._rangeMin;
                    this._rangeMax = pane.YAxis.Scale._rangeMax;
                }
                else if (!ReferenceEquals(axis, pane.XAxis) && (!ReferenceEquals(axis, pane.X2Axis) && ((pane.Y2Axis.Scale._rangeMin < double.MaxValue) && (pane.Y2Axis.Scale._rangeMax > double.MinValue))))
                {
                    this._rangeMin = pane.Y2Axis.Scale._rangeMin;
                    this._rangeMax = pane.Y2Axis.Scale._rangeMax;
                }
                else
                {
                    this._rangeMin = 0.0;
                    this._rangeMax = 1.0;
                }
            }
        }

        internal void SetScaleMag(double min, double max, double step)
        {
            if (this._magAuto)
            {
                double num = -100.0;
                double num2 = -100.0;
                if (Math.Abs(this._min) > 1E-30)
                {
                    num = Math.Floor(Math.Log10(Math.Abs(this._min)));
                }
                if (Math.Abs(this._max) > 1E-30)
                {
                    num2 = Math.Floor(Math.Log10(Math.Abs(this._max)));
                }
                num = Math.Max(num2, num);
                if ((num == -100.0) || (Math.Abs(num) <= 3.0))
                {
                    num = 0.0;
                }
                this._mag = (int) (Math.Floor((double) (num / 3.0)) * 3.0);
            }
            if (this._formatAuto)
            {
                int num3 = -(((int) Math.Floor(Math.Log10(this._majorStep))) - this._mag);
                if (num3 < 0)
                {
                    num3 = 0;
                }
                this._format = "f" + num3.ToString();
            }
        }

        public virtual void SetupScaleData(GraphPane pane, Axis axis)
        {
            if ((axis is XAxis) || (axis is X2Axis))
            {
                this._minPix = pane.Chart._rect.Left;
                this._maxPix = pane.Chart._rect.Right;
            }
            else
            {
                this._minPix = pane.Chart._rect.Top;
                this._maxPix = pane.Chart._rect.Bottom;
            }
            this._minLinTemp = this.Linearize(this._min);
            this._maxLinTemp = this.Linearize(this._max);
        }

        public float Transform(double x)
        {
            double num = this._maxLinTemp - this._minLinTemp;
            double num2 = (num <= 1E-100) ? 0.0 : ((this.Linearize(x) - this._minLinTemp) / num);
            return ((this._isReverse != ((this._ownerAxis is XAxis) || (this._ownerAxis is X2Axis))) ? (this._minPix + ((float) ((this._maxPix - this._minPix) * num2))) : (this._maxPix - ((float) ((this._maxPix - this._minPix) * num2))));
        }

        public float Transform(bool isOverrideOrdinal, int i, double x)
        {
            if (this.IsAnyOrdinal && ((i >= 0) && !isOverrideOrdinal))
            {
                x = i + 1.0;
            }
            return this.Transform(x);
        }

        internal double _minLinearized
        {
            get => 
                this.Linearize(this._min);
            set => 
                this._min = this.DeLinearize(value);
        }

        internal double _maxLinearized
        {
            get => 
                this.Linearize(this._max);
            set => 
                this._max = this.DeLinearize(value);
        }

        public abstract AxisType Type { get; }

        public bool IsLog =>
            this is LogScale;

        public bool IsExponent =>
            this is ExponentScale;

        public bool IsDate =>
            this is DateScale;

        public bool IsText =>
            this is TextScale;

        public bool IsOrdinal =>
            this is OrdinalScale;

        public bool IsAnyOrdinal
        {
            get
            {
                AxisType type = this.Type;
                return ((type == AxisType.Ordinal) || ((type == AxisType.Text) || ((type == AxisType.LinearAsOrdinal) || (type == AxisType.DateAsOrdinal))));
            }
        }

        public virtual double Min
        {
            get => 
                this._min;
            set
            {
                this._min = value;
                this._minAuto = false;
            }
        }

        public virtual double Max
        {
            get => 
                this._max;
            set
            {
                this._max = value;
                this._maxAuto = false;
            }
        }

        public double MajorStep
        {
            get => 
                this._majorStep;
            set
            {
                if (value < 1E-300)
                {
                    this._majorStepAuto = true;
                }
                else
                {
                    this._majorStep = value;
                    this._majorStepAuto = false;
                }
            }
        }

        public double MinorStep
        {
            get => 
                this._minorStep;
            set
            {
                if (value < 1E-300)
                {
                    this._minorStepAuto = true;
                }
                else
                {
                    this._minorStep = value;
                    this._minorStepAuto = false;
                }
            }
        }

        public double Exponent
        {
            get => 
                this._exponent;
            set => 
                this._exponent = value;
        }

        public double BaseTic
        {
            get => 
                this._baseTic;
            set => 
                this._baseTic = value;
        }

        public DateUnit MajorUnit
        {
            get => 
                this._majorUnit;
            set => 
                this._majorUnit = value;
        }

        public DateUnit MinorUnit
        {
            get => 
                this._minorUnit;
            set => 
                this._minorUnit = value;
        }

        internal virtual double MajorUnitMultiplier =>
            1.0;

        internal virtual double MinorUnitMultiplier =>
            1.0;

        public bool MinAuto
        {
            get => 
                this._minAuto;
            set => 
                this._minAuto = value;
        }

        public bool MaxAuto
        {
            get => 
                this._maxAuto;
            set => 
                this._maxAuto = value;
        }

        public bool MajorStepAuto
        {
            get => 
                this._majorStepAuto;
            set => 
                this._majorStepAuto = value;
        }

        public bool MinorStepAuto
        {
            get => 
                this._minorStepAuto;
            set => 
                this._minorStepAuto = value;
        }

        public bool FormatAuto
        {
            get => 
                this._formatAuto;
            set => 
                this._formatAuto = value;
        }

        public string Format
        {
            get => 
                this._format;
            set
            {
                this._format = value;
                this._formatAuto = false;
            }
        }

        public int Mag
        {
            get => 
                this._mag;
            set
            {
                this._mag = value;
                this._magAuto = false;
            }
        }

        public bool MagAuto
        {
            get => 
                this._magAuto;
            set => 
                this._magAuto = value;
        }

        public double MinGrace
        {
            get => 
                this._minGrace;
            set => 
                this._minGrace = value;
        }

        public double MaxGrace
        {
            get => 
                this._maxGrace;
            set => 
                this._maxGrace = value;
        }

        public AlignP Align
        {
            get => 
                this._align;
            set => 
                this._align = value;
        }

        public ZedGraph.AlignH AlignH
        {
            get => 
                this._alignH;
            set => 
                this._alignH = value;
        }

        public ZedGraph.FontSpec FontSpec
        {
            get => 
                this._fontSpec;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Uninitialized FontSpec in Scale");
                }
                this._fontSpec = value;
            }
        }

        public float LabelGap
        {
            get => 
                this._labelGap;
            set => 
                this._labelGap = value;
        }

        public bool IsLabelsInside
        {
            get => 
                this._isLabelsInside;
            set => 
                this._isLabelsInside = value;
        }

        public bool IsSkipFirstLabel
        {
            get => 
                this._isSkipFirstLabel;
            set => 
                this._isSkipFirstLabel = value;
        }

        public bool IsSkipLastLabel
        {
            get => 
                this._isSkipLastLabel;
            set => 
                this._isSkipLastLabel = value;
        }

        public bool IsSkipCrossLabel
        {
            get => 
                this._isSkipCrossLabel;
            set => 
                this._isSkipCrossLabel = value;
        }

        public bool IsReverse
        {
            get => 
                this._isReverse;
            set => 
                this._isReverse = value;
        }

        public bool IsUseTenPower
        {
            get => 
                this._isUseTenPower;
            set => 
                this._isUseTenPower = value;
        }

        public bool IsPreventLabelOverlap
        {
            get => 
                this._isPreventLabelOverlap;
            set => 
                this._isPreventLabelOverlap = value;
        }

        public bool IsVisible
        {
            get => 
                this._isVisible;
            set => 
                this._isVisible = value;
        }

        public string[] TextLabels
        {
            get => 
                this._textLabels;
            set => 
                this._textLabels = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static double ZeroLever;
            public static double MinGrace;
            public static double MaxGrace;
            public static double MaxTextLabels;
            public static double TargetXSteps;
            public static double TargetYSteps;
            public static double TargetMinorXSteps;
            public static double TargetMinorYSteps;
            public static bool IsReverse;
            public static string Format;
            public static double RangeYearYear;
            public static double RangeYearMonth;
            public static double RangeMonthMonth;
            public static double RangeDayDay;
            public static double RangeDayHour;
            public static double RangeHourHour;
            public static double RangeHourMinute;
            public static double RangeMinuteMinute;
            public static double RangeMinuteSecond;
            public static double RangeSecondSecond;
            public static string FormatYearYear;
            public static string FormatYearMonth;
            public static string FormatMonthMonth;
            public static string FormatDayDay;
            public static string FormatDayHour;
            public static string FormatHourHour;
            public static string FormatHourMinute;
            public static string FormatMinuteMinute;
            public static string FormatMinuteSecond;
            public static string FormatSecondSecond;
            public static string FormatMillisecond;
            public static AlignP Align;
            public static ZedGraph.AlignH AlignH;
            public static string FontFamily;
            public static float FontSize;
            public static Color FontColor;
            public static bool FontBold;
            public static bool FontItalic;
            public static bool FontUnderline;
            public static Color FillColor;
            public static Brush FillBrush;
            public static ZedGraph.FillType FillType;
            public static bool IsVisible;
            public static bool IsLabelsInside;
            public static float EdgeTolerance;
            public static float LabelGap;
            static Default()
            {
                ZeroLever = 0.25;
                MinGrace = 0.1;
                MaxGrace = 0.1;
                MaxTextLabels = 12.0;
                TargetXSteps = 7.0;
                TargetYSteps = 7.0;
                TargetMinorXSteps = 5.0;
                TargetMinorYSteps = 5.0;
                IsReverse = false;
                Format = "g";
                RangeYearYear = 1825.0;
                RangeYearMonth = 730.0;
                RangeMonthMonth = 300.0;
                RangeDayDay = 10.0;
                RangeDayHour = 3.0;
                RangeHourHour = 0.4167;
                RangeHourMinute = 0.125;
                RangeMinuteMinute = 0.00694;
                RangeMinuteSecond = 0.002083;
                RangeSecondSecond = 3.472E-05;
                FormatYearYear = "yyyy";
                FormatYearMonth = "MMM-yyyy";
                FormatMonthMonth = "MMM-yyyy";
                FormatDayDay = "d-MMM";
                FormatDayHour = "d-MMM HH:mm";
                FormatHourHour = "HH:mm";
                FormatHourMinute = "HH:mm";
                FormatMinuteMinute = "HH:mm";
                FormatMinuteSecond = "mm:ss";
                FormatSecondSecond = "mm:ss";
                FormatMillisecond = "ss.fff";
                Align = AlignP.Center;
                AlignH = ZedGraph.AlignH.Center;
                FontFamily = "Arial";
                FontSize = 14f;
                FontColor = Color.Black;
                FontBold = false;
                FontItalic = false;
                FontUnderline = false;
                FillColor = Color.White;
                FillBrush = null;
                FillType = ZedGraph.FillType.None;
                IsVisible = true;
                IsLabelsInside = false;
                EdgeTolerance = 6f;
                LabelGap = 0.3f;
            }
        }
    }
}

