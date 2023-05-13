namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class Border : LineBase, ISerializable, ICloneable
    {
        public const int schema = 11;
        private float _inflateFactor;

        public Border()
        {
            this._inflateFactor = Default.InflateFactor;
        }

        public Border(Border rhs) : base(rhs)
        {
            this._inflateFactor = rhs._inflateFactor;
        }

        public Border(Color color, float width) : this(!color.IsEmpty, color, width)
        {
        }

        protected Border(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema");
            this._inflateFactor = info.GetSingle("inflateFactor");
        }

        public Border(bool isVisible, Color color, float width) : base(color)
        {
            base._width = width;
            base._isVisible = isVisible;
        }

        public Border Clone() => 
            new Border(this);

        public void Draw(Graphics g, PaneBase pane, float scaleFactor, RectangleF rect)
        {
            if (base._isVisible)
            {
                RectangleF ef = rect;
                float x = this._inflateFactor * scaleFactor;
                ef.Inflate(x, x);
                using (Pen pen = base.GetPen(pane, scaleFactor))
                {
                    g.DrawRectangle(pen, ef.X, ef.Y, ef.Width, ef.Height);
                }
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema", 11);
            info.AddValue("inflateFactor", this._inflateFactor);
        }

        object ICloneable.Clone() => 
            this.Clone();

        public float InflateFactor
        {
            get => 
                this._inflateFactor;
            set => 
                this._inflateFactor = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float InflateFactor;
        }
    }
}

