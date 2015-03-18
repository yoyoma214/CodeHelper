/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.viewmodel.models.statements;

import parsetool.models.common.TokenPair;
import parsetool.viewmodel.models.expressions.Expression;

/**
 *
 * @author cqy
 */
public class Statement extends TokenPair{
    private Expression expression;
    private Declare_Statement declare_statement;
    private Push push;
    private Pull pull;

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
     * @return the push
     */
    public Push getPush() {
        return push;
    }

    /**
     * @param push the push to set
     */
    public void setPush(Push push) {
        this.push = push;
    }

    /**
     * @return the pull
     */
    public Pull getPull() {
        return pull;
    }

    /**
     * @param pull the pull to set
     */
    public void setPull(Pull pull) {
        this.pull = pull;
    }
}
