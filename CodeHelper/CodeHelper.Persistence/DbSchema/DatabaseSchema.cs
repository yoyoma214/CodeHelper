using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generator.DbSchema.DbSchemaProvider;
using Generator.DbSchema.SqlServer;
using Generator.DbSchema.Access;
using Generator.DbSchema.Postgres;
using CodeHelper.Persistence;
using CodeHelper.Persistence.Enums;
using CodeHelper.Core;

namespace Generator.DbSchema
{
    public abstract class DatabaseSchema
    {
        public IDbSchemaProvider Provider { get; set; }
        IList<TableSchema> _Tables = new List<TableSchema>();
        public IList<TableSchema> Tables
        {
            get
            {
                return this.Provider.GetTables(this.ConnectionString, this);
            }
        }

        string _ConnectionString;
        public string ConnectionString
        {
            get
            {
                return this._ConnectionString;
            }
            set
            {
                this._ConnectionString =value;
            }
        }

        public TableSchema GetTable(string name)
        {
            return this.Provider.GetTable(this.ConnectionString, name);
        }
        //public static DatabaseSchema CreateInstance()
        //{
        //    return CreateInstance(GlobalService.DbType);
        //}
        public static DatabaseSchema CreateInstance(DatabaseType dbType)
        {
            if (dbType == DatabaseType.SqlServer)
            {
                SqlDatabaseSchema schema =new SqlDatabaseSchema();
                schema.Provider = new SqlSchemaProvider();
                return schema;
            }
            if (dbType == DatabaseType.Access)
            {
                AccessDatabaseSchema schema = new AccessDatabaseSchema();
                schema.Provider = new AccessSchemaProvider();
                return schema;
            }
            if (dbType == DatabaseType.Postgres)
            {
                var schema = new PostgresDatabaseSchema();
                schema.Provider = new PostgresSchemaProvider();
                return schema;
            }
            return null;
        }
        public virtual bool TestConnect()
        {
            return true;
        }
    }
}
