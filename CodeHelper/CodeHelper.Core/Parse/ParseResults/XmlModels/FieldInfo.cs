using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults;

namespace CodeHelper.Core.Parse.ParseResults.XmlModels
{
    public class FieldInfo : PropertyInfoBase
    {
        //public String Name { get; set; }
        public String DefaultValue { get; set; }
        public bool IsGenricList
        {
            get
            {
                if (Type.StartsWith("List<"))
                {
                    return true;
                }
                return false;
            }
        }
        public string GenericArgument
        {
            get
            {
                if (IsGenricList)
                {
                    return Type.Replace("List<", "").Replace(">", "");
                }

                return "";
            }
        }

        public override void Init()
        {
            this.TokenPair = this;
            base.Init();
        }
    }
}
