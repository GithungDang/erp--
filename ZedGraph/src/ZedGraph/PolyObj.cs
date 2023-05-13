namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class PolyObj : BoxObj, ICloneable, ISerializable
    {
        public const int schema3 = 11;
        private PointD[] _points;
        private bool _isClosedFigure;

        public PolyObj() : this(new PointD[0])
        {
        }

        public PolyObj(PointD[] points) : base(0.0, 0.0, 1.0, 1.0)
        {
            this._isClosedFigure = true;
            this._points = points;
        }

        public PolyObj(PolyObj rhs) : base(rhs)
        {
            this._isClosedFigure = true;
            rhs._points = (PointD[]) this._points.Clone();
            rhs._isClosedFigure = this._isClosedFigure;
        }

        protected PolyObj(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this._isClosedFigure = true;
            info.GetInt32("schema3");
            this._points = (PointD[]) info.GetValue("points", typeof(PointD[]));
            this._isClosedFigure = info.GetBoolean("isClosedFigure");
        }

        public PolyObj(PointD[] points, Color borderColor, Color fillColor) : base(0.0, 0.0, 1.0, 1.0, borderColor, fillColor)
        {
            this._isClosedFigure = true;
            this._points = points;
        }

        public PolyObj(PointD[] points, Color borderColor, Color fillColor1, Color fillColor2) : base(0.0, 0.0, 1.0, 1.0, borderColor, fillColor1, fillColor2)
        {
            this._isClosedFigure = true;
            this._points = points;
        }

        public PolyObj Clone() => 
            new PolyObj(this);

        public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
        {
            if ((this._points != null) && (this._points.Length > 1))
            {
                using (GraphicsPath path = this.MakePath(pane))
                {
                    if (base._fill.IsVisible)
                    {
                        using (Brush brush = base.Fill.MakeBrush(path.GetBounds()))
                        {
                            g.FillPath(brush, path);
                        }
                    }
                    if (base._border.IsVisible)
                    {
                        using (Pen pen = base._border.GetPen(pane, scaleFactor))
                        {
                            g.DrawPath(pen, path);
                        }
                    }
                }
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema3", 11);
            info.AddValue("points", this._points);
            info.AddValue("isClosedFigure", this._isClosedFigure);
        }

        internal GraphicsPath MakePath(PaneBase pane)
        {
            GraphicsPath path = new GraphicsPath();
            bool flag = true;
            PointF tf = new PointF();
            foreach (PointD td in this._points)
            {
                PointF tf2 = Location.Transform(pane, td.X + base._location.X, td.Y + base._location.Y, base._location.CoordinateFrame);
                if ((Math.Abs(tf2.X) < 100000f) && (Math.Abs(tf2.Y) < 100000f))
                {
                    if (flag)
                    {
                        flag = false;
                    }
                    else
                    {
                        path.AddLine(tf, tf2);
                    }
                    tf = tf2;
                }
            }
            if (this._isClosedFigure)
            {
                path.CloseFigure();
            }
            return path;
        }

        public override bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor)
        {
            if ((this._points == null) || (this._points.Length <= 1))
            {
                return false;
            }
            if (!base.PointInBox(pt, pane, g, scaleFactor))
            {
                return false;
            }
            using (GraphicsPath path = this.MakePath(pane))
            {
                return path.IsVisible(pt);
            }
        }

        object ICloneable.Clone() => 
            this.Clone();

        public PointD[] Points
        {
            get => 
                this._points;
            set => 
                this._points = value;
        }

        public bool IsClosedFigure
        {
            get => 
                this._isClosedFigure;
            set => 
                this._isClosedFigure = value;
        }
    }
}

