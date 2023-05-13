namespace ZedGraph
{
    using System;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class Link : ISerializable, ICloneable
    {
        public const int schema = 10;
        internal string _title;
        internal string _url;
        internal string _target;
        internal bool _isEnabled;
        public object Tag;

        public Link()
        {
            this._title = string.Empty;
            this._url = string.Empty;
            this._target = string.Empty;
            this.Tag = null;
            this._isEnabled = false;
        }

        public Link(Link rhs)
        {
            this._title = rhs._title;
            this._url = rhs._url;
            this._target = rhs._target;
            this._isEnabled = false;
            if (rhs.Tag is ICloneable)
            {
                this.Tag = ((ICloneable) rhs.Tag).Clone();
            }
            else
            {
                this.Tag = rhs.Tag;
            }
        }

        protected Link(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._title = info.GetString("title");
            this._url = info.GetString("url");
            this._target = info.GetString("target");
            this._isEnabled = info.GetBoolean("isEnabled");
            this.Tag = info.GetValue("Tag", typeof(object));
        }

        public Link(string title, string url, string target)
        {
            this._title = title;
            this._url = url;
            this._target = target;
            this.Tag = null;
            this._isEnabled = true;
        }

        public Link Clone() => 
            new Link(this);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("title", this._title);
            info.AddValue("url", this._url);
            info.AddValue("target", this._target);
            info.AddValue("isEnabled", this._isEnabled);
            info.AddValue("Tag", this.Tag);
        }

        public virtual string MakeCurveItemUrl(GraphPane pane, CurveItem curve, int index)
        {
            string str = this._url;
            str = (str.IndexOf('?') < 0) ? (str + "?index=" + index.ToString()) : (str + "&index=" + index.ToString());
            Axis xAxis = curve.GetXAxis(pane);
            if ((xAxis.Type == AxisType.Text) && ((index >= 0) && ((xAxis.Scale.TextLabels != null) && (index <= xAxis.Scale.TextLabels.Length))))
            {
                str = str + "&xtext=" + xAxis.Scale.TextLabels[index];
            }
            Axis yAxis = curve.GetYAxis(pane);
            if ((yAxis != null) && ((yAxis.Type == AxisType.Text) && ((index >= 0) && ((yAxis.Scale.TextLabels != null) && (index <= yAxis.Scale.TextLabels.Length)))))
            {
                str = str + "&ytext=" + yAxis.Scale.TextLabels[index];
            }
            return str;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public string Title
        {
            get => 
                this._title;
            set => 
                this._title = value;
        }

        public string Url
        {
            get => 
                this._url;
            set => 
                this._url = value;
        }

        public string Target
        {
            get => 
                (this._target != string.Empty) ? this._target : "_self";
            set => 
                this._target = value;
        }

        public bool IsEnabled
        {
            get => 
                this._isEnabled;
            set => 
                this._isEnabled = value;
        }

        public bool IsActive =>
            this._isEnabled && ((this._url != null) || !ReferenceEquals(this._title, null));
    }
}

