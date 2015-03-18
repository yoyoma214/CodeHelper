/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models;

import parsetool.dataview.models.option.Option_Expression;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Search_Option extends TokenPair{
    private Option_Expression option_expression;

    /**
     * @return the option_expression
     */
    public Option_Expression getOption_expression() {
        return option_expression;
    }

    /**
     * @param option_expression the option_expression to set
     */
    public void setOption_expression(Option_Expression option_expression) {
        this.option_expression = option_expression;
    }
}
