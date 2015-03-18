using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generator.Items.DBItems;
using Project;
using Generator.Items.SqlServer;
using Generator.DbSchema.SqlServer;

namespace Generator.GenerateUnit.GenDAL.SqlServer
{
    internal class SqlGenTableDAL : GenTableDALBase
    {
        TableType table = null;
        #region 属性
        ColumnSetType ColumnSet
        {
            get
            {
                return this.table.ColumnSet;
            }
        }
        ModelType Model
        {
            get
            {
                return this.table.Model;
            }
        }
        string ModelName
        {
            get
            {
                return this.Model.Name.Value;
            }
        }
        string TableName
        {
            get
            {
                return this.ColumnSet.Name.Value;
            }
        }
        string ParaModelName
        {
            get
            {
                return ModelName[0].ToString().ToLower() + ModelName.Substring(1);
            }
        }
        string ConnectionString { get; set; }
        #endregion
        internal SqlGenTableDAL(TableType table, string connectionString)
        {
            this.table = table;
            this.ConnectionString = connectionString;
        }        

        private FieldType GetMapField(string columnName)
        {
            foreach (FieldType f in this.Model.MyFields)
            {
                if (f.Name.Equals(columnName))
                    return f;
            }
            return null;
        }

        public override void Generate(StringBuilder builder)
        {
            builder.AppendLine("public class " + GetDalName(this.table.Name.Value));
            builder.AppendLine("{");
            builder.AppendLine();
            this.GenConnection(builder);
            builder.AppendLine();
            this.GenInsert(builder);
            builder.AppendLine();
            this.GenUpdate(builder);
            builder.AppendLine();
            this.GenDelete(builder);
            builder.AppendLine();
            this.GenGetOne(builder);
            builder.AppendLine();
            this.GenGetList(builder);
            builder.AppendLine();
            this.GenGetPageList(builder);
            builder.AppendLine();
            GenConvertToModel(builder, this.Model);
            builder.AppendLine();
            builder.AppendLine("}");
            base.Generate(builder);
        }

        private static bool IsIdentColumn(ColumnType column)
        {
            if (column.HasExpand())
            {
                foreach (ExpandType expand in column.MyExpands)
                {
                    if (expand.Key.Value.Equals(SqlColumnSchema.IDENT))
                    {
                        return expand.Val.BoolValue();                        
                    }
                }
            }
            return false;
        }

