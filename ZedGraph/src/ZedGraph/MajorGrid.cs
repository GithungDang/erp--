namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class MajorGrid : MinorGrid, ICloneable, ISerializable
    {
        public const int schema2 = 10;
        internal bool _isZeroLine;

        public MajorGrid()
        {
            base._dashOn = Default.DashOn;
            base._dashOff = Default.DashOff;
            base._penWidth = Default.PenWidth;
            base._isVisible = Default.IsVisible;
            base._color = Default.Color;
            this._isZeroLine = Default.IsZeroLine;
        }

        public MajorGrid(MajorGrid rhs) : base(rhs)
        {
            this._isZeroLine = rhs._isZeroLine;
        }

        protected MajorGrid(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._isZeroLine = info.GetBoolean("isZeroLine");
        }

        public MajorGrid Clone() => 
            new MajorGrid(this);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
            info.AddValue("isZeroLine", this._isZeroLine);
        }

        object ICloneable.Clone() => 
            this.Clone();

        public bool IsZeroLine
        {
            get => 
                this._isZeroLine;
            set => 
                this._isZeroLine = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float DashOn;
            public static float DashOff;
            public static float PenWidth;
            public static System.Drawing.Color Color;
            public static bool IsVisible;
            public static bool IsZeroLine;
            static Default()
            {
                DashOn = 1f;
                DashOff = 5f;
                PenWidth = 1f;
                Color = System.Drawing.Color.Black;
                IsVisible = false;
                IsZeroLine = false;
            }
        }
    }
}

