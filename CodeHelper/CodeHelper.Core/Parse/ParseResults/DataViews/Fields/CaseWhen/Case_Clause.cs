using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields.CaseWhen
{
    public class Case_Clause : TokenPair
    {
        public Case_Have_Target_Expression Case_have_target_expression { get; set; }

        public Case_Expression Case_expression { get; set; }

        public CaseFieldInfo Parse(SelectAtomContext ctx)
        {
            if (Case_have_target_expression != null)
                return Case_have_target_expression.Parse(ctx);

            if (Case_expression != null)
                return Case_expression.Parse(ctx);

            return null;
        }
    }
}