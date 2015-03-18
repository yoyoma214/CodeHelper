using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.DbSchema;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper.Common;
using CodeHelper.DataBaseHelper.EF.ConceptualModels;
using CodeHelper.DataBaseHelper.EF;
using CodeHelper.DataBaseHelper.Extensions;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenEF
{
    class GenEFEntity : BaseGen
    {
        ModelType Model = null;
        ColumnSetNode ColumnSetNode = null;
        TableNode tableNode = null;

        public GenEFEntity(ModelType model, ColumnSetNode columnSetNode ,TableNode tableNode)
        {
            this.Model = model;
            this.ColumnSetNode = columnSetNode;
            this.tableNode = tableNode;
        }

        public override void Generate(StringBuilder builder)
        {
            builder.AppendLine(
@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.ZCH49.OASystem.Domain.Entities;
using Company.ZCH49.OASystem.Domain.AggregateRoot;

namespace AAA
{
");
            builder.AppendLine("public class " + this.Model.Name + ": Entity, IAggregateRoot{");
            builder.AppendLine(string.Format(" public {0}()", this.Model.Name));
            builder.AppendLine(" {");
            builder.AppendLine(" }");
            var conn = CodeHelper.Core.DbConfig.ConnectionManager.Get(DBGlobalService.ConnectionString);

            ColumnSchema keyColumn = null;
            ColumnSchema idColumn = null;
            foreach (var f in this.ColumnSetNode.Columns)
            {
                if (f.IsPK)
                {
                    keyColumn = f;
                    break;//一般只有一个pk，其他情况暂不处理
                }
                else if (f.Name.Equals("Id", StringComparison.OrdinalIgnoreCase) && !f.AllowDBNull)
                {
                    //idColumn = f; 暂不做这种潜规则
                }
            }
            if (keyColumn != null)
            {
                builder.AppendLine(string.Format(@" public {0}({1} {2})
    :base({2})", this.Model.Name, keyColumn.SystemType.ToString(), Helper.GetVarName(keyColumn.Name)));

                builder.AppendLine(" {");
                builder.AppendLine(" }");
            }
            else if (idColumn !=null)
            {
                builder.AppendLine(string.Format(@" public {0}({1} id)
    :base(id)", this.Model.Name, idColumn.SystemType.ToString()));

                builder.AppendLine(" {");
                builder.AppendLine(" }");
            }

            foreach (FieldType field in this.Model.Fields.OrderByName())
            {

                if (keyColumn != null && field.Name == keyColumn.Name)
                {
                    continue;
                }

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

            //生成导航属性
            
            var relations = conn.FindRelations(this.ColumnSetNode.Name,null);
            foreach (var r in relations)
            {                
                builder.AppendLine("/// <summary>");
                builder.AppendLine("///");
                builder.AppendLine("/// </summary>");
                var fkModel = CodeHelper.Core.Services.GlobalService.ResloveTableAgent.ResloveMapModel(r.ForeignTable);
                if (r.Relation == CodeHelper.Core.DbConfig.RelationType.OneToOne)
                {
                    builder.AppendFormat("public virtual {0} {1}", fkModel.Name, Helper.GetClassName(r.NavigateProperty));
                    builder.AppendLine();
                    builder.AppendLine("{get;set;}");
                }
                builder.AppendLine();

            }

            if (!this.Model.Name.StartsWith("vw_", StringComparison.OrdinalIgnoreCase))
            {
                builder.AppendFormat(" public void AssignFrom({0} other)", this.Model.Name);
                builder.AppendLine();
                builder.AppendLine(" {");

                foreach (FieldType field in this.Model.Fields.OrderByName())
                {
                    if (keyColumn != null && field.Name == keyColumn.Name)
                    {
                        continue;
                    }

                    builder.AppendFormat("  \tthis.{0} = other.{0};", field.Name);
                    builder.AppendLine();

                }
                builder.AppendLine(" }");
            }
            builder.AppendLine("}");
            builder.Append("}");
            base.Generate(builder);

        }
    }
}
