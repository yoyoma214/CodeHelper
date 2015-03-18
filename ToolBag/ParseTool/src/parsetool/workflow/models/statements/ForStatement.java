/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.workflow.models.statements;

import parsetool.models.common.TokenPair;
import parsetool.workflow.models.State;
import parsetool.workflow.models.expressions.Expression;
import parsetool.workflow.models.expressions.Logical_Or_Expression;

/**
 *
 * @author Administrator
 */
public class ForStatement extends TokenPair {
    private Declare_Statement declare_statement;
    private Logical_Or_Expression logical_or_expression;
    private Expression expression;
    private State state;

    /**
     * @return the declare_statement
     */
    public Declare_Statement getDeclare_statement() {
        return declare_statement;
    }

    /**
     * @param declare_statement the declare_statement to set
     */
    public void setDeclare_statement(Declare_Statement declare_statement) {
        this.declare_statement = declare_statement;
    }

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
