using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields.CaseWhen
{
    public class Case_When_Expression : TokenPair
    {
        public Condition_Clause_Prior condition_clause_prior { get; set; }
        public Result_Expression_Prior result_expression_prior { get; set; }

        public CaseWhenExprressInfo Parse(SelectAtomContext ctx)
        {
            var rslt = new CaseWhenExprressInfo();
            rslt.Condition = condition_clause_prior.Parse(ctx);

            rslt.ResultExpress = result_expression_prior.Parse(ctx);

            return rslt;
        }
    }
}