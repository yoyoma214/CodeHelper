using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields.CaseWhen
{
    public class Result_Expression : TokenPair
    {
        public Value Value { get; set; }
        //public Select Select { get; set; }

        public FieldInfo Parse(SelectAtomContext ctx)
        {
            var rslt = new FieldInfo();
            if (Value != null)
                return Value.Parse(ctx);

            //if (Select != null)
            //{
            //    var subCtx = new SelectContext();

            //    Select.Parse(subCtx);

            //    rslt.Select = subCtx;
                
            //}
            return rslt;
        }
    }
}