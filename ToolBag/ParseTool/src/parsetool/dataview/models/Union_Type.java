/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Union_Type extends TokenPair {
    private String union_type;

    /**
     * @return the union_type
     */
    public String getUnion_type() {
        return union_type;
    }

    /**
     * @param union_type the union_type to set
     */
    public void setUnion_type(String union_type) {
        this.union_type = union_type;
    }
}
