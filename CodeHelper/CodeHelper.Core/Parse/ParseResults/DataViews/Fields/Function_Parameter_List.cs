using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Fields
{
    public class Function_Parameter_List : TokenPair
    {
        public List<Function_Parameter> Function_parameters { get; set; }

        public List<FieldInfo> Parse(SelectAtomContext ctx)
        {
            var rslt = new List<FieldInfo>();

            foreach (var p in this.Function_parameters)
            {
                rslt.Add( p.Parse(ctx));
                //rslt = rslt.Join(temp);
            }
            return rslt;
        }
    }
}
