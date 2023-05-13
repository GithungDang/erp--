namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    internal class ExponentScale : Scale, ISerializable
    {
        public const int schema2 = 10;

        public ExponentScale(Axis owner) : base(owner)
        {
        }

        protected ExponentScale(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
        }

        public ExponentScale(Scale rhs, Axis owner) : base(rhs, owner)
        {
        }

        internal override double CalcMajorTicValue(double baseVal, double tic) => 
            (base._exponent <= 0.0) ? ((base._exponent >= 0.0) ? 1.0 : Math.Pow(Math.Pow(baseVal, 1.0 / base._exponent) + (base._majorStep * tic), base._exponent)) : Math.Pow(Math.Pow(baseVal, 1.0 / base._exponent) + (base._majorStep * tic), base._exponent);

        internal override int CalcMinorStart(double baseVal) => 
            (int) ((Math.Pow(base._min, base._exponent) - baseVal) / Math.Pow(base._minorStep, base._exponent));

        internal override double CalcMinorTicValue(double baseVal, int iTic) => 
            baseVal + Math.Pow(base._majorStep * iTic, base._exponent);

        public override Scale Clone(Axis owner) => 
            new ExponentScale(this, owner);

        public override double DeLinearize(double val) => 
            Math.Pow(val, 1.0 / base._exponent);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
        }

        public override double Linearize(double val) => 
            SafeExp(val, base._exponent);

        internal override string MakeLabel(GraphPane pane, int index, double dVal)
        {
            base._format ??= Scale.Default.Format;
            double num = Math.Pow(10.0, (double) base._mag);
            return (Math.Pow(dVal, 1.0 / base._exponent) / num).ToString(base._format);
        }

        public override void PickScale(GraphPane pane, Graphics g, float scaleFactor)
        {
            base.PickScale(pane, g, scaleFactor);
            if ((base._max - base._min) < 1E-20)
            {
                if (base._maxAuto)
                {
                    this._max = base._max + (0.2 * ((base._max == 0.0) ? 1.0 : Math.Abs(base._max)));
                }
                if (base._minAuto)
                {
                    this._min = base._min - (0.2 * ((base._min == 0.0) ? 1.0 : Math.Abs(base._min)));
                }
            }
            if (base._minAuto && ((base._min > 0.0) && ((base._min / (base._max - base._min)) < Scale.Default.ZeroLever)))
            {
                base._min = 0.0;
            }
            if (base._maxAuto && ((base._max < 0.0) && (Math.Abs((double) (base._max / (base._max - base._min))) < Scale.Default.ZeroLever)))
            {
                base._max = 0.0;
            }
            if (base._majorStepAuto)
            {
                double targetSteps = ((base._ownerAxis is XAxis) || (base._ownerAxis is X2Axis)) ? Scale.Default.TargetXSteps : Scale.Default.TargetYSteps;
                base._majorStep = CalcStepSize(base._max - base._min, targetSteps);
                if (base._isPreventLabelOverlap)
                {
                    double maxSteps = base.CalcMaxLabels(g, pane, scaleFactor);
                    if (maxSteps < ((base._max - base._min) / base._majorStep))
                    {
                        base._majorStep = base.CalcBoundedStepSize(base._max - base._min, maxSteps);
                    }
                }
            }
            if (base._minorStepAuto)
            {
                this._minorStep = CalcStepSize(base._majorStep, ((base._ownerAxis is XAxis) || (base._ownerAxis is X2Axis)) ? Scale.Default.TargetMinorXSteps : Scale.Default.TargetMinorYSteps);
            }
            if (base._minAuto)
            {
                base._min -= base.MyMod(base._min, base._majorStep);
            }
            if (base._maxAuto)
            {
                this._max = (base.MyMod(base._max, base._majorStep) == 0.0) ? base._max : ((base._max + base._majorStep) - base.MyMod(base._max, base._majorStep));
            }
            if (base._magAuto)
            {
                double num3 = 0.0;
                double num4 = 0.0;
                if (Math.Abs(base._min) > 1E-10)
                {
                    num3 = Math.Floor(Math.Log10(Math.Abs(base._min)));
                }
                if (Math.Abs(base._max) > 1E-10)
                {
                    num4 = Math.Floor(Math.Log10(Math.Abs(base._max)));
                }
                if (Math.Abs(num4) > Math.Abs(num3))
                {
                    num3 = num4;
                }
                if (Math.Abs(num3) <= 3.0)
                {
                    num3 = 0.0;
                }
                base._mag = (int) (Math.Floor((double) (num3 / 3.0)) * 3.0);
            }
            if (base._formatAuto)
            {
                int num5 = -(((int) Math.Floor(Math.Log10(base._majorStep))) - base._mag);
                if (num5 < 0)
                {
                    num5 = 0;
                }
                base._format = "f" + num5.ToString();
            }
        }

        public override void SetupScaleData(GraphPane pane, Axis axis)
        {
            base.SetupScaleData(pane, axis);
            if (base._exponent > 0.0)
            {
                base._minLinTemp = this.Linearize(base._min);
                base._maxLinTemp = this.Linearize(base._max);
            }
            else if (base._exponent < 0.0)
            {
                base._minLinTemp = this.Linearize(base._max);
                base._maxLinTemp = this.Linearize(base._min);
            }
        }

        public override AxisType Type =>
            AxisType.Exponent;
    }
}

