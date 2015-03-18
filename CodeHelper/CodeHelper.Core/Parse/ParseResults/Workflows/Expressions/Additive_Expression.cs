using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Additive_Expression : TokenPair
    {
        public List<Multiplicative_Expression> Multiplicative_expressions { get; set; }
        public List<String> Operators { get; set; }


        internal Additive_ExpressionInfo Parse()
        {
            var rslt = new Additive_ExpressionInfo(this);
            foreach (var expr in this.Multiplicative_expressions)
            {
                rslt.Multiplicative_Expressions.Add(expr.Parse());
            }

            foreach (var op in this.Operators)
            {
                switch (op)
                {
                    case "+":
                        rslt.Operators.Add(Additive_Expression_OperatorInfo.Add);
                        break;
                    case "-":
                        rslt.Operators.Add(Additive_Expression_OperatorInfo.Subtract);
                        break;
                }
            }
            return rslt;
        }
    }
}
