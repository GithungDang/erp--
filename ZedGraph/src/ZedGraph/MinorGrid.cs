namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class MinorGrid : ICloneable, ISerializable
    {
        public const int schema = 10;
        internal bool _isVisible;
        internal float _dashOn;
        internal float _dashOff;
        internal float _penWidth;
        internal System.Drawing.Color _color;

        public MinorGrid()
        {
            this._dashOn = Default.DashOn;
            this._dashOff = Default.DashOff;
            this._penWidth = Default.PenWidth;
            this._isVisible = Default.IsVisible;
            this._color = Default.Color;
        }

        public MinorGrid(MinorGrid rhs)
        {
            this._dashOn = rhs._dashOn;
            this._dashOff = rhs._dashOff;
            this._penWidth = rhs._penWidth;
            this._isVisible = rhs._isVisible;
            this._color = rhs._color;
        }

        protected MinorGrid(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._isVisible = info.GetBoolean("isVisible");
            this._dashOn = info.GetSingle("dashOn");
            this._dashOff = info.GetSingle("dashOff");
            this._penWidth = info.GetSingle("penWidth");
            this._color = (System.Drawing.Color) info.GetValue("color", typeof(System.Drawing.Color));
        }

        public MinorGrid Clone() => 
            new MinorGrid(this);

        internal void Draw(Graphics g, Pen pen, float pixVal, float topPix)
        {
            if (this._isVisible)
            {
                g.DrawLine(pen, pixVal, 0f, pixVal, topPix);
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("isVisible", this._isVisible);
            info.AddValue("dashOn", this._dashOn);
            info.AddValue("dashOff", this._dashOff);
            info.AddValue("penWidth", this._penWidth);
            info.AddValue("color", this._color);
        }

        internal Pen GetPen(GraphPane pane, float scaleFactor)
        {
            Pen pen = new Pen(this._color, pane.ScaledPenWidth(this._penWidth, scaleFactor));
            if ((this._dashOff > 1E-10) && (this._dashOn > 1E-10))
            {
                pen.DashStyle = DashStyle.Custom;
                pen.DashPattern = new float[] { this._dashOn, this._dashOff };
            }
            return pen;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public bool IsVisible
        {
            get => 
                this._isVisible;
            set => 
                this._isVisible = value;
        }

        public float DashOn
        {
            get => 
                this._dashOn;
            set => 
                this._dashOn = value;
        }

        public float DashOff
        {
            get => 
                this._dashOff;
            set => 
                this._dashOff = value;
        }

        public float PenWidth
        {
            get => 
                this._penWidth;
            set => 
                this._penWidth = value;
        }

        public System.Drawing.Color Color
        {
            get => 
                this._color;
            set => 
                this._color = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float DashOn;
            public static float DashOff;
            public static float PenWidth;
            public static System.Drawing.Color Color;
            public static bool IsVisible;
            static Default()
            {
                DashOn = 1f;
                DashOff = 10f;
                PenWidth = 1f;
                Color = System.Drawing.Color.Gray;
                IsVisible = false;
            }
        }
    }
}

