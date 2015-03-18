/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.workflow.models.expressions;

import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Postfix_Part_Function extends TokenPair{
    private Argument_Expression_List argument_expression_list;

    /**
     * @return the argument_expression_list
     */
    public Argument_Expression_List getArgument_expression_list() {
        return argument_expression_list;
    }

    /**
     * @param argument_expression_list the argument_expression_list to set
     */
    public void setArgument_expression_list(Argument_Expression_List argument_expression_list) {
        this.argument_expression_list = argument_expression_list;
    }
}
