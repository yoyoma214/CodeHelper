using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Common;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenView
{
    class GenTableHtml : BaseGen
    {
        ModelType Model = null;

        public GenTableHtml(ModelType model)
        {
            this.Model = model;
        }

        public override void Generate(StringBuilder builder)
        {
            builder.AppendLine("<div class=\"tab-content\">");
            builder.AppendLine("<div class=\"table\">");
            builder.AppendLine("<table>");
            builder.AppendLine("<thead>");
            builder.AppendLine("<tr>");

            foreach (FieldType field in this.Model.Fields)
            {
                builder.AppendLine(string.Format("<th>"));
                builder.AppendLine(string.Format(field.Name));
                builder.AppendLine(string.Format("</th>"));
            }

            builder.AppendLine("</tr>");
            builder.AppendLine("<tr>");
            foreach (FieldType field in this.Model.Fields)
            {
                builder.AppendLine(string.Format("<th>"));
                builder.AppendLine(string.Format(field.Name));
                builder.AppendLine(string.Format("</th>"));
            }

            builder.AppendLine("</thead>");
            builder.AppendLine("<tbody>");
            var entityName = Helper.GetClassName(this.Model.Name);
            var varEntityName = Helper.GetVarName(this.Model.Name);
            var listName = this.Model.Name + "s";

            builder.AppendLine(string.Format("@if(Model == null || Model.{0} == null || Model.{0}.Count == 0)",listName));
            builder.AppendLine("{");
            builder.AppendLine(string.Format(@"<tr>
                            <td colspan='{0}' style='text-align: center'>
                                <span>No data</span>
                            </td>
                        </tr>",Model.Fields.Count));
            builder.AppendLine("}");
            builder.AppendLine("else");
            builder.AppendLine("{");
            builder.AppendLine(string.Format("foreach (var {0} in Model.{1})", varEntityName, listName));
            builder.AppendLine("{");
            builder.AppendLine("<tr>");
            builder.AppendLine("<td>");
            foreach (FieldType field in this.Model.Fields)
            {
                builder.AppendLine(string.Format("<td>"));
                builder.AppendLine(string.Format("@{0}.{1}",varEntityName, field.Name));
                builder.AppendLine(string.Format("</td>"));
            }
            builder.AppendLine("</td>");
            builder.AppendLine("</tr>");            
            builder.AppendLine("}");
            builder.AppendLine("}");

            builder.AppendLine("</tbody>");

            base.Generate(builder);
        }
    }
}
