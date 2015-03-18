using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Common;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper.DbSchema;
using CodeHelper.DataBaseHelper.Extensions;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenWcf
{
    class GenConverDtoTotEF: BaseGen
    {
        ModelType Model = null;
        ColumnSetNode ColumnSetNode = null;
        public GenConverDtoTotEF(ModelType model, ColumnSetNode columnSetNode)
        {
            this.Model = model;
            this.ColumnSetNode = columnSetNode;
        }

        public override void Generate(StringBuilder builder)
        {
            var entityName = Helper.GetClassName(this.Model.Name);
            var varEntityName = Helper.GetVarName(this.Model.Name);

            if (DBGlobalService.UseAutoMapper)
            {
                builder.AppendFormat("Mapper.CreateMap<{0}, {1}>();", entityName + "Dto", entityName);
            }
            else
            {
                varEntityName = "entity";

                ColumnSchema keyColumn = null;
                foreach (var f in this.ColumnSetNode.Columns)
                {
                    if (f.IsPK)
                    {
                        keyColumn = f;
                        break;//一般只有一个pk，其他情况暂不处理
                    }
                }

                builder.AppendLine(" public static " + this.Model.Name + " ConvertTo" + this.Model.Name + "(" +
                    entityName + "Dto " + varEntityName + "Dto)");
                builder.AppendLine(" {");
                if (keyColumn != null)
                {
                    builder.AppendLine("    return new " + this.Model.Name + string.Format("({0})", varEntityName + "Dto." + keyColumn.Name) + "{");
                }
                else
                {
                    builder.AppendLine("    return new " + this.Model.Name + "(){");
                }

                foreach (FieldType field in this.Model.Fields.OrderByName())
                {
                    if (keyColumn != null && field.Name == keyColumn.Name)
                        continue;

                    builder.AppendLine(string.Format("      {0} = {1}.{0},", field.Name, varEntityName + "Dto"));
                }
                builder.AppendLine("    };");
                builder.Append(" }");
            }
            base.Generate(builder);
        }
    
    }
}
