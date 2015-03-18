/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.lists;

import java.util.ArrayList;
import java.util.List;
import parsetool.dataview.models.Value;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Value_List extends TokenPair{
   private List<Value> values = new ArrayList<Value>();

    /**
     * @return the values
     */
    public List<Value> getValues() {
        return values;
    }

    /**
     * @param values the values to set
     */
    public void setValues(List<Value> values) {
        this.values = values;
    }
}
