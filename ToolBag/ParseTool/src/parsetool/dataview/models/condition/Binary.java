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
public class Binary extends TokenPair{
    private Binary_Compare_Prior binary_compare_prior;

    /**
     * @return the binary_compare_prior
     */
    public Binary_Compare_Prior getBinary_compare_prior() {
        return binary_compare_prior;
    }

    /**
     * @param binary_compare_prior the binary_compare_prior to set
     */
    public void setBinary_compare_prior(Binary_Compare_Prior binary_compare_prior) {
        this.binary_compare_prior = binary_compare_prior;
    }
}
