/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.condition;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Condition_Option extends TokenPair{
    private String option;

    /**
     * @return the option
     */
    public String getOption() {
        return option;
    }

    /**
     * @param option the option to set
     */
    public void setOption(String option) {
        this.option = option;
    }
}
