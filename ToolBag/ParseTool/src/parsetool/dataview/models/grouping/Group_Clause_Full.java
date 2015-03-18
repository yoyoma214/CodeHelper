/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.grouping;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Group_Clause_Full extends TokenPair{
    private Group_Clause group_clause;

    /**
     * @return the group_clause
     */
    public Group_Clause getGroup_clause() {
        return group_clause;
    }

    /**
     * @param group_clause the group_clause to set
     */
    public void setGroup_clause(Group_Clause group_clause) {
        this.group_clause = group_clause;
    }
}
