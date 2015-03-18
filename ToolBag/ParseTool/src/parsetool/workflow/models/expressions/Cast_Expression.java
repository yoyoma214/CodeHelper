/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.workflow.models.expressions;

import parsetool.models.common.TokenPair;
import parsetool.workflow.models.Generic_Type;

/**
 *
 * @author cqy
 */
public class Cast_Expression extends TokenPair{
    private Generic_Type generic_type;
    private Cast_Expression cast_expression;    
    
    private Unary_Expression unary_expression;

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

    /**
     * @return the generic_type
     */
    public Generic_Type getGeneric_type() {
        return generic_type;
    }

    /**
     * @param generic_type the generic_type to set
     */
    public void setGeneric_type(Generic_Type generic_type) {
        this.generic_type = generic_type;
    }

   
}
