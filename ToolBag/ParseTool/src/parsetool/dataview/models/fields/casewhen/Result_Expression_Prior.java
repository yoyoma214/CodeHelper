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
public class Result_Expression_Prior extends TokenPair{
    private Result_Expression result_expression;

    /**
     * @return the result_expression
     */
    public Result_Expression getResult_expression() {
        return result_expression;
    }

    /**
     * @param result_expression the result_expression to set
     */
    public void setResult_expression(Result_Expression result_expression) {
        this.result_expression = result_expression;
    }
}
