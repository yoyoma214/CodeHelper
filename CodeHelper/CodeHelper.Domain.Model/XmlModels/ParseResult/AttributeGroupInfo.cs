using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model.XmlModel.ParseResult
{
    public class AttributeGroupInfo
    {
        public List<AttributeInfo> Attributes { get; set; }
        public bool IsOrder { get; set; }
    }
}
