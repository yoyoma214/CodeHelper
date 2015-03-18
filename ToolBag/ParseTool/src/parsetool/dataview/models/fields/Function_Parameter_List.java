/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.fields;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Function_Parameter_List extends TokenPair{
    
    private List<Function_Parameter> function_parameters;
    
    public Function_Parameter_List()
    {
        function_parameters = new ArrayList<Function_Parameter>();
    }

    /**
     * @return the function_parameters
     */
    public List<Function_Parameter> getFunction_parameters() {
        return function_parameters;
    }

    /**
     * @param function_parameters the function_parameters to set
     */
    public void setFunction_parameters(List<Function_Parameter> function_parameters) {
        this.function_parameters = function_parameters;
    }
}
