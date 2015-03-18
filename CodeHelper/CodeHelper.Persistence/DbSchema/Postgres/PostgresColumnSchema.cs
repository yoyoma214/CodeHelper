using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core;

namespace Generator.DbSchema.Postgres
{
    public class PostgresColumnSchema : ColumnSchema
    {
        public const string IDENT = "IsIdent";
        public PostgresColumnSchema() : base() { }
        public PostgresColumnSchema(bool isPK, string name, string dataType, string nativeType, int size, byte precision, int scale, bool allowDBNull)
            :base(isPK,name,dataType,nativeType,size,precision,scale,allowDBNull)
        {
            this.SystemType = SchemaUtility.GetSystemType(DatabaseType.Postgres, _nativeType);
        }
        /// <summary>
        /// 是否是表示字段
        /// </summary>
        public bool IsIdent
        {
            get;
            set;
        }
    }
}
