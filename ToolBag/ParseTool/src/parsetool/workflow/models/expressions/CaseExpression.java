/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.workflow.models.expressions;

import parsetool.models.common.TokenPair;
import parsetool.workflow.models.State;

/**
 *
 * @author Administrator
 */
public class CaseExpression extends TokenPair{
    private Boolean isDefault;
    private Constant constant;
    private State state;
    private Boolean hasBreak;

    /**
     * @return the isDefault
     */
    public Boolean getIsDefault() {
        return isDefault;
    }

    /**
     * @param isDefault the isDefault to set
     */
    public void setIsDefault(Boolean isDefault) {
        this.isDefault = isDefault;
    }

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

    /**
     * @return the hasBreak
     */
    public Boolean getHasBreak() {
        return hasBreak;
    }

    /**
     * @param hasBreak the hasBreak to set
     */
    public void setHasBreak(Boolean hasBreak) {
        this.hasBreak = hasBreak;
    }

    /**
     * @return the constant
     */
    public Constant getConstant() {
        return constant;
    }

    /**
     * @param constant the constant to set
     */
    public void setConstant(Constant constant) {
        this.constant = constant;
    }
}
