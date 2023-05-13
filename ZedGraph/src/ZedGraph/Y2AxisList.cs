namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    [Serializable]
    public class Y2AxisList : List<Y2Axis>, ICloneable
    {
        public Y2AxisList()
        {
        }

        public Y2AxisList(Y2AxisList rhs)
        {
            foreach (Y2Axis axis in rhs)
            {
                base.Add(axis.Clone());
            }
        }

        public int Add(string title)
        {
            Y2Axis item = new Y2Axis(title);
            base.Add(item);
            return (base.Count - 1);
        }

        public Y2AxisList Clone() => 
            new Y2AxisList(this);

        public int IndexOf(string title)
        {
            int num2;
            int num = 0;
            using (List<Y2Axis>.Enumerator enumerator = base.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        Y2Axis current = enumerator.Current;
                        if (string.Compare(current.Title._text, title, true) != 0)
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
            using (List<Y2Axis>.Enumerator enumerator = base.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        Y2Axis current = enumerator.Current;
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

        public Y2Axis this[int index] =>
            ((index < 0) || (index >= base.Count)) ? null : base[index];

        public Y2Axis this[string title]
        {
            get
            {
                int index = this.IndexOf(title);
                return ((index < 0) ? null : this[index]);
            }
        }
    }
}

