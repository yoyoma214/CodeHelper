/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.lists;

import parsetool.dataview.models.Select;
import parsetool.dataview.models.Select_Atom;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Select_List extends TokenPair{
    private Select select ;

    /**
     * @return the select
     */
    public Select getSelect() {
        return select;
    }

    /**
     * @param select the select to set
     */
    public void setSelect(Select select) {
        this.select = select;
    }
}
