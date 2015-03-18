/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.orders;

import parsetool.dataview.models.fields.Field_Regular;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Order_Expression extends TokenPair{
    private Field_Regular field_regular;
    private boolean is_asc;
    private boolean is_desc;

    /**
     * @return the is_asc
     */
    public boolean isIs_asc() {
        return is_asc;
    }

    /**
     * @param is_asc the is_asc to set
     */
    public void setIs_asc(boolean is_asc) {
        this.is_asc = is_asc;
    }

    /**
     * @return the is_desc
     */
    public boolean isIs_desc() {
        return is_desc;
    }

    /**
     * @param is_desc the is_desc to set
     */
    public void setIs_desc(boolean is_desc) {
        this.is_desc = is_desc;
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
}
