using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Generator.Items.DBItems;
using Project;
using Generator.GenerateUnit.GenDAL;
using Generator.GenerateUnit.GenDAL.SqlServer;

namespace Generator.GenerateUnit.GenBLL
{
    class GenBLL :BaseGen
    {
        TableType table = null;
        string ModelName { get; set; }
        string ParaModelName { get; set; }
        string TableName { get; set; }
        string DALName { get; set; }
        public GenBLL(TableType table)
        {
            this.table = table;
            this.ModelName = table.Model.Name.Value;
            this.ParaModelName = this.ModelName.Substring(0,1).ToLower() + this.ModelName.Substring(1);
            this.DALName = "dal" + ModelName;
            this.TableName = table.Name.Value;
        }
        private void GenInsert(StringBuilder builder)
        {
            string paraModel = this.table.Model.Name.Value;        
            builder.AppendLine(GeneratorUtil.TabString(1) + "public void Insert(" + this.table.Model.Name.Value + " " + this.ParaModelName + ")");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            builder.AppendLine(GeneratorUtil.TabString(2) + this.DALName + ".Insert(" + this.ParaModelName + ");");
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
        }
        private void GenUpdate(StringBuilder builder)
        {
            builder.AppendLine(GeneratorUtil.TabString(1) + @"public bool Update(" + this.ModelName + " " + this.ParaModelName + ")");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            builder.AppendLine(GeneratorUtil.TabString(2) + "return " + this.DALName + ".Update(" + this.ParaModelName + ");");
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
        }
        private void GenDelete(StringBuilder builder)
        {
            List<ColumnType> pks = SqlGenTableDAL.GetPKColumn(this.table.ColumnSet);
            builder.Append(GeneratorUtil.TabString(1) + @"public bool Delete(");
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
            builder.Append(GeneratorUtil.TabString(2) + "return " + this.DALName + ".Delete(" );
            for (int i = 0; i < pks.Count; i++)
            {
                builder.Append(pks[i].Name.Value);
                if (i < pks.Count - 1)
                {
                    builder.Append(",");
                }
            } 
            builder.AppendLine(");");
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
        }
        private void GenGetOne(StringBuilder builder)
        {
            List<ColumnType> pks = SqlGenTableDAL.GetPKColumn(this.table.ColumnSet);
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
            builder.Append(GeneratorUtil.TabString(2) + "return " + this.DALName + ".Get"+ this.ModelName + "(");
            for (int i = 0; i < pks.Count; i++)
            {
                builder.Append(pks[i].Name.Value);
                if (i < pks.Count - 1)
                {
                    builder.Append(",");
                }
            }
            builder.AppendLine(");");
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
        }
        private void GenGetList(StringBuilder builder)
        {
            builder.AppendLine(GeneratorUtil.TabString(1) + "public IList<" + this.ModelName + "> GetList(SearchConditionBuilder builder)");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            builder.AppendLine(GeneratorUtil.TabString(2) + "return " + this.DALName + ".GetList(builder);");
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
        }
        private void GenGetPageList(StringBuilder builder)
        {
            builder.AppendLine(GeneratorUtil.TabString(1) + "public IList<" + this.ModelName + ">  GetPageList(int pageSize, int pageIndex, out int recordCount, SearchConditionBuilder builder)");
            builder.AppendLine(GeneratorUtil.TabString(1) + "{");
            builder.AppendLine(GeneratorUtil.TabString(2) + "return " + this.DALName + ".GetPageList( pageSize,  pageIndex, out recordCount, builder);");
            builder.AppendLine(GeneratorUtil.TabString(1) + "}");
        }
        private void GenProperty(StringBuilder builder)
        {
            builder.AppendLine(GeneratorUtil.TabString(1) + "private " + GenTableDALBase.GetDalName(this.TableName) + " "
                + this.DALName + " = new " + GenTableDALBase.GetDalName(this.TableName) + "();");         
        }
        public override void Generate(StringBuilder builder)
        {
            builder.AppendLine("public class " + this.ModelName + "Manager");
            builder.AppendLine("{");
            this.GenProperty(builder);
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
            builder.AppendLine("}");
            base.Generate(builder);
        }
    }
}
