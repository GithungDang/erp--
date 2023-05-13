namespace ZedGraph
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct XDate : IComparable
    {
        public const double XLDay1 = 2415018.5;
        public const double JulDayMin = 0.0;
        public const double JulDayMax = 5373483.5;
        public const double XLDayMin = -2415018.5;
        public const double XLDayMax = 2958465.0;
        public const double MonthsPerYear = 12.0;
        public const double HoursPerDay = 24.0;
        public const double MinutesPerHour = 60.0;
        public const double SecondsPerMinute = 60.0;
        public const double MinutesPerDay = 1440.0;
        public const double SecondsPerDay = 86400.0;
        public const double MillisecondsPerSecond = 1000.0;
        public const double MillisecondsPerDay = 86400000.0;
        public const string DefaultFormatStr = "g";
        private double _xlDate;
        public XDate(double xlDate)
        {
            this._xlDate = xlDate;
        }

        public XDate(System.DateTime dateTime)
        {
            this._xlDate = CalendarDateToXLDate(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
        }

        public XDate(int year, int month, int day)
        {
            this._xlDate = CalendarDateToXLDate(year, month, day, 0, 0, 0);
        }

        public XDate(int year, int month, int day, int hour, int minute, int second)
        {
            this._xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second);
        }

        public XDate(int year, int month, int day, int hour, int minute, double second)
        {
            this._xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second);
        }

        public XDate(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            this._xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second, millisecond);
        }

        public XDate(XDate rhs)
        {
            this._xlDate = rhs._xlDate;
        }

        public double XLDate
        {
            get => 
                this._xlDate;
            set => 
                this._xlDate = value;
        }
        public bool IsValidDate =>
            (this._xlDate >= -2415018.5) && (this._xlDate <= 2958465.0);
        public System.DateTime DateTime
        {
            get => 
                XLDateToDateTime(this._xlDate);
            set => 
                this._xlDate = DateTimeToXLDate(value);
        }
        public double JulianDay
        {
            get => 
                XLDateToJulianDay(this._xlDate);
            set => 
                this._xlDate = JulianDayToXLDate(value);
        }
        public double DecimalYear
        {
            get => 
                XLDateToDecimalYear(this._xlDate);
            set => 
                this._xlDate = DecimalYearToXLDate(value);
        }
        private static bool CheckValidDate(double xlDate) => 
            (xlDate >= -2415018.5) && (xlDate <= 2958465.0);

        public static double MakeValidDate(double xlDate)
        {
            if (xlDate < -2415018.5)
            {
                xlDate = -2415018.5;
            }
            if (xlDate > 2958465.0)
            {
                xlDate = 2958465.0;
            }
            return xlDate;
        }

        public void GetDate(out int year, out int month, out int day)
        {
            int num;
            int num2;
            int num3;
            XLDateToCalendarDate(this._xlDate, out year, out month, out day, out num, out num2, out num3);
        }

        public void SetDate(int year, int month, int day)
        {
            this._xlDate = CalendarDateToXLDate(year, month, day, 0, 0, 0);
        }

        public void GetDate(out int year, out int month, out int day, out int hour, out int minute, out int second)
        {
            XLDateToCalendarDate(this._xlDate, out year, out month, out day, out hour, out minute, out second);
        }

        public void SetDate(int year, int month, int day, int hour, int minute, int second)
        {
            this._xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second);
        }

        public double GetDayOfYear() => 
            XLDateToDayOfYear(this._xlDate);

        public static double CalendarDateToXLDate(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            double num = millisecond;
            NormalizeCalendarDate(ref year, ref month, ref day, ref hour, ref minute, ref second, ref num);
            return _CalendarDateToXLDate(year, month, day, hour, minute, second, num);
        }

        public static double CalendarDateToXLDate(int year, int month, int day, int hour, int minute, int second)
        {
            double millisecond = 0.0;
            NormalizeCalendarDate(ref year, ref month, ref day, ref hour, ref minute, ref second, ref millisecond);
            return _CalendarDateToXLDate(year, month, day, hour, minute, second, millisecond);
        }

        public static double CalendarDateToXLDate(int year, int month, int day, int hour, int minute, double second)
        {
            int num = (int) second;
            double millisecond = (second - num) * 1000.0;
            NormalizeCalendarDate(ref year, ref month, ref day, ref hour, ref minute, ref num, ref millisecond);
            return _CalendarDateToXLDate(year, month, day, hour, minute, num, millisecond);
        }

        public static double CalendarDateToJulianDay(int year, int month, int day, int hour, int minute, int second)
        {
            double millisecond = 0.0;
            NormalizeCalendarDate(ref year, ref month, ref day, ref hour, ref minute, ref second, ref millisecond);
            return _CalendarDateToJulianDay(year, month, day, hour, minute, second, millisecond);
        }

        public static double CalendarDateToJulianDay(int year, int month, int day, int hour, int minute, int second, int millisecond)
        {
            double num = millisecond;
            NormalizeCalendarDate(ref year, ref month, ref day, ref hour, ref minute, ref second, ref num);
            return _CalendarDateToJulianDay(year, month, day, hour, minute, second, num);
        }

        private static void NormalizeCalendarDate(ref int year, ref int month, ref int day, ref int hour, ref int minute, ref int second, ref double millisecond)
        {
            int num = (int) Math.Floor((double) (millisecond / 1000.0));
            millisecond -= num * 0x3e8;
            second += num;
            num = (int) Math.Floor((double) (((double) second) / 60.0));
            second -= num * 60;
            minute += num;
            num = (int) Math.Floor((double) (((double) minute) / 60.0));
            minute -= num * 60;
            hour += num;
            num = (int) Math.Floor((double) (((double) hour) / 24.0));
            hour -= num * 0x18;
            day += num;
            num = (int) Math.Floor((double) (((double) month) / 12.0));
            month -= num * 12;
            year += num;
        }

        private static double _CalendarDateToXLDate(int year, int month, int day, int hour, int minute, int second, double millisecond) => 
            JulianDayToXLDate(_CalendarDateToJulianDay(year, month, day, hour, minute, second, millisecond));

        private static double _CalendarDateToJulianDay(int year, int month, int day, int hour, int minute, int second, double millisecond)
        {
            if (month <= 2)
            {
                year--;
                month += 12;
            }
            double num = Math.Floor((double) (((double) year) / 100.0));
            double num2 = (2.0 - num) + Math.Floor((double) (num / 4.0));
            return ((((((((Math.Floor((double) (365.25 * (year + 4716.0))) + Math.Floor((double) (30.6001 * (month + 1)))) + day) + num2) - 1524.5) + (((double) hour) / 24.0)) + (((double) minute) / 1440.0)) + (((double) second) / 86400.0)) + (millisecond / 86400000.0));
        }

        public static void XLDateToCalendarDate(double xlDate, out int year, out int month, out int day, out int hour, out int minute, out int second)
        {
            JulianDayToCalendarDate(XLDateToJulianDay(xlDate), out year, out month, out day, out hour, out minute, out second);
        }

        public static void XLDateToCalendarDate(double xlDate, out int year, out int month, out int day, out int hour, out int minute, out int second, out int millisecond)
        {
            double num2;
            JulianDayToCalendarDate(XLDateToJulianDay(xlDate), out year, out month, out day, out hour, out minute, out second, out num2);
            millisecond = (int) num2;
        }

        public static void XLDateToCalendarDate(double xlDate, out int year, out int month, out int day, out int hour, out int minute, out double second)
        {
            JulianDayToCalendarDate(XLDateToJulianDay(xlDate), out year, out month, out day, out hour, out minute, out second);
        }

        public static void JulianDayToCalendarDate(double jDay, out int year, out int month, out int day, out int hour, out int minute, out int second)
        {
            double millisecond = 0.0;
            JulianDayToCalendarDate(jDay, out year, out month, out day, out hour, out minute, out second, out millisecond);
        }

        public static void JulianDayToCalendarDate(double jDay, out int year, out int month, out int day, out int hour, out int minute, out double second)
        {
            int num;
            double num2;
            JulianDayToCalendarDate(jDay, out year, out month, out day, out hour, out minute, out num, out num2);
            second = num + (num2 / 1000.0);
        }

        public static void JulianDayToCalendarDate(double jDay, out int year, out int month, out int day, out int hour, out int minute, out int second, out double millisecond)
        {
            jDay += 5.7870370370370369E-09;
            double num = Math.Floor((double) (jDay + 0.5));
            double num2 = (jDay + 0.5) - num;
            double num3 = Math.Floor((double) ((num - 1867216.25) / 36524.25));
            double num5 = (((num + 1.0) + num3) - Math.Floor((double) (num3 / 4.0))) + 1524.0;
            double num6 = Math.Floor((double) ((num5 - 122.1) / 365.25));
            double num7 = Math.Floor((double) (365.25 * num6));
            double num8 = Math.Floor((double) ((num5 - num7) / 30.6001));
            day = (int) Math.Floor((double) (((num5 - num7) - Math.Floor((double) (30.6001 * num8))) + num2));
            month = (num8 < 14.0) ? ((int) (num8 - 1.0)) : ((int) (num8 - 13.0));
            year = (month > 2) ? ((int) (num6 - 4716.0)) : ((int) (num6 - 4715.0));
            double num9 = (jDay - 0.5) - Math.Floor((double) (jDay - 0.5));
            num9 = (num9 - ((long) num9)) * 24.0;
            hour = (int) num9;
            num9 = (num9 - ((long) num9)) * 60.0;
            minute = (int) num9;
            num9 = (num9 - ((long) num9)) * 60.0;
            second = (int) num9;
            num9 = (num9 - ((long) num9)) * 1000.0;
            millisecond = num9;
        }

        public static double XLDateToJulianDay(double xlDate) => 
            xlDate + 2415018.5;

        public static double JulianDayToXLDate(double jDay) => 
            jDay - 2415018.5;

        public static double XLDateToDecimalYear(double xlDate)
        {
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            XLDateToCalendarDate(xlDate, out num, out num2, out num3, out num4, out num5, out num6);
            double num7 = CalendarDateToJulianDay(num, 1, 1, 0, 0, 0);
            double num8 = CalendarDateToJulianDay(num + 1, 1, 1, 0, 0, 0);
            double num9 = CalendarDateToJulianDay(num, num2, num3, num4, num5, num6);
            return (num + ((num9 - num7) / (num8 - num7)));
        }

        public static double DecimalYearToXLDate(double yearDec)
        {
            int year = (int) yearDec;
            double num2 = CalendarDateToJulianDay(year, 1, 1, 0, 0, 0);
            double num3 = CalendarDateToJulianDay(year + 1, 1, 1, 0, 0, 0);
            return JulianDayToXLDate(((yearDec - year) * (num3 - num2)) + num2);
        }

        public static double XLDateToDayOfYear(double xlDate)
        {
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            XLDateToCalendarDate(xlDate, out num, out num2, out num3, out num4, out num5, out num6);
            return ((XLDateToJulianDay(xlDate) - CalendarDateToJulianDay(num, 1, 1, 0, 0, 0)) + 1.0);
        }

        public static int XLDateToDayOfWeek(double xlDate) => 
            ((int) (XLDateToJulianDay(xlDate) + 1.5)) % 7;

        public static System.DateTime XLDateToDateTime(double xlDate)
        {
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            XLDateToCalendarDate(xlDate, out num, out num2, out num3, out num4, out num5, out num6, out num7);
            return new System.DateTime(num, num2, num3, num4, num5, num6, num7);
        }

        public static double DateTimeToXLDate(System.DateTime dt) => 
            CalendarDateToXLDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);

        public void AddMilliseconds(double dMilliseconds)
        {
            this._xlDate += dMilliseconds / 86400000.0;
        }

        public void AddSeconds(double dSeconds)
        {
            this._xlDate += dSeconds / 86400.0;
        }

        public void AddMinutes(double dMinutes)
        {
            this._xlDate += dMinutes / 1440.0;
        }

        public void AddHours(double dHours)
        {
            this._xlDate += dHours / 24.0;
        }

        public void AddDays(double dDays)
        {
            this._xlDate += dDays;
        }

        public void AddMonths(double dMonths)
        {
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num = (int) dMonths;
            double num2 = Math.Abs((double) (dMonths - num));
            int num3 = Math.Sign(dMonths);
            XLDateToCalendarDate(this._xlDate, out num4, out num5, out num6, out num7, out num8, out num9);
            if (num != 0)
            {
                num5 += num;
                this._xlDate = CalendarDateToXLDate(num4, num5, num6, num7, num8, num9);
            }
            if (num3 != 0)
            {
                double num10 = CalendarDateToXLDate(num4, num5 + num3, num6, num7, num8, num9);
                this._xlDate += (num10 - this._xlDate) * num2;
            }
        }

        public void AddYears(double dYears)
        {
            int num4;
            int num5;
            int num6;
            int num7;
            int num8;
            int num9;
            int num = (int) dYears;
            double num2 = Math.Abs((double) (dYears - num));
            int num3 = Math.Sign(dYears);
            XLDateToCalendarDate(this._xlDate, out num4, out num5, out num6, out num7, out num8, out num9);
            if (num != 0)
            {
                num4 += num;
                this._xlDate = CalendarDateToXLDate(num4, num5, num6, num7, num8, num9);
            }
            if (num3 != 0)
            {
                double num10 = CalendarDateToXLDate(num4 + num3, num5, num6, num7, num8, num9);
                this._xlDate += (num10 - this._xlDate) * num2;
            }
        }

        public static double operator -(XDate lhs, XDate rhs) => 
            lhs.XLDate - rhs.XLDate;

        public static unsafe XDate operator -(XDate lhs, double rhs)
        {
            XDate* datePtr1 = &lhs;
            datePtr1->_xlDate -= rhs;
            return lhs;
        }

        public static unsafe XDate operator +(XDate lhs, double rhs)
        {
            XDate* datePtr1 = &lhs;
            datePtr1->_xlDate += rhs;
            return lhs;
        }

        public static unsafe XDate operator ++(XDate xDate)
        {
            XDate* datePtr1 = &xDate;
            datePtr1->_xlDate++;
            return xDate;
        }

        public static unsafe XDate operator --(XDate xDate)
        {
            XDate* datePtr1 = &xDate;
            datePtr1->_xlDate--;
            return xDate;
        }

        public static implicit operator double(XDate xDate) => 
            xDate._xlDate;

        public static implicit operator float(XDate xDate) => 
            (float) xDate._xlDate;

        public static implicit operator XDate(double xlDate) => 
            new XDate(xlDate);

        public static implicit operator System.DateTime(XDate xDate) => 
            XLDateToDateTime((double) xDate);

        public static implicit operator XDate(System.DateTime dt) => 
            new XDate(DateTimeToXLDate(dt));

        public override bool Equals(object obj) => 
            !(obj is XDate) ? ((obj is double) && (((double) obj) == this._xlDate)) : (((XDate) obj)._xlDate == this._xlDate);

        public override int GetHashCode() => 
            this._xlDate.GetHashCode();

        public int CompareTo(object target)
        {
            if (!(target is XDate))
            {
                throw new ArgumentException();
            }
            return this.XLDate.CompareTo(((XDate) target).XLDate);
        }

        public string ToString(double xlDate) => 
            ToString(xlDate, "g");

        public override string ToString() => 
            ToString(this._xlDate, "g");

        public string ToString(string fmtStr) => 
            ToString(this.XLDate, fmtStr);

        public static string ToString(double xlDate, string fmtStr)
        {
            int num;
            int num2;
            int num3;
            int num4;
            int num5;
            int num6;
            int num7;
            if (!CheckValidDate(xlDate))
            {
                return "Date Error";
            }
            XLDateToCalendarDate(xlDate, out num, out num2, out num3, out num4, out num5, out num6, out num7);
            if (num <= 0)
            {
                num = 1 - num;
                fmtStr = fmtStr + " (BC)";
            }
            if (fmtStr.IndexOf("[d]") >= 0)
            {
                fmtStr = fmtStr.Replace("[d]", ((int) xlDate).ToString());
                xlDate -= (int) xlDate;
            }
            if ((fmtStr.IndexOf("[h]") >= 0) || (fmtStr.IndexOf("[hh]") >= 0))
            {
                fmtStr = fmtStr.Replace("[h]", ((int) (xlDate * 24.0)).ToString("d"));
                fmtStr = fmtStr.Replace("[hh]", ((int) (xlDate * 24.0)).ToString("d2"));
                xlDate = ((xlDate * 24.0) - ((int) (xlDate * 24.0))) / 24.0;
            }
            if ((fmtStr.IndexOf("[m]") >= 0) || (fmtStr.IndexOf("[mm]") >= 0))
            {
                fmtStr = fmtStr.Replace("[m]", ((int) (xlDate * 1440.0)).ToString("d"));
                fmtStr = fmtStr.Replace("[mm]", ((int) (xlDate * 1440.0)).ToString("d2"));
                xlDate = ((xlDate * 1440.0) - ((int) (xlDate * 1440.0))) / 1440.0;
            }
            if ((fmtStr.IndexOf("[s]") >= 0) || (fmtStr.IndexOf("[ss]") >= 0))
            {
                fmtStr = fmtStr.Replace("[s]", ((int) (xlDate * 86400.0)).ToString("d"));
                fmtStr = fmtStr.Replace("[ss]", ((int) (xlDate * 86400.0)).ToString("d2"));
                xlDate = ((xlDate * 86400.0) - ((int) (xlDate * 86400.0))) / 86400.0;
            }
            if (fmtStr.IndexOf("[f]") >= 0)
            {
                fmtStr = fmtStr.Replace("[f]", ((int) (xlDate * 864000.0)).ToString("d"));
            }
            if (fmtStr.IndexOf("[ff]") >= 0)
            {
                fmtStr = fmtStr.Replace("[ff]", ((int) (xlDate * 8640000.0)).ToString("d"));
            }
            if (fmtStr.IndexOf("[fff]") >= 0)
            {
                fmtStr = fmtStr.Replace("[fff]", ((int) (xlDate * 86400000.0)).ToString("d"));
            }
            if (fmtStr.IndexOf("[ffff]") >= 0)
            {
                fmtStr = fmtStr.Replace("[ffff]", ((int) (xlDate * 864000000.0)).ToString("d"));
            }
            if (fmtStr.IndexOf("[fffff]") >= 0)
            {
                fmtStr = fmtStr.Replace("[fffff]", ((int) (xlDate * 8640000000)).ToString("d"));
            }
            if (num > 0x270f)
            {
                num = 0x270f;
            }
            System.DateTime time = new System.DateTime(num, num2, num3, num4, num5, num6, num7);
            return time.ToString(fmtStr);
        }
    }
}

