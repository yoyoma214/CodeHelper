/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.dataview.models.fields.casewhen;

import parsetool.dataview.models.Value;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Case_Have_Target_When_Expression extends TokenPair{
    private Value value = null;
    private Result_Expression_Prior result_expression_prior = null;

    /**
     * @return the value
     */
    public Value getValue() {
        return value;
    }

    /**
     * @param value the value to set
     */
    public void setValue(Value value) {
        this.value = value;
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
