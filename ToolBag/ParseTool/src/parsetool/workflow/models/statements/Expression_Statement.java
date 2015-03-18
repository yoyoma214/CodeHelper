/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.workflow.models.statements;

import parsetool.models.common.TokenPair;
import parsetool.workflow.models.expressions.Expression;

/**
 *
 * @author Administrator
 */
public class Expression_Statement extends TokenPair {
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
