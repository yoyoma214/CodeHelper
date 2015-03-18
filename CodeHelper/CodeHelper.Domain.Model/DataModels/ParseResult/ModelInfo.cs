using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.DataModel
{
    public class ModelInfo
    {
        public String Name { get; set; }
        public List<FieldInfo> Fields { get; set; }
        public List<ModelInfo> Models { get; set; }

    }
}
