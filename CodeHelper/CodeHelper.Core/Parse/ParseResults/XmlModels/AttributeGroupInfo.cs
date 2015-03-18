using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.XmlModels
{
    public class AttributeGroupInfo : TokenPair
    {
        public List<AttributeInfo> Attributes { get; set; }
        public bool IsOrder { get; set; }
    }
}
