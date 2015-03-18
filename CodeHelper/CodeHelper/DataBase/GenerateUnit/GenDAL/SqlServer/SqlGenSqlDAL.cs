using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using System.Data;

namespace Generator.GenerateUnit.GenDAL.SqlServer
{
    class SqlGenSqlDAL : GenSqlDALBase
    {
        SqlType Sql;
        Dictionary<string,ModelType> models = new Dictionary<string,ModelType>();
        string pagerContentModelName { get; set; }
        string pagerContentTableName { get; set; }
        string pagerRecordCountTableName { get; set; }
        string returnModelName { get; set; }
        
        public SqlGenSqlDAL(SqlType sql)
        {
            this.Sql = sql;
 
            pagerContentModelName = sql.HasPagerContentTable() ? sql.PagerContentTable.Value : null;
            pagerContentModelName = GetModel(this.Sql,pagerContentModelName)??null;
            pagerContentTableName = sql.HasPagerContentTable() ? sql.PagerContentTable.Value : null;
            pagerRecordCountTableName = sql.HasPagerRecordCountTable() ? sql.PagerRecordCountTable.Value : null;
            returnModelName = pagerContentModelName ?? this.Sql.Model.Name.Value;
            foreach (ModelType m in sql.MyModels)
            {
                this.models.Add(m.Name.Value, m);
            }
        }
        private string GetReturnModelParam()
        {
            if (IsPagerQuery(this.Sql))
                return GetParamModel(this.Sql,this.pagerContentTableName);
            return this.returnModelName.Substring(0,1).ToLower() + this.returnModelName.Substring(1) + "s";
        }
        
        public override void Generate(StringBuilder builder)
        {
            builder.AppendLine(GeneratorUtil.TabString(1) + "public IList<" + this.returnModelName + ">  " + this.Sql.Name.Value +"(" + GetListParameter(this.Sql) + ")");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            if (IsPagerQuery(this.Sql))
            {
                builder.AppendLine(GeneratorUtil.TabString(2) + "int startIndex = (pageIndex - 1) * pageSize + 1;");
                builder.AppendLine(GeneratorUtil.TabString(2) + "int endIndex = pageIndex * pageSize;");
            }
            builder.AppendLine(GeneratorUtil.TabString(2) + "string condition = string.Empty;");
            builder.AppendLine(GeneratorUtil.TabString(2) + "string order = string.Empty;");
            builder.AppendLine(GeneratorUtil.TabString(2) + "SqlParameter[] paramList = null;");
            builder.AppendLine(GeneratorUtil.TabString(2) + "if (builder != null)");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            builder.AppendLine(GeneratorUtil.TabString(3) + "condition = builder.SqlString;");
            builder.AppendLine(GeneratorUtil.TabString(3) + "order = builder.OrderString;");
            builder.AppendLine(GeneratorUtil.TabString(3) + "paramList = builder.ParamList.ToArray();");
            builder.AppendLine(GeneratorUtil.TabString(2) + "}");
            builder.AppendLine(GeneratorUtil.TabString(2) + "if (string.IsNullOrWhiteSpace(order))");
            builder.AppendLine(GeneratorUtil.TabString(2) + "{");
            builder.AppendLine(GeneratorUtil.TabString(3) + "order = \"XXXXXX DESC\";");
            builder.AppendLine(GeneratorUtil.TabString(2) + "}");                        
            builder.AppendLine(GeneratorUtil.TabString(2) + "");
            builder.AppendLine(GeneratorUtil.TabString(2) + "StringBuilder query = new StringBuilder(); ");
            foreach (SqlStatementType statment in this.Sql.MySqlStatements)
            {
                if (statment.HasStatement())
                {
                    foreach (var s in this.GetStatmentLines(statment.Statement.Value))
                    {
                        builder.AppendLine(GeneratorUtil.TabString(2) + "query.AppendLine(\"" + s.TrimEnd() + "\");");
                    }
                }
                builder.AppendLine(GeneratorUtil.TabString(2) + "query.AppendLine(\";\");");
            }
            //builder.AppendLine(GeneratorUtil.TabString(2) + "List<SqlParameter> paramList = new List<SqlParameter>();");
            //foreach (SqlStatementType statment in this.Sql.MySqlStatements)
            //{
            //    builder.AppendLine(GeneratorUtil.TabString(2) + "paramList.AddRange(" + GetBuilderName(this.Sql,statment.TableName.Value) + ".ParamList);");
            //}
            //builder.AppendLine(GeneratorUtil.TabString(2) + "DataSet ds = SqlHelper.ExecuteDataset(ReadConnection,CommandType.Text,query.ToString(),paramList.ToArray());");
            builder.AppendLine(GeneratorUtil.TabString(2) + "DataSet ds = SqlHelper.ExecuteDataset(ReadConnection,CommandType.Text,query.ToString(),paramList);");
            foreach (SqlStatementType statment in this.Sql.MySqlStatements)
            {
                if (IsPagerQuery(this.Sql) && statment.TableName.Value.Equals(this.pagerRecordCountTableName))
                    continue;

                builder.Append(GeneratorUtil.TabString(2));
                if (IsPagerQuery(this.Sql) && statment.TableName.Value.Equals(this.pagerContentTableName))
                {
                    builder.Append("List<" + this.GetModel(statment.TableName.Value) + "> ");
                }
                builder.AppendLine(GetParamModel(this.Sql,statment.TableName.Value) 
                    + " = new List<" + this.GetModel(statment.TableName.Value) + ">();");                
            }      
            foreach (ModelType model in this.Sql.MyModels)
            {
                string tableName = model.ColumnSetName.Value;
                string modelName = model.Name.Value;
                if ( this.pagerRecordCountTableName.Equals(tableName))
                {
                    builder.AppendLine(GeneratorUtil.TabString(2) + "recordCount=(int)ds.Tables[\"" + this.pagerRecordCountTableName + "\"].Rows[0][0];");
                }
                else{
                    builder.AppendLine(GeneratorUtil.TabString(2) + "if(ds.Tables[\"" + tableName + "\"] != null)");
                    builder.AppendLine(GeneratorUtil.TabString(2) + "{");
                    builder.AppendLine(GeneratorUtil.TabString(3) + "foreach(DataRow row in ds.Tables[\"" + tableName + "\"].Rows)");
                    builder.AppendLine(GeneratorUtil.TabString(3) + "{");
                    builder.AppendLine(GeneratorUtil.TabString(4) + GetParamModel(this.Sql,tableName) + ".Add(" + GetConvertToModelName(modelName) + "(row));");//
                    builder.AppendLine(GeneratorUtil.TabString(3) + "}");
                    builder.AppendLine(GeneratorUtil.TabString(2) + "}");
                }
            }
            builder.AppendLine(GeneratorUtil.TabString(2) + "return " + this.GetReturnModelParam() + ";");
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
            builder.AppendLine();
            //生成ConvertToModel
            foreach (ModelType model in this.Sql.MyModels)
            {
                string modelName = model.Name.Value;
                if (IsPagerQuery(this.Sql) && this.models[modelName].ColumnSetName.Value.Equals(this.pagerRecordCountTableName))
                {
                    continue;
                }

                SqlGenTableDAL.GenConvertToModel(builder, model);
            }
            base.Generate(builder);
        }
        private string GetConvertToModelName(string model)
        {
            return "ConvertTo" + model;
        }
        private string[] GetStatmentLines(string sql )
        {                        
            return sql.Split('\n');
        }
        private string GetModel(string tableName)
        {
            string result =GetModel(this.Sql,tableName)?? tableName;
            return result;      
        }

    }
}
