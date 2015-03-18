using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Model.XmlModel.ParseResult
{
    public class FieldGroupInfo
    {
        public List<FieldInfo> Fields { get; set; }
        public bool IsOrder { get; set; }
    }
}
