/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.expression;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Positive_Expression extends TokenPair{
    private String operator;
    private Unary_Operator unary_operator;

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
     * @return the unary_operator
     */
    public Unary_Operator getUnary_operator() {
        return unary_operator;
    }

    /**
     * @param unary_operator the unary_operator to set
     */
    public void setUnary_operator(Unary_Operator unary_operator) {
        this.unary_operator = unary_operator;
    }
}
