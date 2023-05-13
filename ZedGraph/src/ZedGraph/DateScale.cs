namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    internal class DateScale : Scale, ISerializable
    {
        public const int schema2 = 10;

        public DateScale(Axis owner) : base(owner)
        {
        }

        protected DateScale(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
        }

        public DateScale(Scale rhs, Axis owner) : base(rhs, owner)
        {
        }

        internal override double CalcBaseTic()
        {
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            if (base._baseTic != double.MaxValue)
            {
                return base._baseTic;
            }
            XDate.XLDateToCalendarDate(base._min, out num, out num2, out num3, out num4, out num5, out num6, out num7);
            switch (base._majorUnit)
            {
                case DateUnit.Month:
                    num3 = 1;
                    num4 = 0;
                    num5 = 0;
                    num6 = 0;
                    num7 = 0;
                    break;

                case DateUnit.Day:
                    num4 = 0;
                    num5 = 0;
                    num6 = 0;
                    num7 = 0;
                    break;

                case DateUnit.Hour:
                    num5 = 0;
                    num6 = 0;
                    num7 = 0;
                    break;

                case DateUnit.Minute:
                    num6 = 0;
                    num7 = 0;
                    break;

                case DateUnit.Second:
                    num7 = 0;
                    break;

                case DateUnit.Millisecond:
                    break;

                default:
                    num2 = 1;
                    num3 = 1;
                    num4 = 0;
                    num5 = 0;
                    num6 = 0;
                    num7 = 0;
                    break;
            }
            double num8 = XDate.CalendarDateToXLDate(num, num2, num3, num4, num5, num6, num7);
            if (num8 < base._min)
            {
                switch (base._majorUnit)
                {
                    case DateUnit.Month:
                        num2++;
                        break;

                    case DateUnit.Day:
                        num3++;
                        break;

                    case DateUnit.Hour:
                        num4++;
                        break;

                    case DateUnit.Minute:
                        num5++;
                        break;

                    case DateUnit.Second:
                        num6++;
                        break;

                    case DateUnit.Millisecond:
                        num7++;
                        break;

                    default:
                        num++;
                        break;
                }
                num8 = XDate.CalendarDateToXLDate(num, num2, num3, num4, num5, num6, num7);
            }
            return num8;
        }

        protected double CalcDateStepSize(double range, double targetSteps) => 
            CalcDateStepSize(range, targetSteps, this);

        internal static double CalcDateStepSize(double range, double targetSteps, Scale scale)
        {
            double num = range / targetSteps;
            if (range > Scale.Default.RangeYearYear)
            {
                scale._majorUnit = DateUnit.Year;
                if (scale._formatAuto)
                {
                    scale._format = Scale.Default.FormatYearYear;
                }
                num = Math.Ceiling((double) (num / 365.0));
                if (scale._minorStepAuto)
                {
                    scale._minorUnit = DateUnit.Year;
                    scale._minorStep = (num != 1.0) ? CalcStepSize(num, targetSteps) : 0.25;
                }
            }
            else if (range > Scale.Default.RangeYearMonth)
            {
                scale._majorUnit = DateUnit.Year;
                if (scale._formatAuto)
                {
                    scale._format = Scale.Default.FormatYearMonth;
                }
                num = Math.Ceiling((double) (num / 365.0));
                if (scale._minorStepAuto)
                {
                    scale._minorUnit = DateUnit.Month;
                    scale._minorStep = Math.Ceiling((double) ((range / (targetSteps * 3.0)) / 30.0));
                    if (scale._minorStep > 6.0)
                    {
                        scale._minorStep = 12.0;
                    }
                    else if (scale._minorStep > 3.0)
                    {
                        scale._minorStep = 6.0;
                    }
                }
            }
            else if (range > Scale.Default.RangeMonthMonth)
            {
                scale._majorUnit = DateUnit.Month;
                if (scale._formatAuto)
                {
                    scale._format = Scale.Default.FormatMonthMonth;
                }
                num = Math.Ceiling((double) (num / 30.0));
                if (scale._minorStepAuto)
                {
                    scale._minorUnit = DateUnit.Month;
                    scale._minorStep = num * 0.25;
                }
            }
            else if (range > Scale.Default.RangeDayDay)
            {
                scale._majorUnit = DateUnit.Day;
                if (scale._formatAuto)
                {
                    scale._format = Scale.Default.FormatDayDay;
                }
                num = Math.Ceiling(num);
                if (scale._minorStepAuto)
                {
                    scale._minorUnit = DateUnit.Day;
                    scale._minorStep = num * 0.25;
                }
            }
            else if (range > Scale.Default.RangeDayHour)
            {
                scale._majorUnit = DateUnit.Day;
                if (scale._formatAuto)
                {
                    scale._format = Scale.Default.FormatDayHour;
                }
                num = Math.Ceiling(num);
                if (scale._minorStepAuto)
                {
                    scale._minorUnit = DateUnit.Hour;
                    scale._minorStep = Math.Ceiling((double) ((range / (targetSteps * 3.0)) * 24.0));
                    scale._minorStep = (scale._minorStep <= 6.0) ? ((scale._minorStep <= 3.0) ? 1.0 : 6.0) : 12.0;
                }
            }
            else if (range > Scale.Default.RangeHourHour)
            {
                scale._majorUnit = DateUnit.Hour;
                num = Math.Ceiling((double) (num * 24.0));
                if (scale._formatAuto)
                {
                    scale._format = Scale.Default.FormatHourHour;
                }
                num = (num <= 12.0) ? ((num <= 6.0) ? ((num <= 2.0) ? ((num <= 1.0) ? 1.0 : 2.0) : 6.0) : 12.0) : 24.0;
                if (scale._minorStepAuto)
                {
                    scale._minorUnit = DateUnit.Hour;
                    scale._minorStep = (num > 1.0) ? ((num > 6.0) ? ((num > 12.0) ? 4.0 : 2.0) : 1.0) : 0.25;
                }
            }
            else if (range > Scale.Default.RangeHourMinute)
            {
                scale._majorUnit = DateUnit.Hour;
                num = Math.Ceiling((double) (num * 24.0));
                if (scale._formatAuto)
                {
                    scale._format = Scale.Default.FormatHourMinute;
                }
                if (scale._minorStepAuto)
                {
                    scale._minorUnit = DateUnit.Minute;
                    scale._minorStep = Math.Ceiling((double) ((range / (targetSteps * 3.0)) * 1440.0));
                    scale._minorStep = (scale._minorStep <= 15.0) ? ((scale._minorStep <= 5.0) ? ((scale._minorStep <= 1.0) ? 1.0 : 5.0) : 15.0) : 30.0;
                }
            }
            else if (range > Scale.Default.RangeMinuteMinute)
            {
                scale._majorUnit = DateUnit.Minute;
                if (scale._formatAuto)
                {
                    scale._format = Scale.Default.FormatMinuteMinute;
                }
                num = Math.Ceiling((double) (num * 1440.0));
                num = (num <= 15.0) ? ((num <= 5.0) ? ((num <= 1.0) ? 1.0 : 5.0) : 15.0) : 30.0;
                if (scale._minorStepAuto)
                {
                    scale._minorUnit = DateUnit.Minute;
                    scale._minorStep = (num > 1.0) ? ((num > 5.0) ? 5.0 : 1.0) : 0.25;
                }
            }
            else if (range > Scale.Default.RangeMinuteSecond)
            {
                scale._majorUnit = DateUnit.Minute;
                num = Math.Ceiling((double) (num * 1440.0));
                if (scale._formatAuto)
                {
                    scale._format = Scale.Default.FormatMinuteSecond;
                }
                if (scale._minorStepAuto)
                {
                    scale._minorUnit = DateUnit.Second;
                    scale._minorStep = Math.Ceiling((double) ((range / (targetSteps * 3.0)) * 86400.0));
                    scale._minorStep = (scale._minorStep <= 15.0) ? ((scale._minorStep <= 5.0) ? ((scale._minorStep <= 1.0) ? 1.0 : 5.0) : 15.0) : 30.0;
                }
            }
            else if (range <= Scale.Default.RangeSecondSecond)
            {
                scale._majorUnit = DateUnit.Millisecond;
                if (scale._formatAuto)
                {
                    scale._format = Scale.Default.FormatMillisecond;
                }
                num = CalcStepSize(range * 86400000.0, Scale.Default.TargetXSteps);
                if (scale._minorStepAuto)
                {
                    scale._minorStep = CalcStepSize(num, ((scale._ownerAxis is XAxis) || (scale._ownerAxis is X2Axis)) ? Scale.Default.TargetMinorXSteps : Scale.Default.TargetMinorYSteps);
                    scale._minorUnit = DateUnit.Millisecond;
                }
            }
            else
            {
                scale._majorUnit = DateUnit.Second;
                if (scale._formatAuto)
                {
                    scale._format = Scale.Default.FormatSecondSecond;
                }
                num = Math.Ceiling((double) (num * 86400.0));
                num = (num <= 15.0) ? ((num <= 5.0) ? ((num <= 1.0) ? 1.0 : 5.0) : 15.0) : 30.0;
                if (scale._minorStepAuto)
                {
                    scale._minorUnit = DateUnit.Second;
                    scale._minorStep = (num > 1.0) ? ((num > 5.0) ? 5.0 : 1.0) : 0.25;
                }
            }
            return num;
        }

        protected double CalcEvenStepDate(double date, int direction)
        {
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            XDate.XLDateToCalendarDate(date, out num, out num2, out num3, out num4, out num5, out num6, out num7);
            if (direction < 0)
            {
                direction = 0;
            }
            switch (base._majorUnit)
            {
                case DateUnit.Month:
                    return (((direction != 1) || ((num3 != 1) || ((num4 != 0) || ((num5 != 0) || (num6 != 0))))) ? XDate.CalendarDateToXLDate(num, num2 + direction, 1, 0, 0, 0) : date);

                case DateUnit.Day:
                    return (((direction != 1) || ((num4 != 0) || ((num5 != 0) || (num6 != 0)))) ? XDate.CalendarDateToXLDate(num, num2, num3 + direction, 0, 0, 0) : date);

                case DateUnit.Hour:
                    return (((direction != 1) || ((num5 != 0) || (num6 != 0))) ? XDate.CalendarDateToXLDate(num, num2, num3, num4 + direction, 0, 0) : date);

                case DateUnit.Minute:
                    return (((direction != 1) || (num6 != 0)) ? XDate.CalendarDateToXLDate(num, num2, num3, num4, num5 + direction, 0) : date);

                case DateUnit.Second:
                    return XDate.CalendarDateToXLDate(num, num2, num3, num4, num5, (int) (num6 + direction));

                case DateUnit.Millisecond:
                    return XDate.CalendarDateToXLDate(num, num2, num3, num4, num5, num6, num7 + direction);
            }
            return (((direction != 1) || ((num2 != 1) || ((num3 != 1) || ((num4 != 0) || ((num5 != 0) || (num6 != 0)))))) ? XDate.CalendarDateToXLDate(num + direction, 1, 1, 0, 0, 0) : date);
        }

        internal override double CalcMajorTicValue(double baseVal, double tic)
        {
            XDate date = new XDate(baseVal);
            switch (base._majorUnit)
            {
                case DateUnit.Month:
                    date.AddMonths(tic * base._majorStep);
                    break;

                case DateUnit.Day:
                    date.AddDays(tic * base._majorStep);
                    break;

                case DateUnit.Hour:
                    date.AddHours(tic * base._majorStep);
                    break;

                case DateUnit.Minute:
                    date.AddMinutes(tic * base._majorStep);
                    break;

                case DateUnit.Second:
                    date.AddSeconds(tic * base._majorStep);
                    break;

                case DateUnit.Millisecond:
                    date.AddMilliseconds(tic * base._majorStep);
                    break;

                default:
                    date.AddYears(tic * base._majorStep);
                    break;
            }
            return date.XLDate;
        }

        internal override int CalcMinorStart(double baseVal)
        {
            switch (base._minorUnit)
            {
                case DateUnit.Month:
                    return (int) ((base._min - baseVal) / (28.0 * base._minorStep));

                case DateUnit.Day:
                    return (int) ((base._min - baseVal) / base._minorStep);

                case DateUnit.Hour:
                    return (int) (((base._min - baseVal) * 24.0) / base._minorStep);

                case DateUnit.Minute:
                    return (int) (((base._min - baseVal) * 1440.0) / base._minorStep);

                case DateUnit.Second:
                    return (int) (((base._min - baseVal) * 86400.0) / base._minorStep);
            }
            return (int) ((base._min - baseVal) / (365.0 * base._minorStep));
        }

        internal override double CalcMinorTicValue(double baseVal, int iTic)
        {
            XDate date = new XDate(baseVal);
            switch (base._minorUnit)
            {
                case DateUnit.Month:
                    date.AddMonths(iTic * base._minorStep);
                    break;

                case DateUnit.Day:
                    date.AddDays(iTic * base._minorStep);
                    break;

                case DateUnit.Hour:
                    date.AddHours(iTic * base._minorStep);
                    break;

                case DateUnit.Minute:
                    date.AddMinutes(iTic * base._minorStep);
                    break;

                case DateUnit.Second:
                    date.AddSeconds(iTic * base._minorStep);
                    break;

                default:
                    date.AddYears(iTic * base._minorStep);
                    break;
            }
            return date.XLDate;
        }

        internal override int CalcNumTics()
        {
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num10;
            int num11;
            int num12;
            int num13;
            int num14;
            int num15;
            int num = 1;
            XDate.XLDateToCalendarDate(base._min, out num2, out num4, out num6, out num8, out num10, out num12, out num14);
            XDate.XLDateToCalendarDate(base._max, out num3, out num5, out num7, out num9, out num11, out num13, out num15);
            switch (base._majorUnit)
            {
                case DateUnit.Month:
                    num = (int) ((((num5 - num4) + (12.0 * (num3 - num2))) / base._majorStep) + 1.001);
                    break;

                case DateUnit.Day:
                    num = (int) (((base._max - base._min) / base._majorStep) + 1.001);
                    break;

                case DateUnit.Hour:
                    num = (int) (((base._max - base._min) / (base._majorStep / 24.0)) + 1.001);
                    break;

                case DateUnit.Minute:
                    num = (int) (((base._max - base._min) / (base._majorStep / 1440.0)) + 1.001);
                    break;

                case DateUnit.Second:
                    num = (int) (((base._max - base._min) / (base._majorStep / 86400.0)) + 1.001);
                    break;

                case DateUnit.Millisecond:
                    num = (int) (((base._max - base._min) / (base._majorStep / 86400000.0)) + 1.001);
                    break;

                default:
                    num = (int) ((((double) (num3 - num2)) / base._majorStep) + 1.001);
                    break;
            }
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
            new DateScale(this, owner);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
        }

        private double GetUnitMultiple(DateUnit unit)
        {
            switch (unit)
            {
                case DateUnit.Month:
                    return 30.0;

                case DateUnit.Day:
                    return 1.0;

                case DateUnit.Hour:
                    return 0.041666666666666664;

                case DateUnit.Minute:
                    return 0.00069444444444444447;

                case DateUnit.Second:
                    return 1.1574074074074073E-05;

                case DateUnit.Millisecond:
                    return 1.1574074074074074E-08;
            }
            return 365.0;
        }

        internal override string MakeLabel(GraphPane pane, int index, double dVal)
        {
            base._format ??= Scale.Default.Format;
            return XDate.ToString(dVal, base._format);
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
            double targetSteps = ((base._ownerAxis is XAxis) || (base._ownerAxis is X2Axis)) ? Scale.Default.TargetXSteps : Scale.Default.TargetYSteps;
            double num2 = this.CalcDateStepSize(base._max - base._min, targetSteps);
            if (base._majorStepAuto)
            {
                base._majorStep = num2;
                if (base._isPreventLabelOverlap)
                {
                    double num3 = base.CalcMaxLabels(g, pane, scaleFactor);
                    if (num3 < this.CalcNumTics())
                    {
                        base._majorStep = this.CalcDateStepSize(base._max - base._min, num3);
                    }
                }
            }
            if (base._minAuto)
            {
                base._min = this.CalcEvenStepDate(base._min, -1);
            }
            if (base._maxAuto)
            {
                base._max = this.CalcEvenStepDate(base._max, 1);
            }
            base._mag = 0;
        }

        public override AxisType Type =>
            AxisType.Date;

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

        internal override double MajorUnitMultiplier =>
            this.GetUnitMultiple(base._majorUnit);

        internal override double MinorUnitMultiplier =>
            this.GetUnitMultiple(base._minorUnit);
    }
}

