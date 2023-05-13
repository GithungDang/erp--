namespace ZedGraph
{
    using System;
    using System.Collections.Generic;

    public class ScaleStateList : List<ScaleState>, ICloneable
    {
        public ScaleStateList(ScaleStateList rhs)
        {
            foreach (ScaleState state in rhs)
            {
                base.Add(state.Clone());
            }
        }

        public ScaleStateList(Y2AxisList list)
        {
            foreach (Axis axis in list)
            {
                base.Add(new ScaleState(axis));
            }
        }

        public ScaleStateList(YAxisList list)
        {
            foreach (Axis axis in list)
            {
                base.Add(new ScaleState(axis));
            }
        }

        public void ApplyScale(Y2AxisList list)
        {
            int num = Math.Min(list.Count, base.Count);
            for (int i = 0; i < num; i++)
            {
                base[i].ApplyScale(list[i]);
            }
        }

        public void ApplyScale(YAxisList list)
        {
            int num = Math.Min(list.Count, base.Count);
            for (int i = 0; i < num; i++)
            {
                base[i].ApplyScale(list[i]);
            }
        }

        public ScaleStateList Clone() => 
            new ScaleStateList(this);

        public bool IsChanged(Y2AxisList list)
        {
            int num = Math.Min(list.Count, base.Count);
            for (int i = 0; i < num; i++)
            {
                if (base[i].IsChanged(list[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsChanged(YAxisList list)
        {
            int num = Math.Min(list.Count, base.Count);
            for (int i = 0; i < num; i++)
            {
                if (base[i].IsChanged(list[i]))
                {
                    return true;
                }
            }
            return false;
        }

        object ICloneable.Clone() => 
            this.Clone();
    }
}

