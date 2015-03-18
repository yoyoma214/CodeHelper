/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.expression;

import java.util.ArrayList;
import java.util.List;
import parsetool.dataview.models.fields.Table_Field_Atom;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Unary_Operator extends TokenPair{
    private String operator ;
    private Table_Field_Atom table_field_atom;

    /**
     * @return the table_field_atom
     */
    public Table_Field_Atom getTable_field_atom() {
        return table_field_atom;
    }

    /**
     * @param table_field_atom the table_field_atom to set
     */
    public void setTable_field_atom(Table_Field_Atom table_field_atom) {
        this.table_field_atom = table_field_atom;
    }

    /**
     * @return the operator
     */
    public String getOperator() {
        return operator;
    }

    /**
     * @param operator the operator to set
     */
    public void setOperator(String operator) {
        this.operator = operator;
    }


}
