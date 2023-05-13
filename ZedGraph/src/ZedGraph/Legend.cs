namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class Legend : ICloneable, ISerializable
    {
        public const int schema = 12;
        private RectangleF _rect;
        private LegendPos _position;
        private bool _isHStack;
        private bool _isVisible;
        private ZedGraph.Fill _fill;
        private ZedGraph.Border _border;
        private ZedGraph.FontSpec _fontSpec;
        private ZedGraph.Location _location;
        private int _hStack;
        private float _legendItemWidth;
        private float _legendItemHeight;
        private float _gap;
        private bool _isReverse;
        private float _tmpSize;
        private bool _isShowLegendSymbols;

        public Legend()
        {
            this._position = Default.Position;
            this._isHStack = Default.IsHStack;
            this._isVisible = Default.IsVisible;
            this.Location = new ZedGraph.Location(0.0, 0.0, CoordType.PaneFraction);
            this._fontSpec = new ZedGraph.FontSpec(Default.FontFamily, Default.FontSize, Default.FontColor, Default.FontBold, Default.FontItalic, Default.FontUnderline, Default.FontFillColor, Default.FontFillBrush, Default.FontFillType);
            this._fontSpec.Border.IsVisible = false;
            this._border = new ZedGraph.Border(Default.IsBorderVisible, Default.BorderColor, Default.BorderWidth);
            this._fill = new ZedGraph.Fill(Default.FillColor, Default.FillBrush, Default.FillType);
            this._gap = Default.Gap;
            this._isReverse = Default.IsReverse;
            this._isShowLegendSymbols = Default.IsShowLegendSymbols;
        }

        public Legend(Legend rhs)
        {
            this._rect = rhs.Rect;
            this._position = rhs.Position;
            this._isHStack = rhs.IsHStack;
            this._isVisible = rhs.IsVisible;
            this._location = rhs.Location;
            this._border = rhs.Border.Clone();
            this._fill = rhs.Fill.Clone();
            this._fontSpec = rhs.FontSpec.Clone();
            this._gap = rhs._gap;
            this._isReverse = rhs._isReverse;
            this._isShowLegendSymbols = rhs._isShowLegendSymbols;
        }

        protected Legend(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._position = (LegendPos) info.GetValue("position", typeof(LegendPos));
            this._isHStack = info.GetBoolean("isHStack");
            this._isVisible = info.GetBoolean("isVisible");
            this._fill = (ZedGraph.Fill) info.GetValue("fill", typeof(ZedGraph.Fill));
            this._border = (ZedGraph.Border) info.GetValue("border", typeof(ZedGraph.Border));
            this._fontSpec = (ZedGraph.FontSpec) info.GetValue("fontSpec", typeof(ZedGraph.FontSpec));
            this._location = (ZedGraph.Location) info.GetValue("location", typeof(ZedGraph.Location));
            this._gap = info.GetSingle("gap");
            this._isReverse = info.GetBoolean("isReverse");
            this._isShowLegendSymbols = info.GetBoolean("isShowLegendSymbols");
        }

        public void CalcRect(Graphics g, PaneBase pane, float scaleFactor, ref RectangleF tChartRect)
        {
            this._rect = Rectangle.Empty;
            this._hStack = 1;
            this._legendItemWidth = 1f;
            this._legendItemHeight = 0f;
            RectangleF ef = pane.CalcClientRect(g, scaleFactor);
            if (!this._isVisible)
            {
                return;
            }
            int num = 0;
            PaneList paneList = this.GetPaneList(pane);
            this._tmpSize = this.GetMaxHeight(paneList, g, scaleFactor);
            float num2 = this._tmpSize / 2f;
            float num3 = 0f;
            float num5 = this._gap * this._tmpSize;
            using (List<GraphPane>.Enumerator enumerator = paneList.GetEnumerator())
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        break;
                    }
                    GraphPane current = enumerator.Current;
                    int count = current.CurveList.Count;
                    int num7 = 0;
                    while (true)
                    {
                        if (num7 < count)
                        {
                            CurveItem item = current.CurveList[this._isReverse ? ((count - num7) - 1) : num7];
                            if ((item._label._text != string.Empty) && item._label._isVisible)
                            {
                                float num4 = ((item._label._fontSpec != null) ? item._label._fontSpec : this.FontSpec).GetWidth(g, item._label._text, scaleFactor);
                                if (num4 > num3)
                                {
                                    num3 = num4;
                                }
                                if ((item is LineItem) && (((LineItem) item).Symbol.Size > this._legendItemHeight))
                                {
                                    this._legendItemHeight = ((LineItem) item).Symbol.Size;
                                }
                                num++;
                            }
                            num7++;
                            continue;
                        }
                        if (!(pane is MasterPane) || !((MasterPane) pane).IsUniformLegendEntries)
                        {
                            break;
                        }
                        goto TR_0024;
                    }
                }
            }
        TR_0024:
            if (!this._isHStack)
            {
                this._legendItemWidth = !this._isShowLegendSymbols ? ((0.5f * this._tmpSize) + num3) : ((3f * this._tmpSize) + num3);
            }
            else
            {
                float num8;
                switch (this._position)
                {
                    case LegendPos.Top:
                    case LegendPos.Bottom:
                    case LegendPos.TopCenter:
                    case LegendPos.BottomCenter:
                        num8 = tChartRect.Width;
                        break;

                    case LegendPos.Left:
                    case LegendPos.Right:
                        num8 = 0f;
                        break;

                    case LegendPos.InsideTopLeft:
                    case LegendPos.InsideTopRight:
                    case LegendPos.InsideBotLeft:
                    case LegendPos.InsideBotRight:
                    case LegendPos.Float:
                        num8 = tChartRect.Width / 2f;
                        break;

                    case LegendPos.TopFlushLeft:
                    case LegendPos.BottomFlushLeft:
                        num8 = ef.Width;
                        break;

                    default:
                        num8 = 0f;
                        break;
                }
                this._legendItemWidth = !this._isShowLegendSymbols ? ((0.5f * this._tmpSize) + num3) : ((3f * this._tmpSize) + num3);
                if (num3 > 0f)
                {
                    this._hStack = (int) ((num8 - num2) / this._legendItemWidth);
                }
                if (this._hStack > num)
                {
                    this._hStack = num;
                }
                this._hStack ??= 1;
            }
            float width = this._hStack * this._legendItemWidth;
            this._legendItemHeight = (this._legendItemHeight * scaleFactor) + num2;
            if (this._tmpSize > this._legendItemHeight)
            {
                this._legendItemHeight = this._tmpSize;
            }
            float height = ((float) Math.Ceiling((double) (((double) num) / ((double) this._hStack)))) * this._legendItemHeight;
            RectangleF ef2 = new RectangleF();
            if (num > 0)
            {
                ef2 = new RectangleF(0f, 0f, width, height);
                switch (this._position)
                {
                    case LegendPos.Top:
                        ef2.X = tChartRect.Left;
                        ef2.Y = ef.Top;
                        tChartRect.Y += height + num5;
                        tChartRect.Height -= height + num5;
                        break;

                    case LegendPos.Left:
                        ef2.X = ef.Left;
                        ef2.Y = tChartRect.Top;
                        tChartRect.X += width + num2;
                        tChartRect.Width -= width + num5;
                        break;

                    case LegendPos.Right:
                        ef2.X = ef.Right - width;
                        ef2.Y = tChartRect.Top;
                        tChartRect.Width -= width + num5;
                        break;

                    case LegendPos.Bottom:
                        ef2.X = tChartRect.Left;
                        ef2.Y = ef.Bottom - height;
                        tChartRect.Height -= height + num5;
                        break;

                    case LegendPos.InsideTopLeft:
                        ef2.X = tChartRect.Left;
                        ef2.Y = tChartRect.Top;
                        break;

                    case LegendPos.InsideTopRight:
                        ef2.X = tChartRect.Right - width;
                        ef2.Y = tChartRect.Top;
                        break;

                    case LegendPos.InsideBotLeft:
                        ef2.X = tChartRect.Left;
                        ef2.Y = tChartRect.Bottom - height;
                        break;

                    case LegendPos.InsideBotRight:
                        ef2.X = tChartRect.Right - width;
                        ef2.Y = tChartRect.Bottom - height;
                        break;

                    case LegendPos.Float:
                        ef2.Location = this.Location.TransformTopLeft(pane, width, height);
                        break;

                    case LegendPos.TopCenter:
                        ef2.X = tChartRect.Left + ((tChartRect.Width - width) / 2f);
                        ef2.Y = tChartRect.Top;
                        tChartRect.Y += height + num5;
                        tChartRect.Height -= height + num5;
                        break;

                    case LegendPos.BottomCenter:
                        ef2.X = tChartRect.Left + ((tChartRect.Width - width) / 2f);
                        ef2.Y = ef.Bottom - height;
                        tChartRect.Height -= height + num5;
                        break;

                    case LegendPos.TopFlushLeft:
                        ef2.X = ef.Left;
                        ef2.Y = ef.Top;
                        tChartRect.Y += height + (num5 * 1.5f);
                        tChartRect.Height -= height + (num5 * 1.5f);
                        break;

                    case LegendPos.BottomFlushLeft:
                        ef2.X = ef.Left;
                        ef2.Y = ef.Bottom - height;
                        tChartRect.Height -= height + num5;
                        break;

                    default:
                        break;
                }
            }
            this._rect = ef2;
        }

        public Legend Clone() => 
            new Legend(this);

        public void Draw(Graphics g, PaneBase pane, float scaleFactor)
        {
            if (this._isVisible)
            {
                this._fill.Draw(g, this._rect);
                PaneList paneList = this.GetPaneList(pane);
                float num = this._tmpSize / 2f;
                if (this._hStack <= 0)
                {
                    this._hStack = 1;
                }
                if (this._legendItemWidth <= 0f)
                {
                    this._legendItemWidth = 100f;
                }
                if (this._legendItemHeight <= 0f)
                {
                    this._legendItemHeight = this._tmpSize;
                }
                int num2 = 0;
                using (new SolidBrush(Color.Black))
                {
                    using (List<GraphPane>.Enumerator enumerator = paneList.GetEnumerator())
                    {
                        while (true)
                        {
                            if (!enumerator.MoveNext())
                            {
                                break;
                            }
                            GraphPane current = enumerator.Current;
                            int count = current.CurveList.Count;
                            int num6 = 0;
                            while (true)
                            {
                                if (num6 < count)
                                {
                                    CurveItem item = current.CurveList[this._isReverse ? ((count - num6) - 1) : num6];
                                    if ((item._label._text != "") && item._label._isVisible)
                                    {
                                        float x = (this._rect.Left + (num / 2f)) + ((num2 % this._hStack) * this._legendItemWidth);
                                        float num4 = this._rect.Top + ((num2 / this._hStack) * this._legendItemHeight);
                                        ZedGraph.FontSpec spec = (item._label._fontSpec != null) ? item._label._fontSpec : this.FontSpec;
                                        spec.StringAlignment = StringAlignment.Near;
                                        if (this._isShowLegendSymbols)
                                        {
                                            spec.Draw(g, pane, item._label._text, x + (2.5f * this._tmpSize), num4 + (this._legendItemHeight / 2f), AlignH.Left, AlignV.Center, scaleFactor);
                                            RectangleF rect = new RectangleF(x, num4 + (this._legendItemHeight / 4f), 2f * this._tmpSize, this._legendItemHeight / 2f);
                                            item.DrawLegendKey(g, current, rect, scaleFactor);
                                        }
                                        else
                                        {
                                            if (item._label._fontSpec == null)
                                            {
                                                spec.FontColor = item.Color;
                                            }
                                            spec.Draw(g, pane, item._label._text, x + (0f * this._tmpSize), num4 + (this._legendItemHeight / 2f), AlignH.Left, AlignV.Center, scaleFactor);
                                        }
                                        num2++;
                                    }
                                    num6++;
                                    continue;
                                }
                                if (!(pane is MasterPane) || !((MasterPane) pane).IsUniformLegendEntries)
                                {
                                    break;
                                }
                                goto TR_0007;
                            }
                        }
                    }
                TR_0007:
                    if (num2 > 0)
                    {
                        this.Border.Draw(g, pane, scaleFactor, this._rect);
                    }
                }
            }
        }

        public bool FindPoint(PointF mousePt, PaneBase pane, float scaleFactor, out int index)
        {
            bool flag;
            index = -1;
            if (!this._rect.Contains(mousePt))
            {
                return false;
            }
            int num = (int) ((mousePt.Y - this._rect.Top) / this._legendItemHeight);
            int num2 = (int) (((mousePt.X - this._rect.Left) - (this._tmpSize / 2f)) / this._legendItemWidth);
            if (num2 < 0)
            {
                num2 = 0;
            }
            if (num2 >= this._hStack)
            {
                num2 = this._hStack - 1;
            }
            int num3 = num2 + (num * this._hStack);
            index = 0;
            using (List<GraphPane>.Enumerator enumerator = this.GetPaneList(pane).GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        GraphPane current = enumerator.Current;
                        using (List<CurveItem>.Enumerator enumerator2 = current.CurveList.GetEnumerator())
                        {
                            while (true)
                            {
                                if (!enumerator2.MoveNext())
                                {
                                    break;
                                }
                                CurveItem item = enumerator2.Current;
                                if (item._label._isVisible && (item._label._text != string.Empty))
                                {
                                    if (num3 != 0)
                                    {
                                        num3--;
                                    }
                                    else
                                    {
                                        return true;
                                    }
                                }
                                index++;
                            }
                        }
                        continue;
                    }
                    else
                    {
                        return true;
                    }
                    break;
                }
            }
            return flag;
        }

        private float GetMaxHeight(PaneList paneList, Graphics g, float scaleFactor)
        {
            float height = this.FontSpec.GetHeight(scaleFactor);
            float num2 = height;
            foreach (GraphPane pane in paneList)
            {
                foreach (CurveItem item in pane.CurveList)
                {
                    if ((item._label._text != string.Empty) && item._label._isVisible)
                    {
                        float num3 = height;
                        if (item._label._fontSpec != null)
                        {
                            num3 = item._label._fontSpec.GetHeight(scaleFactor);
                        }
                        num3 *= item._label._text.Split(new char[] { '\n' }).Length;
                        if (num3 > num2)
                        {
                            num2 = num3;
                        }
                    }
                }
            }
            return num2;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 12);
            info.AddValue("position", this._position);
            info.AddValue("isHStack", this._isHStack);
            info.AddValue("isVisible", this._isVisible);
            info.AddValue("fill", this._fill);
            info.AddValue("border", this._border);
            info.AddValue("fontSpec", this._fontSpec);
            info.AddValue("location", this._location);
            info.AddValue("gap", this._gap);
            info.AddValue("isReverse", this._isReverse);
            info.AddValue("isShowLegendSymbols", this._isShowLegendSymbols);
        }

        private PaneList GetPaneList(PaneBase pane)
        {
            PaneList paneList;
            if (pane is GraphPane)
            {
                paneList = new PaneList();
                paneList.Add((GraphPane) pane);
            }
            else
            {
                paneList = ((MasterPane) pane).PaneList;
            }
            return paneList;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public RectangleF Rect =>
            this._rect;

        public ZedGraph.FontSpec FontSpec
        {
            get => 
                this._fontSpec;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Uninitialized FontSpec in Legend");
                }
                this._fontSpec = value;
            }
        }

        public bool IsVisible
        {
            get => 
                this._isVisible;
            set => 
                this._isVisible = value;
        }

        public ZedGraph.Border Border
        {
            get => 
                this._border;
            set => 
                this._border = value;
        }

        public ZedGraph.Fill Fill
        {
            get => 
                this._fill;
            set => 
                this._fill = value;
        }

        public bool IsHStack
        {
            get => 
                this._isHStack;
            set => 
                this._isHStack = value;
        }

        public LegendPos Position
        {
            get => 
                this._position;
            set => 
                this._position = value;
        }

        public ZedGraph.Location Location
        {
            get => 
                this._location;
            set => 
                this._location = value;
        }

        public float Gap
        {
            get => 
                this._gap;
            set => 
                this._gap = value;
        }

        public bool IsReverse
        {
            get => 
                this._isReverse;
            set => 
                this._isReverse = value;
        }

        public bool IsShowLegendSymbols
        {
            get => 
                this._isShowLegendSymbols;
            set => 
                this._isShowLegendSymbols = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float BorderWidth;
            public static Color BorderColor;
            public static Color FillColor;
            public static Brush FillBrush;
            public static ZedGraph.FillType FillType;
            public static LegendPos Position;
            public static bool IsBorderVisible;
            public static bool IsVisible;
            public static bool IsFilled;
            public static bool IsHStack;
            public static string FontFamily;
            public static float FontSize;
            public static Color FontColor;
            public static bool FontBold;
            public static bool FontItalic;
            public static bool FontUnderline;
            public static Color FontFillColor;
            public static Brush FontFillBrush;
            public static ZedGraph.FillType FontFillType;
            public static float Gap;
            public static bool IsReverse;
            public static bool IsShowLegendSymbols;
            static Default()
            {
                BorderWidth = 1f;
                BorderColor = Color.Black;
                FillColor = Color.White;
                FillBrush = null;
                FillType = ZedGraph.FillType.Brush;
                Position = LegendPos.Top;
                IsBorderVisible = true;
                IsVisible = true;
                IsFilled = true;
                IsHStack = true;
                FontFamily = "Arial";
                FontSize = 12f;
                FontColor = Color.Black;
                FontBold = false;
                FontItalic = false;
                FontUnderline = false;
                FontFillColor = Color.White;
                FontFillBrush = null;
                FontFillType = ZedGraph.FillType.None;
                Gap = 0.5f;
                IsReverse = false;
                IsShowLegendSymbols = true;
            }
        }
    }
}

