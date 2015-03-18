/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.option;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Option_List extends TokenPair{
    
    private List<Option> options = new ArrayList<Option>();

    /**
     * @return the options
     */
    public List<Option> getOptions() {
        return options;
    }
}
