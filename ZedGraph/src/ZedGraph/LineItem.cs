namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class LineItem : CurveItem, ICloneable, ISerializable
    {
        public const int schema2 = 10;
        protected ZedGraph.Symbol _symbol;
        protected ZedGraph.Line _line;

        public LineItem(string label) : base(label)
        {
            this._symbol = new ZedGraph.Symbol();
            this._line = new ZedGraph.Line();
        }

        public LineItem(LineItem rhs) : base(rhs)
        {
            this._symbol = new ZedGraph.Symbol(rhs.Symbol);
            this._line = new ZedGraph.Line(rhs.Line);
        }

        protected LineItem(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._symbol = (ZedGraph.Symbol) info.GetValue("symbol", typeof(ZedGraph.Symbol));
            this._line = (ZedGraph.Line) info.GetValue("line", typeof(ZedGraph.Line));
        }

        public LineItem(string label, IPointList points, Color color, SymbolType symbolType) : this(label, points, color, symbolType, LineBase.Default.Width)
        {
        }

        public LineItem(string label, double[] x, double[] y, Color color, SymbolType symbolType) : this(label, new PointPairList(x, y), color, symbolType)
        {
        }

        public LineItem(string label, IPointList points, Color color, SymbolType symbolType, float lineWidth) : base(label, points)
        {
            this._line = new ZedGraph.Line(color);
            if (lineWidth == 0f)
            {
                this._line.IsVisible = false;
            }
            else
            {
                this._line.Width = lineWidth;
            }
            this._symbol = new ZedGraph.Symbol(symbolType, color);
        }

        public LineItem(string label, double[] x, double[] y, Color color, SymbolType symbolType, float lineWidth) : this(label, new PointPairList(x, y), color, symbolType, lineWidth)
        {
        }

        public LineItem Clone() => 
            new LineItem(this);

        public override void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor)
        {
            if (base._isVisible)
            {
                this.Line.Draw(g, pane, this, scaleFactor);
                this.Symbol.Draw(g, pane, this, scaleFactor, base.IsSelected);
            }
        }

        public override void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
        {
            int x = (int) (rect.Left + (rect.Width / 2f));
            int y = (int) (rect.Top + (rect.Height / 2f));
            this._line.Fill.Draw(g, rect);
            this._line.DrawSegment(g, pane, rect.Left, (float) y, rect.Right, (float) y, scaleFactor);
            this._symbol.DrawSymbol(g, pane, x, y, scaleFactor, false, null);
        }

        public override bool GetCoords(GraphPane pane, int i, out string coords)
        {
            double num;
            double num2;
            double num3;
            coords = string.Empty;
            if ((i < 0) || (i >= base._points.Count))
            {
                return false;
            }
            if (base._points[i].IsInvalid)
            {
                return false;
            }
            new ValueHandler(pane, false).GetValues(this, i, out num, out num3, out num2);
            Axis yAxis = base.GetYAxis(pane);
            PointF pt = new PointF(base.GetXAxis(pane).Scale.Transform(base._isOverrideOrdinal, i, num), yAxis.Scale.Transform(base._isOverrideOrdinal, i, num2));
            if (!pane.Chart.Rect.Contains(pt))
            {
                return false;
            }
            float num4 = this._symbol.Size * pane.CalcScaleFactor();
            coords = $"{pt.X - num4:f0},{pt.Y - num4:f0},{pt.X + num4:f0},{pt.Y + num4:f0}";
            return true;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
            info.AddValue("symbol", this._symbol);
            info.AddValue("line", this._line);
        }

        internal override bool IsXIndependent(GraphPane pane) => 
            true;

        internal override bool IsZIncluded(GraphPane pane) => 
            false;

        public override void MakeUnique(ColorSymbolRotator rotator)
        {
            base.Color = rotator.NextColor;
            this.Symbol.Type = rotator.NextSymbol;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public ZedGraph.Symbol Symbol
        {
            get => 
                this._symbol;
            set => 
                this._symbol = value;
        }

        public ZedGraph.Line Line
        {
            get => 
                this._line;
            set => 
                this._line = value;
        }
    }
}

