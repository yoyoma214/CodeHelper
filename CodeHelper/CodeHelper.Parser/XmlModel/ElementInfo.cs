using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.XmlModel
{
    public class ElementInfo
    {
        public String Name { get; set; }
        public List<AttributeInfo> Attributes { get; set; }
        public List<FieldInfo> Fields { get; set; }
        public List<AttributeGroupInfo> AttrGroups { get; set; }
        public List<FieldGroupInfo> FieldGroups { get; set; }
    }
}
