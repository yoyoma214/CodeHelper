/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.condition.in;

import parsetool.dataview.models.condition.in.In_Expression;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class In_Expression_Prior extends TokenPair{
    private In_Expression in_expression;

    /**
     * @return the in_expression
     */
    public In_Expression getIn_expression() {
        return in_expression;
    }

    /**
     * @param in_expression the in_expression to set
     */
    public void setIn_expression(In_Expression in_expression) {
        this.in_expression = in_expression;
    }
}
