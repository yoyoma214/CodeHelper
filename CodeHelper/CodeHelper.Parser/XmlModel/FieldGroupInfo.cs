using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.XmlModel
{
    public class FieldGroupInfo
    {
        public List<FieldInfo> Fields { get; set; }
        public bool IsOrder { get; set; }
    }
}
