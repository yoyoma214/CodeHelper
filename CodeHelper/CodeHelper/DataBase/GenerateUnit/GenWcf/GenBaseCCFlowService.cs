using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.Items.DBItems;
using CodeHelper.DataBaseHelper.Common;
using CodeHelper.DataBaseHelper.Extensions;

namespace CodeHelper.DataBaseHelper.GenerateUnit.GenWcf
{
    class GenBaseCCFlowService: BaseGen
    {
        ModelType Model = null;
        ColumnSetNode ColumnSetNode = null;
        public GenBaseCCFlowService(ModelType model, ColumnSetNode columnSetNode)
        {
            this.Model = model;
            this.ColumnSetNode = columnSetNode;
        }

        private List<FieldType> GetOrderedFields()
        {
            return this.Model.Fields.OrderBy(x => x.Name).ToList();
        }

        public override void Generate(StringBuilder builder)
        {
            var entityName = Helper.GetClassName(this.Model.Name);
            var varEntityName = Helper.GetVarName(this.Model.Name);
            var dtoName = entityName + "Dto";
            var dtoVariable = Helper.GetVarName(dtoName);

            #region Distribute Service
            builder.AppendLine("        #region Distribute Service Interface");
            builder.AppendLine();
            builder.AppendLine(@"        [OperationContract]
        [WithoutAuthorization]
        [FaultContractAttribute(typeof(UnAuthorization))]");
            
            builder.Append("        ReturnInfoDto Add" + this.Model.Name + "(");

            var fields = GetOrderedFields();

            for (var index = 0; index < fields.Count; index ++ )
            {
                var f = fields[index];
                builder.AppendFormat("{0} {1}", "string", Helper.GetVarName(f.Name));

                if (index != fields.Count - 1)
                {
                    builder.Append(",");
                }
            }
            builder.AppendLine(");");

            builder.AppendLine();

            builder.AppendLine(@"        [OperationContract]
        [WithoutAuthorization]
        [FaultContractAttribute(typeof(UnAuthorization))]");

            builder.Append("        ReturnInfoDto Update" + this.Model.Name + "(");

            for (var index = 0; index < fields.Count; index++)
            {
                var f = fields[index];
                builder.AppendFormat("{0} {1}", "string", Helper.GetVarName(f.Name));

                if (index != fields.Count - 1)
                {
                    builder.Append(",");
                }
            }
            builder.AppendLine(");");
            builder.AppendLine();

            builder.AppendLine("        #endregion");
            builder.AppendLine();

            builder.AppendLine("        #region Distribute Service Implement");
            builder.AppendLine();

            builder.AppendFormat("        Add" + this.Model.Name + "(");
            for (var index = 0; index < fields.Count; index++)
            {                
                builder.Append("para[" + index + "].ToString()");
                if (index != fields.Count - 1)
                {
                    builder.Append(",");
                }                
            }
            builder.AppendLine(");");
            builder.AppendLine();

            builder.Append("        public ReturnInfoDto Add" + this.Model.Name + "(");
            for (var index = 0; index < fields.Count; index++)
            {
                var f = fields[index];
                builder.AppendFormat("{0} {1}", "string", Helper.GetVarName(f.Name));

                if (index != fields.Count - 1)
                {
                    builder.Append(",");
                }
            }            
            builder.AppendLine(")");
            builder.AppendLine("        {");
            builder.AppendLine(string.Format("        \tvar dto = new {0}();",dtoName));
            for (var index = 0; index < fields.Count; index++)
            {
                var f = fields[index];
                builder.Append("        \t");
                var defaultVal = "";
                if (!f.NullAble)
                {
                    defaultVal = "??default(" + f.SystemType + ")";
                }
                
                if (string.Equals(f.SystemType, "string", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1}{2};", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name), defaultVal);
                }
                else if (string.Equals(f.SystemType, "int", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1}.ToInt(){2};", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name), defaultVal);
                }
                else if (string.Equals(f.SystemType, "float", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1}.ToFloat(){2};", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name), defaultVal);
                }
                else if (string.Equals(f.SystemType, "double", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1}.ToDouble(){2};", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name), defaultVal);
                }
                else if (string.Equals(f.SystemType, "decimal", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1}.ToDecimal(){2};", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name), defaultVal);
                }
                else if (string.Equals(f.SystemType, "guid", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1}.ToGuid(){2};", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name), defaultVal);
                }
                else if (string.Equals(f.SystemType, "datetime", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1}.ToDateTime(){2};", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name), defaultVal);
                }
                else
                {
                    builder.AppendFormat("dto.{0} = {1}.ToUnkown();", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name));
                }
                builder.AppendLine();
            }
            builder.AppendLine("        \treturn _appService.Add" + this.Model.Name + "(dto);");

            builder.AppendLine("        }");
            builder.AppendLine();


            builder.AppendFormat("        Update" + this.Model.Name + "(");
            for (var index = 0; index < fields.Count; index++)
            {
                builder.Append("para[" + index + "].ToString()");
                if (index != fields.Count - 1)
                {
                    builder.Append(",");
                }
            }
            builder.AppendLine(");");
            builder.AppendLine();

            builder.Append("        public ReturnInfoDto Update" + this.Model.Name + "(");
            for (var index = 0; index < fields.Count; index++)
            {
                var f = fields[index];
                builder.AppendFormat("{0} {1}", "string", Helper.GetVarName(f.Name));

                if (index != fields.Count - 1)
                {
                    builder.Append(",");
                }
            }            
            builder.AppendLine(")");

            builder.AppendLine("        {");
            for (var index = 0; index < fields.Count; index++)
            {
                var f = fields[index];
                builder.Append("        \t");
                if (string.Equals(f.SystemType, "string", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1};", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name));
                }
                else if (string.Equals(f.SystemType, "int", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1}.ToInt();", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name));
                }
                else if (string.Equals(f.SystemType, "float", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1}.ToFloat();", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name));
                }
                else if (string.Equals(f.SystemType, "double", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1}.ToDouble();", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name));
                }
                else if (string.Equals(f.SystemType, "decimal", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1}.ToDecimal();", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name));
                }
                else if (string.Equals(f.SystemType, "guid", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1}.ToGuid();", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name));
                }
                else if (string.Equals(f.SystemType, "datetime", StringComparison.OrdinalIgnoreCase))
                {
                    builder.AppendFormat("dto.{0} = {1}.ToDateTime();", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name));
                }
                else
                {
                    builder.AppendFormat("dto.{0} = {1}.ToUnkown();", Helper.GetClassName(f.Name), Helper.GetVarName(f.Name));
                }
                builder.AppendLine();
            }
            builder.AppendLine("        \treturn _appService.Add" + this.Model.Name + "(dto);");

            builder.AppendLine("        }");
            builder.AppendLine();
            builder.AppendLine("        #endregion");
            builder.AppendLine();
            #endregion

            base.Generate(builder);
        }
    }
}
