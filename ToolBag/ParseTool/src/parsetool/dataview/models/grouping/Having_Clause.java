/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.grouping;

import parsetool.dataview.models.condition.Condition_Clause;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Having_Clause extends TokenPair{
    private Condition_Clause condition;

    /**
     * @return the condition
     */
    public Condition_Clause getCondition() {
        return condition;
    }

    /**
     * @param condition the condition to set
     */
    public void setCondition(Condition_Clause condition) {
        this.condition = condition;
    }
}
