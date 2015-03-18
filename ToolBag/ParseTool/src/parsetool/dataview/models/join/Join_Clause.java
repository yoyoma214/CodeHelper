/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.join;

import parsetool.dataview.models.Table_Alias;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Join_Clause extends TokenPair{
   private String join_type;
   private Table_Alias table_alias;
   private Join_On_Clause join_on_clause;

    /**
     * @return the join_type
     */
    public String getJoin_type() {
        return join_type;
    }

    /**
     * @param join_type the join_type to set
     */
    public void setJoin_type(String join_type) {
        this.join_type = join_type;
    }

    /**
     * @return the table_alias
     */
    public Table_Alias getTable_alias() {
        return table_alias;
    }

    /**
     * @param table_alias the table_alias to set
     */
    public void setTable_alias(Table_Alias table_alias) {
        this.table_alias = table_alias;
    }

    /**
     * @return the join_on_clause
     */
    public Join_On_Clause getJoin_on_clause() {
        return join_on_clause;
    }

    /**
     * @param join_on_clause the join_on_clause to set
     */
    public void setJoin_on_clause(Join_On_Clause join_on_clause) {
        this.join_on_clause = join_on_clause;
    }
}
