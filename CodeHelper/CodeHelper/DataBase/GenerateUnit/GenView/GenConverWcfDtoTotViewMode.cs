using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Common;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper.DbSchema;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenView
{
    class GenConverWcfDtoTotViewMode: BaseGen
    {
        ModelType Model = null;
        ColumnSetNode ColumnSetNode = null;
        public GenConverWcfDtoTotViewMode(ModelType model, ColumnSetNode columnSetNode)
        {
            this.Model = model;
            this.ColumnSetNode = columnSetNode;
        }

        public override void Generate(StringBuilder builder)
        {
            var viewModelName = this.Model.Name.EndsWith("Info", StringComparison.OrdinalIgnoreCase)
                   ? this.Model.Name : (this.Model.Name + "Info");
            viewModelName = viewModelName.StartsWith("vw_", StringComparison.OrdinalIgnoreCase) ?
                viewModelName.Substring(3) : viewModelName;

            var dtoModeName = this.Model.Name + "Dto";
            if (DBGlobalService.UseAutoMapper)
            {
                builder.AppendFormat("Mapper.CreateMap<{0}, {1}>();", dtoModeName, viewModelName);
            }
            else
            {
                //var entityName = Helper.GetClassName(dtoModeName);
                var varDtoName = "dto";// Helper.GetVarName(dtoModeName);

                ColumnSchema keyColumn = null;
                foreach (var f in this.ColumnSetNode.Columns)
                {
                    if (f.IsPK)
                    {
                        keyColumn = f;
                        break;//一般只有一个pk，其他情况暂不处理
                    }
                }

                builder.AppendLine(" public static " + viewModelName + " ConvertTo" + viewModelName + "(" +
                    dtoModeName + " " + varDtoName + " )");
                builder.AppendLine(" {");
                builder.AppendLine("    return new " + viewModelName + "()" + "{");

                foreach (FieldType field in this.Model.Fields.OrderBy(x => x.Name).ToList())
                {
                    //if (field.Name.Value == keyColumn.Name)
                    //    continue;

                    builder.AppendLine(string.Format("      {0} = dto.{0},", field.Name, varDtoName));
                }
                builder.AppendLine("    };");
                builder.Append(" }");
            }
            base.Generate(builder);
        }
    
    }
}
