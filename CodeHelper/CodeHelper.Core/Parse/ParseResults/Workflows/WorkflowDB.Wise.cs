using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Common.Extensions;

namespace CodeHelper.Core.Parse.ParseResults.Workflows
{    

    public class T_Type
    {
        //public static T_Type Col
        //public enum PrimitiveType
        //{
        //    String,Int
        //}
        static T_Type()
        {
            //T_Type.Boolean = new T_Boolean();
            //T_Type.Int = new T_IntType();
            //T_Type.Float = new T_FloatType();
            //T_Type.Decimal = new T_DecimalType();
            //T_Type.DateTime = new T_DateTimeType();
            //T_Type.String = new T_StringType();
            //T_Type.Null = new T_NullType();
            //T_Type.Guid = new T_GuidType();

            Types.Add("string", new T_StringType());
            Types.Add("int", new T_IntType());
            Types.Add("int?", new T_IntType());
            Types["int?"].NullAble = true;

            Types.Add("int32", new T_IntType());
            Types.Add("int32?", new T_IntType());
            Types["int32?"].NullAble = true;

            Types.Add("float", new T_FloatType());
            Types.Add("float?", new T_FloatType());
            Types["float?"].NullAble = true;

            Types.Add("decimal", new T_DecimalType());
            Types.Add("decimal?", new T_DecimalType());
            Types["decimal?"].NullAble = true;

            Types.Add("bool", new T_Boolean());
            Types.Add("bool?", new T_Boolean());
            Types["bool?"].NullAble = true;

            Types.Add("datetime", new T_DateTimeType());
            Types.Add("datetime?", new T_DateTimeType());
            Types["datetime?"].NullAble = true;

            Types.Add("guid", new T_GuidType());
            Types.Add("guid?", new T_GuidType());
            Types["guid?"].NullAble = true;

            Types.Add("null", T_Type.Null);
        }

        public static T_Boolean Boolean { get { return new T_Boolean(); } }
        public static T_IntType Int { get { return new T_IntType(); } }
        public static T_FloatType Float { get { return new T_FloatType(); } }
        public static T_DecimalType Decimal { get { return new T_DecimalType(); } }
        public static T_DateTimeType DateTime { get { return new T_DateTimeType(); } }
        public static T_StringType String { get { return new T_StringType(); } }
        public static T_NullType Null { get { return new T_NullType(); } }
        public static T_GuidType Guid { get { return new T_GuidType(); } }

        private static Dictionary<string, T_Type> Types = new Dictionary<string, T_Type>();

        public static void Regist(T_Type type)
        {
            if (!Types.ContainsKey(type.Name))
            {
                Types.Add(type.Name, type);
            }
        }

        public static void ClearCustomType()
        {
            var keys = new List<string>();
            foreach(var kv in Types)
            {
                if (kv.Value is ClzInfo)
                    keys.Add(kv.Key);
            }

            foreach (var k in keys)
                Types.Remove(k);
        }

        public static T_Type ParseType(GenericTypeInfo type)
        {
            if (!string.IsNullOrWhiteSpace(type.Long_Name))
            {
                return ParseType(type.Long_Name);
            }

            #region List
            if (type.Header.Long_Name == "List")
            {
                if(type.Parameters.Count != 1)
                {
                   return null;
                }
                var para = ParseType(type.Parameters[0]);
                if(para == null)
                    return null;

                return new T_ListType(para);
            }
            #endregion

            #region Dictionary
            if (type.Header.Long_Name == "Dictionary")
            {
                if (type.Parameters.Count != 2)
                {
                    return null;
                }
                var key = ParseType(type.Parameters[0]);
                if (key == null)
                    return null;

                var value = ParseType(type.Parameters[0]);
                if (value == null)
                    return null;

                return new T_DictionaryType(key, value);
            }
            #endregion

            return null;
        }

        public static T_Type ParseType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return null;
            }

            foreach (var key in Types.Keys )
            {
                if (key.Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    return Types[key];
                }
            }

            var name = type.ToLower();
            if (type.EndsWith("?"))
                name = name.Substring(0, name.Length-1);
            
            if (Types.ContainsKey(name))
            {
                var t = Types[name];

                if (type.EndsWith("?"))
                {
                    t.NullAble = true;
                }

                return t;
            }
            
