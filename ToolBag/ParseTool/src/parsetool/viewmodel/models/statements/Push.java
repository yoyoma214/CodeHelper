/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.viewmodel.models.statements;

import parsetool.models.common.TokenPair;
import parsetool.viewmodel.models.State;
import parsetool.viewmodel.models.expressions.Expression;

/**
 *
 * @author cqy
 */
public class Push extends TokenPair{
    private Expression expression;
    private State state;

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

    /**
     * @return the state
     */
    public State getState() {
        return state;
    }

    /**
     * @param state the state to set
     */
    public void setState(State state) {
        this.state = state;
    }
}
