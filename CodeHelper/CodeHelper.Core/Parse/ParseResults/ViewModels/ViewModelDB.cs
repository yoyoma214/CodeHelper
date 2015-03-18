using System;
using System.Collections.Generic;
using CodeHelper.Core.Error;
using System.ComponentModel;
using CodeHelper.Common.Extensions;
using System.Text;
using CodeHelper.Common;

namespace CodeHelper.Core.Parse.ParseResults.ViewModels
{
    public static class ListExtension
    {
        public static List<T> SubList<T>(this List<T> list, int index)
        {
            if (list == null)
                return null;
            var temp = new List<T>();
            for (var i = index; i < list.Count; i++)
            {
                temp.Add(list[i]);
            }
            
            return temp;
        }

        public static List<T> SubList<T>(this List<T> list, int from,int to)
        {
            if (list == null)
                return null;

            var temp = new List<T>();
            for (var i = from; i < to; i++)
            {
                temp.Add(list[i]);
            }

            return temp;
        }
    }

    public class AttributeInfo 
    {
        public TokenPair TokenPair { get; set; }
        public String Name { get; set; }
        public String Value { get; set; }

        internal void Wise(ModelInfo modelInfo)
        {
            var f = new T_Field();
        }
        public AttributeInfo(TokenPair token)
        {
            this.TokenPair = token;
        }
    }

    public class OptionInfo 
    {
        public TokenPair TokenPair { get; set; }
        public String Name { get; set; }
        public String Value { get; set; }
        public OptionInfo(TokenPair token)
        {
            this.TokenPair = token;
        }
    }

    public class FieldInfo
    {
        public TokenPair TokenPair { get; set; }
        public String Type_name { get; set; }
        public String Name { get; set; }
        public ExpressionStatementInfo Default_value { get; set; }
        public List<OptionInfo> Options { get; set; }
        public T_Type TypeInfo { get;private set; }
        public T_InputType Input { get; set; }

        public FieldInfo(TokenPair token)
        {
            this.TokenPair = token;
            Options = new List<OptionInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            builder.AppendFormat("{0} {1}", Type_name, Name);
            if (Default_value != null)
            {
                builder.Append("=" + Default_value);
                Default_value.Render(builder);
            }

            if (this.Options.Count > 0)
                builder.Append("{");
            for(var index = 0 ; index < this.Options.Count ;index ++)
            {
                if (index > 0 && index <= this.Options.Count - 1)
                {
                    builder.Append(", ");
                }
                builder.AppendFormat("{0} ={1}", Options[index].Name, Options[index].Value);
            }
            if (this.Options.Count > 0)
                builder.Append("}");
            builder.AppendLine(";");
        }

        internal void Wise(ModelInfo modelInfo)
        {
            //判断类型是否存在
            this.TypeInfo = T_Type.ParseType(this.Type_name);
            if (this.TypeInfo == null)
            {
                ViewModelDB.Current.AddError("不支持此类型" + this.Type_name, this.TokenPair.BeginToken);
                return;
            }

            foreach (var f in modelInfo.FieldInfos)
            {
                if (f.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase) && f != this)
                {
                    ViewModelDB.Current.AddError("重复定义" + this.Name, this.TokenPair.BeginToken);
                    return;
                }
            }

            this.Input = new T_InputType(this.TypeInfo);
            
