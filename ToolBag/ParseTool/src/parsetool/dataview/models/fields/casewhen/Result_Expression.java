/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.fields.casewhen;

import parsetool.dataview.models.Select_Atom;
import parsetool.dataview.models.Value;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Result_Expression extends TokenPair{
    private Value value;
    //private Select_Atom select;

    /**
     * @return the value
     */
    public Value getValue() {
        return value;
    }

    /**
     * @param value the value to set
     */
    public void setValue(Value value) {
        this.value = value;
    }
}
