using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.DataViews.Joins;
using CodeHelper.Core.Parse.ParseResults.DataViews.Condition;
using CodeHelper.Core.Parse.ParseResults.DataViews.Grouping;
using CodeHelper.Core.Parse.ParseResults.DataViews.Orders;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class Select_Atom : TokenPair
    {
        public Select_Clause_Full Select_clause_full { get; set; }
        public From_Clause_Full From_clause_full { get; set; }
        public Join_Clause_Full Join_clause_full { get; set; }
        public Condition_Clause_Full Conditon_clause_full { get; set; }
        public Group_Clause_Full Group_clause_full { get; set; }
        public Order_Clause_Full Order_clause_full { get; set; }
        public Select Select { get; set; }

        public void Parse(SelectAtomContext ctx)
        {
 
            //SelectAtomContext result = new SelectAtomContext();

            //SelectAtomContext.Context_Stack.Push(result);

            if (this.Select != null)
            {
                ctx.SelectContext = new SelectContext();
                Select.Parse(ctx.SelectContext);
                return;
            }

            if (Select_clause_full != null)
            {
                var temp = Select_clause_full.Parse(ctx);
                ctx.ReturnFields.AddRange(temp);
            }

            if (From_clause_full != null)
            {
                var temp = From_clause_full.Parse(ctx);
                ctx.TableJoinInfos.AddRange(temp);
            }

            if (Join_clause_full != null)
            {
                var temp = Join_clause_full.Parse(ctx);
                ctx.TableJoinInfos.AddRange(temp);                
            }

            if (Conditon_clause_full != null)
            {
                ctx.Condition = new OrConditionInfo();
                Conditon_clause_full.Parse(ctx.Condition);
                //ctx.Condition = temp;
            }

            if (Group_clause_full != null)
            {
                var temp = Group_clause_full.Parse(ctx);
                ctx.Group = temp;
            }

            if (Order_clause_full != null)
            {
                var temp = Order_clause_full.Parse(ctx);
                ctx.OrderInfos.AddRange(temp);
            }

            //result.ParentContext = ctx;

            //SelectAtomContext.Context_Stack.Pop();

            //return result;
        }
    }
}
