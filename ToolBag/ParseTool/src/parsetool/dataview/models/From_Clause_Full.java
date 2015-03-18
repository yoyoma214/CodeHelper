/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class From_Clause_Full extends TokenPair{
    private From_Clause from_clause;

    /**
     * @return the from_clause
     */
    public From_Clause getFrom_clause() {
        return from_clause;
    }

    /**
     * @param from_clause the from_clause to set
     */
    public void setFrom_clause(From_Clause from_clause) {
        this.from_clause = from_clause;
    }
}
