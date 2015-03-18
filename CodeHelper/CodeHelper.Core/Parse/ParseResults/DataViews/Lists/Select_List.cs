using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Lists
{
    public class Select_List : TokenPair
    {
        public Select Select { get; set; }

        public SelectListFieldInfo Parse(SelectAtomContext ctx)
        {
            var rslt = new SelectListFieldInfo();
            rslt.SelectContext = new SelectContext();
            Select.Parse(rslt.SelectContext);
            return rslt;
        }
    }
}