        protected virtual void GenInsert(StringBuilder builder)
        {
            string paraModel = this.table.Model.Name.Value;
            paraModel = paraModel[0].ToString().ToLower() + paraModel.Substring(1);
            builder.AppendLine(GeneratorUtil.TabString(1) + "public bool Insert(" + this.table.Model.Name.Value + " " + paraModel + ")");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            builder.AppendLine(GeneratorUtil.TabString(2) + "string sql = @\"INSERT INTO " + this.table.Name + "(");
            for (int index = 0; index < this.table.ColumnSet.ColumnCount; index++)
            {
                ColumnType column =this.table.ColumnSet.GetColumnAt(index);
                if ( IsIdentColumn(column))
                    continue;

                builder.Append(GeneratorUtil.TabString(2) + column.Name.Value);
                if (index != this.table.ColumnSet.ColumnCount - 1)
                {
                    builder.AppendLine(",");
                }
            }
            builder.AppendLine(") VALUES(");
            for (int index = 0; index < this.table.ColumnSet.ColumnCount; index++)
            {
                ColumnType column = this.table.ColumnSet.GetColumnAt(index);
                if (IsIdentColumn(column))
                    continue;

                builder.Append(GeneratorUtil.TabString(2) + "@" + this.table.ColumnSet.GetColumnAt(index).Name);
                if (index != this.table.ColumnSet.ColumnCount - 1)
                {
                    builder.AppendLine(",");
                }
            }
            builder.Append(");");
            var pks = GetPKColumn(this.ColumnSet);
            if (pks.Count == 1)
            {
                builder.AppendLine();
                builder.AppendLine(GeneratorUtil.TabString(2) + "SELECT SCOPE_IDENTITY();\";");
            }
            else
            {
                builder.AppendLine("\";");
            }
            builder.AppendLine(GeneratorUtil.TabString(2) + "SqlParameter[] sqlParamArray = new SqlParameter[] ");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            for (int i = 0; i < this.Model.FieldCount; i++)
            {
                FieldType field = this.Model.GetFieldAt(i);
                if (!string.IsNullOrWhiteSpace(field.ColumnName.Value))
                {
                    ColumnType column = GetColumn(this.table, field.ColumnName.Value);
                    if (IsIdentColumn(column))
                        continue;

                    builder.Append(GeneratorUtil.TabString(3) + "new SqlParameter(\"" + field.ColumnName + "\"," + paraModel + "." + field.Name + ")");
                    if (i < this.Model.FieldCount - 1)
                    {
                        builder.Append(",");
                    }
                    builder.AppendLine();
                }
            }
            builder.AppendLine(GeneratorUtil.TabString(2) + "};");
            if (pks.Count == 1)
            {
                builder.AppendLine(GeneratorUtil.TabString(2) + "object id = SqlHelper.ExecuteScalar(WriteConnection,CommandType.Text,sql,sqlParamArray);");
                builder.AppendLine(GeneratorUtil.TabString(2) + "if ( id != null ){ ");
                builder.AppendLine(GeneratorUtil.TabString(3) + paraModel + "." + pks[0].Name + " = (" + pks[0].SystemType + ")id;");
                builder.AppendLine(GeneratorUtil.TabString(2) + "}");
                builder.AppendLine(GeneratorUtil.TabString(2) + "return id != null;");
            }
            else
            {
                builder.AppendLine(GeneratorUtil.TabString(2) + "int i = SqlHelper.ExecuteNonQuery(WriteConnection,CommandType.Text,sql,sqlParamArray);");
                builder.AppendLine(GeneratorUtil.TabString(2) + "return i == 1;");
            }
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
        }

        private void GenUpdate(StringBuilder builder)
        {
            builder.AppendLine(GeneratorUtil.TabString(1) + @"public bool Update(" + this.ModelName + " " + this.ParaModelName + ")");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            builder.AppendLine(GeneratorUtil.TabString(2) + "string sql = @\"UPDATE " + this.TableName);
            builder.AppendLine(GeneratorUtil.TabString(2) + "SET");
            for (int i = 0; i < this.table.ColumnSet.ColumnCount; i++)
            {
                ColumnType column = this.ColumnSet.GetColumnAt(i);
                if (!column.IsPK.Value)
                {
                    var columnName = this.table.ColumnSet.GetColumnAt(i).Name.Value;
                    builder.Append(GeneratorUtil.TabString(2) + columnName + " = @" + columnName);
                    if (i < this.table.ColumnSet.ColumnCount - 1)
                    {
                        builder.Append(",");
                    }
                    builder.AppendLine();
                }
            }
            builder.AppendLine(GeneratorUtil.TabString(2) + "WHERE ");
            builder.Append(GeneratorUtil.TabString(2));
            List<ColumnType> PKCols = GetPKColumn(this.ColumnSet);
            for (int index = 0 ; index < PKCols.Count; index ++ )
            {
                ColumnType pkCol = PKCols[index];
                builder.Append( pkCol.Name + " = @" + pkCol.Name.Value);
                if ( index < PKCols.Count -1)
                    builder.Append( " and ");
            }
            
            builder.AppendLine("\";");

            builder.AppendLine(GeneratorUtil.TabString(2) + "SqlParameter[] sqlParams = ");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            //for (int i = 0; i < this.table.ColumnSet.ColumnCount; i++)
            //{
            for (int i = 0; i < this.Model.FieldCount; i++)
            {
                FieldType field = this.Model.GetFieldAt(i);
                if (!string.IsNullOrWhiteSpace(field.ColumnName.Value))
                {
                    builder.Append(GeneratorUtil.TabString(3) + "new SqlParameter(\"@" + field.ColumnName.Value + "\"," 
                        + this.ParaModelName + "." + field.Name.Value + ")");
                    if (i < this.ColumnSet.ColumnCount - 1)
                    {
                        builder.Append(",");
                    }
                    builder.AppendLine();
                }
            }
            builder.AppendLine(GeneratorUtil.TabString(2) + "};");
            builder.AppendLine(GeneratorUtil.TabString(2) + "int i = SqlHelper.ExecuteNonQuery(WriteConnection, CommandType.Text, sql, sqlParams);");
            builder.AppendLine(GeneratorUtil.TabString(2) + "return i == 1;");
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");

        }        

