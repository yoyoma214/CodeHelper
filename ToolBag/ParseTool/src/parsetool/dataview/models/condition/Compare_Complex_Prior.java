/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.dataview.models.condition;

import parsetool.dataview.models.Search_Option;
import parsetool.dataview.models.option.Option_Expression;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Compare_Complex_Prior  extends TokenPair {
    private Compare_Complex_Mix_Or compare_complex_mix_or;
    private Compare_Complex compare_complex;
    private Search_Option search_option;
    
    /**
     * @return the compare_complex_mix_or
     */
    public Compare_Complex_Mix_Or getCompare_complex_mix_or() {
        return compare_complex_mix_or;
    }

    /**
     * @param compare_complex_mix_or the compare_complex_mix_or to set
     */
    public void setCompare_complex_mix_or(Compare_Complex_Mix_Or compare_complex_mix_or) {
        this.compare_complex_mix_or = compare_complex_mix_or;
    }

    /**
     * @return the compare_complex
     */
    public Compare_Complex getCompare_complex() {
        return compare_complex;
    }

    /**
     * @param compare_complex the compare_complex to set
     */
    public void setCompare_complex(Compare_Complex compare_complex) {
        this.compare_complex = compare_complex;
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
