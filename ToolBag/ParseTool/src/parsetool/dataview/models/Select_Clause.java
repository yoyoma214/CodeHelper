/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.dataview.models.fields.Table_Field_Alias;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Select_Clause extends TokenPair{
    private List<Table_Field_Alias> table_field_alias_list = new ArrayList<Table_Field_Alias>();

    /**
     * @return the table_field_alias_list
     */
    public List<Table_Field_Alias> getTable_field_alias_list() {
        return table_field_alias_list;
    }

    /**
     * @param table_field_alias_list the table_field_alias_list to set
     */
    public void setTable_field_alias_list(List<Table_Field_Alias> table_field_alias_list) {
        this.table_field_alias_list = table_field_alias_list;
    }
}
