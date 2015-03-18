using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields
{
    public class Function_Field : TokenPair
    {
        public String Name { get; set; }

        public Function_Parameter_List Function_parameter_list { get; set; }

        public FunctionFieldInfo Parse(SelectAtomContext ctx)
        {
            var f = new FunctionFieldInfo();

            f.FunctionName = this.Name;

            if (Function_parameter_list != null)
            {
                var temp = this.Function_parameter_list.Parse(ctx);

                f.ParameterFields.AddRange(temp);

            }
            return f;
        }
    }
}