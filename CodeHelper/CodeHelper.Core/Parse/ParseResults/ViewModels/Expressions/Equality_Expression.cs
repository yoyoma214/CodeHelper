using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions
{
    public class Equality_Expression : TokenPair
    {
        public List<Relational_Expression> Relational_expressions { get; set; }
        public List<String> Operators { get; set; }

        internal Equality_ExpressionInfo Parse()
        {
            var rslt = new Equality_ExpressionInfo(this);
            foreach (var expr in this.Relational_expressions)
            {
                rslt.Relational_Expressions.Add(expr.Parse());
            }

            foreach (var op in this.Operators)
            {
                switch (op)
                {
                    case "==":
                        rslt.Equality_Expression_Operators.Add(Equality_Expression_OperatorInfo.Equal);
                        break;

                    case "!=":
                        rslt.Equality_Expression_Operators.Add(Equality_Expression_OperatorInfo.NotEqual);
                        break;
                }
            }
            return rslt;
        }
    }
}