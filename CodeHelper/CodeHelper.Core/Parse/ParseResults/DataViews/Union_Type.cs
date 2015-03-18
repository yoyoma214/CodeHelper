using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class Union_Type : TokenPair
    {
        public String Union_type{get;set;}

        public UnionType Parse()
        {
            if (string.IsNullOrWhiteSpace(Union_type))
                return UnionType.Unkown;

            switch (Union_type.ToLower())
            {
                case "except":
                    return UnionType.Except;
                case "intersect":
                    return UnionType.Intersect;
                case "union":
                    return UnionType.Union;
                case "unionall":
                    return UnionType.Union_All;
                default:
                    return UnionType.Unkown;
            }
        }
    }
}
