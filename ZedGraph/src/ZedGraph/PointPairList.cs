namespace ZedGraph
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class PointPairList : List<PointPair>, IPointListEdit, IPointList, ICloneable
    {
        protected bool _sorted;

        public PointPairList()
        {
            this._sorted = true;
            this._sorted = false;
        }

        public PointPairList(IPointList list)
        {
            this._sorted = true;
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                this.Add(list[i]);
            }
            this._sorted = false;
        }

        public PointPairList(PointPairList rhs)
        {
            this._sorted = true;
            this.Add(rhs);
            this._sorted = false;
        }

        public PointPairList(double[] x, double[] y)
        {
            this._sorted = true;
            this.Add(x, y);
            this._sorted = false;
        }

        public PointPairList(double[] x, double[] y, double[] baseVal)
        {
            this._sorted = true;
            this.Add(x, y, baseVal);
            this._sorted = false;
        }

        public void Add(PointPair point)
        {
            this._sorted = false;
            base.Add(point.Clone());
        }

        public void Add(PointPairList pointList)
        {
            foreach (PointPair pair in pointList)
            {
                this.Add(pair);
            }
            this._sorted = false;
        }

        public void Add(double[] x, double[] y)
        {
            int length = 0;
            if (x != null)
            {
                length = x.Length;
            }
            if ((y != null) && (y.Length > length))
            {
                length = y.Length;
            }
            for (int i = 0; i < length; i++)
            {
                PointPair item = new PointPair(0.0, 0.0, 0.0) {
                    X = (x != null) ? ((i >= x.Length) ? double.MaxValue : x[i]) : (i + 1.0),
                    Y = (y != null) ? ((i >= y.Length) ? double.MaxValue : y[i]) : (i + 1.0)
                };
                base.Add(item);
            }
            this._sorted = false;
        }

        public void Add(double x, double y)
        {
            this._sorted = false;
            PointPair item = new PointPair(x, y);
            base.Add(item);
        }

        public void Add(double[] x, double[] y, double[] z)
        {
            int length = 0;
            if (x != null)
            {
                length = x.Length;
            }
            if ((y != null) && (y.Length > length))
            {
                length = y.Length;
            }
            if ((z != null) && (z.Length > length))
            {
                length = z.Length;
            }
            for (int i = 0; i < length; i++)
            {
                PointPair item = new PointPair {
                    X = (x != null) ? ((i >= x.Length) ? double.MaxValue : x[i]) : (i + 1.0),
                    Y = (y != null) ? ((i >= y.Length) ? double.MaxValue : y[i]) : (i + 1.0),
                    Z = (z != null) ? ((i >= z.Length) ? double.MaxValue : z[i]) : (i + 1.0)
                };
                base.Add(item);
            }
            this._sorted = false;
        }

        public void Add(double x, double y, double z)
        {
            this._sorted = false;
            PointPair item = new PointPair(x, y, z);
            base.Add(item);
        }

        public void Add(double x, double y, string tag)
        {
            this._sorted = false;
            PointPair item = new PointPair(x, y, tag);
            base.Add(item);
        }

        public void Add(double x, double y, double z, string tag)
        {
            this._sorted = false;
            PointPair item = new PointPair(x, y, z, tag);
            base.Add(item);
        }

        public PointPairList Clone() => 
            new PointPairList(this);

        public override bool Equals(object obj)
        {
            PointPairList list = obj as PointPairList;
            if (base.Count != list.Count)
            {
                return false;
            }
            for (int i = 0; i < base.Count; i++)
            {
                if (!base[i].Equals(list[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode() => 
            base.GetHashCode();

        public int IndexOfTag(string label)
        {
            int num2;
            int num = 0;
            using (List<PointPair>.Enumerator enumerator = base.GetEnumerator())
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        PointPair current = enumerator.Current;
                        if (!(current.Tag is string) || (string.Compare((string) current.Tag, label, true) != 0))
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

        public void Insert(int index, PointPair point)
        {
            this._sorted = false;
            base.Insert(index, point);
        }

        public void Insert(int index, double x, double y)
        {
            this._sorted = false;
            base.Insert(index, new PointPair(x, y));
        }

        public void Insert(int index, double x, double y, double z)
        {
            this._sorted = false;
            this.Insert(index, new PointPair(x, y, z));
        }

        public double InterpolateX(double xTarget)
        {
            int num;
            int num3;
            if (base.Count < 2)
            {
                throw new Exception("Error: Not enough points in curve to interpolate");
            }
            if (xTarget <= base[0].X)
            {
                num = 0;
                num3 = 1;
            }
            else if (xTarget >= base[base.Count - 1].X)
            {
                num = base.Count - 2;
                num3 = base.Count - 1;
            }
            else
            {
                num = 0;
                num3 = base.Count - 1;
                int num4 = 0;
                while (true)
                {
                    if ((num4 >= 0x3e8) || (num3 <= (num + 1)))
                    {
                        if (num4 < 0x3e8)
                        {
                            break;
                        }
                        throw new Exception("Error: Infinite loop in interpolation");
                    }
                    int num2 = (num3 + num) / 2;
                    if (xTarget > base[num2].X)
                    {
                        num = num2;
                    }
                    else
                    {
                        num3 = num2;
                    }
                    num4++;
                }
            }
            return ((((xTarget - base[num].X) / (base[num3].X - base[num].X)) * (base[num3].Y - base[num].Y)) + base[num].Y);
        }

        public double InterpolateY(double yTarget)
        {
            int num;
            int num3;
            if (base.Count < 2)
            {
                throw new Exception("Error: Not enough points in curve to interpolate");
            }
            if (yTarget <= base[0].Y)
            {
                num = 0;
                num3 = 1;
            }
            else if (yTarget >= base[base.Count - 1].Y)
            {
                num = base.Count - 2;
                num3 = base.Count - 1;
            }
            else
            {
                num = 0;
                num3 = base.Count - 1;
                int num4 = 0;
                while (true)
                {
                    if ((num4 >= 0x3e8) || (num3 <= (num + 1)))
                    {
                        if (num4 < 0x3e8)
                        {
                            break;
                        }
                        throw new Exception("Error: Infinite loop in interpolation");
                    }
                    int num2 = (num3 + num) / 2;
                    if (yTarget > base[num2].Y)
                    {
                        num = num2;
                    }
                    else
                    {
                        num3 = num2;
                    }
                    num4++;
                }
            }
            return ((((yTarget - base[num].Y) / (base[num3].Y - base[num].Y)) * (base[num3].X - base[num].X)) + base[num].X);
        }

        public PointPairList LinearRegression(IPointList points, int pointCount)
        {
            double maxValue = double.MaxValue;
            double minValue = double.MinValue;
            for (int i = 0; i < points.Count; i++)
            {
                PointPair pair = points[i];
                if (!pair.IsInvalid)
                {
                    maxValue = (pair.X < maxValue) ? pair.X : maxValue;
                    minValue = (pair.X > minValue) ? pair.X : minValue;
                }
            }
            return this.LinearRegression(points, pointCount, maxValue, minValue);
        }

        public PointPairList LinearRegression(IPointList points, int pointCount, double minX, double maxX)
        {
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            for (int i = 0; i < points.Count; i++)
            {
                PointPair pair = points[i];
                if (!pair.IsInvalid)
                {
                    num += points[i].X;
                    num2 += points[i].Y;
                    num3 += points[i].X * points[i].X;
                    num4 += points[i].X * points[i].Y;
                    num5++;
                }
            }
            if ((num5 < 2.0) || ((maxX - minX) < 1E-20))
            {
                return null;
            }
            double num7 = ((num5 * num4) - (num * num2)) / ((num5 * num3) - (num * num));
            double num8 = (num2 - (num7 * num)) / num5;
            PointPairList list = new PointPairList();
            double num9 = (maxX - minX) / ((double) pointCount);
            double x = minX;
            for (int j = 0; j < pointCount; j++)
            {
                list.Add(new PointPair(x, (x * num7) + num8));
                x += num9;
            }
            return list;
        }

        public void SetX(double[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                if (i < base.Count)
                {
                    base[i].X = x[i];
                }
            }
            this._sorted = false;
        }

        public void SetY(double[] y)
        {
            for (int i = 0; i < y.Length; i++)
            {
                if (i < base.Count)
                {
                    base[i].Y = y[i];
                }
            }
            this._sorted = false;
        }

        public void SetZ(double[] z)
        {
            for (int i = 0; i < z.Length; i++)
            {
                if (i < base.Count)
                {
                    base[i].Z = z[i];
                }
            }
            this._sorted = false;
        }

        public bool Sort()
        {
            if (this._sorted)
            {
                return true;
            }
            base.Sort(new PointPair.PointPairComparer(SortType.XValues));
            return false;
        }

        public bool Sort(SortType type)
        {
            if (this._sorted)
            {
                return true;
            }
            base.Sort(new PointPair.PointPairComparer(type));
            return false;
        }

        public double SplineInterpolateX(double xTarget, double tension)
        {
            double num5;
            double num8;
            double num9;
            double num12;
            tension /= 3.0;
            if (base.Count < 2)
            {
                throw new Exception("Error: Not enough points in curve to interpolate");
            }
            if ((xTarget <= base[0].X) || (xTarget >= base[base.Count - 1].X))
            {
                return double.MaxValue;
            }
            int num = 0;
            int num3 = base.Count - 1;
            int num4 = 0;
            while ((num4 < 0x3e8) && (num3 > (num + 1)))
            {
                int num2 = (num3 + num) / 2;
                if (xTarget > base[num2].X)
                {
                    num = num2;
                }
                else
                {
                    num3 = num2;
                }
                num4++;
            }
            if (num4 >= 0x3e8)
            {
                throw new Exception("Error: Infinite loop in interpolation");
            }
            double x = base[num].X;
            double num7 = base[num3].X;
            double y = base[num].Y;
            double num11 = base[num3].Y;
            if (num == 0)
            {
                num5 = x - ((num7 - x) / 3.0);
                num9 = y - ((num11 - y) / 3.0);
            }
            else
            {
                num5 = base[num - 1].X;
                num9 = base[num - 1].Y;
            }
            if (num3 == (base.Count - 1))
            {
                num8 = num7 + ((num7 - x) / 3.0);
                num12 = num11 + ((num11 - y) / 3.0);
            }
            else
            {
                num8 = base[num3 + 1].X;
                num12 = base[num3 + 1].Y;
            }
            double num19 = x;
            double num20 = y;
            for (double i = 0.01; i <= 1.0; i += 0.01)
            {
                double num13 = ((1.0 - i) * (1.0 - i)) * (1.0 - i);
                double num14 = ((3.0 * i) * (1.0 - i)) * (1.0 - i);
                double num15 = ((3.0 * i) * i) * (1.0 - i);
                double num16 = (i * i) * i;
                double num17 = (((x * num13) + ((x + ((num7 - num5) * tension)) * num14)) + ((num7 - ((num8 - x) * tension)) * num15)) + (num7 * num16);
                double num18 = (((y * num13) + ((y + ((num11 - num9) * tension)) * num14)) + ((num11 - ((num12 - y) * tension)) * num15)) + (num11 * num16);
                if (num17 >= xTarget)
                {
                    return ((((xTarget - num19) / (num17 - num19)) * (num18 - num20)) + num20);
                }
                num19 = num17;
                num20 = num18;
            }
            return num11;
        }

        public void SumX(PointPairList sumList)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (i < sumList.Count)
                {
                    PointPair local1 = base[i];
                    local1.X += sumList[i].X;
                }
            }
            this._sorted = false;
        }

        public void SumY(PointPairList sumList)
        {
            for (int i = 0; i < base.Count; i++)
            {
                if (i < sumList.Count)
                {
                    PointPair local1 = base[i];
                    local1.Y += sumList[i].Y;
                }
            }
        }

        object ICloneable.Clone() => 
            this.Clone();

        public bool Sorted =>
            this._sorted;
    }
}

