using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class All_Field : TokenPair
    {
        public AllFieldInfo Parse(SelectAtomContext ctx)
        {
            return new AllFieldInfo();
        }
    }
}