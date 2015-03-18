using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CodeHelper.DataBaseHelper.DbSchema
{
    public class ColumnSchema
    {
        public ColumnSchema()
        {
            Expands = new List<KeyValuePair<string, string>>();
        }
        public ColumnSchema(bool isPK, string name, string dataType, string nativeType, int size, byte precision, int scale, bool allowDBNull)
            : this()
        {
            this._isPK = isPK;
            this._name = name;
            this._allowDBNull = allowDBNull;
            this._dataType = dataType;
            this._nativeType = nativeType;
            this._size = size;
            this._precision = precision;
            this._scale = scale;
        }
        protected string _name = null;
        public string Name { get { return this._name; } set { _name = value; } }
        // Fields
        protected bool _isPK;
        protected bool _allowDBNull;
        protected string _dataType;
        protected string _nativeType;
        protected int _precision;
        protected int _scale;
        protected int _size;
        public string ForeignKeyTable { get; set; }
        public string ForeignKeyColumn { get; set; }
        //public string IsVirtualFK { get; set; }

        // Properties
        public virtual bool IsPK
        {
            get { return this._isPK; }
            set { this._isPK = value; }
        }
        public virtual bool AllowDBNull { get { return _allowDBNull; } set { _allowDBNull = value; } }
        public virtual string DataType { get { return _dataType; } set { _dataType = value; } }
        public virtual string NativeType { get { return _nativeType; } set { _nativeType = value; } }
        public virtual int Precision { get { return _precision; } set { _precision = value; } }
        public virtual int Scale { get { return _scale; } set { _scale = value; } }
        public virtual int Size { get { return _size; } set { _size = value; } }

        private Type _systemType;
        public virtual Type SystemType
        {
            get
            {
                return _systemType;
            }
            set
            {
                _systemType = value;
            }
            //{
            //    return SchemaUtility.GetSystemType(SchemaUtility.GetDbType(this.NativeType));
            //}
        }
        public string Description
        {
            set;
            get;
        }

        public IList<KeyValuePair<string, string>> Expands
        {
            get;
            set;
        }
    }
}
