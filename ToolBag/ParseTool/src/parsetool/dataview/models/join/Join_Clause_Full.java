/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.dataview.models.join;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Join_Clause_Full extends TokenPair{
    
    private List<Join_Clause> join_clause_list = new ArrayList<Join_Clause>();

    /**
     * @return the join_clause_list
     */
    public List<Join_Clause> getJoin_clause_list() {
        return join_clause_list;
    }

    /**
     * @param join_clause_list the join_clause_list to set
     */
    public void setJoin_clause_list(List<Join_Clause> join_clause_list) {
        this.join_clause_list = join_clause_list;
    }
    
}
