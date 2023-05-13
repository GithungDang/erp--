namespace ZedGraph
{
    using System;
    using System.Runtime.CompilerServices;

    public class Selection : CurveList
    {
        private EventHandler SelectionChangedEvent;
        public static ZedGraph.Border Border = new ZedGraph.Border(Color.Gray, 1f);
        public static ZedGraph.Fill Fill = new ZedGraph.Fill(Color.Gray);
        public static ZedGraph.Line Line = new ZedGraph.Line(Color.Gray);
        public static ZedGraph.Symbol Symbol = new ZedGraph.Symbol(SymbolType.Circle, Color.Gray);

        public event EventHandler SelectionChangedEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)] add
            {
                this.SelectionChangedEvent += value;
            }
            [MethodImpl(MethodImplOptions.Synchronized)] remove
            {
                this.SelectionChangedEvent -= value;
            }
        }

        public void AddToSelection(MasterPane master, CurveItem ci)
        {
            if (!base.Contains(ci))
            {
                base.Add(ci);
            }
            this.UpdateSelection(master);
        }

        public void AddToSelection(MasterPane master, CurveList ciList)
        {
            foreach (CurveItem item in ciList)
            {
                if (!base.Contains(item))
                {
                    base.Add(item);
                }
            }
            this.UpdateSelection(master);
        }

        public void ClearSelection(MasterPane master)
        {
            this.ClearSelection(master, true);
        }

        public void ClearSelection(MasterPane master, bool sendEvent)
        {
            base.Clear();
            foreach (GraphPane pane in master.PaneList)
            {
                foreach (CurveItem item in pane.CurveList)
                {
                    item.IsSelected = false;
                }
            }
            if (sendEvent && (this.SelectionChangedEvent != null))
            {
                this.SelectionChangedEvent(this, new EventArgs());
            }
        }

        public void RemoveFromSelection(MasterPane master, CurveItem ci)
        {
            if (base.Contains(ci))
            {
                base.Remove(ci);
            }
            this.UpdateSelection(master);
        }

        public void Select(MasterPane master, CurveItem ci)
        {
            this.ClearSelection(master, false);
            this.AddToSelection(master, ci);
        }

        public void Select(MasterPane master, CurveList ciList)
        {
            this.ClearSelection(master, false);
            this.AddToSelection(master, ciList);
        }

        public void UpdateSelection(MasterPane master)
        {
            if (base.Count <= 0)
            {
                this.ClearSelection(master);
            }
            else
            {
                foreach (GraphPane pane in master.PaneList)
                {
                    foreach (CurveItem item in pane.CurveList)
                    {
                        item.IsSelected = false;
                    }
                }
                foreach (CurveItem item2 in this)
                {
                    item2.IsSelected = true;
                    if (item2.IsLine && (master.PaneList.Count == 1))
                    {
                        GraphPane pane2 = master.PaneList[0];
                        pane2.CurveList.Remove(item2);
                        pane2.CurveList.Insert(0, item2);
                    }
                }
                if (this.SelectionChangedEvent != null)
                {
                    this.SelectionChangedEvent(this, new EventArgs());
                }
            }
        }
    }
}

