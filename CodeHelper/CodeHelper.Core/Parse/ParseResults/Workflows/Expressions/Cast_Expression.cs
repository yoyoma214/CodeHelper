using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Cast_Expression : TokenPair
    {
        public Generic_Type Generic_type { get; set; }

        public Cast_Expression Cast_expression { get; set; }

        public Unary_Expression Unary_expression { get; set; }


        internal Cast_ExpressionInfo Parse()
        {
            var rslt = new Cast_ExpressionInfo(this);
            if (this.Unary_expression != null)
            {
                rslt.Unary_Expression = this.Unary_expression.Parse();
            }
            else
            {
                rslt.GenericType = Generic_type.Parse();
                rslt.Cast_Expression = this.Cast_expression.Parse();
            }
            return rslt;
        }
    }
}