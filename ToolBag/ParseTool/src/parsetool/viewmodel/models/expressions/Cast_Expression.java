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
public class Cast_Expression extends TokenPair{
    private String type_name;
    private Cast_Expression cast_expression;    
    
    private Unary_Expression unary_expression;

    /**
     * @return the type_name
     */
    public String getType_name() {
        return type_name;
    }

    /**
     * @param type_name the type_name to set
     */
    public void setType_name(String type_name) {
        this.type_name = type_name;
    }

    /**
     * @return the cast_expression
     */
    public Cast_Expression getCast_expression() {
        return cast_expression;
    }

    /**
     * @param cast_expression the cast_expression to set
     */
    public void setCast_expression(Cast_Expression cast_expression) {
        this.cast_expression = cast_expression;
    }

    /**
     * @return the unary_expression
     */
    public Unary_Expression getUnary_expression() {
        return unary_expression;
    }

    /**
     * @param unary_expression the unary_expression to set
     */
    public void setUnary_expression(Unary_Expression unary_expression) {
        this.unary_expression = unary_expression;
    }
}
