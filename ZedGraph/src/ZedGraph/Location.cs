namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class Location : ICloneable, ISerializable
    {
        public const int schema = 10;
        private ZedGraph.AlignV _alignV;
        private ZedGraph.AlignH _alignH;
        private double _x;
        private double _y;
        private double _width;
        private double _height;
        private CoordType _coordinateFrame;

        public Location() : this(0.0, 0.0, CoordType.ChartFraction)
        {
        }

        public Location(Location rhs)
        {
            this._x = rhs._x;
            this._y = rhs._y;
            this._width = rhs._width;
            this._height = rhs._height;
            this._coordinateFrame = rhs.CoordinateFrame;
            this._alignH = rhs.AlignH;
            this._alignV = rhs.AlignV;
        }

        protected Location(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._alignV = (ZedGraph.AlignV) info.GetValue("alignV", typeof(ZedGraph.AlignV));
            this._alignH = (ZedGraph.AlignH) info.GetValue("alignH", typeof(ZedGraph.AlignH));
            this._x = info.GetDouble("x");
            this._y = info.GetDouble("y");
            this._width = info.GetDouble("width");
            this._height = info.GetDouble("height");
            this._coordinateFrame = (CoordType) info.GetValue("coordinateFrame", typeof(CoordType));
        }

        public Location(double x, double y, CoordType coordType) : this(x, y, coordType, ZedGraph.AlignH.Left, ZedGraph.AlignV.Top)
        {
        }

        public Location(double x, double y, CoordType coordType, ZedGraph.AlignH alignH, ZedGraph.AlignV alignV)
        {
            this._x = x;
            this._y = y;
            this._width = 0.0;
            this._height = 0.0;
            this._coordinateFrame = coordType;
            this._alignH = alignH;
            this._alignV = alignV;
        }

        public Location(double x, double y, double width, double height, CoordType coordType, ZedGraph.AlignH alignH, ZedGraph.AlignV alignV) : this(x, y, coordType, alignH, alignV)
        {
            this._width = width;
            this._height = height;
        }

        public Location Clone() => 
            new Location(this);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("alignV", this._alignV);
            info.AddValue("alignH", this._alignH);
            info.AddValue("x", this._x);
            info.AddValue("y", this._y);
            info.AddValue("width", this._width);
            info.AddValue("height", this._height);
            info.AddValue("coordinateFrame", this._coordinateFrame);
        }

        object ICloneable.Clone() => 
            this.Clone();

        public PointF Transform(PaneBase pane) => 
            Transform(pane, this._x, this._y, this._coordinateFrame);

        public static PointF Transform(PaneBase pane, double x, double y, CoordType coord) => 
            pane.TransformCoord(x, y, coord);

        public PointF TransformBottomRight(PaneBase pane) => 
            Transform(pane, this.X2, this.Y2, this._coordinateFrame);

        public RectangleF TransformRect(PaneBase pane)
        {
            PointF tf = this.TransformTopLeft(pane);
            PointF tf2 = this.TransformBottomRight(pane);
            return new RectangleF(tf.X, tf.Y, Math.Abs((float) (tf2.X - tf.X)), Math.Abs((float) (tf2.Y - tf.Y)));
        }

        public PointF TransformTopLeft(PaneBase pane) => 
            this.Transform(pane);

        public unsafe PointF TransformTopLeft(PaneBase pane, float width, float height)
        {
            PointF tf = this.Transform(pane);
            if (this._alignH == ZedGraph.AlignH.Right)
            {
                PointF* tfPtr1 = &tf;
                tfPtr1.X -= width;
            }
            else if (this._alignH == ZedGraph.AlignH.Center)
            {
                PointF* tfPtr2 = &tf;
                tfPtr2.X -= width / 2f;
            }
            if (this._alignV == ZedGraph.AlignV.Bottom)
            {
                PointF* tfPtr3 = &tf;
                tfPtr3.Y -= height;
            }
            else if (this._alignV == ZedGraph.AlignV.Center)
            {
                PointF* tfPtr4 = &tf;
                tfPtr4.Y -= height / 2f;
            }
            return tf;
        }

        public ZedGraph.AlignH AlignH
        {
            get => 
                this._alignH;
            set => 
                this._alignH = value;
        }

        public ZedGraph.AlignV AlignV
        {
            get => 
                this._alignV;
            set => 
                this._alignV = value;
        }

        public CoordType CoordinateFrame
        {
            get => 
                this._coordinateFrame;
            set => 
                this._coordinateFrame = value;
        }

        public double X
        {
            get => 
                this._x;
            set => 
                this._x = value;
        }

        public double Y
        {
            get => 
                this._y;
            set => 
                this._y = value;
        }

        public double X1
        {
            get => 
                this._x;
            set => 
                this._x = value;
        }

        public double Y1
        {
            get => 
                this._y;
            set => 
                this._y = value;
        }

        public double Width
        {
            get => 
                this._width;
            set => 
                this._width = value;
        }

        public double Height
        {
            get => 
                this._height;
            set => 
                this._height = value;
        }

        public double X2 =>
            this._x + this._width;

        public double Y2 =>
            this._y + this._height;

        public RectangleF Rect
        {
            get => 
                new RectangleF((float) this._x, (float) this._y, (float) this._width, (float) this._height);
            set
            {
                this._x = value.X;
                this._y = value.Y;
                this._width = value.Width;
                this._height = value.Height;
            }
        }

        public PointF TopLeft
        {
            get => 
                new PointF((float) this._x, (float) this._y);
            set
            {
                this._x = value.X;
                this._y = value.Y;
            }
        }

        public PointF BottomRight =>
            new PointF((float) this.X2, (float) this.Y2);
    }
}

