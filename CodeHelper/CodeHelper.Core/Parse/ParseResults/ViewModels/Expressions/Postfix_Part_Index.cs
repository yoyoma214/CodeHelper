using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions
{
    public class Postfix_Part_Index : TokenPair
    {
        public Expression Expression;

        internal Postfix_Part_IndexInfo Parse()
        {
            var rslt = new Postfix_Part_IndexInfo(this);
            rslt.Expression = this.Expression.Parse();
            return rslt;
        }
    }
}