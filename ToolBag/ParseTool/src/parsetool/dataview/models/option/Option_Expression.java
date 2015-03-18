/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.option;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Option_Expression extends TokenPair{
    private Option_List option_list;

    /**
     * @return the option_list
     */
    public Option_List getOption_list() {
        return option_list;
    }

    /**
     * @param option_list the option_list to set
     */
    public void setOption_list(Option_List option_list) {
        this.option_list = option_list;
    }
}
