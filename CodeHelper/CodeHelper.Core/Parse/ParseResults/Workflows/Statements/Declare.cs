using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.Workflows.Expressions;
namespace CodeHelper.Core.Parse.ParseResults.Workflows.Statements
{
    public class Declare : TokenPair
    {
        public Generic_Type Generic_Type { get; set; }
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
            rslt.GenericType = this.Generic_Type.Parse();
            if (this.Default_value != null)
            {
                rslt.Value = Default_value.Parse();
            }
            return rslt;
        }
    }
}