/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.fields;

import parsetool.dataview.models.fields.Table_Field_Atom;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Table_Field_Alias extends TokenPair{
    private String alias;
    private Table_Field table_field;

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
