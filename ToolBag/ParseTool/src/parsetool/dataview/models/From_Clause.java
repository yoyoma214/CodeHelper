/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class From_Clause extends TokenPair{
    private Select_Alias select_alias;
    private List<Table_Alias> table_alias_list = new ArrayList<Table_Alias>();
    /**
     * @return the select_alias
     */
    public Select_Alias getSelect_alias() {
        return select_alias;
    }

    /**
     * @param select_alias the select_alias to set
     */
    public void setSelect_alias(Select_Alias select_alias) {
        this.select_alias = select_alias;
    }

    /**
     * @return the table_alias_list
     */
    public List<Table_Alias> getTable_alias_list() {
        return table_alias_list;
    }

    /**
     * @param table_alias_list the table_alias_list to set
     */
    public void setTable_alias_list(List<Table_Alias> table_alias_list) {
        this.table_alias_list = table_alias_list;
    }
}
