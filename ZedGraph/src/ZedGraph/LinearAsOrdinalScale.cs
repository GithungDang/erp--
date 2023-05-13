namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    internal class LinearAsOrdinalScale : Scale, ISerializable
    {
        public const int schema2 = 10;

        public LinearAsOrdinalScale(Axis owner) : base(owner)
        {
        }

        protected LinearAsOrdinalScale(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
        }

        public LinearAsOrdinalScale(Scale rhs, Axis owner) : base(rhs, owner)
        {
        }

        public override Scale Clone(Axis owner) => 
            new LinearAsOrdinalScale(this, owner);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
        }

        internal override string MakeLabel(GraphPane pane, int index, double dVal)
        {
            base._format ??= Scale.Default.Format;
            int num2 = ((int) dVal) - 1;
            return (((pane.CurveList.Count <= 0) || (pane.CurveList[0].Points.Count <= num2)) ? string.Empty : (pane.CurveList[0].Points[num2].X / Math.Pow(10.0, (double) base._mag)).ToString(base._format));
        }

        public override void PickScale(GraphPane pane, Graphics g, float scaleFactor)
        {
            base.PickScale(pane, g, scaleFactor);
            double min = 0.0;
            double max = 1.0;
            foreach (CurveItem item in pane.CurveList)
            {
                if ((((base._ownerAxis is Y2Axis) && item.IsY2Axis) || (((base._ownerAxis is YAxis) && !item.IsY2Axis) || ((base._ownerAxis is X2Axis) && item.IsX2Axis))) || ((base._ownerAxis is XAxis) && !item.IsX2Axis))
                {
                    double num;
                    double num2;
                    double num3;
                    double num4;
                    item.GetRange(out num, out num2, out num3, out num4, false, false, pane);
                    if (!(base._ownerAxis is XAxis) && !(base._ownerAxis is X2Axis))
                    {
                        min = num3;
                        max = num4;
                    }
                    else
                    {
                        min = num;
                        max = num2;
                    }
                }
            }
            base.PickScale(pane, g, scaleFactor);
            OrdinalScale.PickScale(pane, g, scaleFactor, this);
            base.SetScaleMag(min, max, Math.Abs((double) (max - min)) / Scale.Default.TargetXSteps);
        }

        public override AxisType Type =>
            AxisType.LinearAsOrdinal;
    }
}

