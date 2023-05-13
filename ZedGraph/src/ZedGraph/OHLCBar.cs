namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class OHLCBar : LineBase, ICloneable, ISerializable
    {
        public const int schema = 10;
        protected bool _isOpenCloseVisible;
        protected float _size;
        protected bool _isAutoSize;
        internal double _userScaleSize;

        public OHLCBar() : this(LineBase.Default.Color)
        {
        }

        public OHLCBar(Color color) : base(color)
        {
            this._userScaleSize = 1.0;
            this._size = Default.Size;
            this._isAutoSize = Default.IsAutoSize;
            this._isOpenCloseVisible = Default.IsOpenCloseVisible;
        }

        public OHLCBar(OHLCBar rhs) : base(rhs)
        {
            this._userScaleSize = 1.0;
            this._isOpenCloseVisible = rhs._isOpenCloseVisible;
            this._size = rhs._size;
            this._isAutoSize = rhs._isAutoSize;
        }

        protected OHLCBar(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            this._userScaleSize = 1.0;
            info.GetInt32("schema");
            this._isOpenCloseVisible = info.GetBoolean("isOpenCloseVisible");
            this._size = info.GetSingle("size");
            this._isAutoSize = info.GetBoolean("isAutoSize");
        }

        public OHLCBar Clone() => 
            new OHLCBar(this);

        public void Draw(Graphics g, GraphPane pane, OHLCBarItem curve, Axis baseAxis, Axis valueAxis, float scaleFactor)
        {
            if (curve.Points != null)
            {
                float halfSize = this.GetBarWidth(pane, baseAxis, scaleFactor);
                using (Pen pen = !curve.IsSelected ? new Pen(base._color, base._width) : new Pen(Selection.Border.Color, Selection.Border.Width))
                {
                    for (int i = 0; i < curve.Points.Count; i++)
                    {
                        PointPair dataValue = curve.Points[i];
                        double x = dataValue.X;
                        double y = dataValue.Y;
                        double z = dataValue.Z;
                        double maxValue = double.MaxValue;
                        double close = double.MaxValue;
                        if (dataValue is StockPt)
                        {
                            maxValue = (dataValue as StockPt).Open;
                            close = (dataValue as StockPt).Close;
                        }
                        if ((!curve.Points[i].IsInvalid3D && ((x > 0.0) || !baseAxis._scale.IsLog)) && (((y > 0.0) && (z > 0.0)) || !valueAxis._scale.IsLog))
                        {
                            float pixBase = (int) (baseAxis.Scale.Transform(curve.IsOverrideOrdinal, i, x) + 0.5);
                            float pixHigh = valueAxis.Scale.Transform(curve.IsOverrideOrdinal, i, y);
                            float pixLow = valueAxis.Scale.Transform(curve.IsOverrideOrdinal, i, z);
                            float pixOpen = !PointPairBase.IsValueInvalid(maxValue) ? valueAxis.Scale.Transform(curve.IsOverrideOrdinal, i, maxValue) : float.MaxValue;
                            float pixClose = !PointPairBase.IsValueInvalid(close) ? valueAxis.Scale.Transform(curve.IsOverrideOrdinal, i, close) : float.MaxValue;
                            if (curve.IsSelected || !base._gradientFill.IsGradientValueType)
                            {
                                this.Draw(g, pane, (baseAxis is XAxis) || (baseAxis is X2Axis), pixBase, pixHigh, pixLow, pixOpen, pixClose, halfSize, pen);
                            }
                            else
                            {
                                using (Pen pen2 = base.GetPen(pane, scaleFactor, dataValue))
                                {
                                    this.Draw(g, pane, (baseAxis is XAxis) || (baseAxis is X2Axis), pixBase, pixHigh, pixLow, pixOpen, pixClose, halfSize, pen2);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Draw(Graphics g, GraphPane pane, bool isXBase, float pixBase, float pixHigh, float pixLow, float pixOpen, float pixClose, float halfSize, Pen pen)
        {
            if (pixBase != double.MaxValue)
            {
                if (!isXBase)
                {
                    if ((Math.Abs(pixLow) < 1000000f) && (Math.Abs(pixHigh) < 1000000f))
                    {
                        g.DrawLine(pen, pixHigh, pixBase, pixLow, pixBase);
                    }
                    if (this._isOpenCloseVisible && (Math.Abs(pixOpen) < 1000000f))
                    {
                        g.DrawLine(pen, pixOpen, pixBase - halfSize, pixOpen, pixBase);
                    }
                    if (this._isOpenCloseVisible && (Math.Abs(pixClose) < 1000000f))
                    {
                        g.DrawLine(pen, pixClose, pixBase, pixClose, pixBase + halfSize);
                    }
                }
                else
                {
                    if ((Math.Abs(pixLow) < 1000000f) && (Math.Abs(pixHigh) < 1000000f))
                    {
                        g.DrawLine(pen, pixBase, pixHigh, pixBase, pixLow);
                    }
                    if (this._isOpenCloseVisible && (Math.Abs(pixOpen) < 1000000f))
                    {
                        g.DrawLine(pen, pixBase - halfSize, pixOpen, pixBase, pixOpen);
                    }
                    if (this._isOpenCloseVisible && (Math.Abs(pixClose) < 1000000f))
                    {
                        g.DrawLine(pen, pixBase, pixClose, pixBase + halfSize, pixClose);
                    }
                }
            }
        }

        public float GetBarWidth(GraphPane pane, Axis baseAxis, float scaleFactor)
        {
            float num = !this._isAutoSize ? ((this._size * scaleFactor) / 2f) : ((baseAxis._scale.GetClusterWidth(this._userScaleSize) / (1f + pane._barSettings.MinClusterGap)) / 2f);
            return (float) ((int) (num + 0.5f));
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema", 10);
            info.AddValue("isOpenCloseVisible", this._isOpenCloseVisible);
            info.AddValue("size", this._size);
            info.AddValue("isAutoSize", this._isAutoSize);
        }

        object ICloneable.Clone() => 
            this.Clone();

        public bool IsOpenCloseVisible
        {
            get => 
                this._isOpenCloseVisible;
            set => 
                this._isOpenCloseVisible = value;
        }

        public float Size
        {
            get => 
                this._size;
            set
            {
                this._size = value;
                this._isAutoSize = false;
            }
        }

        public bool IsAutoSize
        {
            get => 
                this._isAutoSize;
            set => 
                this._isAutoSize = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static float Size;
            public static bool IsOpenCloseVisible;
            public static bool IsAutoSize;
            static Default()
            {
                Size = 12f;
                IsOpenCloseVisible = true;
                IsAutoSize = true;
            }
        }
    }
}

