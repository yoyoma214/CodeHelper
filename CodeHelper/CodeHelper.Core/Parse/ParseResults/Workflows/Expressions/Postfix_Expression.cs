using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Postfix_Expression : TokenPair
    {
        public Primary_Expression Primary_expression { get; set; }
        public List<Postfix_Part> Postfix_parts { get; set; }


        internal Postfix_ExpressionInfo Parse()
        {
            var rslt = new Postfix_ExpressionInfo(this);
            rslt.Primary_Expression = this.Primary_expression.Parse();
            foreach (var part in this.Postfix_parts)
            {
                rslt.Postfix_Parts.Add(part.Parse());
            }
            return rslt;
        }
    }
}