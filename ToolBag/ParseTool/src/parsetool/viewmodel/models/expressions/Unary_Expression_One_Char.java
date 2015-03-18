/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.viewmodel.models.expressions;

import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Unary_Expression_One_Char extends TokenPair {
    private String operator;
    private Cast_Expression cast_expression;

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
     * @return the cast_expression
     */
    public Cast_Expression getCast_expression() {
        return cast_expression;
    }

    /**
     * @param cast_expression the cast_expression to set
     */
    public void setCast_expression(Cast_Expression cast_expression) {
        this.cast_expression = cast_expression;
    }
}
