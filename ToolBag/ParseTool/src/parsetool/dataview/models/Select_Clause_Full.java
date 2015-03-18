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
public class Select_Clause_Full extends TokenPair{
    private Select_Clause select_clause;
    private Top_Clause top_clause;
    /**
     * @return the select_clause
     */
    public Select_Clause getSelect_clause() {
        return select_clause;
    }

    /**
     * @param select_clause the select_clause to set
     */
    public void setSelect_clause(Select_Clause select_clause) {
        this.select_clause = select_clause;
    }

    /**
     * @return the top_clause
     */
    public Top_Clause getTop_clause() {
        return top_clause;
    }

    /**
     * @param top_clause the top_clause to set
     */
    public void setTop_clause(Top_Clause top_clause) {
        this.top_clause = top_clause;
    }
}
