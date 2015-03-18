/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.dataview.models.condition;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Compare_Complex_Mix_Or extends TokenPair {
    
    private List<Compare_Complex_Mix_And> compare_complex_mix_ands = 
            new ArrayList<Compare_Complex_Mix_And>();

    /**
     * @return the compare_complex_mix_ands
     */
    public List<Compare_Complex_Mix_And> getCompare_complex_mix_ands() {
        return compare_complex_mix_ands;
    }

    /**
     * @param compare_complex_mix_ands the compare_complex_mix_ands to set
     */
    public void setCompare_complex_mix_ands(List<Compare_Complex_Mix_And> compare_complex_mix_ands) {
        this.compare_complex_mix_ands = compare_complex_mix_ands;
    }
    
}
