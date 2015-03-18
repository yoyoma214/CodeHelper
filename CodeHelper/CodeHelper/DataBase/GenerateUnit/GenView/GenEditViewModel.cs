using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.Common;
using CodeHelper.DataBaseHelper.Common;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenView
{
    class GenEditViewModel: BaseGen
    {
        ModelType Model = null;
        ColumnSetNode ColumnSetNode = null;
        public GenEditViewModel(ModelType model, ColumnSetNode columnSetNode)
        {
            this.Model = model;
            this.ColumnSetNode = columnSetNode;
        }

        //private string 

        public override void Generate(StringBuilder sb)
        {
            var entityName = Helper.GetClassName(this.Model.Name);
            var varEntityName = Helper.GetVarName(this.Model.Name);
            var dtoName = entityName + "Dto";
            var dtoVariable = Helper.GetVarName(dtoName);

            var viewModel = Helper.GetViewMode(this.Model.Name);
            var varViewModel = Helper.GetVarName(viewModel);

            var serivce = Helper.GetClassName(Helper.GetModuleName(this.Model.Name) + "Service");
            var varSerivce = "_" + Helper.GetVarName(serivce);

            var builder = new IndentStringBuilder();

            builder.AppendLine(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Company.ZCH49.OaSystem.WebSite.ServiceLayer;");
            builder.AppendLine();
            builder.AppendLine("namespace xxx");
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("public class Edit{0}Model", entityName);
            builder.IncreaseIndentLine("{");
            builder.AppendLine("#region property");
            builder.AppendLine();
            foreach (var f in this.Model.Fields)
            {
                if (f.SystemType == "String")
                {
                    builder.AppendFormatLine("public {0} {1} ", f.SystemType, f.Name);
                }
                else
                {
                    builder.AppendFormatLine("public {0}? {1} ", f.SystemType, f.Name);
                }

                builder.AppendLine("{get;set;}");
                builder.AppendLine();
            }

            builder.AppendLine("public string ErrorMsg");
            builder.AppendLine("{get;set;}");
            builder.AppendLine();

            builder.AppendLine("public bool IsSave");
            builder.AppendLine("{get;set;}");
            builder.AppendLine();

            builder.AppendLine("public bool IsPostBack");
            builder.AppendLine("{get;set;}");
            builder.AppendLine();

            builder.AppendLine("#endregion");
            builder.AppendLine();
            builder.AppendFormatLine("public {0} {1} = new {0}();", serivce, varSerivce);
            builder.AppendLine();

            builder.AppendLine("public bool IsNew");
            builder.AppendLine("{");
            builder.AppendLine("\tget");
            builder.AppendLine("\t{");
            builder.AppendLine("\t\treturn !this.Id.HasValue;");
            builder.AppendLine("\t}");
            builder.AppendLine("}");
            builder.AppendLine();

            builder.AppendLine("public void Action()");
            builder.IncreaseIndentLine("{");
            builder.AppendLine("Init();");
            builder.AppendLine();
            builder.AppendLine("if (this.IsSave)");
            builder.AppendLine("{");
            builder.AppendLine("\tthis.Save();");
            builder.AppendLine("}");
            builder.DecreaseIndentLine("}");
            builder.AppendLine();

            builder.AppendLine("private void Init()");
            builder.IncreaseIndentLine("{");
            builder.AppendLine("if (this.Id.HasValue && this.IsPostBack == false)");
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("var rslt = {0}.Get{1}(Id.Value);", varSerivce,entityName);
            builder.AppendFormatLine("if (rslt == null || !rslt.IsSuccess || rslt.Data == null)");
            builder.IncreaseIndentLine("{");
            builder.AppendLine("this.ErrorMsg = rslt == null ? \"no this data\" : rslt.Message;");
            builder.AppendLine("return;");
            builder.DecreaseIndentLine("}");
            builder.AppendLine();

            builder.AppendLine("var info = rslt.Data;");
            foreach (var f in this.Model.Fields)
            {
                builder.AppendFormatLine("this.{0} = info.{0};",Helper.GetClassName(f.Name));
            }
            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");
            builder.AppendLine();

            builder.AppendFormatLine("private bool Validate({0} info)",viewModel);
            builder.IncreaseIndentLine("{");
            foreach (var f in this.Model.Fields)
            {
                if (!f.NullAble)
                {
                    if (string.Compare(f.SystemType, "string", true) == 0)
                    {
                        builder.AppendFormatLine("if (string.IsNullOrWhiteSpace(info.{0}))", Helper.GetClassName(f.Name));                        
                    }
                    else
                    {
                        builder.AppendFormatLine("if (info.{0} == default({1}))", Helper.GetClassName(f.Name),f.SystemType);
                    }
                    builder.IncreaseIndentLine("{");
                    builder.AppendFormatLine("this.ErrorMsg = \"{0} Required\";", Helper.GetClassName(f.Name));
                    builder.AppendLine("return false;");
                    builder.DecreaseIndentLine("}");
                }
            }
            builder.AppendLine("return true;");
            builder.DecreaseIndentLine("}");
            builder.AppendLine();

            builder.AppendLine("private void Save()");
            builder.IncreaseIndentLine("{");
 
            //builder.AppendFormatLine("var {0} = new {1}();", varSerivce, serivce);

            builder.AppendFormatLine("var info = this.To{0}();", viewModel);
            builder.AppendFormatLine("if (!this.Validate(info))");
            builder.AppendLine("\treturn;");
            builder.AppendLine();
            builder.AppendFormatLine("var rslt = new ReturnInfo();", viewModel);
            builder.AppendLine();
            builder.AppendLine("if (this.IsNew)");
            builder.AppendLine("{");
            builder.AppendFormatLine("\trslt = {0}.Add{1}(info);",varSerivce, entityName);
            builder.AppendLine("}");
            builder.AppendLine("else");
            builder.AppendLine("{");
            builder.AppendFormatLine("\trslt = {0}.Update{1}(info);",varSerivce, entityName);
            builder.AppendLine("}");
            builder.AppendLine();
            builder.AppendLine("this.ErrorMsg = rslt.Message;");
            builder.DecreaseIndentLine("}");
            builder.AppendLine();

            builder.AppendFormatLine("private {0} To{0}()", viewModel);
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("var info = new {0}()",viewModel);
            
            builder.IncreaseIndentLine("{");
            foreach (var f in this.Model.Fields)
            {
                if (f.NullAble)
                {
                    builder.AppendFormatLine("{0} = this.{0},", f.Name);
                }
                else
                {
                    if (f.SystemType == "Guid")
                    {
                        if (f.Name.Equals("id", StringComparison.OrdinalIgnoreCase))
                        {
                            builder.AppendFormatLine("{0} = this.{0}??Guid.NewGuid(),", f.Name);
                        }
                        else
                        {
                            builder.AppendFormatLine("{0} = this.{0}??Guid.Empty,", f.Name);
                        }
                    }
                    else if (f.SystemType == "DateTime")
                    {
                        builder.AppendFormatLine("{0} = this.{0}??DateTime.Now,", f.Name);
                    }
                    else
                    {
                        builder.AppendFormatLine("{0} = this.{0}??default({1}),", f.Name,f.SystemType);
                    }
                }
            }
            
            builder.DecreaseIndentLine("};");
            builder.AppendLine();
            builder.AppendLine("return info;");
            builder.DecreaseIndentLine("}");
            builder.AppendLine();

            builder.AppendFormatLine("public static ReturnInfo Delete{0}(Guid id)",entityName);
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("var {0} = new {1}();",varSerivce,serivce);
            builder.AppendFormatLine("return {0}.Delete{1}(id);",varSerivce,entityName);
            builder.DecreaseIndentLine("}");

            builder.AppendLine();
            builder.AppendFormatLine("public static ReturnInfo Delete{0}(List<Guid> id_list)", entityName);
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("var {0} = new {1}();", varSerivce, serivce);
            builder.AppendFormatLine("return {0}.Delete{1}(id_list);", varSerivce, entityName);
            builder.DecreaseIndentLine("}");

            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");
            sb.Append(builder.ToString());
        }
    }
}
