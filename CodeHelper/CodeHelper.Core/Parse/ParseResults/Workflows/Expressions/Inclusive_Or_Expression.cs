using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Inclusive_Or_Expression : TokenPair
    {
        public List<Exclusive_Or_Expression> Exclusive_or_expressions { get; set; }


        internal Inclusive_Or_ExpressionInfo Parse()
        {
            var rslt = new Inclusive_Or_ExpressionInfo(this);
            foreach (var or in this.Exclusive_or_expressions)
            {
                rslt.Exclusive_Or_Expressions.Add(or.Parse());
            }
            return rslt;
        }
    }
}