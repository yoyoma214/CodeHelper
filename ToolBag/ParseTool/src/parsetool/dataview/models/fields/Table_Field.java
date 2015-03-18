/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.fields;

import parsetool.dataview.models.expression.Binary_Expression;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Table_Field extends TokenPair {
    private Table_Field_Atom table_field_atom;
    private Binary_Expression binary_expression;

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
     * @return the binary_expression
     */
    public Binary_Expression getBinary_expression() {
        return binary_expression;
    }

    /**
     * @param binary_expression the binary_expression to set
     */
    public void setBinary_expression(Binary_Expression binary_expression) {
        this.binary_expression = binary_expression;
    }
}
