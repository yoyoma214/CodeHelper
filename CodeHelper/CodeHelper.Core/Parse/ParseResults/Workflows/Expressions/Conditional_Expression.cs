using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Conditional_Expression : TokenPair
    {
        public Logical_Or_Expression Logical_or_expression { get; set; }
        public Expression Second_expression { get; set; }
        public Conditional_Expression Third_expression { get; set; }

        public ConditionalExpressionInfo Parse()
        {
            var rslt = new ConditionalExpressionInfo(this);
            rslt.Logical_Or_Expression = this.Logical_or_expression.Parse();
            if (Second_expression != null)
            {
                rslt.Expression = this.Second_expression.Parse();
            }
            if (Third_expression != null)
            {
                rslt.ConditionalExpression = this.Third_expression.Parse();
            }
            return rslt;
        }
    }
}