/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.orders;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Order_Clause_Full extends TokenPair{
    private Order_Clause order_clause;

    /**
     * @return the order_clause
     */
    public Order_Clause getOrder_clause() {
        return order_clause;
    }

    /**
     * @param order_clause the order_clause to set
     */
    public void setOrder_clause(Order_Clause order_clause) {
        this.order_clause = order_clause;
    }
}
