/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.condition.exists;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Existed_Compare_Prior extends TokenPair{
    private Existed_Compare existed_compare;

    /**
     * @return the existed_compare
     */
    public Existed_Compare getExisted_compare() {
        return existed_compare;
    }

    /**
     * @param existed_compare the existed_compare to set
     */
    public void setExisted_compare(Existed_Compare existed_compare) {
        this.existed_compare = existed_compare;
    }
}
