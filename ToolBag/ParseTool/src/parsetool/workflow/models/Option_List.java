/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.workflow.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Option_List extends TokenPair{
    
    private List<Option> options = new ArrayList<Option>();

    /**
     * @return the options
     */
    public List<Option> getOptions() {
        return options;
    }

    /**
     * @param options the options to set
     */
    public void setOptions(List<Option> options) {
        this.options = options;
    }
}
