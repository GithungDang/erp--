namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class MinorTic : ICloneable, ISerializable
    {
        public const int schema = 10;
        internal bool _isOutside;
        internal bool _isInside;
        internal bool _isOpposite;
        internal bool _isCrossOutside;
        internal bool _isCrossInside;
        internal float _penWidth;
        internal float _size;
        internal System.Drawing.Color _color;

        public MinorTic()
        {
            this._size = Default.Size;
            this._color = Default.Color;
            this._penWidth = Default.PenWidth;
            this.IsOutside = Default.IsOutside;
            this.IsInside = Default.IsInside;
            this.IsOpposite = Default.IsOpposite;
            this._isCrossOutside = Default.IsCrossOutside;
            this._isCrossInside = Default.IsCrossInside;
        }

        public MinorTic(MinorTic rhs)
        {
            this._size = rhs._size;
            this._color = rhs._color;
            this._penWidth = rhs._penWidth;
            this.IsOutside = rhs.IsOutside;
            this.IsInside = rhs.IsInside;
            this.IsOpposite = rhs.IsOpposite;
            this._isCrossOutside = rhs._isCrossOutside;
            this._isCrossInside = rhs._isCrossInside;
        }

        protected MinorTic(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._color = (System.Drawing.Color) info.GetValue("color", typeof(System.Drawing.Color));
            this._size = info.GetSingle("size");
            this._penWidth = info.GetSingle("penWidth");
            this.IsOutside = info.GetBoolean("IsOutside");
            this.IsInside = info.GetBoolean("IsInside");
            this.IsOpposite = info.GetBoolean("IsOpposite");
            this._isCrossOutside = info.GetBoolean("isCrossOutside");
            this._isCrossInside = info.GetBoolean("isCrossInside");
        }

        public MinorTic Clone() => 
            new MinorTic(this);

        internal void Draw(Graphics g, GraphPane pane, Pen pen, float pixVal, float topPix, float shift, float scaledTic)
        {
            if (this.IsOutside)
            {
                g.DrawLine(pen, pixVal, shift, pixVal, shift + scaledTic);
            }
            if (this._isCrossOutside)
            {
                g.DrawLine(pen, pixVal, 0f, pixVal, scaledTic);
            }
            if (this.IsInside)
            {
                g.DrawLine(pen, pixVal, shift, pixVal, shift - scaledTic);
            }
            if (this._isCrossInside)
            {
                g.DrawLine(pen, pixVal, 0f, pixVal, -scaledTic);
            }
            if (this.IsOpposite)
            {
                g.DrawLine(pen, pixVal, topPix, pixVal, topPix + scaledTic);
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("color", this._color);
            info.AddValue("size", this._size);
            info.AddValue("penWidth", this._penWidth);
            info.AddValue("IsOutside", this.IsOutside);
            info.AddValue("IsInside", this.IsInside);
            info.AddValue("IsOpposite", this.IsOpposite);
            info.AddValue("isCrossOutside", this._isCrossOutside);
            info.AddValue("isCrossInside", this._isCrossInside);
        }

        internal Pen GetPen(GraphPane pane, float scaleFactor) => 
            new Pen(this._color, pane.ScaledPenWidth(this._penWidth, scaleFactor));

        public float ScaledTic(float scaleFactor) => 
            this._size * scaleFactor;

        object ICloneable.Clone() => 
            this.Clone();

        public System.Drawing.Color Color
        {
            get => 
                this._color;
            set => 
                this._color = value;
        }

        public float Size
        {
            get => 
                this._size;
            set => 
                this._size = value;
        }

        public bool IsAllTics
        {
            set
            {
                this.IsOutside = value;
                this.IsInside = value;
                this.IsOpposite = value;
                this._isCrossOutside = value;
                this._isCrossInside = value;
            }
        }

        public bool IsOutside
        {
            get => 
                this._isOutside;
            set => 
                this._isOutside = value;
        }

        public bool IsInside
        {
            get => 
                this._isInside;
            set => 
                this._isInside = value;
        }

        public bool IsOpposite
        {
            get => 
                this._isOpposite;
            set => 
                this._isOpposite = value;
        }

        public bool IsCrossOutside
        {
            get => 
                this._isCrossOutside;
            set => 
                this._isCrossOutside = value;
        }

        public bool IsCrossInside
        {
            get => 
                this._isCrossInside;
            set => 
                this._isCrossInside = value;
        }

        public float PenWidth
        {
            get => 
                this._penWidth;
            set => 
                this._penWidth = value;
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
                Size = 2.5f;
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

