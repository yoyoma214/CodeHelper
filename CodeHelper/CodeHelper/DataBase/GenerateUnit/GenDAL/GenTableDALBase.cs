using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;

namespace Generator.GenerateUnit.GenDAL
{
    abstract class GenTableDALBase : BaseGen
    {
        public static GenTableDALBase CreateInstance(TableType table, string connectionString)
        {
            if (GlobalService.DbType == DatabaseType.SqlServer)
            {
                return new SqlServer.SqlGenTableDAL(table, connectionString);
            }
            return null;
        }
        public static string GetDalName(string tableName)
        {
            return tableName.Substring(0, 1).ToUpper() + tableName.Substring(1) + "DAL";
        }
        public static List<ColumnType> GetPKColumn(ColumnSetType columnSet)
        {
            List<ColumnType> pks = new List<ColumnType>();
            foreach (ColumnType column in columnSet.MyColumns)
            {
                if (column.IsPK.Value)
                    pks.Add(column);
            }
            return pks;
        }
        public static ColumnType GetColumn(TableType table, string column)
        {
            foreach (ColumnType col in table.ColumnSet.MyColumns)
            {
                if (string.Equals(col.Name.Value, column, StringComparison.InvariantCultureIgnoreCase))
                    return col;
            }
            return null;
        }
    }
}
