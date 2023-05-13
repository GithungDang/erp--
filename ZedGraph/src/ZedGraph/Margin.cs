namespace ZedGraph
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class Margin : ICloneable, ISerializable
    {
        public const int schema = 10;
        protected float _left;
        protected float _right;
        protected float _top;
        protected float _bottom;

        public Margin()
        {
            this._left = Default.Left;
            this._right = Default.Right;
            this._top = Default.Top;
            this._bottom = Default.Bottom;
        }

        public Margin(Margin rhs)
        {
            this._left = rhs._left;
            this._right = rhs._right;
            this._top = rhs._top;
            this._bottom = rhs._bottom;
        }

        protected Margin(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._left = info.GetSingle("left");
            this._right = info.GetSingle("right");
            this._top = info.GetSingle("top");
            this._bottom = info.GetSingle("bottom");
        }

        public Margin Clone() => 
            new Margin(this);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("left", this._left);
            info.AddValue("right", this._right);
            info.AddValue("top", this._top);
            info.AddValue("bottom", this._bottom);
        }

        object ICloneable.Clone() => 
            this.Clone();

        public float Left
        {
            get => 
                this._left;
            set => 
                this._left = value;
        }

        public float Right
        {
            get => 
                this._right;
            set => 
                this._right = value;
        }

        public float Top
        {
            get => 
                this._top;
            set => 
                this._top = value;
        }

        public float Bottom
        {
            get => 
                this._bottom;
            set => 
                this._bottom = value;
        }

        public float All
        {
            set
            {
                this._bottom = value;
                this._top = value;
                this._left = value;
                this._right = value;
            }
        }

        public class Default
        {
            public static float Left = 10f;
            public static float Right = 10f;
            public static float Top = 10f;
            public static float Bottom = 10f;
        }
    }
}

