using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Creator : TokenPair
    {
        public Generic_Type Generic_type { get; set; }
        public List<Assignment_Expression> Assignment_expressions { get; set; }

        internal CreatorInfo Parse()
        {
            var rslt = new CreatorInfo();
            rslt.GenericType = Generic_type.Parse();
            
            foreach (var para in this.Assignment_expressions)
            {
                rslt.Assignment_expressions.Add(para.Parse());
            }
            return rslt;
        }
    }
}
