namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public abstract class GraphObj : ISerializable, ICloneable
    {
        public const int schema = 10;
        protected ZedGraph.Location _location;
        protected bool _isVisible;
        protected bool _isClippedToChartRect;
        public object Tag;
        internal ZedGraph.ZOrder _zOrder;
        internal ZedGraph.Link _link;

        public GraphObj() : this(0.0, 0.0, Default.CoordFrame, Default.AlignH, Default.AlignV)
        {
        }

        public GraphObj(GraphObj rhs)
        {
            this._isVisible = rhs.IsVisible;
            this._isClippedToChartRect = rhs._isClippedToChartRect;
            this._zOrder = rhs.ZOrder;
            this.Tag = !(rhs.Tag is ICloneable) ? rhs.Tag : ((ICloneable) rhs.Tag).Clone();
            this._location = rhs.Location.Clone();
            this._link = rhs._link.Clone();
        }

        public GraphObj(double x, double y) : this(x, y, Default.CoordFrame, Default.AlignH, Default.AlignV)
        {
        }

        protected GraphObj(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._location = (ZedGraph.Location) info.GetValue("location", typeof(ZedGraph.Location));
            this._isVisible = info.GetBoolean("isVisible");
            this.Tag = info.GetValue("Tag", typeof(object));
            this._zOrder = (ZedGraph.ZOrder) info.GetValue("zOrder", typeof(ZedGraph.ZOrder));
            this._isClippedToChartRect = info.GetBoolean("isClippedToChartRect");
            this._link = (ZedGraph.Link) info.GetValue("link", typeof(ZedGraph.Link));
        }

        public GraphObj(double x, double y, CoordType coordType) : this(x, y, coordType, Default.AlignH, Default.AlignV)
        {
        }

        public GraphObj(double x, double y, double x2, double y2) : this(x, y, x2, y2, Default.CoordFrame, Default.AlignH, Default.AlignV)
        {
        }

        public GraphObj(double x, double y, CoordType coordType, AlignH alignH, AlignV alignV)
        {
            this._isVisible = true;
            this._isClippedToChartRect = Default.IsClippedToChartRect;
            this.Tag = null;
            this._zOrder = ZedGraph.ZOrder.A_InFront;
            this._location = new ZedGraph.Location(x, y, coordType, alignH, alignV);
            this._link = new ZedGraph.Link();
        }

        public GraphObj(double x, double y, double x2, double y2, CoordType coordType, AlignH alignH, AlignV alignV)
        {
            this._isVisible = true;
            this._isClippedToChartRect = Default.IsClippedToChartRect;
            this.Tag = null;
            this._zOrder = ZedGraph.ZOrder.A_InFront;
            this._location = new ZedGraph.Location(x, y, x2, y2, coordType, alignH, alignV);
            this._link = new ZedGraph.Link();
        }

        public abstract void Draw(Graphics g, PaneBase pane, float scaleFactor);
        public abstract void GetCoords(PaneBase pane, Graphics g, float scaleFactor, out string shape, out string coords);
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("location", this._location);
            info.AddValue("isVisible", this._isVisible);
            info.AddValue("Tag", this.Tag);
            info.AddValue("zOrder", this._zOrder);
            info.AddValue("isClippedToChartRect", this._isClippedToChartRect);
            info.AddValue("link", this._link);
        }

        public virtual bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor)
        {
            GraphPane pane2 = pane as GraphPane;
            return (((pane2 == null) || !this._isClippedToChartRect) || pane2.Chart.Rect.Contains(pt));
        }

        object ICloneable.Clone()
        {
            throw new NotImplementedException("Can't clone an abstract base type -- child types must implement ICloneable");
        }

        public ZedGraph.Location Location
        {
            get => 
                this._location;
            set => 
                this._location = value;
        }

        public ZedGraph.ZOrder ZOrder
        {
            get => 
                this._zOrder;
            set => 
                this._zOrder = value;
        }

        public bool IsVisible
        {
            get => 
                this._isVisible;
            set => 
                this._isVisible = value;
        }

        public bool IsClippedToChartRect
        {
            get => 
                this._isClippedToChartRect;
            set => 
                this._isClippedToChartRect = value;
        }

        public ZedGraph.Link Link
        {
            get => 
                this._link;
            set => 
                this._link = value;
        }

        public bool IsInFrontOfData =>
            (this._zOrder == ZedGraph.ZOrder.A_InFront) || ((this._zOrder == ZedGraph.ZOrder.B_BehindLegend) || (this._zOrder == ZedGraph.ZOrder.C_BehindChartBorder));

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static ZedGraph.AlignV AlignV;
            public static ZedGraph.AlignH AlignH;
            public static CoordType CoordFrame;
            public static bool IsClippedToChartRect;
            static Default()
            {
                AlignV = ZedGraph.AlignV.Center;
                AlignH = ZedGraph.AlignH.Center;
                CoordFrame = CoordType.AxisXYScale;
                IsClippedToChartRect = false;
            }
        }
    }
}

