/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.condition.in;

import parsetool.dataview.models.fields.Table_Field;
import parsetool.dataview.models.fields.Table_Field_Atom;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class In_Expression extends TokenPair{
    private Table_Field table_field;
    private In_Keyword in_keyword;
    private In_Right_Value in_right_value;

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

    /**
     * @return the in_keyword
     */
    public In_Keyword getIn_keyword() {
        return in_keyword;
    }

    /**
     * @param in_keyword the in_keyword to set
     */
    public void setIn_keyword(In_Keyword in_keyword) {
        this.in_keyword = in_keyword;
    }

    /**
     * @return the in_right_value
     */
    public In_Right_Value getIn_right_value() {
        return in_right_value;
    }

    /**
     * @param in_right_value the in_right_value to set
     */
    public void setIn_right_value(In_Right_Value in_right_value) {
        this.in_right_value = in_right_value;
    }


}
