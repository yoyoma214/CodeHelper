using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Multiplicative_Expression : TokenPair
    {
        public List<Cast_Expression> Cast_expressions { get; set; }
        public List<String> Operators { get; set; }

        internal Multiplicative_ExpressionInfo Parse()
        {
            var rslt = new Multiplicative_ExpressionInfo(this);
            foreach (var expr in Cast_expressions)
            {
                rslt.Cast_Expressions.Add(expr.Parse());
            }
            foreach (var op in this.Operators)
            {
                switch (op)
                {
                    case "/":
                        rslt.Operators.Add(Multiplicative_Expression_OperatorInfo.Devide);
                        break;
                    case "%":
                        rslt.Operators.Add(Multiplicative_Expression_OperatorInfo.Mod);
                        break;
                    case "*":
                        rslt.Operators.Add(Multiplicative_Expression_OperatorInfo.Mulit);
                        break;
                }
            }
            return rslt;
        }
    }
}