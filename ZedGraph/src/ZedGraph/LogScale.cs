namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    internal class LogScale : Scale, ISerializable
    {
        public const int schema2 = 10;

        public LogScale(Axis owner) : base(owner)
        {
        }

        protected LogScale(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
        }

        public LogScale(Scale rhs, Axis owner) : base(rhs, owner)
        {
        }

        internal override double CalcBaseTic() => 
            (base._baseTic == double.MaxValue) ? Math.Ceiling((double) (SafeLog(base._min) - 1E-08)) : base._baseTic;

        internal override double CalcMajorTicValue(double baseVal, double tic) => 
            baseVal + (tic * this.CyclesPerStep);

        internal override int CalcMinorStart(double baseVal) => 
            -9;

        internal override double CalcMinorTicValue(double baseVal, int iTic)
        {
            double[] numArray = new double[] { 0.0, 0.301029995663981, 0.477121254719662, 0.602059991327962, 0.698970004336019, 0.778151250383644, 0.845098040014257, 0.903089986991944, 0.954242509439325, 1.0 };
            return ((baseVal + Math.Floor((double) (((double) iTic) / 9.0))) + numArray[(iTic + 9) % 9]);
        }

        internal override int CalcNumTics()
        {
            int num = 1;
            num = ((int) ((SafeLog(base._max) - SafeLog(base._min)) / this.CyclesPerStep)) + 1;
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

        public override Scale Clone(Axis owner) => 
            new LogScale(this, owner);

        public override double DeLinearize(double val) => 
            Math.Pow(10.0, val);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
        }

        public override double Linearize(double val) => 
            SafeLog(val);

        internal override string MakeLabel(GraphPane pane, int index, double dVal)
        {
            base._format ??= Scale.Default.Format;
            return (!base._isUseTenPower ? Math.Pow(10.0, dVal).ToString(base._format) : $"{dVal:F0}");
        }

        public override void PickScale(GraphPane pane, Graphics g, float scaleFactor)
        {
            base.PickScale(pane, g, scaleFactor);
            if (base._majorStepAuto)
            {
                base._majorStep = 1.0;
            }
            base._mag = 0;
            if ((base._min <= 0.0) && (base._max <= 0.0))
            {
                base._min = 1.0;
                base._max = 10.0;
            }
            else if (base._min <= 0.0)
            {
                base._min = base._max / 10.0;
            }
            else if (base._max <= 0.0)
            {
                base._max = base._min * 10.0;
            }
            if ((base._max - base._min) < 1E-20)
            {
                if (base._maxAuto)
                {
                    base._max *= 2.0;
                }
                if (base._minAuto)
                {
                    base._min /= 2.0;
                }
            }
            if (base._minAuto)
            {
                base._min = Math.Pow(10.0, Math.Floor(Math.Log10(base._min)));
            }
            if (base._maxAuto)
            {
                base._max = Math.Pow(10.0, Math.Ceiling(Math.Log10(base._max)));
            }
        }

        public override void SetupScaleData(GraphPane pane, Axis axis)
        {
            base.SetupScaleData(pane, axis);
            base._minLinTemp = this.Linearize(base._min);
            base._maxLinTemp = this.Linearize(base._max);
        }

        public override AxisType Type =>
            AxisType.Log;

        public override double Min
        {
            get => 
                base._min;
            set
            {
                if (value > 0.0)
                {
                    base._min = value;
                }
            }
        }

        public override double Max
        {
            get => 
                base._max;
            set
            {
                if (value > 0.0)
                {
                    base._max = value;
                }
            }
        }

        private double CyclesPerStep =>
            base._majorStep;
    }
}

