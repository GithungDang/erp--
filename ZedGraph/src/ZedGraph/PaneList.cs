namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class PaneList : List<GraphPane>, ICloneable
    {
        public const int schema = 10;

        public PaneList()
        {
        }

        public PaneList(PaneList rhs)
        {
            foreach (GraphPane pane in rhs)
            {
                base.Add(pane.Clone());
            }
        }

        protected PaneList(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
        }

        public PaneList Clone() => 
            new PaneList(this);

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
        }

        public int IndexOf(string title)
        {
            int num2;
            int num = 0;
            using (List<GraphPane>.Enumerator enumerator = base.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        GraphPane current = enumerator.Current;
                        if (string.Compare(current.Title.Text, title, true) != 0)
                        {
                            num++;
                            continue;
                        }
                        num2 = num;
                    }
                    else
                    {
                        return -1;
                    }
                    break;
                }
            }
            return num2;
        }

        public int IndexOfTag(string tagStr)
        {
            int num2;
            int num = 0;
            using (List<GraphPane>.Enumerator enumerator = base.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        GraphPane current = enumerator.Current;
                        if (!(current.Tag is string) || (string.Compare((string) current.Tag, tagStr, true) != 0))
                        {
                            num++;
                            continue;
                        }
                        num2 = num;
                    }
                    else
                    {
                        return -1;
                    }
                    break;
                }
            }
            return num2;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public GraphPane this[string title]
        {
            get
            {
                int index = this.IndexOf(title);
                return ((index < 0) ? null : base[index]);
            }
        }
    }
}

