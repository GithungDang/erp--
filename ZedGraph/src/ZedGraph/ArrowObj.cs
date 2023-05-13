namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class ArrowObj : LineObj, ICloneable, ISerializable
    {
        public const int schema3 = 10;
        private float _size;
        private bool _isArrowHead;

        public ArrowObj() : this(LineBase.Default.Color, Default.Size, 0.0, 0.0, 1.0, 1.0)
        {
        }

        public ArrowObj(ArrowObj rhs) : base(rhs)
        {
            this._size = rhs.Size;
            this._isArrowHead = rhs.IsArrowHead;
        }

        protected ArrowObj(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema3");
            this._size = info.GetSingle("size");
            this._isArrowHead = info.GetBoolean("isArrowHead");
        }

        public ArrowObj(double x1, double y1, double x2, double y2) : this(LineBase.Default.Color, Default.Size, x1, y1, x2, y2)
        {
        }

        public ArrowObj(Color color, float size, double x1, double y1, double x2, double y2) : base(color, x1, y1, x2, y2)
        {
            this._isArrowHead = Default.IsArrowHead;
            this._size = size;
        }

        public ArrowObj Clone() => 
            new ArrowObj(this);

        public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
        {
            Matrix transform;
            PointF tf = base.Location.TransformTopLeft(pane);
            PointF tf2 = base.Location.TransformBottomRight(pane);
            if ((tf.X <= -10000f) || ((tf.X >= 100000f) || ((tf.Y <= -100000f) || ((tf.Y >= 100000f) || ((tf2.X <= -10000f) || ((tf2.X >= 100000f) || ((tf2.Y <= -100000f) || (tf2.Y >= 100000f))))))))
            {
                return;
            }
            else
            {
                float num = this._size * scaleFactor;
                double y = tf2.Y - tf.Y;
                double x = tf2.X - tf.X;
                float angle = (((float) Math.Atan2(y, x)) * 180f) / 3.141593f;
                float num5 = (float) Math.Sqrt((x * x) + (y * y));
                transform = g.Transform;
                g.TranslateTransform(tf.X, tf.Y);
                g.RotateTransform(angle);
                using (Pen pen = base._line.GetPen(pane, scaleFactor))
                {
                    if (!this._isArrowHead)
                    {
                        g.DrawLine(pen, 0f, 0f, num5, 0f);
                    }
                    else
                    {
                        g.DrawLine(pen, (float) 0f, (float) 0f, (float) ((num5 - num) + 1f), (float) 0f);
                        PointF[] points = new PointF[4];
                        float num6 = num / 3f;
                        points[0].X = num5;
                        points[0].Y = 0f;
                        points[1].X = num5 - num;
                        points[1].Y = num6;
                        points[2].X = num5 - num;
                        points[2].Y = -num6;
                        points[3] = points[0];
                        using (SolidBrush brush = new SolidBrush(base._line._color))
                        {
                            g.FillPolygon(brush, points);
                        }
                    }
                }
            }
            g.Transform = transform;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema3", 11);
            info.AddValue("size", this._size);
            info.AddValue("isArrowHead", this._isArrowHead);
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

        public bool IsArrowHead
        {
            get => 
                this._isArrowHead;
            set => 
                this._isArrowHead = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float Size;
            public static bool IsArrowHead;
            static Default()
            {
                Size = 12f;
                IsArrowHead = true;
            }
        }
    }
}