            return null;
        }

        public bool IsInstance { get; set; }

        public bool NullAble { get; set; }

        public bool Enumerable { get; set; }

        public string Name { get; set; }

        string nameSpace = null;
        public string NameSpace
        {
            get {
                return nameSpace;
            }
            set
            {
                nameSpace = value;
                if (value.StartsWith("TestWF.TestWF"))
                {

                }
            }
        }

        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(NameSpace))
                {
                    return Name;
                }

                return this.NameSpace + "." + Name;

            }
        }

        public virtual T_Field GetField(string name)
        {
            if (this.IsInstance)
            {
                foreach (var f in this.Fields)
                {
                    if (f.Name.Equals(name))
                        return f;
                }
            }
            else
            {
                foreach (var f in this.Static_Fields)
                {
                    if (f.Name.Equals(name))
                        return f;
                }
            }

            return null;
        }

        public List<T_Field> Fields { get; set; }

        public List<T_Field> Static_Fields { get; set; }

        public List<T_Method> Static_Methods { get; set; }

        public T_Method GetMethod(string name)
        {
            if (this.IsInstance)
            {
                foreach (var m in this.Methods)
                {
                    if (m.Name.Equals(name))
                        return m;
                }
            }
            else
            {
                foreach (var m in this.Static_Methods)
                {
                    if (m.Name.Equals(name))
                        return m;
                }
            }
            return null;
        }

        public List<T_Method> Methods { get; set; }

        public virtual T_Type ChangeType(T_Type to)
        {
            if (to.Name == this.Name)
                return this;

            return null;
        }

        public virtual Object Default { get; set; }

        public virtual bool CanChangeType(T_Type to)
        {
            if (this.Name == to.Name)
                return true;

            return false;
        }

        internal T_Type()
        {
            this.IsInstance = true;
            this.Fields = new List<T_Field>();
            this.Methods = new List<T_Method>();
            this.Static_Fields = new List<T_Field>();
            this.Static_Methods = new List<T_Method>();
        }

        public static bool operator == ( T_Type x ,T_Type y)
        {
            //11:无法正常比较
            try
            {
                // If both are null, or both are same instance, return true.
                if (System.Object.ReferenceEquals(x, y))
                {
                    return true;
                }

                // If one is null, but not both, return false.
                if (((object)x == null) || ((object)y == null))
                {
                    return false;
                }

                if (x.NullAble && y is T_NullType)
                    return true;
                if (y.NullAble && x is T_NullType)
                    return true;

                return x.Name == y.Name;
            }
            catch
            {
                return false;
            }
        }

        public static bool operator !=(T_Type x, T_Type y)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(x, y))
            {
                return false;
            }

            // If one is null, but not both, return false.
            if (((object)x == null) || ((object)y == null))
            {
                return true;
            }

            if (x.NullAble && y is T_NullType)
                return false;
            if (y.NullAble && x is T_NullType)
                return false;

            return x.Name != y.Name;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            T_Type p = obj as T_Type;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return this.Name == p.Name;
        }

        public bool Equals(T_Type p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return this.Name == p.Name;
        }

        public virtual T_Type RenderView(StringBuilder builder, List<string> call_stack, StringBuilder paras,AssignOperatorInfo? op, StringBuilder opValue,
            PostfixPartType? postfixPartType, StringBuilder func_paras, StringBuilder index_para)
        {
            //if(call_stack == null)

            var member = call_stack[0];
            AssignOperatorInfo? op2 = null;
            StringBuilder opValue2 = null;
            if (call_stack.Count == 1)
            {
                op2 = op;
                opValue2 = opValue;
            }
            
            T_Type nextType = null;
            if (!this.IsInstance)
            {
                foreach (var f in this.Static_Fields)
                {
                    if (f.Name == member)
                    {
                        this.RenderView(builder, f, op2, opValue2);
                        nextType = f.Type;
                        break;
                    }
                }
                if (nextType == null)
                {
                    foreach (var m in this.Static_Methods)
                    {
                        if (m.Name == member)
                        {
                            this.RenderView(builder, m, paras);
                            nextType = m.Type;
                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (var f in this.Fields)
                {
                    if (f.Name == member)
                    {
                        this.RenderView(builder, f, op2, opValue2);
                        nextType = f.Type;
                        break;
                    }
                }
                if (nextType == null)
                {
                    foreach (var m in this.Methods)
                    {
                        if (m.Name == member)
                        {
                            this.RenderView(builder, m, paras);
                            nextType = m.Type;
                            break;
                        }
                    }
                }
            }
            if (call_stack.Count > 1)
            {
                //var call_stack2 = new List<string>();
                //call_stack2.AddRange(call_stack);
                //call_stack2.RemoveAt(0);
                return nextType.RenderView(builder, call_stack.SubList(1), paras, op, opValue, postfixPartType, func_paras, index_para);
            }

            return nextType;
        }

        protected virtual void RenderView(StringBuilder builder, T_Method m, StringBuilder paras)
        {
            var p = "";
            if (paras != null) p = paras.ToString();

            builder.AppendFormat(".{0}({1})", m.Name, p);
        }

        protected virtual void RenderView(StringBuilder builder, T_Field f,AssignOperatorInfo?  op, StringBuilder rightBuilder)
        {            
            var p = "";
            if (rightBuilder != null) p = rightBuilder.ToString();

            //builder.AppendFormat(".{0}({1})", f.Name, p);

            builder.AppendFormat(".{0}", f.Name);
            
            if (op.HasValue)
            {
                builder.AppendFormat("{0}{1}",op.Value.GetDescription(),rightBuilder.ToString());
            }
        }

    }

    /// <summary>
    /// 自定义类型（非泛型）
    /// </summary>
    public class T_CustomType : T_Type
    {
    }

    public class T_NullType : T_Type
    {
    }

    public class T_DictionaryType : T_Type
    {
        public T_Type KeyType { get; set; }
        public T_Type ValueType { get; set; }
        public T_DictionaryType(T_Type key, T_Type value)
        {
            this.KeyType = key;
            this.ValueType = value;
            this.NullAble = true;
            this.Enumerable = true;
        }
    }

    public class T_Field
    {
        public string Name { get; set; }
        public T_Type Type { get; set; }
        internal T_Field()
        {
        }
    }

    public class T_Method
    {
        public string Name { get; set; }
        public T_Type Type { get; set; }
        public List<T_Parameter> Parameters { get; set; }
        internal T_Method()
        {
        }
    }

    public class T_Parameter
    {
        public string Name { get; set; }
        public T_Type Type { get; set; }

        internal T_Parameter()
        {
        }
    }

    public class T_StringType : T_Type
    {
        internal T_StringType()
            : base()
        {
            this.Name = "string";
            this.NullAble = true;
            this.Fields.Add(new T_Field() { Name = "Length", Type = new T_IntType() });
        }

        public override object Default
        {
            get
            {
                return null;
            }
            set
            {
                base.Default = value;
            }
        }
    }

    public class T_IntType : T_Type
    {
        internal T_IntType()
            : base()
        {
            this.Methods.Add(new T_Method() { Name = "" });
            this.Name = "int";
        }

        public override bool CanChangeType(T_Type to)
        {
            return base.CanChangeType(to);
        }
    }

    public class T_GuidType : T_Type
    {
        public T_GuidType()
            : base()
        {
            this.Name = "Guid";
        }
    }

    public class T_Boolean : T_Type
    {
        public T_Boolean():base()
        {
            this.Name = "bool";
        }
    }

    //public class T_Boolean_NullAble : T_Boolean
    //{
    //    public T_Boolean_NullAble()
    //        : base()
    //    {
    //        this.Name = "bool";
    //    }
    //}

    public class T_CharType : T_Type
    {
        public T_CharType()
            : base()
        {
            this.Name = "char";
        }
    }
    public class T_DecimalType : T_Type
    {
        public T_DecimalType()
            : base()
        {
            this.Name = "decimal";
        }
    }
    public class T_HexType : T_Type
    {
        public T_HexType()
            : base()
        {
            this.Name = "hex";
        }
    }
    public class T_OctalType : T_Type
    {
        public T_OctalType()
            : base()
        {
            this.Name = "octal";
        }
    }
    public class T_FloatType : T_Type
    {
        public T_FloatType()
            : base()
        {
            this.Name = "float";
        }
    }
    public class T_DoubleType : T_Type
    {
        public T_DoubleType()
            : base()
        {
            this.Name = "double";
        }
    }

    public class T_DateTimeType : T_Type
    {
        internal T_DateTimeType()
            : base()
        {
            this.Name = "DateTime";
            this.Static_Methods.Add(new T_Method() { Name="Now", Parameters=new List<T_Parameter>(), Type= this });
        }
    }

    public class T_ListType : T_Type
    {
        public T_Type ItemType { get; set; }

        //public T_Type Index(int index) 

        internal T_ListType(T_Type valueType)
            : base()
        {
            this.ItemType = valueType;
            this.Name = string.Format("List<{0}>",valueType.Name);
            var get = new T_Method() { Name = "Get", Type = ItemType};
            //get.Parameters.Add(new T_Parameter(){ Name});                        
            this.Methods.Add(get);
            this.NullAble = true;
            this.Enumerable = true;
        }
    }
    public class T_ValidateType : T_Type
    {
        protected T_Field IsInt { get; set; }
        protected T_Field IsFloat { get; set; }
        protected T_Field IsEmail { get; set; }
        protected T_Field Regex { get; set; }
        protected T_Field SameTo { get; set; }
        protected T_Field Required { get; set; }
        protected T_Field Max { get; set; }
        protected T_Field Min { get; set; }
        protected T_Field MaxLength { get; set; }
        protected T_Field MinLength { get; set; }

        public T_ValidateType():base()
        {
            this.IsEmail = new T_Field() { Name = "IsEmail" , Type= T_Type.Boolean };
            this.IsInt = new T_Field() { Name = "IsInt", Type = T_Type.Boolean };
            this.IsFloat = new T_Field() { Name = "IsFloat", Type = T_Type.Boolean };
            this.Regex = new T_Field() { Name = "Regex", Type = T_Type.String };
            this.Required = new T_Field() { Name = "Required", Type = T_Type.Boolean };

            this.SameTo = new T_Field() { Name = "SameTo", Type = T_Type.String };
            this.Max = new T_Field() { Name = "Max", Type = T_Type.Float };
            this.Min = new T_Field() { Name = "Min", Type = T_Type.Float };
            this.MaxLength = new T_Field() { Name = "MaxLength", Type = T_Type.Int };
            this.MinLength = new T_Field() { Name = "MinLength", Type = T_Type.Int };

            this.Fields.Add(this.IsEmail);
            this.Fields.Add(this.IsInt);
            this.Fields.Add(this.IsFloat);
            this.Fields.Add(this.Regex);
            this.Fields.Add(this.Required);

            this.Fields.Add(this.SameTo);
            this.Fields.Add(this.Max);
            this.Fields.Add(this.Min);
            this.Fields.Add(this.MaxLength);
            this.Fields.Add(this.MinLength);
        }

        protected override void RenderView(StringBuilder builder, T_Field f, AssignOperatorInfo? op, StringBuilder opValue)
        {
            if (op.HasValue)
            {
                builder.AppendFormat(".{0} {1} {2}",f.Name, op.GetDescription(), opValue);
            }
            else
            {
                builder.AppendFormat(".{0}", f.Name);
            }
        }
    }

    public class T_InputType : T_Type
    {
        protected T_Field Value { get; set; }
        protected T_Field Visible { get; set; }
        protected T_Field Enabled { get; set; }
        protected T_Field Changed { get; set; }
        protected T_Field Validation { get; set; }
        
        public T_InputType(T_Type valueType)
        {
            var type = "unknown";
            if (valueType != null)
                type = valueType.Name;

            this.Name = string.Format("Input<{0}>", type);

            this.Value = new T_Field() { Name = "Value", Type = valueType };
            this.Visible = new T_Field() { Name = "Visible", Type = T_Type.Boolean };
            this.Enabled = new T_Field() { Name = "Enabled", Type = T_Type.Boolean };
            this.Changed = new T_Field() { Name = "Changed", Type = new T_EventType("Changed") };
            this.Validation = new T_Field() {Name="Validation",Type = new T_ValidateType() };

            this.Fields.Add(this.Visible);
            this.Fields.Add(this.Value);
            this.Fields.Add(this.Enabled);
            this.Fields.Add(this.Changed);
            this.Fields.Add(this.Validation);

            this.Methods.Add(new T_Method() { Name = "Value", Type = valueType });
            this.Methods.Add(new T_Method() { Name = "Visible", Type = T_Type.Boolean });
            this.Methods.Add(new T_Method() { Name = "Enabled", Type = T_Type.Boolean });

        }

        protected override void RenderView(StringBuilder builder, T_Field f,AssignOperatorInfo? op, StringBuilder opValue)
        {
            //base.RenderView(builder, f, rightBuilder);
            if (opValue != null && opValue.Length > 0)
            {
                builder.AppendFormat(".{0}({1})",f.Name, opValue.ToString());
            }
            else
            {
                if (f.Type is T_EventType)
                {
                    builder.AppendFormat(".{0}", f.Name);
                }
                else if (f.Type is T_ValidateType)
                {
                    builder.AppendFormat(".{0}", f.Name);
                }
                else
                {
                    builder.AppendFormat(".{0}()", f.Name);
                }
            }
        }

        public override T_Field GetField(string name)
        {
            var m = this.GetMethod(name);
            if (m != null)
                return new T_Field() { Name=name, Type = m.Type };

            return base.GetField(name);
        }
    }

    //public class T_EventField:T_Field{
        
    //}

    public class T_EventType : T_Type
    {
        public static string Event_Changed = "Changed";
        public string EventName = "";

        public T_EventType(string name):base()
        {
            EventName = name;
            this.Name = string.Format("Event[{0}]",name);
        }
    }
}
