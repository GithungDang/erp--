namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class ImageObj : GraphObj, ICloneable, ISerializable
    {
        public const int schema2 = 10;
        private System.Drawing.Image _image;
        private bool _isScaled;

        public ImageObj() : this(null, (double) 0.0, (double) 0.0, (double) 1.0, (double) 1.0)
        {
        }

        public ImageObj(ImageObj rhs) : base(rhs)
        {
            this._image = rhs._image;
            this._isScaled = rhs.IsScaled;
        }

        public ImageObj(System.Drawing.Image image, RectangleF rect) : this(image, (double) rect.X, (double) rect.Y, (double) rect.Width, (double) rect.Height)
        {
        }

        protected ImageObj(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._image = (System.Drawing.Image) info.GetValue("image", typeof(System.Drawing.Image));
            this._isScaled = info.GetBoolean("isScaled");
        }

        public ImageObj(System.Drawing.Image image, double left, double top, double width, double height) : base(left, top, width, height)
        {
            this._image = image;
            this._isScaled = Default.IsScaled;
        }

        public ImageObj(System.Drawing.Image image, RectangleF rect, CoordType coordType, AlignH alignH, AlignV alignV) : base((double) rect.X, (double) rect.Y, (double) rect.Width, (double) rect.Height, coordType, alignH, alignV)
        {
            this._image = image;
            this._isScaled = Default.IsScaled;
        }

        public ImageObj Clone() => 
            new ImageObj(this);

        public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
        {
            if (this._image != null)
            {
                RectangleF rect = base._location.TransformRect(pane);
                if (this._isScaled)
                {
                    g.DrawImage(this._image, rect);
                }
                else
                {
                    Region clip = g.Clip;
                    g.SetClip(rect);
                    g.DrawImageUnscaled(this._image, Rectangle.Round(rect));
                    g.SetClip(clip, CombineMode.Replace);
                }
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
            info.AddValue("image", this._image);
            info.AddValue("isScaled", this._isScaled);
        }

        public override bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor) => 
            (this._image != null) && (base.PointInBox(pt, pane, g, scaleFactor) ? base._location.TransformRect(pane).Contains(pt) : false);

        object ICloneable.Clone() => 
            this.Clone();

        public System.Drawing.Image Image
        {
            get => 
                this._image;
            set => 
                this._image = value;
        }

        public bool IsScaled
        {
            get => 
                this._isScaled;
            set => 
                this._isScaled = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static bool IsScaled;
            static Default()
            {
                IsScaled = true;
            }
        }
    }
}

