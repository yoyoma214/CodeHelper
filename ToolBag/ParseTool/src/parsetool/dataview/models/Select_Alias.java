/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Select_Alias extends TokenPair{
    private Select_Atom select;
    private String alias;

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
     * @return the alias
     */
    public String getAlias() {
        return alias;
    }

    /**
     * @param alias the alias to set
     */
    public void setAlias(String alias) {
        this.alias = alias;
    }
}
