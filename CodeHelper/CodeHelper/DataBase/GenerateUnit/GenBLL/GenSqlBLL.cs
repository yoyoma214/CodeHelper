using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using Generator.GenerateUnit.GenDAL;

namespace Generator.GenerateUnit.GenBLL
{
    class GenSqlBLL:BaseGen
    {
        SqlType Sql = null;
        string returnModelName { get; set; }
        public GenSqlBLL(SqlType sqlType)
        {
            this.Sql = sqlType;
            this.returnModelName = this.Sql.Model.Name.Value; 
        }

        public override void Generate(StringBuilder builder)
        {

            builder.AppendLine(GeneratorUtil.TabString(0) + "public IList<" + this.returnModelName + ">  " + this.Sql.Name.Value + "(" + GenSqlDALBase.GetListParameter(this.Sql) + ")");
            builder.AppendLine(GeneratorUtil.TabString(0) + "{");
            builder.AppendLine(GeneratorUtil.TabString(1) + "return this.dal." + this.Sql.Name.Value + "(" + GetParamterList(this.Sql) + ");");
            builder.AppendLine(GeneratorUtil.TabString(0) + "}");
            base.Generate(builder);
        }
        public static string GetParamterList(SqlType sql)
        {
            string parameters = null;
            if (GenSqlDALBase.IsPagerQuery(sql))
            {
                parameters +=
                    "pageSize, pageIndex, out recordCount,";
            }
            foreach (SqlStatementType statment in sql.MySqlStatements)
            {
                parameters += " " + GenSqlDALBase.GetBuilderName(sql, statment.TableName.Value) + ", ";
                if (GenSqlDALBase.IsPagerQuery(sql))
                {
                    if (statment.TableName.Value.Equals(sql.PagerContentTable.Value) ||
                        statment.TableName.Value.Equals(sql.PagerRecordCountTable.Value))
                        continue;
                }
                parameters += "out  " + GenSqlDALBase.GetParamModel(sql, statment.TableName.Value) + ",";
            }
            parameters = parameters.Trim();
            parameters = parameters.EndsWith(",") ? parameters.Substring(0, parameters.Length - 1) : parameters;
            return parameters;
        }
    }
}
