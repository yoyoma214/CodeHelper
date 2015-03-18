using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Expression
{
    public class Binary_Expression : TokenPair
    {
        public List<Multiplicative_Expression> Multiplicative_expressions { get; set; }

        public List<String> Operators { get; set; }

        public Binary_Expression()
        {
            this.Multiplicative_expressions = new List<Multiplicative_Expression>();

            this.Operators = new List<string>();
        }

        public BinaryExpressionFieldInfo Parse(SelectAtomContext ctx)
        {
            var rslt = new BinaryExpressionFieldInfo();

            foreach (var expr in Multiplicative_expressions)
            {
                rslt.MultiplicativeExpressionInfos.Add(expr.Parse(ctx));
            }

            return rslt;
        }
    }
}
