using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.DataViews.Condition;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Grouping
{
    public class Having_Clause : TokenPair
    {
        public Condition_Clause Condition { get; set; }

        public void Parse(HavingInfo ctx)
        {
            if (Condition == null)
                return;
            //var having  = new HavingInfo();
            ctx.Condition = new OrConditionInfo();

            //SelectAtomContext.Condition_Stack.Push(having.Condition);
            Condition.Parse(ctx.Condition);
            //var context = SelectAtomContext.Context_Stack.Peek();
            //context.Group.Having = having;
            //SelectAtomContext.Condition_Stack.Pop();
            //return having;
        }
    }
}