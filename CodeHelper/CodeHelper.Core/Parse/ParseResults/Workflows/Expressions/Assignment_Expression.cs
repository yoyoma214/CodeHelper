using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Assignment_Expression : TokenPair
    {
        public String Lvalue { get; set; }
        public String Operator { get; set; }
        public Assignment_Expression Assignment_expression { get; set; }
        public Conditional_Expression Conditional_expression { get; set; }

        public AssignmentExpressionInfo Parse()
        {
            var rslt = new AssignmentExpressionInfo(this);
            if (Conditional_expression != null)
            {
                rslt.ConditionalExpression = this.Conditional_expression.Parse();
            }
            else
            {
                rslt.LValue = new LValueInfo(this) { Text = Lvalue };
                #region operator
                switch (Operator)
                {
                    case "=":
                        rslt.AssignOperator = AssignOperatorInfo.Equal;
                        break;
                    case "*=":
                        rslt.AssignOperator = AssignOperatorInfo.MulitEqual;
                        break;
                    case "+=":
                        rslt.AssignOperator = AssignOperatorInfo.AddEqual;
                        break;
                    case "/=":
                        rslt.AssignOperator = AssignOperatorInfo.DivideEqual;
                        break;
                    case "%=":
                        rslt.AssignOperator = AssignOperatorInfo.ModEqual;
                        break;
                    case "-=":
                        rslt.AssignOperator = AssignOperatorInfo.SubEqual;
                        break;
                    default:
                        break;
                }
                #endregion
                rslt.AssignmentExpression = this.Assignment_expression.Parse();
                
            }
            return rslt;
        }
    }
}
