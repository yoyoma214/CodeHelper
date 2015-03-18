using System;
namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition.In
{
    public class In_Keyword : TokenPair
    {
        public String keyworkd { get; set; }

        public InCondtionInfo Parse(SelectAtomContext ctx)
        {
            return null;
        }
    }

}