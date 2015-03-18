using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Services;
using CodeHelper.Core.Types;
using CodeHelper.Core.Parse.ParseResults.DataModels;

namespace CodeHelper.Core.Parse.ParseResults
{
    public class TypeInfoBase :TokenPair, ITypeInfo, IGeneratorUtil
    {
        public List<AttributeInfo> Attributes { get; set; }

        public TypeInfoBase()
        {
            TypeInfos = new List<ITypeInfo>();
            PropertyInfos = new List<IPropertyInfo>();
            Attributes = new List<AttributeInfo>();
        }

        public string VariableName
        {
            get {
                if (string.IsNullOrWhiteSpace(Name))
                    return "_unknown_var";

                return Name[0].ToString().ToLower() + Name.Substring(1);
            }
        }

        public string Name
        {
            get;
            set;
        }

        public List<ITypeInfo> TypeInfos
        {
            get;
            set;
        }

        public bool IsXmlNode
        {
            get;
            set;
        }


        public string FullName
        {
            get;
            set;
        }


        public List<IPropertyInfo> PropertyInfos
        {
            get;
            set;
        }


        public virtual void Wise()
        {
            foreach (var p in this.PropertyInfos)
            {
                p.Wise();
            }
        }

        public int Line
        {
            get;
            set;
        }

        public int CharPositionInLine
        {
            get;
            set;
        }

        public int Length
        {
            get;
            set;
        }


        public virtual void Init()
        {
            
        }


        public bool IsPrimitive
        {
            get;
            set;
        }


        public bool IsGenericType
        {
            get;
            set;
        }

        public bool IsGenericTypeDefinition
        {
            get;
            set;
        }

        public ITypeInfo GenericParameterType
        {
            get;
            set;
        }

        public Guid? FileId
        {
            get;
            set;
        }

        public TokenPair TokenPair
        {
            get;
            set;
        }
    }
}
