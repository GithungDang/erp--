namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class Label : ICloneable, ISerializable
    {
        public const int schema = 10;
        internal string _text;
        internal ZedGraph.FontSpec _fontSpec;
        internal bool _isVisible;

        public Label(Label rhs)
        {
            this._text = (rhs._text == null) ? string.Empty : ((string) rhs._text.Clone());
            this._isVisible = rhs._isVisible;
            if (rhs._fontSpec != null)
            {
                this._fontSpec = rhs._fontSpec.Clone();
            }
            else
            {
                this._fontSpec = null;
            }
        }

        protected Label(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._text = info.GetString("text");
            this._isVisible = info.GetBoolean("isVisible");
            this._fontSpec = (ZedGraph.FontSpec) info.GetValue("fontSpec", typeof(ZedGraph.FontSpec));
        }

        public Label(string text, ZedGraph.FontSpec fontSpec)
        {
            this._text = (text == null) ? string.Empty : text;
            this._fontSpec = fontSpec;
            this._isVisible = true;
        }

        public Label(string text, string fontFamily, float fontSize, Color color, bool isBold, bool isItalic, bool isUnderline)
        {
            this._text = (text == null) ? string.Empty : text;
            this._fontSpec = new ZedGraph.FontSpec(fontFamily, fontSize, color, isBold, isItalic, isUnderline);
            this._isVisible = true;
        }

        public Label Clone() => 
            new Label(this);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("text", this._text);
            info.AddValue("isVisible", this._isVisible);
            info.AddValue("fontSpec", this._fontSpec);
        }

        object ICloneable.Clone() => 
            this.Clone();

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
            set => 
                this._fontSpec = value;
        }

        public bool IsVisible
        {
            get => 
                this._isVisible;
            set => 
                this._isVisible = value;
        }
    }
}

