using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Parameters
{
    public class Parameter : TokenPair
    {
        public Parameter_Name Parameter_name { get; set; }

        public ParameterFieldInfo Parse(SelectAtomContext ctx)
        {  
            
            var para = new ParameterFieldInfo();

            para.Name = Parameter_name.Text;            

            return para;
        }
    }

}