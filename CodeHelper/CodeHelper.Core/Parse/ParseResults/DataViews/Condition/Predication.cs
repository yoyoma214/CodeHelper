using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Condition
{
    public class Predication : TokenPair
    {
        public String Predicate;

        public Select Select;

        public void Parse(PredicationFieldInfo ctx)
        {
            switch (Predicate.ToLower())
            {
                case "all":
                    ctx.PredicationType = PredicationType.All;
                    break;
                case "any":
                    ctx.PredicationType = PredicationType.Any;
                    break;
                case "some":
                    ctx.PredicationType = PredicationType.Some;
                    break;               
                default:
                    ctx.PredicationType = PredicationType.Unknown;
                    break;
            }
            ctx.SelectContext = new SelectContext();

            this.Select.Parse(ctx.SelectContext);
        }
    }
}
