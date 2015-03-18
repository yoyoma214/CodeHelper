using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Microsoft.ApplicationBlocks.Data;
using Util;

namespace Generator.DbSchema.Access
{
    public class AccessDatabaseSchema : DatabaseSchema
    {
        public override bool TestConnect()
        {
            string sql = "select 1";
            //return SqlHelper.ExecuteScalar(this.ConnectionString, System.Data.CommandType.Text, sql) != null;            
            return AccessHelper.GetSingle(this.ConnectionString,sql) != null;
        }
    }
}
