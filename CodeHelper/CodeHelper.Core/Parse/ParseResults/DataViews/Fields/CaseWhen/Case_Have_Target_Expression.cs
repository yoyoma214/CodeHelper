using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields.CaseWhen
{
    public class Case_Have_Target_Expression : TokenPair
    {
        public Table_Field Table_field { get; set; }
        public List<Case_Have_Target_When_Expression> Case_have_target_when_expressions { get; set; }
        public Case_Else_Expression Case_else_expression { get; set; }

        public Case_Have_Target_Expression()
        {
            Case_have_target_when_expressions = new List<Case_Have_Target_When_Expression>();
        }

        public CaseFieldWithTargetInfo Parse(SelectAtomContext ctx)
        {
            var rslt = new CaseFieldWithTargetInfo();
            rslt.Target = Table_field.Parse(ctx);

            foreach (var expr in this.Case_have_target_when_expressions)
            {
                rslt.CaseHaveTargetWhenExpressions.Add(expr.Parse(ctx));
            }

            if (Case_else_expression != null)
            {
                rslt.CaseElseExpression = Case_else_expression.Parse(ctx);
            }

            return rslt;
        }
    }
}