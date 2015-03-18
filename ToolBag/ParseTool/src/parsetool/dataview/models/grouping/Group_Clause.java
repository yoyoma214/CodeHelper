/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.grouping;

import java.util.ArrayList;
import java.util.List;
import parsetool.dataview.models.fields.Field_Regular;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Group_Clause extends TokenPair{
    private List<Field_Regular> field_regulars = new ArrayList<Field_Regular>();
    private Having_Clause_Full having_clause_full;

    /**
     * @return the fields
     */
    public List<Field_Regular> getField_Regulars() {
        return field_regulars;
    }

    /**
     * @param fields the fields to set
     */
    public void setField_Regulars(List<Field_Regular> fields) {
        this.field_regulars = fields;
    }

    /**
     * @return the having_clause_full
     */
    public Having_Clause_Full getHaving_clause_full() {
        return having_clause_full;
    }

    /**
     * @param having_clause_full the having_clause_full to set
     */
    public void setHaving_clause_full(Having_Clause_Full having_clause_full) {
        this.having_clause_full = having_clause_full;
    }
}
