namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class ErrorBar : ICloneable, ISerializable
    {
        public const int schema = 10;
        private bool _isVisible;
        private System.Drawing.Color _color;
        private float _penWidth;
        private ZedGraph.Symbol _symbol;

        public ErrorBar() : this(Default.Color)
        {
        }

        public ErrorBar(System.Drawing.Color color)
        {
            this._symbol = new ZedGraph.Symbol(Default.Type, color);
            this._symbol.Size = Default.Size;
            this._color = color;
            this._penWidth = Default.PenWidth;
            this._isVisible = Default.IsVisible;
        }

        public ErrorBar(ErrorBar rhs)
        {
            this._color = rhs.Color;
            this._isVisible = rhs.IsVisible;
            this._penWidth = rhs.PenWidth;
            this._symbol = rhs.Symbol.Clone();
        }

        protected ErrorBar(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._isVisible = info.GetBoolean("isVisible");
            this._color = (System.Drawing.Color) info.GetValue("color", typeof(System.Drawing.Color));
            this._penWidth = info.GetSingle("penWidth");
            this._symbol = (ZedGraph.Symbol) info.GetValue("symbol", typeof(ZedGraph.Symbol));
        }

        public ErrorBar Clone() => 
            new ErrorBar(this);

        public void Draw(Graphics g, GraphPane pane, ErrorBarItem curve, Axis baseAxis, Axis valueAxis, float scaleFactor)
        {
            ValueHandler handler = new ValueHandler(pane, false);
            if ((curve.Points != null) && this.IsVisible)
            {
                using (Pen pen = !curve.IsSelected ? new Pen(this._color, this._penWidth) : new Pen(Selection.Border.Color, Selection.Border.Width))
                {
                    for (int i = 0; i < curve.Points.Count; i++)
                    {
                        double num4;
                        double num5;
                        double num6;
                        handler.GetValues(curve, i, out num4, out num6, out num5);
                        if ((!curve.Points[i].IsInvalid3D && ((num4 > 0.0) || !baseAxis._scale.IsLog)) && (((num5 > 0.0) && (num6 > 0.0)) || !valueAxis._scale.IsLog))
                        {
                            float pixBase = baseAxis.Scale.Transform(curve.IsOverrideOrdinal, i, num4);
                            float pixValue = valueAxis.Scale.Transform(curve.IsOverrideOrdinal, i, num5);
                            float pixLowValue = valueAxis.Scale.Transform(curve.IsOverrideOrdinal, i, num6);
                            this.Draw(g, pane, (baseAxis is XAxis) || (baseAxis is X2Axis), pixBase, pixValue, pixLowValue, scaleFactor, pen, curve.IsSelected, curve.Points[i]);
                        }
                    }
                }
            }
        }

        public void Draw(Graphics g, GraphPane pane, bool isXBase, float pixBase, float pixValue, float pixLowValue, float scaleFactor, Pen pen, bool isSelected, PointPair dataValue)
        {
            if (isXBase)
            {
                g.DrawLine(pen, pixBase, pixValue, pixBase, pixLowValue);
                this._symbol.DrawSymbol(g, pane, (int) pixBase, (int) pixValue, scaleFactor, isSelected, dataValue);
                this._symbol.DrawSymbol(g, pane, (int) pixBase, (int) pixLowValue, scaleFactor, isSelected, dataValue);
            }
            else
            {
                g.DrawLine(pen, pixValue, pixBase, pixLowValue, pixBase);
                this._symbol.DrawSymbol(g, pane, (int) pixValue, (int) pixBase, scaleFactor, isSelected, dataValue);
                this._symbol.DrawSymbol(g, pane, (int) pixLowValue, (int) pixBase, scaleFactor, isSelected, dataValue);
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("isVisible", this._isVisible);
            info.AddValue("color", this._color);
            info.AddValue("penWidth", this._penWidth);
            info.AddValue("symbol", this._symbol);
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

        public System.Drawing.Color Color
        {
            get => 
                this._color;
            set => 
                this._color = value;
        }

        public float PenWidth
        {
            get => 
                this._penWidth;
            set => 
                this._penWidth = value;
        }

        public ZedGraph.Symbol Symbol
        {
            get => 
                this._symbol;
            set => 
                this._symbol = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float Size;
            public static float PenWidth;
            public static bool IsVisible;
            public static System.Drawing.Color Color;
            public static SymbolType Type;
            static Default()
            {
                Size = 7f;
                PenWidth = 1f;
                IsVisible = true;
                Color = System.Drawing.Color.Red;
                Type = SymbolType.HDash;
            }
        }
    }
}

