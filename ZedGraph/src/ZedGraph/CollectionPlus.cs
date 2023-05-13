namespace ZedGraph
{
    using System;
    using System.Collections;

    [Serializable]
    public class CollectionPlus : CollectionBase
    {
        public int IndexOf(object item) => 
            base.List.IndexOf(item);

        public int Move(int index, int relativePos)
        {
            if ((index < 0) || (index >= base.List.Count))
            {
                return -1;
            }
            object obj2 = base.List[index];
            base.List.RemoveAt(index);
            index += relativePos;
            if (index < 0)
            {
                index = 0;
            }
            if (index > base.List.Count)
            {
                index = base.List.Count;
            }
            base.List.Insert(index, obj2);
            return index;
        }

        public void Remove(int index)
        {
            if ((index >= 0) && (index < base.List.Count))
            {
                base.List.RemoveAt(index);
            }
        }

        public void Remove(object item)
        {
            base.List.Remove(item);
        }
    }
}

