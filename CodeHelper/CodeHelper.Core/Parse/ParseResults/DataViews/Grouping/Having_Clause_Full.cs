using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Grouping
{
    public class Having_Clause_Full : TokenPair
    {
        public Having_Clause Having_clause { get; set; }

        public void Parse(HavingInfo ctx)
        {
            if (Having_clause == null)
                return;

            Having_clause.Parse(ctx);
        }
    }
}