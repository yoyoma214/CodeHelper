/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.viewmodel.models.expressions;

import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Constant extends TokenPair{
    private String value;
    private boolean is_hex;
    private boolean is_octal;
    private boolean is_decimal;
    private boolean is_char;
    private boolean is_string;
    private boolean is_float;
    private boolean is_bool;

    /**
     * @return the value
     */
    public String getValue() {
        return value;
    }

    /**
     * @param value the value to set
     */
    public void setValue(String value) {
        this.value = value;
    }

    /**
     * @return the is_hex
     */
    public boolean isIs_hex() {
        return is_hex;
    }

    /**
     * @param is_hex the is_hex to set
     */
    public void setIs_hex(boolean is_hex) {
        this.is_hex = is_hex;
    }

    /**
     * @return the is_octal
     */
    public boolean isIs_octal() {
        return is_octal;
    }

    /**
     * @param is_octal the is_octal to set
     */
    public void setIs_octal(boolean is_octal) {
        this.is_octal = is_octal;
    }

    /**
     * @return the is_decimal
     */
    public boolean isIs_decimal() {
        return is_decimal;
    }

    /**
     * @param is_decimal the is_decimal to set
     */
    public void setIs_decimal(boolean is_decimal) {
        this.is_decimal = is_decimal;
    }

    /**
     * @return the is_char
     */
    public boolean isIs_char() {
        return is_char;
    }

    /**
     * @param is_char the is_char to set
     */
    public void setIs_char(boolean is_char) {
        this.is_char = is_char;
    }

    /**
     * @return the is_string
     */
    public boolean isIs_string() {
        return is_string;
    }

    /**
     * @param is_string the is_string to set
     */
    public void setIs_string(boolean is_string) {
        this.is_string = is_string;
    }

    /**
     * @return the is_float
     */
    public boolean isIs_float() {
        return is_float;
    }

    /**
     * @param is_float the is_float to set
     */
    public void setIs_float(boolean is_float) {
        this.is_float = is_float;
    }

    /**
     * @return the is_bool
     */
    public boolean isIs_bool() {
        return is_bool;
    }

    /**
     * @param is_bool the is_bool to set
     */
    public void setIs_bool(boolean is_bool) {
        this.is_bool = is_bool;
    }
}
