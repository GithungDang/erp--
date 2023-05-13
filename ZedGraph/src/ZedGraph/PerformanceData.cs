namespace ZedGraph
{
    using System;
    using System.Reflection;

    public class PerformanceData
    {
        public double time;
        public double distance;
        public double velocity;
        public double acceleration;

        public PerformanceData(double time, double distance, double velocity, double acceleration)
        {
            this.time = time;
            this.distance = distance;
            this.velocity = velocity;
            this.acceleration = acceleration;
        }

        public double this[PerfDataType type]
        {
            get
            {
                switch (type)
                {
                    case PerfDataType.Distance:
                        return this.distance;

                    case PerfDataType.Velocity:
                        return this.velocity;

                    case PerfDataType.Acceleration:
                        return this.acceleration;
                }
                return this.time;
            }
            set
            {
                switch (type)
                {
                    case PerfDataType.Time:
                        this.time = value;
                        return;

                    case PerfDataType.Distance:
                        this.distance = value;
                        return;

                    case PerfDataType.Velocity:
                        this.velocity = value;
                        return;

                    case PerfDataType.Acceleration:
                        this.acceleration = value;
                        return;
                }
            }
        }
    }
}

