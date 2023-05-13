namespace ZedGraph
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class BarSettings : ISerializable
    {
        public const int schema = 10;
        private float _minClusterGap;
        private float _minBarGap;
        private BarBase _base;
        private BarType _type;
        internal double _clusterScaleWidth;
        internal bool _clusterScaleWidthAuto;
        internal GraphPane _ownerPane;

        public BarSettings(GraphPane parentPane)
        {
            this._minClusterGap = Default.MinClusterGap;
            this._minBarGap = Default.MinBarGap;
            this._clusterScaleWidth = Default.ClusterScaleWidth;
            this._clusterScaleWidthAuto = Default.ClusterScaleWidthAuto;
            this._base = Default.Base;
            this._type = Default.Type;
            this._ownerPane = parentPane;
        }

        internal BarSettings(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._minClusterGap = info.GetSingle("minClusterGap");
            this._minBarGap = info.GetSingle("minBarGap");
            this._clusterScaleWidth = info.GetDouble("clusterScaleWidth");
            this._clusterScaleWidthAuto = info.GetBoolean("clusterScaleWidthAuto");
            this._base = (BarBase) info.GetValue("base", typeof(BarBase));
            this._type = (BarType) info.GetValue("type", typeof(BarType));
        }

        public BarSettings(BarSettings rhs, GraphPane parentPane)
        {
            this._minClusterGap = rhs._minClusterGap;
            this._minBarGap = rhs._minBarGap;
            this._clusterScaleWidth = rhs._clusterScaleWidth;
            this._clusterScaleWidthAuto = rhs._clusterScaleWidthAuto;
            this._base = rhs._base;
            this._type = rhs._type;
            this._ownerPane = parentPane;
        }

        public Axis BarBaseAxis() => 
            (this._base != BarBase.Y) ? ((this._base != BarBase.Y2) ? ((this._base != BarBase.X2) ? ((Axis) this._ownerPane.XAxis) : ((Axis) this._ownerPane.X2Axis)) : ((Axis) this._ownerPane.Y2Axis)) : ((Axis) this._ownerPane.YAxis);

        public void CalcClusterScaleWidth()
        {
            Axis baseAxis = this.BarBaseAxis();
            if (this._clusterScaleWidthAuto && !baseAxis.Scale.IsAnyOrdinal)
            {
                double maxValue = double.MaxValue;
                foreach (CurveItem item in this._ownerPane.CurveList)
                {
                    IPointList points = item.Points;
                    if (item is BarItem)
                    {
                        double minStepSize = GetMinStepSize(item.Points, baseAxis);
                        maxValue = (minStepSize < maxValue) ? minStepSize : maxValue;
                    }
                }
                if (maxValue == double.MaxValue)
                {
                    maxValue = 1.0;
                }
                this._clusterScaleWidth = maxValue;
            }
            foreach (CurveItem item2 in this._ownerPane.CurveList)
            {
                IPointList points = item2.Points;
                if ((item2 is JapaneseCandleStickItem) && (item2 as JapaneseCandleStickItem).Stick.IsAutoSize)
                {
                    (item2 as JapaneseCandleStickItem).Stick._userScaleSize = GetMinStepSize(points, baseAxis);
                }
            }
        }

        public float GetClusterWidth() => 
            this.BarBaseAxis()._scale.GetClusterWidth(this._ownerPane);

        internal static double GetMinStepSize(IPointList list, Axis baseAxis)
        {
            double maxValue = double.MaxValue;
            if ((list.Count <= 0) || baseAxis._scale.IsAnyOrdinal)
            {
                return 1.0;
            }
            PointPair pair = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                PointPair pair2 = list[i];
                if (!pair2.IsInvalid || !pair.IsInvalid)
                {
                    double num3 = ((baseAxis is XAxis) || (baseAxis is X2Axis)) ? (pair2.X - pair.X) : (pair2.Y - pair.Y);
                    if ((num3 > 0.0) && (num3 < maxValue))
                    {
                        maxValue = num3;
                    }
                }
                pair = pair2;
            }
            double num4 = baseAxis.Scale._maxLinearized - baseAxis.Scale._minLinearized;
            if (num4 <= 0.0)
            {
                maxValue = 1.0;
            }
            else if ((maxValue <= 0.0) || (maxValue > num4))
            {
                maxValue = 0.1 * num4;
            }
            return maxValue;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("minClusterGap", this._minClusterGap);
            info.AddValue("minBarGap", this._minBarGap);
            info.AddValue("clusterScaleWidth", this._clusterScaleWidth);
            info.AddValue("clusterScaleWidthAuto", this._clusterScaleWidthAuto);
            info.AddValue("base", this._base);
            info.AddValue("type", this._type);
        }

        public float MinClusterGap
        {
            get => 
                this._minClusterGap;
            set => 
                this._minClusterGap = value;
        }

        public float MinBarGap
        {
            get => 
                this._minBarGap;
            set => 
                this._minBarGap = value;
        }

        public BarBase Base
        {
            get => 
                this._base;
            set => 
                this._base = value;
        }

        public BarType Type
        {
            get => 
                this._type;
            set => 
                this._type = value;
        }

        public double ClusterScaleWidth
        {
            get => 
                this._clusterScaleWidth;
            set
            {
                this._clusterScaleWidth = value;
                this._clusterScaleWidthAuto = false;
            }
        }

        public bool ClusterScaleWidthAuto
        {
            get => 
                this._clusterScaleWidthAuto;
            set => 
                this._clusterScaleWidthAuto = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float MinClusterGap;
            public static float MinBarGap;
            public static BarBase Base;
            public static BarType Type;
            public static double ClusterScaleWidth;
            public static bool ClusterScaleWidthAuto;
            static Default()
            {
                MinClusterGap = 1f;
                MinBarGap = 0.2f;
                Base = BarBase.X;
                Type = BarType.Cluster;
                ClusterScaleWidth = 1.0;
                ClusterScaleWidthAuto = true;
            }
        }
    }
}

