/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.workflow.models;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Action extends TokenPair {
    private BeforeAction before;
    private AfterAction after;

    /**
     * @return the before
     */
    public BeforeAction getBefore() {
        return before;
    }

    /**
     * @param before the before to set
     */
    public void setBefore(BeforeAction before) {
        this.before = before;
    }

    /**
     * @return the after
     */
    public AfterAction getAfter() {
        return after;
    }

    /**
     * @param after the after to set
     */
    public void setAfter(AfterAction after) {
        this.after = after;
    }
}
