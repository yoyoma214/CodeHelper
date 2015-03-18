using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions
{
    public class Shift_Expression : TokenPair
    {
        public List<Additive_Expression> Additive_expressions { get; set; }
        public List<String> Operators { get; set; }

        internal Shift_ExpressionInfo Parse()
        {
            var rslt = new Shift_ExpressionInfo(this);
            foreach (var expr in Additive_expressions)
            {
                rslt.Additive_Expressions.Add(expr.Parse());
            }
            foreach (var op in this.Operators)
            {
                switch (op)
                {
                    case "<<":
                        rslt.Operators.Add(Shift_Expression_OperatorInfo.Left);
                        break;
                    case ">>":
                        rslt.Operators.Add(Shift_Expression_OperatorInfo.Right);
                        break;
                }
            }
            return rslt;
        }
    }
}