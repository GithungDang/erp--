namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class Chart : ICloneable, ISerializable
    {
        public const int schema = 10;
        internal RectangleF _rect;
        internal ZedGraph.Fill _fill;
        internal ZedGraph.Border _border;
        internal bool _isRectAuto;

        public Chart()
        {
            this._isRectAuto = true;
            this._border = new ZedGraph.Border(Default.IsBorderVisible, Default.BorderColor, Default.BorderPenWidth);
            this._fill = new ZedGraph.Fill(Default.FillColor, Default.FillBrush, Default.FillType);
        }

        public Chart(Chart rhs)
        {
            this._border = rhs._border.Clone();
            this._fill = rhs._fill.Clone();
            this._rect = rhs._rect;
            this._isRectAuto = rhs._isRectAuto;
        }

        protected Chart(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._rect = (RectangleF) info.GetValue("rect", typeof(RectangleF));
            this._fill = (ZedGraph.Fill) info.GetValue("fill", typeof(ZedGraph.Fill));
            this._border = (ZedGraph.Border) info.GetValue("border", typeof(ZedGraph.Border));
            this._isRectAuto = info.GetBoolean("isRectAuto");
        }

        public Chart Clone() => 
            new Chart(this);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("rect", this._rect);
            info.AddValue("fill", this._fill);
            info.AddValue("border", this._border);
            info.AddValue("isRectAuto", this._isRectAuto);
        }

        object ICloneable.Clone() => 
            this.Clone();

        public RectangleF Rect
        {
            get => 
                this._rect;
            set
            {
                this._rect = value;
                this._isRectAuto = false;
            }
        }

        public ZedGraph.Fill Fill
        {
            get => 
                this._fill;
            set => 
                this._fill = value;
        }

        public ZedGraph.Border Border
        {
            get => 
                this._border;
            set => 
                this._border = value;
        }

        public bool IsRectAuto
        {
            get => 
                this._isRectAuto;
            set => 
                this._isRectAuto = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static Color BorderColor;
            public static Color FillColor;
            public static Brush FillBrush;
            public static ZedGraph.FillType FillType;
            public static float BorderPenWidth;
            public static bool IsBorderVisible;
            static Default()
            {
                BorderColor = Color.Black;
                FillColor = Color.White;
                FillBrush = null;
                FillType = ZedGraph.FillType.Brush;
                BorderPenWidth = 1f;
                IsBorderVisible = true;
            }
        }
    }
}

