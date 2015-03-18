using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults;

namespace CodeHelper.Core.Parse.ParseResults.XmlModels
{
    public class XmlAttributeInfo : PropertyInfoBase
    {
        //public String Name { get; set; }
        public String DefaultValue { get; set; }

        public override void Init()
        {
            this.TokenPair = this;
            base.Init();
        }
    }
}
