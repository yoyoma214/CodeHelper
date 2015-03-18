using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class Top_Clause : TokenPair
    {
        public Value Value { get; set; }

        public FieldInfo Parse()
        {
            return Value.Parse(null);
        }

    }
}
