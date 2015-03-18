/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.dataview.models.fields;

import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Function_Parameter extends TokenPair{
    
    private Table_Field table_field; 

    /**
     * @return the table_field
     */
    public Table_Field getTable_field() {
        return table_field;
    }

    /**
     * @param table_field the table_field to set
     */
    public void setTable_field(Table_Field table_field) {
        this.table_field = table_field;
    }
}
