using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Options
{
    public class Option : TokenPair
    {
        public Option_Name Option_name { get; set; }
        public Option_Value Option_value { get; set; }

        //public override SelectAtomContext Parse(SelectAtomContext ctx)
        //{
        //    return base.Parse(ctx);
        //}
    }
}