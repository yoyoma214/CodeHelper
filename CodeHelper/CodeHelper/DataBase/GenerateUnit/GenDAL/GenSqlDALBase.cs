using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;

namespace Generator.GenerateUnit.GenDAL
{
    class GenSqlDALBase:BaseGen
    {
        public static GenSqlDALBase CreateInstance(SqlType sql)
        {
            if (GlobalService.DbType == DatabaseType.SqlServer)
            {
                return new SqlServer.SqlGenSqlDAL(sql);
            }
            return null;
        }
        public static string GetModel(SqlType sql, string table)
        {
            foreach (var m in sql.MyModels)
            {
                if (m.ColumnSetName.Value.Equals(table))
                    return m.Name.Value;
            }
            return null;
        }
        public static string GetParamModel(SqlType sql, string tableName)
        {
            string result = GetModel(sql, tableName);
            result = result.Substring(0, 1).ToLower() + result.Substring(1) + "s";
            return result;
        }
        public static string GetListParameter(SqlType sql)
        {
            string parameters = null;
            if (IsPagerQuery(sql))
            {
                parameters +=
                    "int pageSize, int pageIndex, out int recordCount,";
            }
            foreach (SqlStatementType statment in sql.MySqlStatements)
            {
                parameters += "SearchConditionBuilder " + GetBuilderName(sql, statment.TableName.Value) + ", ";
                if (IsPagerQuery(sql))
                {
                    if (statment.TableName.Value.Equals(sql.PagerContentTable.Value) ||
                        statment.TableName.Value.Equals(sql.PagerRecordCountTable.Value))
                        continue;
                }
                parameters += "out IList<" + GetModel(sql, statment.TableName.Value) + "> " + GetParamModel(sql, statment.TableName.Value) + ",";
            }
            parameters = parameters.Trim();
            parameters = parameters.EndsWith(",") ? parameters.Substring(0, parameters.Length - 1) : parameters;
            return parameters;

        }
        public static bool IsPagerQuery(SqlType sql)
        {
            if (sql.HasPagerContentTable() && sql.HasPagerRecordCountTable())
            {
                return (!string.IsNullOrWhiteSpace(sql.PagerContentTable.Value) &&
                    !string.IsNullOrWhiteSpace(sql.PagerRecordCountTable.Value));
            }
            return false;
        }
        public static string GetBuilderName(SqlType sql, string tableName)
        {
            string result = GetModel(sql, tableName) ?? tableName;
            result = result.Substring(0, 1).ToLower() + result.Substring(1);
            result += "Builder";
            return result;
        }
    }
}
