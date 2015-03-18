using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Expression
{
    public class Multiplicative_Expression : TokenPair
    {
        public List<Positive_Expression> Positive_expressions { get; set; }
        public List<String> Operators { get; set; }

        public Multiplicative_Expression()
        {
            this.Positive_expressions = new List<Positive_Expression>();
            this.Operators = new List<string>();
        }

        public MultiplicativeExpressionInfo Parse(SelectAtomContext ctx)
        {
            var rslt = new MultiplicativeExpressionInfo();

            foreach (var op in Operators)
            {
                rslt.Operators.Add(op);
            }

            foreach (var expression in this.Positive_expressions)
            {
                rslt.PositiveExpressionInfos.Add(expression.Parse(ctx));
            }
            return rslt;
        }
    }
}
