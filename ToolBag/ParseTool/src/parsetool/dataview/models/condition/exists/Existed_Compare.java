/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.condition.exists;

import parsetool.dataview.models.Select_Atom;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Existed_Compare extends TokenPair{
    private boolean is_existed;
    private boolean is_not_existed;
    private Select_Atom select;

    /**
     * @return the select
     */
    public Select_Atom getSelect() {
        return select;
    }

    /**
     * @param select the select to set
     */
    public void setSelect(Select_Atom select) {
        this.select = select;
    }

    /**
     * @return the is_existed
     */
    public boolean isIs_existed() {
        return is_existed;
    }

    /**
     * @param is_existed the is_existed to set
     */
    public void setIs_existed(boolean is_existed) {
        this.is_existed = is_existed;
    }

    /**
     * @return the is_not_existed
     */
    public boolean isIs_not_existed() {
        return is_not_existed;
    }

    /**
     * @param is_not_existed the is_not_existed to set
     */
    public void setIs_not_existed(boolean is_not_existed) {
        this.is_not_existed = is_not_existed;
    }
}
