using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;
using System.ComponentModel;
using CodeHelper.Common.Extensions;
using CodeHelper.Core.Services;
using CodeHelper.Core.Parse.ParseResults.DataViews.Joins;
using System.Diagnostics;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public interface IResloveTableAgent
    {
        TableInfo Reslove(string tableName);

        ModelInfo ResloveMapModel(string tableName);

        FieldInfo ResloveMapField(string tableName, string fieldName);
    }

    public enum DbType
    {
        [Description("unknown")]
        Unknown,
        [Description("int")]
        Int,
        [Description("bool")]
        Bool,
        [Description("float")]
        Float,
        [Description("decimal")]
        Decimal,
        [Description("char")]
        Char,
        [Description("string")]
        String,
        [Description("DateTime")]
        DateTime,
        [Description("parameter")]
        Parameter,
        [Description("Guid")]
        Guid,
        [Description("multicolumn")]
        MultiColumn,
        [Description("null")]
        Null,
        [Description("List")]
        List,
        [Description("optionstring")]
        OptionString
    }
    /// <summary>
    /// 字段信息
    /// </summary>
    public class FieldInfo
    {
        public virtual string FullName
        {
            get;
            set;
        }

        public virtual string ShortName
        {
            get
            {
                return FullName;
            }
        }
        public virtual string ClassName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.ShortName))
                    return "";

                return GeneratorHelper.ClassName(ShortName);
            }
        }
        public virtual string VariableName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.ShortName))
                    return "";

                return GeneratorHelper.VariableName(ShortName);
            }
        }
        DbType _DbType;
        public DbType DbType
        {
            get
            {
                return _DbType;
            }
            set
            {
                _DbType = value;
            }
        }
        public string Alias { get; set; }
        public bool NullAble { get; set; }
        public bool IsParameter
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FullName))
                    return false;

                return this.FullName.StartsWith("$");
            }
        }

        public virtual void Render(StringBuilder builder)
        {
            builder.Append(this.FullName);
        }

        public virtual string RenderEFCondtion()
        {            
            return "";
        }

        public virtual void Wise(SelectAtomContext context)
        {
        }

        public virtual string SystemType
        {
            get
            {
                var type = EnumUtils.GetDescription(this.DbType);

                if (this.DbType == DataViews.DbType.Bool ||
                     this.DbType == DataViews.DbType.Char ||
                    this.DbType == DataViews.DbType.DateTime ||
                     this.DbType == DataViews.DbType.Decimal ||
                     this.DbType == DataViews.DbType.Float ||
                     this.DbType == DataViews.DbType.Guid ||
                    this.DbType == DataViews.DbType.Int)
                {
                    if (this.NullAble)
                        type += "?";
                }

                return type;
            }
        }

        internal virtual void RenderSql(StringBuilder builder)
        {

        }
    }
    public interface IValue
    {
        string Value { get; set; }
    }
    public interface IListValue : IValue
    {
    }

    public class ListFieldInfo : FieldInfo, IListValue
    {
        public List<FieldInfo> Fields { get; set; }

        public ListFieldInfo()
        {
            this.Fields = new List<FieldInfo>();
        }

        public override void Render(StringBuilder builder)
        {
            builder.Append("(");
            for (int index = 0; index < Fields.Count; index++)
            {
                if (index > 0)
                    builder.Append(" , ");

                Fields[index].Render(builder);
            }

            builder.Append(")");
            base.Render(builder);
        }

        public string Value
        {
            get;
            set;

        }
    }
    public class ValueListFieldInfo : ListFieldInfo
    {
        public override string RenderEFCondtion()
        {
            
            return "";
        }

        public string RenderEFCondtion(string listName, string systemType)
        {
            var rslt = "";
            foreach (var v in this.Fields)
            {
                rslt += string.Format("\t\t {0}.Add({1});\r\n", listName, v.RenderEFCondtion());
            }
            return rslt;
        }
                
    }
    public class SelectListFieldInfo : ListFieldInfo
    {
        public SelectContext SelectContext { get; set; }

        public override void Render(StringBuilder builder)
        {
            builder.Append("(");
            this.SelectContext.Render(builder);
            builder.Append(")");
            if (!string.IsNullOrWhiteSpace(this.Alias))
            {
                builder.Append(" as " + this.Alias);
            }
            //base.Render(builder);
        }

        public override void Wise(SelectAtomContext context)
        {
            this.SelectContext.Wise(this.SelectContext);

            var returnFields = this.SelectContext.Unions[0].Context.ReturnFields;
            if (returnFields.Count == 1)
            {
                this.DbType = returnFields[0].DbType;
            }
        }
    }

    public class ValueFieldInfo : FieldInfo, IValue
    {
        public string Value { get; set; }

        public override void Render(StringBuilder builder)
        {
            builder.Append(this.Value);

            if (!string.IsNullOrWhiteSpace(this.Alias))
            {
                builder.Append(" as " + this.Alias);
            }

            base.Render(builder);
        }

        public override string RenderEFCondtion()
        {
            if (this.IsParameter)
            {
                return "condition." + Value.Substring(1);
            }

            if (this.DbType == DataViews.DbType.Char || this.DbType == DataViews.DbType.String)
            {
                return "\"" + Value.Substring(1, Value.Length - 2) + "\"";
            }

            if (this.DbType == DataViews.DbType.Bool)
            {
                bool b;
                if (bool.TryParse(this.Value, out b))
                {
                    return b.ToString().ToLower();
                }
            }

            if (this.DbType == DataViews.DbType.OptionString)
                return Value.Substring(1,Value.Length-2);

            return Value;
        }
        
        public override void Wise(SelectAtomContext context)
        {
            if (this.IsParameter)
            {
                SelectContext.Root.Parameters.Add(new ParameterFieldInfo() { Name = this.FullName });
            }
            base.Wise(context);
        }
    }

    public class AllFieldInfo : FieldInfo, MutiField
    {
        public AllFieldInfo()
        {
            AllFields = new List<FieldInfo>();
        }

        public List<FieldInfo> AllFields
        {
            get;
            set;
        }

        public override void Render(StringBuilder builder)
        {
            builder.Append("*");

            base.Render(builder);
        }

        public override void Wise(SelectAtomContext context)
        {

            foreach (var table in context.TableJoinInfos)
            {
                if (table.RightModelInfo != null)
                {
                    foreach (var f in table.RightModelInfo.Fields)
                    {
                        AllFields.Add(f);
                    }
                }
            }
        }

        internal override void RenderSql(StringBuilder builder)
        {
            builder.Append("*");
        }


        public string Table
        {
            get;
            set;
        }
    }
    //public class ParameterFieldInfo : FieldInfo
    //{
    //    //public string Name { get; set; }

    //    public override void Render(StringBuilder builder)
    //    {
    //        builder.Append(this.Name);

    //        base.Render(builder);
    //    }
    //}

    public interface MutiField
    {
        List<FieldInfo> AllFields { get; set; }
        string Table { get; set; }
    }

    public class TableAllFieldInfo : FieldInfo, MutiField
    {
        public string Table { get; set; }

        public List<FieldInfo> AllFields { get; set; }

        public TableAllFieldInfo()
        {
            AllFields = new List<FieldInfo>();
        }

        public override void Render(StringBuilder builder)
        {
            builder.Append(Table + ".*");
            base.Render(builder);
        }

        public override void Wise(SelectAtomContext context)
        {

            var model = context.ResolveModelType(this.Table);
            if (model == null)
                return;

            foreach (var f in model.Fields)
            {
                AllFields.Add(f);
            }
        }

        internal override void RenderSql(StringBuilder builder)
        {
            builder.Append(Table + ".*");
        }
    }

    public class FieldRegularInfo : FieldInfo
    {
        public string Table { get; set; }
        public string Model { get; set; }

        public override string FullName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this.Alias))
                    return this.Alias;

                return base.FullName;
            }
            set
            {
                base.FullName = value;
            }
        }

        public override string ShortName
        {
            get
            {
                var ss = this.FullName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (ss.Length == 1)
                    return ss[0];

                return ss.Last();
            }
        }
        public string Table_alias
        {
            get
            {
                var ss = this.FullName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (ss.Length == 1)
                    return null;

                return ss[0];

            }
        }
        //public string Name { get; set; }
        public override void Render(StringBuilder builder)
        {
            builder.Append(this.FullName);
            //base.Render(builder);
        }

        public override void Wise(SelectAtomContext context)
        {
            string _table, _model;
            bool nullAble;
            if (string.Equals(this.FullName, "null", StringComparison.OrdinalIgnoreCase))
            {
                this.DbType = DataViews.DbType.Null;
                this.NullAble = true;
            }
            else
            {
                this.DbType = context.ResolveFieldType(this.FullName, out nullAble, out _table, out _model);
                this.NullAble = nullAble;
                this.Table = _table;
                this.Model = _model;
            }
            //if (!string.IsNullOrWhiteSpace(this.Table_alias))
            //{
            //    this.Table = context.ResolveTableAlias(this.Table_alias);
            //    this.Model = context.ResolveModelType(this.Table).Name;
            //}
        }

        internal override void RenderSql(StringBuilder builder)
        {
            builder.Append(this.FullName);
        }
    }

    public class CaseFieldInfo : FieldInfo
    {
        public override void Render(StringBuilder builder)
        {
            base.Render(builder);
        }

        public override void Wise(SelectAtomContext context)
        {
            base.Wise(context);
        }

        public override string RenderEFCondtion()
        {
            return base.RenderEFCondtion();
        }
    }

    public class CaseFieldWithTargetInfo : CaseFieldInfo
    {
        public FieldInfo Target { get; set; }
        public List<CaseHaveTargetWhenExpressionInfo> CaseHaveTargetWhenExpressions { get; set; }
        public CaseElseExpressionInfo CaseElseExpression { get; set; }

        public CaseFieldWithTargetInfo()
            : base()
        {
            CaseHaveTargetWhenExpressions = new List<CaseHaveTargetWhenExpressionInfo>();
        }

        public override void Render(StringBuilder builder)
        {
            //base.Render(builder);

            builder.Append(" ( case ");

            this.Target.Render(builder);

            foreach (var expr in CaseHaveTargetWhenExpressions)
            {
                expr.Render(builder);
            }

            if (CaseElseExpression != null)
            {
                CaseElseExpression.Render(builder);
            }

            builder.Append(" end )");
        }

        public override void Wise(SelectAtomContext context)
        {
            this.Target.Wise(context);

            this.DbType = this.Target.DbType;

            foreach (var expr in CaseHaveTargetWhenExpressions)
            {
                expr.Wise(context);               
            }

            foreach (var expr in CaseHaveTargetWhenExpressions)
            {
                if (expr.ResultExpress.DbType != DataViews.DbType.Unknown && 
                    expr.ResultExpress.DbType != DataViews.DbType.Parameter)
                {
                    DbType = expr.ResultExpress.DbType;
                    break;
                }
            }
            
            if (CaseElseExpression != null)
            {
                CaseElseExpression.Wise(context);

                if (this.DbType == DataViews.DbType.Unknown)
                {
                    this.DbType = CaseElseExpression.Value.DbType;
                }
            }
        }

        public override string RenderEFCondtion()
        {
            return base.RenderEFCondtion();
        }
    }

    public class CaseHaveTargetWhenExpressionInfo
    {
        public FieldInfo Value { get; set; }
        public FieldInfo ResultExpress { get; set; }

        public void Render(StringBuilder builder)
        {
            builder.Append(" when ");
            Value.Render(builder);
            builder.Append(" then ");
            ResultExpress.Render(builder);

        }

        public void Wise(SelectAtomContext context)
        {
            Value.Wise(context);
            ResultExpress.Wise(context);            
        }

        public string RenderEFCondtion()
        {
            return "";
        }
    }

    public class CaseElseExpressionInfo:ExpressionInfo
    {
        public FieldInfo Value { get; set; }
        //public SelectContext Select { get; set; }

        public void Render(StringBuilder builder)
        {
            builder.Append(" else ");
            if (Value != null)
                Value.Render(builder);

            //if (Select != null)
            //    Select.Render(builder);
        }

        public void Wise(SelectAtomContext context)
        {
            Value.Wise(context);
        }

        public string RenderEFCondtion()
        {
            return "";
        }
    }

    public class CaseFieldNoTargetInfo : CaseFieldInfo
    {
        public List<CaseWhenExprressInfo> CaseWhenExprresses { get; set; }
        public CaseElseExpressionInfo CaseElseExpression { get; set; }

        public CaseFieldNoTargetInfo()
            : base()
        {
            CaseWhenExprresses = new List<CaseWhenExprressInfo>();
        }

        public override void Render(StringBuilder builder)
        {
            builder.Append(" ( case ");
            foreach (var expr in CaseWhenExprresses)
            {
                expr.Render(builder);
            }

            if (this.CaseElseExpression != null)
            {
                CaseElseExpression.Render(builder);
            }

            builder.Append(" end ) ");
        }

        public override void Wise(SelectAtomContext context)
        {
            foreach (var expr in CaseWhenExprresses)
            {
                expr.Wise(context);                
            }

            foreach (var expr in CaseWhenExprresses)
            {       
                if (expr.ResultExpress.DbType != DataViews.DbType.Unknown
                    && expr.ResultExpress.DbType != DataViews.DbType.Parameter
                    )
                {
                    this.DbType = expr.ResultExpress.DbType;
                    break;
                }
            }

            if (this.CaseElseExpression != null)
            {
                this.CaseElseExpression.Wise(context);

                if (this.DbType == DataViews.DbType.Unknown)
                {
                    this.DbType = this.CaseElseExpression.Value.DbType;
                }
            }
        }

        public override string RenderEFCondtion()
        {
            return base.RenderEFCondtion();
        }
    }

    public class CaseWhenExprressInfo
    {
        public ConditionInfo Condition { get; set; }
        public FieldInfo ResultExpress { get; set; }
        public void Render(StringBuilder builder)
        {
            builder.Append(" when ");
            Condition.Render(builder);
            builder.Append(" then ");
            ResultExpress.Render(builder);
        }

        public void Wise(SelectAtomContext context)
        {
           
        }

        public string RenderEFCondtion()
        {
            return "";
        }
    }

    public class FunctionFieldInfo : FieldInfo
    {
        public string FunctionName { get; set; }
        public List<FieldInfo> ParameterFields { get; set; }
        //public SqlContext Context { get; set; }

        public FunctionFieldInfo()
        {
            this.ParameterFields = new List<FieldInfo>();
            //this.Context = new SqlContext();
        }

        public override void Render(StringBuilder builder)
        {
            builder.Append(this.FunctionName + "(");
            for (var index = 0; index < ParameterFields.Count; index++)
            {
                if (index > 0 && index < ParameterFields.Count)
                {
                    builder.Append(",");
                }
                ParameterFields[index].Render(builder);

            }

            builder.Append(")");
            if (!string.IsNullOrWhiteSpace(this.Alias))
            {
                builder.Append(" as " + this.Alias);
            }
            base.Render(builder);
        }

        public override string RenderEFCondtion()
        {
            if (this.FunctionName.Equals("isnull", StringComparison.OrdinalIgnoreCase))
            {
                var field = this.ParameterFields[0].ClassName;
                var fieldInfo = ((ValueFieldInfo)this.ParameterFields[1]);

                var defaultVal = fieldInfo.Value;
                if (fieldInfo.SystemType == "string")
                {
                    defaultVal = "\"" + defaultVal.Substring(1, defaultVal.Length - 2) + "\"";
                }
                return string.Format("(x.{0}??{1})", field, defaultVal);
            }

            return base.RenderEFCondtion();
        }

        public bool IsAggregationFunc
        {
            get
            {
                var lowName = this.FunctionName.ToLower();
                if (lowName == "sum" ||
                    lowName == "count" ||
                    lowName == "avg")
                {
                    return true;
                }
                return false;
            }
        }

        public override void Wise(SelectAtomContext context)
        {
            foreach (var p in this.ParameterFields)
            {
                p.Wise(context);
            }

            if (this.FunctionName.Equals("avg", StringComparison.OrdinalIgnoreCase))
            {
                if (this.ParameterFields[0].DbType == DataViews.DbType.Int)
                    this.DbType = DataViews.DbType.Decimal;
                else
                    this.DbType = this.ParameterFields[0].DbType;
            }

            if (this.FunctionName.Equals("sum", StringComparison.OrdinalIgnoreCase))
            {
                this.DbType = this.ParameterFields[0].DbType;
            }

            if (this.FunctionName.Equals("count", StringComparison.OrdinalIgnoreCase))
            {
                this.DbType = DataViews.DbType.Int;
            }
        }
    }

    /// <summary>
    /// 表信息
    /// </summary>
    public class TableInfo
    {
        public string Name { get; set; }
        public List<FieldInfo> Fields { get; set; }
        //public SqlContext ThisContext{get;set;}

        public TableInfo()
        {
            this.Fields = new List<FieldInfo>();
        }
    }

    public class ModelInfo
    {
        public string Name { get; set; }
        public List<FieldInfo> Fields { get; set; }
        //public SqlContext ThisContext{get;set;}

        public ModelInfo()
        {
            this.Fields = new List<FieldInfo>();
        }
    }

    /// <summary>
    /// 比较条件类型
    /// </summary>
    public enum ConditionType
    {
        [Description("unknown")]
        Unknown,
        [Description("=")]
        Equal,
        [Description(">")]
        Gt,
        [Description("<")]
        Lt,
        [Description("!=")]
        NotEqual,
        [Description(">=")]
        GtEqual,
        [Description("<=")]
        LtEqual,
        [Description("like")]
        Like,
        [Description("in")]
        In,
        [Description("not in")]
        NotIn,
        [Description("exists")]
        Exists,
        [Description("not exists")]
        NotExists,
        [Description("between")]
        Between
    }

    /// <summary>
    /// 比较之间的关系
    /// </summary>
    public enum RelationType
    {
        [Description("unknown")]
        Unknown,
        [Description("and")]
        And,
        [Description("or")]
        Or
    }

    /// <summary>
    /// 复合条件信息
    /// </summary>
    public class ConditionComplexInfo
    {
        /// <summary>
        /// 条件信息，如果非空，则Conditions，RelationTypes都视为Empty
        /// </summary>
        public ConditionInfo Condition { get; set; }

        /// <summary>
        /// 复合条件列表，前提是Condition为null，才会视为有效
        /// </summary>
        public List<ConditionComplexInfo> Conditions { get; set; }
        /// <summary>
        /// 复合条件之间的关联，前提是Condition为null，才会视为有效
        /// </summary>
        public List<RelationType> RelationTypes { get; set; }

        public ConditionComplexInfo()
        {
            Conditions = new List<ConditionComplexInfo>();
            RelationTypes = new List<RelationType>();
        }

        public virtual string RenderEFSpec(StringBuilder builder, string modelName, ParameterList parameters)
        {
            /*
            if (Condition != null)
                return Condition.RenderEFSpec(builder, modelName, parameters);
            else
            {
                if (this.RelationTypes.Count > 0)
                {
                    SqlContext.Condition_Generate_Stack.Push("compositeGroup_" + (SqlContext.Condition_Generate_Stack.Count + 1));
                }

                var spec_list = new List<string>();

                for (var index = 0; index < this.Conditions.Count; index++)
                {
                    spec_list.Add(this.Conditions[index].RenderEFSpec(builder, modelName, parameters));
                }
                var name = "";

                var prevAnd = "";
                var orList = new List<string>();

                for (var index = 0; index < this.RelationTypes.Count; index++)
                {
                    var r = this.RelationTypes[index];

                    var left = spec_list[index];
                    var right = spec_list[index + 1];
                    if (prevAnd == "")
                        prevAnd = left;

                    if (r == RelationType.And)
                    {
                        name = prevAnd + "_and_" + right;
                        name = name.Replace("_spec_", "_").Replace("_spec", "");
                        //prevAnd = name;
                        builder.AppendLine(string.Format("\t\t var {0} = new AndSpecification<{1}>({2},{3}); ", name, modelName, prevAnd, right));
                        prevAnd = name;

                    }
                    else if (r == RelationType.Or)
                    {
                        if (!string.IsNullOrWhiteSpace(prevAnd))
                        {
                            orList.Add(prevAnd);
                            prevAnd = "";
                        }
                        else
                        {
                            orList.Add(spec_list[index - 1]);
                        }

                    }
                    if (index == this.RelationTypes.Count - 1)
                    {
                        orList.Add(spec_list.Last());
                    }

                }
                List<RelationType> orList_Op = new List<RelationType>();
                foreach (var op in this.RelationTypes)
                {
                    if (op == RelationType.Or)
                    {
                        orList_Op.Add(op);
                    }
                }

                var rslt = "";
                var prevOr = "";
                for (var index = 0; index < orList_Op.Count; index++)
                {

                    var left = orList[index];
                    var right = orList[index + 1];

                    name = left + "_or_" + right;
                    name = name.Replace("_spec_", "").Replace("_spec", "");

                    if (prevOr == "")
                    {
                        prevOr = left;
                    }

                    builder.AppendLine(string.Format("\t\t var {0} = new OrSpecification<{1}>({2},{3}); ",
                        name, modelName, prevOr, right));

                    prevOr = name;
                    rslt = name;
                }

                //如果没有or操作，则全为and操作
                if (rslt == "")
                    rslt = prevAnd;

                //先输出and

                //后输出or（组合and）

                //var compositeGroup = SqlContext.Condition_Generate_Stack.Peek();
                ////builder.AppendLine(string.Format(" var {0}", compositeGroup));

                //if (SqlContext.Condition_Generate_Stack.Count == 1)
                //{
                //    //builder.AppendLine(string.Format(" var {0}", compositeGroup));
                //}

                //builder.AppendLine(")");
                if (string.IsNullOrWhiteSpace(rslt))
                {
                    rslt = spec_list.Count == 1 ? spec_list[0] : "unknown";
                }
                if (this.RelationTypes.Count > 0)
                {
                    SqlContext.Condition_Generate_Stack.Pop();
                }

                return rslt;
            }
             * */
            return "";

        }

        public virtual void Render(StringBuilder builder)
        {
            if (Condition != null)
                Condition.Render(builder);
            else
            {
                for (var index = 0; index < this.Conditions.Count; index++)
                {
                    this.Conditions[index].Render(builder);
                    if (this.RelationTypes.Count > 0 && index < this.RelationTypes.Count)
                    {
                        builder.Append(" " + EnumUtils.GetDescription(this.RelationTypes[index]) + " ");
                    }
                }
            }
        }

        public virtual void Wise(SelectAtomContext context)
        {
            if (this.Condition != null)
            {
                this.Condition.Wise(context);
                return;
            }

            foreach (var condition in this.Conditions)
            {
                condition.Wise(context);
            }
        }
    }

    public class HavingInfo
    {
        public OrConditionInfo Condition { get; set; }
        public void Render(StringBuilder builder)
        {
            builder.Append(" having ");
            Condition.Render(builder);
            /*
            for (int index = 0; index < this.Condition.Conditions.Count; index++)
            {
                if (index > 0)
                {
                    builder.Append("( ");
                }
                this.Condition.Conditions[index].Render(builder);
                if (index > 0)
                {
                    builder.Append(" )");
                }
                if (this.Condition.RelationTypes.Count > 0 && index < this.Condition.RelationTypes.Count)
                {
                    builder.Append(" " + EnumUtils.GetDescription(this.Condition.RelationTypes[index]) + " ");
                }
            }
             */

        }

        public void RenderEFSpec(StringBuilder builder)
        {

        }

        public void Wise(SelectAtomContext context)
        {
            if (Condition != null)
            {
                this.Condition.Wise(context);
            }
            //base.Wise(context);
        }

        internal void RenderSql(StringBuilder builder)
        {
            builder.Append(" having ");
            Condition.RenderSql(builder);
        }
    }

    public static class GeneratorHelper
    {
        public static string SharpMapCondtionType(ConditionType condtionType)
        {
            switch (condtionType)
            {
                case ConditionType.Gt:
                    return ">";
                case ConditionType.Equal:
                    return "==";
                case ConditionType.GtEqual:
                    return ">=";
                case ConditionType.Lt:
                    return "<";
                case ConditionType.LtEqual:
                    return "<=";
                case ConditionType.NotEqual:
                    return "!=";
                default:
                    return "unknown";
            }
        }

        public static string ClassName(string s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1);
        }

        public static string VariableName(string s)
        {
            return s.Substring(0, 1).ToLower() + s.Substring(1);
        }
    }

    /// <summary>
    /// 条件信息
    /// </summary>
    public class BinaryConditionInfo : ConditionInfo
    {
        public FieldInfo LeftValue { get; set; }
        public FieldInfo RightValue { get; set; }
        public int StartCharIndex { get; set; }
        public int EndCharIndex { get; set; }
     

        public virtual bool HasParemter
        {
            get
            {
                return this.LeftValue.IsParameter || this.RightValue.IsParameter;
            }
        }

        public override void Render(StringBuilder builder)
        {
            LeftValue.Render(builder);
            builder.Append(" " + EnumUtils.GetDescription(this.ConditionType) + " ");
            if (RightValue != null)
            {
                RightValue.Render(builder);
            }
        }

        public override string RenderEFSpec(StringBuilder builder, string modelName,string condition_class, ParameterList parameters)
        {
            var rslt = this.LeftValue.IsParameter ? this.LeftValue.FullName.Substring(1) :
                           (this.RightValue.IsParameter ? this.RightValue.FullName.Substring(1) : "");

            if (string.IsNullOrWhiteSpace(rslt))
            {
                rslt = this.LeftValue.FullName;
            }            
            if (string.IsNullOrWhiteSpace(rslt))
            {
                if (this.LeftValue is FunctionFieldInfo)
                {
                    foreach (var f in ((FunctionFieldInfo)this.LeftValue).ParameterFields)
                    {
                        if (f.IsParameter)
                            rslt = f.VariableName;
                        if (f is FieldRegularInfo)
                            rslt = f.VariableName;                                                
                    }
                }
                if (string.IsNullOrWhiteSpace(rslt))
                {
                    if (this.RightValue is ValueFieldInfo)
                    { 
                    }
                    else if (this.RightValue is FunctionFieldInfo)
                    {
                        foreach (var f in ((FunctionFieldInfo)this.RightValue).ParameterFields)
                        {
                            if (f.IsParameter)
                                rslt = f.VariableName;
                            if (f is FieldRegularInfo)
                                rslt = f.VariableName;
                        }
                    }
                }
                if (string.IsNullOrWhiteSpace(rslt))
                {
                    rslt = "none";
                }
            }
            rslt = parameters.Use(rslt);
            rslt += "_spec";
            rslt = rslt.Substring(0, 1).ToLower() + rslt.Substring(1);
            
            var parameter = this.LeftValue.IsParameter ? this.LeftValue.FullName :
                            this.RightValue.FullName;
            parameter = parameter ?? "";

            ParameterFieldInfo para = null;
            foreach (var p in parameters)
            {
                if (p.Name.Equals(parameter, StringComparison.OrdinalIgnoreCase))
                {
                    para = p;
                    break;
                }
            }

            if (parameter.StartsWith("$"))
            {
                parameter = parameter.Substring(1);
                parameter = parameter.Substring(0, 1).ToUpper() + parameter.Substring(1);
            }

            #region 无参数条件
            if (string.IsNullOrWhiteSpace(parameter) || para == null)
            {
                //可能两个都是value类型
                if (string.IsNullOrWhiteSpace(this.LeftValue.FullName) && string.IsNullOrWhiteSpace(this.RightValue.FullName))
                {
                    //if(LeftValue

                    builder.AppendLine(string.Format("\t\t var {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                    builder.AppendLine(string.Format("\t\t\t {0} {1} {2}", this.LeftValue.RenderEFCondtion(), GeneratorHelper.SharpMapCondtionType(
                    this.ConditionType), this.RightValue.RenderEFCondtion()));

                    builder.AppendLine(string.Format("\t\t );"));
                    builder.AppendLine();
                    return rslt;
                }

                //可能其中有一个是字段
                var left = this.LeftValue.FullName;
                if (string.IsNullOrWhiteSpace(left))
                    left = this.LeftValue.RenderEFCondtion();
                else
                {
                    left = "x." + left;
                }
                var right = this.RightValue.FullName;
                if (string.IsNullOrWhiteSpace(right))
                    right = this.RightValue.RenderEFCondtion();
                else
                {
                    if ( this.RightValue.DbType != DbType.Null )                       
                        right = "x." + right;
                }

                builder.AppendLine(string.Format("\t\t var {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                builder.AppendLine(string.Format("\t\t\t {0} {1} {2}", left, GeneratorHelper.SharpMapCondtionType(
                    this.ConditionType), right));

                builder.AppendLine(string.Format("\t\t );"));
                builder.AppendLine();
                //可能含有方法:暂不处理

                return rslt;
            }
            #endregion

            //rslt = parameters.Use(parameter) + "_spec";

            builder.AppendLine(string.Format("\t\t ISpecification<{0}> {1} = null;", modelName, rslt));

            if (para.NullAble)
            {
                //if (this.ConditionType == DataViews.ConditionType.In || this.ConditionType == DataViews.ConditionType.NotIn)
                //{
                //    builder.AppendLine(string.Format("\t\t if (condition.{0} == null || condition.{0}.Count == 0)", parameter));
                //    builder.AppendLine("\t\t {");
                //    builder.AppendLine(string.Format("\t\t\t {0} =  new DirectSpecification<{1}>(x=> true);", rslt, modelName));
                //    builder.AppendLine("\t\t }");
                //}
                //else 
                if (para.DbType == DbType.String)
                {
                    builder.AppendLine(string.Format("\t\t if (string.IsNullOrWhiteSpace(condition.{0}))", parameter));
                    builder.AppendLine("\t\t {");

                    builder.AppendLine(string.Format("\t\t\t  {0} =  new DirectSpecification<{1}>(x=> {2});", rslt, modelName, SelectContext.OrConext.Peek() ? "false" : "true"));
                    builder.AppendLine("\t\t }");
                }
                else
                {
                    builder.AppendLine(string.Format("\t\t if (!condition.{0}.HasValue)", parameter));
                    builder.AppendLine("\t\t {");

                    builder.AppendLine(string.Format("\t\t\t  {0} =  new DirectSpecification<{1}>(x=> {2});", rslt, modelName, SelectContext.OrConext.Peek() ? "false" : "true"));
                    //builder.AppendLine(string.Format("\t\t\t {0} =  new DirectSpecification<{1}>(x=> true);", rslt, modelName));

                    builder.AppendLine("\t\t }");
                }
                builder.AppendLine("\t\t else{");
            }

            var condition_type_value = "condition." + parameter;

            var field_para = this.LeftValue.IsParameter ? this.LeftValue.FullName :
                       this.RightValue.FullName;
            field_para = field_para.Substring(1);
            field_para = field_para.Substring(0, 1).ToUpper() + field_para.Substring(1);

            var field = this.LeftValue.IsParameter ? this.RightValue.FullName :
                       this.LeftValue.FullName;

            var condition_type = condition_class + "." + field_para + "_ConditionType";
            //var condition_type = modelName + "_Condition";
            #region 有选项
            if (this.Options.Count > 0)
            {

                foreach (var option in this.Options)
                {
                    if (option.Name.Equals("op", StringComparison.OrdinalIgnoreCase)
                        && option.Value.Equals("all", StringComparison.OrdinalIgnoreCase) && this.HasParemter)
                    {
                        if (string.IsNullOrWhiteSpace(field_para))
                        {
                            builder.Append("必须有参数和字段名称");
                            return "";
                        }

                        //builder.AppendLine(string.Format("\t\t ISpecification<{0}> {1} = null;", modelName, rslt));

                        builder.AppendLine(string.Format("\t\t\t if (condition.{0}_Condition== {1}.EQ )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t  x.{0} {1} condition.{2}", field, " ==", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (condition.{0}_Condition== {1}.LT )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t  x.{0} {1} condition.{2}", field, "<", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (condition.{0}_Condition=={1}.LT_EQ )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t  {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t  x.{0} {1} condition.{2}", field, "<=", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (condition.{0}_Condition=={1}.GT )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t x.{0} {1} condition.{2}", field, ">", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (condition.{0}_Condition=={1}.GT_EQ )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t x.{0} {1} condition.{2}", field, ">=", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (condition.{0}_Condition=={1}.NOT_EQ )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t x.{0} {1} condition.{2}", field, "!=", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine("\t\t }");


                    }
                    else if (option.Name.Equals("between", StringComparison.OrdinalIgnoreCase) && this.HasParemter)
                    {
                        builder.AppendLine(string.Format("\t\t if ( condition.{0}_Condition== {1}.BETWEEN )", field_para, condition_type));
                        builder.AppendLine("\t\t {");
                        var begin_spec = rslt + "_begin";
                        var end_spec = rslt + "_end";
                        var end_para = GeneratorHelper.ClassName(option.Value.Substring(1));

                        builder.AppendLine(string.Format("\t\t\t var {0} = new DirectSpecification<{1}>( x=> true );"
                            , begin_spec, modelName));
                        builder.AppendLine(string.Format("\t\t\t var {0} = new DirectSpecification<{1}>( x=> true );"
                           , end_spec, modelName));

                        builder.AppendFormatLine("\t\t\t if ( condition.{0} != null )", field_para);
                        builder.AppendLine("\t\t\t {");
                        builder.AppendFormatLine("\t\t\t\t {0} = new DirectSpecification<{1}>( x=> "
                            , begin_spec, modelName);
                        builder.AppendFormatLine("\t\t\t\t  x.{0} >= condition.{1}", field, field_para);
                        builder.AppendLine("\t\t\t\t );");
                        builder.AppendLine("\t\t\t }");

                        builder.AppendFormatLine("\t\t\t if ( condition.{0} != null )", end_para);
                        builder.AppendLine("\t\t\t {");
                        builder.AppendFormatLine("\t\t\t\t {0} = new DirectSpecification<{1}>( x=> "
                            , end_spec, modelName);
                        builder.AppendFormatLine("\t\t\t\t  x.{0} <= condition.{1}", field, end_para);
                        builder.AppendLine("\t\t\t\t );");
                        builder.AppendLine("\t\t\t }");

                        //builder.AppendLine(string.Format("\t\t\t var {0} = new DirectSpecification<{1}>( x=> "
                        //    , begin_spec, modelName));
                        //builder.AppendLine(string.Format("\t\t\t\t  condition.{1}??true || x.{0} >= condition.{1}", field, field_para));
                        //builder.AppendLine(string.Format("\t\t\t\t );"));

                        //builder.AppendLine(string.Format("\t\t\t var {0} = new DirectSpecification<{1}>( x=> "
                        //   , end_spec, modelName));
                        //builder.AppendLine(string.Format("\t\t\t\t condition.{1}??true || x.{0} <= condition.{1}", field, end_para));
                        //builder.AppendLine(string.Format("\t\t\t\t );"));


                        builder.Append(string.Format("\t\t \t {0} = new AndSpecification<{1}>({2},{3});",
                            rslt, modelName, begin_spec, end_spec));
                        builder.AppendLine();
                        builder.AppendLine("\t\t }");
                        return rslt;
                    }
                }

                if (para.NullAble)
                {
                    builder.AppendLine("\t\t }");
                }
                builder.AppendLine();
                return rslt;
            }
            #endregion

            #region like
            if (this.ConditionType == DataViews.ConditionType.Like)
            {
                builder.AppendLine(string.Format("\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                builder.AppendLine(string.Format("\t\t\t\t  x.{0}.Contains({1})", field, this.RightValue.RenderEFCondtion()));
                builder.AppendLine(string.Format("\t\t\t );"));

                if (para.NullAble)
                {
                    builder.AppendLine("\t\t}");
                }
                builder.AppendLine();
                return rslt;
            }
            #endregion

            //if (this.ConditionType == DataViews.ConditionType.In || this.ConditionType == DataViews.ConditionType.NotIn)
            //{
            //    builder.AppendLine(string.Format("\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
            //    var null_default_val = "";

            //    if (this.LeftValue.NullAble)
            //    {
            //        null_default_val = string.Format("??default({0})", this.LeftValue.SystemType.Replace("?",""));
            //    }
            //    if (this.ConditionType == DataViews.ConditionType.In)
            //    {
            //        builder.AppendLine(string.Format("\t\t\t\t  {0}.Contains(x.{1}{2})", this.RightValue.RenderEFCondtion(), field, null_default_val));
            //    }
            //    else
            //    {
            //        builder.AppendLine(string.Format("\t\t\t\t  !{0}.Contains(x.{1}{2})", this.RightValue.RenderEFCondtion(), field, null_default_val));
            //    }
            //    builder.AppendLine(string.Format("\t\t\t );"));

            //    if (para.NullAble)
            //    {
            //        builder.AppendLine("\t\t}");
            //    }
            //    builder.AppendLine();
            //    return rslt;
            //}

            #region 其他比较
            builder.AppendLine(string.Format("\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
            var _operator = EnumUtils.GetDescription(this.ConditionType);
            if (_operator == "=")
                _operator = "==";

            builder.AppendLine(string.Format("\t\t\t x.{0} {1} {2}", this.LeftValue.FullName
                , _operator
                , this.RightValue.RenderEFCondtion()));
            builder.AppendLine(string.Format("\t\t );"));

            if (para.NullAble)
            {
                builder.AppendLine("\t\t}");
            }
            #endregion
            builder.AppendLine();
            return rslt;

        }

        public override void Wise(SelectAtomContext context)
        {
            this.LeftValue.Wise(context);
            this.RightValue.Wise(context);

            DbType type = DbType.Unknown;
            bool nullAble = true;

            type = this.LeftValue.DbType;
            if (type == DbType.Parameter)
            {
                type = this.RightValue.DbType;
            }

            if (this.LeftValue.IsParameter)
            {
                SelectContext.Root.Parameters.Add(this.LeftValue as ParameterFieldInfo);
                foreach (var p in SelectContext.Root.Parameters)
                {
                    if (p.Name == this.RightValue.FullName)
                    {
                        p.DbType = type;
                        p.Options.AddRange(this.Options);
                        nullAble = p.NullAble;
                    }
                }
            }

            if (this.RightValue.IsParameter)
            {
                if (this.ConditionType == DataViews.ConditionType.In ||
                     this.ConditionType == DataViews.ConditionType.NotIn)
                {
                    ((ParameterFieldInfo)this.RightValue).IsList = true;
                }

                SelectContext.Root.Parameters.Add(this.RightValue as ParameterFieldInfo);
                foreach (var p in SelectContext.Root.Parameters)
                {
                    if (p.Name == this.RightValue.FullName)
                    {
                        p.DbType = type;
                        p.Options.AddRange(this.Options);
                        nullAble = p.NullAble;
                    }
                }
            }

            //提取选项提示信息
            foreach (var option in this.Options)
            {
                if (option.Value.StartsWith("$"))
                {
                    var parameter = new ParameterFieldInfo();
                    parameter.Name = option.Value;
                    parameter.DbType = type;
                    parameter.NullAble = nullAble;
                    context.Parameters.Add(parameter);
                    SelectContext.Root.Parameters.Add(parameter);
                }
            }
            base.Wise(context);
        }

        public override void RenderSql(StringBuilder builder)
        {
            this.LeftValue.RenderSql(builder);

            builder.AppendLine(" " + EnumUtils.GetDescription(this.ConditionType) + " ");

            this.RightValue.RenderSql(builder);
        }

        internal override bool ShouldRender_InSingleQuery(string entity)
        {
            var left_table = "";
            if (this.LeftValue is FieldRegularInfo)
            {
                left_table = ((FieldRegularInfo)this.LeftValue).Table_alias;
                left_table = string.IsNullOrWhiteSpace(left_table) ? ((FieldRegularInfo)this.LeftValue).Table : left_table;
            }
            var right_table = "";
            if (this.RightValue is FieldRegularInfo)
            {
                right_table = ((FieldRegularInfo)this.RightValue).Table_alias;
                right_table = string.IsNullOrWhiteSpace(right_table) ? ((FieldRegularInfo)this.LeftValue).Table : right_table;
            }


            if (left_table == "" && right_table == "")
                return false;

            if (!string.IsNullOrWhiteSpace(left_table) && !string.IsNullOrWhiteSpace(right_table))
            {
                if (left_table != right_table)
                    return false;
                if (left_table == entity)
                    return true;
            }
            
            if (left_table != entity && right_table != entity)
                return false;
           

            //if (left_table == entity && right_table == entity)
            //    return true;            

            return true;
        }

        public override void RenderEF(string entity, StringBuilder builder)
        {
            var parameters = SelectContext.Root.Parameters;

            //如果左右两边不属于同一个表则报错
            if (this.LeftValue is FieldRegularInfo && this.RightValue is FieldRegularInfo)
            {
                if (((FieldRegularInfo)this.LeftValue).Table_alias != ((FieldRegularInfo)this.RightValue).Table_alias)
                {
                    //builder.AppendLine("如果左右两边不属于同一个表" );
                    return;
                }
            }

            if (this.LeftValue is FieldRegularInfo)
            {
                if (((FieldRegularInfo)this.LeftValue).Table_alias != entity)
                {
                    return;
                }
            }

            this.Have_Render_EF = true;

            var query = "";

            if (entity == null)
            {
                query = "query";
            }
            if (entity != null)
            {
                query = entity + "_q";
            }

            query = GeneratorHelper.VariableName(query);

            //var rslt = this.LeftValue.IsParameter ? this.LeftValue.Name.Substring(1) :
            //               (this.RightValue.IsParameter ? this.RightValue.Name.Substring(1) : "");

            //if (string.IsNullOrWhiteSpace(rslt))
            //{
            //    rslt = this.LeftValue.Name;
            //}

            //rslt += "_spec";
            //rslt = rslt.Substring(0, 1).ToLower() + rslt.Substring(1);

            var parameter = this.LeftValue.IsParameter ? this.LeftValue.FullName :
                            this.RightValue.FullName;
            parameter = parameter ?? "";

            ParameterFieldInfo para = null;
            foreach (var p in parameters)
            {
                if (p.Name.Equals(parameter, StringComparison.OrdinalIgnoreCase))
                {
                    para = p;
                    break;
                }
            }

            if (parameter.StartsWith("$"))
            {
                parameter = parameter.Substring(1);
                parameter = parameter.Substring(0, 1).ToUpper() + parameter.Substring(1);
            }
            else
            {
                parameter = null;
            }

            #region 无参数条件
            if (string.IsNullOrWhiteSpace(parameter))
            {
                //可能两个都是value类型
                if (string.IsNullOrWhiteSpace(this.LeftValue.FullName) && string.IsNullOrWhiteSpace(this.RightValue.FullName))
                {
                    if (string.IsNullOrWhiteSpace(entity))
                    {
                        builder.AppendLine(string.Format("\t\t {0} = {0}.Where(x=>{1} {2} {3});", query, this.LeftValue.RenderEFCondtion(), GeneratorHelper.SharpMapCondtionType(
                            this.ConditionType), this.RightValue.RenderEFCondtion()));
                    }
           
                    return;
                }

                //可能其中有一个是字段
                var left = this.LeftValue.ShortName;
                //if (string.IsNullOrWhiteSpace(left))
                //    left = this.LeftValue.RenderEFCondtion();
                //else
                //{
                //    left = "x." + left;
                //}
                var right = this.RightValue.FullName;
                if (string.IsNullOrWhiteSpace(right))
                    right = this.RightValue.RenderEFCondtion();
                //else
                //{
                //    right = "x." + right;
                //}

                builder.AppendLine(string.Format("\t\t {0} = {0}.Where(x=>x.{1} {2} {3});", query, left, GeneratorHelper.SharpMapCondtionType(
                    this.ConditionType), right));
                //builder.AppendLine(string.Format("\t\t\t {0} {1} {2}", left, GeneratorHelper.SharpMapCondtionType(
                //    this.ConditionType), right));

                //builder.AppendLine(string.Format("\t\t );"));
                builder.AppendLine();
                //可能含有方法:暂不处理

                return;
            }
            #endregion

            var condition_type_value = "condition." + parameter;

            var field_para = this.LeftValue.IsParameter ? this.LeftValue.ShortName :
                       this.RightValue.ShortName;
            field_para = field_para.Substring(1);
            field_para = field_para.Substring(0, 1).ToUpper() + field_para.Substring(1);

            var field = this.LeftValue.IsParameter ? this.RightValue.ShortName :
                       this.LeftValue.ShortName;
            field = GeneratorHelper.ClassName(field);

            var condition_type = field_para + "_Condition";
            //var condition_type = modelName + "_Condition";

            #region 有选项
            /*
            if (this.Options.Count > 0)
            {

                foreach (var option in this.Options)
                {
                    if (option.Name.Equals("op", StringComparison.OrdinalIgnoreCase)
                        && option.Value.Equals("all", StringComparison.OrdinalIgnoreCase) && this.HasParemter)
                    {
                        if (string.IsNullOrWhiteSpace(field_para))
                        {
                            builder.Append("必须有参数和字段名称");
                            return ;
                        }

                        //builder.AppendLine(string.Format("\t\t ISpecification<{0}> {1} = null;", modelName, rslt));

                        builder.AppendLine(string.Format("\t\t\t if (x.{0}== {1}.EQ )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t  x.{0} {1} condition.{2}", field, " ==", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (x.{0}== {1}.LT )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t  x.{0} {1} condition.{2}", field, "<", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (x.{0}=={1}.LT_EQ )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t  {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t  x.{0} {1} condition.{2}", field, "<=", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (x.{0}=={1}.GT )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t x.{0} {1} condition.{2}", field, ">", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (x.{0}=={1}.GT_EQ )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t x.{0} {1} condition.{2}", field, ">=", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (x.{0}=={1}.NOT_EQ )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t x.{0} {1} condition.{2}", field, "!=", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine("\t\t }");


                    }
                    else if (option.Name.Equals("between", StringComparison.OrdinalIgnoreCase) && this.HasParemter)
                    {
                        builder.AppendLine(string.Format("\t\t if ( x.{0}== {1}.BETWEEN )", field_para, condition_type));
                        builder.AppendLine("\t\t {");
                        var begin_spec = rslt + "_begin";
                        var end_spec = rslt + "_end";
                        var end_para = GeneratorHelper.ClassName(option.Value.Substring(1));

                        builder.AppendLine(string.Format("\t\t\t var {0} = new DirectSpecification<{1}>( x=> "
                            , begin_spec, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t  condition.{1}??true || x.{0} >= condition.{1}", field, field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));

                        builder.AppendLine(string.Format("\t\t\t var {0} = new DirectSpecification<{1}>( x=> "
                           , end_spec, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t condition.{1}??true || x.{0} <= condition.{1}", field, end_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));


                        builder.Append(string.Format("\t\t \t {0} = new AndSpecification<{1}>({2},{3});",
                            rslt, modelName, begin_spec, end_spec));
                        builder.AppendLine();
                        builder.AppendLine("\t\t }");
                        return;
                    }
                }

                if (para.NullAble)
                {
                    builder.AppendLine("\t\t }");
                }
                builder.AppendLine();
                return;
            }
             *  */
            #endregion

            if (para.NullAble)
            {
                builder.AppendLine(string.Format("\t if(condition.{0} != null )", para.ClassName));
                builder.AppendLine("\t {");
            }

            #region like
            if (this.ConditionType == DataViews.ConditionType.Like)
            {
                builder.AppendLine(string.Format("\t {0} = {0}.Where(x=>x.{1}.Contains({2}));", query, field, this.RightValue.RenderEFCondtion()));
                //builder.AppendLine(string.Format("\t\t\t\t  x.{0}.Contains({1})", field, this.RightValue.RenderEFCondtion()));
                //builder.AppendLine(string.Format("\t\t\t );"));

                if (para.NullAble)
                {
                    builder.AppendLine("\t }");
                }
                //builder.AppendLine();
                return;
            }
            #endregion

            #region 其他比较
            //builder.AppendLine(string.Format("\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
            var _operator = EnumUtils.GetDescription(this.ConditionType);
            if (_operator == "=")
                _operator = "==";

            builder.AppendLine(string.Format("\t {0} = {0}.Where(x=>x.{1} {2} {3});", query, field, _operator, this.RightValue.RenderEFCondtion()));

            //builder.AppendLine(string.Format("\t\t\t x.{0} {1} {2}", this.LeftValue.Name
            //    , _operator
            //    , this.RightValue.RenderEFCondtion()));
            //builder.AppendLine(string.Format("\t\t );"));

            if (para.NullAble)
            {
                builder.AppendLine("\t }");
            }
            #endregion
            builder.AppendLine();

        }

        internal override void RenderEF(List<TableJoinInfo> join_list, StringBuilder builder)
        {
            if (this.Have_Render_EF)
                return;

            var parameters = SelectContext.Root.Parameters;

            var parameter = this.LeftValue.IsParameter ? this.LeftValue.FullName :
                            this.RightValue.FullName;
            parameter = parameter ?? "";

            ParameterFieldInfo para = null;
            foreach (var p in parameters)
            {
                if (p.Name.Equals(parameter, StringComparison.OrdinalIgnoreCase))
                {
                    para = p;
                    break;
                }
            }

            if (parameter.StartsWith("$"))
            {
                parameter = parameter.Substring(1);
                parameter = parameter.Substring(0, 1).ToUpper() + parameter.Substring(1);
            }
            else
            {
                parameter = null;
            }

            #region 无参数条件
            if (string.IsNullOrWhiteSpace(parameter))
            {
                //可能两个都是value类型
                if (string.IsNullOrWhiteSpace(this.LeftValue.FullName) && string.IsNullOrWhiteSpace(this.RightValue.FullName))
                {
                    
                        //builder.AppendLine(string.Format("\t\t {0} = {0}.Where(x=>{1} {2} {3});", "q", this.LeftValue.RenderEFCondtion(), GeneratorHelper.SharpMapCondtionType(
                        //    this.ConditionType), this.RightValue.RenderEFCondtion()));

                    builder.AppendLine(string.Format("\t\t  {0} {1} {2}", this.LeftValue.RenderEFCondtion(), GeneratorHelper.SharpMapCondtionType(
                    this.ConditionType), this.RightValue.RenderEFCondtion()));
                    
                    return;
                }

                //可能其中有一个是字段
                var left = this.LeftValue.FullName;
                if (string.IsNullOrWhiteSpace(left))
                    left = this.LeftValue.RenderEFCondtion();
                else
                {
                    left = "x." + left;
                }
                var right = this.RightValue.FullName;
                if (string.IsNullOrWhiteSpace(right))
                    right = this.RightValue.RenderEFCondtion();
                else
                {
                    right = "x." + right;
                }

                builder.AppendLine(string.Format(" {0} {1} {2}",  left, GeneratorHelper.SharpMapCondtionType(
                    this.ConditionType), right));
                //builder.AppendLine(string.Format("\t\t\t {0} {1} {2}", left, GeneratorHelper.SharpMapCondtionType(
                //    this.ConditionType), right));

                //builder.AppendLine(string.Format("\t\t );"));
                builder.AppendLine();
                //可能含有方法:暂不处理

                return;
            }
            #endregion

            var condition_type_value = "condition." + parameter;

            var field_para = this.LeftValue.IsParameter ? this.LeftValue.ShortName :
                       this.RightValue.ShortName;
            field_para = field_para.Substring(1);
            field_para = field_para.Substring(0, 1).ToUpper() + field_para.Substring(1);

            var field = this.LeftValue.IsParameter ? this.RightValue.ShortName :
                       this.LeftValue.ShortName;
            field = GeneratorHelper.ClassName(field);

            var condition_type = field_para + "_Condition";
            //var condition_type = modelName + "_Condition";
            var left_table = "";
            if ( this.LeftValue is FieldRegularInfo)
            {
                left_table = ((FieldRegularInfo)this.LeftValue).Table_alias;
                left_table = string.IsNullOrWhiteSpace(left_table) ? ((FieldRegularInfo)this.LeftValue).Table : left_table;
            }
            var right_table = "";
            if ( this.RightValue is FieldRegularInfo)
            {
                right_table = ((FieldRegularInfo)this.RightValue).Table_alias;
                right_table = string.IsNullOrWhiteSpace(right_table) ? ((FieldRegularInfo)this.LeftValue).Table : right_table;
            }

            #region 有选项
            /*
            if (this.Options.Count > 0)
            {

                foreach (var option in this.Options)
                {
                    if (option.Name.Equals("op", StringComparison.OrdinalIgnoreCase)
                        && option.Value.Equals("all", StringComparison.OrdinalIgnoreCase) && this.HasParemter)
                    {
                        if (string.IsNullOrWhiteSpace(field_para))
                        {
                            builder.Append("必须有参数和字段名称");
                            return ;
                        }

                        //builder.AppendLine(string.Format("\t\t ISpecification<{0}> {1} = null;", modelName, rslt));

                        builder.AppendLine(string.Format("\t\t\t if (x.{0}== {1}.EQ )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t  x.{0} {1} condition.{2}", field, " ==", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (x.{0}== {1}.LT )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t  x.{0} {1} condition.{2}", field, "<", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (x.{0}=={1}.LT_EQ )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t  {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t  x.{0} {1} condition.{2}", field, "<=", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (x.{0}=={1}.GT )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t x.{0} {1} condition.{2}", field, ">", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (x.{0}=={1}.GT_EQ )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t x.{0} {1} condition.{2}", field, ">=", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine(string.Format("\t\t\t else if (x.{0}=={1}.NOT_EQ )", field_para, condition_type));
                        builder.AppendLine("\t\t\t {");
                        builder.AppendLine(string.Format("\t\t\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t\t x.{0} {1} condition.{2}", field, "!=", field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));
                        builder.AppendLine("\t\t\t }");

                        builder.AppendLine("\t\t }");


                    }
                    else if (option.Name.Equals("between", StringComparison.OrdinalIgnoreCase) && this.HasParemter)
                    {
                        builder.AppendLine(string.Format("\t\t if ( x.{0}== {1}.BETWEEN )", field_para, condition_type));
                        builder.AppendLine("\t\t {");
                        var begin_spec = rslt + "_begin";
                        var end_spec = rslt + "_end";
                        var end_para = GeneratorHelper.ClassName(option.Value.Substring(1));

                        builder.AppendLine(string.Format("\t\t\t var {0} = new DirectSpecification<{1}>( x=> "
                            , begin_spec, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t  condition.{1}??true || x.{0} >= condition.{1}", field, field_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));

                        builder.AppendLine(string.Format("\t\t\t var {0} = new DirectSpecification<{1}>( x=> "
                           , end_spec, modelName));
                        builder.AppendLine(string.Format("\t\t\t\t condition.{1}??true || x.{0} <= condition.{1}", field, end_para));
                        builder.AppendLine(string.Format("\t\t\t\t );"));


                        builder.Append(string.Format("\t\t \t {0} = new AndSpecification<{1}>({2},{3});",
                            rslt, modelName, begin_spec, end_spec));
                        builder.AppendLine();
                        builder.AppendLine("\t\t }");
                        return;
                    }
                }

                if (para.NullAble)
                {
                    builder.AppendLine("\t\t }");
                }
                builder.AppendLine();
                return;
            }
             *  */
            #endregion

            if (para.NullAble)
            {
                builder.AppendLine(string.Format("\t (condition.{0} == null ? true : ", para.ClassName));
                //builder.AppendLine("\t {");
            }

            #region like
            if (this.ConditionType == DataViews.ConditionType.Like)
            {
                //builder.AppendLine(string.Format(" {0} {1} {2} ", field,"", this.RightValue.RenderEFCondtion()));
                builder.AppendLine(string.Format("\t\t\t\t  x.{0}.Contains({1})", field, this.RightValue.RenderEFCondtion()));
                builder.AppendLine(string.Format("\t\t\t );"));

                if (para.NullAble)
                {
                    builder.AppendLine("\t }");
                }
                //builder.AppendLine();
                return;
            }
            #endregion

            #region 其他比较
            //builder.AppendLine(string.Format("\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));
            var _operator = EnumUtils.GetDescription(this.ConditionType);
            if (_operator == "=")
                _operator = "==";

            builder.AppendLine(string.Format(" x.{0}.{1} {2} {3} ",left_table, field, _operator, this.RightValue.RenderEFCondtion()));

            //builder.AppendLine(string.Format("\t\t\t x.{0} {1} {2}", this.LeftValue.Name
            //    , _operator
            //    , this.RightValue.RenderEFCondtion()));
            //builder.AppendLine(string.Format("\t\t );"));

            if (para.NullAble)
            {
                builder.AppendLine(")");
            }
            #endregion
            builder.AppendLine();
        }

        internal override void RenderEF_Join(string prevQuery, JoinType joinType, TableJoinInfo joinInfo, List<TableJoinInfo> join_list, StringBuilder builder, StringBuilder left_builder, StringBuilder right_builder)
        {
            //获取左值和右值的表对象
            var left_regular_field = this.LeftValue as FieldRegularInfo;
            var right_regular_field = this.RightValue as FieldRegularInfo;
            if (left_regular_field == null ||
                right_regular_field == null)
            {
                builder.AppendLine("关联条件必须都是表字段");
                return;
            }
            var left_model = left_regular_field.Model;
            var right_model = right_regular_field.Model;
            var left_q = string.IsNullOrWhiteSpace(prevQuery) ? left_model + "_q" : prevQuery.Trim();
            //var right_q = GeneratorHelper.VariableName(right_model + "_q");
            var right_q = string.IsNullOrWhiteSpace(joinInfo.Alias) ? left_model + "_q" : joinInfo.Alias + "_q";
            var left_field = GeneratorHelper.ClassName(this.LeftValue.ShortName);
            var right_field = GeneratorHelper.ClassName(this.RightValue.ShortName);

            var left_linq = string.IsNullOrWhiteSpace(left_regular_field.Table_alias)
                ? left_model : left_regular_field.Table_alias.Trim();
            var right_linq = string.IsNullOrWhiteSpace(right_regular_field.Table_alias)
                ? right_model : right_regular_field.Table_alias.Trim();

            //生成关联
            if (joinType == JoinType.Inner)
            {
                builder.AppendLine(string.Format("\t {0}.Join({1},{4}=>{4}{6}.{2},{5}=>{5}.{3},",
                    prevQuery, right_q, left_field, right_field, left_linq, right_linq, join_list.Count > 2 ? "." + left_linq : ""));

                builder.Append(string.Format("\t\t\t ({0},{1})=>new ", left_linq, right_linq));
                builder.Append("{ ");
                builder.Append(string.Format("{0},{1}", left_linq, right_linq));
                builder.AppendLine(" });");
                builder.AppendLine();
            }
            else if (joinType == JoinType.Left)
            {
                var conditions = joinInfo.Condition.Conditions[0].CompareComplexConditionInfos;

                if (conditions.Count > 1)
                {
                    List<FieldInfo> join_codition_fields = new List<FieldInfo>();

                    for (var index = 0; index < conditions.Count; index++)
                    {
                        var binary = conditions[index].AtomConditionInfo as BinaryConditionInfo;
                        join_codition_fields.Add(binary.LeftValue);
                    }

                    left_builder.AppendFormat("{0} = {1}.{0},", left_field, left_linq);

                    var join_info_field = ""; 

                    for(var index = 0 ; index < conditions.Count ; index ++ )
                    {
                        if (conditions[index].AtomConditionInfo == this)
                        {
                            join_info_field = join_codition_fields[index].ClassName;
                        }
                    }
                    right_builder.AppendFormat("{0} = {1}.{2},", join_info_field, right_linq, right_field);

                    return;
                }
              
                builder.AppendLine(string.Format("\t {0}.GroupJoin({1},{4}=>{4}{6}.{2},{5}=>{5}.{3},",
                    prevQuery, right_q, left_field, right_field, left_linq, right_linq, join_list.Count > 2 ? "." + left_linq : ""));

                builder.Append(string.Format("\t\t\t ({0},{1})=>new ", left_linq, right_linq));
                builder.Append("{ ");
                builder.Append(string.Format("{0},{1} = {1}.DefaultIfEmpty()", left_linq, right_linq));
                builder.AppendLine(" })");

                builder.Append(string.Format("\t\t\t .SelectMany(item=>item.{0}.Select({0}=> new ", right_linq));
                builder.Append("{");
                for (var index = 0; index < join_list.Count; index++)
                {
                    var join = join_list[index];
                    var alias_table = !string.IsNullOrWhiteSpace(join.Alias) ? join.Alias
                           : GeneratorHelper.ClassName(join.RightModelInfo.Name);

                    if (index < join_list.Count - 1)
                    {
                        if (join_list.Count == 2)
                        {
                            builder.AppendFormat("item.{0},", alias_table);
                        }
                        else
                        {
                            builder.AppendFormat("item.{0}.{1},", left_linq, alias_table);
                        }
                    }
                    else
                    {
                        builder.AppendFormat("{0}", alias_table);
                    }

                }
                builder.AppendLine("}));");
                builder.AppendLine();
            }
        }
    }

    public class LikeConditionInfo : BinaryConditionInfo
    {
        public override bool HasParemter
        {
            get
            {
                if (base.HasParemter)
                    return base.HasParemter;

                if (this.RightValue is ValueFieldInfo)
                {
                    var v = this.RightValue as ValueFieldInfo;
                    return v.Value.Replace("%", "").Contains("$");
                }

                return false;
            }
        }

        public override void Wise(SelectAtomContext context)
        {
            DbType type = DbType.Unknown;

            if (this.LeftValue is FieldRegularInfo)
            {
                bool nullAble;
                type = context.ResolveFieldType(this.LeftValue.FullName, out nullAble);
            }

            base.Wise(context);

            //if (this.RightParameter is ValueFieldInfo)
            //{
            //    type = context.ResolveFieldType(this.RightParameter.Name);
            //}

            if (this.RightValue is ValueFieldInfo)
            {
                var v = this.RightValue as ValueFieldInfo;
                var p = v.Value.Replace("%", "").Replace("'", "").Trim(); ;
                if (p.Contains("$"))
                {
                    var parameter = new ParameterFieldInfo() { DbType = type, Name = p };
                    context.Parameters.Add(parameter);

                    bool existed = false;
                    foreach (var each in SelectContext.Root.Parameters)
                    {
                        if (each.FullName.Equals(p, StringComparison.OrdinalIgnoreCase))
                        {
                            existed = true;
                            break;
                        }
                    }
                    if (!existed)
                    {
                        SelectContext.Root.Parameters.Add(parameter);
                    }
                }
            }

            if (this.RightValue.IsParameter)
            {
                foreach (var p in context.Parameters)
                {
                    if (p.Name == this.RightValue.FullName)
                    {
                        p.DbType = type;
                    }
                }
            }
        }
    }

    public class InCondtionInfo : BinaryConditionInfo
    {
        public InCondtionInfo()
            : base()
        {
        }

        public override string RenderEFSpec(StringBuilder builder, string modelName, string condition_class, ParameterList parameters)
        {

            var rslt = this.LeftValue.IsParameter ? this.LeftValue.FullName.Substring(1) :
                          (this.RightValue.IsParameter ? this.RightValue.FullName.Substring(1) : "");

            if (string.IsNullOrWhiteSpace(rslt))
            {
                rslt = this.LeftValue.FullName;
            }

            rslt += "_spec";
            rslt = GeneratorHelper.VariableName(rslt);

            var field = this.LeftValue.IsParameter ? this.RightValue.FullName :
                       this.LeftValue.FullName;

            field = GeneratorHelper.ClassName(field);

            builder.AppendLine(string.Format("\t\t ISpecification<{0}> {1} = null;", modelName, rslt));

            //var condition_type_value = "condition." + parameter;


            var null_default_val = "";

            FieldInfo filedInfo = GlobalService.ResloveTableAgent.ResloveMapField(modelName, field);

            if (this.RightValue is ValueListFieldInfo)
            {
                var values_name = parameters.Use(field);
                values_name = GeneratorHelper.VariableName(values_name);
                values_name += "_list";
                //filedInfo = GlobalService.ResloveTableAgent.ResloveMapField(modelName, field);
                if (filedInfo == null)
                    return string.Format("No this field", field);

                builder.AppendLine(string.Format("\t\t var {0} = new List<{1}>();", values_name, filedInfo.SystemType));

                builder.AppendLine(((ValueListFieldInfo)this.RightValue).RenderEFCondtion(values_name, filedInfo.SystemType));

                builder.AppendLine(string.Format("\t\t {0} = new DirectSpecification<{1}>(x=>", rslt, modelName));

                if (this.LeftValue.NullAble)
                {
                    null_default_val = string.Format("??default({0})", this.LeftValue.SystemType.Replace("?", ""));
                }
                if (this.ConditionType == DataViews.ConditionType.In)
                {
                    builder.AppendLine(string.Format("\t\t\t\t  {0}.Contains(x.{1}{2})", values_name, field, null_default_val));
                }
                else
                {
                    builder.AppendLine(string.Format("\t\t\t\t  !{0}.Contains(x.{1}{2})", values_name, field, null_default_val));
                }
                builder.AppendLine(string.Format("\t\t\t );"));
            }
            else if (this.RightValue is ParameterFieldInfo)
            {
                var parameter = this.LeftValue.IsParameter ? this.LeftValue.FullName :
                               this.RightValue.FullName;
                parameter = parameter ?? "";
                ParameterFieldInfo para = null;

                foreach (var p in parameters)
                {
                    if (p.Name.Equals(parameter, StringComparison.OrdinalIgnoreCase))
                    {
                        para = p;
                        break;
                    }
                }

                if (parameter.StartsWith("$"))
                {
                    parameter = parameter.Substring(1);
                    parameter = parameter.Substring(0, 1).ToUpper() + parameter.Substring(1);
                }


                foreach (var p in parameters)
                {
                    if (p.Name.Equals(parameter, StringComparison.OrdinalIgnoreCase))
                    {
                        para = p;
                        break;
                    }
                }

                //if (filedInfo.NullAble)
                //{
                if (this.ConditionType == DataViews.ConditionType.In || this.ConditionType == DataViews.ConditionType.NotIn)
                {
                    builder.AppendLine(string.Format("\t\t if (condition.{0} == null || condition.{0}.Count == 0)", parameter));
                    builder.AppendLine("\t\t {");
                    //builder.AppendLine(string.Format("\t\t\t {0} =  new DirectSpecification<{1}>(x=> {2});", rslt, modelName));
                    builder.AppendLine(string.Format("\t\t\t  {0} =  new DirectSpecification<{1}>(x=> {2});", rslt, modelName, SelectContext.OrConext.Peek() ? "false" : "true"));
                    builder.AppendLine("\t\t }");
                }
                else if (para.DbType == DbType.String)
                {
                    Debug.Assert(false, "DbType.String");
                    builder.AppendLine(string.Format("\t\t if (string.IsNullOrWhiteSpace(condition.{0}))", parameter));
                    builder.AppendLine("\t\t {");
                    //builder.AppendLine(string.Format("\t\t\t  {0} =  new DirectSpecification<{1}>(x=> true);", rslt, modelName));
                    builder.AppendLine(string.Format("\t\t\t  {0} =  new DirectSpecification<{1}>(x=> {2});", rslt, modelName, SelectContext.OrConext.Peek() ? "false" : "true"));
                    builder.AppendLine("\t\t }");
                }
                else
                {
                    Debug.Assert(false, "");
                    builder.AppendLine(string.Format("\t\t if (!condition.{0}.HasValue)", parameter));
                    builder.AppendLine("\t\t {");
                    //builder.AppendLine(string.Format("\t\t\t {0} =  new DirectSpecification<{1}>(x=> true);", rslt, modelName));
                    builder.AppendLine(string.Format("\t\t\t  {0} =  new DirectSpecification<{1}>(x=> {2});", rslt, modelName, SelectContext.OrConext.Peek() ? "false" : "true"));
                    builder.AppendLine("\t\t }");
                }
                builder.AppendLine("\t\t else{");

                if (filedInfo.NullAble)
                {
                    if (this.ConditionType == DataViews.ConditionType.In)
                    {
                        builder.AppendLine(string.Format("\t\t\t {0} =  new DirectSpecification<{1}>(x=> condition.{2}.Contains(x.{3}??default({4})));",
                            rslt, modelName, parameter, field, para.DbType.GetDescription()));
                    }
                    if (this.ConditionType == DataViews.ConditionType.NotIn)
                    {
                        builder.AppendLine(string.Format("\t\t\t {0} =  new DirectSpecification<{1}>(x=> ! condition.{2}.Contains(x.{3}??default({4})));",
                            rslt, modelName, parameter, field, para.DbType.GetDescription()));
                    }
                }
                else
                {
                    if (this.ConditionType == DataViews.ConditionType.In)
                    {
                        builder.AppendLine(string.Format("\t\t\t {0} =  new DirectSpecification<{1}>(x=> condition.{2}.Contains(x.{3}));",
                            rslt, modelName, parameter, field));
                    }
                    if (this.ConditionType == DataViews.ConditionType.NotIn)
                    {
                        builder.AppendLine(string.Format("\t\t\t {0} =  new DirectSpecification<{1}>(x=> ! condition.{2}.Contains(x.{3}));",
                            rslt, modelName, parameter, field));
                    }
                }
                //}

                if (para.NullAble)
                {
                    builder.AppendLine("\t\t}");
                }
            }

            builder.AppendLine();
            return rslt;
        }
    }

    public class ConditionInfo
    {
        public virtual ConditionType ConditionType { get; set; }
        public List<SqlOption> Options { get; set; }
        public bool Required { get; set; }
        /// <summary>
        /// 是否已经生成EF代码
        /// </summary>
        internal virtual bool Have_Render_EF { get; set; }

        public ConditionInfo()
        {
            this.Options = new List<SqlOption>();
        }

        public virtual void Render(StringBuilder builder)
        {
        }

        public virtual string RenderEFSpec(StringBuilder builder, string modelName,string condition_class, ParameterList parameters)
        {
            return "";
            //builder.AppendLine(string.Format("x.{0} {1} {2}",this.));
        }

        public virtual void Wise(SelectAtomContext context)
        {

        }

        public virtual void RenderSql(StringBuilder builder)
        {

        }

        public virtual void RenderEF(string entity, StringBuilder builder)
        {

        }

        internal virtual void RenderEF(List<TableJoinInfo> join_list, StringBuilder builder)
        {

        }

        internal virtual void RenderEF_Join(string prevQuery, JoinType joinType, TableJoinInfo joinInfo, List<TableJoinInfo> join_list, StringBuilder builder, StringBuilder left_builder, StringBuilder right_builder)
        {

        }

        internal virtual bool ShouldRender_InSingleQuery(string entity)
        {
            return false;
        }
    }

    public class BetweenConditionInfo : ConditionInfo
    {
    }

    public class ExistsConditionInfo : ConditionInfo
    {
        public SelectContext SubContext { get; set; }

        public override void Render(StringBuilder builder)
        {
            builder.Append(EnumUtils.GetDescription(this.ConditionType));
            builder.Append(" ( ");
            SubContext.Render(builder);
            builder.Append(" ) ");
        }

        public override void Wise(SelectAtomContext context)
        {
            base.Wise(context);
        }

        public override string RenderEFSpec(StringBuilder builder, string modelName,string condition_class, ParameterList parameters)
        {
            return base.RenderEFSpec(builder, modelName,condition_class, parameters);
        }

        public override void RenderEF(string entity, StringBuilder builder)
        {
            base.RenderEF(entity, builder);
        }
    }

    public class OrConditionInfo : ConditionInfo
    {
        public List<AndConditionInfo> Conditions { get; set; }
        public OrConditionInfo()
        {
            Conditions = new List<AndConditionInfo>();
        }
        public override void Wise(SelectAtomContext context)
        {
            foreach (var and in Conditions)
            {
                and.Wise(context);
            }
            //base.Wise(context);
        }

        public override void Render(StringBuilder builder)
        {

            builder.Append(" ( ");
            for (var index = 0; index < Conditions.Count; index++)
            {
                if (index > 0)
                    builder.Append(" or ");

                Conditions[index].Render(builder);
            }

            builder.Append(" ) ");
        }

        public override void RenderSql(StringBuilder builder)
        {
            builder.Append(" ( ");
            for (var index = 0; index < Conditions.Count; index++)
            {
                if (index > 0)
                    builder.Append(" or ");

                Conditions[index].RenderSql(builder);
            }

            builder.Append(" ) ");
        }

        public override string RenderEFSpec(StringBuilder builder, string modelName,string condition_class, ParameterList parameters)
        {
            if (this.Conditions.Count == 0)
                return "";

            var and_conditions = new List<string>();

            if (this.Conditions.Count > 1)
            {
                SelectContext.IsInOrContext = true;
                SelectContext.OrConext.Push(true);
            }

            foreach (var condtion in this.Conditions)
            {
                and_conditions.Add(condtion.RenderEFSpec(builder, modelName,condition_class, parameters));
            }

            
            var returnName = and_conditions[0];

            if (and_conditions.Count > 1)
            {
                var name = and_conditions[0];
                var prevOr = "";
                var right = "";

                for (var index = 1; index < and_conditions.Count; index++)
                {
                    name += "_" + and_conditions[index];
                    name = name.Replace("_spec", "");
                    prevOr = and_conditions[index - 1];
                    right = and_conditions[index];

                    builder.AppendLine(string.Format("\t\t var {0} = new OrSpecification<{1}>({2},{3}); ",
                                name, modelName, prevOr, right));
                }

                returnName = name;
            }

            foreach (var op in this.Options)
            {
                if (op.Name.Equals( "hiddenby", StringComparison.OrdinalIgnoreCase))
                {
                    ParameterFieldInfo value = null;
                    List<List<ParameterFieldInfo>> values = new List<List<ParameterFieldInfo>>();
                    //List<ParameterFieldInfo> values = new List<ParameterFieldInfo>();
                    List<string> paras = new List<string>();
                    var or_list = op.Value.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var or in or_list)
                    {
                        var list = new List<ParameterFieldInfo>();
                        values.Add(list);
                        var and_list = or.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var and in and_list)
                        {
                            var para = parameters.Find(and,true);
                            if ( para == null ){
                                builder.AppendFormatLine("\t\t 没有该参数{0}", op.Value);
                                continue;
                            }

                            list.Add(para);
                        }
                    }
                    ////parameters.fin
                    //foreach (var para in parameters)
                    //{
                    //    if (para.FullName.Equals(op.Value))
                    //    {
                    //        value = para;
                    //    }
                    //}
                    //if (value == null)
                    //{
                    //    builder.AppendFormatLine("\t\t 没有该参数{0}", op.Value);
                    //    break;
                    //}
                    foreach (var or in values)
                    {
                        builder.AppendFormat("\t\t if (");
                        for (var index = 0; index < or.Count; index++)
                        {
                            var para = or[index];
                            if (index > 0)
                                builder.Append(" && ");
                            builder.AppendFormat("condition.{0}.IsNullOrEmpty()", para.ClassName);
                        }
                        builder.AppendLine("\t\t){");
                        var inOr = false;
                        if (this.Conditions.Count > 1)
                        {

                            if (SelectContext.OrConext.Count > 1)
                            {
                                inOr = SelectContext.OrConext.ToArray()[SelectContext.OrConext.Count - 2];
                            }
                            else
                            {
                                inOr = false;
                            }
                        }
                        else
                        {
                            if (SelectContext.OrConext.Count >= 1)
                            {
                                inOr = SelectContext.OrConext.Peek();
                            }
                            else
                            {
                                inOr = false;
                            }
                        }

                        builder.AppendFormatLine("\t\t\t{0} = new DirectSpecification<{1}>(x=> {2}); ", returnName, modelName, inOr ? "false" : "true");
                        builder.AppendLine("\t\t}");
                    }
                    //if (value.SystemType.Equals("string", StringComparison.OrdinalIgnoreCase))
                    //{
                    //    builder.AppendFormatLine("\t\t if (string.IsNullOrWhiteSpacecondition.{0}))", value.ClassName);
                    //}
                    //else
                    //{
                    //    builder.AppendFormatLine("\t\t if (condition.{0} == null)", value.ClassName);
                    //}
                    //builder.AppendLine("\t\t {");
                    //builder.AppendFormatLine("\t\t\t{0} = new DirectSpecification<{1}>(x=> true); ", returnName, modelName);
                    //builder.AppendLine("\t\t }");
                    builder.AppendLine();
                }
            }

            SelectContext.IsInOrContext = false;
            if (this.Conditions.Count > 1)
                SelectContext.OrConext.Pop();
            return returnName;
        }

        public override void RenderEF(string entity, StringBuilder builder)
        {
            foreach (var and in this.Conditions)
            {
                and.RenderEF(entity, builder);
            }
        }

        internal override void RenderEF(List<TableJoinInfo> join_list, StringBuilder builder)
        {
            builder.Append("(");
            for(var index = 0 ; index < this.Conditions.Count ; index ++ )
            {
                if (index > 0 && index <= this.Conditions.Count - 1)
                {
                    builder.Append(" || ");
                }

                Conditions[index].RenderEF(join_list, builder);               
            }
            builder.Append(")");
        }

        internal override void RenderEF_Join(string prevQuery, JoinType joinType, TableJoinInfo joinInfo, List<TableJoinInfo> join_list, StringBuilder builder, StringBuilder left_builder, StringBuilder right_builder)
        {
            if (this.Conditions.Count > 1)
            {
                builder.Append("关联查询不能有or关系");
                return;
            }
            foreach (var and in this.Conditions)
            {
                and.RenderEF_Join(prevQuery, joinType, joinInfo, join_list, builder,left_builder,right_builder);
            }
        }
    }

    public class AndConditionInfo : ConditionInfo
    {
        public List<CompareComplexConditionInfo> CompareComplexConditionInfos { get; set; }
        public AndConditionInfo()
        {
            CompareComplexConditionInfos = new List<CompareComplexConditionInfo>();
        }

        public List<CompareComplexConditionInfo> ShouldRender_InSingleQuery(string entity)
        {
            var rslt = new List<CompareComplexConditionInfo>();
            foreach (var condition in this.CompareComplexConditionInfos)
            {
                if (condition.ShouldRender_InSingleQuery(entity))
                {
                    rslt.Add(condition);
                }
            }
            return rslt;
        }

        public override void Wise(SelectAtomContext context)
        {
            foreach (var condition in CompareComplexConditionInfos)
            {
                condition.Wise(context);
            }
            //base.Wise(context);
        }

        public override void Render(StringBuilder builder)
        {
            for (var index = 0; index < CompareComplexConditionInfos.Count; index++)
            {
                if (index > 0)
                    builder.Append(" and ");

                CompareComplexConditionInfos[index].Render(builder);
            }
        }

        public override string RenderEFSpec(StringBuilder builder, string modelName,string condition_class, ParameterList parameters)
        {
            var and_conditions = new List<string>();

            if ( this.CompareComplexConditionInfos.Count > 1 )
                SelectContext.OrConext.Push(false);

            foreach (var condtion in this.CompareComplexConditionInfos)
            {
                and_conditions.Add(condtion.RenderEFSpec(builder, modelName,condition_class, parameters));
            }
            
            var returnName = and_conditions[0];

            if (and_conditions.Count > 1)
            {                
                var name = and_conditions[0];
                var prevOr = "";
                var right = "";

                for (var index = 1; index < and_conditions.Count; index++)
                {
                    if (index == 1)
                    {
                        prevOr = and_conditions[index - 1];
                    }
                    else
                    {
                        prevOr = name;
                    }

                    name += "_" + and_conditions[index];
                    name = name.Replace("_spec", "");

                    right = and_conditions[index];

                    builder.AppendLine(string.Format("\t\t ISpecification<{1}> {0} = new AndSpecification<{1}>({2},{3}); ",
                                name, modelName, prevOr, right));
                }

                returnName = name;
            }

            if (this.Options.Count > 0)
            {

            }

            if (this.CompareComplexConditionInfos.Count > 1)
                SelectContext.OrConext.Pop();

            return returnName;
        }

        internal void RenderSql(StringBuilder builder)
        {
            var and_conditions = new List<string>();

            foreach (var condtion in this.CompareComplexConditionInfos)
            {
                condtion.RenderSql(builder);
            }
        }

        internal override void RenderEF(List<TableJoinInfo> join_list, StringBuilder builder)
        {
            var need_render_conditon = new List<CompareComplexConditionInfo>();
            need_render_conditon.AddRange(this.CompareComplexConditionInfos);

            if (SelectContext.Root.Unions[0].Context.Condition.Conditions.Contains(this))
            {
                var rendered_conditon = new List<CompareComplexConditionInfo>();
                foreach (var joinInfo in join_list)
                {
                    var conditions = this.ShouldRender_InSingleQuery(joinInfo.Alias);
                    foreach (var cond in this.CompareComplexConditionInfos)
                    {
                        if (conditions.Contains(cond))
                        {
                            need_render_conditon.Remove(cond);
                        }
                    }
                }
            }

            for (var index = 0; index < need_render_conditon.Count; index++)
            {

                if (index > 0 && index <= need_render_conditon.Count - 1)
                {
                    builder.Append(" && ");
                }

                need_render_conditon[index].RenderEF(join_list, builder);

            }

        }

        public override void RenderEF(string entity, StringBuilder builder)
        {
            //for (var index = 0; index < this.CompareComplexConditionInfos.Count; index++)
            //{
            //    this.CompareComplexConditionInfos[index].RenderEF(entity, builder);
            //}

            var list = this.ShouldRender_InSingleQuery(entity);
            foreach (var condition in list)
            {
                condition.RenderEF(entity, builder);
            }
        }


        internal override void RenderEF_Join(string prevQuery, JoinType joinType, TableJoinInfo joinInfo, List<TableJoinInfo> join_list, StringBuilder builder, StringBuilder left_builder, StringBuilder right_builder)
        {
            left_builder = left_builder?? new StringBuilder();
            right_builder =right_builder??  new StringBuilder();
            
            for (var index = 0; index < this.CompareComplexConditionInfos.Count; index++)
            {                
                this.CompareComplexConditionInfos[index].RenderEF_Join(prevQuery, joinType,joinInfo, join_list,builder, left_builder,right_builder);
            }

            if (joinInfo.Condition.Conditions[0].CompareComplexConditionInfos.Count == 1)
                return;

            List<FieldInfo> join_codition_fields = new List<FieldInfo>();

            for (var index = 0; index < this.CompareComplexConditionInfos.Count; index++)
            {
                var binary = this.CompareComplexConditionInfos[index].AtomConditionInfo as BinaryConditionInfo;
                join_codition_fields.Add(binary.LeftValue);
            }
            //生成ef代码

            //获取左值和右值的表对象
            //var left_regular_field = this.LeftValue as FieldRegularInfo;
            //var right_regular_field = this.RightValue as FieldRegularInfo;
            //if ( left_regular_field == null || 
            //    right_regular_field == null)
            //{
            //    builder.AppendLine("关联条件必须都是表字段");
            //    return;
            //}

            var left_model = joinInfo.RightModelInfo.Name;
            var right_model = joinInfo.RightModelInfo.Name;
            var left_q_item = string.IsNullOrWhiteSpace(prevQuery) ? left_model + "_q" : prevQuery.Trim();
            var right_q_item = string.IsNullOrWhiteSpace(joinInfo.Alias) ? GeneratorHelper.VariableName(right_model + "_q") :
                joinInfo.Alias
                ;
            //var left_field = join.RightModelInfo.Name;
            //var right_field = join.RightModelInfo.Name;

            var left_linq = joinInfo.RightModelInfo.Name;
            left_linq = join_list[0].Alias ?? join_list[0].RightModelInfo.Name;
            var right_linq = joinInfo.RightModelInfo.Name;
            right_linq = joinInfo.Alias ?? joinInfo.RightModelInfo.Name;


            var right_q = string.IsNullOrWhiteSpace(joinInfo.Alias) ? GeneratorHelper.VariableName(right_model + "_q") :
                joinInfo.Alias + "_q"
                ;
            var join_codition = join_list[join_list.Count - 2].Alias + "_" + joinInfo.Alias;
            join_codition = GeneratorHelper.ClassName(SelectContext.Root.CurrentQuery + "_" + join_codition) + "_JoinCondition";

            var left_join_info = left_builder.ToString();
            left_join_info = left_join_info.EndsWith(",") ? left_join_info.Substring(0, left_join_info.Length - 1) : left_join_info;
            var right_join_info = right_builder.ToString();
            right_join_info = right_join_info.EndsWith(",") ? right_join_info.Substring(0, right_join_info.Length - 1) : right_join_info;

            //生成关联
            if (joinType == JoinType.Inner)
            {
                builder.AppendLine(string.Format("\t {0}.Join({1},{2}=>{2},{3}=>{3},",
                    prevQuery, right_q_item, left_builder,right_builder));

                builder.Append(string.Format("\t\t\t ({0},{1})=>new ", left_linq, right_linq));
                builder.Append("{ ");
                builder.Append(string.Format("{0},{1}", left_linq, right_linq));
                builder.AppendLine(" });");
                builder.AppendLine();
            }
            else if (joinType == JoinType.Left)
            {

                builder.AppendLine(string.Format("\t {0}.GroupJoin({1},{2}=>new {3}@@@{4}@@,\r\n\t\t{5}=>new {3}@@@{6}@@,",
                    prevQuery, right_q, left_linq, join_codition, left_join_info, right_q_item, right_join_info).Replace("@@@", "{")
                    .Replace("@@","}")
                    );

                builder.Append(string.Format("\t\t\t ({0},{1})=>new ", left_linq, right_linq));
                builder.Append("{ ");
                builder.Append(string.Format("{0},{1} = {1}.DefaultIfEmpty()", left_linq, right_linq));
                builder.AppendLine(" })");

                builder.Append(string.Format("\t\t\t .SelectMany(item=>item.{0}.Select({0}=> new ", right_linq));
                builder.Append("{");
                for (var index = 0; index < join_list.Count; index++)
                {
                    var join = join_list[index];
                    var alias_table = !string.IsNullOrWhiteSpace(join.Alias) ? join.Alias
                           : GeneratorHelper.ClassName(join.RightModelInfo.Name);

                    if (index < join_list.Count - 1)
                    {
                        if (join_list.Count == 2)
                        {
                            builder.AppendFormat("item.{0},", alias_table);
                        }
                        else
                        {
                            builder.AppendFormat("item.{0}.{1},", left_linq, alias_table);
                        }
                    }
                    else
                    {
                        builder.AppendFormat("{0}", alias_table);
                    }

                }
                builder.AppendLine("}));");
                builder.AppendLine();
            }
        }

   
    }
    public class CompareComplexConditionInfo : ConditionInfo
    {
        /// <summary>
        /// AtomConditionInfo 无效
        /// </summary>
        public OrConditionInfo OrConditionInfo { get; set; }

        /// <summary>
        /// OrConditionInfo 无效
        /// </summary>
        public ConditionInfo AtomConditionInfo { get; set; }

        public override void Wise(SelectAtomContext context)
        {
            if (OrConditionInfo != null)
                OrConditionInfo.Wise(context);

            if (AtomConditionInfo != null)
                AtomConditionInfo.Wise(context);
            //base.Wise(context);
        }

        public override void Render(StringBuilder builder)
        {
            if (OrConditionInfo != null)
                OrConditionInfo.Render(builder);

            if (AtomConditionInfo != null)
                AtomConditionInfo.Render(builder);
        }

        public override string RenderEFSpec(StringBuilder builder, string modelName,string condition_class, ParameterList parameters)
        {

            if (OrConditionInfo != null)
            {
                OrConditionInfo.Options.AddRange(this.Options);
                return OrConditionInfo.RenderEFSpec(builder, modelName, condition_class, parameters);
            }

            if (AtomConditionInfo != null)
                return AtomConditionInfo.RenderEFSpec(builder, modelName,condition_class, parameters);

            return "";
        }

        internal void RenderSql(StringBuilder builder)
        {
            if (OrConditionInfo != null)
                OrConditionInfo.RenderSql(builder);

            if (AtomConditionInfo != null)
                AtomConditionInfo.RenderSql(builder);
        }

        public override void RenderEF(string entity, StringBuilder builder)
        {
            if (OrConditionInfo != null)
            {
                OrConditionInfo.RenderEF(entity, builder);
            }

            if (AtomConditionInfo != null)
            {
                AtomConditionInfo.RenderEF(entity, builder);
            }
        }

        internal override void RenderEF(List<TableJoinInfo> join_list, StringBuilder builder)
        {
            if (OrConditionInfo != null)
            {
                OrConditionInfo.RenderEF(join_list, builder);
            }

            if (AtomConditionInfo != null)
            {
                AtomConditionInfo.RenderEF(join_list, builder);
            }
        }

        internal void RenderEF_Join(string prevQuery, JoinType joinType, TableJoinInfo joinInfo, List<TableJoinInfo> join_list, StringBuilder builder, StringBuilder left_builder, StringBuilder right_builder)
        {
            if (OrConditionInfo != null)
            {
                OrConditionInfo.RenderEF_Join(prevQuery, joinType,joinInfo, join_list, builder,left_builder,right_builder);
            }

            if (AtomConditionInfo != null)
            {
                AtomConditionInfo.RenderEF_Join(prevQuery, joinType,joinInfo, join_list, builder,left_builder,right_builder);
            }
        }

        internal override bool ShouldRender_InSingleQuery(string entity)
        {

            if (this.AtomConditionInfo == null)
                return false;

            //

            return this.AtomConditionInfo.ShouldRender_InSingleQuery(entity);
        }

        internal override bool Have_Render_EF
        {
            get
            {
                if (this.AtomConditionInfo != null)
                    return this.AtomConditionInfo.Have_Render_EF;

                return base.Have_Render_EF;
            }
            set
            {
                base.Have_Render_EF = value;
            }
        }
    }
    /// <summary>
    /// 查询参数
    /// </summary>
    public class ParameterFieldInfo : FieldInfo
    {
        public string Name { get; set; }

        //public DbType DbType { get; set; }

        public bool IsList { get; set; }

        public List<SqlOption> Options { get; set; }

        //public bool NullAble { get; set; }

        public override string FullName
        {
            get
            {
                return this.Name;
            }
           
        }

        public override string ShortName
        {
            get
            {
                return this.Name.Substring(1);
            }
        }

        public ParameterFieldInfo()
        {
            NullAble = true;
            Options = new List<SqlOption>();
        }

        public override string SystemType
        {
            get
            {
                if (this.IsList)
                    return "List<" + base.SystemType.Replace("?", "") + ">";
                return base.SystemType;
            }
        }

        public override string RenderEFCondtion()
        {
            return "condition." + this.ClassName;
        }

        public override void Wise(SelectAtomContext context)
        {
            var para = new ParameterFieldInfo();
            para.Name = this.Name;
            context.Parameters.Add(para);
        }
    }

    /// <summary>
    /// join关联的条件信息
    /// </summary>
    public class JonOnCondition
    {
        public FieldInfo LeftField { get; set; }

        public FieldInfo RightField { get; set; }

        /// <summary>
        /// on > < 等等操作符
        /// </summary>
        public string Condition { get; set; }
    }

    /// <summary>
    /// join 的类别
    /// </summary>
    public enum JoinType
    {
        /// <summary>
        /// 表示查询的第一个表（不论是否有连接）
        /// </summary>
        First,
        [Description("outer")]
        Outer,
        [Description("left outer join")]
        Left,
        [Description("right outer join")]
        Right,
        [Description("inner join")]
        Inner,
        [Description("unkown")]
        Unkown
    }

    public class TableJoinInfo
    {
        //public TableJoinInfo PrevTableJoinInfo { get; set; }
        public string LeftTable { get; set; }
        public TableInfo LeftTableInfo { get; set; }
        public JoinType JoinType { get; set; }
        public string RightTable { get; set; }
        public TableInfo RightTableInfo { get; set; }
        public ModelInfo RightModelInfo { get; set; }
        //public List<JonOnCondition> JonOnConditions { get; set; }
        public OrConditionInfo Condition { get; set; }
        public SelectAtomContext ParentContext { get; set; }
        //SqlContext subContext = null;
        /// <summary>
        /// 用于描述用查询构造的表，形如：(select * from A) T
        /// </summary>
        public SelectContext SubContext { get; set; }
        public string Alias { get; set; }

        public TableJoinInfo()
        {
            //this.JonOnConditions = new List<JonOnCondition>();
        }

        public void Wise(SelectAtomContext context)
        {
            this.RightTableInfo = GlobalService.ResloveTableAgent.Reslove(this.RightTable);
            this.RightModelInfo = GlobalService.ResloveTableAgent.ResloveMapModel(this.RightTable);

            //if (this.SubContext == null)
            //{
            //    this.RightTableInfo = GlobalService.ResloveTableAgent.Reslove(this.RightTable);
            //}
            //else
            //{
            //    //this.SubContext.Wise(context);
            //}

            if (Condition != null)
            {
                Condition.Wise(context);
            }

        }

        public FieldInfo ResolveFieldType(string fieldName)
        {
            if (this.RightTableInfo == null)
                return null;

            foreach (var f in this.RightModelInfo.Fields)
            {
                if (f.FullName.Equals(fieldName, StringComparison.OrdinalIgnoreCase))
                {
                    return f;
                }
            }

            return null;
        }

        public void Render(StringBuilder builder)
        {
            builder.Append(" on ");
            this.Condition.Render(builder);
        }

        internal void RenderSql(StringBuilder builder)
        {
            builder.AppendLine(" on ");
            this.Condition.RenderSql(builder);
        }

        internal void RenderEF(string prevQuery, JoinType joinType, List<TableJoinInfo> join_list, StringBuilder builder)
        {
            if (this.JoinType == DataViews.JoinType.First)
            {
                var entity = this.RightModelInfo.Name;
            }
            if (this.JoinType == DataViews.JoinType.Unkown)
            {
            }
            if (this.JoinType == DataViews.JoinType.Inner || this.JoinType == DataViews.JoinType.Left)
            {
                this.Condition.RenderEF_Join(prevQuery, joinType,this, join_list, builder,null,null);
            }
        }
    }

    public class SelectJoinInfo : TableJoinInfo
    {
    }

    public enum OrderType
    {
        Asc, Desc
    }

    public class OrderInfo
    {
        public string Table { get; set; }
        public string Field { get; set; }
        public OrderType OrderType { get; set; }

        public void Render(StringBuilder builder)
        {
            builder.Append(string.Format("{0}{1}"
                , string.IsNullOrWhiteSpace(Table) ? "" : Table + ".", Field));

            switch (OrderType)
            {
                case DataViews.OrderType.Asc:
                    builder.Append(" asc ");
                    break;
                case DataViews.OrderType.Desc:
                    builder.Append(" desc ");
                    break;
                default:
                    break;
            }

        }

        internal void RenderSql(StringBuilder builder)
        {
            throw new NotImplementedException();
        }
    }

    public class SqlOption
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class SqlResult
    {
        public List<SqlOption> Options { get; set; }
        public SelectAtomContext Context { get; set; }
        public bool IsEnablePager { get; set; }

        public SqlResult()
        {
            this.Options = new List<SqlOption>();
        }
    }

    //public class HavingInfo
    //{
    //    public List<ConditionComplexInfo> Conditions { get; set; }
    //    public List<RelationType> RelationTypes { get; set; } 
    //    public HavingInfo()
    //    {
    //        this.Conditions = new List<ConditionComplexInfo>();
    //        this.RelationTypes = new List<RelationType>();
    //    }

    //    public void Render(StringBuilder builder)
    //    {
    //        builder.Append(" having ");
    //        for (int index = 0; index < this.Conditions.Count; index++)
    //        {
    //            if (index > 0)
    //            {
    //                builder.Append("( ");
    //            }
    //            this.Conditions[index].Render(builder);
    //            if (index > 0)
    //            {
    //                builder.Append(" )");
    //            }
    //            if (this.RelationTypes.Count > 0 && index < this.RelationTypes.Count)
    //            {
    //                builder.Append(" " + EnumUtils.GetDescription(this.RelationTypes[index]) + " ");
    //            }
    //        }

    //    }
    //}

    public class GroupInfo
    {
        public bool IsEmpty()
        {
            return Fields == null || Fields.Count == 0;
        }

        public List<string> Fields { get; set; }
        public HavingInfo Having { get; set; }

        public GroupInfo()
        {
            this.Fields = new List<string>();
            //this.Having = new HavingInfo();
        }

        public void Render(StringBuilder builder)
        {
            if (this.Fields.Count == 0)
                return;

            builder.AppendLine();
            builder.Append(" group by ");
            for (int index = 0; index < this.Fields.Count; index++)
            {
                builder.Append(this.Fields[index]);

                if (index < this.Fields.Count - 1)
                {
                    builder.Append(" , ");
                }

            }
            if (this.Having != null)
            {
                this.Having.Render(builder);
            }
        }

        public void Wise(SelectAtomContext context)
        {
            if (Having != null)
            {
                Having.Wise(context);
            }
        }

        internal void RenderSql(StringBuilder builder)
        {
            if (this.Fields.Count == 0)
                return;

            builder.AppendLine();
            builder.Append(" group by ");
            for (int index = 0; index < this.Fields.Count; index++)
            {
                builder.Append(this.Fields[index]);

                if (index < this.Fields.Count - 1)
                {
                    builder.Append(" , ");
                }

            }
            if (this.Having != null)
            {
                this.Having.RenderSql(builder);
            }
        }
    }

    public enum ContextType
    {
        Unknown, Select, Join, Function, In, Exists, Having, Program
    }

    public class ExpressionInfo
    {

    }

    public class MultiplicativeExpressionInfo : ExpressionInfo
    {
        public List<PositiveExpressionInfo> PositiveExpressionInfos { get; set; }
        public List<string> Operators { get; set; }
        public MultiplicativeExpressionInfo()
        {
            this.PositiveExpressionInfos = new List<PositiveExpressionInfo>();
            this.Operators = new List<string>();
        }
    }
    public class PositiveExpressionInfo : ExpressionInfo
    {
        public bool IsPositive { get; set; }
        public UnaryOperatorInfo UnaryOperatorInfo { get; set; }
    }
    public enum PredicationType
    {
        [Description("Unknown")]
        Unknown,
        [Description("any")]
        Any,
        [Description("some")]
        Some,
        [Description("all")]
        All
    }
    public class PredicationFieldInfo : FieldInfo
    {
        public PredicationType PredicationType { get; set; }
        public SelectContext SelectContext { get; set; }

        //public override void Wise(SelectAtomContext context)
        //{
        //    //base.Wise(context);
        //}
        public override void Render(StringBuilder builder)
        {
            builder.Append(EnumUtils.GetDescription(this.PredicationType));
            builder.Append("(");
            SelectContext.Render(builder);
            //builder.Append();
            builder.Append(")");
        }
    }
    public class BinaryExpressionFieldInfo : FieldInfo
    {
        public List<MultiplicativeExpressionInfo> MultiplicativeExpressionInfos { get; set; }
        public List<string> Operators { get; set; }
        public BinaryExpressionFieldInfo()
        {
            this.MultiplicativeExpressionInfos = new List<MultiplicativeExpressionInfo>();
            this.Operators = new List<string>();
        }

        public override void Render(StringBuilder builder)
        {
            for (var index = 0; index < MultiplicativeExpressionInfos.Count; index++)
            {
                //MultiplicativeExpressionInfos[index].ren
            }
        }
        public override string RenderEFCondtion()
        {
            return "";
        }
    }


    public class UnaryOperatorInfo : ExpressionInfo
    {
        public bool IsNegate { get; set; }
        public FieldInfo FieldInfo { get; set; }

    }
    public enum UnionType
    {
        [Description("unkown")]
        Unkown,
        [Description("union")]
        Union,
        [Description("union all")]
        Union_All,
        [Description("except")]
        Except,
        [Description("intersect")]
        Intersect
    }
    public class UnionContext
    {
        public SelectAtomContext Context { get; set; }
        public UnionType UnionType { get; set; }

        internal void RenderEF(StringBuilder builder)
        {
            this.Context.RenderEF(builder);
        }
    }

    public class ParameterList : IList<ParameterFieldInfo>
    {
        List<ParameterFieldInfo> list = new List<ParameterFieldInfo>();
        Dictionary<string, int> uses = new Dictionary<string, int>();

        public string Use(string para)
        {
            if (!uses.ContainsKey(para))
            {
                uses.Add(para, 1);
                return para;
            }

            uses[para] = uses[para] + 1;

            return para + uses[para];
        }

        public int IndexOf(ParameterFieldInfo item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, ParameterFieldInfo item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public ParameterFieldInfo this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        public void Add(ParameterFieldInfo item)
        {
            if (list.FirstOrDefault(x => x.Name.Equals(item.Name, StringComparison.OrdinalIgnoreCase)) == null)
                list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(ParameterFieldInfo item)
        {
            return list.Contains(item);
        }

        public void CopyTo(ParameterFieldInfo[] array, int arrayIndex)
        {
            //throw new NotImplementedException();
            list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(ParameterFieldInfo item)
        {
            return list.Remove(item);
        }

        public IEnumerator<ParameterFieldInfo> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public ParameterFieldInfo Find(string name, bool ingoreCase = false)
        {
            StringComparison sc = ingoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            foreach (var p in this.list)
            {
                if (p.Name.Equals(name, sc) || p.FullName.Equals(name, sc))
                {
                    return p;
                }
            }

            return null;
        }
    }

    public class SelectContext
    {
        public ContextType ContextType { get; set; }
        public List<UnionContext> Unions { get; set; }
        public SelectContext ParentContext { get; set; }
        public ParameterList Parameters { get; set; }
        public static SelectContext Root { get; set; }
        /// <summary>
        /// 当前层or到最高层or构成的堆栈
        /// </summary>
        public static Stack<bool> OrConext { get; set; }
        /// <summary>
        /// 当前的条件是否在一个or条件下（前提是or中有两个and）
        /// </summary>
        public static bool IsInOrContext { get; set; }
        static SelectContext()
        {
            OrConext = new Stack<bool>();
        }

        public SelectContext()
        {
            Unions = new List<UnionContext>();
            Parameters = new ParameterList();
        }

        public void Wise(SelectContext context)
        {
            foreach (var union in Unions)
            {
                union.Context.Wise(this);
            }
        }

        public void Render(StringBuilder builder)
        {
            for (var index = 0; index < Unions.Count; index++)
            {
                var union = Unions[index];
                union.Context.Render(builder);

                if (this.Unions.Count == 1 || index >= Unions.Count - 1)
                    return;


                builder.AppendLine();
                builder.AppendLine(EnumUtils.GetDescription(union.UnionType));
            }
        }

        public void RenderSql(StringBuilder builder)
        {
            for (var index = 0; index < Unions.Count; index++)
            {
                var union = Unions[index];
                union.Context.RenderSql(builder);

                if (this.Unions.Count == 1 || index >= Unions.Count - 1)
                    return;


                builder.AppendLine();
                builder.AppendLine(EnumUtils.GetDescription(union.UnionType));
            }
        }

        public void RenderEF(StringBuilder builder)
        {
            for (var index = 0; index < this.Unions.Count; index++)
            {
                this.Unions[index].RenderEF(builder);

                if (index > 1)
                {
                }
            }
        }

        public string CurrentQuery { get; set; }
    }

    public class SelectAtomContext
    {
        public SelectAtomContext ParentContext { get; set; }
        public ContextType ContextType { get; set; }
        //public List<UnionContext> Unions { get; set; }

        //public List<SqlContext> SubContexts { get; set; }
        public FieldInfo TopValue { get; set; }
        public List<FieldInfo> ReturnFields { get; set; }
        public ParameterList Parameters { get; set; }
        public List<TableJoinInfo> TableJoinInfos { get; set; }
        public OrConditionInfo Condition { get; set; }
        public List<RelationType> RelationTypes { get; set; }
        public GroupInfo Group { get; set; }
        public List<OrderInfo> OrderInfos { get; set; }
        public List<ParseErrorInfo> Errors { get; set; }

        public SelectContext SelectContext { get; set; }

        public static Stack<ConditionComplexInfo> Condition_Stack { get; set; }
        public static Stack<SelectAtomContext> Context_Stack { get; set; }
        static SelectAtomContext()
        {
            Condition_Stack = new Stack<ConditionComplexInfo>();
            Context_Stack = new Stack<SelectAtomContext>();
        }
        public void PushParamter(ParameterFieldInfo para)
        {
            SelectAtomContext top = this;
            while (top.ParentContext != null)
            {
                if (top.ParentContext.ParentContext == null)
                {
                    top.ParentContext.Parameters.Add(para);
                    break;
                }
                top = top.ParentContext;
            }

        }

        public SelectAtomContext()
        {
            this.ReturnFields = new List<FieldInfo>();
            this.Parameters = new ParameterList();
            this.Condition = new OrConditionInfo();
            //this.Conditions = new List<ConditionComplexInfo>();
            //this.Groups = new List<GroupInfo>();
            this.Group = new GroupInfo();
            this.OrderInfos = new List<OrderInfo>();
            this.TableJoinInfos = new List<TableJoinInfo>();
            //this.SubContexts = new List<SqlContext>();
            this.Errors = new List<ParseErrorInfo>();
            this.RelationTypes = new List<RelationType>();
            //Unions = new List<UnionContext>();
        }

        public void Wise(SelectContext context)
        {
            //context = context == null ? this : context;            
            if (this.TopValue != null)
            {
                this.TopValue.Wise(this);
                this.TopValue.DbType = DbType.Int;
                this.TopValue.NullAble = false;
                if (this.TopValue is ParameterFieldInfo)
                {
                    SelectContext.Root.Parameters.Add(this.TopValue as ParameterFieldInfo);
                }
            }

            foreach (var table in this.TableJoinInfos)
            {
                table.Wise(this);
            }

            foreach (var condition in this.Condition.Conditions)
            {
                condition.Wise(this);
            }

            if (this.Group != null)
            {
                this.Group.Wise(this);
            }

            foreach (var field in this.ReturnFields)
            {
                field.Wise(this);
            }

            var exsitedParas = new List<string>(this.Parameters.Count);

            for (var i = 0; i < this.Parameters.Count; i++)
            {
                if (!exsitedParas.Contains(this.Parameters[i].Name))
                {
                    exsitedParas.Add(this.Parameters[i].Name);
                }
                else
                {
                    this.Parameters.Remove(this.Parameters[i]);
                    i--;
                }
            }
            foreach (var p in this.Parameters)
            {
                this.PushParamter(p);
            }

            //SelectContext.Root.Parameters.AddRange(this.Parameters);
        }

        public string Render(StringBuilder builder = null)
        {
            if (builder == null)
            {
                builder = new StringBuilder();
            }
            builder.Append("select ");
            for (var index = 0; index < this.ReturnFields.Count; index++)
            {
                if (index > 0 && index < this.ReturnFields.Count)
                {
                    builder.Append(",");
                }
                this.ReturnFields[index].Render(builder);
            }

            if (TableJoinInfos.Count > 0)
            {
                builder.Append(" from ");
                for (var index = 0; index < this.TableJoinInfos.Count; index++)
                {
                    var t = this.TableJoinInfos[index];
                    if (t.JoinType == JoinType.First)
                    {
                        builder.Append(t.RightTable);
                    }
                    else
                    {
                        builder.Append(" " + EnumUtils.GetDescription(t.JoinType) + " ");
                        builder.Append(t.RightTable);
                        t.Render(builder);
                    }
                }

                if (this.Condition != null && this.Condition.Conditions.Count > 0)
                {
                    builder.AppendLine();
                    builder.Append(" where ");
                    this.Condition.Render(builder);
                }
                if (this.Group != null)
                {
                    this.Group.Render(builder);
                }
            }
            if (this.OrderInfos.Count > 0)
            {
                //builder.AppendLine();
                builder.Append(" order by ");
                foreach (var order in this.OrderInfos)
                {
                    order.Render(builder);
                }
            }
            //builder.Append(
            return builder.ToString();
        }

        public DbType ResolveFieldType(string fieldName, out bool nullAble, out string table_name, out string model_name)
        {
            DbType? type = null;
            table_name = null;
            model_name = null;
            nullAble = true;

            foreach (var table in this.TableJoinInfos)
            {
                var ss = fieldName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                var table_alias = "";
                var field_name = fieldName;
                if (ss.Length == 2)
                {
                    table_alias = ss[0];
                    field_name = ss[1];
                }

                if (table.Alias == table_alias || table.RightTable == table_alias || string.IsNullOrWhiteSpace(table_alias))
                {
                    table_name = table.RightTable;
                    if ( table.RightModelInfo != null )
                        model_name = table.RightModelInfo.Name;

                    var f = table.ResolveFieldType(field_name);
                    if (f != null)
                    {
                        type = f.DbType;
                        nullAble = f.NullAble;
                        if (type.HasValue)
                            return type.Value;
                    }

                }
            }
            if (type == null)
            {
                if (this.ParentContext != null)
                {
                    type = this.ParentContext.ResolveFieldType(fieldName, out nullAble, out table_name, out model_name);
                    if (type.HasValue)
                        return type.Value;
                }
            }

            return DbType.Unknown;
        }

        public DbType ResolveFieldType(string fieldName, out bool nullAble)
        {
            string _table, _model;

            return ResolveFieldType(fieldName, out nullAble, out _table, out _model);
        }

        public ModelInfo ResolveModelType(string tableName)
        {
            foreach (var table in this.TableJoinInfos)
            {
                if (table.RightTable.Equals(tableName, StringComparison.OrdinalIgnoreCase) ||
                     table.Alias.Equals(tableName, StringComparison.OrdinalIgnoreCase))
                {
                    return table.RightModelInfo;
                }
            }

            return null;
        }

        public string ResolveTableAlias(string alias)
        {
            foreach (var table in this.TableJoinInfos)
            {
                if (table.Alias.Equals(alias, StringComparison.OrdinalIgnoreCase))
                    return table.Alias;
                if (table.RightTable.Equals(alias, StringComparison.OrdinalIgnoreCase))
                    return table.RightTable;
            }

            return null;
        }

        internal void RenderSql(StringBuilder builder)
        {
            if (builder == null)
            {
                builder = new StringBuilder();
            }
            builder.Append("select ");
            for (var index = 0; index < this.ReturnFields.Count; index++)
            {
                if (index > 0 && index < this.ReturnFields.Count)
                {
                    builder.Append(",");
                }
                this.ReturnFields[index].RenderSql(builder);
            }

            if (TableJoinInfos.Count > 0)
            {
                builder.Append(" from ");
                for (var index = 0; index < this.TableJoinInfos.Count; index++)
                {
                    var t = this.TableJoinInfos[index];
                    if (t.JoinType == JoinType.First)
                    {
                        builder.Append(t.RightTable);
                    }
                    else
                    {
                        builder.Append(" " + EnumUtils.GetDescription(t.JoinType) + " ");
                        builder.Append(t.RightTable);
                        t.RenderSql(builder);
                    }
                }

                if (this.Condition != null && this.Condition.Conditions.Count > 0)
                {
                    builder.AppendLine();
                    builder.Append(" where ");
                    this.Condition.RenderSql(builder);
                }
                if (this.Group != null)
                {
                    this.Group.RenderSql(builder);
                }
            }
            if (this.OrderInfos.Count > 0)
            {
                builder.Append(" order by ");
                foreach (var order in this.OrderInfos)
                {
                    order.RenderSql(builder);
                }
            }
        }

        internal void RenderEF(StringBuilder builder)
        {
            string first_q = null ;

            for (var index = 0; index < this.TableJoinInfos.Count(); index++)
            {

                var alias = this.TableJoinInfos[index].Alias ?? this.TableJoinInfos[index].RightModelInfo.Name;                
                var q_name = alias + "_q";

                if (index == 0)
                    first_q = q_name;

                var entity = this.TableJoinInfos[index].RightModelInfo.Name;
                builder.AppendLine(string.Format("\t var {0} = ctx.Set<{1}>().AsQueryable();",
                    GeneratorHelper.VariableName(q_name), entity));

                this.Condition.RenderEF(alias, builder);
            }

            builder.AppendLine(string.Format("\t var q = {0};",
                first_q));

            this.Condition.RenderEF("", builder);

            builder.AppendLine();

            var prevQuery = "q";
            var join_list = new List<TableJoinInfo>();

            var q = "q_1";
            for (var index = 0; index < this.TableJoinInfos.Count(); index++)
            {
                var tableJoin = this.TableJoinInfos[index];

                join_list.Add(this.TableJoinInfos[index]);

                if (index > 1)
                {
                    prevQuery = q;
                    q = "q_" + index;
                }
                if (index > 0)
                {
                    builder.AppendFormat("\t var {0} =", q);
                    tableJoin.RenderEF(prevQuery, tableJoin.JoinType, join_list, builder);
                }
            }

            builder.AppendLine(string.Format("\t var q_final = {0}.Where(x=>", q));
            builder.Append("\t\t ");
            var sb = new StringBuilder();
            this.Condition.RenderEF(TableJoinInfos, sb);
            if (sb.ToString() == "()")
            {
                builder.Append("true");
            }
            else
            {
                builder.Append(sb.ToString());
            }
            builder.AppendLine(");");
            //builder.AppendFormat("\t var q_final = {0};", q);
            builder.AppendLine();

        }
    }


    public static class SqlContextExtenstion
    {
        //public static SqlContext Join1(this SqlContext left, SqlContext right)
        //{
        //    try
        //    {
        //        var newCtx = left;
        //        //newCtx.ParentContext = left.ParentContext;
        //        //newCtx.ContextType = left.ContextType;

        //        //newCtx.Conditions.AddRange(left.Conditions);
        //        newCtx.Condition.Conditions.AddRange(right.Condition.Conditions);

        //        //newCtx.Errors.AddRange(left.Errors);
        //        newCtx.Errors.AddRange(right.Errors);

        //        //newCtx.Group.Fields.AddRange(left.Group.Fields);

        //        //newCtx.Group.Having.Conditions.AddRange(left.Group.Having.Conditions);

        //        newCtx.Group.Fields.AddRange(right.Group.Fields);
        //        newCtx.Group.Having.Conditions.AddRange(right.Group.Having.Conditions);

        //        //newCtx.OrderInfos.AddRange(left.OrderInfos);
        //        newCtx.OrderInfos.AddRange(right.OrderInfos);

        //        //newCtx.Parameters.AddRange(left.Parameters);
        //        newCtx.Parameters.AddRange(right.Parameters);

        //        //newCtx.RelationTypes.AddRange(left.RelationTypes);
        //        newCtx.RelationTypes.AddRange(right.RelationTypes);

        //        //newCtx.ReturnFields.AddRange(left.ReturnFields);
        //        newCtx.ReturnFields.AddRange(right.ReturnFields);

        //        //newCtx.TableJoinInfos.AddRange(left.TableJoinInfos);
        //        newCtx.TableJoinInfos.AddRange(right.TableJoinInfos);

        //        return newCtx;
        //    }
        //    catch (Exception e)
        //    {
        //        return left;
        //    }

        //}
    }

    public class ComputeNode
    {
        public SelectAtomContext Compute(SelectAtomContext ctx)
        {
            return null;
        }
    }


}

