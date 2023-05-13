namespace ZedGraph
{
    using System;

    public class Sample
    {
        private DateTime _time;
        private double _position;
        private double _velocity;

        public DateTime Time
        {
            get => 
                this._time;
            set => 
                this._time = value;
        }

        public double Position
        {
            get => 
                this._position;
            set => 
                this._position = value;
        }

        public double Velocity
        {
            get => 
                this._velocity;
            set => 
                this._velocity = value;
        }
    }
}

