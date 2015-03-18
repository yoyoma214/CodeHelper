using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Common;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper.Extensions;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenWcf
{
    class GenConvertEFToDto: BaseGen
    {
        ModelType Model = null;
        ColumnSetNode ColumnSetNode = null;
        public GenConvertEFToDto(ModelType model, ColumnSetNode columnSetNode)
        {
            this.Model = model;
            this.ColumnSetNode = columnSetNode;
        }

        public override void Generate(StringBuilder builder)
        {
            var entityName = Helper.GetClassName(this.Model.Name);
            var varEntityName = Helper.GetVarName(this.Model.Name);
            varEntityName = "entity";
            if (DBGlobalService.UseAutoMapper)
            {
                builder.AppendFormat("Mapper.CreateMap<{0}, {1}>();", entityName, entityName + "Dto");
            }
            else
            {
                builder.AppendLine(" public static " + this.Model.Name + "Dto ConvertTo" + this.Model.Name + "Dto(" +
                    entityName + " " + varEntityName + ")");
                builder.AppendLine(" {");
                builder.AppendLine("    return new " + this.Model.Name + "Dto{");

                foreach (FieldType field in this.Model.Fields.OrderByName())
                {
                    builder.AppendLine(string.Format("      {0} = {1}.{0},", field.Name, varEntityName));
                }
                builder.AppendLine("    };");
                builder.Append(" }");
            }
            base.Generate(builder);
        }
    
    }
}
