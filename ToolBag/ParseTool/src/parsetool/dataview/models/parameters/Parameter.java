/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.dataview.models.parameters;

import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Parameter extends TokenPair{
    private Parameter_Name parameter_name;

    /**
     * @return the parameter_name
     */
    public Parameter_Name getParameter_name() {
        return parameter_name;
    }

    /**
     * @param parameter_name the parameter_name to set
     */
    public void setParameter_name(Parameter_Name parameter_name) {
        this.parameter_name = parameter_name;
    }
}
