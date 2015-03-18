using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using Generator.DbSchema.Postgres;
using CodeHelper.Persistence.Enums;
using CodeHelper.Core;

namespace Generator.DbSchema
{
    public class SchemaUtility
    {
        static Dictionary<DatabaseType, DbTypeProvider> DbTypeProviders;
        static SchemaUtility()
        {
            DbTypeProviders = new Dictionary<DatabaseType, DbTypeProvider>();
            DbTypeProviders.Add(DatabaseType.Postgres, new PostgresDbTypeProvider());
            DbTypeProviders.Add(DatabaseType.SqlServer, new SqlDbTypeProvider());
            DbTypeProviders.Add(DatabaseType.UnKnown, new DbTypeProvider());
        }

        public static Type GetSystemType(DatabaseType dbType, string nativeType)
        {
            return DbTypeProviders[dbType].GetSystemType(nativeType);
        }

        public static Type GetSystemType(DatabaseType dbType, DbType type)
        {
            return DbTypeProviders[dbType].GetSystemType(type);
        }

        public static DbType GetDbType(DatabaseType dbType, string nativeType)
        {
            return DbTypeProviders[dbType].GetDbType(nativeType);
        }

        public static string GetSpecifcDbType(DatabaseType dbType, string nativeType)
        {
            return DbTypeProviders[dbType].GetSpecifcDbType(dbType, nativeType);
        }
    }

}

