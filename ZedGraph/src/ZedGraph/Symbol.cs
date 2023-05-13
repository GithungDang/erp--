namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class Symbol : ICloneable, ISerializable
    {
        public const int schema = 11;
        private float _size;
        private SymbolType _type;
        private bool _isAntiAlias;
        private bool _isVisible;
        private ZedGraph.Fill _fill;
        private ZedGraph.Border _border;
        private GraphicsPath _userSymbol;

        public Symbol() : this(SymbolType.Default, Color.Empty)
        {
        }

        public Symbol(Symbol rhs)
        {
            this._size = rhs.Size;
            this._type = rhs.Type;
            this._isAntiAlias = rhs._isAntiAlias;
            this._isVisible = rhs.IsVisible;
            this._fill = rhs.Fill.Clone();
            this._border = rhs.Border.Clone();
            if (rhs.UserSymbol != null)
            {
                this._userSymbol = rhs.UserSymbol.Clone() as GraphicsPath;
            }
            else
            {
                this._userSymbol = null;
            }
        }

        protected Symbol(SerializationInfo info, StreamingContext context)
        {
            int num = info.GetInt32("schema");
            this._size = info.GetSingle("size");
            this._type = (SymbolType) info.GetValue("type", typeof(SymbolType));
            this._isAntiAlias = info.GetBoolean("isAntiAlias");
            this._isVisible = info.GetBoolean("isVisible");
            this._fill = (ZedGraph.Fill) info.GetValue("fill", typeof(ZedGraph.Fill));
            this._border = (ZedGraph.Border) info.GetValue("border", typeof(ZedGraph.Border));
            if (num >= 11)
            {
                this._userSymbol = (GraphicsPath) info.GetValue("userSymbol", typeof(GraphicsPath));
            }
            else
            {
                this._userSymbol = null;
            }
        }

        public Symbol(SymbolType type, Color color)
        {
            this._size = Default.Size;
            this._type = type;
            this._isAntiAlias = Default.IsAntiAlias;
            this._isVisible = Default.IsVisible;
            this._border = new ZedGraph.Border(Default.IsBorderVisible, color, Default.PenWidth);
            this._fill = new ZedGraph.Fill(color, Default.FillBrush, Default.FillType);
            this._userSymbol = null;
        }

        public Symbol Clone() => 
            new Symbol(this);

        public void Draw(Graphics g, GraphPane pane, LineItem curve, float scaleFactor, bool isSelected)
        {
            Symbol symbol = this;
            if (isSelected)
            {
                symbol = Selection.Symbol;
            }
            int left = (int) pane.Chart.Rect.Left;
            int right = (int) pane.Chart.Rect.Right;
            int top = (int) pane.Chart.Rect.Top;
            int bottom = (int) pane.Chart.Rect.Bottom;
            bool[,] flagArray = new bool[right + 1, bottom + 1];
            IPointList points = curve.Points;
            if ((points != null) && (this._border.IsVisible || this._fill.IsVisible))
            {
                SmoothingMode smoothingMode = g.SmoothingMode;
                if (this._isAntiAlias)
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                }
                using (Pen pen = symbol._border.GetPen(pane, scaleFactor))
                {
                    using (GraphicsPath path = this.MakePath(g, scaleFactor))
                    {
                        RectangleF bounds = path.GetBounds();
                        using (Brush brush = symbol.Fill.MakeBrush(bounds))
                        {
                            ValueHandler handler = new ValueHandler(pane, false);
                            Scale scale = curve.GetXAxis(pane).Scale;
                            Scale scale2 = curve.GetYAxis(pane).Scale;
                            bool isLog = scale.IsLog;
                            bool flag2 = scale2.IsLog;
                            bool isAnyOrdinal = scale.IsAnyOrdinal;
                            double min = scale.Min;
                            double max = scale.Max;
                            int iPt = 0;
                            goto TR_0022;
                        TR_000B:
                            iPt++;
                        TR_0022:
                            while (true)
                            {
                                if (iPt < points.Count)
                                {
                                    double x;
                                    double num8;
                                    if (pane.LineType == LineType.Stack)
                                    {
                                        double num9;
                                        handler.GetValues(curve, iPt, out x, out num9, out num8);
                                    }
                                    else
                                    {
                                        x = points[iPt].X;
                                        num8 = !(curve is StickItem) ? points[iPt].Y : points[iPt].Z;
                                    }
                                    if (((x != double.MaxValue) && ((num8 != double.MaxValue) && (!double.IsNaN(x) && (!double.IsNaN(num8) && (!double.IsInfinity(x) && (!double.IsInfinity(num8) && ((x > 0.0) || !isLog))))))) && ((!flag2 || (num8 > 0.0)) && (isAnyOrdinal || ((x >= min) && (x <= max)))))
                                    {
                                        int x = (int) scale.Transform(curve.IsOverrideOrdinal, iPt, x);
                                        int y = (int) scale2.Transform(curve.IsOverrideOrdinal, iPt, num8);
                                        if ((x >= left) && ((x <= right) && ((y >= top) && (y <= bottom))))
                                        {
                                            if (flagArray[x, y])
                                            {
                                                break;
                                            }
                                            flagArray[x, y] = true;
                                        }
                                        if (!this._fill.IsGradientValueType && !this._border._gradientFill.IsGradientValueType)
                                        {
                                            this.DrawSymbol(g, x, y, path, pen, brush);
                                        }
                                        else
                                        {
                                            using (Brush brush2 = this._fill.MakeBrush(bounds, points[iPt]))
                                            {
                                                using (Pen pen2 = this._border.GetPen(pane, scaleFactor, points[iPt]))
                                                {
                                                    this.DrawSymbol(g, x, y, path, pen2, brush2);
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    g.SmoothingMode = smoothingMode;
                                    return;
                                }
                                break;
                            }
                            goto TR_000B;
                        }
                    }
                }
            }
        }

        private void DrawSymbol(Graphics g, int x, int y, GraphicsPath path, Pen pen, Brush brush)
        {
            if (this._isVisible && ((this.Type != SymbolType.None) && ((x < 0x186a0) && ((x > -100000) && ((y < 0x186a0) && (y > -100000))))))
            {
                Matrix transform = g.Transform;
                g.TranslateTransform((float) x, (float) y);
                if (this._fill.IsVisible)
                {
                    g.FillPath(brush, path);
                }
                if (this._border.IsVisible)
                {
                    g.DrawPath(pen, path);
                }
                g.Transform = transform;
            }
        }

        public void DrawSymbol(Graphics g, GraphPane pane, int x, int y, float scaleFactor, bool isSelected, PointPair dataValue)
        {
            SmoothingMode smoothingMode;
            if (isSelected)
            {
                Symbol symbol = Selection.Symbol;
            }
            if (!this._isVisible || ((this.Type == SymbolType.None) || ((x >= 0x186a0) || ((x <= -100000) || ((y >= 0x186a0) || (y <= -100000))))))
            {
                return;
            }
            else
            {
                smoothingMode = g.SmoothingMode;
                if (this._isAntiAlias)
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                }
                using (Pen pen = this._border.GetPen(pane, scaleFactor, dataValue))
                {
                    using (GraphicsPath path = this.MakePath(g, scaleFactor))
                    {
                        using (Brush brush = this.Fill.MakeBrush(path.GetBounds(), dataValue))
                        {
                            this.DrawSymbol(g, x, y, path, pen, brush);
                        }
                    }
                }
            }
            g.SmoothingMode = smoothingMode;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 11);
            info.AddValue("size", this._size);
            info.AddValue("type", this._type);
            info.AddValue("isAntiAlias", this._isAntiAlias);
            info.AddValue("isVisible", this._isVisible);
            info.AddValue("fill", this._fill);
            info.AddValue("border", this._border);
            info.AddValue("userSymbol", this._userSymbol);
        }

        public GraphicsPath MakePath(Graphics g, float scaleFactor)
        {
            float width = this._size * scaleFactor;
            float num2 = width / 2f;
            float num3 = num2 + 1f;
            GraphicsPath path = new GraphicsPath();
            switch ((((this._type == SymbolType.Default) || ((this._type == SymbolType.UserDefined) && (this._userSymbol == null))) ? Default.Type : this._type))
            {
                case SymbolType.Square:
                    path.AddLine(-num2, -num2, num2, -num2);
                    path.AddLine(num2, -num2, num2, num2);
                    path.AddLine(num2, num2, -num2, num2);
                    path.AddLine(-num2, num2, -num2, -num2);
                    break;

                case SymbolType.Diamond:
                    path.AddLine(0f, -num2, num2, 0f);
                    path.AddLine(num2, 0f, 0f, num2);
                    path.AddLine(0f, num2, -num2, 0f);
                    path.AddLine(-num2, 0f, 0f, -num2);
                    break;

                case SymbolType.Triangle:
                    path.AddLine(0f, -num2, num2, num2);
                    path.AddLine(num2, num2, -num2, num2);
                    path.AddLine(-num2, num2, 0f, -num2);
                    break;

                case SymbolType.Circle:
                    path.AddEllipse(-num2, -num2, width, width);
                    break;

                case SymbolType.XCross:
                    path.AddLine(-num2, -num2, num3, num3);
                    path.StartFigure();
                    path.AddLine(num2, -num2, -num3, num3);
                    break;

                case SymbolType.Plus:
                    path.AddLine(0f, -num2, 0f, num3);
                    path.StartFigure();
                    path.AddLine(-num2, 0f, num3, 0f);
                    break;

                case SymbolType.Star:
                    path.AddLine(0f, -num2, 0f, num3);
                    path.StartFigure();
                    path.AddLine(-num2, 0f, num3, 0f);
                    path.StartFigure();
                    path.AddLine(-num2, -num2, num3, num3);
                    path.StartFigure();
                    path.AddLine(num2, -num2, -num3, num3);
                    break;

                case SymbolType.TriangleDown:
                    path.AddLine(0f, num2, num2, -num2);
                    path.AddLine(num2, -num2, -num2, -num2);
                    path.AddLine(-num2, -num2, 0f, num2);
                    break;

                case SymbolType.HDash:
                    path.AddLine(-num2, 0f, num3, 0f);
                    break;

                case SymbolType.VDash:
                    path.AddLine(0f, -num2, 0f, num3);
                    break;

                case SymbolType.UserDefined:
                    path = this._userSymbol.Clone() as GraphicsPath;
                    path.Transform(new Matrix(width, 0f, 0f, width, 0f, 0f));
                    break;

                default:
                    break;
            }
            return path;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public float Size
        {
            get => 
                this._size;
            set => 
                this._size = value;
        }

        public SymbolType Type
        {
            get => 
                this._type;
            set => 
                this._type = value;
        }

        public bool IsAntiAlias
        {
            get => 
                this._isAntiAlias;
            set => 
                this._isAntiAlias = value;
        }

        public bool IsVisible
        {
            get => 
                this._isVisible;
            set => 
                this._isVisible = value;
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

        public GraphicsPath UserSymbol
        {
            get => 
                this._userSymbol;
            set => 
                this._userSymbol = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float Size;
            public static float PenWidth;
            public static Color FillColor;
            public static Brush FillBrush;
            public static ZedGraph.FillType FillType;
            public static SymbolType Type;
            public static bool IsAntiAlias;
            public static bool IsVisible;
            public static bool IsBorderVisible;
            public static Color BorderColor;
            static Default()
            {
                Size = 7f;
                PenWidth = 1f;
                FillColor = Color.Red;
                FillBrush = null;
                FillType = ZedGraph.FillType.None;
                Type = SymbolType.Square;
                IsAntiAlias = false;
                IsVisible = true;
                IsBorderVisible = true;
                BorderColor = Color.Red;
            }
        }
    }
}

