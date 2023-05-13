namespace ZedGraph
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class StockPt : PointPair, ISerializable
    {
        public const int schema3 = 11;
        public double Open;
        public double Close;
        public double Vol;
        private double _colorValue;

        public StockPt() : this(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, null)
        {
        }

        public StockPt(PointPair rhs) : base(rhs)
        {
            if (!(rhs is StockPt))
            {
                this.Open = double.MaxValue;
                this.Close = double.MaxValue;
                this.Vol = double.MaxValue;
                this.ColorValue = double.MaxValue;
            }
            else
            {
                StockPt pt = rhs as StockPt;
                this.Open = pt.Open;
                this.Close = pt.Close;
                this.Vol = pt.Vol;
                this.ColorValue = rhs.ColorValue;
            }
        }

        public StockPt(StockPt rhs) : base(rhs)
        {
            this.Low = rhs.Low;
            this.Open = rhs.Open;
            this.Close = rhs.Close;
            this.Vol = rhs.Vol;
            this.ColorValue = rhs.ColorValue;
            if (rhs.Tag is ICloneable)
            {
                base.Tag = ((ICloneable) rhs.Tag).Clone();
            }
            else
            {
                base.Tag = rhs.Tag;
            }
        }

        protected StockPt(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema3");
            this.Open = info.GetDouble("Open");
            this.Close = info.GetDouble("Close");
            this.Vol = info.GetDouble("Vol");
            this.ColorValue = info.GetDouble("ColorValue");
        }

        public StockPt(double date, double high, double low, double open, double close, double vol) : this(date, high, low, open, close, vol, null)
        {
        }

        public StockPt(double date, double high, double low, double open, double close, double vol, string tag) : base(date, high)
        {
            this.Low = low;
            this.Open = open;
            this.Close = close;
            this.Vol = vol;
            this.ColorValue = double.MaxValue;
            base.Tag = tag;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema3", 11);
            info.AddValue("Open", this.Open);
            info.AddValue("Close", this.Close);
            info.AddValue("Vol", this.Vol);
            info.AddValue("ColorValue", this.ColorValue);
        }

        public override string ToString(bool isShowAll) => 
            this.ToString("G", isShowAll);

        public override string ToString(string format, bool isShowAll)
        {
            string text2;
            string[] strArray = new string[] { "( ", XDate.ToString(this.Date, "g"), ", ", this.Close.ToString(format) };
            if (!isShowAll)
            {
                text2 = "";
            }
            else
            {
                string[] strArray2 = new string[] { ", ", this.Low.ToString(format), ", ", this.Open.ToString(format), ", ", this.Close.ToString(format) };
                text2 = string.Concat(strArray2);
            }
            strArray[4] = text2;
            strArray[5] = " )";
            return string.Concat(strArray);
        }

        public double Date
        {
            get => 
                base.X;
            set => 
                base.X = value;
        }

        public double High
        {
            get => 
                base.Y;
            set => 
                base.Y = value;
        }

        public double Low
        {
            get => 
                base.Z;
            set => 
                base.Z = value;
        }

        public override double ColorValue
        {
            get => 
                this._colorValue;
            set => 
                this._colorValue = value;
        }

        public bool IsInvalid5D =>
            (this.Date == double.MaxValue) || ((this.Close == double.MaxValue) || ((this.Open == double.MaxValue) || ((this.High == double.MaxValue) || ((this.Low == double.MaxValue) || (double.IsInfinity(this.Date) || (double.IsInfinity(this.Close) || (double.IsInfinity(this.Open) || (double.IsInfinity(this.High) || (double.IsInfinity(this.Low) || (double.IsNaN(this.Date) || (double.IsNaN(this.Close) || (double.IsNaN(this.Open) || (double.IsNaN(this.High) || double.IsNaN(this.Low))))))))))))));
    }
}

