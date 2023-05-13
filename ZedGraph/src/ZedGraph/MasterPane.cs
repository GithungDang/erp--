namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class MasterPane : PaneBase, ICloneable, ISerializable, IDeserializationCallback
    {
        public const int schema2 = 11;
        internal ZedGraph.PaneList _paneList;
        internal float _innerPaneGap;
        private bool _isUniformLegendEntries;
        private bool _isCommonScaleFactor;
        internal PaneLayout _paneLayout;
        internal bool _isColumnSpecified;
        internal int[] _countList;
        internal float[] _prop;
        private bool _isAntiAlias;

        public MasterPane() : this("", new RectangleF(0f, 0f, 500f, 375f))
        {
        }

        public MasterPane(MasterPane rhs) : base(rhs)
        {
            this._innerPaneGap = rhs._innerPaneGap;
            this._isUniformLegendEntries = rhs._isUniformLegendEntries;
            this._isCommonScaleFactor = rhs._isCommonScaleFactor;
            this._paneList = rhs._paneList.Clone();
            this._paneLayout = rhs._paneLayout;
            this._countList = rhs._countList;
            this._isColumnSpecified = rhs._isColumnSpecified;
            this._prop = rhs._prop;
            this._isAntiAlias = rhs._isAntiAlias;
        }

        protected MasterPane(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            int num = info.GetInt32("schema2");
            this._paneList = (ZedGraph.PaneList) info.GetValue("paneList", typeof(ZedGraph.PaneList));
            this._innerPaneGap = info.GetSingle("innerPaneGap");
            this._isUniformLegendEntries = info.GetBoolean("isUniformLegendEntries");
            this._isCommonScaleFactor = info.GetBoolean("isCommonScaleFactor");
            this._paneLayout = (PaneLayout) info.GetValue("paneLayout", typeof(PaneLayout));
            this._countList = (int[]) info.GetValue("countList", typeof(int[]));
            this._isColumnSpecified = info.GetBoolean("isColumnSpecified");
            this._prop = (float[]) info.GetValue("prop", typeof(float[]));
            if (num >= 11)
            {
                this._isAntiAlias = info.GetBoolean("isAntiAlias");
            }
        }

        public MasterPane(string title, RectangleF paneRect) : base(title, paneRect)
        {
            this._innerPaneGap = Default.InnerPaneGap;
            this._isUniformLegendEntries = Default.IsUniformLegendEntries;
            this._isCommonScaleFactor = Default.IsCommonScaleFactor;
            this._paneList = new ZedGraph.PaneList();
            base._legend.IsVisible = Default.IsShowLegend;
            this._isAntiAlias = false;
            this.InitLayout();
        }

        public void Add(GraphPane pane)
        {
            this._paneList.Add(pane);
        }

        public void AxisChange()
        {
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                this.AxisChange(graphics);
            }
        }

        public void AxisChange(Graphics g)
        {
            foreach (GraphPane pane in this._paneList)
            {
                pane.AxisChange(g);
            }
        }

        public MasterPane Clone() => 
            new MasterPane(this);

        public void CommonScaleFactor()
        {
            if (this._isCommonScaleFactor)
            {
                float num = 0f;
                foreach (GraphPane pane in this.PaneList)
                {
                    pane.BaseDimension = PaneBase.Default.BaseDimension;
                    float num2 = pane.CalcScaleFactor();
                    num = (num2 > num) ? num2 : num;
                }
                foreach (GraphPane pane2 in this.PaneList)
                {
                    float num3 = pane2.CalcScaleFactor();
                    pane2.BaseDimension *= num3 / num;
                }
            }
        }

        public void DoLayout(Graphics g)
        {
            if (this._countList != null)
            {
                this.DoLayout(g, this._isColumnSpecified, this._countList, this._prop);
            }
            else
            {
                int count = this._paneList.Count;
                if (count != 0)
                {
                    int num2;
                    int num3;
                    int columns = (int) (Math.Sqrt((double) count) + 0.9999999);
                    switch (this._paneLayout)
                    {
                        case PaneLayout.ForceSquare:
                            num2 = columns;
                            this.DoLayout(g, num2, columns);
                            return;

                        case PaneLayout.SquareRowPreferred:
                            num2 = columns;
                            num3 = columns;
                            if (count <= (columns * (columns - 1)))
                            {
                                num3--;
                            }
                            this.DoLayout(g, num2, num3);
                            return;

                        case PaneLayout.SingleRow:
                            num2 = 1;
                            this.DoLayout(g, num2, count);
                            return;

                        case PaneLayout.SingleColumn:
                            num2 = count;
                            this.DoLayout(g, num2, 1);
                            return;

                        case PaneLayout.ExplicitCol12:
                            this.DoLayout(g, true, new int[] { 1, 2 }, null);
                            return;

                        case PaneLayout.ExplicitCol21:
                            this.DoLayout(g, true, new int[] { 2, 1 }, null);
                            return;

                        case PaneLayout.ExplicitCol23:
                            this.DoLayout(g, true, new int[] { 2, 3 }, null);
                            return;

                        case PaneLayout.ExplicitCol32:
                            this.DoLayout(g, true, new int[] { 3, 2 }, null);
                            return;

                        case PaneLayout.ExplicitRow12:
                            this.DoLayout(g, false, new int[] { 1, 2 }, null);
                            return;

                        case PaneLayout.ExplicitRow21:
                            this.DoLayout(g, false, new int[] { 2, 1 }, null);
                            return;

                        case PaneLayout.ExplicitRow23:
                            this.DoLayout(g, false, new int[] { 2, 3 }, null);
                            return;

                        case PaneLayout.ExplicitRow32:
                            this.DoLayout(g, false, new int[] { 3, 2 }, null);
                            return;
                    }
                    num2 = columns;
                    num3 = columns;
                    if (count <= (columns * (columns - 1)))
                    {
                        num2--;
                    }
                    this.DoLayout(g, num2, num3);
                }
            }
        }

        internal void DoLayout(Graphics g, int rows, int columns)
        {
            if (rows < 1)
            {
                rows = 1;
            }
            if (columns < 1)
            {
                columns = 1;
            }
            int[] countList = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                countList[i] = columns;
            }
            this.DoLayout(g, true, countList, null);
        }

        internal void DoLayout(Graphics g, bool isColumnSpecified, int[] countList, float[] proportion)
        {
            float scaleFactor = base.CalcScaleFactor();
            RectangleF tChartRect = base.CalcClientRect(g, scaleFactor);
            base._legend.CalcRect(g, this, scaleFactor, ref tChartRect);
            float num2 = this._innerPaneGap * scaleFactor;
            int num3 = 0;
            if (isColumnSpecified)
            {
                int length = countList.Length;
                float num5 = 0f;
                int index = 0;
                while (index < length)
                {
                    float num7 = (this._prop == null) ? (1f / ((float) length)) : this._prop[index];
                    float height = (tChartRect.Height - ((length - 1) * num2)) * num7;
                    int num9 = countList[index];
                    if (num9 <= 0)
                    {
                        num9 = 1;
                    }
                    float width = (tChartRect.Width - ((num9 - 1) * num2)) / ((float) num9);
                    int num11 = 0;
                    while (true)
                    {
                        if (num11 >= num9)
                        {
                            num5 += height + num2;
                            index++;
                            break;
                        }
                        if (num3 >= this._paneList.Count)
                        {
                            return;
                        }
                        this[num3].Rect = new RectangleF(tChartRect.X + (num11 * (width + num2)), tChartRect.Y + num5, width, height);
                        num3++;
                        num11++;
                    }
                }
            }
            else
            {
                int length = countList.Length;
                float num13 = 0f;
                int index = 0;
                while (index < length)
                {
                    float num15 = (this._prop == null) ? (1f / ((float) length)) : this._prop[index];
                    float width = (tChartRect.Width - ((length - 1) * num2)) * num15;
                    int num17 = countList[index];
                    if (num17 <= 0)
                    {
                        num17 = 1;
                    }
                    float height = (tChartRect.Height - ((num17 - 1) * num2)) / ((float) num17);
                    int num19 = 0;
                    while (true)
                    {
                        if (num19 >= num17)
                        {
                            num13 += width + num2;
                            index++;
                            break;
                        }
                        if (num3 >= this._paneList.Count)
                        {
                            return;
                        }
                        this[num3].Rect = new RectangleF(tChartRect.X + num13, tChartRect.Y + (num19 * (height + num2)), width, height);
                        num3++;
                        num19++;
                    }
                }
            }
        }

        public override void Draw(Graphics g)
        {
            SmoothingMode smoothingMode = g.SmoothingMode;
            TextRenderingHint textRenderingHint = g.TextRenderingHint;
            CompositingQuality compositingQuality = g.CompositingQuality;
            InterpolationMode interpolationMode = g.InterpolationMode;
            base.SetAntiAliasMode(g, this._isAntiAlias);
            base.Draw(g);
            if ((base._rect.Width > 1f) && (base._rect.Height > 1f))
            {
                float scaleFactor = base.CalcScaleFactor();
                g.SetClip(base._rect);
                base._graphObjList.Draw(g, this, scaleFactor, ZOrder.G_BehindChartFill);
                base._graphObjList.Draw(g, this, scaleFactor, ZOrder.E_BehindCurves);
                base._graphObjList.Draw(g, this, scaleFactor, ZOrder.D_BehindAxis);
                base._graphObjList.Draw(g, this, scaleFactor, ZOrder.C_BehindChartBorder);
                g.ResetClip();
                foreach (GraphPane pane in this._paneList)
                {
                    pane.Draw(g);
                }
                g.SetClip(base._rect);
                base._graphObjList.Draw(g, this, scaleFactor, ZOrder.B_BehindLegend);
                RectangleF tChartRect = base.CalcClientRect(g, scaleFactor);
                base._legend.CalcRect(g, this, scaleFactor, ref tChartRect);
                base._legend.Draw(g, this, scaleFactor);
                base._graphObjList.Draw(g, this, scaleFactor, ZOrder.A_InFront);
                g.ResetClip();
                g.SmoothingMode = smoothingMode;
                g.TextRenderingHint = textRenderingHint;
                g.CompositingQuality = compositingQuality;
                g.InterpolationMode = interpolationMode;
            }
        }

        public GraphPane FindChartRect(PointF mousePt)
        {
            GraphPane pane2;
            using (List<GraphPane>.Enumerator enumerator = this._paneList.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        GraphPane current = enumerator.Current;
                        if (!current.Chart._rect.Contains(mousePt))
                        {
                            continue;
                        }
                        pane2 = current;
                    }
                    else
                    {
                        return null;
                    }
                    break;
                }
            }
            return pane2;
        }

        public bool FindNearestPaneObject(PointF mousePt, Graphics g, out GraphPane pane, out object nearestObj, out int index)
        {
            bool flag;
            pane = null;
            nearestObj = null;
            index = -1;
            GraphObj obj2 = null;
            int num = -1;
            float scaleFactor = base.CalcScaleFactor();
            if (base.GraphObjList.FindPoint(mousePt, this, g, scaleFactor, out index))
            {
                obj2 = base.GraphObjList[index];
                num = index;
                if (obj2.ZOrder == ZOrder.A_InFront)
                {
                    nearestObj = obj2;
                    index = num;
                    return true;
                }
            }
            using (List<GraphPane>.Enumerator enumerator = this._paneList.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        GraphPane current = enumerator.Current;
                        RectangleF rect = current.Rect;
                        if (!rect.Contains(mousePt))
                        {
                            continue;
                        }
                        pane = current;
                        flag = current.FindNearestObject(mousePt, g, out nearestObj, out index);
                    }
                    else
                    {
                        if (obj2 == null)
                        {
                            return false;
                        }
                        nearestObj = obj2;
                        index = num;
                        return true;
                    }
                    break;
                }
            }
            return flag;
        }

        public GraphPane FindPane(PointF mousePt)
        {
            GraphPane pane2;
            using (List<GraphPane>.Enumerator enumerator = this._paneList.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        GraphPane current = enumerator.Current;
                        RectangleF rect = current.Rect;
                        if (!rect.Contains(mousePt))
                        {
                            continue;
                        }
                        pane2 = current;
                    }
                    else
                    {
                        return null;
                    }
                    break;
                }
            }
            return pane2;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 11);
            info.AddValue("paneList", this._paneList);
            info.AddValue("innerPaneGap", this._innerPaneGap);
            info.AddValue("isUniformLegendEntries", this._isUniformLegendEntries);
            info.AddValue("isCommonScaleFactor", this._isCommonScaleFactor);
            info.AddValue("paneLayout", this._paneLayout);
            info.AddValue("countList", this._countList);
            info.AddValue("isColumnSpecified", this._isColumnSpecified);
            info.AddValue("prop", this._prop);
            info.AddValue("isAntiAlias", this._isAntiAlias);
        }

        private void InitLayout()
        {
            this._paneLayout = Default.PaneLayout;
            this._countList = null;
            this._isColumnSpecified = false;
            this._prop = null;
        }

        public void OnDeserialization(object sender)
        {
            Graphics g = Graphics.FromImage(new Bitmap(10, 10));
            this.ReSize(g, base._rect);
        }

        public void ReSize(Graphics g)
        {
            this.ReSize(g, base._rect);
        }

        public override void ReSize(Graphics g, RectangleF rect)
        {
            base._rect = rect;
            this.DoLayout(g);
            this.CommonScaleFactor();
        }

        public void SetLayout(Graphics g, PaneLayout paneLayout)
        {
            this.InitLayout();
            this._paneLayout = paneLayout;
            this.DoLayout(g);
        }

        public void SetLayout(Graphics g, bool isColumnSpecified, int[] countList)
        {
            this.SetLayout(g, isColumnSpecified, countList, null);
        }

        public void SetLayout(Graphics g, int rows, int columns)
        {
            this.InitLayout();
            if (rows < 1)
            {
                rows = 1;
            }
            if (columns < 1)
            {
                columns = 1;
            }
            int[] countList = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                countList[i] = columns;
            }
            this.SetLayout(g, true, countList, null);
        }

        public unsafe void SetLayout(Graphics g, bool isColumnSpecified, int[] countList, float[] proportion)
        {
            this.InitLayout();
            if ((countList != null) && (countList.Length > 0))
            {
                this._prop = new float[countList.Length];
                float num = 0f;
                int index = 0;
                while (true)
                {
                    if (index >= countList.Length)
                    {
                        int num3 = 0;
                        while (true)
                        {
                            if (num3 >= countList.Length)
                            {
                                this._isColumnSpecified = isColumnSpecified;
                                this._countList = countList;
                                this.DoLayout(g);
                                break;
                            }
                            float* singlePtr1 = &(this._prop[num3]);
                            singlePtr1[0] /= num;
                            num3++;
                        }
                        break;
                    }
                    this._prop[index] = ((proportion == null) || ((proportion.Length <= index) || (proportion[index] < 1E-10))) ? 1f : proportion[index];
                    num += this._prop[index];
                    index++;
                }
            }
        }

        object ICloneable.Clone() => 
            this.Clone();

        public ZedGraph.PaneList PaneList
        {
            get => 
                this._paneList;
            set => 
                this._paneList = value;
        }

        public float InnerPaneGap
        {
            get => 
                this._innerPaneGap;
            set => 
                this._innerPaneGap = value;
        }

        public bool IsUniformLegendEntries
        {
            get => 
                this._isUniformLegendEntries;
            set => 
                this._isUniformLegendEntries = value;
        }

        public bool IsCommonScaleFactor
        {
            get => 
                this._isCommonScaleFactor;
            set => 
                this._isCommonScaleFactor = value;
        }

        public bool IsAntiAlias
        {
            get => 
                this._isAntiAlias;
            set => 
                this._isAntiAlias = value;
        }

        public GraphPane this[int index]
        {
            get => 
                this._paneList[index];
            set => 
                this._paneList[index] = value;
        }

        public GraphPane this[string title] =>
            this._paneList[title];

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static ZedGraph.PaneLayout PaneLayout;
            public static float InnerPaneGap;
            public static bool IsShowLegend;
            public static bool IsUniformLegendEntries;
            public static bool IsCommonScaleFactor;
            static Default()
            {
                PaneLayout = ZedGraph.PaneLayout.SquareColPreferred;
                InnerPaneGap = 10f;
                IsShowLegend = false;
                IsUniformLegendEntries = false;
                IsCommonScaleFactor = false;
            }
        }
    }
}