        private void GenDelete(StringBuilder builder)
        {
            List<ColumnType> pks = GetPKColumn(this.ColumnSet);
            builder.Append(GeneratorUtil.TabString(1) + @"public bool Delete(");
            for(int i = 0 ; i < pks.Count ; i ++ )
            {
                builder.Append(pks[i].SystemType.Value + " " + pks[i].Name.Value);
                if (i < pks.Count - 1)
                {
                    builder.Append(",");
                }
            }
            builder.AppendLine(")");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            builder.Append(GeneratorUtil.TabString(2) + "string sql = \"DELETE FROM " + this.TableName + " WHERE ");
            for (int i = 0; i < pks.Count; i++)
            {
                builder.Append(pks[i].Name.Value + " = @" + pks[i].Name.Value);
                if (i < pks.Count - 1)
                {
                    builder.Append(",");
                }
            }
            builder.AppendLine("\";");

            builder.AppendLine(GeneratorUtil.TabString(2) + "SqlParameter[] sqlParams = ");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            for (int i = 0; i < pks.Count; i++)
            {
                string pkName = pks[i].Name.Value;
                builder.Append(GeneratorUtil.TabString(3) + "new SqlParameter(\"@" + pkName + "\"," + pkName + ")");
                if (i < pks.Count - 1)
                {
                    builder.Append(",");
                }
                builder.AppendLine();
            }
            builder.AppendLine(GeneratorUtil.TabString(2) + "};");
            builder.AppendLine(GeneratorUtil.TabString(2) + "int i = SqlHelper.ExecuteNonQuery(WriteConnection, CommandType.Text, sql, sqlParams);");
            builder.AppendLine(GeneratorUtil.TabString(2) + "return i ==1;");
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
        }

        private void GenGetOne(StringBuilder builder)
        {
            List<ColumnType> pks = GetPKColumn(this.ColumnSet);
            builder.Append(GeneratorUtil.TabString(1) + "public " + this.ModelName + " Get" + this.ModelName + "(");
            for (int i = 0; i < pks.Count; i++)
            {
                builder.Append(pks[i].SystemType.Value + " " + pks[i].Name.Value);
                if (i < pks.Count - 1)
                {
                    builder.Append(",");
                }
            }
            builder.AppendLine(")");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            builder.Append(GeneratorUtil.TabString(2) + "string sql=@\"SELECT * FROM " + this.TableName + "(NOLOCK) WHERE ");
            for (int i = 0; i < pks.Count; i++)
            {
                string pkName = pks[i].Name.Value;
                builder.Append(pkName + "= @" + pkName);
                if (i < pks.Count - 1)
                {
                    builder.Append(",");
                }
            }
            builder.AppendLine("\";");
            builder.AppendLine(GeneratorUtil.TabString(2) + "SqlParameter[] sqlParams = ");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            for (int i = 0; i < pks.Count; i++)
            {
                string pkName = pks[i].Name.Value;
                builder.Append(GeneratorUtil.TabString(3) + "new SqlParameter(\"@" + pkName + "\"," + pkName + ")");
                if (i < pks.Count - 1)
                {
                    builder.Append(",");
                }
                builder.AppendLine();
            }
            builder.AppendLine(GeneratorUtil.TabString(2) + "};");
            builder.AppendLine(GeneratorUtil.TabString(2) + @"DataSet ds = SqlHelper.ExecuteDataset(ReadConnection, CommandType.Text, sql, sqlParams);");
            builder.AppendLine(GeneratorUtil.TabString(2) + "if (ds.Tables[0].Rows.Count == 1)");
            builder.AppendLine(GeneratorUtil.TabString(2) +"{");
            builder.AppendLine(GeneratorUtil.TabString(3) + "return " + GetConvertName(this.ModelName) + @"(ds.Tables[0].Rows[0]);");
            builder.AppendLine(GeneratorUtil.TabString(2) +"}");
            builder.AppendLine(GeneratorUtil.TabString(2) + "return null;");   
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
        }

