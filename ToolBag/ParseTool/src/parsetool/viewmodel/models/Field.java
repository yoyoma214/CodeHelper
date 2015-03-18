/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.viewmodel.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;
import parsetool.viewmodel.models.statements.Declare;

/**
 *
 * @author cqy
 */
public class Field extends TokenPair{
    private Declare declare;
    private List<Option> options = new ArrayList<Option>();    

    /**
     * @return the declare
     */
    public Declare getDeclare() {
        return declare;
    }

    /**
     * @param declare the declare to set
     */
    public void setDeclare(Declare declare) {
        this.declare = declare;
    }

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
