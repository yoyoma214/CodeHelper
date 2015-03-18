using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.XmlModel
{
    public class AttributeGroupInfo
    {
        public List<AttributeInfo> Attributes { get; set; }
        public bool IsOrder { get; set; }
    }
}