        private void GenGetList(StringBuilder builder)
        {
            builder.AppendLine(GeneratorUtil.TabString(1) + "public IList<" + this.ModelName + "> GetList(SearchConditionBuilder builder)");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            builder.AppendLine(GeneratorUtil.TabString(2) + "string condition = string.Empty;");
            builder.AppendLine(GeneratorUtil.TabString(2) + "string order = string.Empty;");
            builder.AppendLine(GeneratorUtil.TabString(2) + "SqlParameter[] paramList = null;");
            builder.AppendLine();
            builder.AppendLine(GeneratorUtil.TabString(2) + "if (builder != null)");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            builder.AppendLine(GeneratorUtil.TabString(3) + "condition = builder.SqlString;");
            builder.AppendLine(GeneratorUtil.TabString(3) + "order = builder.OrderString;");
            builder.AppendLine(GeneratorUtil.TabString(3) + "paramList = builder.ParamList.ToArray();");
            builder.AppendLine(GeneratorUtil.TabString(2) + "}");

            builder.AppendLine(GeneratorUtil.TabString(2) + "StringBuilder query = new StringBuilder();");
            builder.AppendLine(GeneratorUtil.TabString(2) + "query.AppendFormat(\"SELECT * \");");
            builder.AppendLine(GeneratorUtil.TabString(2) + "query.AppendFormat(\"FROM " + this.TableName + "(NOLOCK) \");");
            builder.AppendLine(GeneratorUtil.TabString(2) + "if (!string.IsNullOrWhiteSpace(condition))");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            builder.AppendLine(GeneratorUtil.TabString(3) + "query.AppendFormat(\" WHERE {0} \", condition);");
            builder.AppendLine(GeneratorUtil.TabString(2) + "}");
            builder.AppendLine();
            builder.AppendLine(GeneratorUtil.TabString(2) + "if (!string.IsNullOrWhiteSpace(order))");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            builder.AppendLine(GeneratorUtil.TabString(3) + "query.AppendFormat(\" ORDER BY {0} \", order);");
            builder.AppendLine(GeneratorUtil.TabString(2) + "}");
            builder.AppendLine(GeneratorUtil.TabString(2) + "DataSet ds = SqlHelper.ExecuteDataset(");
            builder.AppendLine(GeneratorUtil.TabString(2) + "ReadConnection, CommandType.Text, query.ToString(), paramList);");
            builder.AppendLine(GeneratorUtil.TabString(2) + "List<" + this.ModelName + "> list = new List<" + this.ModelName + ">();");
            builder.AppendLine(GeneratorUtil.TabString(2) + "foreach (DataRow row in ds.Tables[0].Rows)");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            builder.AppendLine(GeneratorUtil.TabString(3) + "list.Add(" + GetConvertName(this.ModelName) + "(row));");
            builder.AppendLine(GeneratorUtil.TabString(2) + "}");
            builder.AppendLine(GeneratorUtil.TabString(2) + "return list;");
            //builder.AppendLine(GeneratorUtil.TabString(2) + ");");
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
        }

