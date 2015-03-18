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
public class Postfix_Part_Index extends TokenPair{
    private Expression expression;

    /**
     * @return the expression
     */
    public Expression getExpression() {
        return expression;
    }

    /**
     * @param expression the expression to set
     */
    public void setExpression(Expression expression) {
        this.expression = expression;
    }
}
