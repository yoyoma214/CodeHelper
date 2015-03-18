using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Generator.DbSchema.Postgres
{
    public class SqlDbTypeProvider : DbTypeProvider
    {
        public override Type GetSystemType(DbType type)
        {
            return base.GetSystemType(type);
        }
        
        public override DbType GetDbType(string nativeType)
        {
            //if (nativeType == "serial")
            //{
            //    return DbType.Int32;
            //}
            //if (nativeType == "int4")
            //{
            //    return DbType.Int32;
            //}
            if (nativeType == "uniqueidentifier")
            {
                return DbType.Guid;
            }
            return base.GetDbType(nativeType);
        }
    }
}
