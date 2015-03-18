using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.DataBaseHelper.EF.Mappings
{
    public class Condition : EFBaseNode
    {
        public string ColumnName { get; set; }

        public bool IsNull { get; set; }
    }
}
