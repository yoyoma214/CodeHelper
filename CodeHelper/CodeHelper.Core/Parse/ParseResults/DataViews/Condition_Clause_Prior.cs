using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.DataViews.Condition;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class Condition_Clause_Prior : TokenPair
    {
        public Condition_Clause Condition_clause { get; set; }

        public OrConditionInfo Parse(SelectAtomContext ctx)
        {
            var rslt = new OrConditionInfo();
            Condition_clause.Parse(rslt);
            return rslt;
        }
    }
}