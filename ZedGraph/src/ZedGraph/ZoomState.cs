namespace ZedGraph
{
    using System;

    public class ZoomState : ICloneable
    {
        private ScaleState _xAxis;
        private ScaleState _x2Axis;
        private ScaleStateList _yAxis;
        private ScaleStateList _y2Axis;
        private StateType _type;

        public ZoomState(ZoomState rhs)
        {
            this._xAxis = new ScaleState(rhs._xAxis);
            this._x2Axis = new ScaleState(rhs._x2Axis);
            this._yAxis = new ScaleStateList(rhs._yAxis);
            this._y2Axis = new ScaleStateList(rhs._y2Axis);
        }

        public ZoomState(GraphPane pane, StateType type)
        {
            this._xAxis = new ScaleState(pane.XAxis);
            this._x2Axis = new ScaleState(pane.X2Axis);
            this._yAxis = new ScaleStateList(pane.YAxisList);
            this._y2Axis = new ScaleStateList(pane.Y2AxisList);
            this._type = type;
        }

        public void ApplyState(GraphPane pane)
        {
            this._xAxis.ApplyScale(pane.XAxis);
            this._x2Axis.ApplyScale(pane.X2Axis);
            this._yAxis.ApplyScale(pane.YAxisList);
            this._y2Axis.ApplyScale(pane.Y2AxisList);
        }

        public ZoomState Clone() => 
            new ZoomState(this);

        public bool IsChanged(GraphPane pane) => 
            this._xAxis.IsChanged(pane.XAxis) || (this._x2Axis.IsChanged(pane.X2Axis) || (this._yAxis.IsChanged(pane.YAxisList) || this._y2Axis.IsChanged(pane.Y2AxisList)));

        object ICloneable.Clone() => 
            this.Clone();

        public StateType Type =>
            this._type;

        public string TypeString
        {
            get
            {
                switch (this._type)
                {
                    case StateType.WheelZoom:
                        return "WheelZoom";

                    case StateType.Pan:
                        return "Pan";

                    case StateType.Scroll:
                        return "Scroll";
                }
                return "Zoom";
            }
        }

        public enum StateType
        {
            Zoom,
            WheelZoom,
            Pan,
            Scroll
        }
    }
}

