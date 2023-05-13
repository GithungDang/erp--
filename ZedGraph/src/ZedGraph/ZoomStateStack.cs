namespace ZedGraph
{
    using System;
    using System.Collections.Generic;

    public class ZoomStateStack : List<ZoomState>, ICloneable
    {
        public ZoomStateStack()
        {
        }

        public ZoomStateStack(ZoomStateStack rhs)
        {
            foreach (ZoomState state in rhs)
            {
                base.Add(new ZoomState(state));
            }
        }

        public ZoomStateStack Clone() => 
            new ZoomStateStack(this);

        public ZoomState Pop(GraphPane pane)
        {
            if (this.IsEmpty)
            {
                return null;
            }
            ZoomState state = base[base.Count - 1];
            base.RemoveAt(base.Count - 1);
            state.ApplyState(pane);
            return state;
        }

        public ZoomState PopAll(GraphPane pane)
        {
            if (this.IsEmpty)
            {
                return null;
            }
            ZoomState state = base[0];
            base.Clear();
            state.ApplyState(pane);
            return state;
        }

        public ZoomState Push(ZoomState state)
        {
            base.Add(state);
            return state;
        }

        public ZoomState Push(GraphPane pane, ZoomState.StateType type)
        {
            ZoomState item = new ZoomState(pane, type);
            base.Add(item);
            return item;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public bool IsEmpty =>
            base.Count == 0;

        public ZoomState Top =>
            this.IsEmpty ? null : base[base.Count - 1];
    }
}

