namespace ZedGraph
{
    using System;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Security.Permissions;

    [Serializable]
    public class RollingPointPairList : ISerializable, IPointListEdit, IPointList, ICloneable
    {
        public const int schema = 10;
        protected PointPair[] _mBuffer;
        protected int _headIdx;
        protected int _tailIdx;

        public RollingPointPairList(int capacity) : this(capacity, false)
        {
            this._mBuffer = new PointPair[capacity];
            this._headIdx = this._tailIdx = -1;
        }

        public RollingPointPairList(IPointList rhs)
        {
            this._mBuffer = new PointPair[rhs.Count];
            for (int i = 0; i < rhs.Count; i++)
            {
                this._mBuffer[i] = new PointPair(rhs[i]);
            }
            this._headIdx = rhs.Count - 1;
            this._tailIdx = 0;
        }

        public RollingPointPairList(int capacity, bool preLoad)
        {
            this._mBuffer = new PointPair[capacity];
            this._headIdx = this._tailIdx = -1;
            if (preLoad)
            {
                for (int i = 0; i < capacity; i++)
                {
                    this._mBuffer[i] = new PointPair();
                }
            }
        }

        protected RollingPointPairList(SerializationInfo info, StreamingContext context)
        {
            info.GetInt32("schema");
            this._headIdx = info.GetInt32("headIdx");
            this._tailIdx = info.GetInt32("tailIdx");
            this._mBuffer = (PointPair[]) info.GetValue("mBuffer", typeof(PointPair[]));
        }

        public void Add(IPointList pointList)
        {
            for (int i = 0; i < pointList.Count; i++)
            {
                this.Add(pointList[i]);
            }
        }

        public void Add(PointPair item)
        {
            this._mBuffer[this.GetNextIndex()] = item;
        }

        public void Add(double x, double y)
        {
            this.Add(x, y, double.MaxValue, null);
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
                this.Add(item);
            }
        }

        public void Add(double x, double y, double z)
        {
            this.Add(x, y, z, null);
        }

        public void Add(double x, double y, object tag)
        {
            this.Add(x, y, double.MaxValue, tag);
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
                this.Add(item);
            }
        }

        public void Add(double x, double y, double z, object tag)
        {
            this.GetNextIndex();
            if (this._mBuffer[this._headIdx] == null)
            {
                this._mBuffer[this._headIdx] = new PointPair(x, y, z, tag);
            }
            else
            {
                this._mBuffer[this._headIdx].X = x;
                this._mBuffer[this._headIdx].Y = y;
                this._mBuffer[this._headIdx].Z = z;
                this._mBuffer[this._headIdx].Tag = tag;
            }
        }

        public void Clear()
        {
            this._headIdx = this._tailIdx = -1;
        }

        public RollingPointPairList Clone() => 
            new RollingPointPairList(this);

        private int GetNextIndex()
        {
            if (this._headIdx == -1)
            {
                this._headIdx = this._tailIdx = 0;
            }
            else
            {
                if (++this._headIdx == this._mBuffer.Length)
                {
                    this._headIdx = 0;
                }
                if ((this._headIdx == this._tailIdx) && (++this._tailIdx == this._mBuffer.Length))
                {
                    this._tailIdx = 0;
                }
            }
            return this._headIdx;
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter=true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", 10);
            info.AddValue("headIdx", this._headIdx);
            info.AddValue("tailIdx", this._tailIdx);
            info.AddValue("mBuffer", this._mBuffer);
        }

        public PointPair Peek()
        {
            if (this._headIdx == -1)
            {
                throw new InvalidOperationException("buffer is empty.");
            }
            return this._mBuffer[this._headIdx];
        }

        public PointPair Pop()
        {
            if (this._tailIdx == -1)
            {
                throw new InvalidOperationException("buffer is empty.");
            }
            PointPair pair = this._mBuffer[this._headIdx];
            if (this._tailIdx == this._headIdx)
            {
                this._headIdx = this._tailIdx = -1;
                return pair;
            }
            if (--this._headIdx == -1)
            {
                this._headIdx = this._mBuffer.Length - 1;
            }
            return pair;
        }

        public PointPair Remove()
        {
            if (this._tailIdx == -1)
            {
                throw new InvalidOperationException("buffer is empty.");
            }
            PointPair pair = this._mBuffer[this._tailIdx];
            if (this._tailIdx == this._headIdx)
            {
                this._headIdx = this._tailIdx = -1;
                return pair;
            }
            if (++this._tailIdx == this._mBuffer.Length)
            {
                this._tailIdx = 0;
            }
            return pair;
        }

        public void RemoveAt(int index)
        {
            int count = this.Count;
            if ((index >= count) || (index < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = index + this._tailIdx; i < ((this._tailIdx + count) - 1); i++)
            {
                i = (i >= this._mBuffer.Length) ? 0 : i;
                int num3 = i + 1;
                num3 = (num3 >= this._mBuffer.Length) ? 0 : num3;
                this._mBuffer[i] = this._mBuffer[num3];
            }
            this.Pop();
        }

        public void RemoveRange(int index, int count)
        {
            int num = this.Count;
            if ((index >= num) || ((index < 0) || ((count < 0) || (count > num))))
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = 0; i < count; i++)
            {
                this.RemoveAt(index);
            }
        }

        object ICloneable.Clone() => 
            this.Clone();

        public int Capacity =>
            this._mBuffer.Length;

        public int Count =>
            (this._headIdx != -1) ? ((this._headIdx <= this._tailIdx) ? ((this._tailIdx <= this._headIdx) ? 1 : (((this._mBuffer.Length - this._tailIdx) + this._headIdx) + 1)) : ((this._headIdx - this._tailIdx) + 1)) : 0;

        public bool IsEmpty =>
            this._headIdx == -1;

        public PointPair this[int index]
        {
            get
            {
                if ((index >= this.Count) || (index < 0))
                {
                    throw new ArgumentOutOfRangeException();
                }
                index += this._tailIdx;
                if (index >= this._mBuffer.Length)
                {
                    index -= this._mBuffer.Length;
                }
                return this._mBuffer[index];
            }
            set
            {
                if ((index >= this.Count) || (index < 0))
                {
                    throw new ArgumentOutOfRangeException();
                }
                index += this._tailIdx;
                if (index >= this._mBuffer.Length)
                {
                    index -= this._mBuffer.Length;
                }
                this._mBuffer[index] = value;
            }
        }
    }
}

