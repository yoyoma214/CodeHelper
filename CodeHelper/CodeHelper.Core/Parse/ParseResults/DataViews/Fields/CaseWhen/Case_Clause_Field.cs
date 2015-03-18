using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields.CaseWhen
{
    public class Case_Clause_Field : TokenPair
    {
        public Case_Clause_Prior Case_clause_prior { get; set; }

        public CaseFieldInfo Parse(SelectAtomContext ctx)
        {
            return Case_clause_prior.Parse(ctx);
        }
    }
}