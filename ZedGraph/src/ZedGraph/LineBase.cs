namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class LineBase : ICloneable, ISerializable
    {
        public const int schema0 = 12;
        internal float _width;
        internal DashStyle _style;
        internal float _dashOn;
        internal float _dashOff;
        internal bool _isVisible;
        internal bool _isAntiAlias;
        internal System.Drawing.Color _color;
        internal Fill _gradientFill;

        public LineBase() : this(System.Drawing.Color.Empty)
        {
        }

        public LineBase(System.Drawing.Color color)
        {
            this._width = Default.Width;
            this._style = Default.Style;
            this._dashOn = Default.DashOn;
            this._dashOff = Default.DashOff;
            this._isVisible = Default.IsVisible;
            this._color = color.IsEmpty ? Default.Color : color;
            this._isAntiAlias = Default.IsAntiAlias;
            this._gradientFill = new Fill(System.Drawing.Color.Red, System.Drawing.Color.White);
            this._gradientFill.Type = FillType.None;
        }

        public LineBase(LineBase rhs)
        {
            this._width = rhs._width;
            this._style = rhs._style;
            this._dashOn = rhs._dashOn;
            this._dashOff = rhs._dashOff;
            this._isVisible = rhs._isVisible;
            this._color = rhs._color;
            this._isAntiAlias = rhs._isAntiAlias;
            this._gradientFill = new Fill(rhs._gradientFill);
        }

        protected LineBase(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema0");
            this._width = info.GetSingle("width");
            this._style = (DashStyle) info.GetValue("style", typeof(DashStyle));
            this._dashOn = info.GetSingle("dashOn");
            this._dashOff = info.GetSingle("dashOff");
            this._isVisible = info.GetBoolean("isVisible");
            this._isAntiAlias = info.GetBoolean("isAntiAlias");
            this._color = (System.Drawing.Color) info.GetValue("color", typeof(System.Drawing.Color));
            this._gradientFill = (Fill) info.GetValue("gradientFill", typeof(Fill));
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema0", 12);
            info.AddValue("width", this._width);
            info.AddValue("style", this._style);
            info.AddValue("dashOn", this._dashOn);
            info.AddValue("dashOff", this._dashOff);
            info.AddValue("isVisible", this._isVisible);
            info.AddValue("isAntiAlias", this._isAntiAlias);
            info.AddValue("color", this._color);
            info.AddValue("gradientFill", this._gradientFill);
        }

        public Pen GetPen(PaneBase pane, float scaleFactor) => 
            this.GetPen(pane, scaleFactor, null);

        public Pen GetPen(PaneBase pane, float scaleFactor, PointPair dataValue)
        {
            System.Drawing.Color gradientColor = this._color;
            if (this._gradientFill.IsGradientValueType)
            {
                gradientColor = this._gradientFill.GetGradientColor(dataValue);
            }
            Pen pen = new Pen(gradientColor, pane.ScaledPenWidth(this._width, scaleFactor)) {
                DashStyle = this._style
            };
            if (this._style == DashStyle.Custom)
            {
                if ((this._dashOff <= 1E-10) || (this._dashOn <= 1E-10))
                {
                    pen.DashStyle = DashStyle.Solid;
                }
                else
                {
                    pen.DashStyle = DashStyle.Custom;
                    pen.DashPattern = new float[] { this._dashOn, this._dashOff };
                }
            }
            return pen;
        }

        object ICloneable.Clone()
        {
            throw new NotImplementedException("Can't clone an abstract base type -- child types must implement ICloneable");
        }

        public System.Drawing.Color Color
        {
            get => 
                this._color;
            set => 
                this._color = value;
        }

        public DashStyle Style
        {
            get => 
                this._style;
            set => 
                this._style = value;
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

        public float Width
        {
            get => 
                this._width;
            set => 
                this._width = value;
        }

        public bool IsVisible
        {
            get => 
                this._isVisible;
            set => 
                this._isVisible = value;
        }

        public bool IsAntiAlias
        {
            get => 
                this._isAntiAlias;
            set => 
                this._isAntiAlias = value;
        }

        public Fill GradientFill
        {
            get => 
                this._gradientFill;
            set => 
                this._gradientFill = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static bool IsVisible;
            public static float Width;
            public static bool IsAntiAlias;
            public static DashStyle Style;
            public static float DashOn;
            public static float DashOff;
            public static System.Drawing.Color Color;
            static Default()
            {
                IsVisible = true;
                Width = 1f;
                IsAntiAlias = false;
                Style = DashStyle.Solid;
                DashOn = 1f;
                DashOff = 1f;
                Color = System.Drawing.Color.Black;
            }
        }
    }
}

