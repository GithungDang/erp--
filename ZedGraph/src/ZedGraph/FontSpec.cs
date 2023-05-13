namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Text;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class FontSpec : ICloneable, ISerializable
    {
        public const int schema = 10;
        private Color _fontColor;
        private string _family;
        private bool _isBold;
        private bool _isItalic;
        private bool _isUnderline;
        private ZedGraph.Fill _fill;
        private ZedGraph.Border _border;
        private float _angle;
        private System.Drawing.StringAlignment _stringAlignment;
        private float _size;
        private Font _font;
        private bool _isAntiAlias;
        private bool _isDropShadow;
        private Color _dropShadowColor;
        private float _dropShadowAngle;
        private float _dropShadowOffset;
        private Font _superScriptFont;
        private float _scaledSize;

        public FontSpec() : this("Arial", 12f, Color.Black, false, false, false)
        {
        }

        public FontSpec(FontSpec rhs)
        {
            this._fontColor = rhs.FontColor;
            this._family = rhs.Family;
            this._isBold = rhs.IsBold;
            this._isItalic = rhs.IsItalic;
            this._isUnderline = rhs.IsUnderline;
            this._fill = rhs.Fill.Clone();
            this._border = rhs.Border.Clone();
            this._isAntiAlias = rhs._isAntiAlias;
            this._stringAlignment = rhs.StringAlignment;
            this._angle = rhs.Angle;
            this._size = rhs.Size;
            this._isDropShadow = rhs._isDropShadow;
            this._dropShadowColor = rhs._dropShadowColor;
            this._dropShadowAngle = rhs._dropShadowAngle;
            this._dropShadowOffset = rhs._dropShadowOffset;
            this._scaledSize = rhs._scaledSize;
            this.Remake(1f, this._size, ref this._scaledSize, ref this._font);
        }

        protected FontSpec(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._fontColor = (Color) info.GetValue("fontColor", typeof(Color));
            this._family = info.GetString("family");
            this._isBold = info.GetBoolean("isBold");
            this._isItalic = info.GetBoolean("isItalic");
            this._isUnderline = info.GetBoolean("isUnderline");
            this._isAntiAlias = info.GetBoolean("isAntiAlias");
            this._fill = (ZedGraph.Fill) info.GetValue("fill", typeof(ZedGraph.Fill));
            this._border = (ZedGraph.Border) info.GetValue("border", typeof(ZedGraph.Border));
            this._angle = info.GetSingle("angle");
            this._stringAlignment = (System.Drawing.StringAlignment) info.GetValue("stringAlignment", typeof(System.Drawing.StringAlignment));
            this._size = info.GetSingle("size");
            this._isDropShadow = info.GetBoolean("isDropShadow");
            this._dropShadowColor = (Color) info.GetValue("dropShadowColor", typeof(Color));
            this._dropShadowAngle = info.GetSingle("dropShadowAngle");
            this._dropShadowOffset = info.GetSingle("dropShadowOffset");
            this._scaledSize = -1f;
            this.Remake(1f, this._size, ref this._scaledSize, ref this._font);
        }

        public FontSpec(string family, float size, Color color, bool isBold, bool isItalic, bool isUnderline)
        {
            this.Init(family, size, color, isBold, isItalic, isUnderline, Default.FillColor, Default.FillBrush, Default.FillType);
        }

        public FontSpec(string family, float size, Color color, bool isBold, bool isItalic, bool isUnderline, Color fillColor, Brush fillBrush, FillType fillType)
        {
            this.Init(family, size, color, isBold, isItalic, isUnderline, fillColor, fillBrush, fillType);
        }

        public SizeF BoundingBox(Graphics g, string text, float scaleFactor)
        {
            SizeF layoutArea = new SizeF();
            return this.BoundingBox(g, text, scaleFactor, layoutArea);
        }

        public SizeF BoundingBox(Graphics g, string text, float scaleFactor, SizeF layoutArea)
        {
            SizeF ef = !layoutArea.IsEmpty ? this.MeasureString(g, text, scaleFactor, layoutArea) : this.MeasureString(g, text, scaleFactor);
            float num = (float) Math.Abs(Math.Cos((this._angle * 3.1415926535897931) / 180.0));
            float num2 = (float) Math.Abs(Math.Sin((this._angle * 3.1415926535897931) / 180.0));
            return new SizeF((ef.Width * num) + (ef.Height * num2), (ef.Width * num2) + (ef.Height * num));
        }

        public unsafe SizeF BoundingBoxTenPower(Graphics g, string text, float scaleFactor)
        {
            float scaledSize = this._scaledSize * Default.SuperSize;
            this.Remake(scaleFactor, this.Size * Default.SuperSize, ref scaledSize, ref this._superScriptFont);
            SizeF ef = this.MeasureString(g, "10", scaleFactor);
            SizeF ef2 = g.MeasureString(text, this._superScriptFont);
            if (this._isDropShadow)
            {
                SizeF* efPtr1 = &ef2;
                efPtr1.Width += (float) ((Math.Cos((double) this._dropShadowAngle) * this._dropShadowOffset) * this._superScriptFont.Height);
                SizeF* efPtr2 = &ef2;
                efPtr2.Height += (float) ((Math.Sin((double) this._dropShadowAngle) * this._dropShadowOffset) * this._superScriptFont.Height);
            }
            SizeF ef3 = new SizeF(ef.Width + ef2.Width, ef.Height + (ef2.Height * Default.SuperShift));
            float num2 = (float) Math.Abs(Math.Cos((this._angle * 3.1415926535897931) / 180.0));
            float num3 = (float) Math.Abs(Math.Sin((this._angle * 3.1415926535897931) / 180.0));
            return new SizeF((ef3.Width * num2) + (ef3.Height * num3), (ef3.Width * num3) + (ef3.Height * num2));
        }

        public FontSpec Clone() => 
            new FontSpec(this);

        public void Draw(Graphics g, PaneBase pane, string text, float x, float y, AlignH alignH, AlignV alignV, float scaleFactor)
        {
            SizeF layoutArea = new SizeF();
            this.Draw(g, pane, text, x, y, alignH, alignV, scaleFactor, layoutArea);
        }

        public void Draw(Graphics g, PaneBase pane, string text, float x, float y, AlignH alignH, AlignV alignV, float scaleFactor, SizeF layoutArea)
        {
            SmoothingMode smoothingMode = g.SmoothingMode;
            TextRenderingHint textRenderingHint = g.TextRenderingHint;
            if (this._isAntiAlias)
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
            }
            SizeF sizeF = !layoutArea.IsEmpty ? this.MeasureString(g, text, scaleFactor, layoutArea) : this.MeasureString(g, text, scaleFactor);
            Matrix transform = g.Transform;
            g.Transform = this.SetupMatrix(g.Transform, x, y, sizeF, alignH, alignV, this._angle);
            RectangleF rect = new RectangleF(-sizeF.Width / 2f, 0f, sizeF.Width, sizeF.Height);
            this._fill.Draw(g, rect);
            this._border.Draw(g, pane, scaleFactor, rect);
            StringFormat format = new StringFormat {
                Alignment = this._stringAlignment
            };
            if (this._isDropShadow)
            {
                RectangleF layoutRectangle = rect;
                layoutRectangle.Offset((float) ((Math.Cos((double) this._dropShadowAngle) * this._dropShadowOffset) * this._font.Height), (float) ((Math.Sin((double) this._dropShadowAngle) * this._dropShadowOffset) * this._font.Height));
                using (SolidBrush brush = new SolidBrush(this._dropShadowColor))
                {
                    g.DrawString(text, this._font, brush, layoutRectangle, format);
                }
            }
            using (SolidBrush brush2 = new SolidBrush(this._fontColor))
            {
                g.DrawString(text, this._font, brush2, rect, format);
            }
            g.Transform = transform;
            g.SmoothingMode = smoothingMode;
            g.TextRenderingHint = textRenderingHint;
        }

        public void DrawTenPower(Graphics g, GraphPane pane, string text, float x, float y, AlignH alignH, AlignV alignV, float scaleFactor)
        {
            SmoothingMode smoothingMode = g.SmoothingMode;
            TextRenderingHint textRenderingHint = g.TextRenderingHint;
            if (this._isAntiAlias)
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
            }
            this.Remake(scaleFactor, this.Size, ref this._scaledSize, ref this._font);
            float scaledSize = this._scaledSize * Default.SuperSize;
            this.Remake(scaleFactor, this.Size * Default.SuperSize, ref scaledSize, ref this._superScriptFont);
            SizeF ef = g.MeasureString("10", this._font);
            SizeF ef2 = g.MeasureString(text, this._superScriptFont);
            SizeF sizeF = new SizeF(ef.Width + ef2.Width, ef.Height + (ef2.Height * Default.SuperShift));
            float width = g.MeasureString("x", this._superScriptFont).Width;
            Matrix transform = g.Transform;
            g.Transform = this.SetupMatrix(g.Transform, x, y, sizeF, alignH, alignV, this._angle);
            StringFormat format = new StringFormat {
                Alignment = this._stringAlignment
            };
            RectangleF rect = new RectangleF(-sizeF.Width / 2f, 0f, sizeF.Width, sizeF.Height);
            this._fill.Draw(g, rect);
            this._border.Draw(g, pane, scaleFactor, rect);
            using (SolidBrush brush = new SolidBrush(this._fontColor))
            {
                g.DrawString("10", this._font, brush, (-sizeF.Width + ef.Width) / 2f, ef2.Height * Default.SuperShift, format);
                g.DrawString(text, this._superScriptFont, brush, ((sizeF.Width - ef2.Width) - width) / 2f, 0f, format);
            }
            g.Transform = transform;
            g.SmoothingMode = smoothingMode;
            g.TextRenderingHint = textRenderingHint;
        }

        public PointF[] GetBox(Graphics g, string text, float x, float y, AlignH alignH, AlignV alignV, float scaleFactor, SizeF layoutArea)
        {
            this.Remake(scaleFactor, this.Size, ref this._scaledSize, ref this._font);
            SizeF size = !layoutArea.IsEmpty ? g.MeasureString(text, this._font, layoutArea) : g.MeasureString(text, this._font);
            RectangleF ef2 = new RectangleF(new PointF(-size.Width / 2f, 0f), size);
            Matrix matrix = new Matrix();
            this.SetupMatrix(matrix, x, y, size, alignH, alignV, this._angle);
            PointF[] pts = new PointF[] { new PointF(ef2.Left, ef2.Top), new PointF(ef2.Right, ef2.Top), new PointF(ef2.Right, ef2.Bottom), new PointF(ef2.Left, ef2.Bottom) };
            matrix.TransformPoints(pts);
            return pts;
        }

        public Font GetFont(float scaleFactor)
        {
            this.Remake(scaleFactor, this.Size, ref this._scaledSize, ref this._font);
            return this._font;
        }

        public float GetHeight(float scaleFactor)
        {
            this.Remake(scaleFactor, this.Size, ref this._scaledSize, ref this._font);
            float height = this._font.Height;
            if (this._isDropShadow)
            {
                height += (float) ((Math.Sin((double) this._dropShadowAngle) * this._dropShadowOffset) * this._font.Height);
            }
            return height;
        }

        private Matrix GetMatrix(float x, float y, SizeF sizeF, AlignH alignH, AlignV alignV, float angle)
        {
            Matrix matrix = new Matrix();
            float num = (alignH != AlignH.Left) ? ((alignH != AlignH.Right) ? 0f : (-sizeF.Width / 2f)) : (sizeF.Width / 2f);
            float num2 = (alignV != AlignV.Center) ? ((alignV != AlignV.Bottom) ? 0f : -sizeF.Height) : (-sizeF.Height / 2f);
            matrix.Translate(-num, -num2, MatrixOrder.Prepend);
            if (angle != 0f)
            {
                matrix.Rotate(angle, MatrixOrder.Prepend);
            }
            matrix.Translate(-x, -y, MatrixOrder.Prepend);
            return matrix;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("fontColor", this._fontColor);
            info.AddValue("family", this._family);
            info.AddValue("isBold", this._isBold);
            info.AddValue("isItalic", this._isItalic);
            info.AddValue("isUnderline", this._isUnderline);
            info.AddValue("isAntiAlias", this._isAntiAlias);
            info.AddValue("fill", this._fill);
            info.AddValue("border", this._border);
            info.AddValue("angle", this._angle);
            info.AddValue("stringAlignment", this._stringAlignment);
            info.AddValue("size", this._size);
            info.AddValue("isDropShadow", this._isDropShadow);
            info.AddValue("dropShadowColor", this._dropShadowColor);
            info.AddValue("dropShadowAngle", this._dropShadowAngle);
            info.AddValue("dropShadowOffset", this._dropShadowOffset);
        }

        public float GetWidth(Graphics g, float scaleFactor)
        {
            this.Remake(scaleFactor, this.Size, ref this._scaledSize, ref this._font);
            return g.MeasureString("x", this._font).Width;
        }

        public float GetWidth(Graphics g, string text, float scaleFactor)
        {
            this.Remake(scaleFactor, this.Size, ref this._scaledSize, ref this._font);
            float width = g.MeasureString(text, this._font).Width;
            if (this._isDropShadow)
            {
                width += (float) ((Math.Cos((double) this._dropShadowAngle) * this._dropShadowOffset) * this._font.Height);
            }
            return width;
        }

        private void Init(string family, float size, Color color, bool isBold, bool isItalic, bool isUnderline, Color fillColor, Brush fillBrush, FillType fillType)
        {
            this._fontColor = color;
            this._family = family;
            this._isBold = isBold;
            this._isItalic = isItalic;
            this._isUnderline = isUnderline;
            this._size = size;
            this._angle = 0f;
            this._isAntiAlias = Default.IsAntiAlias;
            this._stringAlignment = Default.StringAlignment;
            this._isDropShadow = Default.IsDropShadow;
            this._dropShadowColor = Default.DropShadowColor;
            this._dropShadowAngle = Default.DropShadowAngle;
            this._dropShadowOffset = Default.DropShadowOffset;
            this._fill = new ZedGraph.Fill(fillColor, fillBrush, fillType);
            this._border = new ZedGraph.Border(true, Color.Black, 1f);
            this._scaledSize = -1f;
            this.Remake(1f, this._size, ref this._scaledSize, ref this._font);
        }

        public unsafe SizeF MeasureString(Graphics g, string text, float scaleFactor)
        {
            this.Remake(scaleFactor, this.Size, ref this._scaledSize, ref this._font);
            SizeF ef = g.MeasureString(text, this._font);
            if (this._isDropShadow)
            {
                SizeF* efPtr1 = &ef;
                efPtr1.Width += (float) ((Math.Cos((double) this._dropShadowAngle) * this._dropShadowOffset) * this._font.Height);
                SizeF* efPtr2 = &ef;
                efPtr2.Height += (float) ((Math.Sin((double) this._dropShadowAngle) * this._dropShadowOffset) * this._font.Height);
            }
            return ef;
        }

        public unsafe SizeF MeasureString(Graphics g, string text, float scaleFactor, SizeF layoutArea)
        {
            this.Remake(scaleFactor, this.Size, ref this._scaledSize, ref this._font);
            SizeF ef = g.MeasureString(text, this._font, layoutArea);
            if (this._isDropShadow)
            {
                SizeF* efPtr1 = &ef;
                efPtr1.Width += (float) ((Math.Cos((double) this._dropShadowAngle) * this._dropShadowOffset) * this._font.Height);
                SizeF* efPtr2 = &ef;
                efPtr2.Height += (float) ((Math.Sin((double) this._dropShadowAngle) * this._dropShadowOffset) * this._font.Height);
            }
            return ef;
        }

        public bool PointInBox(PointF pt, Graphics g, string text, float x, float y, AlignH alignH, AlignV alignV, float scaleFactor)
        {
            SizeF layoutArea = new SizeF();
            return this.PointInBox(pt, g, text, x, y, alignH, alignV, scaleFactor, layoutArea);
        }

        public bool PointInBox(PointF pt, Graphics g, string text, float x, float y, AlignH alignH, AlignV alignV, float scaleFactor, SizeF layoutArea)
        {
            this.Remake(scaleFactor, this.Size, ref this._scaledSize, ref this._font);
            SizeF size = !layoutArea.IsEmpty ? g.MeasureString(text, this._font, layoutArea) : g.MeasureString(text, this._font);
            RectangleF ef2 = new RectangleF(new PointF(-size.Width / 2f, 0f), size);
            Matrix matrix = this.GetMatrix(x, y, size, alignH, alignV, this._angle);
            PointF[] pts = new PointF[] { pt };
            matrix.TransformPoints(pts);
            return ef2.Contains(pts[0]);
        }

        private void Remake(float scaleFactor, float size, ref float scaledSize, ref Font font)
        {
            float num = size * scaleFactor;
            float num2 = (font == null) ? 0f : font.Size;
            if ((font == null) || ((Math.Abs((float) (num - num2)) > 0.1) || ((font.Name != this.Family) || ((font.Bold != this._isBold) || ((font.Italic != this._isItalic) || (font.Underline != this._isUnderline))))))
            {
                FontStyle regular = FontStyle.Regular;
                regular = ((this._isBold ? FontStyle.Bold : regular) | (this._isItalic ? FontStyle.Italic : regular)) | (this._isUnderline ? FontStyle.Underline : regular);
                scaledSize = size * scaleFactor;
                font = new Font(this._family, scaledSize, regular, GraphicsUnit.World);
            }
        }

        private Matrix SetupMatrix(Matrix matrix, float x, float y, SizeF sizeF, AlignH alignH, AlignV alignV, float angle)
        {
            matrix.Translate(x, y, MatrixOrder.Prepend);
            if (this._angle != 0f)
            {
                matrix.Rotate(-angle, MatrixOrder.Prepend);
            }
            float offsetX = (alignH != AlignH.Left) ? ((alignH != AlignH.Right) ? 0f : (-sizeF.Width / 2f)) : (sizeF.Width / 2f);
            float offsetY = (alignV != AlignV.Center) ? ((alignV != AlignV.Bottom) ? 0f : -sizeF.Height) : (-sizeF.Height / 2f);
            matrix.Translate(offsetX, offsetY, MatrixOrder.Prepend);
            return matrix;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public Color FontColor
        {
            get => 
                this._fontColor;
            set => 
                this._fontColor = value;
        }

        public string Family
        {
            get => 
                this._family;
            set
            {
                if (value != this._family)
                {
                    this._family = value;
                    this.Remake(this._scaledSize / this._size, this.Size, ref this._scaledSize, ref this._font);
                }
            }
        }

        public bool IsBold
        {
            get => 
                this._isBold;
            set
            {
                if (value != this._isBold)
                {
                    this._isBold = value;
                    this.Remake(this._scaledSize / this._size, this.Size, ref this._scaledSize, ref this._font);
                }
            }
        }

        public bool IsItalic
        {
            get => 
                this._isItalic;
            set
            {
                if (value != this._isItalic)
                {
                    this._isItalic = value;
                    this.Remake(this._scaledSize / this._size, this.Size, ref this._scaledSize, ref this._font);
                }
            }
        }

        public bool IsUnderline
        {
            get => 
                this._isUnderline;
            set
            {
                if (value != this._isUnderline)
                {
                    this._isUnderline = value;
                    this.Remake(this._scaledSize / this._size, this.Size, ref this._scaledSize, ref this._font);
                }
            }
        }

        public float Angle
        {
            get => 
                this._angle;
            set => 
                this._angle = value;
        }

        public System.Drawing.StringAlignment StringAlignment
        {
            get => 
                this._stringAlignment;
            set => 
                this._stringAlignment = value;
        }

        public float Size
        {
            get => 
                this._size;
            set
            {
                if (value != this._size)
                {
                    this.Remake((this._scaledSize / this._size) * value, this._size, ref this._scaledSize, ref this._font);
                    this._size = value;
                }
            }
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

        public bool IsAntiAlias
        {
            get => 
                this._isAntiAlias;
            set => 
                this._isAntiAlias = value;
        }

        public bool IsDropShadow
        {
            get => 
                this._isDropShadow;
            set => 
                this._isDropShadow = value;
        }

        public Color DropShadowColor
        {
            get => 
                this._dropShadowColor;
            set => 
                this._dropShadowColor = value;
        }

        public float DropShadowAngle
        {
            get => 
                this._dropShadowAngle;
            set => 
                this._dropShadowAngle = value;
        }

        public float DropShadowOffset
        {
            get => 
                this._dropShadowOffset;
            set => 
                this._dropShadowOffset = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float SuperSize;
            public static float SuperShift;
            public static Color FillColor;
            public static Brush FillBrush;
            public static ZedGraph.FillType FillType;
            public static System.Drawing.StringAlignment StringAlignment;
            public static bool IsDropShadow;
            public static bool IsAntiAlias;
            public static Color DropShadowColor;
            public static float DropShadowAngle;
            public static float DropShadowOffset;
            static Default()
            {
                SuperSize = 0.85f;
                SuperShift = 0.4f;
                FillColor = Color.White;
                FillBrush = null;
                FillType = ZedGraph.FillType.Solid;
                StringAlignment = System.Drawing.StringAlignment.Center;
                IsDropShadow = false;
                IsAntiAlias = false;
                DropShadowColor = Color.Black;
                DropShadowAngle = 45f;
                DropShadowOffset = 0.05f;
            }
        }
    }
}

