using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class Table_Alias : TokenPair
    {
        public Table Table { get; set; }
        public String Alias { get; set; }

        public void Parse(TableJoinInfo ctx)
        {         
            ctx.RightTable =  Table.Text;
            ctx.Alias = Alias;         
        }
    }
}