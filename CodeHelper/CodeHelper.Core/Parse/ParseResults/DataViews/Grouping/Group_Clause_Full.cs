using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Grouping
{
    public class Group_Clause_Full : TokenPair
    {
        public Group_Clause Group_clause { get; set; }

        public GroupInfo Parse(SelectAtomContext ctx)
        {
            if (Group_clause == null)
                return null;

            return Group_clause.Parse(ctx);
        }
    }
}