/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.condition.in;

import parsetool.dataview.models.lists.Value_List;
import parsetool.dataview.models.parameters.Parameter;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class In_Right_Value extends TokenPair{
    private Parameter parameter;
    private In_List list;

    /**
     * @return the parameter
     */
    public Parameter getParameter() {
        return parameter;
    }

    /**
     * @param parameter the parameter to set
     */
    public void setParameter(Parameter parameter) {
        this.parameter = parameter;
    }

    /**
     * @return the list
     */
    public In_List getList() {
        return list;
    }

    /**
     * @param list the list to set
     */
    public void setList(In_List list) {
        this.list = list;
    }
}
