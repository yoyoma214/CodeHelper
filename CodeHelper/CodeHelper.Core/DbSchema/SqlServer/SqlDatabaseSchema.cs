using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;

namespace CodeHelper.DataBaseHelper.DbSchema.SqlServer
{
    public class SqlDatabaseSchema : DatabaseSchema
    {
        public override bool TestConnect()
        {
            string sql = "select 1";
            return SqlHelper.ExecuteScalar(this.ConnectionString, System.Data.CommandType.Text, sql) != null;
        }
    }
}
