using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions
{
    public class Logical_And_Expression : TokenPair
    {
        public List<Inclusive_Or_Expression> Inclusive_or_expressions { get; set; }


        internal Logical_And_ExpressionInfo Parse()
        {
            var rslt = new Logical_And_ExpressionInfo(this);
            foreach (var or in this.Inclusive_or_expressions)
            {
                rslt.Inclusive_Or_Expressions.Add(or.Parse());
            }
            return rslt;
        }
    }
}