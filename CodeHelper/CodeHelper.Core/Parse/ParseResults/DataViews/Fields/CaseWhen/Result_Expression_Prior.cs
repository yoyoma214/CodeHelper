using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields.CaseWhen
{
    public class Result_Expression_Prior : TokenPair
    {
        public Result_Expression Result_expression { get; set; }

        public FieldInfo Parse(SelectAtomContext ctx)
        {
            return Result_expression.Parse(ctx);
        }
    }
}