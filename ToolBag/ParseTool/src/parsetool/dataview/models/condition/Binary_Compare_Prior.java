/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.condition;

import parsetool.dataview.models.Search_Option;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Binary_Compare_Prior extends TokenPair{
    private Binary_Compare binary_compare;
    private Condition_Option condition_option;
    private Search_Option search_option;
    /**
     * @return the binary_compare
     */
    public Binary_Compare getBinary_compare() {
        return binary_compare;
    }

    /**
     * @param binary_compare the binary_compare to set
     */
    public void setBinary_compare(Binary_Compare binary_compare) {
        this.binary_compare = binary_compare;
    }

    /**
     * @return the condition_option
     */
    public Condition_Option getCondition_option() {
        return condition_option;
    }

    /**
     * @param condition_option the condition_option to set
     */
    public void setCondition_option(Condition_Option condition_option) {
        this.condition_option = condition_option;
    }

    /**
     * @return the search_option
     */
    public Search_Option getSearch_option() {
        return search_option;
    }

    /**
     * @param search_option the search_option to set
     */
    public void setSearch_option(Search_Option search_option) {
        this.search_option = search_option;
    }
}
