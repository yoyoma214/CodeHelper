using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields
{
    public class Function_Parameter : TokenPair
    {

        public Table_Field Table_field { get; set; }

        public FieldInfo Parse(SelectAtomContext ctx)
        {
            return this.Table_field.Parse(ctx);
        }
    }
}