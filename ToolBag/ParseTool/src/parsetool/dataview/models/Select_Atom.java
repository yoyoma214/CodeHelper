/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models;

import parsetool.dataview.models.condition.Condition_Clause_Full;
import parsetool.dataview.models.grouping.Group_Clause_Full;
import parsetool.dataview.models.join.Join_Clause;
import parsetool.dataview.models.join.Join_Clause_Full;
import parsetool.dataview.models.orders.Order_Clause_Full;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Select_Atom extends TokenPair{
  
    private Select_Clause_Full select_clause_full;
    private From_Clause_Full from_clause_full;
    private Join_Clause_Full join_clause_full;
    private Condition_Clause_Full conditon_clause_full;
    private Group_Clause_Full group_clause_full;
    private Order_Clause_Full order_clause_full;
    
    private Select select;
    
    /**
     * @return the select_clause_full
     */
    public Select_Clause_Full getSelect_clause_full() {
        return select_clause_full;
    }

    /**
     * @param select_clause_full the select_clause_full to set
     */
    public void setSelect_clause_full(Select_Clause_Full select_clause_full) {
        this.select_clause_full = select_clause_full;
    }

    /**
     * @return the from_clause_full
     */
    public From_Clause_Full getFrom_clause_full() {
        return from_clause_full;
    }

    /**
     * @param from_clause_full the from_clause_full to set
     */
    public void setFrom_clause_full(From_Clause_Full from_clause_full) {
        this.from_clause_full = from_clause_full;
    }

    /**
     * @return the join_clause
     */
    public Join_Clause_Full getJoin_clause_full() {
        return join_clause_full;
    }

    /**
     * @param join_clause the join_clause to set
     */
    public void setJoin_clause_full(Join_Clause_Full join_clause_full) {
        this.join_clause_full = join_clause_full;
    }

    /**
     * @return the conditon_clause_full
     */
    public Condition_Clause_Full getConditon_clause_full() {
        return conditon_clause_full;
    }

    /**
     * @param conditon_clause_full the conditon_clause_full to set
     */
    public void setConditon_clause_full(Condition_Clause_Full conditon_clause_full) {
        this.conditon_clause_full = conditon_clause_full;
    }

    /**
     * @return the group_clause_full
     */
    public Group_Clause_Full getGroup_clause_full() {
        return group_clause_full;
    }

    /**
     * @param group_clause_full the group_clause_full to set
     */
    public void setGroup_clause_full(Group_Clause_Full group_clause_full) {
        this.group_clause_full = group_clause_full;
    }

    /**
     * @return the order_clause_full
     */
    public Order_Clause_Full getOrder_clause_full() {
        return order_clause_full;
    }

    /**
     * @param order_clause_full the order_clause_full to set
     */
    public void setOrder_clause_full(Order_Clause_Full order_clause_full) {
        this.order_clause_full = order_clause_full;
    }

    /**
     * @return the select
     */
    public Select getSelect() {
        return select;
    }

    /**
     * @param select the select to set
     */
    public void setSelect(Select select) {
        this.select = select;
    }

}
