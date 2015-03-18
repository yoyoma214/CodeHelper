using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Condition_Option : TokenPair
    {
        public String Option { get; set; }

        public void Parse(SelectAtomContext ctx)
        {
            return;
            //return base.Parse(ctx);
        }
    }
}