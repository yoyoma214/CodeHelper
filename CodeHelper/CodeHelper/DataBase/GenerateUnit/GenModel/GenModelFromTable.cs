using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Items.DBItems;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenModel
{
    class GenModel :BaseGen
    {
        ModelType Model = null;


        public GenModel(ModelType model)
        {
            this.Model = model;           
        }

        public override void Generate(StringBuilder builder)
        {
            builder.AppendLine("public class " + this.Model.Name + "{");
            foreach (FieldType field in this.Model.Fields)
            {
                builder.AppendLine("/// <summary>");
                builder.AppendLine("///" + field.Description);
                builder.AppendLine("/// </summary>");
                builder.Append(" public ");
                Type type = DbSchema.SchemaUtility.GetSystemType(DBGlobalService.DbType, field.SystemType);
                if (field.NullAble && type.IsValueType)
                {
                    builder.AppendLine(field.SystemType + "? " + field.Name);
                }
                else
                {
                    builder.AppendLine(field.SystemType + " " + field.Name);
                }
                builder.AppendLine("{get;set;}");
                builder.AppendLine();
            }
            builder.Append("}");
            base.Generate(builder);
        }
    }
}
