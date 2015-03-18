using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenView
{
    class GenViewModel : BaseGen
    {
        ModelType Model = null;


        public GenViewModel(ModelType model)
        {
            this.Model = model;
        }

        public override void Generate(StringBuilder builder)
        {
            builder.AppendLine(
@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace AAA
{
");          
            var modelName = this.Model.Name.EndsWith("Info", StringComparison.OrdinalIgnoreCase)
                    ? this.Model.Name : (this.Model.Name + "Info");
            modelName = modelName.StartsWith("vw_", StringComparison.OrdinalIgnoreCase)?
                modelName.Substring(3): modelName;

            builder.AppendLine("public class " + modelName + "{");
            foreach (FieldType field in this.Model.Fields.OrderBy(x=>x.Name).ToList())
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
            builder.Append("}");
            base.Generate(builder);
        }
    }
}
