namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    [Serializable]
    public class YAxisList : List<YAxis>, ICloneable
    {
        public YAxisList()
        {
        }

        public YAxisList(YAxisList rhs)
        {
            foreach (YAxis axis in rhs)
            {
                base.Add(axis.Clone());
            }
        }

        public int Add(string title)
        {
            YAxis item = new YAxis(title);
            base.Add(item);
            return (base.Count - 1);
        }

        public YAxisList Clone() => 
            new YAxisList(this);

        public int IndexOf(string title)
        {
            int num2;
            int num = 0;
            using (List<YAxis>.Enumerator enumerator = base.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        YAxis current = enumerator.Current;
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
            using (List<YAxis>.Enumerator enumerator = base.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        YAxis current = enumerator.Current;
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

        public YAxis this[int index] =>
            ((index < 0) || (index >= base.Count)) ? null : base[index];

        public YAxis this[string title]
        {
            get
            {
                int index = this.IndexOf(title);
                return ((index < 0) ? null : this[index]);
            }
        }
    }
}

