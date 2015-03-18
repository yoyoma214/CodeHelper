using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields
{
    public class Field_Regular : TokenPair
    {
        public Long_Name Long_Name { get; set; }

        public FieldRegularInfo Parse(SelectAtomContext ctx)
        {
            return new FieldRegularInfo() { FullName = this.Long_Name.Text };
        }
    }
}