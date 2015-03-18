using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Generator.DbSchema.DbSchemaProvider
{
    public abstract class BaseDbSchemaProvider : IDbSchemaProvider
    {
        #region IDbSchemaProvider 成员

        public string Description
        {
            protected set;
            get;
        }

        public string Name
        {
            protected set;
            get;
        }

        public string GetDatabaseName(string connectionString)
        {
            throw new NotImplementedException();
        }

        public abstract ColumnSchema[] GetTableColumns(string connectionString, TableSchema table);


        public abstract TableSchema[] GetTables(string connectionString, DatabaseSchema database);

        public string ConnectionString
        {
            internal set;
            get;
        }

        public abstract TableSchema GetTable(string connectionString, string name)
      ;

        #endregion

        public virtual DbType? GetDbType(string nativeType)
        {
            return null;
        }

        public virtual Type GetSystemType(DbType type)
        {
            return null;
        }
    }
}