            modelInfo.Fields.Add(new T_Field() { Name = this.Name, Type = this.Input });
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {

            if (this.IsKey)
            {
                builder.AppendFormatLine(@"<input type=""hidden"" name=""{0}"" id=""{0}""/>", this.Name);
                return;
            }

            builder.AppendFormatLine("<div class='field'>");
            builder.AppendFormatLine("<div class='title'><span>{0}:</span></div>",this.Name);
            builder.AppendFormatLine("<div class='input'>");
            
            if (this.InputType == ViewModels.InputType.Text)
            {
                builder.AppendFormatLine(@"<input type=""text"" name=""{0}"" id=""{0}""/>", this.Name);
            }
            else if (this.InputType == ViewModels.InputType.Select)
            {
                builder.AppendFormatLine(
@"<select  name=""{0}"" id=""{0}"">
    <option selected=""selected"" value="""">--请选择--</option>    
</select>", this.Name);
            }

            builder.AppendFormatLine("</div>");
            builder.AppendFormatLine("</div>");
        }

        public bool IsKey
        {
            get
            {
                var ops = this.Options;
                if (ops == null)
                    return false;

                foreach (var op in ops)
                {
                    if (op.Name.Equals("IsKey", StringComparison.OrdinalIgnoreCase))
                    {
                        return "true".Equals(op.Value, StringComparison.OrdinalIgnoreCase);
                    }
                }

                return false;
            }
        }

        public InputType InputType
        {
            get
            {
                var ops = this.Options;
                if (ops == null)
                    return InputType.Text;

                foreach (var op in ops)
                {
                    if (op.Name.Equals("control", StringComparison.OrdinalIgnoreCase))
                    {
                        if ("text".Equals(op.Value, StringComparison.OrdinalIgnoreCase))
                            return ViewModels.InputType.Text;
                        if ("select".Equals(op.Value, StringComparison.OrdinalIgnoreCase))
                            return ViewModels.InputType.Select;
                    }
                }
                return InputType.Text;
            }
        }
    }

    public enum InputType
    {
        Text,Select
    }

    public class ModelInfo :T_Type
    {
        public TokenPair TokenPair { get; set; }

        #region 静态信息
        public String Area { get; set; }

        public List<AttributeInfo> Attributes { get; set; }

        public String Name { get; set; }

        public List<FieldInfo> FieldInfos { get; set; }
        
        //public T_Field GetField(string name)
        //{
        //    foreach (var f in Fields)
        //    {
        //        if (f.Name.Equals(name))
        //            return f;
        //    }

        //    return null;
        //}
        #endregion

        #region 动态信息
        public List<VariableInfo> Variables { get; set; }

        public VariableInfo GetVariable(string name)
        {
            if (this.Name == "$")
            {

            }

            foreach (var v in Variables)
            {
                if (v.Name.Equals(name))
                    return v;
            }

            return null;
        }

        public List<PushInfo> PushInfos { get; set; }

        public List<PullInfo> PullInfos { get; set; }

        public List<StatementInfo> StatementInfos { get; set; }
        #endregion

        public ModelInfo(TokenPair token)
        {
            this.TokenPair = token;
            Attributes = new List<AttributeInfo>();
            //Fields = new List<FieldInfo>();
            Variables = new List<VariableInfo>();
            PushInfos = new List<PushInfo>();
            PullInfos = new List<PullInfo>();
            StatementInfos = new List<StatementInfo>();
            FieldInfos = new List<FieldInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            builder.AppendLine(this.Area + ":");
            foreach (var attr in this.Attributes)
            {
                builder.AppendFormatLine("[{0}({1})]", attr.Name, attr.Value);
            }
            builder.AppendFormatLine("class {0}", this.Name);
            builder.AppendLine("{");
            foreach (var field in this.FieldInfos)
            {
                builder.Append("\t");
                field.Render(builder);              
            }

            builder.AppendLine("}");

            if ( Variables.Count > 0 ) builder.AppendLine();
            foreach (var variable in this.Variables)
            {
                variable.Render(builder);
                builder.AppendLine(";");
            }

            if (StatementInfos.Count > 0) builder.AppendLine();
            foreach (var state in this.StatementInfos)
            {
                state.Render(builder);
                builder.AppendLine(";");
            }

            if (PushInfos.Count > 0) builder.AppendLine();
            foreach (var push in this.PushInfos)
            {                
                push.Render(builder);
            }

            if (PullInfos.Count > 0) builder.AppendLine();
            foreach (var pull in this.PullInfos)
            {
                pull.Render(builder);
            }
                        
        }

        internal void Wise()
        {
            try
            {
                foreach (var attr in this.Attributes)
                    attr.Wise(this);

                foreach (var field in this.FieldInfos)
                    field.Wise(this);

                foreach (var variable in this.Variables)
                    variable.Wise(this);

                foreach (var statement in this.StatementInfos)
                    statement.Wise(null,this);

                foreach (var push in this.PushInfos)
                    push.Wise(this);

                foreach (var pull in this.PullInfos)
                    pull.Wise(this);
            }
            catch (Exception ex)
            {
            }
        }

        internal void RenderView(IndentStringBuilder builder)
        {
            try
            {
                //foreach (var attr in this.Attributes)
                //    attr.Wise(this);                
                builder.AppendFormatLine("<div id='{0}'>", this.Area);

                foreach (var field in this.FieldInfos)
                    field.RenderView(builder, this);

                foreach (var variable in this.Variables)
                    variable.RenderView(builder, this);

                builder.AppendLine("<script language='javascript' type='text/javascript'>");
                builder.IncreaseIndentLine("$(function(){");
                foreach (var statement in this.StatementInfos)
                {
                    statement.RenderView(builder, this);
                    builder.AppendLine();
                }

                foreach (var push in this.PushInfos)
                    push.RenderView(builder,this);

                foreach (var pull in this.PullInfos)
                    pull.RenderView(builder,this);

                builder.DecreaseIndentLine("});");
                builder.AppendLine("</script>");
                builder.AppendFormatLine("</div>");
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex.StackTrace);
            }
        }

        public override T_Type RenderView(IndentStringBuilder builder, List<string> call_stack, IndentStringBuilder paras, AssignOperatorInfo? op, IndentStringBuilder opValue, PostfixPartType? postfixPartType, IndentStringBuilder func_paras, IndentStringBuilder index_para)
        {
            //if (builder.Length == 0)
                builder.Append(this.Area);
            return base.RenderView(builder, call_stack, paras, op, opValue, postfixPartType, func_paras, index_para);
        }
    }
    //public class ExpressionInfo
    //{

    //}

    public class VariableInfo
    {
        public TokenPair TokenPair { get; set; }

        public String Type_name { get; set; }

        public string Name { get; set; }

        public ExpressionStatementInfo Value { get; set; }

        public T_Type TypeInfo { get; set; }
        public T_Type RootType { get; set; }
        public List<string> Spans
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Name))
                    return new List<string>(0);
                var rslt = new List<string>(4);

                var list = this.Name.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                rslt.AddRange(list);
                return rslt;
            }
        }

        public VariableInfo(TokenPair token)
        {
            this.TokenPair = token;
        }

        internal void Render(IndentStringBuilder builder)
        {
            builder.AppendFormat("{0} {1}",this.Type_name, this.Name);
            if (this.Value != null)
            {
                builder.Append(" = ");
                this.Value.Render(builder);
            }
            //builder.AppendLine(";");
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo, IndentStringBuilder val)
        {
            this.RootType.RenderView(builder, this.Spans.SubList(1), null,AssignOperatorInfo.Equal, val, null, null, null);
        }

        internal void Wise(ModelInfo modelInfo)
        {
            #region 类型判断
            if (!string.IsNullOrWhiteSpace(this.Type_name))
            {
                this.TypeInfo = T_Type.ParseType(this.Type_name);
                if (this.TypeInfo == null)
                    ViewModelDB.Current.AddError("不支持此类型" + this.Type_name, this.TokenPair.BeginToken);
            }
            else
            {
                //todo: 如果没有typename 表示 求字段类型
                T_Type type = null;
                for (var index = 0; index < this.Spans.Count; index++)
                {
                    var span = this.Spans[index];
                    if (index == 0)
                    {
                        if (span == "$")
                            this.RootType = type = modelInfo;
                        else
                        {
                            ViewModelDB.Current.AddError("必须是$开头", this.TokenPair.BeginToken);
                        }
                    }
                    else
                    {
                        var f = type.GetField(span);
                        if (f == null)
                        {
                            ViewModelDB.Current.AddError("无法找到字段" + span, this.TokenPair.BeginToken);
                            return;
                        }
                        else
                        {
                            type = f.Type;
                        }
                    }
                }
                this.TypeInfo = type;
            }
            #endregion

            #region 默认值判断
            if (this.Value != null)
            {
                var t = this.Value.Wise(null, modelInfo);
                if (this.TypeInfo != t)
                {
                    ViewModelDB.Current.AddError("右边类型应该是" + this.TypeInfo.Name,this.TokenPair.BeginToken);
                    return;
                }
            }
            #endregion
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {

        }
    }

    public class LValueInfo 
    {
        public TokenPair TokenPair { get; set; }
        public string Text { get; set; }
        public T_Type TypeInfo { get; set; }
        private T_Type RootType { get; set; }
        public List<string> Spans
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Text)) return null;

                var rslt = new List<string>();
                rslt.AddRange(Text.Split( new char[]{'.'}, StringSplitOptions.RemoveEmptyEntries));
                return rslt;
            }
        }
        
        public LValueInfo(TokenPair token)
        {
            this.TokenPair = token;
        }

        internal T_Type Wise(ModelInfo modelInfo)
        {
            if (!string.IsNullOrWhiteSpace(this.Text))
            {
                T_Type rootType = null;

                if (this.Spans[0] == "$")
                {
                    /*
                    var f = modelInfo.GetField(this.Spans[1]);
                    if (f == null)
                    {
                        ViewModelDB.Current.AddError("无法获取类型", this.TokenPair.BeginToken);
                        return null;
                    }

                    rootType = f.Type;
                     * */
                    rootType = RootType = modelInfo;
                }
                else
                {
                   var v= modelInfo.GetVariable(this.Spans[0]);
                   if (v == null)
                   {
                       ViewModelDB.Current.AddError("无法获取类型", this.TokenPair.BeginToken);
                       return null;
                   }
                   rootType = v.TypeInfo;
                }
                var prevType = RootType = rootType;
                for (var index = 1; index < this.Spans.Count; index ++)
                {
                    var f = prevType.GetField(this.Spans[index]);
                    if (f == null)
                    {
                        ViewModelDB.Current.AddError("无法获取字段:" + this.Spans[index], this.TokenPair.BeginToken);
                        return null;
                    }
                    prevType = f.Type;
                }

                this.TypeInfo = prevType;

                return prevType;
            }
            return null;
        }

        internal void RenderView(IndentStringBuilder builder, ConditionalExpressionInfo ConditionalExpression, ModelInfo modelInfo,AssignOperatorInfo?  op,IndentStringBuilder rightBuilder)
        {
            RootType.RenderView(builder, this.Spans.SubList(1), null,op, rightBuilder,null,null,null);
        }
    }

    public enum AssignOperatorInfo
    {
        [Description("=")]
        Equal,
        [Description("*=")]
        MulitEqual,
        [Description("/=")]
        DivideEqual,
        [Description("%=")]
        ModEqual,
        [Description("+=")]
        AddEqual,
        [Description("-=")]
        SubEqual
    }

    public class AssignmentExpressionInfo
    {
        public TokenPair TokenPair { get; set; }
        public LValueInfo LValue { get; set; }
        public AssignOperatorInfo AssignOperator { get; set; }
        public AssignmentExpressionInfo AssignmentExpression { get; set; }

        /// <summary>
        /// 排他存在
        /// </summary>
        public ConditionalExpressionInfo ConditionalExpression { get; set; }
        public AssignmentExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
        }
        internal void Render(IndentStringBuilder builder)
        {
            if (ConditionalExpression != null)
            {
                this.ConditionalExpression.Render(builder);
            }
            else
            {
                builder.Append(this.LValue.Text);
                builder.Append(this.AssignOperator.GetDescription());
                this.AssignmentExpression.Render(builder);
            }
        }

        internal T_Type Wise(T_Type type, ModelInfo modelInfo)
        {
            if (ConditionalExpression != null)
            {
                return this.ConditionalExpression.Wise(modelInfo);
            }
            else
            {
                var rslt = this.LValue.Wise(modelInfo);

                if ( rslt is T_InputType )
                    ViewModelDB.Current.AddError("输入类型不能被赋值", this.TokenPair.BeginToken);

                var right = this.AssignmentExpression.Wise(type,modelInfo);

                if (rslt != right)
                {
                    ViewModelDB.Current.AddError("右边表达式应该为" + rslt.Name, this.AssignmentExpression.TokenPair.BeginToken);
                }
                return rslt;
            }
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            if (ConditionalExpression != null)
            {
                this.ConditionalExpression.RenderView(builder, modelInfo);
            }
            else
            {
                
                //builder.Append(this.AssignOperator.GetDescription());
                var sb = new IndentStringBuilder();
                this.AssignmentExpression.RenderView(sb, modelInfo);
                this.LValue.RenderView(builder,ConditionalExpression, modelInfo ,this.AssignOperator, sb);
                builder.Append(";");
            }
        }
    }

    public class ConditionalExpressionInfo
    {
        public TokenPair TokenPair { get; set; }

        public Logical_Or_ExpressionInfo Logical_Or_Expression{get;set;}
        /// <summary>
        /// 可选
        /// </summary>
        public ExpressionStatementInfo Expression { get; set; }
        /// <summary>
        /// 可选
        /// </summary>
        public ConditionalExpressionInfo ConditionalExpression{get;set;}

        public ConditionalExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
        }
        internal void Render(IndentStringBuilder builder)
        {
            this.Logical_Or_Expression.Render(builder);
            if (this.Expression != null)
                this.Expression.Render(builder);
            if (ConditionalExpression != null)
                this.ConditionalExpression.Render(builder);
        }

        internal T_Type Wise(ModelInfo modelInfo)
        {
            T_Type rslt = this.Logical_Or_Expression.Wise(null,modelInfo);
            T_Type t1 = null;
            T_Type t2 = null;
            if (this.Expression != null)
                t1 = this.Expression.Wise(null,modelInfo);
            if (ConditionalExpression != null)
                t2 = this.ConditionalExpression.Wise(modelInfo);

            if (t1 != t2)
            {
                ViewModelDB.Current.AddError("条件表达式类型必须相同", this.TokenPair.BeginToken);
            }

            if (t1 != null)
                return t1;

            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            this.Logical_Or_Expression.RenderView(builder, modelInfo);
            if (this.Expression != null)
                this.Expression.RenderView(builder, modelInfo);
            if (ConditionalExpression != null)
                this.ConditionalExpression.RenderView(builder, modelInfo);
        }
    }
    public class Logical_Or_ExpressionInfo 
    {
        public TokenPair TokenPair { get; set; }
        public List<Logical_And_ExpressionInfo> Logical_And_Expressions { get; set; }
        public Logical_Or_ExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
            this.Logical_And_Expressions = new List<Logical_And_ExpressionInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            for (var index = 0; index < this.Logical_And_Expressions.Count; index++)
            {
                if (index > 0 )
                {
                    builder.Append(" && ");
                }
                this.Logical_And_Expressions[index].Render(builder);
            }
        }

        internal T_Type Wise(T_Type type, ModelInfo modelInfo)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.Logical_And_Expressions.Count; index++)
            {
                rslt = this.Logical_And_Expressions[index].Wise(type, modelInfo);
                //if (temp == null || temp.GetType() != typeof(T_Boolean))
                //{
                //    ViewModelDB.Current.AddError("布尔表达式必须为boolean类型", this.TokenPair.BeginToken);
                //}
            }

            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            for (var index = 0; index < this.Logical_And_Expressions.Count; index++)
            {
                if (index > 0)
                {
                    builder.Append(" && ");
                }
                this.Logical_And_Expressions[index].RenderView(builder, modelInfo);
            }
        }
    }
    public class Logical_And_ExpressionInfo
    {
        public TokenPair TokenPair { get; set; }
        public List<Inclusive_Or_ExpressionInfo> Inclusive_Or_Expressions { get; set; }
        public Logical_And_ExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
            this.Inclusive_Or_Expressions = new List<Inclusive_Or_ExpressionInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            for (var index = 0; index < this.Inclusive_Or_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.Append(" || ");
                this.Inclusive_Or_Expressions[index].Render(builder);
            }
        }

        internal T_Type Wise(T_Type type,ModelInfo modelInfo)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.Inclusive_Or_Expressions.Count; index++)
            {
                rslt = this.Inclusive_Or_Expressions[index].Wise(type, modelInfo);
            }
            if (this.Inclusive_Or_Expressions.Count > 1)
            {
                return new T_Boolean();
            }
            else
            {
                return rslt;
            }
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            for (var index = 0; index < this.Inclusive_Or_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.Append(" && ");
                this.Inclusive_Or_Expressions[index].RenderView(builder, modelInfo);
            }
        }
    }
    public class Inclusive_Or_ExpressionInfo 
    {
        public TokenPair TokenPair { get; set; }

        public List<Exclusive_Or_ExpressionInfo> Exclusive_Or_Expressions { get; set; }
        public Inclusive_Or_ExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
            this.Exclusive_Or_Expressions = new List<Exclusive_Or_ExpressionInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            for (var index = 0; index < this.Exclusive_Or_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.Append(" | ");
                this.Exclusive_Or_Expressions[index].Render(builder);
            }
        }

        internal T_Type Wise(T_Type type, ModelInfo modelInfo)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.Exclusive_Or_Expressions.Count; index++)
            {
                rslt = this.Exclusive_Or_Expressions[index].Wise(type,modelInfo);
            }

            if (this.Exclusive_Or_Expressions.Count > 1)
                return T_Type.ParseType("int");

            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            for (var index = 0; index < this.Exclusive_Or_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.Append(" | ");
                this.Exclusive_Or_Expressions[index].RenderView(builder, modelInfo);
            }
        }
    }
    public class Exclusive_Or_ExpressionInfo 
    {
        public TokenPair TokenPair { get; set; }
        public List<And_ExpressionInfo> And_Expressions { get; set; }
        public Exclusive_Or_ExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
            this.And_Expressions = new List<And_ExpressionInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            for (var index = 0; index < this.And_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.Append(" ^ ");
                this.And_Expressions[index].Render(builder);
            }
        }

        internal T_Type Wise(T_Type type , ModelInfo modelInfo)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.And_Expressions.Count; index++)
            {
                rslt = this.And_Expressions[index].Wise(type , modelInfo);
            }

            if (this.And_Expressions.Count > 1)
                return T_Type.ParseType("int");

            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            for (var index = 0; index < this.And_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.Append(" ^ ");
                this.And_Expressions[index].RenderView(builder, modelInfo);
            }
        }
    }
    public class And_ExpressionInfo
    {
        public TokenPair TokenPair { get; set; }
        public List<Equality_ExpressionInfo> Equality_Expressions { get; set; }
        public And_ExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
            this.Equality_Expressions = new List<Equality_ExpressionInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            for (var index = 0; index < this.Equality_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.Append(" & ");
                this.Equality_Expressions[index].Render(builder);
            }
        }

        internal T_Type Wise(T_Type type ,ModelInfo modelInfo)
        {
            var types = new List<T_Type>();
            for (var index = 0; index < this.Equality_Expressions.Count; index++)
            {
                types.Add(this.Equality_Expressions[index].Wise(type, modelInfo));
            }

            for(var i = 0 ; i < types.Count ; i ++ )
            {
                for (var j = i + 1; j < types.Count; j++)
                {
                    if (types[i].GetType() != types[j].GetType())
                    {
                        ViewModelDB.Current.AddError("类型必须相同",TokenPair.BeginToken);
                    }
                }
            }
            return types[0];
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            for (var index = 0; index < this.Equality_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.Append(" & ");
                this.Equality_Expressions[index].RenderView(builder, modelInfo);
            }
        }
    }
    public class Equality_ExpressionInfo
    {
        public TokenPair TokenPair { get; set; }

        public List<Relational_ExpressionInfo> Relational_Expressions { get; set; }

        public List<Equality_Expression_OperatorInfo> Equality_Expression_Operators { get; set; }

        //public List<Tuple<Equality_Expression_OperatorInfo, Relational_ExpressionInfo>>
        //    Relational_Expressions { get; set; }
        public Equality_ExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
            this.Relational_Expressions = new List<Relational_ExpressionInfo>();
            this.Equality_Expression_Operators = new List<Equality_Expression_OperatorInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            for (var index = 0; index < this.Relational_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.AppendFormat(" {0} ",this.Equality_Expression_Operators[index-1].GetDescription());

                this.Relational_Expressions[index].Render(builder);
            }
        }

        internal T_Type Wise(T_Type type, ModelInfo modelInfo)
        {
            if (this.Relational_Expressions.Count > 2)
            {
                ViewModelDB.Current.AddError("语法错误", this.TokenPair.BeginToken);
                return null;
            }
            T_Type rslt = null;
            var list = new List<T_Type>();
            for (var index = 0; index < this.Relational_Expressions.Count; index++)
            {
                rslt = this.Relational_Expressions[index].Wise(type, modelInfo);
                list.Add(rslt);
            }

            if (this.Relational_Expressions.Count > 1)
            {
                if (list[0] != list[1])
                {
                    ViewModelDB.Current.AddError("比较符合两边类型必须相同",this.TokenPair.BeginToken);
                }
                return new T_Boolean();
            }
            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            for (var index = 0; index < this.Relational_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.AppendFormat(" {0} ", this.Equality_Expression_Operators[index - 1].GetDescription());

                this.Relational_Expressions[index].RenderView(builder, modelInfo);
            }
        }
    }

    public enum Equality_Expression_OperatorInfo
    {
        [Description("==")]
        Equal,
        [Description("!=")]
        NotEqual
    }
    public class Relational_ExpressionInfo
    {
        public TokenPair TokenPair { get; set; }
        public List<Shift_ExpressionInfo> Shift_Expressions { get; set; }
        public List<Relational_Expression_OperatorInfo> Operators { get; set; }
        public Relational_ExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
            this.Shift_Expressions = new List<Shift_ExpressionInfo>();
            this.Operators = new List<Relational_Expression_OperatorInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            for (var index = 0; index < this.Shift_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.AppendFormat(" {0} ", this.Operators[index - 1].GetDescription());

                this.Shift_Expressions[index].Render(builder);
            }
        }

        internal T_Type Wise(T_Type type , ModelInfo modelInfo)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.Shift_Expressions.Count; index++)
            {
                rslt = this.Shift_Expressions[index].Wise(type,modelInfo);
            }

            if (this.Shift_Expressions.Count > 1)
                return new T_Boolean();
            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            for (var index = 0; index < this.Shift_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.AppendFormat(" {0} ", this.Operators[index - 1].GetDescription());

                this.Shift_Expressions[index].RenderView(builder, modelInfo);
            }
        }
    }
    public class Shift_ExpressionInfo 
    {
        public TokenPair TokenPair { get; set; }
        public List<Additive_ExpressionInfo> Additive_Expressions { get; set; }
        public List<Shift_Expression_OperatorInfo> Operators { get; set; }
        public Shift_ExpressionInfo(TokenPair token) 
        {
            this.TokenPair = token;
            this.Additive_Expressions = new List<Additive_ExpressionInfo>();
            this.Operators = new List<Shift_Expression_OperatorInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            for (var index = 0; index < this.Additive_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.AppendFormat(" {0} ", this.Operators[index - 1].GetDescription());

                this.Additive_Expressions[index].Render(builder);
            }
        }

        internal T_Type Wise(T_Type type ,ModelInfo modelInfo)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.Additive_Expressions.Count; index++)
            {
                rslt = this.Additive_Expressions[index].Wise(type ,modelInfo);
            }
            if (this.Additive_Expressions.Count > 1)
                return new T_Boolean();

            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            for (var index = 0; index < this.Additive_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.AppendFormat(" {0} ", this.Operators[index - 1].GetDescription());

                this.Additive_Expressions[index].RenderView(builder, modelInfo);
            }
        }
    }
    public class Additive_ExpressionInfo
    {
        public TokenPair TokenPair { get; set; }
        public List<Multiplicative_ExpressionInfo> Multiplicative_Expressions { get; set; }
        public List<Additive_Expression_OperatorInfo> Operators { get; set; }
        public Additive_ExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
            this.Multiplicative_Expressions = new List<Multiplicative_ExpressionInfo>();
            this.Operators = new List<Additive_Expression_OperatorInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            for (var index = 0; index < this.Multiplicative_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.AppendFormat(" {0} ", this.Operators[index - 1].GetDescription());

                this.Multiplicative_Expressions[index].Render(builder);
            }
        }

        internal T_Type Wise(T_Type type ,ModelInfo modelInfo)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.Multiplicative_Expressions.Count; index++)
            {
                if (index == 0)
                {
                    rslt = this.Multiplicative_Expressions[index].Wise(type, modelInfo);
                }
                else
                {
                    var t = this.Multiplicative_Expressions[index].Wise(type, modelInfo);
                }
            }
            return rslt;
            
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            for (var index = 0; index < this.Multiplicative_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.AppendFormat(" {0} ", this.Operators[index - 1].GetDescription());

                this.Multiplicative_Expressions[index].RenderView(builder, modelInfo);
            }
        }
    }
    public class Multiplicative_ExpressionInfo 
    {
        public TokenPair TokenPair { get; set; }
        public List<Cast_ExpressionInfo> Cast_Expressions { get; set; }
        public List<Multiplicative_Expression_OperatorInfo> Operators { get; set; }
        public Multiplicative_ExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
            this.Cast_Expressions = new List<Cast_ExpressionInfo>();
            this.Operators = new List<Multiplicative_Expression_OperatorInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            for (var index = 0; index < this.Cast_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.AppendFormat(" {0} ", this.Operators[index - 1].GetDescription());

                this.Cast_Expressions[index].Render(builder);
            }
        }

        internal T_Type Wise(T_Type type ,ModelInfo modelInfo)
        {
            if (this.Cast_Expressions.Count > 2)
            {
                ViewModelDB.Current.AddError("运算表达式过多",this.TokenPair.BeginToken);
                return null;
            }
            T_Type rslt = null;
            var list = new List<T_Type>();

            for (var index = 0; index < this.Cast_Expressions.Count; index++)
            {
                if ( index == 0 )
                    rslt = this.Cast_Expressions[index].Wise(type, modelInfo);
                else
                    rslt = this.Cast_Expressions[index].Wise(type, modelInfo);

                list.Add(rslt);
            }

            if (list.Count > 1)
            {
                foreach (var t in list)
                {
                    if (t.GetType() != typeof(T_IntType) &&
                        t.GetType() != typeof(T_FloatType) &&
                        t.GetType() != typeof(T_DecimalType))
                    {
                        ViewModelDB.Current.AddError(string.Format("只有int,float,decimal能用于{0}运算",this.Operators[0].GetDescription()),this.TokenPair.BeginToken);
                        return null;
                    }
                }
            }

            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            for (var index = 0; index < this.Cast_Expressions.Count; index++)
            {
                if (index > 0)
                    builder.AppendFormat(" {0} ", this.Operators[index - 1].GetDescription());

                this.Cast_Expressions[index].RenderView(builder, modelInfo);
            }
        }
    }
    public class TypeNameInfo 
    {
        public TokenPair TokenPair { get; set; }
        public string Text{get;set;}
        public TypeNameInfo(TokenPair token)
        {
            this.TokenPair = token;
        }
        
    }
    public class Cast_ExpressionInfo
    {
        public TokenPair TokenPair { get; set; }
        public TypeNameInfo TypeName { get; set; }
        public Cast_ExpressionInfo Cast_Expression { get; set; }

        /// <summary>
        /// 排他
        /// </summary>
        public Unary_ExpressionInfo Unary_Expression { get; set; }
        public Cast_ExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
        }
        internal void Render(IndentStringBuilder builder)
        {
            if (this.Unary_Expression != null)
            {
                this.Unary_Expression.Render(builder);
            }
            else
            {
                builder.AppendFormat("({0})",this.TypeName.Text);
                this.Cast_Expression.Render(builder);
            }
        }

        internal T_Type Wise(T_Type type , ModelInfo modelInfo)
        {
            T_Type rslt = null;
            if (this.Unary_Expression != null)
            {
                rslt = this.Unary_Expression.Wise(type,modelInfo);
            }
            else
            {
                rslt = this.Cast_Expression.Wise(type,modelInfo);
            }
            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            if (this.Unary_Expression != null)
            {
                this.Unary_Expression.RenderView(builder, modelInfo);
            }
            else
            {
                builder.AppendFormat("({0})", this.TypeName.Text);
                this.Cast_Expression.RenderView(builder, modelInfo);
            }
        }
    }
    public class Unary_ExpressionInfo 
    {
        public TokenPair TokenPair { get; set; }
        /// <summary>
        /// 排他
        /// </summary>
        public Postfix_ExpressionInfo Postfix_Expression { get; set; }
        /// <summary>
        /// 排他
        /// </summary>
        public Unary_Expression_One_CharInfo Unary_Expression_One_Char { get; set; }
        /// <summary>
        /// 排他
        /// </summary>
        public Unary_Expression_Two_CharInfo Unary_Expression_Two_Char { get; set; }

        public Unary_ExpressionInfo(TokenPair token)
        {
            TokenPair = token;
        }
        internal void Render(IndentStringBuilder builder)
        {
            if (this.Postfix_Expression != null)
            {
                this.Postfix_Expression.Render(builder);
            }

            if (this.Unary_Expression_One_Char != null)
                this.Unary_Expression_One_Char.Render(builder);

            if (this.Unary_Expression_Two_Char != null)
                this.Unary_Expression_Two_Char.Render(builder);
        }

        internal T_Type Wise(T_Type type ,ModelInfo modelInfo)
        {
            if (this.Postfix_Expression != null)
            {
                return this.Postfix_Expression.Wise(modelInfo);
            }

            if (this.Unary_Expression_One_Char != null)
                return this.Unary_Expression_One_Char.Wise(type,modelInfo);

            if (this.Unary_Expression_Two_Char != null)
                return this.Unary_Expression_Two_Char.Wise(type,modelInfo);

            return null;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            if (this.Postfix_Expression != null)
            {
                this.Postfix_Expression.RenderView(builder, modelInfo);
            }

            if (this.Unary_Expression_One_Char != null)
                this.Unary_Expression_One_Char.RenderView(builder, modelInfo);

            if (this.Unary_Expression_Two_Char != null)
                this.Unary_Expression_Two_Char.RenderView(builder,modelInfo);
        }
    }

    public class Postfix_ExpressionInfo
    {
        public TokenPair TokenPair { get; set; }
        public Primary_ExpressionInfo Primary_Expression { get; set; }
        public List<Postfix_PartInfo> Postfix_Parts { get; set; }
        public T_Type Type { get; set; }
        public T_Type RootType { get; set; }

        public Postfix_ExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
            this.Postfix_Parts = new List<Postfix_PartInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            this.Primary_Expression.Render(builder);
            for (var index = 0; index < this.Postfix_Parts.Count; index++)
            {
                this.Postfix_Parts[index].Render(builder);
            }
        }

        internal T_Type Wise(ModelInfo modelInfo)
        {
            this.RootType = this.Type = this.Primary_Expression.Wise(null,modelInfo);
            var type = this.Type;
            for (var index = 0; index < this.Postfix_Parts.Count; index++)
            {
                if (index < this.Postfix_Parts.Count - 1)
                {
                    var last = this.Postfix_Parts[index + 1];
                    if (last.Postfix_Part_Empty_Function != null)
                    {
                        last.Postfix_Part_Empty_Function.Wise(type, this.Postfix_Parts[index].Postfix_Part_Long_Name.StandartName, modelInfo);
                        break;
                    }
                    if (last.Postfix_Part_Function != null)
                    {
                        last.Postfix_Part_Function.Wise(type, this.Postfix_Parts[index].Postfix_Part_Long_Name.StandartName, modelInfo);
                        break;
                    }
                }
                type = this.Postfix_Parts[index].Wise(type, modelInfo);
            }

            this.Type = type;
            return type;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            this.Primary_Expression.RenderView(builder, modelInfo, this.Postfix_Parts.Count > 0);

            if (this.Postfix_Parts.Count > 0)
            {
                var nextType = this.RootType;
                var stack = new List<string>();
                Postfix_PartInfo notLongName = null;
                for (var index = 0; index < this.Postfix_Parts.Count; index++)
                {
                    var ln = this.Postfix_Parts[index].Postfix_Part_Long_Name;
                    if (ln == null)
                    {
                        notLongName = this.Postfix_Parts[index];
                        continue;
                    }
                    stack.Add(ln.StandartName);
                }
                //stack.Add(
                if (builder.ToString() == modelInfo.Area)
                    builder.Clear();

                if (notLongName == null)
                {
                    if (stack.Count > 1)
                        this.RootType.RenderView(builder, stack, null, null, null,null,null,null);
                }
                else
                {
                    T_Type t = this.RootType;
                    if (stack.Count > 1)
                    {
                        t = this.RootType.RenderView(builder, stack.SubList(0, stack.Count - 1), null, null, null, null, null, null);
                    }
                    //t.RenderView(builder,stack.SubList(stack.Count-2),nu
                    notLongName.RenderView(builder, modelInfo, stack[stack.Count - 1], t);
                }
                //for (var index = 0; index < this.Postfix_Parts.Count; index++)
                //{
                //    this.Postfix_Parts[index].RenderView(builder, modelInfo);               
                //    //nextType.RenderView(builder,stack,
                //}
            }
        }
    }

    public class Primary_ExpressionInfo
    {
        public TokenPair TokenPair { get; set; }
        public String Id { get; set; }
        public ConstantInfo Constant { get; set; }
        public ExpressionStatementInfo Expression { get; set; }

        public bool IsId { get; set; }
        public bool IsConstant { get; set; }
        public bool IsExpression { get; set; }

        private T_Type RootType { get; set; }

        public Primary_ExpressionInfo(TokenPair token)
        {
            this.TokenPair = token;
        }
        internal void Render(IndentStringBuilder builder)
        {
            if (this.IsId)
                builder.Append(this.Id);
            if (this.IsConstant)
                this.Constant.Render(builder);
            if (this.IsExpression)
                this.Expression.Render(builder);
        }

        internal T_Type Wise(T_Type type, ModelInfo modelInfo)
        {
            T_Type rslt = null;
            if (this.IsConstant)
                rslt = this.Constant.Wise(modelInfo);
            if (this.IsExpression)
                rslt = this.Expression.Wise(type,modelInfo);
            if (this.IsId)
            {
                if (this.Id == "$")
                    rslt = modelInfo;
                else
                {
                    var var = modelInfo.GetVariable(this.Id);

                    if (var != null)
                    {
                        rslt = var.TypeInfo;
                    }
                    else
                    {
                        //查找类型
                        rslt = T_Type.ParseType(this.Id);
                        if (rslt == null)
                        {
                            ViewModelDB.Current.AddError("没有该变量或者类型" + this.Id,this.TokenPair.BeginToken);
                            return null;
                        }
                        rslt.IsInstance = false;
                    }
                }
            }
            RootType = rslt;
            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo,bool havePostfix)
        {
            if (this.IsId)
            {
                if (this.RootType == modelInfo)
                {
                    if (!havePostfix)
                    {
                        builder.Append(modelInfo.Area);
                    }
                }
                else
                {
                    builder.Append(this.Id);
                }
            }
            if (this.IsConstant)
                this.Constant.RenderView(builder, modelInfo);
            if (this.IsExpression)
                this.Expression.RenderView(builder, modelInfo);

        }
    }

    public class ConstantInfo
    {
        public TokenPair TokenPair { get; set; }
        public String Value { get; set; }
        public bool Is_Hex { get; set; }
        public bool Is_Octal { get; set; }
        public bool Is_Decimal { get; set; }
        public bool Is_Char { get; set; }
        public bool Is_String { get; set; }
        public bool Is_Float { get; set; }
        public bool Is_Bool { get; set; }

        public ConstantInfo(TokenPair token)
        {
            this.TokenPair = token;
        }

        internal void Render(IndentStringBuilder builder)
        {
            //if (this.Is_String)
            //    builder.AppendFormat("\"{0}\"", this.Value);
            //else if (this.Is_Char)
            //    builder.AppendFormat("'{0}'", this.Value);
            //else
            //    builder.Append(this.Value);
            builder.Append(this.Value);
        }

        internal T_Type Wise(ModelInfo modelInfo)
        {
            if (this.Is_Char)
                return T_Type.ParseType("char");
            if (this.Is_Decimal)
                return T_Type.ParseType("decimal");
            if (this.Is_Float)
                return T_Type.ParseType("float");
            if (this.Is_Hex)
                return T_Type.ParseType("hex");
            if (this.Is_Octal)
                return T_Type.ParseType("octal");
            if (this.Is_String)
                return T_Type.ParseType("string");
            if (this.Is_Bool)
                return T_Type.ParseType("bool");
            return null;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            builder.Append(this.Value);
        }
    }

    public enum PostfixPartType
    {
        SelfIncrease, SelfDecrease, EmptyCall, Call, Index, LongName
    }

    public class Postfix_PartInfo
    {
        public TokenPair TokenPair { get; set; }
        public Postfix_Part_IndexInfo Postfix_Part_Index { get; set; }
        public Postfix_Part_Empty_FunctionInfo Postfix_Part_Empty_Function { get; set; }
        public Postfix_Part_FunctionInfo Postfix_Part_Function { get; set; }
        public Postfix_Part_Long_NameInfo Postfix_Part_Long_Name { get; set; }
        public Postfix_Part_IncreaseInfo Postfix_Part_Increase { get; set; }
        public Postfix_Part_DecreaseInfo Postfix_Part_Decrease { get; set; }
        public T_Type Type { get; set; }
        public PostfixPartType? PostfixPartType { get; set; }
        public Postfix_PartInfo(TokenPair token)
        {
            this.TokenPair = token;
        }
        internal void Render(IndentStringBuilder builder)
        {
            if (this.Postfix_Part_Decrease != null)
                builder.Append("--");
            if (this.Postfix_Part_Empty_Function != null)
                builder.Append("()");
            if (this.Postfix_Part_Function != null)
                this.Postfix_Part_Function.Render(builder);
            if (this.Postfix_Part_Increase != null)
                builder.Append("++");
            if (this.Postfix_Part_Index != null)
                this.Postfix_Part_Index.Render(builder);
            if (this.Postfix_Part_Long_Name != null)
                builder.Append(this.Postfix_Part_Long_Name.Text);
        }

        internal T_Type Wise(T_Type type ,ModelInfo modelInfo)
        {
            //if (this.Postfix_Part_Empty_Function != null)
            //    return this.Postfix_Part_Empty_Function.Wise(type,modelInfo);

            if (this.Postfix_Part_Long_Name != null)
                return this.Postfix_Part_Long_Name.Wise(type, modelInfo);

            if (this.Postfix_Part_Increase != null)
                return this.Postfix_Part_Increase.Wise(type, modelInfo);

            if (this.Postfix_Part_Decrease != null)
                return this.Postfix_Part_Decrease.Wise(type, modelInfo);

            //if (this.Postfix_Part_Function != null)
            //    return this.Postfix_Part_Function.Wise(type,null, modelInfo);

            if (this.Postfix_Part_Index != null)
                return this.Postfix_Part_Index.Wise(type,null, modelInfo);
            return null;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo,string name, T_Type type)
        {
            var stack = new List<string>();
            stack.Add(name);

            if (this.Postfix_Part_Decrease != null)
            {
                type.RenderView(builder, stack, null, null, null, this.Postfix_Part_Decrease.PostfixPartType, null, null);
            }
                //builder.Append("--");
            if (this.Postfix_Part_Empty_Function != null)
                //builder.Append("()");
            {
                type.RenderView(builder, stack, null, null, null, this.Postfix_Part_Empty_Function.PostfixPartType, null, null);
            }

            if (this.Postfix_Part_Function != null)
                this.Postfix_Part_Function.RenderView(builder,modelInfo);
            if (this.Postfix_Part_Increase != null)
            {
                type.RenderView(builder, stack, null, null, null, this.Postfix_Part_Increase.PostfixPartType, null, null);
            }
                //builder.Append("++");
            if (this.Postfix_Part_Index != null)
                this.Postfix_Part_Index.RenderView(builder, modelInfo);
            if (this.Postfix_Part_Long_Name != null)
                builder.Append(this.Postfix_Part_Long_Name.Text);
        }
    }
    public class Postfix_Part_IndexInfo 
    {
        public TokenPair TokenPair { get; set; }

        public ExpressionStatementInfo Expression { get; set; }
        public Postfix_Part_IndexInfo(TokenPair token)
        {
            this.TokenPair = token;
        }
        internal void Render(IndentStringBuilder builder)
        {
            this.Expression.Render(builder);
        }

        internal T_Type Wise(T_Type type , string name,ModelInfo modelInfo)
        {
            return this.Expression.Wise(type,modelInfo);
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            this.Expression.RenderView(builder, modelInfo);
        }
    }

    public class Postfix_Part_Empty_FunctionInfo 
    {
        public TokenPair TokenPair { get; set; }
        public PostfixPartType PostfixPartType { get; set; }
        public Postfix_Part_Empty_FunctionInfo()
        {
            this.PostfixPartType = ViewModels.PostfixPartType.EmptyCall;
        }
        internal T_Type Wise(T_Type type,string name, ModelInfo modelInfo)
        {
            var rslt = type.GetMethod(name);
            if (rslt == null)
            {
                ViewModelDB.Current.AddError(string.Format("类型{0}没有该方法{1}", type.Name, name), this.TokenPair.BeginToken);
                return null;
            }
            return rslt.Type;
        }
    }

    public class Postfix_Part_FunctionInfo 
    {
        public TokenPair TokenPair { get; set; }
        public List<AssignmentExpressionInfo> Assignment_Expressions { get; set; }

        public Postfix_Part_FunctionInfo(TokenPair token)
        {            
            this.TokenPair = token;
            this.PostfixPartType = ViewModels.PostfixPartType.Call;
            this.Assignment_Expressions = new List<AssignmentExpressionInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            builder.Append("(");
            for (var index = 0; index < this.Assignment_Expressions.Count; index++)
            {
                if (index > 0 && index <= this.Assignment_Expressions.Count - 1)
                {
                    builder.Append(", ");
                }
                this.Assignment_Expressions[index].Render(builder);
            }
            builder.Append(")");
        }

        internal T_Type Wise(T_Type type , string name,ModelInfo modelInfo)
        {
            T_Type rslt = null;
            var paras = new List<T_Type>();
            for (var index = 0; index < this.Assignment_Expressions.Count; index++)
            {
                paras.Add(this.Assignment_Expressions[index].Wise(null,modelInfo));
            }

            //根据参数类型列表获取方法的返回类型
            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            builder.Append("(");
            for (var index = 0; index < this.Assignment_Expressions.Count; index++)
            {
                if (index > 0 && index <= this.Assignment_Expressions.Count - 1)
                {
                    builder.Append(", ");
                }
                this.Assignment_Expressions[index].RenderView(builder, modelInfo);
            }
            builder.Append(")");
        }

        public PostfixPartType PostfixPartType { get; set; }
    }
    public class Postfix_Part_Long_NameInfo
    {
        public TokenPair TokenPair { get; set; }
        public string Text { get; set; }
        public string StandartName
        {
            get
            {
                if (String.IsNullOrWhiteSpace(Text))
                    return Text;

                return Text.Replace(".", "");
            }
        }
        public T_Type Type { get; set; }

        public Postfix_Part_Long_NameInfo(TokenPair token)
        {
            this.PostfixPartType = ViewModels.PostfixPartType.LongName;
            this.TokenPair = token;
        }

        internal T_Type Wise(T_Type type,ModelInfo modelInfo)
        {
            var name = this.Text.Replace(".", "");

            var f = type.GetField(name);
            if (f != null)
                return f.Type;

            var m = type.GetMethod(name);
            if (m != null)
                return m.Type;

            ViewModelDB.Current.AddError(string.Format("无法识别{0}类型",name),this.TokenPair.EndToken);
            return null;
        }

        public PostfixPartType PostfixPartType { get; set; }
    }

    public class Postfix_Part_IncreaseInfo 
    { 
        public TokenPair TokenPair { get; set; }
        public PostfixPartType PostfixPartType { get; set; }

        public Postfix_Part_IncreaseInfo(TokenPair token)
        {
            this.PostfixPartType = ViewModels.PostfixPartType.SelfIncrease;
            this.TokenPair = token;
        }

        internal T_Type Wise(T_Type type ,ModelInfo modelInfo)
        {
            return type;
        }
    }
    public class Postfix_Part_DecreaseInfo 
    {
        public TokenPair TokenPair { get; set; }
        public PostfixPartType PostfixPartType { get; set; }
        public Postfix_Part_DecreaseInfo(TokenPair token)
        {
            this.PostfixPartType = PostfixPartType.SelfDecrease;
            this.TokenPair = token;
        }

        internal T_Type Wise(T_Type type ,ModelInfo modelInfo)
        {
            return type;
        }
    }

    public class Unary_Expression_Two_CharInfo
    {
        public TokenPair TokenPair { get; set; }
        public Unary_Expression_OperatorInfo Unary_Expression_Operator { get; set; }
        public Unary_ExpressionInfo Unary_Expression { get; set; }
        public Unary_Expression_Two_CharInfo(TokenPair token)
        {
            this.TokenPair = token;
        }
        internal void Render(IndentStringBuilder builder)
        {
            builder.AppendFormat("{0} ",this.Unary_Expression_Operator.GetDescription());
            this.Unary_Expression.Render(builder);
        }

        internal T_Type Wise(T_Type type, ModelInfo modelInfo)
        {
            return this.Unary_Expression.Wise(type,modelInfo);
        }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            builder.AppendFormat("{0} ", this.Unary_Expression_Operator.GetDescription());
            this.Unary_Expression.RenderView(builder, modelInfo);
        }
    }

    public enum Unary_OperatorInfo
    {
        [Description("+")]
        Positive,
        [Description("-")]
        Negative,
        [Description("~")]
        BitReverse,
        [Description("!")]
        BoolReverse
    }
    public enum Unary_Expression_OperatorInfo
    {
        [Description("++")]
        AddSelf,
        [Description("--")]
        SubstractSelf,
    }
    public class Unary_Expression_One_CharInfo 
    {
        public Unary_OperatorInfo Unary_Operator { get; set; }
        public Cast_ExpressionInfo Cast_Expression { get; set; }

        public Unary_Expression_One_CharInfo(TokenPair token)
        {
            this.TokenPair = token;
        }
        internal void Render(IndentStringBuilder builder)
        {
            builder.AppendFormat("{0} ",this.Unary_Operator.GetDescription());
            this.Cast_Expression.Render(builder);
        }

        internal T_Type Wise(T_Type type,ModelInfo modelInfo)
        {
            return this.Cast_Expression.Wise(type,modelInfo);
        }

        public TokenPair TokenPair { get; set; }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            builder.AppendFormat("{0} ", this.Unary_Operator.GetDescription());
            this.Cast_Expression.RenderView(builder, modelInfo);
        }
    }
    public enum Multiplicative_Expression_OperatorInfo
    {
        [Description("*")]
        Mulit,
        [Description("/")]
        Devide,
        [Description("%")]
        Mod
    }
    public enum Additive_Expression_OperatorInfo
    {
        [Description("+")]
        Add,
        [Description("-")]
        Subtract
    }
    public enum Shift_Expression_OperatorInfo
    {
        [Description("<<")]
        Left,
        [Description(">>")]
        Right
    }
    public enum Relational_Expression_OperatorInfo
    {
        [Description(">")]
        GT,
        [Description("<")]
        LT,
        [Description(">=")]
        GTEqual,
        [Description("<=")]
        LTEqual
    }
    public class ExpressionStatementInfo : StatementInfo
    {
        public List<AssignmentExpressionInfo> AssignmentExpressions { get; set; }
        public ExpressionStatementInfo(TokenPair token):base(token)
        {        
            this.AssignmentExpressions = new List<AssignmentExpressionInfo>();
        }
  
        internal override void Render(IndentStringBuilder builder)
        {
            if (this.Expression != null)
                this.Expression.Render(builder);
            if (this.DeclareStatement != null)
                this.DeclareStatement.Render(builder);
            
            for (var index = 0; index < this.AssignmentExpressions.Count; index ++ )
            {
                this.AssignmentExpressions[index].Render(builder);
            }
        }

        internal override T_Type Wise(T_Type type, ModelInfo modelInfo)
        {
            //if (this.Expression != null)
            //    return this.Expression.Wise(type,modelInfo);
            //if (this.DeclareStatement != null)
            //    return this.DeclareStatement.Wise(type,modelInfo);
            var temp = type;
            for (var index = 0; index < this.AssignmentExpressions.Count; index++)
            {
                temp = this.AssignmentExpressions[index].Wise(temp, modelInfo);
            }
            return temp;
        }

        internal override void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            if (this.Expression != null)
                this.Expression.RenderView(builder, modelInfo);
            if (this.DeclareStatement != null)
                this.DeclareStatement.RenderView(builder, modelInfo);

            for (var index = 0; index < this.AssignmentExpressions.Count; index++)
            {
                this.AssignmentExpressions[index].RenderView(builder, modelInfo);
            }
        }

        private void RenderView(IndentStringBuilder builder)
        {
            throw new NotImplementedException();
        }
    }

    public class DeclareStatementInfo:StatementInfo
    {
        public DeclareStatementInfo(TokenPair token):base(token)
        {     
        }

    }

    public class StatementInfo 
    {
        /// <summary>
        /// 排他，单独存在
        /// </summary>
        public ExpressionStatementInfo Expression { get; set; }
        /// <summary>
        /// 排他，单独存在
        /// </summary>
        public DeclareStatementInfo DeclareStatement { get; set; }
        public StatementInfo(TokenPair token)
        {     
            this.TokenPair = token;           
        }
        internal virtual void Render(IndentStringBuilder builder)
        {
            if (this.Expression != null)
                this.Expression.Render(builder);
            if (this.DeclareStatement != null)
                this.DeclareStatement.Render(builder);
        }

        internal virtual T_Type Wise(T_Type type ,ModelInfo modelInfo)
        {
            if (this.Expression != null)
                this.Expression.Wise(type ,modelInfo);
            if (this.DeclareStatement != null)
                this.DeclareStatement.Wise(type ,modelInfo);

            return null;
        }

        public TokenPair TokenPair { get; set; }

        internal virtual void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            if (this.Expression != null)
                this.Expression.RenderView(builder, modelInfo);
            if (this.DeclareStatement != null)
                this.DeclareStatement.RenderView(builder, modelInfo);
        }
    }

    public class PushInfo
    {
        public ExpressionStatementInfo Source { get; set; }
        public List<StatementInfo> Target { get; set; }
        private T_Type SourceType { get; set; }
        
        public PushInfo(TokenPair token)
        {
            this.TokenPair = token;           
            Target = new List<StatementInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            this.Source.Render(builder);
            builder.AppendLine(" ==>");
            builder.AppendLine("{");
            foreach (var state in this.Target)
            {
                builder.Append("\t");
                state.Render(builder);
                builder.AppendLine(";");                
            }
            builder.AppendLine("}");
        }

        internal void Wise(ModelInfo modelInfo)
        {
            //throw new NotImplementedException();
            //source 必须是bool结果或者是事件类型

            SourceType = this.Source.Wise(null, modelInfo);
            foreach (var state in this.Target)
            {
                state.Wise(null,modelInfo);
            }
        }

        public TokenPair TokenPair { get; set; }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            //执行顺序：事件，bool表达式，拉语句
            var para = new IndentStringBuilder();
            para.Append("function(){");
            foreach (var state in this.Target)
            {
                para.AppendLine();
                para.Append("\t\t");
                state.RenderView(para, modelInfo);
            }
            para.AppendLine();
            para.Append("\t}");

            if (this.SourceType is T_EventType)
            {
                //this.SourceType.RenderView(builder, null, null, null, null, null, null, null);
                //var para = new IndentStringBuilder();
                //para.Append("function(){");
                //foreach (var state in this.Target)
                //{
                //    para.AppendLine();
                //    para.Append("\t\t");
                //    state.RenderView(para, modelInfo);
                //}
                //para.AppendLine();
                //para.Append("\t}");

                this.Source.RenderView(builder, modelInfo);

                builder.Append("(");
                builder.AppendLine(para.ToString());
                builder.AppendLine(");");
            }
            else if (this.SourceType is T_Boolean)
            {
                var sourceBuilder = new IndentStringBuilder();
                this.Source.RenderView(sourceBuilder, modelInfo);
                builder.AppendFormat("{0}.RegistPushEvent(function(){{return {1};}},", modelInfo.Area, sourceBuilder.ToString());
              

                //builder.Append("(");
                builder.AppendLine(para.ToString());
                builder.AppendLine(");");
            }
        }
    }

    public class PullInfo 
    {
        public ExpressionStatementInfo Source { get; set; }
        public VariableInfo Target { get; set; }
        public PullInfo(TokenPair token)
        {
            this.TokenPair = token;                       
        }

        internal void Render(IndentStringBuilder builder)
        {
            Target.Render(builder);
            builder.Append(" <== " );            
            Source.Render(builder);
            builder.AppendLine(";");
        }

        internal void Wise(ModelInfo modelInfo)
        {
            //throw new NotImplementedException();
            this.Source.Wise(null,modelInfo);
            this.Target.Wise(modelInfo);
        }

        public TokenPair TokenPair { get; set; }

        internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo)
        {
            builder.AppendFormat("{0}.RegistPullEvent(function()",modelInfo.Area);
            builder.AppendLine("{");
            var sourceBuilder = new IndentStringBuilder();
            this.Source.RenderView(sourceBuilder, modelInfo);
            builder.AppendFormat("\tvar v = {0};", sourceBuilder.ToString());
            builder.AppendLine();
            var targetBuilder = new IndentStringBuilder();
            var paraBuilder = new IndentStringBuilder();
            paraBuilder.Append("v");
            this.Target.RenderView(targetBuilder, modelInfo, paraBuilder);
            builder.AppendFormat("\t{0};", targetBuilder.ToString());
            builder.AppendLine();
            builder.AppendLine("});");
        }
    }

    public static class ParseModuleBaseExtension
    {
        public static void AddError(this ParseModuleBase module, string message, Token token)
        {
            module.Errors.Add(new ParseErrorInfo()
            {
                Message = message,
                CharPositionInLine = token.CharPositionInLine,
                Line = token.Line,
                ErrorType = ErrorType.Error,
                File = module.File,
                FileId = module.FileId
            });
        }
    }

    public class ViewModelDB : ParseModuleBase
    {
        public List<Model> Models { get; set; }

        public List<ModelInfo> ModelInfos { get; set; }

        public static ViewModelDB Current { get; set; }

        public ViewModelDB()
        {
            ModelInfos = new List<ModelInfo>();
        }
        public void Parse()
        {
            
        }

        public override void Initialize()
        {
            try
            {
                foreach (var model in Models)
                {
                    this.ModelInfos.Add(model.Parse());
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }
        }

        public override void Wise()
        {
            //base.Wise();
            foreach (var model in this.ModelInfos)
            {
                model.Wise();
            }
        }

        public void Render(IndentStringBuilder builder)
        {
            foreach (var model in this.ModelInfos)
            {
                model.Render(builder);
                builder.AppendLine();
            }
        }

        public void RenderView(IndentStringBuilder builder)
        {
            builder.AppendFormatLine(
@"@model CodeHelper.Workflow.ResultInfo
@{{
    ViewBag.Title = Model.Node;
}}
<form action=""/workflow/Process"" >
<input type=""hidden"" name=""instanceId"" value=""@Model.InstanceId""/>
<input type=""hidden"" name=""nodeId"" value=""@Model.NodeId""/>
");
            foreach (var model in this.ModelInfos)
            {                
                model.RenderView(builder);
                builder.AppendLine();
            }

            builder.AppendLine(
@"<button type=""submit"" name=""submit"">
    submit</button>
</form>");
        }
    }
}