/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models;

import parsetool.dataview.models.lists.Select_List;
import parsetool.dataview.models.parameters.Parameter;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Value extends TokenPair{
    private boolean is_bool;
    private boolean is_int;
    private boolean is_float;
    private boolean is_char;
    private boolean is_string;
    private boolean is_parameter;
    private boolean is_select_list;
    private boolean is_option_string;
    
    private Select_List select_list;
    
    private String value;
    
    private Parameter parameter;
    private String long_name;

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

    /**
     * @return the is_int
     */
    public boolean isIs_int() {
        return is_int;
    }

    /**
     * @param is_int the is_int to set
     */
    public void setIs_int(boolean is_int) {
        this.is_int = is_int;
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
     * @return the is_parameter
     */
    public boolean isIs_parameter() {
        return is_parameter;
    }

    /**
     * @param is_parameter the is_parameter to set
     */
    public void setIs_parameter(boolean is_parameter) {
        this.is_parameter = is_parameter;
    }

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
     * @return the parameter
     */
    public Parameter getParameter() {
        return parameter;
    }

    /**
     * @param parameter the parameter to set
     */
    public void setParameter(Parameter parameter) {
        this.parameter = parameter;
    }

    /**
     * @return the select_list
     */
    public Select_List getSelect_list() {
        return select_list;
    }

    /**
     * @param select_list the select_list to set
     */
    public void setSelect_list(Select_List select_list) {
        this.select_list = select_list;
    }

    /**
     * @return the is_select_list
     */
    public boolean isIs_select_list() {
        return is_select_list;
    }

    /**
     * @param is_select_list the is_select_list to set
     */
    public void setIs_select_list(boolean is_select_list) {
        this.is_select_list = is_select_list;
    }

    /**
     * @return the long_name
     */
    public String getLong_name() {
        return long_name;
    }

    /**
     * @param long_name the long_name to set
     */
    public void setLong_name(String long_name) {
        this.long_name = long_name;
    }

    /**
     * @return the is_option_string
     */
    public boolean isIs_option_string() {
        return is_option_string;
    }

    /**
     * @param is_option_string the is_option_string to set
     */
    public void setIs_option_string(boolean is_option_string) {
        this.is_option_string = is_option_string;
    }
}
