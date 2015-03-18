using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Orders
{
    public class Order_Clause_Full : TokenPair
    {
        public Order_Clause Order_clause { get; set; }

        public List<OrderInfo> Parse(SelectAtomContext ctx)
        {
            if (Order_clause == null)
                return null;

            return Order_clause.Parse(ctx);
        }
    }
}