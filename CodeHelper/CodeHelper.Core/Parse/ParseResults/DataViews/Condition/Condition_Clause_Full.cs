using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Condition_Clause_Full : TokenPair
    {
        public Condition_Clause Condition_clause { get; set; }

        public void Parse(OrConditionInfo ctx)
        {
            if (Condition_clause != null)
            {
                Condition_clause.Parse(ctx);
            }
            //return null;
            //return base.Parse(ctx);
        }
    }
}