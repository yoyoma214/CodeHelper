/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.dataview.models;

import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Table_All_Field extends TokenPair{
    private String Name;

    /**
     * @return the Name
     */
    public String getName() {
        return Name;
    }

    /**
     * @param Name the Name to set
     */
    public void setName(String Name) {
        this.Name = Name;
    }
}
