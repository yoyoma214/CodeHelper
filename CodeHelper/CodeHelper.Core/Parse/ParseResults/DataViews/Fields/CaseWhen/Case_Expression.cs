using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields.CaseWhen
{
    public class Case_Expression : TokenPair
    {
        public List<Case_When_Expression> Case_when_expressions { get; set; }
        public Case_Else_Expression Case_else_expression { get; set; }

        public Case_Expression()
        {
            Case_when_expressions = new List<Case_When_Expression>();

        }

        public CaseFieldNoTargetInfo Parse(SelectAtomContext ctx)
        {
            var rslt = new CaseFieldNoTargetInfo();
            foreach (var expr in Case_when_expressions)
            {
                rslt.CaseWhenExprresses.Add(expr.Parse(ctx));
            }

            rslt.CaseElseExpression = Case_else_expression.Parse(ctx);

            return rslt;
        }
    }
}