namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    internal class LinearScale : Scale, ISerializable
    {
        public const int schema2 = 10;

        public LinearScale(Axis owner) : base(owner)
        {
        }

        protected LinearScale(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
        }

        public LinearScale(Scale rhs, Axis owner) : base(rhs, owner)
        {
        }

        public override Scale Clone(Axis owner) => 
            new LinearScale(this, owner);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
        }

        public override void PickScale(GraphPane pane, Graphics g, float scaleFactor)
        {
            base.PickScale(pane, g, scaleFactor);
            if ((base._max - base._min) < 1E-30)
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
            base.SetScaleMag(base._min, base._max, base._majorStep);
        }

        public override AxisType Type =>
            AxisType.Linear;
    }
}

