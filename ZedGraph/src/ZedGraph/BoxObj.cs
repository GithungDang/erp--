namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class BoxObj : GraphObj, ICloneable, ISerializable
    {
        public const int schema2 = 10;
        protected ZedGraph.Fill _fill;
        protected ZedGraph.Border _border;

        public BoxObj() : this(0.0, 0.0, 1.0, 1.0)
        {
        }

        public BoxObj(BoxObj rhs) : base(rhs)
        {
            this.Border = rhs.Border.Clone();
            this.Fill = rhs.Fill.Clone();
        }

        protected BoxObj(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._fill = (ZedGraph.Fill) info.GetValue("fill", typeof(ZedGraph.Fill));
            this._border = (ZedGraph.Border) info.GetValue("border", typeof(ZedGraph.Border));
        }

        public BoxObj(double x, double y, double width, double height) : base(x, y, width, height)
        {
            this.Border = new ZedGraph.Border(Default.BorderColor, Default.PenWidth);
            this.Fill = new ZedGraph.Fill(Default.FillColor);
        }

        public BoxObj(double x, double y, double width, double height, Color borderColor, Color fillColor) : base(x, y, width, height)
        {
            this.Border = new ZedGraph.Border(borderColor, Default.PenWidth);
            this.Fill = new ZedGraph.Fill(fillColor);
        }

        public BoxObj(double x, double y, double width, double height, Color borderColor, Color fillColor1, Color fillColor2) : base(x, y, width, height)
        {
            this.Border = new ZedGraph.Border(borderColor, Default.PenWidth);
            this.Fill = new ZedGraph.Fill(fillColor1, fillColor2);
        }

        public BoxObj Clone() => 
            new BoxObj(this);

        public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
        {
            RectangleF rect = base.Location.TransformRect(pane);
            RectangleF ef2 = pane.Rect;
            ef2.Inflate(20f, 20f);
            rect.Intersect(ef2);
            if ((Math.Abs(rect.Left) < 100000f) && ((Math.Abs(rect.Top) < 100000f) && ((Math.Abs(rect.Right) < 100000f) && (Math.Abs(rect.Bottom) < 100000f))))
            {
                this._fill.Draw(g, rect);
                this._border.Draw(g, pane, scaleFactor, rect);
            }
        }

        public override void GetCoords(PaneBase pane, Graphics g, float scaleFactor, out string shape, out string coords)
        {
            RectangleF ef = base._location.TransformRect(pane);
            shape = "rect";
            coords = $"{ef.Left:f0},{ef.Top:f0},{ef.Right:f0},{ef.Bottom:f0}";
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
            info.AddValue("fill", this._fill);
            info.AddValue("border", this._border);
        }

        public override bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor) => 
            base.PointInBox(pt, pane, g, scaleFactor) ? base._location.TransformRect(pane).Contains(pt) : false;

        object ICloneable.Clone() => 
            this.Clone();

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

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float PenWidth;
            public static Color BorderColor;
            public static Color FillColor;
            static Default()
            {
                PenWidth = 1f;
                BorderColor = Color.Black;
                FillColor = Color.White;
            }
        }
    }
}

