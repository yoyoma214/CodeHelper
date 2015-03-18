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
public class Postfix_Part extends TokenPair{
    private Postfix_Part_Index postfix_part_index;
    private Postfix_Part_Decrease postfix_part_decrease;
    private Postfix_Part_Empty_Function postfix_part_empty_function;
    private Postfix_Part_Function postfix_part_function;
    private Postfix_Part_Increase postfix_part_increase;
    private Postfix_Part_Long_Name postfix_part_long_name;

    /**
     * @return the postfix_part_index
     */
    public Postfix_Part_Index getPostfix_part_index() {
        return postfix_part_index;
    }

    /**
     * @param postfix_part_index the postfix_part_index to set
     */
    public void setPostfix_part_index(Postfix_Part_Index postfix_part_index) {
        this.postfix_part_index = postfix_part_index;
    }

    /**
     * @return the postfix_part_decrease
     */
    public Postfix_Part_Decrease getPostfix_part_decrease() {
        return postfix_part_decrease;
    }

    /**
     * @param postfix_part_decrease the postfix_part_decrease to set
     */
    public void setPostfix_part_decrease(Postfix_Part_Decrease postfix_part_decrease) {
        this.postfix_part_decrease = postfix_part_decrease;
    }

    /**
     * @return the postfix_part_empty_function
     */
    public Postfix_Part_Empty_Function getPostfix_part_empty_function() {
        return postfix_part_empty_function;
    }

    /**
     * @param postfix_part_empty_function the postfix_part_empty_function to set
     */
    public void setPostfix_part_empty_function(Postfix_Part_Empty_Function postfix_part_empty_function) {
        this.postfix_part_empty_function = postfix_part_empty_function;
    }

    /**
     * @return the postfix_part_function
     */
    public Postfix_Part_Function getPostfix_part_function() {
        return postfix_part_function;
    }

    /**
     * @param postfix_part_function the postfix_part_function to set
     */
    public void setPostfix_part_function(Postfix_Part_Function postfix_part_function) {
        this.postfix_part_function = postfix_part_function;
    }

    /**
     * @return the postfix_part_increase
     */
    public Postfix_Part_Increase getPostfix_part_increase() {
        return postfix_part_increase;
    }

    /**
     * @param postfix_part_increase the postfix_part_increase to set
     */
    public void setPostfix_part_increase(Postfix_Part_Increase postfix_part_increase) {
        this.postfix_part_increase = postfix_part_increase;
    }

    /**
     * @return the postfix_part_long_name
     */
    public Postfix_Part_Long_Name getPostfix_part_long_name() {
        return postfix_part_long_name;
    }

    /**
     * @param postfix_part_long_name the postfix_part_long_name to set
     */
    public void setPostfix_part_long_name(Postfix_Part_Long_Name postfix_part_long_name) {
        this.postfix_part_long_name = postfix_part_long_name;
    }
}
