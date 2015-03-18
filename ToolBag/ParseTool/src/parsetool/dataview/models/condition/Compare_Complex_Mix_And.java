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
public class Compare_Complex_Mix_And extends TokenPair {
    private List<Compare_Complex_Prior> compare_complex_priors
            = new ArrayList<Compare_Complex_Prior>();

    /**
     * @return the compare_complex_priors
     */
    public List<Compare_Complex_Prior> getCompare_complex_priors() {
        return compare_complex_priors;
    }

    /**
     * @param compare_complex_priors the compare_complex_priors to set
     */
    public void setCompare_complex_priors(List<Compare_Complex_Prior> compare_complex_priors) {
        this.compare_complex_priors = compare_complex_priors;
    }
    
}
