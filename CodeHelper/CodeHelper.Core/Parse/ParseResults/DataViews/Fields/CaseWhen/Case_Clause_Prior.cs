using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields.CaseWhen
{
    public class Case_Clause_Prior : TokenPair
    {
        public Case_Clause Case_clause { get; set; }

        public CaseFieldInfo Parse(SelectAtomContext ctx)
        {
            return Case_clause.Parse(ctx);
        }
    }
}