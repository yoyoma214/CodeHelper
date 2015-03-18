using System;
using System.Collections.Generic;
using CodeHelper.Core.Error;
using System.ComponentModel;
using CodeHelper.Common.Extensions;
using System.Text;
using CodeHelper.Common;
using CodeHelper.DataBaseHelper.DbSchema;
using System.Linq;
using System.IO;

namespace CodeHelper.Core.Parse.ParseResults.Workflows
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

        public static List<T> SubList<T>(this List<T> list, int from, int to)
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

        internal void Wise(ClzInfo modelInfo)
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

    public class RegionInfo
    {
        public string Name { get; set; }
        public bool IsClass { get; set; }
        public List<FieldInfo> Fields { get; set; }
        public List<ClzInfo> Clzes { get; set; }
        public List<UnitInfo> Units { get; set; }
        public RegionInfo Parent { get; set; }
        public RegionInfo Prev { get; set; }
        public RegionInfo()
        {
            this.Clzes = new List<ClzInfo>();
            this.Fields = new List<FieldInfo>();
            this.Units = new List<UnitInfo>();
        }
        public RegionInfo(string name, bool isClass)
            : this()
        {
            this.Name = name;
            this.IsClass = isClass;
        }

        public ClzInfo FindClz(string name)
        {
            return null;
        }

        public FieldInfo FindField(string name)
        {
            return this.FindField(name, this.IsClass);
        }

        public FieldInfo FindField(string name, bool inClass)
        {
            foreach (var f in this.Fields)
            {
                if (f.Name == name)
                    return f;
            }

            if (this.Prev != null)
            {
                var rslt = this.Prev.FindField(name);
                if (rslt != null)
                    return rslt;
            }

            //不跨越父类搜索字段
            if (this.Parent.IsClass && inClass)
                return null;

            if (this.Parent != null)
                return this.Parent.FindField(name);

            return null;
        }

        public UnitInfo FindUnit(string name)
        {
            foreach (var n in this.Units)
            {
                if (n.Name == name)
                    return n;
            }

            if (this.Prev != null)
            {
                var rslt = this.Prev.FindUnit(name);
                if (rslt != null)
                    return rslt;
            }

            if (this.Parent != null)
                return this.Parent.FindUnit(name);

            return null;
        }
    }

    public class RefWorkflowInfo
    {
        public TokenPair TokenPair { get; set; }
        public string Target { get; set; }
        public static event OnSearchWorkflow SearchWorkflow;

        internal void Wise(string thisFlow)
        {
            //查询数据库是否有该流程
            if (RefWorkflowInfo.SearchWorkflow != null)
            {
                var wf = RefWorkflowInfo.SearchWorkflow(this.Target);
                if (wf == null)
                {
                    WorkflowDB.Current.AddError("系统没有该流程:" + this.Target, this.TokenPair.EndToken);
                    return;
                }
                if (wf.Name.Equals(thisFlow, StringComparison.OrdinalIgnoreCase))
                {
                    WorkflowDB.Current.AddError("流程引用不能执行自身:" + this.Target, this.TokenPair.EndToken);
                    return;
                }
            }
        }


    }

    public class FieldInfo
    {
        public TokenPair TokenPair { get; set; }
        public GenericTypeInfo GenericType { get; set; }
        public String Name { get; set; }
        public ExpressionInfo Default_value { get; set; }
        public List<OptionInfo> Options { get; set; }
        public T_Type TypeInfo { get; set; }
        public string DbType(DatabaseType dbType)
        {
            if (this.TypeInfo == null)
                return "unknown";

            return SchemaUtility.GetSpecifcDbType(dbType, this.TypeInfo.Name);
        }
        //public T_InputType Input { get; set; }

        public FieldInfo(TokenPair token)
        {
            this.TokenPair = token;
            Options = new List<OptionInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {

            GenericType.Render(builder);
            builder.Append(" " + this.Name);
            if (Default_value != null)
            {
                builder.Append("=");
                Default_value.Render(builder);
            }

            if (this.Options.Count > 0)
                builder.Append("{");
            for (var index = 0; index < this.Options.Count; index++)
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

        internal void Wise(ClzInfo modelInfo, RegionInfo region)
        {
            if (this.Name.Equals("parent"))
                return;

            //判断类型是否存在
            this.TypeInfo = T_Type.ParseType(this.GenericType);

            //if (this.TypeInfo is T_ListType)
            //{
            //    var lstType = this.TypeInfo as T_ListType;
            //    if (lstType.ItemType is T_CustomType)
            //    {
            //        region
            //    }
            //}

            if (this.TypeInfo == null)
            {
                WorkflowDB.Current.AddError("不支持此类型" + this.GenericType, this.TokenPair.BeginToken);
                return;
            }

            if (modelInfo != null)
            {
                foreach (var f in modelInfo.fields)
                {
                    if (f.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase) && f != this)
                    {
                        WorkflowDB.Current.AddError("重复定义" + this.Name, this.TokenPair.BeginToken);
                        return;
                    }
                }
            }
        }

        internal void RenderSql(Stack<string> context, DatabaseType dbType, IndentStringBuilder builder, IndentStringBuilder tailBuilder)
        {
            if (this.TypeInfo == null)
            {
                builder.AppendFormatLine("unkown field");
                return;
            }

            //if (this.Name == "OrderInfo")
            //{
            //}

            if (this.TypeInfo is T_ListType)
            {
                var lstType = this.TypeInfo as T_ListType;
                if (!(lstType.ItemType is ClzInfo))
                {
                    builder.AppendFormatLine("cannot generate " + lstType.ToString());
                }
                else
                {
                    var tableName = context.Reverse().ToArray()[0] + "_" + lstType.ItemType.FullName.Replace(".", "_");
                    var fkTableName = string.Join("_", context.Reverse().ToList().SubList(1));
                    tailBuilder.AppendFormatLine("ALTER TABLE {0} ADD {1}Id uniqueidentifier NULL;", tableName, fkTableName);
                }
            }
            else if (this.TypeInfo is T_CustomType)
            {
                //builder.AppendFormatLine("[{0}Id] uniqueidentifier NULL,", this.TypeInfo.Name, this.DbType(dbType));
            }
            else if (this.TypeInfo is ClzInfo)
            {
                builder.AppendFormatLine("[{0}Id] uniqueidentifier NULL,", this.Name, this.DbType(dbType));
            }
            else
            {
                builder.AppendFormatLine("[{0}] {1} {2} NULL,", this.Name, this.DbType(dbType), this.TypeInfo.NullAble ? "" : "NOT");
            }
        }



        internal void RenderWF(IndentStringBuilder builder, bool parentIsClz)
        {
            if (parentIsClz)
            {
            }

            if (this.Name.Equals("parent", StringComparison.OrdinalIgnoreCase))
                return;

            parentIsClz = true;

            if (parentIsClz)
            {
                builder.AppendFormatLine("public {0} {1}", this.TypeInfo.Name, this.Name);
                builder.AppendLine("{get;set;}");
            }
            else
            {


                builder.AppendFormatLine("public Variable<{0}> {1} = new Variable<{0}>", this.TypeInfo.Name, this.Name);
                builder.IncreaseIndentLine("{");
                if (this.Default_value != null)
                {
                    var sb = new IndentStringBuilder();
                    this.Default_value.Render(sb);
                    builder.AppendFormatLine("Default = {0}", sb.ToString());
                }
                builder.DecreaseIndentLine("};");
            }
        }


        internal void RenderMapping(IndentStringBuilder builder, bool p)
        {
            //if (this.TypeInfo.Enumerable)
            //{
            //    return;
            //}

            if (this.TypeInfo is T_ListType)
            {


                //    this.HasMany(x => x.Details).WithOptional(y => y.OrderInfo)
                //.Map(z => z.MapKey("OrderInfoId")).WillCascadeOnDelete(true);
            }
            else
            {
                builder.AppendFormat("Property(t => t.{0})", this.Name);

                if (!this.TypeInfo.NullAble)
                {
                    builder.AppendFormat(".IsRequired()");
                }
                builder.AppendLine(";");

                builder.AppendFormat("Property(t => t.{0}).HasColumnName(\"{0}\")", this.Name);
                builder.AppendLine(";");
            }
        }

        internal void RenderModel(IndentStringBuilder builder, bool parentIsClz)
        {
            parentIsClz = true;

            if (parentIsClz)
            {
                var nullAble = "";
                if (!(this.TypeInfo is T_ListType) && this.TypeInfo.NullAble)
                    nullAble = "?";

                if (this.TypeInfo == T_Type.String)
                {
                    nullAble = "";
                }

                var virtualStr = "";
                if (this.TypeInfo is T_ListType || this.TypeInfo is ClzInfo)
                {
                    virtualStr = "virtual ";
                }
                builder.AppendFormatLine("public {0}{1}{2} {3}", virtualStr, this.TypeInfo.Name, nullAble, this.Name);
                builder.AppendLine("{get;set;}");
            }
            else
            {
                builder.AppendFormatLine("public Variable<{0}> {1} = new Variable<{0}>", this.TypeInfo.Name, this.Name);
                builder.IncreaseIndentLine("{");
                if (this.Default_value != null)
                {
                    var sb = new IndentStringBuilder();
                    this.Default_value.Render(sb);
                    builder.AppendFormatLine("Default = {0}", sb.ToString());
                }
                builder.DecreaseIndentLine("};");
            }
        }
    }

    //public class ModelInfo :T_Type
    //{
    //    public TokenPair TokenPair { get; set; }

    //    #region 静态信息
    //    public String Area { get; set; }

    //    public List<AttributeInfo> Attributes { get; set; }

    //    public String Name { get; set; }

    //    public List<FieldInfo> FieldInfos { get; set; }

    //    //public T_Field GetField(string name)
    //    //{
    //    //    foreach (var f in Fields)
    //    //    {
    //    //        if (f.Name.Equals(name))
    //    //            return f;
    //    //    }

    //    //    return null;
    //    //}
    //    #endregion

    //    #region 动态信息
    //    public List<VariableInfo> Variables { get; set; }

    //    public VariableInfo GetVariable(string name)
    //    {
    //        if (this.Name == "$")
    //        {

    //        }

    //        foreach (var v in Variables)
    //        {
    //            if (v.Name.Equals(name))
    //                return v;
    //        }

    //        return null;
    //    }

    //    public List<PushInfo> PushInfos { get; set; }

    //    public List<PullInfo> PullInfos { get; set; }

    //    public List<StatementInfo> StatementInfos { get; set; }
    //    #endregion

    //    public ModelInfo(TokenPair token)
    //    {
    //        this.TokenPair = token;
    //        Attributes = new List<AttributeInfo>();
    //        //Fields = new List<FieldInfo>();
    //        Variables = new List<VariableInfo>();
    //        PushInfos = new List<PushInfo>();
    //        PullInfos = new List<PullInfo>();
    //        StatementInfos = new List<StatementInfo>();
    //        FieldInfos = new List<FieldInfo>();
    //    }

    //    internal void Render(IndentStringBuilder builder)
    //    {
    //        builder.AppendLine(this.Area + ":");
    //        foreach (var attr in this.Attributes)
    //        {
    //            builder.AppendFormatLine("[{0}({1})]", attr.Name, attr.Value);
    //        }
    //        builder.AppendFormatLine("class {0}", this.Name);
    //        builder.AppendLine("{");
    //        foreach (var field in this.FieldInfos)
    //        {
    //            builder.Append("\t");
    //            field.Render(builder);              
    //        }

    //        builder.AppendLine("}");

    //        if ( Variables.Count > 0 ) builder.AppendLine();
    //        foreach (var variable in this.Variables)
    //        {
    //            variable.Render(builder);
    //            builder.AppendLine(";");
    //        }

    //        if (StatementInfos.Count > 0) builder.AppendLine();
    //        foreach (var state in this.StatementInfos)
    //        {
    //            state.Render(builder);
    //            builder.AppendLine(";");
    //        }

    //        if (PushInfos.Count > 0) builder.AppendLine();
    //        foreach (var push in this.PushInfos)
    //        {                
    //            push.Render(builder);
    //        }

    //        if (PullInfos.Count > 0) builder.AppendLine();
    //        foreach (var pull in this.PullInfos)
    //        {
    //            pull.Render(builder);
    //        }

    //    }

    //    internal void Wise()
    //    {
    //        try
    //        {
    //            foreach (var attr in this.Attributes)
    //                attr.Wise(this);

    //            foreach (var field in this.FieldInfos)
    //                field.Wise(this);

    //            foreach (var variable in this.Variables)
    //                variable.Wise(this);

    //            foreach (var statement in this.StatementInfos)
    //                statement.Wise(null,this);

    //            foreach (var push in this.PushInfos)
    //                push.Wise(this);

    //            foreach (var pull in this.PullInfos)
    //                pull.Wise(this);
    //        }
    //        catch (Exception ex)
    //        {
    //        }
    //    }

    //    internal void RenderView(IndentStringBuilder builder)
    //    {
    //        try
    //        {
    //            //foreach (var attr in this.Attributes)
    //            //    attr.Wise(this);

    //            //foreach (var field in this.FieldInfos)
    //            //    field.Wise(this);

    //            //foreach (var variable in this.Variables)
    //            //    variable.Wise(this);

    //            foreach (var statement in this.StatementInfos)
    //            {
    //                statement.RenderView(builder, this);
    //                builder.AppendLine();
    //            }

    //            foreach (var push in this.PushInfos)
    //                push.RenderView(builder,this);

    //            foreach (var pull in this.PullInfos)
    //                pull.RenderView(builder,this);
    //        }
    //        catch (Exception ex)
    //        {
    //            System.Console.Error.WriteLine(ex.StackTrace);
    //        }
    //    }

    //    public override T_Type RenderView(IndentStringBuilder builder, List<string> call_stack, IndentStringBuilder paras, AssignOperatorInfo? op, IndentStringBuilder opValue, PostfixPartType? postfixPartType, IndentStringBuilder func_paras, IndentStringBuilder index_para)
    //    {
    //        //if (builder.Length == 0)
    //            builder.Append(this.Area);
    //        return base.RenderView(builder, call_stack, paras, op, opValue, postfixPartType, func_paras, index_para);
    //    }
    //}
    //public class ExpressionInfo
    //{

    //}

    public class GenericTypeInfo
    {
        /// <summary>
        /// 排他存在
        /// </summary>
        public String Long_Name { get; set; }

        public GenericTypeInfo Header { get; set; }
        /// <summary>
        /// 和header一起表示泛型
        /// </summary>
        public List<GenericTypeInfo> Parameters { get; set; }

        public GenericTypeInfo()
        {
            this.Parameters = new List<GenericTypeInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            if (!string.IsNullOrWhiteSpace(this.Long_Name))
                builder.Append(this.Long_Name);
            else
            {
                this.Header.Render(builder);
                builder.Append("<");
                foreach (var p in this.Parameters)
                {
                    p.Render(builder);
                    if (p != this.Parameters[this.Parameters.Count - 1])
                        builder.Append(",");
                }
                builder.Append(">");
            }
        }
    }

    public class VariableInfo : StatementInfo
    {
        public TokenPair TokenPair { get; set; }

        public GenericTypeInfo GenericType { get; set; }

        public string Name { get; set; }

        public ExpressionInfo Value { get; set; }

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
            : base(token)
        {
            this.TokenPair = token;
        }

        internal override void Render(IndentStringBuilder builder)
        {
            //builder.AppendFormat("{0} {1}",this.GenericType, this.Name);
            this.GenericType.Render(builder);
            builder.Append(" " + this.Name);
            if (this.Value != null)
            {
                builder.Append(" = ");
                this.Value.Render(builder);
                builder.Append(";");
            }
            //builder.AppendLine(";");
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo, IndentStringBuilder val)
        {
            //this.RootType.RenderView(builder, this.Spans.SubList(1), null,AssignOperatorInfo.Equal, val, null, null, null);
        }
        internal override T_Type Wise(T_Type type1, RegionInfo region)
        {
            #region 类型判断
            if (this.GenericType != null)
            {
                this.TypeInfo = T_Type.ParseType(this.GenericType);
                if (this.TypeInfo == null)
                    WorkflowDB.Current.AddError("不支持此类型" + this.GenericType, this.TokenPair.BeginToken);
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
                        if (span == "$") { }
                        //this.RootType = type = modelInfo;
                        else
                        {
                            WorkflowDB.Current.AddError("必须是$开头", this.TokenPair.BeginToken);
                        }
                    }
                    else
                    {
                        var f = type.GetField(span);
                        if (f == null)
                        {
                            WorkflowDB.Current.AddError("无法找到字段" + span, this.TokenPair.BeginToken);
                            return null;
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
                var t = this.Value.Wise(null, region);
                if (this.TypeInfo != t)
                {
                    WorkflowDB.Current.AddError("右边类型应该是" + this.TypeInfo.Name, this.TokenPair.BeginToken);
                    return null;
                }
            }
            #endregion

            region.Fields.Add(new FieldInfo(this.TokenPair) { Name = this.Name, TypeInfo = this.TypeInfo });
            return this.TypeInfo;
        }
    }

    public class ClzInfo : T_Type
    {
        public List<FieldInfo> fields { get; set; }
        public TokenPair TokenPair { get; set; }
        public string MappingNameSpace { get; set; }
        public string TableName { get; set; }

        public ClzInfo()
        {
            this.fields = new List<FieldInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            builder.AppendFormatLine("class {0}", this.Name);
            builder.IncreaseIndentLine("{");
            foreach (var f in this.fields)
                f.Render(builder);
            builder.DecreaseIndentLine("}");
        }

        internal void Wise(RegionInfo region, string flowName, string rootNameSpace, string nameSpace, string mapping_nameSpace)
        {
            //var newType = T_Type.ParseType(this.Name);
            this.NameSpace = nameSpace;

            this.MappingNameSpace = mapping_nameSpace;

            this.TableName = flowName + "." + this.Name;
            this.TableName = "WF_" + this.TableName.Replace(".", "_");
            foreach (var f in this.fields)
            {
                if (f.GenericType == null)
                    continue;

                f.Wise(this, null);

                //newType.Fields.Add(new T_Field() { Name = f.Name, Type = f.TypeInfo });
            }

            var hasId = false;

            foreach (var f in this.fields)
            {
                if (f.Name.Equals("Id", StringComparison.InvariantCultureIgnoreCase))
                {
                    hasId = true;
                }
            }
            if (!hasId)
            {
                fields.Insert(0, new FieldInfo(null) { TypeInfo = T_GuidType.Guid, Name = "Id" });
            }

            this.fields[0].TypeInfo.NullAble = false;

            if (region.Name == "Program")
            {
                this.fields.Insert(1, new FieldInfo(null) { TypeInfo = T_GuidType.Guid, Name = "InstanceId" });
            }
            else
            {
                this.fields.Insert(1, new FieldInfo(null) { TypeInfo = T_GuidType.Guid, Name = "NodeStateId" });
            }



        }

        internal void RenderSql(Stack<string> context, DatabaseType dbType, IndentStringBuilder builder, IndentStringBuilder tailBuilder)
        {
            context.Push(this.Name);
            var list = context.ToList();
            list.Reverse();
            //var tableName = string.Join("_", list);
            builder.Increase();
            builder.AppendFormatLine("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'U'))", TableName);
            builder.AppendFormatLine("BEGIN");
            builder.AppendFormatLine("\tDROP TABLE dbo.{0}", TableName);
            builder.AppendFormatLine("END");
            builder.AppendLine();

            builder.AppendFormatLine("CREATE TABLE [dbo].[{0}](", TableName);

            foreach (var f in this.fields)
            {
                f.RenderSql(context, dbType, builder, tailBuilder);
            }

            //if (context.Count == 3)
            //{
            //    builder.AppendLine("[WFId] uniqueidentifier NOT NULL,");
            //}
            //if (context.Count == 4)
            //{
            //    builder.AppendLine("[NodeId] uniqueidentifier NOT NULL,");
            //}

            builder.AppendFormatLine(" CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED ", TableName);
            builder.AppendLine("(");
            builder.AppendLine("	[Id] ASC");
            builder.AppendLine(")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]");
            builder.AppendLine(") ON [PRIMARY]");
            builder.Decrease();
            builder.AppendLine("GO");
            builder.AppendLine();
            context.Pop();
        }

        internal void RegistType(string nameSpace)
        {
            //var newType = new T_CustomType();
            //newType.Name = this.Name;
            //newType.NameSpace = nameSpace;

            //if (T_Type.ParseType(this.Name) != null)
            //{
            //    WorkflowDB.Current.AddError(string.Format("类型重复定义:{0}", this.Name), this.TokenPair.BeginToken);
            //}
            //else
            //{
            //    T_Type.Regist(newType);
            //}

            this.NameSpace = nameSpace;
            if (T_Type.ParseType(this.Name) != null)
            {
                WorkflowDB.Current.AddError(string.Format("类型重复定义:{0}", this.Name), this.TokenPair.BeginToken);
            }
            else
            {
                T_Type.Regist(this);
            }
        }

        internal void RenderWF(IndentStringBuilder builder)
        {
            builder.AppendFormatLine("public class {0}", this.Name);
            builder.IncreaseIndentLine("{");
            foreach (var f in this.fields)
            {
                f.RenderWF(builder, true);
            }
            builder.DecreaseIndentLine("}");
        }

        internal void RenderModel(IndentStringBuilder builder, NodeInfo node)
        {
            builder.AppendFormatLine("public class {0}", this.Name);
            builder.IncreaseIndentLine("{");

            builder.AppendFormatLine("public {0}()", this.Name);
            builder.IncreaseIndentLine("{");
            foreach (var f in this.fields)
            {
                if (f.TypeInfo is T_ListType)
                {
                    builder.AppendFormatLine("this.{0} = new List<{1}>();", f.Name, ((T_ListType)f.TypeInfo).ItemType.Name);
                }
            }
            builder.DecreaseIndentLine("}");

            foreach (var f in this.fields)
            {
                f.RenderModel(builder, true);
            }
            builder.DecreaseIndentLine("}");
        }

        internal void RenderMapping(IndentStringBuilder builder, NodeInfo nodeInfo)
        {
            builder.AppendFormatLine("public class {0}Map:EntityTypeConfiguration<{0}>", this.Name);
            builder.IncreaseIndentLine("{");
            builder.IncreaseIndentLine(string.Format("public {0}Map()", this.Name) + "{");
            builder.AppendLine("// Primary Key");
            builder.AppendLine(string.Format("HasKey(t => t.{0});", "Id"));

            builder.AppendLine();

            builder.AppendLine(string.Format("ToTable(\"{0}\");", this.TableName));

            foreach (var f in this.fields)
            {
                //1 -- *
                if (f.TypeInfo.Enumerable)
                {
                    builder.AppendLine();
                    builder.AppendFormatLine("this.HasMany(x => x.{0}).WithOptional(y => y.{1}).Map(y => y.MapKey(\"{1}Id\"));", f.Name, this.Name);
                    continue;
                }
                else if (f.TypeInfo is ClzInfo)
                {
                    var clz = f.TypeInfo as ClzInfo;
                    bool alread_render_relation = false;
                    foreach (var f2 in clz.fields)
                    {
                        var list = f2.TypeInfo as T_ListType;
                        if (list != null && list.ItemType == this)
                        {
                            alread_render_relation = true;
                            break;
                        }
                    }
                    if (alread_render_relation)
                        continue;

                    builder.AppendLine();
                    //1 -- 1/0
                    builder.AppendFormatLine("this.HasOptional(x => x.{0}).WithOptionalDependent().Map(y => y.MapKey(\"{1}Id\"));", f.Name, f.Name);
                    continue;
                }

                builder.AppendLine();
                f.RenderMapping(builder, true);
                //builder.AppendLine();
            }

            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");
        }

        internal void RenderDBContext(IndentStringBuilder builder, IndentStringBuilder onModelCreating)
        {
            builder.AppendFormatLine("public DbSet<{0}.{1}> {1}s", this.NameSpace, this.Name);
            builder.IncreaseIndentLine("{");
            builder.AppendLine("get");
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("return this.Set<{0}.{1}>();", this.NameSpace, this.Name);
            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");

            onModelCreating.AppendFormatLine("modelBuilder.Configurations.Add(new {0}.{1}Map());", this.MappingNameSpace, this.Name);
        }
    }

    public class VariableDefine
    {
        public List<ClzInfo> Clzes { get; set; }
        public List<FieldInfo> Fields { get; set; }
        public RegionInfo Region { get; set; }
        public VariableDefine()
        {
            this.Clzes = new List<ClzInfo>();
            this.Fields = new List<FieldInfo>();
            this.Region = new RegionInfo("variable", true);
        }

        internal void Render(IndentStringBuilder builder)
        {
            foreach (var clz in this.Clzes)
                clz.Render(builder);
            foreach (var f in this.Fields)
                f.Render(builder);
        }

        internal void Wise(RegionInfo region, string flowName, string rootNameSpace, string nameSpace, string mapping_nameSpace)
        {
            foreach (var clz in this.Clzes)
            {
                clz.Wise(region, flowName, rootNameSpace, nameSpace, mapping_nameSpace);
                clz.NameSpace = nameSpace;
            }
            foreach (var f in this.Fields)
                f.Wise(null, region);
        }

        internal void RenderSql(Stack<string> context, DatabaseType dbType, IndentStringBuilder builder, IndentStringBuilder tailBuilder)
        {

            //生成在U_WFName中
            var list = context.ToList();
            list.Reverse();
            var tableName = string.Join("_", list);

            foreach (var clz in this.Clzes)
                clz.RenderSql(context, dbType, builder, tailBuilder);

        }

        internal void RegistType(string nameSpace)
        {
            foreach (var clz in this.Clzes)
            {
                clz.RegistType(nameSpace);

            }

        }

        internal void RenderWF(IndentStringBuilder builder)
        {
            //foreach (var clz in this.Clzes)
            //    clz.RenderWF(builder);

            foreach (var f in this.Fields)
                f.RenderWF(builder, this.Region.IsClass || this.Region.Parent.IsClass);
        }

        internal void RenderModel(IndentStringBuilder builder, NodeInfo node)
        {
            foreach (var clz in this.Clzes)
                clz.RenderModel(builder, node);
        }

        internal void RenderMapping(IndentStringBuilder builder, NodeInfo nodeInfo)
        {
            foreach (var clz in this.Clzes)
                clz.RenderMapping(builder, nodeInfo);
        }

        internal void RenderDBContext(IndentStringBuilder builder, IndentStringBuilder onModelCreating)
        {
            foreach (var clz in this.Clzes)
                clz.RenderDBContext(builder, onModelCreating);
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
                rslt.AddRange(Text.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries));
                return rslt;
            }
        }

        public LValueInfo(TokenPair token)
        {
            this.TokenPair = token;
        }

        internal T_Type Wise(RegionInfo region)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.Text))
                {
                    T_Type rootType = null;

                    if (this.Spans[0] == "$")
                    {
                    }
                    else
                    {
                        var v = region.FindField(this.Spans[0]);
                        rootType = v.TypeInfo;
                    }
                    var prevType = RootType = rootType;
                    for (var index = 1; index < this.Spans.Count; index++)
                    {
                        var f = prevType.GetField(this.Spans[index]);
                        if (f == null)
                        {
                            WorkflowDB.Current.AddError("无法获取字段:" + this.Spans[index], this.TokenPair.BeginToken);
                            return null;
                        }
                        prevType = f.Type;
                    }

                    this.TypeInfo = prevType;

                    return prevType;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        internal void RenderView(IndentStringBuilder builder, ConditionalExpressionInfo ConditionalExpression, ClzInfo modelInfo, AssignOperatorInfo? op, IndentStringBuilder rightBuilder)
        {
            //RootType.RenderView(builder, this.Spans.SubList(1), null,op, rightBuilder,null,null,null);
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

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            if (ConditionalExpression != null)
            {
                return this.ConditionalExpression.Wise(region);
            }
            else
            {
                var rslt = this.LValue.Wise(region);

                if (rslt is T_InputType)
                    WorkflowDB.Current.AddError("输入类型不能被赋值", this.TokenPair.BeginToken);

                var right = this.AssignmentExpression.Wise(type, region);

                if (rslt != right)
                {
                    WorkflowDB.Current.AddError("右边表达式应该为" + rslt.Name, this.AssignmentExpression.TokenPair.BeginToken);
                }
                return rslt;
            }
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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
                this.LValue.RenderView(builder, ConditionalExpression, modelInfo, this.AssignOperator, sb);
                builder.Append(";");
            }
        }
    }

    public class ConditionalExpressionInfo
    {
        public TokenPair TokenPair { get; set; }

        public Logical_Or_ExpressionInfo Logical_Or_Expression { get; set; }
        /// <summary>
        /// 可选
        /// </summary>
        public ExpressionInfo Expression { get; set; }
        /// <summary>
        /// 可选
        /// </summary>
        public ConditionalExpressionInfo ConditionalExpression { get; set; }

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

        internal T_Type Wise(RegionInfo region)
        {
            T_Type rslt = this.Logical_Or_Expression.Wise(null, region);
            T_Type t1 = null;
            T_Type t2 = null;
            if (this.Expression != null)
                t1 = this.Expression.Wise(null, region);
            if (ConditionalExpression != null)
                t2 = this.ConditionalExpression.Wise(region);

            if (t1 != t2)
            {
                WorkflowDB.Current.AddError("条件表达式类型必须相同", this.TokenPair.BeginToken);
            }

            if (t1 != null)
                return t1;

            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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
                if (index > 0)
                {
                    builder.Append(" && ");
                }
                this.Logical_And_Expressions[index].Render(builder);
            }
        }

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.Logical_And_Expressions.Count; index++)
            {
                rslt = this.Logical_And_Expressions[index].Wise(type, region);
                //if (temp == null || temp.GetType() != typeof(T_Boolean))
                //{
                //    ViewModelDB.Current.AddError("布尔表达式必须为boolean类型", this.TokenPair.BeginToken);
                //}
            }

            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.Inclusive_Or_Expressions.Count; index++)
            {
                rslt = this.Inclusive_Or_Expressions[index].Wise(type, region);
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

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.Exclusive_Or_Expressions.Count; index++)
            {
                rslt = this.Exclusive_Or_Expressions[index].Wise(type, region);
            }

            if (this.Exclusive_Or_Expressions.Count > 1)
                return T_Type.ParseType("int");

            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.And_Expressions.Count; index++)
            {
                rslt = this.And_Expressions[index].Wise(type, region);
            }

            if (this.And_Expressions.Count > 1)
                return T_Type.ParseType("int");

            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            var types = new List<T_Type>();
            for (var index = 0; index < this.Equality_Expressions.Count; index++)
            {
                types.Add(this.Equality_Expressions[index].Wise(type, region));
            }

            for (var i = 0; i < types.Count; i++)
            {
                for (var j = i + 1; j < types.Count; j++)
                {
                    if (types[i].GetType() != types[j].GetType())
                    {
                        WorkflowDB.Current.AddError("类型必须相同", TokenPair.BeginToken);
                    }
                }
            }
            return types[0];
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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
                    builder.AppendFormat(" {0} ", this.Equality_Expression_Operators[index - 1].GetDescription());

                this.Relational_Expressions[index].Render(builder);
            }
        }

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            if (this.Relational_Expressions.Count > 2)
            {
                WorkflowDB.Current.AddError("语法错误", this.TokenPair.BeginToken);
                return null;
            }
            T_Type rslt = null;
            var list = new List<T_Type>();
            for (var index = 0; index < this.Relational_Expressions.Count; index++)
            {
                rslt = this.Relational_Expressions[index].Wise(type, region);
                list.Add(rslt);
            }

            if (this.Relational_Expressions.Count > 1)
            {
                if (list[0] != list[1])
                {
                    WorkflowDB.Current.AddError("比较符合两边类型必须相同", this.TokenPair.BeginToken);
                }
                return new T_Boolean();
            }
            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.Shift_Expressions.Count; index++)
            {
                rslt = this.Shift_Expressions[index].Wise(type, region);
            }

            if (this.Shift_Expressions.Count > 1)
                return new T_Boolean();
            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.Additive_Expressions.Count; index++)
            {
                rslt = this.Additive_Expressions[index].Wise(type, region);
            }
            if (this.Additive_Expressions.Count > 1)
                return new T_Boolean();

            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            T_Type rslt = null;
            for (var index = 0; index < this.Multiplicative_Expressions.Count; index++)
            {
                if (index == 0)
                {
                    rslt = this.Multiplicative_Expressions[index].Wise(type, region);
                }
                else
                {
                    var t = this.Multiplicative_Expressions[index].Wise(type, region);
                }
            }
            return rslt;

        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            if (this.Cast_Expressions.Count > 2)
            {
                WorkflowDB.Current.AddError("运算表达式过多", this.TokenPair.BeginToken);
                return null;
            }
            T_Type rslt = null;
            var list = new List<T_Type>();

            for (var index = 0; index < this.Cast_Expressions.Count; index++)
            {
                if (index == 0)
                    rslt = this.Cast_Expressions[index].Wise(type, region);
                else
                    rslt = this.Cast_Expressions[index].Wise(type, region);

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
                        WorkflowDB.Current.AddError(string.Format("只有int,float,decimal能用于{0}运算", this.Operators[0].GetDescription()), this.TokenPair.BeginToken);
                        return null;
                    }
                }
            }

            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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
        public string Text { get; set; }
        public TypeNameInfo(TokenPair token)
        {
            this.TokenPair = token;
        }

    }
    public class Cast_ExpressionInfo
    {
        public TokenPair TokenPair { get; set; }
        public GenericTypeInfo GenericType { get; set; }
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
                builder.Append("(");
                this.GenericType.Render(builder);
                builder.Append(")");
                this.Cast_Expression.Render(builder);
            }
        }

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            T_Type rslt = null;
            if (this.Unary_Expression != null)
            {
                rslt = this.Unary_Expression.Wise(type, region);
            }
            else
            {
                rslt = this.Cast_Expression.Wise(type, region);
            }
            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
        {
            if (this.Unary_Expression != null)
            {
                this.Unary_Expression.RenderView(builder, modelInfo);
            }
            else
            {
                builder.Append("(");
                this.GenericType.Render(builder);
                builder.Append(")");
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

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            if (this.Postfix_Expression != null)
            {
                return this.Postfix_Expression.Wise(region);
            }

            if (this.Unary_Expression_One_Char != null)
                return this.Unary_Expression_One_Char.Wise(type, region);

            if (this.Unary_Expression_Two_Char != null)
                return this.Unary_Expression_Two_Char.Wise(type, region);

            return null;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
        {
            if (this.Postfix_Expression != null)
            {
                this.Postfix_Expression.RenderView(builder, modelInfo);
            }

            if (this.Unary_Expression_One_Char != null)
                this.Unary_Expression_One_Char.RenderView(builder, modelInfo);

            if (this.Unary_Expression_Two_Char != null)
                this.Unary_Expression_Two_Char.RenderView(builder, modelInfo);
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

        internal T_Type Wise(RegionInfo region)
        {
            this.RootType = this.Type = this.Primary_Expression.Wise(null, region);
            var type = this.Type;
            for (var index = 0; index < this.Postfix_Parts.Count; index++)
            {
                if (index < this.Postfix_Parts.Count - 1)
                {
                    var last = this.Postfix_Parts[index + 1];
                    if (last.Postfix_Part_Empty_Function != null)
                    {
                        last.Postfix_Part_Empty_Function.Wise(type, this.Postfix_Parts[index].Postfix_Part_Long_Name.StandartName, region);
                        break;
                    }
                    if (last.Postfix_Part_Function != null)
                    {
                        last.Postfix_Part_Function.Wise(type, this.Postfix_Parts[index].Postfix_Part_Long_Name.StandartName, region);
                        break;
                    }
                }
                type = this.Postfix_Parts[index].Wise(type, region);
            }

            this.Type = type;
            return type;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
        {
            //this.Primary_Expression.RenderView(builder, modelInfo, this.Postfix_Parts.Count > 0);

            //if (this.Postfix_Parts.Count > 0)
            //{
            //    var nextType = this.RootType;
            //    var stack = new List<string>();
            //    Postfix_PartInfo notLongName = null;
            //    for (var index = 0; index < this.Postfix_Parts.Count; index++)
            //    {
            //        var ln = this.Postfix_Parts[index].Postfix_Part_Long_Name;
            //        if (ln == null)
            //        {
            //            notLongName = this.Postfix_Parts[index];
            //            continue;
            //        }
            //        stack.Add(ln.StandartName);
            //    }
            //    //stack.Add(
            //    if (builder.ToString() == modelInfo.Area)
            //        builder.Clear();

            //    if (notLongName == null)
            //    {
            //        if (stack.Count > 1)
            //            this.RootType.RenderView(builder, stack, null, null, null,null,null,null);
            //    }
            //    else
            //    {
            //        T_Type t = this.RootType;
            //        if (stack.Count > 1)
            //        {
            //            t = this.RootType.RenderView(builder, stack.SubList(0, stack.Count - 1), null, null, null, null, null, null);
            //        }
            //        //t.RenderView(builder,stack.SubList(stack.Count-2),nu
            //        notLongName.RenderView(builder, modelInfo, stack[stack.Count - 1], t);
            //    }
            //    //for (var index = 0; index < this.Postfix_Parts.Count; index++)
            //    //{
            //    //    this.Postfix_Parts[index].RenderView(builder, modelInfo);               
            //    //    //nextType.RenderView(builder,stack,
            //    //}
            //}
        }
    }
    public class Primary_ExpressionInfo
    {
        public TokenPair TokenPair { get; set; }
        public String Id { get; set; }
        public ConstantInfo Constant { get; set; }
        public ExpressionInfo Expression { get; set; }
        public CreatorInfo Creator { get; set; }

        public bool IsId { get; set; }
        public bool IsConstant { get; set; }
        public bool IsExpression { get; set; }
        public bool IsCreator { get; set; }

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
            if (this.IsCreator)
                this.Creator.Render(builder);
        }

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            T_Type rslt = null;
            if (this.IsConstant)
                rslt = this.Constant.Wise(region);
            if (this.IsExpression)
                rslt = this.Expression.Wise(type, region);
            if (this.IsId)
            {
                if (this.Id == "$") { }
                //rslt = modelInfo;
                else
                {
                    if (this.Id == "null")
                        return T_Type.Null;

                    var v = region.FindField(this.Id);

                    if (v == null)
                    {
                        WorkflowDB.Current.AddError("没有该变量或者类型" + this.Id, this.TokenPair.BeginToken);
                        return null;
                    }
                    else
                    {
                        rslt = v.TypeInfo;
                    }
                }
            }
            RootType = rslt;
            return rslt;
        }

        //internal void RenderView(IndentStringBuilder builder, ModelInfo modelInfo,bool havePostfix)
        //{
        //    if (this.IsId)
        //    {
        //        if (this.RootType == modelInfo)
        //        {
        //            if (!havePostfix)
        //            {
        //                builder.Append(modelInfo.Area);
        //            }
        //        }
        //        else
        //        {
        //            builder.Append(this.Id);
        //        }
        //    }
        //    if (this.IsConstant)
        //        this.Constant.RenderView(builder, modelInfo);
        //    if (this.IsExpression)
        //        this.Expression.RenderView(builder, modelInfo);

        //}
    }

    public class CreatorInfo
    {
        public GenericTypeInfo GenericType { get; set; }
        public List<AssignmentExpressionInfo> Assignment_expressions { get; set; }
        public CreatorInfo()
        {
            this.Assignment_expressions = new List<AssignmentExpressionInfo>();
        }

        public void Render(IndentStringBuilder builder)
        {
            builder.Append(" new ");
            GenericType.Render(builder);
            builder.Append("(");
            foreach (var exp in this.Assignment_expressions)
            {
                exp.Render(builder);
                if (exp != this.Assignment_expressions[this.Assignment_expressions.Count - 1])
                {
                    builder.Append(",");
                }
            }
            builder.Append(")");
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
        public bool Is_Int { get; set; }


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

        internal T_Type Wise(RegionInfo region)
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
            if (this.Is_Int)
                return T_Type.ParseType("int");
            return null;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            //if (this.Postfix_Part_Empty_Function != null)
            //    return this.Postfix_Part_Empty_Function.Wise(type,modelInfo);

            if (this.Postfix_Part_Long_Name != null)
                return this.Postfix_Part_Long_Name.Wise(type, region);

            if (this.Postfix_Part_Increase != null)
                return this.Postfix_Part_Increase.Wise(type, region);

            if (this.Postfix_Part_Decrease != null)
                return this.Postfix_Part_Decrease.Wise(type, region);

            //if (this.Postfix_Part_Function != null)
            //    return this.Postfix_Part_Function.Wise(type,null, modelInfo);

            if (this.Postfix_Part_Index != null)
                return this.Postfix_Part_Index.Wise(type, null, region);
            return null;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo, string name, T_Type type)
        {
            var stack = new List<string>();
            stack.Add(name);

            if (this.Postfix_Part_Decrease != null)
            {
                //type.RenderView(builder, stack, null, null, null, this.Postfix_Part_Decrease.PostfixPartType, null, null);
            }
            //builder.Append("--");
            if (this.Postfix_Part_Empty_Function != null)
            //builder.Append("()");
            {
                //type.RenderView(builder, stack, null, null, null, this.Postfix_Part_Empty_Function.PostfixPartType, null, null);
            }

            if (this.Postfix_Part_Function != null)
                this.Postfix_Part_Function.RenderView(builder, modelInfo);
            if (this.Postfix_Part_Increase != null)
            {
                //type.RenderView(builder, stack, null, null, null, this.Postfix_Part_Increase.PostfixPartType, null, null);
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

        public ExpressionInfo Expression { get; set; }
        public Postfix_Part_IndexInfo(TokenPair token)
        {
            this.TokenPair = token;
        }
        internal void Render(IndentStringBuilder builder)
        {
            this.Expression.Render(builder);
        }

        internal T_Type Wise(T_Type type, string name, RegionInfo region)
        {
            return this.Expression.Wise(type, region);
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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
            this.PostfixPartType = PostfixPartType.EmptyCall;
        }
        internal T_Type Wise(T_Type type, string name, RegionInfo region)
        {
            var rslt = type.GetMethod(name);
            if (rslt == null)
            {
                WorkflowDB.Current.AddError(string.Format("类型{0}没有该方法{1}", type.Name, name), this.TokenPair.BeginToken);
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
            this.PostfixPartType = PostfixPartType.Call;
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

        internal T_Type Wise(T_Type type, string name, RegionInfo region)
        {
            T_Type rslt = null;
            var paras = new List<T_Type>();
            for (var index = 0; index < this.Assignment_Expressions.Count; index++)
            {
                paras.Add(this.Assignment_Expressions[index].Wise(null, region));
            }

            //根据参数类型列表获取方法的返回类型
            return rslt;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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
            this.PostfixPartType = PostfixPartType.LongName;
            this.TokenPair = token;
        }

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            try
            {
                if (WorkflowDB.Current.InputChar.Line == this.TokenPair.BeginToken.Line &&
                    WorkflowDB.Current.InputChar.CharPositionInLine == this.TokenPair.EndToken.CharPositionInLine + 1)
                {

                }

                var name = this.Text.Replace(".", "");

                var f = type.GetField(name);
                if (f != null)
                    return f.Type;

                var m = type.GetMethod(name);
                if (m != null)
                    return m.Type;

                WorkflowDB.Current.AddError(string.Format("无法识别{0}类型", name), this.TokenPair.EndToken);
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PostfixPartType PostfixPartType { get; set; }
    }

    public class Postfix_Part_IncreaseInfo
    {
        public TokenPair TokenPair { get; set; }
        public PostfixPartType PostfixPartType { get; set; }

        public Postfix_Part_IncreaseInfo(TokenPair token)
        {
            this.PostfixPartType = PostfixPartType.SelfIncrease;
            this.TokenPair = token;
        }

        internal T_Type Wise(T_Type type, RegionInfo region)
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

        internal T_Type Wise(T_Type type, RegionInfo region)
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
            builder.AppendFormat("{0} ", this.Unary_Expression_Operator.GetDescription());
            this.Unary_Expression.Render(builder);
        }

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            return this.Unary_Expression.Wise(type, region);
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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
            builder.AppendFormat("{0} ", this.Unary_Operator.GetDescription());
            this.Cast_Expression.Render(builder);
        }

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            return this.Cast_Expression.Wise(type, region);
        }

        public TokenPair TokenPair { get; set; }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
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
        public ExpressionInfo Expression { get; set; }

        public ExpressionStatementInfo(TokenPair token)
            : base(token)
        {
            //this.AssignmentExpressions = new List<AssignmentExpressionInfo>();
        }

        internal override void Render(IndentStringBuilder builder)
        {
            this.Expression.Render(builder);
            builder.AppendLine(";");
        }

        internal override T_Type Wise(T_Type type, RegionInfo region)
        {
            this.Region.Parent = region;
            return this.Expression.Wise(type, this.Region);
        }
    }

    public class ExpressionInfo
    {
        public List<AssignmentExpressionInfo> AssignmentExpressions { get; set; }

        public ExpressionInfo()
        {
            this.AssignmentExpressions = new List<AssignmentExpressionInfo>();
        }

        public void Render(IndentStringBuilder builder)
        {
            //if (this.Expression != null)
            //    this.Expression.Render(builder);
            //if (this.DeclareStatement != null)
            //    this.DeclareStatement.Render(builder);

            for (var index = 0; index < this.AssignmentExpressions.Count; index++)
            {
                this.AssignmentExpressions[index].Render(builder);
            }
            //builder.Append(";");
        }

        internal T_Type Wise(T_Type type, RegionInfo region)
        {
            //if (this.Expression != null)
            //    return this.Expression.Wise(type,modelInfo);
            //if (this.DeclareStatement != null)
            //    return this.DeclareStatement.Wise(type,modelInfo);
            var temp = type;
            for (var index = 0; index < this.AssignmentExpressions.Count; index++)
            {
                temp = this.AssignmentExpressions[index].Wise(temp, region);
            }
            return temp;
        }

        internal void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
        {
            //if (this.Expression != null)
            //    this.Expression.RenderView(builder, modelInfo);
            //if (this.DeclareStatement != null)
            //    this.DeclareStatement.RenderView(builder, modelInfo);

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

    public class DeclareStatementInfo : StatementInfo
    {

        public DeclareStatementInfo(TokenPair token)
            : base(token)
        {
        }

        internal override void Render(IndentStringBuilder builder)
        {
            base.Render(builder);
        }

        internal override T_Type Wise(T_Type type, RegionInfo region)
        {
            return base.Wise(type, region);
        }
    }

    public class StatementInfo
    {
        ///// <summary>
        ///// 排他，单独存在
        ///// </summary>
        //public ExpressionStatementInfo Expression { get; set; }
        ///// <summary>
        ///// 排他，单独存在
        ///// </summary>
        //public DeclareStatementInfo DeclareStatement { get; set; }
        public RegionInfo Region { get; set; }

        public StatementInfo(TokenPair token)
        {
            this.TokenPair = token;
            this.Region = new RegionInfo();
        }
        internal virtual void Render(IndentStringBuilder builder)
        {
            //if (this.Expression != null)
            //    this.Expression.Render(builder);
            //if (this.DeclareStatement != null)
            //    this.DeclareStatement.Render(builder);
        }

        internal virtual T_Type Wise(T_Type type, RegionInfo region)
        {
            //if (this.Expression != null)
            //    this.Expression.Wise(type ,modelInfo);
            //if (this.DeclareStatement != null)
            //    this.DeclareStatement.Wise(type ,modelInfo);

            return null;
        }

        public TokenPair TokenPair { get; set; }

        internal virtual void RenderView(IndentStringBuilder builder, ClzInfo modelInfo)
        {
            //if (this.Expression != null)
            //    this.Expression.RenderView(builder, modelInfo);
            //if (this.DeclareStatement != null)
            //    this.DeclareStatement.RenderView(builder, modelInfo);
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
    public class FormInfo
    {
        public string Id { get; set; }

        internal void Render(IndentStringBuilder builder)
        {
            builder.AppendFormatLine("form : {0} , {1} ;", this.Id, this.DataId);
        }

        internal void Wise(RegionInfo regionInfo)
        {

        }

        public string DataId { get; set; }

        internal void RenderWF(IndentStringBuilder builder)
        {

        }
    }

    public class ActionInfo
    {
        public TokenPair TokenPair { get; set; }
        public List<StatementInfo> Statements { get; set; }
        public RegionInfo Region { get; set; }
        public ActionInfo()
        {
            this.Statements = new List<StatementInfo>();
            this.Region = new RegionInfo();
        }

        internal virtual void Render(IndentStringBuilder builder)
        {

        }

        internal void Wise(RegionInfo region)
        {
            foreach (var s in this.Statements)
            {
                s.Wise(null, region);
            }
        }

        internal virtual void RenderWF(IndentStringBuilder builder)
        {
        }
    }
    public class BeforeActionInfo : ActionInfo
    {
        internal override void Render(IndentStringBuilder builder)
        {
            builder.IncreaseIndentLine("before :");
            for (var i = 0; i < this.Statements.Count; i++)
            {
                this.Statements[i].Render(builder);
                if (i < this.Statements.Count - 1)
                    builder.AppendLine();
            }
            builder.Decrease();
        }

        internal override void RenderWF(IndentStringBuilder builder)
        {
            builder.AppendLine("public override void BeforeAction()");
            builder.IncreaseIndentLine("{");
            foreach (var s in this.Statements)
            {
                s.Render(builder);
                builder.AppendLine();
            }
            builder.DecreaseIndentLine("}");
        }
    }
    public class AfterActionInfo : ActionInfo
    {
        internal override void Render(IndentStringBuilder builder)
        {
            builder.IncreaseIndentLine("after :");
            for (var i = 0; i < this.Statements.Count; i++)
            {
                this.Statements[i].Render(builder);
                if (i < this.Statements.Count - 1)
                    builder.AppendLine();
            }

            builder.Decrease();
        }

        internal override void RenderWF(IndentStringBuilder builder)
        {
            builder.AppendLine("public override void AfterAction()");
            builder.IncreaseIndentLine("{");
            foreach (var s in this.Statements)
            {
                s.Render(builder);
                builder.AppendLine();
            }
            builder.DecreaseIndentLine("}");
        }
    }
    public class Translation_StatementInfo : StatementInfo
    {
        public ExpressionInfo Expression { get; set; }
        public string Target
        {
            get;
            set;
        }
        public Translation_StatementInfo(TokenPair token)
            : base(token)
        {
        }
        internal override void Render(IndentStringBuilder builder)
        {
            Expression.Render(builder);
            builder.Append(" ==> ");
            builder.Append(Target);
            builder.Append(";");
        }

        internal void Wise(RegionInfo regionInfo)
        {
            var v = this.Expression.Wise(null, regionInfo);
            if (v == null || v != T_Type.Boolean)
            {
                WorkflowDB.Current.AddError("条件必须为bool类型", this.TokenPair.BeginToken);
            }

            var n = regionInfo.FindUnit(this.Target);
            if (n == null)
            {
                WorkflowDB.Current.AddError("节点不存在:" + this.Target, this.TokenPair.EndToken);
            }

        }

        internal void RenderWF(IndentStringBuilder builder)
        {
            builder.Append("if(");
            Expression.Render(builder);
            builder.Append(")");
            builder.IncreaseIndentLine("{");
            builder.AppendFormat("this.Result = \"{0}\";", Target);
            builder.AppendLine();
            builder.DecreaseIndentLine("}");
        }
    }

    public class IfStatementInfo : StatementInfo
    {
        public ExpressionInfo Condition { get; set; }
        public List<StatementInfo> TrueState { get; set; }
        public IfStatementInfo ElseIf { get; set; }
        public List<StatementInfo> ElseState { get; set; }

        public IfStatementInfo(TokenPair token)
            : base(token)
        {
            TrueState = new List<StatementInfo>();
            ElseState = new List<StatementInfo>();
        }

        internal override void Render(IndentStringBuilder builder)
        {
            builder.Append("if (");
            Condition.Render(builder);
            builder.Append(" )");
            builder.AppendLine("{");
            if (this.TrueState != null)
            {
                foreach (var s in this.TrueState)
                    s.Render(builder);
            }
            builder.AppendLine("}");

            if (this.ElseIf != null)
                this.ElseIf.Render(builder);
            //builder.AppendLine("{");
            if (this.ElseState != null)
            {
                foreach (var s in this.ElseState)
                    s.Render(builder);
            }

            //builder.AppendLine("}");
        }

        internal override T_Type Wise(T_Type type, RegionInfo region)
        {
            var t = this.Condition.Wise(null, region);
            if (t != T_Boolean.Boolean)
            {
                WorkflowDB.Current.AddError("表达式必须为bool类型", this.TokenPair.BeginToken);
                return null;
            }
            if (this.TrueState != null)
            {
                foreach (var s in this.TrueState)
                    s.Wise(null, region);
            }
            if (this.ElseIf != null)
                this.ElseIf.Wise(null, region);
            if (this.ElseState != null)
            {
                foreach (var s in this.ElseState)
                    s.Wise(null, region);
            }
            return null;
        }
    }

    public class SwitchStatementInfo : StatementInfo
    {
        public ExpressionInfo Key { get; set; }
        public List<CaseExpressionInfo> CaseExpressions { get; set; }

        public SwitchStatementInfo(TokenPair token)
            : base(token)
        {
            CaseExpressions = new List<CaseExpressionInfo>();
        }

        internal override void Render(IndentStringBuilder builder)
        {
            builder.Append("switch (");
            Key.Render(builder);
            builder.Append(")");

            //builder.AppendLine(":");

            builder.IncreaseIndentLine("{");
            foreach (var exp in this.CaseExpressions)
            {
                exp.Render(builder);
                if (exp != this.CaseExpressions[this.CaseExpressions.Count - 1])
                    builder.AppendLine();
            }
            builder.Decrease("}");
        }

        internal override T_Type Wise(T_Type type, RegionInfo region)
        {
            this.Region.Parent = region;
            var t = this.Key.Wise(null, this.Region);
            //this.Region.Fields.Add(new FieldInfo(this.TokenPair) {
            //     Name = "Swicth_Key" , TypeInfo = t
            //});

            if (this.CaseExpressions != null && this.CaseExpressions.Count > 0)
            {
                foreach (var exp in this.CaseExpressions)
                {
                    exp.Wise(t, this.Region);
                }
            }
            return null;
        }
    }

    public class CaseExpressionInfo
    {
        public Boolean IsDefault { get; set; }
        public ConstantInfo Constant { get; set; }
        public RegionInfo Region { get; set; }
        public List<StatementInfo> Statements { get; set; }
        public Boolean HasBreak { get; set; }
        public TokenPair TokenPair { get; set; }

        public CaseExpressionInfo()
        {
            this.Statements = new List<StatementInfo>();
            this.Region = new RegionInfo("case", false);
        }

        internal void Render(IndentStringBuilder builder)
        {
            if (this.IsDefault)
                builder.IncreaseIndentLine("default :");
            else
            {
                builder.Append("case ");
                Constant.Render(builder);
                builder.IncreaseIndentLine(":");
            }

            foreach (var s in this.Statements)
            {
                s.Render(builder);
                builder.AppendLine();
            }
            builder.Decrease();
        }

        internal void Wise(T_Type type, RegionInfo regionInfo)
        {
            this.Region.Parent = regionInfo;
            if (!this.IsDefault)
            {
                var t = this.Constant.Wise(this.Region);
                if (t != type)
                {
                    WorkflowDB.Current.AddError("常量类型必须为:" + type.Name, this.TokenPair.BeginToken);
                }
            }

            if (this.Statements != null && this.Statements.Count > 0)
            {
                foreach (var s in this.Statements)
                {
                    s.Wise(null, this.Region);
                }
            }
        }
    }

    public class WhileStatementInfo : StatementInfo
    {
        public ExpressionInfo Condition { get; set; }
        public List<StatementInfo> Statements { get; set; }

        public WhileStatementInfo(TokenPair token)
            : base(token)
        {
        }

        internal override void Render(IndentStringBuilder builder)
        {
            builder.Append("while (");
            Condition.Render(builder);
            builder.AppendLine(")");
            builder.IncreaseIndentLine("{");
            foreach (var s in this.Statements)
            {
                s.Render(builder);
                builder.AppendLine();
            }
            builder.DecreaseIndentLine("}");
        }

        internal override T_Type Wise(T_Type type, RegionInfo region)
        {
            this.Region.Parent = region;

            if (this.Condition != null)
            {
                var c = this.Condition.Wise(null, this.Region);
                if (c == null || c != T_Type.Boolean)
                {
                    WorkflowDB.Current.AddError("条件表达式必须为bool类型", this.TokenPair.BeginToken);
                }
            }
            else
            {
                WorkflowDB.Current.AddError("必须有条件", this.TokenPair.BeginToken);
            }

            if (this.Statements != null && this.Statements.Count > 0)
            {
                foreach (var s in this.Statements)
                    s.Wise(null, this.Region);
            }

            return null;
        }
    }

    public class DoWhileStatementInfo : StatementInfo
    {
        public List<StatementInfo> Statements { get; set; }
        public ExpressionInfo Condition { get; set; }

        public DoWhileStatementInfo(TokenPair token)
            : base(token)
        {
        }

        internal override void Render(IndentStringBuilder builder)
        {
            builder.AppendLine("do");
            builder.IncreaseIndentLine("{");
            foreach (var s in this.Statements)
            {
                s.Render(builder);
                builder.AppendLine();
            }
            builder.DecreaseIndentLine("}");
            builder.Append("while(");
            this.Condition.Render(builder);
            builder.Append(");");
        }

        internal override T_Type Wise(T_Type type, RegionInfo region)
        {
            this.Region.Parent = region;

            if (this.Statements != null && this.Statements.Count > 0)
            {
                foreach (var s in this.Statements)
                    s.Wise(null, this.Region);
            }

            if (this.Condition != null)
            {
                var c = this.Condition.Wise(null, this.Region);
                if (c == null || c != T_Type.Boolean)
                {
                    WorkflowDB.Current.AddError("条件表达式必须为bool类型", this.TokenPair.BeginToken);
                }
            }
            else
            {
                WorkflowDB.Current.AddError("必须有条件", this.TokenPair.BeginToken);
            }
            return null;

        }
    }

    public class ForStatementInfo : StatementInfo
    {
        public VariableInfo Declare_statement { get; set; }
        public Logical_Or_ExpressionInfo Logical_or_expression { get; set; }
        public ExpressionInfo Expression { get; set; }
        public List<StatementInfo> Statements { get; set; }

        public ForStatementInfo(TokenPair token)
            : base(token)
        {
            Statements = new List<StatementInfo>();
        }

        internal override void Render(IndentStringBuilder builder)
        {
            builder.Append("for(");
            Declare_statement.Render(builder);
            //builder.Append(";");
            Logical_or_expression.Render(builder);
            builder.Append(";");
            Expression.Render(builder);
            builder.AppendLine(")");
            builder.AppendLine("{");
            builder.Increase();
            foreach (var s in this.Statements)
            {
                s.Render(builder);
            }
            builder.Decrease();
            builder.AppendLine();
            builder.AppendLine("}");
        }

        internal override T_Type Wise(T_Type type, RegionInfo region)
        {
            this.Region.Parent = region;

            if (this.Declare_statement != null)
            {
                this.Declare_statement.Wise(null, this.Region);

                //this.Region.Fields.Add(new FieldInfo(this.Declare_statement.TokenPair)
                //{
                //    Name = this.Declare_statement.Name,
                //    TypeInfo = this.Declare_statement.TypeInfo
                //});
            }

            if (this.Logical_or_expression != null)
                this.Logical_or_expression.Wise(null, this.Region);

            if (this.Expression != null)
                this.Expression.Wise(null, this.Region);

            if (this.Statements != null && this.Statements.Count > 0)
            {
                foreach (var s in this.Statements)
                    s.Wise(null, this.Region);
            }
            return null;
        }
    }

    public class ForEachStatementInfo : StatementInfo
    {
        public GenericTypeInfo GenericType { get; set; }
        public String Var { get; set; }
        public ExpressionInfo InExpression { get; set; }
        public List<StatementInfo> Statements { get; set; }
        public ForEachStatementInfo(TokenPair token)
            : base(token)
        {
            Statements = new List<StatementInfo>();
        }

        internal override void Render(IndentStringBuilder builder)
        {
            builder.Append("foreach(");
            this.GenericType.Render(builder);
            //builder.Append(this.GenericType.);
            builder.Append(" " + this.Var);
            builder.Append(" in ");
            this.InExpression.Render(builder);
            builder.Append(")");
            builder.IncreaseIndentLine("{");
            foreach (var s in this.Statements)
            {
                s.Render(builder);
                builder.AppendLine();
            }
            builder.DecreaseIndentLine("}");
        }

        internal override T_Type Wise(T_Type type, RegionInfo region)
        {
            this.Region.Parent = region;
            //不验证InExpression是否可枚举类型，暂时由编译器验证
            if (this.InExpression != null)
            {
                var temp = this.InExpression.Wise(null, region);
                if (!temp.Enumerable)
                {
                    WorkflowDB.Current.AddError("不能迭代访问类型:" + temp.Name, this.TokenPair.BeginToken);
                }
            }
            var t = T_Type.ParseType(this.GenericType);
            if (t == null)
                WorkflowDB.Current.AddError("没有该类型:" + this.GenericType, this.TokenPair.BeginToken);

            var v = region.FindField(this.Var);
            if (v != null)
            {
                WorkflowDB.Current.AddError("已经声明过变量:" + Var, this.TokenPair.BeginToken);
            }

            if (this.Statements != null && this.Statements.Count > 0)
            {
                foreach (var s in this.Statements)
                    s.Wise(null, this.Region);
            }
            return null;
        }
    }

    public class GotoStatementInfo : StatementInfo
    {
        public String Target { get; set; }

        public GotoStatementInfo(TokenPair token)
            : base(token)
        {
        }

        internal override void Render(IndentStringBuilder builder)
        {
            builder.AppendFormatLine("goto {0};", this.Target);
        }

        internal override T_Type Wise(T_Type type, RegionInfo region)
        {
            return base.Wise(type, region);
        }
    }

    public class BreakStatementInfo : StatementInfo
    {
        public BreakStatementInfo(TokenPair token)
            : base(token)
        {
        }

        internal override void Render(IndentStringBuilder builder)
        {
            builder.Append("break;");
        }

        internal override T_Type Wise(T_Type type, RegionInfo region)
        {
            return base.Wise(type, region);
        }
    }

    public class ContinueStatementInfo : StatementInfo
    {
        public ContinueStatementInfo(TokenPair token)
            : base(token)
        {
        }
        internal override void Render(IndentStringBuilder builder)
        {
            builder.AppendLine("continue;");
        }

        internal override T_Type Wise(T_Type type, RegionInfo region)
        {
            return base.Wise(type, region);
        }
    }

    public class TranslationInfo
    {
        public List<Translation_StatementInfo> Statments { get; set; }
        public TranslationInfo()
        {
            this.Statments = new List<Translation_StatementInfo>();
        }

        internal void Render(IndentStringBuilder builder)
        {
            if (this.Statments.Count > 0)
            {
                builder.IncreaseIndentLine("translation :");
                foreach (var s in this.Statments)
                {
                    s.Render(builder);
                    if (s != this.Statments[this.Statments.Count - 1])
                        builder.AppendLine();
                }
                builder.Decrease();
            }
        }

        internal void Wise(RegionInfo regionInfo)
        {
            foreach (var s in this.Statments)
                s.Wise(regionInfo);
        }

        internal void RenderWF(IndentStringBuilder builder)
        {
            builder.AppendLine("public override void TransitionDefine()");
            builder.IncreaseIndentLine("{");
            foreach (var s in this.Statments)
            {
                //s.RenderWF(builder);
                //if (s != this.Statments[this.Statments.Count - 1])

                builder.AppendFormatLine("this.Cases.Add(\"{0}\", \"{0}\");", s.Target);
            }
            builder.DecreaseIndentLine("}");

            builder.AppendLine("public override void OnTransition()");
            builder.IncreaseIndentLine("{");
            foreach (var s in this.Statments)
            {
                s.RenderWF(builder);
                //if (s != this.Statments[this.Statments.Count - 1])
                builder.AppendLine();
            }
            builder.DecreaseIndentLine("}");
        }
    }

    public class NodeInfo
    {
        public string Name { get; set; }
        public RefWorkflowInfo RefWorkflow { get; set; }
        public VariableDefine Variable { get; set; }
        public InitInfo Init { get; set; }
        public FormInfo Form { get; set; }
        public List<ActionInfo> Actions { get; set; }
        public TranslationInfo Translation { get; set; }
        public RegionInfo Region { get; set; }
        public string FlowName { get; set; }
        public string NameSpace { get; set; }

        public NodeInfo()
        {
            Actions = new List<ActionInfo>();
            this.Region = new RegionInfo();
        }

        public void Parse()
        {

        }

        public void Wise(RegionInfo region, string rootNameSpace, string flowName, string nameSpace, string mapping_nameSpace)
        {
            this.Region.Parent = region;
            this.FlowName = flowName;
            this.NameSpace = nameSpace;
            this.RootNameSpace = rootNameSpace;

            this.Region.Fields.Add(new FieldInfo(null) { TypeInfo = new T_GuidType() { NullAble = !true }, Name = "Id" });
            //this.Region.Fields.Add(new FieldInfo(null) { TypeInfo = new T_GuidType() { NullAble = true }, Name = "InstanceId" });
            this.Region.Fields.Add(new FieldInfo(null) { TypeInfo = new T_GuidType() { NullAble = true }, Name = "NodeStateId" });
            //this.Region.Fields.Add(new FieldInfo(null) { TypeInfo = new T_StringType() { NullAble = true }, Name = "Status" });
            //this.Region.Fields.Add(new FieldInfo(null) { TypeInfo = new T_DateTimeType() { NullAble = true }, Name = "CreateTime" });
            //this.Region.Fields.Add(new FieldInfo(null) { TypeInfo = new T_DateTimeType() { NullAble = true }, Name = "UpdateTime" });   

            if (this.Variable != null)
            {
                this.Region.Clzes.AddRange(this.Variable.Clzes);
                this.Region.Fields.AddRange(this.Variable.Fields);
                //this.Variable.Wise(this.Region,rootNameSpace, nameSpace + "." + this.Name, mapping_nameSpace + "." + this.Name);
                this.Variable.Wise(this.Region, flowName, rootNameSpace, nameSpace, mapping_nameSpace);
            }

            if (this.RefWorkflow != null)
                this.RefWorkflow.Wise(this.FlowName);

            if (this.Init != null)
                this.Init.Wise(this.Region);

            foreach (var action in this.Actions)
            {
                action.Wise(this.Region);
            }

            if (this.Form != null)
                this.Form.Wise(this.Region);

            if (this.Translation != null)
                this.Translation.Wise(this.Region);
        }

        internal void Render(IndentStringBuilder builder)
        {
            builder.IncreaseIndentLine("node " + this.Name + ":");
            if (Variable != null)
            {
                Variable.Render(builder);
            }
            if (this.Init != null)
            {
                builder.Increase();
                this.Init.Render(builder);
                builder.Decrease();
            }
            if (this.Form != null)
            {
                builder.Increase();
                this.Form.Render(builder);
                builder.Decrease();
            }
            if (this.Actions != null && this.Actions.Count > 0)
            {
                builder.IncreaseIndentLine("action :");
                foreach (var action in this.Actions)
                {
                    action.Render(builder);
                }
                builder.Decrease();
            }
            if (this.Translation != null)
            {
                builder.Increase();
                this.Translation.Render(builder);
                builder.Decrease();
            }

            builder.Decrease();
        }

        internal void RenderSql(Stack<string> context, DatabaseType dbType, IndentStringBuilder builder, IndentStringBuilder tailBuilder)
        {
            var tableName = string.Format("WF_{0}_{1}", this.FlowName, this.Name);

            builder.Increase();
            builder.AppendFormatLine("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'U'))", tableName);
            builder.AppendFormatLine("BEGIN");
            builder.AppendFormatLine("\tDROP TABLE dbo.{0}", tableName);
            builder.AppendFormatLine("END");
            builder.AppendLine();

            builder.AppendFormatLine("CREATE TABLE [dbo].{0}(", tableName);

            foreach (var f in this.Region.Fields)
            {
                f.RenderSql(context, dbType, builder, null);
            }

            builder.AppendFormatLine(" CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED ", tableName);
            builder.AppendLine("(");
            builder.AppendLine("	[Id] ASC");
            builder.AppendLine(")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]");
            builder.AppendLine(") ON [PRIMARY]");
            builder.Decrease();
            builder.AppendLine("GO");
            builder.AppendLine();

            context.Push(this.Name);
            this.Variable.RenderSql(context, dbType, builder, tailBuilder);
            context.Pop();
        }

        internal void RegistType(string nameSpace, T_Type flowType)
        {
            this.Variable.Fields.Add(new FieldInfo(null) { Name = "parent", TypeInfo = flowType });
            if (this.Variable != null)
            {
                this.Variable.RegistType(nameSpace);
            }
        }

        internal void RenderWF(IndentStringBuilder builder, IndentStringBuilder createBuilder)
        {
            var node = this.Name;
            createBuilder.AppendFormatLine("var {0} = new {1}(this);", GenHelper.GetVarName(node), node);
            createBuilder.AppendFormatLine("flow.Nodes.Add({0});", GenHelper.GetVarName(node));

            if (this is ParallelInfo)
                builder.AppendFormatLine("public partial class {0} : ParallelActivity<string>", this.Name);
            else
                builder.AppendFormatLine("public partial class {0} : StateActivity<string>", this.Name);

            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("private {0} parent = null;", this.FlowName);
            builder.AppendFormatLine("public {0} Parent", this.FlowName);
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("get");
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("return parent;");
            builder.DecreaseIndentLine("}");
            builder.AppendFormatLine("private set");
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("parent = value;");
            builder.DecreaseIndentLine("}");

            builder.DecreaseIndentLine("}");
            builder.AppendFormatLine("public {0}({1} parent)", this.Name, this.FlowName);
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("this.parent = parent;");
            builder.AppendFormatLine("this.Name = \"{0}\";", this.Name);
            builder.DecreaseIndentLine("}");
            if (this.Variable != null)
                this.Variable.RenderWF(builder);

            this.RenderLoad(builder);
            builder.AppendLine();

            this.RenderPersist(builder);
            builder.AppendLine();

            if (this.Init != null)
                this.Init.RenderWF(builder);

            if (this.Form != null)
                this.Form.RenderWF(builder);

            if (this.Actions != null)
                foreach (var a in this.Actions)
                    a.RenderWF(builder);

            if (this.Translation != null)
                this.Translation.RenderWF(builder);

            builder.AppendLine("public override void OnExecute(WFRuntimeContext context)");
            builder.IncreaseIndentLine("{");

            builder.DecreaseIndentLine("}");

            builder.DecreaseIndentLine("}");
        }

        private void RenderLoad(IndentStringBuilder builder)
        {
            builder.AppendFormatLine("public override void Load()");
            builder.IncreaseIndentLine("{");
            builder.AppendLine("using (var ctx = new FlowConext())");
            builder.IncreaseIndentLine("{");
            var flowName = GenHelper.GetVarName(this.Name);
            builder.AppendFormatLine("var {0} = ctx.{1}Infos.Where(x => x.NodeStateId == this.NodeStateId).FirstOrDefault();", flowName, this.Name);
            builder.AppendFormatLine("if ({0} != null)", flowName);
            builder.IncreaseIndentLine("{");
            foreach (var field in this.Region.Fields)
            {
                if (field.TypeInfo is ClzInfo)
                    continue;

                if (field.Name == "Id" || field.Name == "NodeStateId" || field.Name.Equals("parent", StringComparison.OrdinalIgnoreCase))
                    continue;

                builder.AppendFormatLine("this.{0} = {1}.{0};", field.Name, flowName);
            }

            builder.DecreaseIndentLine("}");
            builder.AppendLine();

            foreach (var field in this.Region.Fields)
            {
                if (field.TypeInfo is ClzInfo)
                {
                    if (field.Name.Equals("parent", StringComparison.OrdinalIgnoreCase))
                        continue;

                    builder.AppendFormatLine(
                        "this.{0} = ctx.{1}s.Where(x => x.NodeStateId == this.NodeStateId).FirstOrDefault();"
                        , field.Name, field.TypeInfo.Name);
                    builder.AppendFormatLine("if ({0} == null)", field.Name);
                    builder.IncreaseIndentLine("{");
                    builder.AppendFormatLine("{0} = new {1}();", field.Name, field.TypeInfo.Name);
                    builder.AppendFormatLine("{0}.Id = Guid.NewGuid();", field.Name);
                    builder.AppendFormatLine("{0}.NodeStateId = this.NodeStateId;", field.Name);

                    builder.DecreaseIndentLine("}");
                }
                else
                    continue;
            }
            //builder.AppendLine("ctx.Commit();");
            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");
        }

        private void RenderPersist(IndentStringBuilder builder)
        {
            builder.AppendLine("public override void Persist()");
            builder.IncreaseIndentLine("{");

            builder.AppendLine("using (var ctx = new FlowConext())");
            builder.IncreaseIndentLine("{");
            var flowName = GenHelper.GetVarName(this.Name);
            builder.AppendFormatLine("var {0} = ctx.{1}Infos.Where(x => x.NodeStateId == this.NodeStateId).FirstOrDefault();", flowName, this.Name);
            builder.AppendFormatLine("if ({0} == null)", flowName);
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("{0} = new {1}Info();", flowName, this.Name);
            builder.AppendFormatLine("{0}.Id = Guid.NewGuid();", flowName);
            builder.AppendFormatLine("{0}.NodeStateId = this.NodeStateId;", flowName);
            builder.AppendFormatLine("ctx.{0}Infos.Add({1});", this.Name, flowName);

            builder.DecreaseIndentLine("}");

            foreach (var field in this.Region.Fields)
            {
                if (field.TypeInfo is ClzInfo)
                    continue;

                if (field.Name == "Id" || field.Name == "NodeStateId" || field.Name.Equals("parent", StringComparison.OrdinalIgnoreCase))
                    continue;

                builder.AppendFormatLine("{0}.{1} = this.{1};", flowName, field.Name);
            }

            builder.AppendLine();


            foreach (var field in this.Region.Fields)
            {
                if (field.TypeInfo is ClzInfo)
                {
                    if (field.Name.Equals("parent", StringComparison.OrdinalIgnoreCase))
                        continue;

                    builder.AppendFormatLine(
                        "var _{0} = ctx.{1}s.Where(x => x.NodeStateId == this.NodeStateId).FirstOrDefault();"
                        , field.Name, field.TypeInfo.Name);
                    builder.AppendFormatLine("if (_{0} == null && {0} != null)", field.Name);
                    builder.IncreaseIndentLine("{");
                    //builder.AppendFormatLine("{0} = new {1}Info();", field.Name, field.TypeInfo.Name);
                    //builder.AppendFormatLine("{0}.Id = Guid.NewGuid();", field.Name);
                    //builder.AppendFormatLine("{0}.InstanceId = this.InstanceId;", field.Name);
                    builder.AppendFormatLine("ctx.{0}s.Add({1});", field.TypeInfo.Name, field.Name);

                    builder.DecreaseIndentLine("}");
                }
                else
                    continue;
            }

            builder.AppendLine("ctx.SaveChanges();");
            builder.AppendLine("ctx.Commit();");
            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");
        }

        internal void RenderModel(IndentStringBuilder builder)
        {
            builder.AppendFormatLine("public class {0}Info", this.Name);
            builder.IncreaseIndentLine("{");
            foreach (var f in this.Region.Fields)
            {
                if (!(f.TypeInfo is ClzInfo))
                {
                    f.RenderModel(builder, false);
                }
            }

            builder.DecreaseIndentLine("}");
            builder.AppendLine();

            //builder.AppendFormatLine("public partial class {0}", this.Name);
            //builder.IncreaseIndentLine("{");
            if (this.Variable != null)
                this.Variable.RenderModel(builder, this);

            //builder.DecreaseIndentLine("}");
        }

        internal void RenderMapping(IndentStringBuilder builder)
        {
            builder.AppendFormatLine("public class {0}InfoMap:EntityTypeConfiguration<{0}Info>", this.Name);
            builder.IncreaseIndentLine("{");
            builder.AppendFormat("public {0}InfoMap()", this.Name);
            builder.IncreaseIndentLine("{");

            builder.AppendLine("// Primary Key");
            builder.AppendLine("HasKey(t => t.Id);");

            builder.AppendFormatLine("ToTable(\"WF_{0}_{1}\");", this.FlowName, this.Name);

            foreach (var f in this.Region.Fields)
            {
                if (!(f.TypeInfo is ClzInfo))
                {
                    builder.AppendLine();
                    f.RenderMapping(builder, false);
                }
            }

            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");

            //builder.AppendFormatLine("public partial class {0}", this.Name);
            //builder.IncreaseIndentLine("{");
            if (this.Variable != null)
                this.Variable.RenderMapping(builder, this);

            //builder.DecreaseIndentLine("}");
        }

        internal void RenderDBContext(IndentStringBuilder builder, IndentStringBuilder onModelCreating)
        {
            builder.AppendFormatLine("public DbSet<{0}Info> {0}Infos", this.Name);
            builder.IncreaseIndentLine("{");
            builder.AppendLine("get");
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("return this.Set<{0}Info>();", this.Name);
            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");

            onModelCreating.AppendFormatLine("modelBuilder.Configurations.Add(new {0}.Mappings.{1}Map());", this.RootNameSpace, this.Name + "Info");

            if (this.Variable != null)
                this.Variable.RenderDBContext(builder, onModelCreating);
        }

        public string RootNameSpace { get; set; }
    }
    public class InitInfo
    {
        public List<StatementInfo> Statements { get; set; }
        public RegionInfo Region { get; set; }
        public InitInfo()
        {
            this.Statements = new List<StatementInfo>();
            this.Region = new RegionInfo("init", false);
        }

        internal void Render(IndentStringBuilder builder)
        {
            builder.IncreaseIndentLine("init:");
            foreach (var s in this.Statements)
            {
                s.Render(builder);
                builder.AppendLine();
            }
            builder.Decrease();
        }

        internal void Wise(RegionInfo region)
        {
            this.Region.Parent = region;
            foreach (var s in this.Statements)
                s.Wise(null, this.Region);
        }

        internal void RenderWF(IndentStringBuilder builder)
        {
            //builder.AppendLine("public override void Init(WFRuntimeContext context)");
            builder.AppendLine("public override void Init()");
            builder.IncreaseIndentLine("{");
            foreach (var s in this.Statements)
            {
                s.Render(builder);
                builder.AppendLine();
            }
            builder.DecreaseIndentLine("}");
        }
    }

    public class ExecuteLineInfo
    {
        public string Name { get; set; }
        public RegionInfo Region { get; set; }

        public List<UnitInfo> Units { get; set; }
        public ExecuteLineInfo()
        {
            this.Region = new RegionInfo("ExecuteLineInfo", false);
            this.Units = new List<UnitInfo>();
        }

        internal void RegistType(string p, ClzInfo clzInfo)
        {
            foreach (var unit in Units)
            {
                unit.RegistType(p, clzInfo);
            }
        }

        internal void Wise(RegionInfo region, string rootNameSpace, string flowName, string nameSpace, string mapping_nameSpace)
        {
            this.Region.Parent = region;

            foreach (var unit in this.Units)
                this.Region.Units.Add(unit);

            foreach (var unit in this.Units)
                unit.Wise(this.Region, rootNameSpace, flowName, nameSpace, mapping_nameSpace);
        }

        internal void RenderWF(IndentStringBuilder builder, IndentStringBuilder createBuilder)
        {
            foreach (var unit in this.Units)
                unit.RenderWF(builder, createBuilder);
        }

        internal void RenderSql(Stack<string> context, DatabaseType dbType, IndentStringBuilder builder, IndentStringBuilder tailBuilder)
        {
            foreach (var unit in this.Units)
                unit.RenderSql(context, dbType, builder, tailBuilder);

        }

        internal void RenderModel(IndentStringBuilder builder)
        {
            foreach (var unit in this.Units)
                unit.RenderModel(builder);
        }

        internal void RenderMapping(IndentStringBuilder builder)
        {
            foreach (var unit in this.Units)
                unit.RenderMapping(builder);
        }

        internal void RenderDBContext(IndentStringBuilder builder, IndentStringBuilder onModelCreating)
        {
            foreach (var unit in this.Units)
                unit.RenderDBContext(builder, onModelCreating);
        }

        internal void Render(IndentStringBuilder builder)
        {
            foreach (var unit in this.Units)
                unit.Render(builder);
        }
    }

    public class ParallelInfo : NodeInfo
    {
        //public RegionInfo Region { get; set; }
        //public string Name { get; set; }
        public List<ExecuteLineInfo> ExecuteLines { get; set; }

        public ParallelInfo()
            : base()
        {
            //this.Region = new RegionInfo();
            this.ExecuteLines = new List<ExecuteLineInfo>();
        }

        internal void RegistType(string p, ClzInfo clzInfo)
        {
            this.Variable.Fields.Add(new FieldInfo(null) { Name = "parent", TypeInfo = clzInfo });

            foreach (var line in this.ExecuteLines)
            {
                line.RegistType(p, clzInfo);
            }
        }

        internal void Wise(RegionInfo region, string rootNameSpace, string flowName, string nameSpace, string mapping_nameSpace)
        {
            this.Region.Parent = region;
            this.FlowName = flowName;
            this.NameSpace = nameSpace;
            this.RootNameSpace = rootNameSpace;

            this.Region.Fields.Add(new FieldInfo(null) { TypeInfo = new T_GuidType() { NullAble = !true }, Name = "Id" });
            this.Region.Fields.Add(new FieldInfo(null) { TypeInfo = new T_GuidType() { NullAble = true }, Name = "NodeStateId" });

            if (this.Variable != null)
            {
                this.Region.Clzes.AddRange(this.Variable.Clzes);
                this.Region.Fields.AddRange(this.Variable.Fields);
                this.Variable.Wise(this.Region, flowName, rootNameSpace, nameSpace, mapping_nameSpace);
            }

            if (this.Init != null)
                this.Init.Wise(this.Region);

            foreach (var action in this.Actions)
            {
                action.Wise(this.Region);
            }

            if (this.Translation != null)
                this.Translation.Wise(this.Region);

            foreach (var line in this.ExecuteLines)
                line.Wise(this.Region, rootNameSpace, flowName, nameSpace, mapping_nameSpace);
        }

        internal void RenderWF(IndentStringBuilder builder, IndentStringBuilder createBuilder)
        {
            base.RenderWF(builder, createBuilder);

            foreach (var line in this.ExecuteLines)
                line.RenderWF(builder, createBuilder);
        }

        internal void RenderSql(Stack<string> context, DatabaseType dbType, IndentStringBuilder builder, IndentStringBuilder tailBuilder)
        {
            base.RenderSql(context, dbType, builder, tailBuilder);

            foreach (var line in this.ExecuteLines)
                line.RenderSql(context, dbType, builder, tailBuilder);
        }

        internal void RenderModel(IndentStringBuilder builder)
        {
            base.RenderModel(builder);

            foreach (var line in this.ExecuteLines)
                line.RenderModel(builder);
        }

        internal void RenderMapping(IndentStringBuilder builder)
        {
            base.RenderMapping(builder);

            foreach (var line in this.ExecuteLines)
                line.RenderMapping(builder);
        }

        internal void RenderDBContext(IndentStringBuilder builder, IndentStringBuilder onModelCreating)
        {
            base.RenderDBContext(builder, onModelCreating);

            foreach (var line in this.ExecuteLines)
                line.RenderDBContext(builder, onModelCreating);
        }

        internal void Render(IndentStringBuilder builder)
        {
            foreach (var line in this.ExecuteLines)
                line.Render(builder);
        }
    }

    public class UnitInfo
    {
        public string Name
        {
            get
            {
                if (this.Node != null)
                    return this.Node.Name;
                if (this.Parallel != null)
                    return this.Parallel.Name;
                return "";
            }
        }
        public RegionInfo Region { get; set; }
        public NodeInfo Node { get; set; }
        public ParallelInfo Parallel { get; set; }
        //public List<> 
        public UnitInfo()
        {
            this.Region = new RegionInfo("UnitInfo", false);
        }

        internal void RegistType(string p, ClzInfo clzInfo)
        {
            if (Node != null)
                Node.RegistType(p, clzInfo);
            if (Parallel != null)
                Parallel.RegistType(p, clzInfo);
        }

        public void Wise(RegionInfo region, string rootNameSpace, string flowName, string nameSpace, string mapping_nameSpace)
        {
            this.Region.Parent = region;

            if (this.Node != null)
                this.Node.Wise(this.Region, rootNameSpace, flowName, nameSpace, mapping_nameSpace);
            if (this.Parallel != null)
                this.Parallel.Wise(this.Region, rootNameSpace, flowName, nameSpace, mapping_nameSpace);
        }

        internal void RenderWF(IndentStringBuilder builder, IndentStringBuilder createBuilder)
        {
            if (this.Node != null)
                this.Node.RenderWF(builder, createBuilder);
            if (this.Parallel != null)
                this.Parallel.RenderWF(builder, createBuilder);
        }

        internal void RenderSql(Stack<string> context, DatabaseType dbType, IndentStringBuilder builder, IndentStringBuilder tailBuilder)
        {
            if (this.Node != null)
                this.Node.RenderSql(context, dbType, builder, tailBuilder);
            if (this.Parallel != null)
                this.Parallel.RenderSql(context, dbType, builder, tailBuilder);
        }


        internal void RenderModel(IndentStringBuilder builder)
        {
            if (this.Node != null)
                this.Node.RenderModel(builder);
            if (this.Parallel != null)
                this.Parallel.RenderModel(builder);
        }

        internal void RenderMapping(IndentStringBuilder builder)
        {
            if (this.Node != null)
                this.Node.RenderMapping(builder);
            if (this.Parallel != null)
                this.Parallel.RenderMapping(builder);
        }

        internal void RenderDBContext(IndentStringBuilder builder, IndentStringBuilder onModelCreating)
        {
            if (this.Node != null)
                this.Node.RenderDBContext(builder, onModelCreating);
            if (this.Parallel != null)
                this.Parallel.RenderDBContext(builder, onModelCreating);
        }

        internal void Render(IndentStringBuilder builder)
        {
            if (this.Node != null)
                this.Node.Render(builder);
            if (this.Parallel != null)
                this.Parallel.Render(builder);
        }
    }

    public class WorkflowInfo
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }

    public delegate WorkflowInfo OnSearchWorkflow(string name);

    public class WorkflowDB : ParseModuleBase
    {
        public Program Program { get; set; }
        public RegionInfo Region { get; set; }

        public VariableDefine Variable { get; set; }
        public InitInfo Init { get; set; }
        public List<UnitInfo> Units { get; set; }
        public ClzInfo TypeInfo { get; set; }
        public static WorkflowDB Current { get; set; }

        public static event OnSearchWorkflow SearchWorkflow;
        static WorkflowDB()
        {
            RefWorkflowInfo.SearchWorkflow += new OnSearchWorkflow(RefWorkflowInfo_SearchWorkflow);
        }

        static WorkflowInfo RefWorkflowInfo_SearchWorkflow(string name)
        {
            if (WorkflowDB.SearchWorkflow != null)
                return WorkflowDB.SearchWorkflow(name);

            return null;
        }

        public WorkflowDB()
        {
            Units = new List<UnitInfo>();
            this.Region = new RegionInfo("Program", true);
            TypeInfo = new ClzInfo();
        }

        public void Parse()
        {
            this.Program.Parse(this);
        }

        public override void Initialize()
        {
            try
            {
                this.Parse();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }
        }

        private void RegistType()
        {
            try
            {
                this.Variable.RegistType(this.NameSpace + ".Models");
                foreach (var node in this.Units)
                {
                    node.RegistType(this.NameSpace + ".Models", this.TypeInfo);
                }
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }
        }

        public override void Wise()
        {
            try
            {
                T_Type.ClearCustomType();
                this.TypeInfo.Name = this.Name;
                this.RegistType();

                TypeInfo.fields.Add(new FieldInfo(null) { TypeInfo = new T_GuidType() { NullAble = !true }, Name = "Id" });
                TypeInfo.fields.Add(new FieldInfo(null) { TypeInfo = new T_GuidType() { NullAble = true }, Name = "InstanceId" });
                TypeInfo.Fields.Add(new T_Field() { Name = "Id", Type = new T_GuidType() { NullAble = !true } });
                TypeInfo.Fields.Add(new T_Field() { Name = "InstanceId", Type = new T_GuidType() { NullAble = true } });
                this.TypeInfo.Name = this.Name + "Info";
                this.TypeInfo.TableName = "WF_" + this.Name;

                //this.Region.Fields.Add(new FieldInfo(null) { TypeInfo = new T_StringType(), Name = "Creator" });
                //this.Region.Fields.Add(new FieldInfo(null) { TypeInfo = new T_StringType(), Name = "Status" });
                //this.Region.Fields.Add(new FieldInfo(null) { TypeInfo = new T_DateTimeType() { NullAble=true }, Name = "CreateTime" });
                //this.Region.Fields.Add(new FieldInfo(null) { TypeInfo = new T_DateTimeType() { NullAble = true }, Name = "UpdateTime" });  

                this.Variable.Wise(this.Region, this.Name, this.NameSpace, this.NameSpace + ".Models", this.NameSpace + ".Mappings");

                this.Variable.Region.Parent = this.Region;
                this.Region.Clzes.AddRange(this.Variable.Clzes);

                this.Region.Fields.AddRange(this.TypeInfo.fields);
                this.Region.Fields.AddRange(this.Variable.Fields);

                this.TypeInfo.fields.Clear();
                this.TypeInfo.fields.AddRange(this.Region.Fields);

                foreach (var f in this.Variable.Fields)
                {
                    TypeInfo.Fields.Add(new T_Field() { Name = f.Name, Type = f.TypeInfo });
                }

                this.Region.Units.AddRange(this.Units);

                if (this.Init != null)
                {
                    this.Init.Region.Parent = this.Region;
                    this.Init.Wise(this.Region);
                }

                foreach (var unit in this.Units)
                {
                    unit.Region.Parent = this.Region;
                    unit.Wise(this.Region, this.NameSpace, this.Name, this.NameSpace + ".Models", this.NameSpace + ".Mappings");
                }
                Dictionary<string, ClzInfo> clzes = new Dictionary<string, ClzInfo>();

                CreateRelation(this.Region, clzes);

                #region 添加关联字段
                foreach (var clz in clzes.Values)
                {
                    foreach (var f in clz.fields)
                    {
                        if (f.TypeInfo is T_ListType)
                        {
                            var listType = f.TypeInfo as T_ListType;
                            if (listType.ItemType is ClzInfo)
                            {
                                if (clzes.ContainsKey(listType.ItemType.FullName))
                                {
                                    ClzInfo itemType = clzes[listType.ItemType.FullName];
                                    if (itemType != null)
                                    {
                                        itemType.fields.Add(new FieldInfo(null) { Name = clz.Name, TypeInfo = clz });
                                    }
                                }
                            }

                            if (clzes.ContainsKey(listType.ItemType.FullName))
                            {
                                var item = clzes[listType.ItemType.FullName];

                                var newf = new FieldInfo(null) { Name = clz.Name + "Id", TypeInfo = T_Type.Guid };
                                newf.TypeInfo.NullAble = true;
                                //item.fields.Add(newf);
                            }
                        }
                    }
                }
                #endregion

                #region 禁止多对多关联
                foreach (var clz in clzes.Values)
                {
                    foreach (var f in clz.fields)
                    {
                        if (f.TypeInfo is T_ListType)
                        {
                            var listType = f.TypeInfo as T_ListType;
                            if (listType.ItemType is ClzInfo)
                            {
                                if (clzes.ContainsKey(listType.ItemType.FullName))
                                {
                                    ClzInfo itemType = clzes[listType.ItemType.FullName];
                                    if (itemType != null)
                                    {
                                        foreach (var f_item in itemType.fields)
                                        {
                                            if (f_item.TypeInfo is T_ListType)
                                            {
                                                var listType2 = f_item.TypeInfo as T_ListType;
                                                if (listType2.ItemType == clz)
                                                {
                                                    WorkflowDB.Current.AddError(
                                                        string.Format("{0},{1}不能发生多对多关系", clz.Name, itemType.Name), clz.TokenPair.BeginToken);
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }
        }

        private void CreateRelation(RegionInfo region, Dictionary<string, ClzInfo> clzes)
        {
            foreach (var clz in region.Clzes)
            {
                clzes.Add(clz.FullName, clz);
            }

            if (region.Units == null || region.Units.Count == 0)
                return;

            foreach (var n in region.Units)
            {
                if (n.Node != null)
                    CreateRelation(n.Node.Region, clzes);
                else if (n.Parallel != null)
                    CreateRelation(n.Parallel.Region, clzes);

            }
        }

        public void Render(IndentStringBuilder builder)
        {
            this.Variable.Render(builder);
            builder.AppendLine();
            this.Init.Render(builder);
            builder.AppendLine();
            foreach (var node in this.Units)
            {
                node.Render(builder);
                builder.AppendLine();
            }
        }

        public void RenderSql(DatabaseType dbType, IndentStringBuilder builder)
        {
            var context = new Stack<string>();
            context.Push("WF");
            context.Push(this.Name);

            builder.Increase();
            var tableName = string.Format("WF_{0}", this.Name);
            builder.AppendFormatLine("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'U'))", tableName);
            builder.AppendFormatLine("BEGIN");
            builder.AppendFormatLine("\tDROP TABLE dbo.{0}", tableName);
            builder.AppendFormatLine("END");
            builder.AppendLine();

            builder.AppendFormatLine("CREATE TABLE [dbo].{0}(", tableName);

            foreach (var f in this.TypeInfo.fields)
            {
                f.RenderSql(context, dbType, builder, null);
            }

            builder.AppendFormatLine(" CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED ", tableName);
            builder.AppendLine("(");
            builder.AppendLine("	[Id] ASC");
            builder.AppendLine(")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]");
            builder.AppendLine(") ON [PRIMARY]");
            builder.Decrease();
            builder.AppendLine("GO");
            builder.AppendLine();

            var tailBuilder = new IndentStringBuilder();

            this.Variable.RenderSql(context, dbType, builder, tailBuilder);

            foreach (var n in this.Units)
                n.RenderSql(context, dbType, builder, tailBuilder);

            builder.AppendLine();
            //builder.Append(tailBuilder.ToString());
        }

        public void RenderWF(IndentStringBuilder builder)
        {
            if (this.Units.Count == 0)
            {
                builder.Append("至少需要有一个节点！");
                return;
            }

            builder.AppendLine(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Workflow.Implements;
using CodeHelper.Workflow.Interfaces;
using CodeHelper.Workflow;");
            builder.AppendFormatLine("using {0}.Data;", this.NameSpace);
            builder.AppendFormatLine("using {0}.Models;", this.NameSpace);
            builder.AppendLine();

            builder.AppendFormatLine("namespace {0}", this.NameSpace);
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("public partial class {0} : FlowContainer", this.Name);
            builder.IncreaseIndentLine("{");
            builder.AppendLine("public override IStatechart GetFlow()");
            builder.IncreaseIndentLine("{");
            builder.AppendLine("var flow = new Statechart();");
            builder.AppendLine();
            //var stateNode = this.Units[0].Name;
            //builder.AppendFormatLine("var {0} = new {1}(this);", GenHelper.GetVarName(stateNode), stateNode);
            //builder.AppendFormatLine("flow.StartNode = {0};", GenHelper.GetVarName(stateNode));
            //builder.AppendFormatLine("flow.Nodes.Add({0});", GenHelper.GetVarName(stateNode));
            var createBuilder = new IndentStringBuilder();
            createBuilder.Increase();
            createBuilder.Increase();
            createBuilder.Increase();
            var nodeBuilder = new IndentStringBuilder();
            nodeBuilder.Increase();
            nodeBuilder.Increase();
            for (var index = 0; index < this.Units.Count; index++)
            {
                //builder.AppendLine();
                //var node = this.Units[index].Name;
                //builder.AppendFormatLine("var {0} = new {1}(this);", GenHelper.GetVarName(node), node);
                //builder.AppendFormatLine("flow.Nodes.Add({0});", GenHelper.GetVarName(node));
                this.Units[index].RenderWF(nodeBuilder, createBuilder);
            }

            builder.AppendLine(createBuilder.ToString().Substring(3));
            var stateNode = this.Units[0].Name;
            builder.AppendFormatLine("flow.StartNode = {0};", GenHelper.GetVarName(stateNode));
            builder.AppendLine();

            builder.AppendFormatLine("foreach (var node in flow.Nodes)");
            builder.IncreaseIndentLine("{");
            builder.AppendLine("var state = node as StateActivity<string>;");
            builder.AppendLine("if (state != null)");
            builder.IncreaseIndentLine("{");
            builder.AppendLine("state.TransitionDefine();");
            builder.AppendLine("state.OnGetActivity += new StateActivity<string>.GetActivity(x => flow.GetActivity(x));");
            builder.AppendLine("state.Persisted += new StateActivity<string>.OnPersisted((x) => this.Persist());");
            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");
            builder.AppendLine("return flow;");
            builder.DecreaseIndentLine("}");

            builder.AppendLine();
            //生成工作流变量
            this.Variable.RenderWF(builder);
            builder.AppendLine();

            this.RenderLoad(builder);

            builder.AppendLine();

            this.RenderPersist(builder);

            builder.AppendLine();

            if (this.Init != null)
                this.Init.RenderWF(builder);

            builder.AppendLine();

            //foreach (var n in this.Units)
            //{
            //    n.RenderWF(builder, createBuilder);
            //    builder.AppendLine();
            //}            
            //生成节点类i    

            builder.AppendLine(nodeBuilder.ToString().Substring(2));
            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");
        }

        private void RenderLoad(IndentStringBuilder builder)
        {
            builder.AppendFormatLine("protected override void Load()");
            builder.IncreaseIndentLine("{");
            builder.AppendLine("using (var ctx = new FlowConext())");
            builder.IncreaseIndentLine("{");
            var flowName = GenHelper.GetVarName(this.Name);
            builder.AppendFormatLine("var {0} = ctx.{1}Infos.Where(x => x.InstanceId == this.InstanceId).FirstOrDefault();", flowName, this.Name);
            builder.AppendFormatLine("if ({0} != null)", flowName);
            builder.IncreaseIndentLine("{");
            //builder.AppendFormatLine("{0} = new {1}Info();",flowName,this.Name);
            //builder.AppendFormatLine("{0}.Id = Guid.NewGuid();",flowName);
            //builder.AppendFormatLine("{0}.InstanceId = this.InstanceId;",flowName);
            ////builder.AppendFormatLine("ctx.{0}Infos.Add({1});",this.Name,flowName);

            //builder.DecreaseIndentLine("}");
            //builder.AppendFormatLine("else");
            //builder.IncreaseIndentLine("{");
            foreach (var field in this.Region.Fields)
            {
                if (field.TypeInfo is ClzInfo)
                    continue;

                if (field.Name == "Id" || field.Name == "InstanceId")
                    continue;

                builder.AppendFormatLine("this.{0} = {1}.{0};", field.Name, flowName);
            }

            builder.DecreaseIndentLine("}");
            builder.AppendLine();

            foreach (var field in this.Region.Fields)
            {
                if (field.TypeInfo is ClzInfo)
                {
                    builder.AppendFormatLine(
                        "this.{0} = ctx.{1}s.Where(x => x.InstanceId == this.InstanceId).FirstOrDefault();"
                        , field.Name, field.TypeInfo.Name);
                    builder.AppendFormatLine("if ({0} == null)", field.Name);
                    builder.IncreaseIndentLine("{");
                    builder.AppendFormatLine("{0} = new {1}();", field.Name, field.TypeInfo.Name);
                    builder.AppendFormatLine("{0}.Id = Guid.NewGuid();", field.Name);
                    builder.AppendFormatLine("{0}.InstanceId = this.InstanceId;", field.Name);
                    //builder.AppendFormatLine("ctx.{0}Infos.Add({1});", field.TypeInfo.Name, field.Name);

                    builder.DecreaseIndentLine("}");
                }
                else
                    continue;
            }
            //builder.AppendLine("ctx.Commit();");
            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");
        }

        private void RenderPersist(IndentStringBuilder builder)
        {
            builder.AppendLine("protected override void Persist()");
            builder.IncreaseIndentLine("{");

            builder.AppendLine("using (var ctx = new FlowConext())");
            builder.IncreaseIndentLine("{");
            var flowName = GenHelper.GetVarName(this.Name);
            builder.AppendFormatLine("var {0} = ctx.{1}Infos.Where(x => x.InstanceId == this.InstanceId).FirstOrDefault();", flowName, this.Name);
            builder.AppendFormatLine("if ({0} == null)", flowName);
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("{0} = new {1}Info();", flowName, this.Name);
            builder.AppendFormatLine("{0}.Id = Guid.NewGuid();", flowName);
            builder.AppendFormatLine("{0}.InstanceId = this.InstanceId;", flowName);
            builder.AppendFormatLine("ctx.{0}Infos.Add({1});", this.Name, flowName);

            builder.DecreaseIndentLine("}");

            foreach (var field in this.Region.Fields)
            {
                if (field.TypeInfo is ClzInfo)
                    continue;

                if (field.Name == "Id" || field.Name == "InstanceId")
                    continue;

                builder.AppendFormatLine("{0}.{1} = this.{1};", flowName, field.Name);
            }

            builder.AppendLine();


            foreach (var field in this.Region.Fields)
            {
                if (field.TypeInfo is ClzInfo)
                {
                    builder.AppendFormatLine(
                        "var _{0} = ctx.{1}s.Where(x => x.InstanceId == this.InstanceId).FirstOrDefault();"
                        , field.Name, field.TypeInfo.Name);
                    builder.AppendFormatLine("if (_{0} == null && {0} != null)", field.Name);
                    builder.IncreaseIndentLine("{");
                    //builder.AppendFormatLine("{0} = new {1}Info();", field.Name, field.TypeInfo.Name);
                    //builder.AppendFormatLine("{0}.Id = Guid.NewGuid();", field.Name);
                    //builder.AppendFormatLine("{0}.InstanceId = this.InstanceId;", field.Name);
                    builder.AppendFormatLine("ctx.{0}s.Add({1});", field.TypeInfo.Name, field.Name);

                    builder.DecreaseIndentLine("}");
                }
                else
                    continue;
            }

            builder.AppendLine("ctx.SaveChanges();");
            builder.AppendLine("ctx.Commit();");
            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");
        }

        public void RenderModel(IndentStringBuilder builder)
        {
            if (this.Units.Count == 0)
            {
                builder.Append("至少需要有一个节点！");
                return;
            }
            builder.AppendLine(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;");
            builder.AppendLine();
            builder.AppendFormatLine("namespace {0}.Models", this.NameSpace);
            builder.IncreaseIndentLine("{");

            //builder.AppendFormatLine("public partial class {0}", this.Name);
            //builder.IncreaseIndentLine("{");

            builder.AppendLine();
            //生成流程类
            builder.AppendFormatLine("public class {0}Info", this.Name);
            builder.IncreaseIndentLine("{");
            foreach (var f in this.Region.Fields)
            {
                if (!(f.TypeInfo is ClzInfo))
                {
                    f.RenderModel(builder, false);
                }
                else
                {
                    f.RenderModel(builder, true);
                }
            }

            builder.DecreaseIndentLine("}");
            builder.AppendLine();

            //生成工作流变量
            this.Variable.RenderModel(builder, null);
            builder.AppendLine();

            foreach (var n in this.Units)
            {
                n.RenderModel(builder);
                builder.AppendLine();
            }

            //生成节点类
            builder.DecreaseIndentLine("}");
            //builder.DecreaseIndentLine("}");
        }

        public void RenderMapping(IndentStringBuilder builder)
        {
            if (this.Units.Count == 0)
            {
                builder.Append("至少需要有一个节点！");
                return;
            }

            builder.AppendLine(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;");
            builder.AppendFormatLine("using {0}.Models;", this.NameSpace);
            builder.AppendLine();
            builder.AppendFormatLine("namespace {0}.Mappings", this.NameSpace);
            builder.IncreaseIndentLine("{");

            this.TypeInfo.RenderMapping(builder, null);
            /*
           builder.AppendFormatLine("public class {0}InfoMap:EntityTypeConfiguration<{0}Info>", this.Name);
           builder.IncreaseIndentLine("{");            
           builder.AppendFormat("public {0}InfoMap()",this.Name);
           builder.IncreaseIndentLine("{");
           builder.AppendLine("// Primary Key");
           builder.AppendLine("HasKey(t => t.Id);");

           builder.AppendFormatLine("ToTable(\"WF_{0}\");",this.Name);

           foreach (var f in this.Region.Fields)
           {
               if (!(f.TypeInfo is ClzInfo))
               {
                   builder.AppendLine();
                   f.RenderMapping(builder, false);
               }
               else
               {
                   f.RenderMapping(builder, true);
               }
           }     
           builder.DecreaseIndentLine("}");
           builder.DecreaseIndentLine("}");
           builder.AppendLine();
             */

            //生成工作流变量
            this.Variable.RenderMapping(builder, null);
            builder.AppendLine();

            foreach (var n in this.Units)
            {
                n.RenderMapping(builder);
                builder.AppendLine();
            }

            //生成节点类
            builder.DecreaseIndentLine("}");
            //builder.DecreaseIndentLine("}");
        }

        public void RenderDBContext(IndentStringBuilder builder)
        {
            if (this.Units.Count == 0)
            {
                builder.Append("至少需要有一个节点！");
                return;
            }
            builder.AppendLine(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity;
using System.Data.Entity.Validation;
using CodeHelper.Domain;");
            builder.AppendFormatLine("using {0}.Models;", this.NameSpace);
            builder.AppendLine();
            builder.AppendFormatLine("namespace {0}.Data", this.NameSpace);
            builder.IncreaseIndentLine("{");

            builder.AppendFormatLine("public partial class {0}: DbContext,IDisposable", "FlowConext");
            builder.IncreaseIndentLine("{");

            builder.AppendLine(@"static FlowConext()
        {
            Database.SetInitializer<FlowConext>(null);
        }");
            builder.AppendLine();

            builder.AppendLine(@" public FlowConext()
            :base()
        {            
            
            string connectionString = Configer.WFConnectionString;
            this.Database.Connection.ConnectionString = connectionString;            
        }");

            IndentStringBuilder onModelCreating = new IndentStringBuilder();

            builder.AppendFormatLine("public DbSet<{0}Info> {0}Infos", this.Name);
            builder.IncreaseIndentLine("{");
            builder.AppendLine("get");
            builder.IncreaseIndentLine("{");
            builder.AppendFormatLine("return this.Set<{0}Info>();", this.Name);
            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");

            onModelCreating.AppendFormatLine("modelBuilder.Configurations.Add(new {0}.Mappings.{1}Map());", this.NameSpace, this.Name + "Info");

            //生成工作流变量
            this.Variable.RenderDBContext(builder, onModelCreating);
            builder.AppendLine();

            foreach (var n in this.Units)
            {
                n.RenderDBContext(builder, onModelCreating);
                builder.AppendLine();
            }

            builder.AppendLine("protected override void OnModelCreating(DbModelBuilder modelBuilder)");
            builder.IncreaseIndentLine("{");

            StringReader reader = new StringReader(onModelCreating.ToString());
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                builder.AppendLine(line);
            }

            builder.DecreaseIndentLine("}");

            builder.AppendLine(@"public void Commit()
        {
            try
            {
                this.SaveChanges();              
            }
            catch (DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
        }

        public void RollbackChanges()
        {
            // set all entities in change tracker 
            // as 'unchanged state'
            ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = System.Data.EntityState.Unchanged);
        }");
            builder.DecreaseIndentLine("}");
            builder.DecreaseIndentLine("}");
        }
    }
}