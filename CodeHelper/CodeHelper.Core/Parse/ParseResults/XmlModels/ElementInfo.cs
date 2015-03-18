using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults;

namespace CodeHelper.Core.Parse.ParseResults.XmlModels
{
    public class ElementInfo : TypeInfoBase
    {
        //public String Name { get; set; }
        public List<XmlAttributeInfo> XmlAttributes { get; set; }
        public List<FieldInfo> Fields { get; set; }
        public List<AttributeGroupInfo> AttrGroups { get; set; }
        public List<FieldGroupInfo> FieldGroups { get; set; }

        public ElementInfo()
            : base()
        {
            this.XmlAttributes = new List<XmlAttributeInfo>();
        }

        public override void Init()
        {
            this.TokenPair = this;

            this.PropertyInfos.AddRange(this.XmlAttributes);
            foreach (var attr in this.XmlAttributes)
                attr.Init();

            this.PropertyInfos.AddRange(this.Fields);
            foreach (var field in this.Fields)
                field.Init();

            base.Init();
        }
    }
}
