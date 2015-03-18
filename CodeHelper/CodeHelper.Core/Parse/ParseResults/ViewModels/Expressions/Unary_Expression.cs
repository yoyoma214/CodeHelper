using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions
{
    public class Unary_Expression : TokenPair
    {
        public Postfix_Expression Postfix_expression { get; set; }
        public Unary_Expression_One_Char Unary_expression_one_char { get; set; }
        public Unary_Expression_Two_Char Unary_expression_two_char { get; set; }


        internal Unary_ExpressionInfo Parse()
        {
            var rslt = new Unary_ExpressionInfo(this);
            if (this.Postfix_expression != null)
            {
                rslt.Postfix_Expression = this.Postfix_expression.Parse();
            }
            if (this.Unary_expression_one_char != null)
            {
                rslt.Unary_Expression_One_Char = this.Unary_expression_one_char.Parse();
            }
            if (this.Unary_expression_two_char != null)
            {
                rslt.Unary_Expression_Two_Char = this.Unary_expression_two_char.Parse();
            }
            return rslt;
        }
    }
}