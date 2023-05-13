namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class LineObj : GraphObj, ICloneable, ISerializable
    {
        public const int schema2 = 11;
        protected LineBase _line;

        public LineObj() : this(LineBase.Default.Color, 0.0, 0.0, 1.0, 1.0)
        {
        }

        public LineObj(LineObj rhs) : base(rhs)
        {
            this._line = new LineBase(rhs._line);
        }

        protected LineObj(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._line = (LineBase) info.GetValue("line", typeof(LineBase));
        }

        public LineObj(double x1, double y1, double x2, double y2) : this(LineBase.Default.Color, x1, y1, x2, y2)
        {
        }

        public LineObj(Color color, double x1, double y1, double x2, double y2) : base(x1, y1, x2 - x1, y2 - y1)
        {
            this._line = new LineBase(color);
            base.Location.AlignH = AlignH.Left;
            base.Location.AlignV = AlignV.Top;
        }

        public LineObj Clone() => 
            new LineObj(this);

        public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
        {
            PointF tf = base.Location.TransformTopLeft(pane);
            PointF tf2 = base.Location.TransformBottomRight(pane);
            if ((tf.X > -10000f) && ((tf.X < 100000f) && ((tf.Y > -100000f) && ((tf.Y < 100000f) && ((tf2.X > -10000f) && ((tf2.X < 100000f) && ((tf2.Y > -100000f) && (tf2.Y < 100000f))))))))
            {
                double y = tf2.Y - tf.Y;
                double x = tf2.X - tf.X;
                float angle = (((float) Math.Atan2(y, x)) * 180f) / 3.141593f;
                float num4 = (float) Math.Sqrt((x * x) + (y * y));
                Matrix transform = g.Transform;
                g.TranslateTransform(tf.X, tf.Y);
                g.RotateTransform(angle);
                using (Pen pen = this._line.GetPen(pane, scaleFactor))
                {
                    g.DrawLine(pen, 0f, 0f, num4, 0f);
                }
                g.Transform = transform;
            }
        }

        public override void GetCoords(PaneBase pane, Graphics g, float scaleFactor, out string shape, out string coords)
        {
            RectangleF ef = base._location.TransformRect(pane);
            Matrix matrix = new Matrix();
            if (ef.Right == 0f)
            {
                ef.Width = 1f;
            }
            matrix.Rotate((float) Math.Atan((double) ((ef.Top - ef.Bottom) / (ef.Left - ef.Right))), MatrixOrder.Prepend);
            matrix.Translate(-ef.Left, -ef.Top, MatrixOrder.Prepend);
            PointF[] pts = new PointF[] { new PointF(0f, 3f), new PointF(ef.Width, 3f), new PointF(ef.Width, -3f), new PointF(0f, -3f) };
            matrix.TransformPoints(pts);
            shape = "poly";
            coords = $"{pts[0].X:f0},{pts[0].Y:f0},{pts[1].X:f0},{pts[1].Y:f0},{pts[2].X:f0},{pts[2].Y:f0},{pts[3].X:f0},{pts[3].Y:f0},";
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 11);
            info.AddValue("line", this._line);
        }

        public override bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor)
        {
            bool flag;
            if (!base.PointInBox(pt, pane, g, scaleFactor))
            {
                return false;
            }
            PointF tf = base._location.TransformTopLeft(pane);
            PointF tf2 = base._location.TransformBottomRight(pane);
            using (Pen pen = new Pen(Color.Black, ((float) GraphPane.Default.NearestTol) * 2f))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddLine(tf, tf2);
                    flag = path.IsOutlineVisible(pt, pen);
                }
            }
            return flag;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public LineBase Line
        {
            get => 
                this._line;
            set => 
                this._line = value;
        }
    }
}

