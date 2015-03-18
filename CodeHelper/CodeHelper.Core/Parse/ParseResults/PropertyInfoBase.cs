using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Types;
using CodeHelper.Core.Services;
using CodeHelper.Core.Parse.ParseResults.DataModels;

namespace CodeHelper.Core.Parse.ParseResults
{
    public class PropertyInfoBase :TokenPair, IPropertyInfo, IGeneratorUtil
    {
        public List<AttributeInfo> Attributes { get; set; }

        public PropertyInfoBase()
            : base()
        {
            this.Attributes = new List<AttributeInfo>();            
        }

        public string Name
        {
            get;
            set;
        }

        public string VariableName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Name))
                    return "_unknown_var";

                return Name[0].ToString().ToLower() + Name.Substring(1);
            }
        }

        public ITypeInfo TypeInfo
        {
            get;
            set;
        }

        public virtual void Wise()
        {
            
        }

        //public int Line
        //{
        //    get;
        //    set;
        //}

        //public int CharPositionInLine
        //{
        //    get;
        //    set;
        //}

        //public int Length
        //{
        //    get;
        //    set;
        //}

        public virtual string Type
        {
            get;
            set;
        }

        public bool Nullabe
        {
            get;
            set;
        }


        public virtual void Init()
        {
            
        }

        public TokenPair TokenPair
        {
            get;
            set;
        }

        public String DefaultValue { get; set; }
    }
}
