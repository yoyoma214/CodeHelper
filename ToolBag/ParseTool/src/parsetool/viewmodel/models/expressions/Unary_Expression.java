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
public class Unary_Expression extends TokenPair{
    private Postfix_Expression postfix_expression;
    private Unary_Expression_One_Char unary_expression_one_char;
    private Unary_Expression_Two_Char unary_expression_two_char;

    /**
     * @return the postfix_expression
     */
    public Postfix_Expression getPostfix_expression() {
        return postfix_expression;
    }

    /**
     * @param postfix_expression the postfix_expression to set
     */
    public void setPostfix_expression(Postfix_Expression postfix_expression) {
        this.postfix_expression = postfix_expression;
    }

    /**
     * @return the unary_expression_one_char
     */
    public Unary_Expression_One_Char getUnary_expression_one_char() {
        return unary_expression_one_char;
    }

    /**
     * @param unary_expression_one_char the unary_expression_one_char to set
     */
    public void setUnary_expression_one_char(Unary_Expression_One_Char unary_expression_one_char) {
        this.unary_expression_one_char = unary_expression_one_char;
    }

    /**
     * @return the unary_expression_two_char
     */
    public Unary_Expression_Two_Char getUnary_expression_two_char() {
        return unary_expression_two_char;
    }

    /**
     * @param unary_expression_two_char the unary_expression_two_char to set
     */
    public void setUnary_expression_two_char(Unary_Expression_Two_Char unary_expression_two_char) {
        this.unary_expression_two_char = unary_expression_two_char;
    }
}
