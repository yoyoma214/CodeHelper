using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Expressions
{
    public class Postfix_Part_Function : TokenPair
    {
        public Argument_Expression_List Argument_expression_list { get; set; }


        internal Postfix_Part_FunctionInfo Parse()
        {
            var rslt = new Postfix_Part_FunctionInfo(this);
            rslt.Assignment_Expressions.AddRange(this.Argument_expression_list.Parse());
            return rslt;
        }
    }
}