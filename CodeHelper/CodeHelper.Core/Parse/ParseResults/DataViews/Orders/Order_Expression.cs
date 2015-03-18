using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.DataViews.Fields;

namespace CodeHelper.Core.Parse.ParseResults.DataViews.Orders
{
    public class Order_Expression : TokenPair
    {
        public Field_Regular Field_regular { get; set; }
        public bool Is_asc { get; set; }
        public bool Is_desc { get; set; }

        public OrderInfo Parse(SelectAtomContext ctx)
        {
            if (Field_regular == null)
                return null;

            OrderInfo rslt = null;
            var temp = Field_regular.Parse(ctx);
            if (temp != null)
            {
                var order = new OrderInfo();

                var fr = temp;
                order.Field = fr.FullName;
                order.OrderType = Is_desc ? OrderType.Desc : OrderType.Asc;
                return order;

            }
            return rslt;
        }
    }
}