using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Items.DBItems;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenView
{
    class GenViewModel_EditPage : BaseGen
    {
        ModelType Model = null;
        ColumnSetNode ColumnSet = null;

        public GenViewModel_EditPage(ModelType model, ColumnSetNode columnSet)
        {
            this.Model = model;
            this.ColumnSet = columnSet;
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

            var pkCol = "";
            foreach (var col in this.ColumnSet.Columns)
            {
                if (col.IsPK)
                {
                    pkCol = col.Name;
                    break;
                }
            }

            var modelName = this.Model.Name.EndsWith("Info", StringComparison.OrdinalIgnoreCase)
                    ? this.Model.Name : (this.Model.Name + "Info");

            builder.AppendLine("\tpublic class " + modelName + "{");
            builder.AppendLine();
            foreach (FieldType field in this.Model.Fields)
            {
                builder.AppendLine("\t\t/// <summary>");
                builder.AppendLine("\t\t///" + field.Description);
                builder.AppendLine("\t\t/// </summary>");
                builder.Append("\t\tpublic ");
                Type type = DbSchema.SchemaUtility.GetSystemType(DBGlobalService.DbType, field.SystemType);
                if (field.NullAble && type.IsValueType)
                {
                    builder.AppendLine(field.SystemType + "? " + field.Name);
                }
                else
                {
                    builder.AppendLine(field.SystemType + " " + field.Name);
                }
                builder.AppendLine("\t\t{get;set;}");

                builder.AppendLine();

                if (field.SystemType.Equals("Guid", StringComparison.OrdinalIgnoreCase))
                {
                    if (field.Name.Equals(pkCol , StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                    var fkName = field.Name;
                    fkName = fkName.EndsWith("id", StringComparison.OrdinalIgnoreCase) ?
                        fkName.Substring(0, fkName.Length - 2) : fkName;

                    builder.AppendLine(string.Format("\t\tpublic List<{0}Info> {0}_List", fkName));
                    builder.AppendLine("\t\t{get;set;}");
                    builder.AppendLine();
                }
            }
            builder.AppendLine("\t}");
            builder.Append("}");
            base.Generate(builder);
        }
    }
}
