using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
//using Microsoft.ApplicationBlocks.Data;
using Npgsql;
using Generator.DbSchema.DbSchemaProvider;
using System.Data.OleDb;

namespace Generator.DbSchema.Postgres
{
    public class PostgresSchemaProvider : BaseDbSchemaProvider
    {
        public override ColumnSchema[] GetTableColumns(string connectionString, TableSchema table)
        {
            throw new NotImplementedException();
        }

        public override TableSchema[] GetTables(string connectionString, DatabaseSchema database)
        {
            List<TableSchema> tableSchemas = new List<TableSchema>();
            var oleConn = new NpgsqlConnection();
            oleConn.ConnectionString =  connectionString;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                this.ConnectionString = connectionString;

                string[] restrictions = new string[4];
                restrictions[0] = conn.Database;
                restrictions[1] = "public";
                conn.ConnectionString = connectionString;
                conn.Open();

                //var s = conn.GetSchema("Tables",new string[] { conn.Database, "public", null, null });
                List<string> tableNames = new List<string>();
                Dictionary<string, Dictionary<string, ForeignKeyInfo>> fkMap = null;

                DataTable tt = conn.GetSchema("Tables", restrictions);
                foreach (DataRow tRow in tt.Rows)
                {
                    tableNames.Add(tRow[2].ToString());                   
                }
                
                fkMap = this.GetForeignKeys(
                       conn, tableNames);

                foreach (DataRow tRow in tt.Rows)
                {
                    var tableName = tRow[2].ToString();
                    tableSchemas.Add(this.GetTable(tableName, conn, oleConn, fkMap.ContainsKey(tableName) ? fkMap[tableName] : null));
                }
                oleConn.Close();
                //tt.WriteXml("1.xml");
            }
            return tableSchemas.ToArray();
        }
        private TableSchema GetTable(string tableName, NpgsqlConnection conn, NpgsqlConnection pkConn,
            Dictionary<string,ForeignKeyInfo> fkOneTable)
        {
            string[] restrictions = new string[4];

            restrictions[0] = conn.Database;
            restrictions[1] = "public";
            restrictions[2] = tableName;            

            DataTable tt = conn.GetSchema("Tables", restrictions);
            if (tt.Rows.Count == 0)
                return null;
            TableSchema tableSchema = new PostgresTableSchema();
            tableSchema.Name = tt.Rows[0]["TABLE_NAME"].ToString();
            restrictions = new string[4];
            restrictions[0] = conn.Database;
            restrictions[1] = "public";
            restrictions[2] = tableSchema.Name;

            DataTable ff = conn.GetSchema("Columns", restrictions);
            restrictions[2] = tableSchema.Name;
            //if (pkConn.State == ConnectionState.Closed)
            //{
            //    pkConn.Open();
            //}
            //List<string> pkColumns = new List<string>();
            //string[] parameters = new string[] { conn.Database, "public", tableSchema.Name };
            //DataTable pkTable = pkConn.GetSchema("Index", parameters);
            ////pkConn.Close();

            //foreach (DataRow indexRow in pkTable.Rows)
            //{
            //    pkColumns.Add(indexRow["column_name"].ToString());
            //}
            string sql = string.Format(@"
select a.attname as column_name,
(case
when atttypmod-4>0 then atttypmod-4
else 0
end)CHARACTER_MAXIMUM_LENGTH,
(case
when (select count(*) from pg_constraint where conrelid = a.attrelid and conkey[1]=attnum and contype='p')>0  then 'Y'
else 'N'
end) as P,
(case
when (select count(*) from pg_constraint where conrelid = a.attrelid and conkey[1]=attnum and contype='u')>0  then 'Y'
else 'N'
end) as U,
(case
when (select count(*) from pg_constraint where conrelid = a.attrelid and conkey[1]=attnum and contype='f')>0  then 'Y'
else 'N'
end) as R,
(case
when a.attnotnull=true  then 'Y'
else 'N'
end) as nullable,
col_description(a.attrelid,a.attnum) as comment,'XEditText' as control,
c.relname,a.attname as column_name, (case
when a.attnotnull=true  then 'Y'
else 'N'
end) as IS_NULLABLE,format_type(a.atttypid,a.atttypmod)  as data_type,0 as NUMERIC_PRECISION,0 as NUMERIC_SCALE,0 as CHARACTER_OCTET_LENGTH,
'' as Value
from  pg_attribute a inner join pg_class c on a.attrelid = c.oid where c.relname ='{0}' and a.attstattarget = -1", tableName);
            DataSet ds = PostgresSqlHelper.ExecuteDataset(conn, CommandType.Text, sql);
            Dictionary<string, bool> dict_IsIdentity = new Dictionary<string, bool>();
            Dictionary<string,string> dict_Description = new Dictionary<string,string>();
            List<string> pkColumns = new List<string>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dict_IsIdentity.Add((string)row["COLUMN_NAME"], false);
                if (row["COMMENT"] != DBNull.Value)
                {
                    dict_Description.Add((string)row["COLUMN_NAME"], (string)row["COMMENT"]);
                }
                if (row["P"] != DBNull.Value && row["P"].ToString() == "Y")
                {
                    pkColumns.Add((string)row["COLUMN_NAME"]);
                }
            }

            foreach (DataRow fRow in ff.Rows)
            {
                string name = fRow["COLUMN_NAME"].ToString();
                bool allowDBNull = fRow["IS_NULLABLE"].ToString().Equals("NO") ? false : true;
                string dataType = fRow["DATA_TYPE"].ToString();
                string nativeType = fRow["DATA_TYPE"].ToString();
                byte precision = 0;
                byte.TryParse(fRow["NUMERIC_PRECISION"].ToString(), out precision);

                int scale = 0;
                int.TryParse(fRow["NUMERIC_SCALE"].ToString(), out scale);

                int size = 0;
                int.TryParse(fRow["CHARACTER_MAXIMUM_LENGTH"].ToString(), out size);
                if (size == 0)
                {
                    int.TryParse(fRow["CHARACTER_OCTET_LENGTH"].ToString(), out size);
                }
                bool isPk = pkColumns.Contains(name);

                PostgresColumnSchema columnSchema = new PostgresColumnSchema(
                    isPk, name, dataType, nativeType, size, precision, scale, allowDBNull);
                tableSchema.Columns.Add(columnSchema);

                columnSchema.IsIdent = fRow["column_default"] != DBNull.Value ? 
                    fRow["column_default"].ToString().StartsWith("nextval('") : false;
                columnSchema.Description = dict_Description.ContainsKey(name) ? dict_Description[name] : "";

                if (fkOneTable != null)
                {
                    if (fkOneTable.ContainsKey(columnSchema.Name))
                    {
                        ForeignKeyInfo fkInfo = fkOneTable[columnSchema.Name];
                        columnSchema.ForeignKeyTable = fkInfo.FK_Table;
                        columnSchema.ForeignKeyColumn = fkInfo.FK_Column;
                    }
                }
            }
            //获得外键
            //DataTable fk = conn.GetSchema("ForeignKeys", restrictions);
            //foreach (DataRow fkRow in fk.Rows)
            //{
            //    fk.WriteXml("1.xml");
            //}
            return tableSchema;
        }
        public override TableSchema GetTable(string connectionString, string tableName)
        {
            var oleConn = new NpgsqlConnection();
            oleConn.ConnectionString = connectionString;
            TableSchema tableSchema = null;

            using (var conn = new NpgsqlConnection())
            {
                this.ConnectionString = connectionString;            
                conn.ConnectionString = connectionString;
                conn.Open();
                oleConn.Open();
                Dictionary<string, Dictionary<string, ForeignKeyInfo>> fkMap = this.GetForeignKeys(
                    conn, new List<string>() { tableName });
                tableSchema = this.GetTable(tableName, conn, oleConn, fkMap.ContainsKey(tableName)?fkMap[tableName]:null);
                oleConn.Close();
            }
            return tableSchema;
        }
        private Dictionary<string, Dictionary<string, ForeignKeyInfo>> GetForeignKeys(NpgsqlConnection conn, List<string> tableNames)
        {
            string tables = "";
            foreach (string t in tableNames)
            {
                tables += "'" + t + "',";
            }
            tables = tables.EndsWith(",")?tables.Substring(0,tables.Length-1):tables; 
            
            string sql = @"SELECT   
                            FK_Table = FK.TABLE_NAME,   
                            FK_Column = CU.COLUMN_NAME,   
                            PKPK_Table = PK.TABLE_NAME,   
                            PK_Column = PT.COLUMN_NAME,   
                            CConstraint_Name = C.CONSTRAINT_NAME   
                            FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C   
                            INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME   
                            INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME   
                            INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME   
                            INNER JOIN (   
                            SELECT i1.TABLE_NAME, i2.COLUMN_NAME   
                            FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1   
                            INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME   
                            WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'   
                            ) PT ON PT.TABLE_NAME = PK.TABLE_NAME   ";
            if ( !tables.Equals(""))
            {
                sql += "WHERE FK.TABLE_NAME IN (" + tables + ")";
            }
            Dictionary<string, Dictionary<string,ForeignKeyInfo>> fks = new Dictionary<string, Dictionary<string,ForeignKeyInfo>>();
            return fks;
        }
        /// <summary>
        /// 外键约束信息
        /// </summary>
        protected class ForeignKeyInfo
        {
            public string FK_Table { get; set; }
            public string FK_Column { get; set; }
            public string PK_Table { get; set; }
            public string PK_Column { get; set; }
            public string Constraint_Name { get; set; }
        }
    }
}