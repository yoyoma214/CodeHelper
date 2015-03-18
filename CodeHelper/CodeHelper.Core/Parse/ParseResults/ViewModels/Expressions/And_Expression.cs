using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions
{
    public class And_Expression : TokenPair
    {
        public List<Equality_Expression> Equality_expressions { get; set; }


        internal And_ExpressionInfo Parse()
        {
            var rslt = new And_ExpressionInfo(this);
            foreach (var eq in this.Equality_expressions)
            {
                rslt.Equality_Expressions.Add(eq.Parse());
            }
            return rslt;
        }
    }
}
