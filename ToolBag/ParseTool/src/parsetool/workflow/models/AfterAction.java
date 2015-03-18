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
public class AfterAction extends TokenPair {
    private State state;

    /**
     * @return the state
     */
    public State getState() {
        return state;
    }

    /**
     * @param state the state to set
     */
    public void setState(State state) {
        this.state = state;
    }
}
