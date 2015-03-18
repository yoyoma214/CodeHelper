using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Expression
{
    public class Positive_Expression : TokenPair
    {
        public String Operator { get; set; }
        public Unary_Operator Unary_operator { get; set; }

        public PositiveExpressionInfo Parse(SelectAtomContext ctx)
        {
            var rslt = new PositiveExpressionInfo();
            rslt.IsPositive = true;
            if (!string.IsNullOrWhiteSpace(Operator))
            {
                if (Operator == "-")
                    rslt.IsPositive = false;
            }

            if (Unary_operator != null)
                rslt.UnaryOperatorInfo = Unary_operator.Parse(ctx);
            
            return rslt;
        }
    }
}
