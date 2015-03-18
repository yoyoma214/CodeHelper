using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.DataViews.Fields;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class Select_Clause : TokenPair
    {
        public List<Table_Field_Alias> Table_field_alias_list { get; set; }

        public List<FieldInfo> Parse(SelectAtomContext ctx)
        {
            var rslt = new List<FieldInfo>();

            if (Table_field_alias_list != null)
            {
                foreach (var field in Table_field_alias_list)
                {
                    var temp = field.Parse(ctx);
                    if (temp == null)
                        System.Diagnostics.Debug.Assert(false,"×Ö¶Î½âÎöÎª¿Õ");

                    rslt.Add(temp);
                    //SqlContext.Context_Stack.Peek().ReturnFields.Add(temp);

                    //rslt = rslt.Join(temp);
                }
            }

            return rslt;
        }
    }
}