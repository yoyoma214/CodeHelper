/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.join;

import parsetool.dataview.models.condition.Condition_Clause;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Join_On_Clause extends TokenPair{
    private Condition_Clause condition_clause;

    /**
     * @return the condition_clause
     */
    public Condition_Clause getCondition_clause() {
        return condition_clause;
    }

    /**
     * @param condition_clause the condition_clause to set
     */
    public void setCondition_clause(Condition_Clause condition_clause) {
        this.condition_clause = condition_clause;
    }
}
