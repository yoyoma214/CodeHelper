/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.condition;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Condition_Clause extends TokenPair{
    private Compare_Complex_Mix_Or compare_complex_mix_or;
    //private List<String> relations = new ArrayList<String>();

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

}