        private void GenGetPageList(StringBuilder builder)
        {
            builder.AppendLine(GeneratorUtil.TabString(1) + "public IList<" + this.ModelName + ">  GetPageList(int pageSize, int pageIndex, out int recordCount, SearchConditionBuilder builder)");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            builder.AppendLine(GeneratorUtil.TabString(2) + "int startIndex = (pageIndex-1) * pageSize + 1;");
            builder.AppendLine(GeneratorUtil.TabString(2) + "int endIndex = pageIndex * pageSize;");
            builder.AppendLine();
            builder.AppendLine(GeneratorUtil.TabString(2) + "string condition = string.Empty;");
            builder.AppendLine(GeneratorUtil.TabString(2) + "string order = string.Empty;");
            builder.AppendLine(GeneratorUtil.TabString(2) + "SqlParameter[] paramList = null;");
            builder.AppendLine();
            builder.AppendLine(GeneratorUtil.TabString(2) + "if (builder != null)");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            builder.AppendLine(GeneratorUtil.TabString(2) + "condition = builder.SqlString;");
            builder.AppendLine(GeneratorUtil.TabString(2) + "order = builder.OrderString;");
            builder.AppendLine(GeneratorUtil.TabString(2) + "paramList = builder.ParamList.ToArray();");
            builder.AppendLine(GeneratorUtil.TabString(2) + "}");
            builder.AppendLine(GeneratorUtil.TabString(2) + "if (string.IsNullOrWhiteSpace(order))");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            builder.AppendLine(GeneratorUtil.TabString(3) + "order = \"" + this.GetDefaultOrderString() + "\";");
            builder.AppendLine(GeneratorUtil.TabString(2) + "}");
            builder.AppendLine(GeneratorUtil.TabString(2) + "StringBuilder query = new StringBuilder();");
            builder.AppendLine(GeneratorUtil.TabString(2) + "query.AppendFormat(\"SELECT * \");");
            builder.AppendLine(GeneratorUtil.TabString(2) + "query.AppendFormat(\"FROM \");");
            builder.AppendLine(GeneratorUtil.TabString(2) + "query.AppendFormat(\"( \");");
            builder.AppendLine(GeneratorUtil.TabString(2) + "query.AppendFormat(\"    SELECT ROW_NUMBER() OVER(ORDER BY {0} ) SN,* \", order);");
            builder.AppendLine(GeneratorUtil.TabString(2) + "query.AppendFormat(\"    FROM " + this.TableName + "(NOLOCK) \");");
            builder.AppendLine(GeneratorUtil.TabString(2) + "if (!string.IsNullOrWhiteSpace(condition))");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            builder.AppendLine(GeneratorUtil.TabString(3) + "query.AppendFormat(\" WHERE {0} \", condition);");
            builder.AppendLine(GeneratorUtil.TabString(2) + "}");
            builder.AppendLine(GeneratorUtil.TabString(2) + "query.AppendFormat(\") T \");");
            builder.AppendLine(GeneratorUtil.TabString(2) + "query.AppendFormat(\"WHERE T.SN BETWEEN {0} AND {1};\", startIndex, endIndex);");
            builder.AppendLine(GeneratorUtil.TabString(2) + "//获取记录条数");
            builder.AppendLine(GeneratorUtil.TabString(2) + "query.AppendFormat(\"SELECT COUNT(1) FROM " + this.TableName + "(NOLOCK) \");");
            builder.AppendLine(GeneratorUtil.TabString(2) + "if (!string.IsNullOrWhiteSpace(condition))");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            builder.AppendLine(GeneratorUtil.TabString(3) + "query.AppendFormat(\" WHERE {0} \", condition);");
            builder.AppendLine(GeneratorUtil.TabString(2) + "}");
            builder.AppendLine(GeneratorUtil.TabString(2) + "DataSet ds = SqlHelper.ExecuteDataset(");
            builder.AppendLine(GeneratorUtil.TabString(2) + "ReadConnection, CommandType.Text, query.ToString(), paramList);");
            builder.AppendLine();
            builder.AppendLine(GeneratorUtil.TabString(2) + "recordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);");
            builder.AppendLine();
            builder.AppendLine(GeneratorUtil.TabString(2) + "IList<" + this.ModelName + "> list = new List<" + this.ModelName + ">();");
            builder.AppendLine();
            builder.AppendLine(GeneratorUtil.TabString(2) + "foreach (DataRow row in ds.Tables[0].Rows)");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            builder.AppendLine(GeneratorUtil.TabString(3) + "list.Add(" + GetConvertName(this.ModelName) + "(row));");
            builder.AppendLine(GeneratorUtil.TabString(2) + "}");
            builder.AppendLine();
            builder.AppendLine(GeneratorUtil.TabString(2) + "return list;");
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
        }

