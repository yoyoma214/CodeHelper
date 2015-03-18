using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields.CaseWhen
{
    public class Case_Have_Target_When_Expression : TokenPair
    {
        public Value Value { get; set; }

        public Result_Expression_Prior Result_expression_prior { get; set; }

        public CaseHaveTargetWhenExpressionInfo Parse(SelectAtomContext ctx)
        {
            var rslt = new CaseHaveTargetWhenExpressionInfo();
            rslt.Value = Value.Parse(ctx);

            rslt.ResultExpress = Result_expression_prior.Parse(ctx);

            return rslt;
        }
    }
}