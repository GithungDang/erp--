namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    internal class TextScale : Scale, ISerializable
    {
        public const int schema2 = 10;

        public TextScale(Axis owner) : base(owner)
        {
        }

        protected TextScale(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
        }

        public TextScale(Scale rhs, Axis owner) : base(rhs, owner)
        {
        }

        internal override double CalcBaseTic() => 
            (base._baseTic == double.MaxValue) ? 1.0 : base._baseTic;

        internal override int CalcMinorStart(double baseVal) => 
            0;

        internal override int CalcNumTics()
        {
            int num = 1;
            num = (base._textLabels != null) ? base._textLabels.Length : 10;
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
            new TextScale(this, owner);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
        }

        internal override string MakeLabel(GraphPane pane, int index, double dVal)
        {
            base._format ??= Scale.Default.Format;
            index *= (int) base._majorStep;
            return (((base._textLabels == null) || ((index < 0) || (index >= base._textLabels.Length))) ? string.Empty : base._textLabels[index]);
        }

        public override void PickScale(GraphPane pane, Graphics g, float scaleFactor)
        {
            base.PickScale(pane, g, scaleFactor);
            if (base._textLabels != null)
            {
                if (base._minAuto)
                {
                    base._min = 0.5;
                }
                if (base._maxAuto)
                {
                    base._max = base._textLabels.Length + 0.5;
                }
            }
            else
            {
                if (base._minAuto)
                {
                    base._min -= 0.5;
                }
                if (base._maxAuto)
                {
                    base._max += 0.5;
                }
            }
            if ((base._max - base._min) < 0.1)
            {
                if (base._maxAuto)
                {
                    base._max = base._min + 10.0;
                }
                else
                {
                    base._min = base._max - 10.0;
                }
            }
            if (!base._majorStepAuto)
            {
                base._majorStep = (int) base._majorStep;
                if (base._majorStep <= 0.0)
                {
                    base._majorStep = 1.0;
                }
            }
            else if (!base._isPreventLabelOverlap)
            {
                base._majorStep = 1.0;
            }
            else if (base._textLabels == null)
            {
                base._majorStep = ((int) (((base._max - base._min) - 1.0) / Scale.Default.MaxTextLabels)) + 1.0;
            }
            else
            {
                double num = base.CalcMaxLabels(g, pane, scaleFactor);
                double num2 = Math.Ceiling((double) ((base._max - base._min) / num));
                base._majorStep = num2;
            }
            if (base._minorStepAuto)
            {
                base._minorStep = base._majorStep / 10.0;
                if (base._minorStep < 1.0)
                {
                    base._minorStep = 1.0;
                }
            }
            base._mag = 0;
        }

        public override AxisType Type =>
            AxisType.Text;
    }
}

