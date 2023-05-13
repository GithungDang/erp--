namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class GapLabel : Label, ICloneable, ISerializable
    {
        public const int schema2 = 10;
        internal float _gap;

        public GapLabel(GapLabel rhs) : base(rhs)
        {
            this._gap = rhs._gap;
        }

        protected GapLabel(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._gap = info.GetSingle("gap");
        }

        public GapLabel(string text, string fontFamily, float fontSize, Color color, bool isBold, bool isItalic, bool isUnderline) : base(text, fontFamily, fontSize, color, isBold, isItalic, isUnderline)
        {
            this._gap = Default.Gap;
        }

        public GapLabel Clone() => 
            new GapLabel(this);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
            info.AddValue("gap", this._gap);
        }

        public float GetScaledGap(float scaleFactor) => 
            base._fontSpec.GetHeight(scaleFactor) * this._gap;

        object ICloneable.Clone() => 
            this.Clone();

        public float Gap
        {
            get => 
                this._gap;
            set => 
                this._gap = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float Gap;
            static Default()
            {
                Gap = 0.3f;
            }
        }
    }
}

