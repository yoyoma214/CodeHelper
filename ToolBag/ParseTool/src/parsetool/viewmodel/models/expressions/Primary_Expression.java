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
public class Primary_Expression extends TokenPair{
    private String id;
    private Constant constant;
    private Expression expression;
    
    private boolean isId;
    private boolean isConstant;
    private boolean isExpression;

    /**
     * @return the id
     */
    public String getId() {
        return id;
    }

    /**
     * @param id the id to set
     */
    public void setId(String id) {
        this.id = id;
    }

    /**
     * @return the constant
     */
    public Constant getConstant() {
        return constant;
    }

    /**
     * @param constant the constant to set
     */
    public void setConstant(Constant constant) {
        this.constant = constant;
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
     * @return the isId
     */
    public boolean isIsId() {
        return isId;
    }

    /**
     * @param isId the isId to set
     */
    public void setIsId(boolean isId) {
        this.isId = isId;
    }

    /**
     * @return the isConstant
     */
    public boolean isIsConstant() {
        return isConstant;
    }

    /**
     * @param isConstant the isConstant to set
     */
    public void setIsConstant(boolean isConstant) {
        this.isConstant = isConstant;
    }

    /**
     * @return the isExpression
     */
    public boolean isIsExpression() {
        return isExpression;
    }

    /**
     * @param isExpression the isExpression to set
     */
    public void setIsExpression(boolean isExpression) {
        this.isExpression = isExpression;
    }
}
