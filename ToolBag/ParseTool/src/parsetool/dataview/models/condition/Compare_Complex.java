/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.condition;

import parsetool.dataview.models.condition.exists.Existed_Compare_Prior;
import parsetool.dataview.models.condition.in.In_Expression_Prior;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Compare_Complex extends TokenPair{
    private Binary_Prior bianary_prior;
    private In_Expression_Prior in_expression_prior;
    private Between_Prior between_prior;
    private Existed_Compare_Prior existed_compare_prior;

    /**
     * @return the bianary_prior
     */
    public Binary_Prior getBianary_prior() {
        return bianary_prior;
    }

    /**
     * @param bianary_prior the bianary_prior to set
     */
    public void setBianary_prior(Binary_Prior bianary_prior) {
        this.bianary_prior = bianary_prior;
    }

    /**
     * @return the in_expression_prior
     */
    public In_Expression_Prior getIn_expression_prior() {
        return in_expression_prior;
    }

    /**
     * @param in_expression_prior the in_expression_prior to set
     */
    public void setIn_expression_prior(In_Expression_Prior in_expression_prior) {
        this.in_expression_prior = in_expression_prior;
    }

    /**
     * @return the between_prior
     */
    public Between_Prior getBetween_prior() {
        return between_prior;
    }

    /**
     * @param between_prior the between_prior to set
     */
    public void setBetween_prior(Between_Prior between_prior) {
        this.between_prior = between_prior;
    }

    /**
     * @return the existed_compare_prior
     */
    public Existed_Compare_Prior getExisted_compare_prior() {
        return existed_compare_prior;
    }

    /**
     * @param existed_compare_prior the existed_compare_prior to set
     */
    public void setExisted_compare_prior(Existed_Compare_Prior existed_compare_prior) {
        this.existed_compare_prior = existed_compare_prior;
    }
    
}
