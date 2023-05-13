namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class AxisLabel : GapLabel, ICloneable, ISerializable
    {
        public const int schema3 = 10;
        internal bool _isOmitMag;
        internal bool _isTitleAtCross;

        public AxisLabel(AxisLabel rhs) : base(rhs)
        {
            this._isOmitMag = rhs._isOmitMag;
            this._isTitleAtCross = rhs._isTitleAtCross;
        }

        protected AxisLabel(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema3");
            this._isOmitMag = info.GetBoolean("isOmitMag");
            this._isTitleAtCross = info.GetBoolean("isTitleAtCross");
        }

        public AxisLabel(string text, string fontFamily, float fontSize, Color color, bool isBold, bool isItalic, bool isUnderline) : base(text, fontFamily, fontSize, color, isBold, isItalic, isUnderline)
        {
            this._isOmitMag = false;
            this._isTitleAtCross = true;
        }

        public AxisLabel Clone() => 
            new AxisLabel(this);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema3", 10);
            info.AddValue("isOmitMag", base._isVisible);
            info.AddValue("isTitleAtCross", this._isTitleAtCross);
        }

        object ICloneable.Clone() => 
            this.Clone();

        public bool IsOmitMag
        {
            get => 
                this._isOmitMag;
            set => 
                this._isOmitMag = value;
        }

        public bool IsTitleAtCross
        {
            get => 
                this._isTitleAtCross;
            set => 
                this._isTitleAtCross = value;
        }
    }
}

