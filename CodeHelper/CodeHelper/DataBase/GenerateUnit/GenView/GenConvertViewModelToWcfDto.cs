using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Common;
using CodeHelper.DataBaseHelper.Items.DBItems;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenView
{
    class GenConvertViewModelToWcfDto: BaseGen
    {
        ModelType Model = null;
        ColumnSetNode ColumnSetNode = null;
        public GenConvertViewModelToWcfDto(ModelType model, ColumnSetNode columnSetNode)
        {
            this.Model = model;
            this.ColumnSetNode = columnSetNode;
        }

        public override void Generate(StringBuilder builder)
        {
            var modelName = this.Model.Name.EndsWith("Info", StringComparison.OrdinalIgnoreCase)
                   ? this.Model.Name : (this.Model.Name + "Info");

            modelName = modelName.StartsWith("vw_", StringComparison.OrdinalIgnoreCase) ?
                modelName.Substring(3) : modelName;

            var entityName = Helper.GetClassName(modelName);
            var varEntityName = "info";// Helper.GetVarName(modelName);
            if (DBGlobalService.UseAutoMapper)
            {
                builder.AppendFormat("Mapper.CreateMap<{0}, {1}>();", entityName, this.Model.Name + "Dto");
            }
            else
            {

                builder.AppendLine(" public static " + this.Model.Name + "Dto ConvertTo" + this.Model.Name + "Dto(" +
                    entityName + " " + varEntityName + ")");
                builder.AppendLine(" {");
                builder.AppendLine("    return new " + this.Model.Name + "Dto{");

                foreach (FieldType field in this.Model.Fields.OrderBy(x => x.Name).ToList())
                {
                    builder.AppendLine(string.Format("      {0} = info.{0},", field.Name, varEntityName));
                }
                builder.AppendLine("    };");
                builder.Append(" }");
            }
            base.Generate(builder);
        }
    
    }
}
