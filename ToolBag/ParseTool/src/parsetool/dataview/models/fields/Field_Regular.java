/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.fields;

import parsetool.dataview.models.Long_Name;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Field_Regular extends TokenPair{
    private Long_Name long_name;

    /**
     * @return the long_name
     */
    public Long_Name getLong_name() {
        return long_name;
    }

    /**
     * @param long_name the long_name to set
     */
    public void setLong_name(Long_Name long_name) {
        this.long_name = long_name;
    }
}
