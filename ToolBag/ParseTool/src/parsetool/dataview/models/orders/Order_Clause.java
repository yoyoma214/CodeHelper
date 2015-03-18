/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.orders;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Order_Clause extends TokenPair{
    private List<Order_Expression> order_expressions = new ArrayList<Order_Expression>();

    /**
     * @return the order_expressions
     */
    public List<Order_Expression> getOrder_expressions() {
        return order_expressions;
    }

    /**
     * @param order_expressions the order_expressions to set
     */
    public void setOrder_expressions(List<Order_Expression> order_expressions) {
        this.order_expressions = order_expressions;
    }
}
