/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.dataview.models.condition.in;

import parsetool.dataview.models.lists.Select_List;
import parsetool.dataview.models.lists.Value_List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class In_List extends TokenPair{
    private Value_List value_list;
    private Select_List select_list;

    /**
     * @return the value_list
     */
    public Value_List getValue_list() {
        return value_list;
    }

    /**
     * @param value_list the value_list to set
     */
    public void setValue_list(Value_List value_list) {
        this.value_list = value_list;
    }

    /**
     * @return the select_list
     */
    public Select_List getSelect_list() {
        return select_list;
    }

    /**
     * @param select_list the select_list to set
     */
    public void setSelect_list(Select_List select_list) {
        this.select_list = select_list;
    }
}
