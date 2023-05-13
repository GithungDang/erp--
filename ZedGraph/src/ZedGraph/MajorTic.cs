namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class MajorTic : MinorTic, ICloneable, ISerializable
    {
        public const int schema2 = 10;
        internal bool _isBetweenLabels;

        public MajorTic()
        {
            base._size = Default.Size;
            base._color = Default.Color;
            base._penWidth = Default.PenWidth;
            base.IsOutside = Default.IsOutside;
            base.IsInside = Default.IsInside;
            base.IsOpposite = Default.IsOpposite;
            base._isCrossOutside = Default.IsCrossOutside;
            base._isCrossInside = Default.IsCrossInside;
            this._isBetweenLabels = false;
        }

        public MajorTic(MajorTic rhs) : base(rhs)
        {
            this._isBetweenLabels = rhs._isBetweenLabels;
        }

        protected MajorTic(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._isBetweenLabels = info.GetBoolean("isBetweenLabels");
        }

        public MajorTic Clone() => 
            new MajorTic(this);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
            info.AddValue("isBetweenLabels", this._isBetweenLabels);
        }

        object ICloneable.Clone() => 
            this.Clone();

        public bool IsBetweenLabels
        {
            get => 
                this._isBetweenLabels;
            set => 
                this._isBetweenLabels = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float Size;
            public static float PenWidth;
            public static bool IsOutside;
            public static bool IsInside;
            public static bool IsOpposite;
            public static bool IsCrossOutside;
            public static bool IsCrossInside;
            public static System.Drawing.Color Color;
            static Default()
            {
                Size = 5f;
                PenWidth = 1f;
                IsOutside = true;
                IsInside = true;
                IsOpposite = true;
                IsCrossOutside = false;
                IsCrossInside = false;
                Color = System.Drawing.Color.Black;
            }
        }
    }
}

