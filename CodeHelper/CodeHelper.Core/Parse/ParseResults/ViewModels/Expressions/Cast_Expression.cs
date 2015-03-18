using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions
{
    public class Cast_Expression : TokenPair
    {
        public String Type_name { get; set; }

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
                rslt.TypeName = new TypeNameInfo(this) { Text = this.Type_name };
                rslt.Cast_Expression = this.Cast_expression.Parse();
            }
            return rslt;
        }
    }
}