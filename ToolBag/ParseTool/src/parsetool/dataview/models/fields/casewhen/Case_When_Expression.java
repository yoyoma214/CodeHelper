/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.fields.casewhen;

import parsetool.dataview.models.Condition_Clause_Prior;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Case_When_Expression extends TokenPair{
    private Condition_Clause_Prior condition_clause_prior ;
    private Result_Expression_Prior result_expression_prior;

    /**
     * @return the condition_clause_prior
     */
    public Condition_Clause_Prior getCondition_clause_prior() {
        return condition_clause_prior;
    }

    /**
     * @param condition_clause_prior the condition_clause_prior to set
     */
    public void setCondition_clause_prior(Condition_Clause_Prior condition_clause_prior) {
        this.condition_clause_prior = condition_clause_prior;
    }

    /**
     * @return the result_expression_prior
     */
    public Result_Expression_Prior getResult_expression_prior() {
        return result_expression_prior;
    }

    /**
     * @param result_expression_prior the result_expression_prior to set
     */
    public void setResult_expression_prior(Result_Expression_Prior result_expression_prior) {
        this.result_expression_prior = result_expression_prior;
    }
}
