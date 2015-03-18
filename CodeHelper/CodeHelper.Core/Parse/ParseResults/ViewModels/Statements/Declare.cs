using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.ViewModels.Expressions;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels.Statements
{
    public class Declare : TokenPair
    {
        public String Type_name { get; set; }
        public String Name { get; set; }
        public Expression Default_value { get; set; }

        public VariableInfo Parse()
        {
            //var rslt = new FieldInfo();
            //rslt.Name = this.Name;
            //rslt.Type_name = this.Type_name;
            //return rslt;

            var rslt = new VariableInfo(this);
            rslt.Name = this.Name;
            rslt.Type_name = this.Type_name;
            if (this.Default_value != null)
            {
                rslt.Value = Default_value.Parse();
            }
            return rslt;
        }
    }
}