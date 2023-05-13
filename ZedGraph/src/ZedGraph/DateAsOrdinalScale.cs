namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    internal class DateAsOrdinalScale : Scale, ISerializable
    {
        public const int schema2 = 10;

        public DateAsOrdinalScale(Axis owner) : base(owner)
        {
        }

        protected DateAsOrdinalScale(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
        }

        public DateAsOrdinalScale(Scale rhs, Axis owner) : base(rhs, owner)
        {
        }

        public override Scale Clone(Axis owner) => 
            new DateAsOrdinalScale(this, owner);

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
            if ((pane.CurveList.Count <= 0) || (pane.CurveList[0].Points.Count <= num2))
            {
                return string.Empty;
            }
            double xlDate = ((base._ownerAxis is XAxis) || (base._ownerAxis is X2Axis)) ? pane.CurveList[0].Points[num2].X : pane.CurveList[0].Points[num2].Y;
            return XDate.ToString(xlDate, base._format);
        }

        public override void PickScale(GraphPane pane, Graphics g, float scaleFactor)
        {
            base.PickScale(pane, g, scaleFactor);
            this.SetDateFormat(pane);
            base.PickScale(pane, g, scaleFactor);
            OrdinalScale.PickScale(pane, g, scaleFactor, this);
        }

        internal void SetDateFormat(GraphPane pane)
        {
            if (base._formatAuto)
            {
                double num = 10.0;
                if ((pane.CurveList.Count > 0) && (pane.CurveList[0].Points.Count > 1))
                {
                    double x;
                    double y;
                    PointPair pair = pane.CurveList[0].Points[0];
                    PointPair pair2 = pane.CurveList[0].Points[pane.CurveList[0].Points.Count - 1];
                    int num4 = 1;
                    int count = pane.CurveList[0].Points.Count;
                    if (pane.IsBoundedRanges)
                    {
                        num4 = Math.Min(Math.Max((int) Math.Floor(base._ownerAxis.Scale.Min), 1), pane.CurveList[0].Points.Count);
                        count = Math.Min(Math.Max((int) Math.Ceiling(base._ownerAxis.Scale.Max), 1), pane.CurveList[0].Points.Count);
                        if (count > num4)
                        {
                            pair = pane.CurveList[0].Points[num4 - 1];
                            pair2 = pane.CurveList[0].Points[count - 1];
                        }
                    }
                    if ((base._ownerAxis is XAxis) || (base._ownerAxis is X2Axis))
                    {
                        x = pair.X;
                        y = pair2.X;
                    }
                    else
                    {
                        x = pair.Y;
                        y = pair2.Y;
                    }
                    if ((x != double.MaxValue) && ((y != double.MaxValue) && (!double.IsNaN(x) && (!double.IsNaN(y) && (!double.IsInfinity(x) && (!double.IsInfinity(y) && (Math.Abs((double) (y - x)) > 1E-10)))))))
                    {
                        num = Math.Abs((double) (y - x));
                    }
                }
                if (num > Scale.Default.RangeYearYear)
                {
                    base._format = Scale.Default.FormatYearYear;
                }
                else if (num > Scale.Default.RangeYearMonth)
                {
                    base._format = Scale.Default.FormatYearMonth;
                }
                else if (num > Scale.Default.RangeMonthMonth)
                {
                    base._format = Scale.Default.FormatMonthMonth;
                }
                else if (num > Scale.Default.RangeDayDay)
                {
                    base._format = Scale.Default.FormatDayDay;
                }
                else if (num > Scale.Default.RangeDayHour)
                {
                    base._format = Scale.Default.FormatDayHour;
                }
                else if (num > Scale.Default.RangeHourHour)
                {
                    base._format = Scale.Default.FormatHourHour;
                }
                else if (num > Scale.Default.RangeHourMinute)
                {
                    base._format = Scale.Default.FormatHourMinute;
                }
                else if (num > Scale.Default.RangeMinuteMinute)
                {
                    base._format = Scale.Default.FormatMinuteMinute;
                }
                else if (num > Scale.Default.RangeMinuteSecond)
                {
                    base._format = Scale.Default.FormatMinuteSecond;
                }
                else if (num > Scale.Default.RangeSecondSecond)
                {
                    base._format = Scale.Default.FormatSecondSecond;
                }
                else
                {
                    base._format = Scale.Default.FormatMillisecond;
                }
            }
        }

        public override AxisType Type =>
            AxisType.DateAsOrdinal;

        public override double Min
        {
            get => 
                base._min;
            set
            {
                base._min = XDate.MakeValidDate(value);
                base._minAuto = false;
            }
        }

        public override double Max
        {
            get => 
                base._max;
            set
            {
                base._max = XDate.MakeValidDate(value);
                base._maxAuto = false;
            }
        }
    }
}

