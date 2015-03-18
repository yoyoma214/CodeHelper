/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.fields;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Function_Field extends TokenPair{
    private String name;
    private Function_Parameter_List function_parameter_list;

    /**
     * @return the name
     */
    public String getName() {
        return name;
    }

    /**
     * @param name the name to set
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * @return the function_parameter_list
     */
    public Function_Parameter_List getFunction_parameter_list() {
        return function_parameter_list;
    }

    /**
     * @param function_parameter_list the function_parameter_list to set
     */
    public void setFunction_parameter_list(Function_Parameter_List function_parameter_list) {
        this.function_parameter_list = function_parameter_list;
    }
}
