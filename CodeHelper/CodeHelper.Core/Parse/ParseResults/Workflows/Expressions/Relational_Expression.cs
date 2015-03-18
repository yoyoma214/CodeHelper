using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Relational_Expression : TokenPair
    {
        public List<Shift_Expression> Shift_expressions { get; set; }
        public List<String> Operators { get; set; }

        internal Relational_ExpressionInfo Parse()
        {
            var rslt = new Relational_ExpressionInfo(this);
            foreach (var shift in this.Shift_expressions)
            {
                rslt.Shift_Expressions.Add(shift.Parse());
            }
            foreach (var op in this.Operators)
            {
                switch (op)
                {
                    case ">":
                        rslt.Operators.Add(Relational_Expression_OperatorInfo.GT);
                        break;
                    case ">=":
                        rslt.Operators.Add(Relational_Expression_OperatorInfo.GTEqual);
                        break;
                    case "<":
                        rslt.Operators.Add(Relational_Expression_OperatorInfo.LT);
                        break;
                    case "<=":
                        rslt.Operators.Add(Relational_Expression_OperatorInfo.LTEqual);
                        break;
                }
            }
            return rslt;
        }
    }
}