namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class TextObj : GraphObj, ICloneable, ISerializable
    {
        public const int schema2 = 10;
        private string _text;
        private ZedGraph.FontSpec _fontSpec;
        private SizeF _layoutArea;

        public TextObj() : base((double) 0.0, (double) 0.0)
        {
            this.Init("");
        }

        public TextObj(TextObj rhs) : base(rhs)
        {
            this._text = rhs.Text;
            this._fontSpec = new ZedGraph.FontSpec(rhs.FontSpec);
        }

        protected TextObj(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._text = info.GetString("text");
            this._fontSpec = (ZedGraph.FontSpec) info.GetValue("fontSpec", typeof(ZedGraph.FontSpec));
            this._layoutArea = (SizeF) info.GetValue("layoutArea", typeof(SizeF));
        }

        public TextObj(string text, double x, double y) : base(x, y)
        {
            this.Init(text);
        }

        public TextObj(string text, double x, double y, CoordType coordType) : base(x, y, coordType)
        {
            this.Init(text);
        }

        public TextObj(string text, double x, double y, CoordType coordType, AlignH alignH, AlignV alignV) : base(x, y, coordType, alignH, alignV)
        {
            this.Init(text);
        }

        public TextObj Clone() => 
            new TextObj(this);

        public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
        {
            PointF tf = base._location.Transform(pane);
            if ((tf.X > -100000f) && ((tf.X < 100000f) && ((tf.Y > -100000f) && (tf.Y < 100000f))))
            {
                this.FontSpec.Draw(g, pane, this._text, tf.X, tf.Y, base._location.AlignH, base._location.AlignV, scaleFactor, this._layoutArea);
            }
        }

        public override void GetCoords(PaneBase pane, Graphics g, float scaleFactor, out string shape, out string coords)
        {
            PointF tf = base._location.Transform(pane);
            SizeF layoutArea = new SizeF();
            PointF[] tfArray = this._fontSpec.GetBox(g, this._text, tf.X, tf.Y, base._location.AlignH, base._location.AlignV, scaleFactor, layoutArea);
            shape = "poly";
            coords = $"{tfArray[0].X:f0},{tfArray[0].Y:f0},{tfArray[1].X:f0},{tfArray[1].Y:f0},{tfArray[2].X:f0},{tfArray[2].Y:f0},{tfArray[3].X:f0},{tfArray[3].Y:f0},";
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 10);
            info.AddValue("text", this._text);
            info.AddValue("fontSpec", this._fontSpec);
            info.AddValue("layoutArea", this._layoutArea);
        }

        private void Init(string text)
        {
            if (text != null)
            {
                this._text = text;
            }
            else
            {
                text = "Text";
            }
            this._fontSpec = new ZedGraph.FontSpec(Default.FontFamily, Default.FontSize, Default.FontColor, Default.FontBold, Default.FontItalic, Default.FontUnderline);
            this._layoutArea = new SizeF(0f, 0f);
        }

        public override bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor)
        {
            if (!base.PointInBox(pt, pane, g, scaleFactor))
            {
                return false;
            }
            PointF tf = base._location.Transform(pane);
            return this._fontSpec.PointInBox(pt, g, this._text, tf.X, tf.Y, base._location.AlignH, base._location.AlignV, scaleFactor, this.LayoutArea);
        }

        object ICloneable.Clone() => 
            this.Clone();

        public SizeF LayoutArea
        {
            get => 
                this._layoutArea;
            set => 
                this._layoutArea = value;
        }

        public string Text
        {
            get => 
                this._text;
            set => 
                this._text = value;
        }

        public ZedGraph.FontSpec FontSpec
        {
            get => 
                this._fontSpec;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Uninitialized FontSpec in TextObj");
                }
                this._fontSpec = value;
            }
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static string FontFamily;
            public static float FontSize;
            public static Color FontColor;
            public static bool FontBold;
            public static bool FontUnderline;
            public static bool FontItalic;
            static Default()
            {
                FontFamily = "Arial";
                FontSize = 12f;
                FontColor = Color.Black;
                FontBold = false;
                FontUnderline = false;
                FontItalic = false;
            }
        }
    }
}

