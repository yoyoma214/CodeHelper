using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Exclusive_Or_Expression : TokenPair
    {
        public List<And_Expression> And_expressions { get; set; }


        internal Exclusive_Or_ExpressionInfo Parse()
        {
            var rslt = new Exclusive_Or_ExpressionInfo(this);
            foreach (var and in this.And_expressions)
            {
                rslt.And_Expressions.Add(and.Parse());
            }
            return rslt;
        }
    }
}