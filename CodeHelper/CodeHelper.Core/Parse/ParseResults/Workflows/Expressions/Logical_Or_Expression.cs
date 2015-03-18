using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Logical_Or_Expression : TokenPair
    {
        public List<Logical_And_Expression> Logical_and_expressions { get; set; }

        internal Logical_Or_ExpressionInfo Parse()
        {
            var rslt = new Logical_Or_ExpressionInfo(this);
            foreach (var and in this.Logical_and_expressions)
            {
                rslt.Logical_And_Expressions.Add(and.Parse());
            }
            return rslt;
        }
    }
}