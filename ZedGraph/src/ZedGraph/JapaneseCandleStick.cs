namespace ZedGraph
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class JapaneseCandleStick : OHLCBar, ICloneable, ISerializable
    {
        public const int schema2 = 11;
        private Fill _risingFill;
        private Fill _fallingFill;
        private Border _risingBorder;
        private Border _fallingBorder;
        protected Color _fallingColor;

        public JapaneseCandleStick()
        {
            this._risingFill = new Fill(Default.RisingColor);
            this._fallingFill = new Fill(Default.FallingColor);
            this._risingBorder = new Border(Default.RisingBorder, LineBase.Default.Width);
            this._fallingBorder = new Border(Default.FallingBorder, LineBase.Default.Width);
            this._fallingColor = Default.FallingColor;
        }

        public JapaneseCandleStick(JapaneseCandleStick rhs) : base(rhs)
        {
            this._risingFill = rhs._risingFill.Clone();
            this._fallingFill = rhs._fallingFill.Clone();
            this._risingBorder = rhs._risingBorder.Clone();
            this._fallingBorder = rhs._fallingBorder.Clone();
            this._fallingColor = rhs._fallingColor;
        }

        protected JapaneseCandleStick(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            info.GetInt32("schema2");
            this._risingFill = (Fill) info.GetValue("risingFill", typeof(Fill));
            this._fallingFill = (Fill) info.GetValue("fallingFill", typeof(Fill));
            this._risingBorder = (Border) info.GetValue("risingBorder", typeof(Border));
            this._fallingBorder = (Border) info.GetValue("fallingBorder", typeof(Border));
            this._fallingColor = (Color) info.GetValue("fallingColor", typeof(Color));
        }

        public JapaneseCandleStick Clone() => 
            new JapaneseCandleStick(this);

        public void Draw(Graphics g, GraphPane pane, JapaneseCandleStickItem curve, Axis baseAxis, Axis valueAxis, float scaleFactor)
        {
            if (curve.Points != null)
            {
                float halfSize = base.GetBarWidth(pane, baseAxis, scaleFactor);
                Color color = base._color;
                Color color2 = this._fallingColor;
                float width = base._width;
                Fill fill = this._risingFill;
                Fill fill2 = this._fallingFill;
                Border border = this._risingBorder;
                Border border2 = this._fallingBorder;
                if (curve.IsSelected)
                {
                    color = Selection.Border.Color;
                    color2 = Selection.Border.Color;
                    width = Selection.Border.Width;
                    fill = Selection.Fill;
                    fill2 = Selection.Fill;
                    border = Selection.Border;
                    border2 = Selection.Border;
                }
                using (Pen pen = new Pen(color, width))
                {
                    using (Pen pen2 = new Pen(color2, width))
                    {
                        for (int i = 0; i < curve.Points.Count; i++)
                        {
                            PointPair pt = curve.Points[i];
                            double x = pt.X;
                            double y = pt.Y;
                            double z = pt.Z;
                            double maxValue = double.MaxValue;
                            double close = double.MaxValue;
                            if (pt is StockPt)
                            {
                                maxValue = (pt as StockPt).Open;
                                close = (pt as StockPt).Close;
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
                                    this.Draw(g, pane, (baseAxis is XAxis) || (baseAxis is X2Axis), pixBase, pixHigh, pixLow, pixOpen, pixClose, halfSize, scaleFactor, (close > maxValue) ? pen : pen2, (close > maxValue) ? fill : fill2, (close > maxValue) ? border : border2, pt);
                                }
                                else
                                {
                                    using (Pen pen3 = base.GetPen(pane, scaleFactor, pt))
                                    {
                                        this.Draw(g, pane, (baseAxis is XAxis) || (baseAxis is X2Axis), pixBase, pixHigh, pixLow, pixOpen, pixClose, halfSize, scaleFactor, pen3, (close > maxValue) ? fill : fill2, (close > maxValue) ? border : border2, pt);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void Draw(Graphics g, GraphPane pane, bool isXBase, float pixBase, float pixHigh, float pixLow, float pixOpen, float pixClose, float halfSize, float scaleFactor, Pen pen, Fill fill, Border border, PointPair pt)
        {
            if ((pixBase != double.MaxValue) && ((Math.Abs(pixLow) < 1000000f) && (Math.Abs(pixHigh) < 1000000f)))
            {
                RectangleF ef;
                if (isXBase)
                {
                    ef = new RectangleF(pixBase - halfSize, Math.Min(pixOpen, pixClose), halfSize * 2f, Math.Abs((float) (pixOpen - pixClose)));
                    g.DrawLine(pen, pixBase, pixHigh, pixBase, pixLow);
                }
                else
                {
                    ef = new RectangleF(Math.Min(pixOpen, pixClose), pixBase - halfSize, Math.Abs((float) (pixOpen - pixClose)), halfSize * 2f);
                    g.DrawLine(pen, pixHigh, pixBase, pixLow, pixBase);
                }
                if (base._isOpenCloseVisible && ((Math.Abs(pixOpen) < 1000000f) && (Math.Abs(pixClose) < 1000000f)))
                {
                    if (ef.Width == 0f)
                    {
                        ef.Width = 1f;
                    }
                    if (ef.Height == 0f)
                    {
                        ef.Height = 1f;
                    }
                    fill.Draw(g, ef, pt);
                    border.Draw(g, pane, scaleFactor, ef);
                }
            }
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", 11);
            info.AddValue("risingFill", this._risingFill);
            info.AddValue("fallingFill", this._fallingFill);
            info.AddValue("risingBorder", this._risingBorder);
            info.AddValue("fallingBorder", this._fallingBorder);
            info.AddValue("fallingColor", this._fallingColor);
        }

        object ICloneable.Clone() => 
            this.Clone();

        public Fill RisingFill
        {
            get => 
                this._risingFill;
            set => 
                this._risingFill = value;
        }

        public Fill FallingFill
        {
            get => 
                this._fallingFill;
            set => 
                this._fallingFill = value;
        }

        public Border RisingBorder
        {
            get => 
                this._risingBorder;
            set => 
                this._risingBorder = value;
        }

        public Border FallingBorder
        {
            get => 
                this._fallingBorder;
            set => 
                this._fallingBorder = value;
        }

        public Color FallingColor
        {
            get => 
                this._fallingColor;
            set => 
                this._fallingColor = value;
        }

        [StructLayout(LayoutKind.Sequential, Size=1)]
        public struct Default
        {
            public static Color RisingColor;
            public static Color FallingColor;
            public static Color RisingBorder;
            public static Color FallingBorder;
            static Default()
            {
                RisingColor = Color.White;
                FallingColor = Color.Black;
                RisingBorder = Color.Black;
                FallingBorder = Color.Black;
            }
        }
    }
}

