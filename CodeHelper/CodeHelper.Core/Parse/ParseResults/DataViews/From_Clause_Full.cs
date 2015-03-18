using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class From_Clause_Full : TokenPair
    {
        public From_Clause From_clause { get; set; }

        public List<TableJoinInfo> Parse(SelectAtomContext ctx)
        {
            if (From_clause != null)
            {
                var temp = From_clause.Parse(ctx);
                return temp;
            }

            return null;
        }
    }
}