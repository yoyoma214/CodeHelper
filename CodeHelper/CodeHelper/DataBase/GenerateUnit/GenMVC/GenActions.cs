using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Common;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper.DbSchema;
using CodeHelper.Common;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenMVC
{
    class GenActions: BaseGen
    {
        ModelType Model = null;
        ColumnSetNode ColumnSetNode = null;
        public GenActions(ModelType model, ColumnSetNode columnSetNode)
        {
            this.Model = model;
            this.ColumnSetNode = columnSetNode;
        }

        public override void Generate(StringBuilder sb)
        {
            var entityName = Helper.GetClassName(this.Model.Name);
            var varEntityName = Helper.GetVarName(this.Model.Name);
            var dtoName = entityName + "Dto";
            var dtoVariable = Helper.GetVarName(dtoName);

            var viewModel = Helper.GetViewMode(this.Model.Name);
            var varViewModel = Helper.GetVarName(viewModel);
            var builder = new IndentStringBuilder();

            builder.Increase();

            builder.AppendFormatLine("public ActionResult Edit{0}(Edit{0}Model model)",entityName);
            builder.IncreaseIndentLine("{");
            builder.AppendLine();
            builder.AppendLine("//model.UserId = Company.ZCH49.OaSystem.WebSite.Models.User.GetCurrentUser(this).Id;");
            builder.AppendLine("model.Action();");
            builder.AppendLine("return View(model);");
            builder.AppendLine();
            builder.DecreaseIndentLine("}");
            
            builder.AppendLine();

            builder.AppendLine("/*[HttpPost]");
            builder.AppendFormatLine("public ActionResult Delete{0}(Guid id)", entityName);
            builder.IncreaseIndentLine("{");
            builder.AppendLine("var model = new ReturnInfo();");
            builder.AppendLine();
            builder.AppendLine("if (id == default(Guid))");
            builder.IncreaseIndentLine("{");
            builder.AppendLine("model.Message = \"no id\";");
            builder.DecreaseIndentLine("}");
            builder.AppendLine("else");
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine(" model = Edit{0}Model.Delete{0}(id);", entityName);
            builder.DecreaseIndentLine("}");
            builder.AppendLine("return Json(model, JsonRequestBehavior.AllowGet);");
            builder.AppendLine("");
            builder.DecreaseIndentLine("}*/");
            
            builder.AppendLine();

            builder.AppendLine("[HttpPost]");
            builder.AppendFormatLine("public ActionResult Delete{0}(List<Guid> idList)", entityName);
            builder.IncreaseIndentLine("{");
            builder.AppendLine("var model = new ReturnInfo();");
            builder.AppendLine();
            builder.AppendLine("if (idList == null || idList.Count == 0)");
            builder.IncreaseIndentLine("{");
            builder.AppendLine("model.Message = \"no id\";");
            builder.DecreaseIndentLine("}");
            builder.AppendLine("else");
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine(" model = Edit{0}Model.Delete{0}(idList);",entityName);
            builder.DecreaseIndentLine("}");
            builder.AppendLine("return Json(model, JsonRequestBehavior.AllowGet);");
            builder.AppendLine("");
            builder.DecreaseIndentLine("}");
            sb.Append(builder.ToString());
            base.Generate(sb);
        }
    
    }
}
