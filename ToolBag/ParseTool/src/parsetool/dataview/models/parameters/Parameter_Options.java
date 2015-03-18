/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.dataview.models.parameters;

import parsetool.dataview.models.option.Option_Expression;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Parameter_Options extends TokenPair{
    
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
