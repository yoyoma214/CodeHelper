/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.fields.casewhen;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Case_Clause_Prior extends TokenPair{
    private Case_Clause case_clause;

    /**
     * @return the case_clause
     */
    public Case_Clause getCase_clause() {
        return case_clause;
    }

    /**
     * @param case_clause the case_clause to set
     */
    public void setCase_clause(Case_Clause case_clause) {
        this.case_clause = case_clause;
    }
}
