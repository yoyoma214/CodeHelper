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
public class Case_Else_Expression extends TokenPair{
    private Result_Expression_Prior result_expression_prior;

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
