using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Options
{
    public class Option_List : TokenPair
    {
        public List<Option> Options { get; set; }

        public Option_List()
        {
            this.Options = new List<Option>();
        }

        //public override SelectAtomContext Parse(SelectAtomContext ctx)
        //{
        //    return base.Parse(ctx);
        //}
    }
}