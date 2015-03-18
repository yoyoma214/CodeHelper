using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Microsoft.ApplicationBlocks.Data;
using System.Data.OleDb;
using Generator.DbSchema.DbSchemaProvider;

namespace Generator.DbSchema.SqlServer
{
    public class SqlSchemaProvider : BaseDbSchemaProvider
    {
        public override ColumnSchema[] GetTableColumns(string connectionString, TableSchema table)
        {
            throw new NotImplementedException();
        }

        public override TableSchema[] GetTables(string connectionString, DatabaseSchema database)
        {
            List<TableSchema> tableSchemas = new List<TableSchema>();
            OleDbConnection oleConn = new OleDbConnection();
            oleConn.ConnectionString = "Provider=SQLOLEDB;" + connectionString;

            using (SqlConnection conn = new SqlConnection())
            {
                this.ConnectionString = connectionString;

                string[] restrictions = new string[4];

                restrictions[1] = "dbo";
                conn.ConnectionString = connectionString;
                conn.Open();


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
        private TableSchema GetTable(string tableName,SqlConnection conn, OleDbConnection pkConn ,
            Dictionary<string,ForeignKeyInfo> fkOneTable)
        {
            string[] restrictions = new string[4];

            restrictions[1] = "dbo";
            restrictions[2] = tableName;            

            DataTable tt = conn.GetSchema("Tables", restrictions);
            if (tt.Rows.Count == 0)
                return null;
            TableSchema tableSchema = new SqlTableSchema();
            tableSchema.Name = tt.Rows[0]["TABLE_NAME"].ToString();
            tableSchema.IsView = tt.Rows[0]["TABLE_TYPE"].ToString().Equals("VIEW", StringComparison.OrdinalIgnoreCase);
            restrictions = new string[4];
            restrictions[1] = "dbo";
            restrictions[2] = tableSchema.Name;

            DataTable ff = conn.GetSchema("Columns", restrictions);
            restrictions[2] = tableSchema.Name;
            if (pkConn.State == ConnectionState.Closed)
            {
                pkConn.Open();
            }
            List<string> pkColumns = new List<string>();
            string[] parameters = new string[] { conn.Database, "dbo", tableSchema.Name };
            DataTable pkTable = pkConn.GetOleDbSchemaTable(OleDbSchemaGuid.Primary_Keys, parameters);
            pkConn.Close();

            foreach (DataRow indexRow in pkTable.Rows)
            {
                pkColumns.Add(indexRow["column_name"].ToString());
            }
            string sql = string.Format(@"
select COLUMNPROPERTY(a.id, a.name, 'IsIdentity') as IsIdentity,
       a.name
       ,g.value
  from syscolumns a
 inner join systypes b on a.xtype = b.xusertype
 inner join sysobjects d on a.id = d.id
                        and d.xtype = 'U'
 left join sys.extended_properties g on d.id = g.major_id and a.colid = g.minor_id
 where d.name = '{0}'", tableName);
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);
            Dictionary<string, bool> dict_IsIdentity = new Dictionary<string, bool>();
            Dictionary<string,string> dict_Description = new Dictionary<string,string>();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                dict_IsIdentity.Add((string)row["name"], row["IsIdentity"].Equals(1)?true:false);
                if (row["Value"] != DBNull.Value)
                {
                    dict_Description.Add((string)row["name"], (string)row["Value"]);
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

                SqlColumnSchema columnSchema = new SqlColumnSchema(
                    pkColumns.Contains(name), name, dataType, nativeType, size, precision, scale, allowDBNull);
                tableSchema.Columns.Add(columnSchema);

                columnSchema.IsIdent = dict_IsIdentity.ContainsKey(name)?dict_IsIdentity[name]:false;
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
            OleDbConnection oleConn = new OleDbConnection();
            oleConn.ConnectionString = "Provider=SQLOLEDB;" + connectionString;
            TableSchema tableSchema = null;

            using (SqlConnection conn = new SqlConnection())
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
        private Dictionary<string, Dictionary<string,ForeignKeyInfo>> GetForeignKeys(SqlConnection conn, List<string> tableNames)
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
            DataSet ds = SqlHelper.ExecuteDataset(conn, CommandType.Text, sql);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ForeignKeyInfo fk = new ForeignKeyInfo()
                {
                    Constraint_Name = row["CConstraint_Name"].ToString(),
                    FK_Column = row["FK_Column"].ToString(),
                    FK_Table = row["FK_Table"].ToString(),
                    PK_Column = row["PK_Column"].ToString(),
                    PK_Table = row["PKPK_Table"].ToString()
                };
                Dictionary<string,ForeignKeyInfo> fks_table = null;                
                if ( fks.ContainsKey(fk.FK_Table))
                {
                    fks_table = fks[fk.FK_Table];
                }
                else{
                    fks_table = new Dictionary<string,ForeignKeyInfo>();
                    fks.Add(fk.FK_Table,fks_table);
                }
                fks_table.Add(fk.FK_Column,fk);
            }
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