namespace ZedGraph
{
    using System;
    using System.Data;
    using System.Reflection;
    using System.Windows.Forms;

    [Serializable]
    public class DataSourcePointList : IPointList, ICloneable
    {
        private System.Windows.Forms.BindingSource _bindingSource;
        private string _xDataMember;
        private string _yDataMember;
        private string _zDataMember;
        private string _tagDataMember;

        public DataSourcePointList()
        {
            this._bindingSource = new System.Windows.Forms.BindingSource();
            this._xDataMember = string.Empty;
            this._yDataMember = string.Empty;
            this._zDataMember = string.Empty;
            this._tagDataMember = string.Empty;
        }

        public DataSourcePointList(DataSourcePointList rhs) : this()
        {
            this._bindingSource.DataSource = rhs._bindingSource.DataSource;
            if (rhs._xDataMember != null)
            {
                this._xDataMember = (string) rhs._xDataMember.Clone();
            }
            if (rhs._yDataMember != null)
            {
                this._yDataMember = (string) rhs._yDataMember.Clone();
            }
            if (rhs._zDataMember != null)
            {
                this._zDataMember = (string) rhs._zDataMember.Clone();
            }
            if (rhs._tagDataMember != null)
            {
                this._tagDataMember = (string) rhs._tagDataMember.Clone();
            }
        }

        public DataSourcePointList Clone() => 
            new DataSourcePointList(this);

        private double GetDouble(object row, string dataMember, int index)
        {
            if ((dataMember == null) || (dataMember == string.Empty))
            {
                return (double) (index + 1);
            }
            DataRowView view = row as DataRowView;
            PropertyInfo property = null;
            if (view == null)
            {
                property = row.GetType().GetProperty(dataMember);
            }
            object obj2 = null;
            if (property != null)
            {
                obj2 = property.GetValue(row, null);
            }
            else if (view != null)
            {
                obj2 = view[dataMember];
            }
            else if (property == null)
            {
                throw new Exception("Can't find DataMember '" + dataMember + "' in DataSource");
            }
            return (((obj2 == null) || (obj2 == DBNull.Value)) ? double.MaxValue : (!ReferenceEquals(obj2.GetType(), typeof(DateTime)) ? (!ReferenceEquals(obj2.GetType(), typeof(string)) ? Convert.ToDouble(obj2) : ((double) (index + 1))) : ((DateTime) obj2).ToOADate()));
        }

        private object GetObject(object row, string dataMember)
        {
            if ((dataMember == null) || (dataMember == string.Empty))
            {
                return null;
            }
            PropertyInfo property = row.GetType().GetProperty(dataMember);
            DataRowView view = row as DataRowView;
            object obj2 = null;
            if (property != null)
            {
                obj2 = property.GetValue(row, null);
            }
            else if (view != null)
            {
                obj2 = view[dataMember];
            }
            if (obj2 == null)
            {
                throw new Exception("Can't find DataMember '" + dataMember + "' in DataSource");
            }
            return obj2;
        }

        object ICloneable.Clone() => 
            this.Clone();

        public PointPair this[int index]
        {
            get
            {
                if ((index < 0) || (index >= this._bindingSource.Count))
                {
                    throw new ArgumentOutOfRangeException("Error: Index out of range");
                }
                object row = this._bindingSource[index];
                return new PointPair(this.GetDouble(row, this._xDataMember, index), this.GetDouble(row, this._yDataMember, index), this.GetDouble(row, this._zDataMember, index)) { Tag = this.GetObject(row, this._tagDataMember) };
            }
        }

        public int Count =>
            (this._bindingSource == null) ? 0 : this._bindingSource.Count;

        public System.Windows.Forms.BindingSource BindingSource =>
            this._bindingSource;

        public object DataSource
        {
            get => 
                this._bindingSource.DataSource;
            set => 
                this._bindingSource.DataSource = value;
        }

        public string XDataMember
        {
            get => 
                this._xDataMember;
            set => 
                this._xDataMember = value;
        }

        public string YDataMember
        {
            get => 
                this._yDataMember;
            set => 
                this._yDataMember = value;
        }

        public string ZDataMember
        {
            get => 
                this._zDataMember;
            set => 
                this._zDataMember = value;
        }

        public string TagDataMember
        {
            get => 
                this._tagDataMember;
            set => 
                this._tagDataMember = value;
        }
    }
}

