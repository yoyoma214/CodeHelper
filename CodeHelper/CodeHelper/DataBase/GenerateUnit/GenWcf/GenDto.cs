using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Extensions;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenWcf
{
    class GenDto : BaseGen
    {
        ModelType Model = null;


        public GenDto(ModelType model)
        {
            this.Model = model;
        }

        public override void Generate(StringBuilder builder)
        {
            builder.AppendLine(
@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace AAA
{
");
            builder.AppendLine("[DataContract]");
            builder.AppendLine("public class " + this.Model.Name + "Dto{");
            foreach (FieldType field in this.Model.Fields.OrderByName())
            {
                builder.AppendLine("/// <summary>");
                builder.AppendLine("///" + field.Description);
                builder.AppendLine("/// </summary>");
                builder.AppendLine("[DataMember]");
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
            builder.AppendLine("}");
            builder.Append("}");
            base.Generate(builder);
        }
    }
}
