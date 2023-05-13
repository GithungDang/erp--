namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class Fill : ISerializable, ICloneable
    {
        public const int schema = 10;
        private System.Drawing.Color _color;
        private System.Drawing.Color _secondaryValueGradientColor;
        protected System.Drawing.Brush _brush;
        private FillType _type;
        private bool _isScaled;
        private ZedGraph.AlignH _alignH;
        private ZedGraph.AlignV _alignV;
        private double _rangeMin;
        private double _rangeMax;
        private double _rangeDefault;
        private Bitmap _gradientBM;
        private Image _image;
        private WrapMode _wrapMode;
        private System.Drawing.Color[] _colorList;
        private float[] _positionList;
        private float _angle;

        public Fill()
        {
            this.Init();
        }

        public Fill(System.Drawing.Color[] colors) : this(colors, (float) 0f)
        {
        }

        public Fill(System.Drawing.Brush brush) : this(brush, Default.IsScaled)
        {
        }

        public Fill(System.Drawing.Color color)
        {
            this.Init();
            this._color = color;
            if (color != System.Drawing.Color.Empty)
            {
                this._type = FillType.Solid;
            }
        }

        public Fill(ColorBlend blend) : this(blend, 0f)
        {
        }

        public Fill(Fill rhs)
        {
            this._color = rhs._color;
            this._secondaryValueGradientColor = rhs._color;
            this._brush = (rhs._brush == null) ? null : ((System.Drawing.Brush) rhs._brush.Clone());
            this._type = rhs._type;
            this._alignH = rhs.AlignH;
            this._alignV = rhs.AlignV;
            this._isScaled = rhs.IsScaled;
            this._rangeMin = rhs._rangeMin;
            this._rangeMax = rhs._rangeMax;
            this._rangeDefault = rhs._rangeDefault;
            this._gradientBM = null;
            this._colorList = (rhs._colorList == null) ? null : ((System.Drawing.Color[]) rhs._colorList.Clone());
            this._positionList = (rhs._positionList == null) ? null : ((float[]) rhs._positionList.Clone());
            this._image = (rhs._image == null) ? null : ((Image) rhs._image.Clone());
            this._angle = rhs._angle;
            this._wrapMode = rhs._wrapMode;
        }

        public Fill(System.Drawing.Color color1, System.Drawing.Color color2) : this(color1, color2, (float) 0f)
        {
        }

        public Fill(ColorBlend blend, float angle)
        {
            this.Init();
            this._type = FillType.Brush;
            this.CreateBrushFromBlend(blend, angle);
        }

        public Fill(System.Drawing.Color[] colors, float angle)
        {
            this.Init();
            this._color = colors[colors.Length - 1];
            ColorBlend blend = new ColorBlend {
                Colors = colors,
                Positions = new float[colors.Length]
            };
            blend.Positions[0] = 0f;
            for (int i = 1; i < colors.Length; i++)
            {
                blend.Positions[i] = ((float) i) / ((float) (colors.Length - 1));
            }
            this._type = FillType.Brush;
            this.CreateBrushFromBlend(blend, angle);
        }

        public Fill(System.Drawing.Color[] colors, float[] positions) : this(colors, positions, 0f)
        {
        }

        public Fill(System.Drawing.Brush brush, bool isScaled)
        {
            this.Init();
            this._isScaled = isScaled;
            this._color = System.Drawing.Color.White;
            this._brush = (System.Drawing.Brush) brush.Clone();
            this._type = FillType.Brush;
        }

        public Fill(Image image, WrapMode wrapMode)
        {
            this.Init();
            this._color = System.Drawing.Color.White;
            this._brush = new TextureBrush(image, wrapMode);
            this._type = FillType.Brush;
            this._image = image;
            this._wrapMode = wrapMode;
        }

        protected Fill(SerializationInfo info, StreamingContext context)
        {
            this.Init();
            info.GetInt32("schema");
            this._color = (System.Drawing.Color) info.GetValue("color", typeof(System.Drawing.Color));
            this._secondaryValueGradientColor = (System.Drawing.Color) info.GetValue("secondaryValueGradientColor", typeof(System.Drawing.Color));
            this._type = (FillType) info.GetValue("type", typeof(FillType));
            this._isScaled = info.GetBoolean("isScaled");
            this._alignH = (ZedGraph.AlignH) info.GetValue("alignH", typeof(ZedGraph.AlignH));
            this._alignV = (ZedGraph.AlignV) info.GetValue("alignV", typeof(ZedGraph.AlignV));
            this._rangeMin = info.GetDouble("rangeMin");
            this._rangeMax = info.GetDouble("rangeMax");
            this._colorList = (System.Drawing.Color[]) info.GetValue("colorList", typeof(System.Drawing.Color[]));
            this._positionList = (float[]) info.GetValue("positionList", typeof(float[]));
            this._angle = info.GetSingle("angle");
            this._image = (Image) info.GetValue("image", typeof(Image));
            this._wrapMode = (WrapMode) info.GetValue("wrapMode", typeof(WrapMode));
            if ((this._colorList != null) && (this._positionList != null))
            {
                ColorBlend blend = new ColorBlend {
                    Colors = this._colorList,
                    Positions = this._positionList
                };
                this.CreateBrushFromBlend(blend, this._angle);
            }
            else if (this._image != null)
            {
                this._brush = new TextureBrush(this._image, this._wrapMode);
            }
            this._rangeDefault = info.GetDouble("rangeDefault");
        }

        public Fill(System.Drawing.Color color, System.Drawing.Brush brush, FillType type)
        {
            this.Init();
            this._color = color;
            this._brush = brush;
            this._type = type;
        }

        public Fill(System.Drawing.Color color1, System.Drawing.Color color2, System.Drawing.Color color3) : this(color1, color2, color3, 0f)
        {
        }

        public Fill(System.Drawing.Color[] colors, float[] positions, float angle)
        {
            this.Init();
            this._color = colors[colors.Length - 1];
            ColorBlend blend = new ColorBlend {
                Colors = colors,
                Positions = positions
            };
            this._type = FillType.Brush;
            this.CreateBrushFromBlend(blend, angle);
        }

        public Fill(System.Drawing.Brush brush, ZedGraph.AlignH alignH, ZedGraph.AlignV alignV)
        {
            this.Init();
            this._alignH = alignH;
            this._alignV = alignV;
            this._isScaled = false;
            this._color = System.Drawing.Color.White;
            this._brush = (System.Drawing.Brush) brush.Clone();
            this._type = FillType.Brush;
        }

        public Fill(System.Drawing.Color color1, System.Drawing.Color color2, float angle)
        {
            this.Init();
            this._color = color2;
            ColorBlend blend = new ColorBlend(2);
            blend.Colors[0] = color1;
            blend.Colors[1] = color2;
            blend.Positions[0] = 0f;
            blend.Positions[1] = 1f;
            this._type = FillType.Brush;
            this.CreateBrushFromBlend(blend, angle);
        }

        public Fill(System.Drawing.Color color1, System.Drawing.Color color2, System.Drawing.Color color3, float angle)
        {
            this.Init();
            this._color = color3;
            ColorBlend blend = new ColorBlend(3);
            blend.Colors[0] = color1;
            blend.Colors[1] = color2;
            blend.Colors[2] = color3;
            blend.Positions[0] = 0f;
            blend.Positions[1] = 0.5f;
            blend.Positions[2] = 1f;
            this._type = FillType.Brush;
            this.CreateBrushFromBlend(blend, angle);
        }

        public Fill Clone() => 
            new Fill(this);

        private void CreateBrushFromBlend(ColorBlend blend, float angle)
        {
            this._angle = angle;
            this._colorList = (System.Drawing.Color[]) blend.Colors.Clone();
            this._positionList = (float[]) blend.Positions.Clone();
            this._brush = new LinearGradientBrush(new Rectangle(0, 0, 100, 100), System.Drawing.Color.Red, System.Drawing.Color.White, angle);
            ((LinearGradientBrush) this._brush).InterpolationColors = blend;
        }

        public void Draw(Graphics g, RectangleF rect)
        {
            this.Draw(g, rect, null);
        }

        public void Draw(Graphics g, RectangleF rect, PointPair pt)
        {
            if (this.IsVisible)
            {
                using (System.Drawing.Brush brush = this.MakeBrush(rect, pt))
                {
                    g.FillRectangle(brush, rect);
                }
            }
        }

        internal System.Drawing.Color GetGradientColor(double val)
        {
            if (double.IsInfinity(val) || (double.IsNaN(val) || (val == double.MaxValue)))
            {
                val = this._rangeDefault;
            }
            double num = (((this._rangeMax - this._rangeMin) < 1E-20) || (val == double.MaxValue)) ? 0.5 : ((val - this._rangeMin) / (this._rangeMax - this._rangeMin));
            if (num < 0.0)
            {
                num = 0.0;
            }
            else if (num > 1.0)
            {
                num = 1.0;
            }
            if (this._gradientBM == null)
            {
                RectangleF rect = new RectangleF(0f, 0f, 100f, 1f);
                this._gradientBM = new Bitmap(100, 1);
                Graphics.FromImage(this._gradientBM).FillRectangle(this.ScaleBrush(rect, this._brush, true), rect);
            }
            return this._gradientBM.GetPixel((int) (99.9 * num), 0);
        }

        internal System.Drawing.Color GetGradientColor(PointPair dataValue)
        {
            double val = (dataValue != null) ? ((this._type != FillType.GradientByColorValue) ? ((this._type != FillType.GradientByZ) ? ((this._type != FillType.GradientByY) ? dataValue.X : dataValue.Y) : dataValue.Z) : dataValue.ColorValue) : this._rangeDefault;
            return this.GetGradientColor(val);
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("color", this._color);
            info.AddValue("secondaryValueGradientColor", this._secondaryValueGradientColor);
            info.AddValue("type", this._type);
            info.AddValue("isScaled", this._isScaled);
            info.AddValue("alignH", this._alignH);
            info.AddValue("alignV", this._alignV);
            info.AddValue("rangeMin", this._rangeMin);
            info.AddValue("rangeMax", this._rangeMax);
            info.AddValue("colorList", this._colorList);
            info.AddValue("positionList", this._positionList);
            info.AddValue("angle", this._angle);
            info.AddValue("image", this._image);
            info.AddValue("wrapMode", this._wrapMode);
            info.AddValue("rangeDefault", this._rangeDefault);
        }

        private void Init()
        {
            this._color = System.Drawing.Color.White;
            this._secondaryValueGradientColor = System.Drawing.Color.White;
            this._brush = null;
            this._type = FillType.None;
            this._isScaled = Default.IsScaled;
            this._alignH = Default.AlignH;
            this._alignV = Default.AlignV;
            this._rangeMin = 0.0;
            this._rangeMax = 1.0;
            this._rangeDefault = double.MaxValue;
            this._gradientBM = null;
            this._colorList = null;
            this._positionList = null;
            this._angle = 0f;
            this._image = null;
            this._wrapMode = WrapMode.Tile;
        }

        public System.Drawing.Brush MakeBrush(RectangleF rect) => 
            this.MakeBrush(rect, null);

        public System.Drawing.Brush MakeBrush(RectangleF rect, PointPair dataValue)
        {
            if (!this.IsVisible || (this._color.IsEmpty && (this._brush == null)))
            {
                return new SolidBrush(System.Drawing.Color.White);
            }
            if (rect.Height < 1f)
            {
                rect.Height = 1f;
            }
            if (rect.Width < 1f)
            {
                rect.Width = 1f;
            }
            return ((this._type != FillType.Brush) ? (!this.IsGradientValueType ? new SolidBrush(this._color) : ((dataValue == null) ? ((this._rangeDefault == double.MaxValue) ? this.ScaleBrush(rect, this._brush, true) : (this._secondaryValueGradientColor.IsEmpty ? new SolidBrush(this.GetGradientColor(this._rangeDefault)) : new Fill(this._secondaryValueGradientColor, this.GetGradientColor(this._rangeDefault), this._angle).MakeBrush(rect))) : (this._secondaryValueGradientColor.IsEmpty ? new SolidBrush(this.GetGradientColor(dataValue)) : new Fill(this._secondaryValueGradientColor, this.GetGradientColor(dataValue), this._angle).MakeBrush(rect)))) : this.ScaleBrush(rect, this._brush, this._isScaled));
        }

        private System.Drawing.Brush ScaleBrush(RectangleF rect, System.Drawing.Brush brush, bool isScaled)
        {
            if (brush == null)
            {
                return new LinearGradientBrush(rect, System.Drawing.Color.White, this._color, 0f);
            }
            if (brush is SolidBrush)
            {
                return (System.Drawing.Brush) brush.Clone();
            }
            if (brush is LinearGradientBrush)
            {
                LinearGradientBrush brush2 = (LinearGradientBrush) brush.Clone();
                if (isScaled)
                {
                    brush2.ScaleTransform(rect.Width / brush2.Rectangle.Width, rect.Height / brush2.Rectangle.Height, MatrixOrder.Append);
                    brush2.TranslateTransform(rect.Left - brush2.Rectangle.Left, rect.Top - brush2.Rectangle.Top, MatrixOrder.Append);
                }
                else
                {
                    float dx = 0f;
                    float dy = 0f;
                    switch (this._alignH)
                    {
                        case ZedGraph.AlignH.Left:
                            dx = rect.Left - brush2.Rectangle.Left;
                            break;

                        case ZedGraph.AlignH.Center:
                            dx = (rect.Left + (rect.Width / 2f)) - brush2.Rectangle.Left;
                            break;

                        case ZedGraph.AlignH.Right:
                            dx = (rect.Left + rect.Width) - brush2.Rectangle.Left;
                            break;

                        default:
                            break;
                    }
                    switch (this._alignV)
                    {
                        case ZedGraph.AlignV.Top:
                            dy = rect.Top - brush2.Rectangle.Top;
                            break;

                        case ZedGraph.AlignV.Center:
                            dy = (rect.Top + (rect.Height / 2f)) - brush2.Rectangle.Top;
                            break;

                        case ZedGraph.AlignV.Bottom:
                            dy = (rect.Top + rect.Height) - brush2.Rectangle.Top;
                            break;

                        default:
                            break;
                    }
                    brush2.TranslateTransform(dx, dy, MatrixOrder.Append);
                }
                return brush2;
            }
            if (!(brush is TextureBrush))
            {
                return (System.Drawing.Brush) brush.Clone();
            }
            TextureBrush brush3 = (TextureBrush) brush.Clone();
            if (isScaled)
            {
                brush3.ScaleTransform(rect.Width / ((float) brush3.Image.Width), rect.Height / ((float) brush3.Image.Height), MatrixOrder.Append);
                brush3.TranslateTransform(rect.Left, rect.Top, MatrixOrder.Append);
            }
            else
            {
                float dx = 0f;
                float dy = 0f;
                switch (this._alignH)
                {
                    case ZedGraph.AlignH.Left:
                        dx = rect.Left;
                        break;

                    case ZedGraph.AlignH.Center:
                        dx = rect.Left + (rect.Width / 2f);
                        break;

                    case ZedGraph.AlignH.Right:
                        dx = rect.Left + rect.Width;
                        break;

                    default:
                        break;
                }
                switch (this._alignV)
                {
                    case ZedGraph.AlignV.Top:
                        dy = rect.Top;
                        break;

                    case ZedGraph.AlignV.Center:
                        dy = rect.Top + (rect.Height / 2f);
                        break;

                    case ZedGraph.AlignV.Bottom:
                        dy = rect.Top + rect.Height;
                        break;

                    default:
                        break;
                }
                brush3.TranslateTransform(dx, dy, MatrixOrder.Append);
            }
            return brush3;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public System.Drawing.Color Color
        {
            get => 
                this._color;
            set => 
                this._color = value;
        }

        public System.Drawing.Color SecondaryValueGradientColor
        {
            get => 
                this._secondaryValueGradientColor;
            set => 
                this._secondaryValueGradientColor = value;
        }

        public System.Drawing.Brush Brush
        {
            get => 
                this._brush;
            set => 
                this._brush = value;
        }

        public FillType Type
        {
            get => 
                this._type;
            set => 
                this._type = value;
        }

        public bool IsVisible
        {
            get => 
                this._type != FillType.None;
            set => 
                this._type = value ? ((this._type == FillType.None) ? FillType.Brush : this._type) : FillType.None;
        }

        public bool IsScaled
        {
            get => 
                this._isScaled;
            set => 
                this._isScaled = value;
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

        public bool IsGradientValueType =>
            (this._type == FillType.GradientByX) || ((this._type == FillType.GradientByY) || ((this._type == FillType.GradientByZ) || (this._type == FillType.GradientByColorValue)));

        public double RangeMin
        {
            get => 
                this._rangeMin;
            set => 
                this._rangeMin = value;
        }

        public double RangeMax
        {
            get => 
                this._rangeMax;
            set => 
                this._rangeMax = value;
        }

        public double RangeDefault
        {
            get => 
                this._rangeDefault;
            set => 
                this._rangeDefault = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static bool IsScaled;
            public static ZedGraph.AlignH AlignH;
            public static ZedGraph.AlignV AlignV;
            static Default()
            {
                IsScaled = true;
                AlignH = ZedGraph.AlignH.Center;
                AlignV = ZedGraph.AlignV.Center;
            }
        }
    }
}

