using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Orders
{
    public class Order_Clause : TokenPair
    {
        public List<Order_Expression> Order_expressions{get;set;}

        public Order_Clause()
        {
            this.Order_expressions = new List<Order_Expression>();
        }

        public List<OrderInfo> Parse(SelectAtomContext ctx)
        {
            if (Order_expressions == null || Order_expressions.Count == 0)
                return null;

            var rslt = new List<OrderInfo>();

            foreach (var order in Order_expressions)
            {
                var temp = order.Parse(ctx);
                rslt.Add(temp);
            }

            return rslt;
        }
    }
}