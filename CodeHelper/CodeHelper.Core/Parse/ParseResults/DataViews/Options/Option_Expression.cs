using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Options
{
    public class Option_Expression : TokenPair
    {
        public Option_List Option_list { get; set; }

        //public override SelectAtomContext Parse(SelectAtomContext ctx)
        //{
        //    return base.Parse(ctx);
        //}
    }
}