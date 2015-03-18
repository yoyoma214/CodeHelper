/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.fields;

import parsetool.dataview.models.All_Field;
import parsetool.dataview.models.Table_All_Field;
import parsetool.dataview.models.Value;
import parsetool.dataview.models.expression.Binary_Expression;
import parsetool.dataview.models.fields.casewhen.Case_Clause_Field;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Table_Field_Atom extends TokenPair{
    private Value value;
    private All_Field all_field;
    private Table_All_Field table_all_field;
    private Field_Regular field_regular;
    private Case_Clause_Field case_clause_field;
    private Function_Field function_field;

    private Binary_Expression binary_expression;
    /**
     * @return the value
     */
    public Value getValue() {
        return value;
    }

    /**
     * @param value the value to set
     */
    public void setValue(Value value) {
        this.value = value;
    }

    /**
     * @return the all_field
     */
    public All_Field getAll_field() {
        return all_field;
    }

    /**
     * @param all_field the all_field to set
     */
    public void setAll_field(All_Field all_field) {
        this.all_field = all_field;
    }

    /**
     * @return the table_all_field
     */
    public Table_All_Field getTable_all_field() {
        return table_all_field;
    }

    /**
     * @param table_all_field the table_all_field to set
     */
    public void setTable_all_field(Table_All_Field table_all_field) {
        this.table_all_field = table_all_field;
    }

    /**
     * @return the field_regular
     */
    public Field_Regular getField_regular() {
        return field_regular;
    }

    /**
     * @param field_regular the field_regular to set
     */
    public void setField_regular(Field_Regular field_regular) {
        this.field_regular = field_regular;
    }

    /**
     * @return the case_clause_field
     */
    public Case_Clause_Field getCase_clause_field() {
        return case_clause_field;
    }

    /**
     * @param case_clause_field the case_clause_field to set
     */
    public void setCase_clause_field(Case_Clause_Field case_clause_field) {
        this.case_clause_field = case_clause_field;
    }

    /**
     * @return the function_field
     */
    public Function_Field getFunction_field() {
        return function_field;
    }

    /**
     * @param function_field the function_field to set
     */
    public void setFunction_field(Function_Field function_field) {
        this.function_field = function_field;
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
