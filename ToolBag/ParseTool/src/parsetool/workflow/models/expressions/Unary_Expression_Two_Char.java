/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.workflow.models.expressions;

import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Unary_Expression_Two_Char extends TokenPair {
    private String operator;
    private Unary_Expression unary_expression;

    /**
     * @return the operator
     */
    public String getOperator() {
        return operator;
    }

    /**
     * @param operator the operator to set
     */
    public void setOperator(String operator) {
        this.operator = operator;
    }

    /**
     * @return the unary_expression
     */
    public Unary_Expression getUnary_expression() {
        return unary_expression;
    }

    /**
     * @param unary_expression the unary_expression to set
     */
    public void setUnary_expression(Unary_Expression unary_expression) {
        this.unary_expression = unary_expression;
    }
}
