/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.grouping;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Having_Clause_Full extends TokenPair{
    private Having_Clause having_clause;

    /**
     * @return the having_clause
     */
    public Having_Clause getHaving_clause() {
        return having_clause;
    }

    /**
     * @param having_clause the having_clause to set
     */
    public void setHaving_clause(Having_Clause having_clause) {
        this.having_clause = having_clause;
    }
}
