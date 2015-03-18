using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.DataViews.Options;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Parameters
{
    public class Parameter_Options : TokenPair
    {
        public Option_Expression Option_expression { get; set; }

        //public override SelectAtomContext Parse(SelectAtomContext ctx)
        //{
        //    return base.Parse(ctx);
        //}
    }
}