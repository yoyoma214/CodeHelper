using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields.CaseWhen
{
    public class Case_Else_Expression : TokenPair
    {
        public Result_Expression_Prior Result_expression_prior { get; set; }

        public CaseElseExpressionInfo Parse(SelectAtomContext ctx)
        {
            var rslt = new CaseElseExpressionInfo();
            rslt.Value = Result_expression_prior.Parse(ctx);
            return rslt;
        }
    }
}