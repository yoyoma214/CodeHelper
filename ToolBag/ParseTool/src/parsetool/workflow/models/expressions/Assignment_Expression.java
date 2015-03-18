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
public class Assignment_Expression extends TokenPair{
    private String lvalue;
    private String operator;
    private Assignment_Expression assignment_expression;
    private Conditional_Expression conditional_expression;

    /**
     * @return the lvalue
     */
    public String getLvalue() {
        return lvalue;
    }

    /**
     * @param lvalue the lvalue to set
     */
    public void setLvalue(String lvalue) {
        this.lvalue = lvalue;
    }

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
     * @return the assignment_expression
     */
    public Assignment_Expression getAssignment_expression() {
        return assignment_expression;
    }

    /**
     * @param assignment_expression the assignment_expression to set
     */
    public void setAssignment_expression(Assignment_Expression assignment_expression) {
        this.assignment_expression = assignment_expression;
    }

    /**
     * @return the conditional_expression
     */
    public Conditional_Expression getConditional_expression() {
        return conditional_expression;
    }

    /**
     * @param conditional_expression the conditional_expression to set
     */
    public void setConditional_expression(Conditional_Expression conditional_expression) {
        this.conditional_expression = conditional_expression;
    }
}
