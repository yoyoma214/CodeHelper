using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class Table_All_Field : TokenPair
    {
        public String Name { get; set; }

        public TableAllFieldInfo Parse(SelectAtomContext ctx)
        {
            return new TableAllFieldInfo() { Table = this.Name };
        }
    }
}