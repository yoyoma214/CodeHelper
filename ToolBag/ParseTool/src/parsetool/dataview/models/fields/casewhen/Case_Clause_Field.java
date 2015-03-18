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
public class Case_Clause_Field extends TokenPair{
    private Case_Clause_Prior case_clause_prior;

    /**
     * @return the case_clause_prior
     */
    public Case_Clause_Prior getCase_clause_prior() {
        return case_clause_prior;
    }

    /**
     * @param case_clause_prior the case_clause_prior to set
     */
    public void setCase_clause_prior(Case_Clause_Prior case_clause_prior) {
        this.case_clause_prior = case_clause_prior;
    }
}
