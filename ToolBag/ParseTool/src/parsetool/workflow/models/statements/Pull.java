/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.workflow.models.statements;

import parsetool.models.common.TokenPair;
import parsetool.viewmodel.models.expressions.Expression;

/**
 *
 * @author cqy
 */
public class Pull extends TokenPair{
    private String lvalue;
    private Expression expression;

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
