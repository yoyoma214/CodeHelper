using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Lists
{
    public class Value_List : TokenPair
    {
        public List<Value> Values { get; set; }

        public Value_List()
        {
            this.Values = new List<Value>();
        }

        public FieldInfo Parse(SelectAtomContext ctx)
        {
            if (Values == null || Values.Count == 0)
            {
                return null;
            }
  
            var f = new ValueListFieldInfo();

            foreach (var v in Values)
            {                
                var temp = v.Parse(ctx);
                f.Fields.Add(temp);
            }

            return f;
        }
    }
}
