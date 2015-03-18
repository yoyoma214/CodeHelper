using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class Select_Clause_Full : TokenPair
    {
        public Select_Clause Select_clause { get; set; }
        public Top_Clause Top_clause { get; set; }

        public List<FieldInfo> Parse(SelectAtomContext ctx)
        {
            if (Top_clause != null)
                ctx.TopValue = Top_clause.Parse();

            if (Select_clause != null)
                return Select_clause.Parse(ctx);

            return null;
        }
    }
}