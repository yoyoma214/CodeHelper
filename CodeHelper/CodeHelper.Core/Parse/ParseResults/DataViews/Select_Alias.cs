using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class Select_Alias : TokenPair
    {
        public Select Select { get; set; }
        public String Alias { get; set; }

        public SelectJoinInfo Parse(SelectAtomContext ctx)
        {
            var selectInfo = new SelectJoinInfo();
            selectInfo.Alias = Alias;
            selectInfo.SubContext = new SelectContext();

            Select.Parse(selectInfo.SubContext);
            return selectInfo;
        }
    }
}