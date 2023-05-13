namespace ZedGraph
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.InteropServices;

    [Serializable]
    public class GraphObjList : List<GraphObj>, ICloneable
    {
        public GraphObjList()
        {
        }

        public GraphObjList(GraphObjList rhs)
        {
            foreach (GraphObj obj2 in rhs)
            {
                base.Add((GraphObj) ((ICloneable) obj2).Clone());
            }
        }

        public GraphObjList Clone() => 
            new GraphObjList(this);

        public void Draw(Graphics g, PaneBase pane, float scaleFactor, ZOrder zOrder)
        {
            for (int i = base.Count - 1; i >= 0; i--)
            {
                GraphObj obj2 = base[i];
                if ((obj2.ZOrder == zOrder) && obj2.IsVisible)
                {
                    Region region = null;
                    if (obj2.IsClippedToChartRect && (pane is GraphPane))
                    {
                        region = g.Clip.Clone();
                        g.SetClip(((GraphPane) pane).Chart._rect);
                    }
                    obj2.Draw(g, pane, scaleFactor);
                    if (obj2.IsClippedToChartRect && (pane is GraphPane))
                    {
                        g.Clip = region;
                    }
                }
            }
        }

        public bool FindPoint(PointF mousePt, PaneBase pane, Graphics g, float scaleFactor, out int index)
        {
            index = -1;
            for (int i = base.Count - 1; i >= 0; i--)
            {
                if (base[i].PointInBox(mousePt, pane, g, scaleFactor) && (((index >= 0) && (base[i].ZOrder > base[index].ZOrder)) || (index < 0)))
                {
                    index = i;
                }
            }
            return (index >= 0);
        }

        public int IndexOfTag(string tag)
        {
            int num2;
            int num = 0;
            using (List<GraphObj>.Enumerator enumerator = base.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        GraphObj current = enumerator.Current;
                        if (!(current.Tag is string) || (string.Compare((string) current.Tag, tag, true) != 0))
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

        public int Move(int index, int relativePos)
        {
            if ((index < 0) || (index >= base.Count))
            {
                return -1;
            }
            GraphObj item = base[index];
            base.RemoveAt(index);
            index += relativePos;
            if (index < 0)
            {
                index = 0;
            }
            if (index > base.Count)
            {
                index = base.Count;
            }
            base.Insert(index, item);
            return index;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public GraphObj this[string tag]
        {
            get
            {
                int num = this.IndexOfTag(tag);
                return ((num < 0) ? null : base[num]);
            }
        }
    }
}

