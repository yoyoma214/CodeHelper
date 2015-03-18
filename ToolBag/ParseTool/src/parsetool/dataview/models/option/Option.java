/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.option;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Option extends TokenPair{
    private Option_Name option_name;
    private Option_Value option_value;

    /**
     * @return the option_name
     */
    public Option_Name getOption_name() {
        return option_name;
    }

    /**
     * @param option_name the option_name to set
     */
    public void setOption_name(Option_Name option_name) {
        this.option_name = option_name;
    }

    /**
     * @return the option_value
     */
    public Option_Value getOption_value() {
        return option_value;
    }

    /**
     * @param option_value the option_value to set
     */
    public void setOption_value(Option_Value option_value) {
        this.option_value = option_value;
    }
}
