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
public class Conditional_Expression extends TokenPair{
    private Logical_Or_Expression logical_or_expression;
    private Expression second_expression;
    private Conditional_Expression third_expression;

    /**
     * @return the logical_or_expression
     */
    public Logical_Or_Expression getLogical_or_expression() {
        return logical_or_expression;
    }

    /**
     * @param logical_or_expression the logical_or_expression to set
     */
    public void setLogical_or_expression(Logical_Or_Expression logical_or_expression) {
        this.logical_or_expression = logical_or_expression;
    }

    /**
     * @return the second_expression
     */
    public Expression getSecond_expression() {
        return second_expression;
    }

    /**
     * @param second_expression the second_expression to set
     */
    public void setSecond_expression(Expression second_expression) {
        this.second_expression = second_expression;
    }

    /**
     * @return the third_expression
     */
    public Conditional_Expression getThird_expression() {
        return third_expression;
    }

    /**
     * @param third_expression the third_expression to set
     */
    public void setThird_expression(Conditional_Expression third_expression) {
        this.third_expression = third_expression;
    }
}
