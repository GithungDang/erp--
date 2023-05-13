namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class ScrollRangeList : List<ScrollRange>, ICloneable
    {
        public ScrollRangeList()
        {
        }

        public ScrollRangeList(ScrollRangeList rhs)
        {
            foreach (ScrollRange range in rhs)
            {
                base.Add(new ScrollRange(range));
            }
        }

        public ScrollRangeList Clone() => 
            new ScrollRangeList(this);

        object ICloneable.Clone() => 
            this.Clone();

        public ScrollRange this[int index]
        {
            get => 
                ((index < 0) || (index >= base.Count)) ? new ScrollRange(false) : base[index];
            set => 
                base[index] = value;
        }
    }
}

