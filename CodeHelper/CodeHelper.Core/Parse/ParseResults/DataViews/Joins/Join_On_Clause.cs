using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.DataViews.Condition;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Joins
{
    public class Join_On_Clause : TokenPair
    {
        public Condition_Clause Condition_clause { get; set; }

        public void Parse(OrConditionInfo ctx)
        {
            Condition_clause.Parse(ctx);
        }
    }
}