        private void GenConnection(StringBuilder builder)
        {
            builder.AppendLine(GeneratorUtil.TabString(1) + @"/// <summary>");
            builder.AppendLine(GeneratorUtil.TabString(1) + "/// 只读数据库连接");
            builder.AppendLine(GeneratorUtil.TabString(1) + "/// </summary>");
            builder.AppendLine(GeneratorUtil.TabString(1) + @"private static string ReadConnection");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            builder.AppendLine(GeneratorUtil.TabString(2) +  "get { return \"" +this.ConnectionString +"\"; }");            
            builder.AppendLine(GeneratorUtil.TabString(1) +"}");
            builder.AppendLine();
            builder.AppendLine(GeneratorUtil.TabString(1) + @"/// <summary>");
            builder.AppendLine(GeneratorUtil.TabString(1) +"/// 可写数据库连接");
            builder.AppendLine(GeneratorUtil.TabString(1) + "/// </summary>");
            builder.AppendLine(GeneratorUtil.TabString(1) + "private static string WriteConnection");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            builder.AppendLine(GeneratorUtil.TabString(2) + "get { return \"" + this.ConnectionString + "\"; }");            
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
        }

        private string GetDefaultOrderString()
        {
            List<ColumnType> pks = GetPKColumn(this.ColumnSet);
            if (pks.Count == 0)
                return "";
            string order = " ";
            for (int i = 0; i < pks.Count; i++)
            {
                order += pks[i].Name + " desc ";
                if (i < pks.Count - 1)
                    order += ",";
            }
            return order;

        }

        public static string GetConvertName(string ModelName)
        {
            return "ConvertTo" + ModelName;
        }

        public static void GenConvertToModel(StringBuilder builder, ModelType Model)
        {                        
            string ModelName = Model.Name.Value;

            builder.AppendLine(GeneratorUtil.TabString(1) + @"public static " + ModelName + " " + GetConvertName(Model.Name.Value) + "(DataRow row )");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            builder.AppendLine(GeneratorUtil.TabString(2)   + ModelName + " info = new " + ModelName + "();");
            foreach (FieldType field in Model.MyFields)
            {
                string systemType = field.SystemType.Value;
                string fieldName = field.Name.Value;
                string columnName = field.ColumnName.Value;

                builder.AppendLine(GeneratorUtil.TabString(2) + "if ( row[\"" + columnName + "\"] == DBNull.Value)");
                builder.AppendLine(GeneratorUtil.TabString(2) + "{");
                if (!field.NullAble.Value)
                {
                    builder.AppendLine(GeneratorUtil.TabString(3) + "info." + fieldName + " = default(" + systemType + ");");
                }
                builder.AppendLine(GeneratorUtil.TabString(2) + "}");
                builder.AppendLine(GeneratorUtil.TabString(2) + "else");
                builder.AppendLine(GeneratorUtil.TabString(2) + "{");
                builder.AppendLine(GeneratorUtil.TabString(3) + "info." + fieldName + " = (" + systemType + ")row[\"" + columnName + "\"];");
                builder.AppendLine(GeneratorUtil.TabString(2) + "}");
            }
            builder.AppendLine(GeneratorUtil.TabString(2) + "return info;");
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
        }
    }
}
