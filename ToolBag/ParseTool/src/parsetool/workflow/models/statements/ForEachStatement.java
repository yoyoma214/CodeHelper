/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.workflow.models.statements;

import parsetool.models.common.TokenPair;
import parsetool.workflow.models.Generic_Type;
import parsetool.workflow.models.State;
import parsetool.workflow.models.Long_Name;
import parsetool.workflow.models.expressions.Expression;

/**
 *
 * @author Administrator
 */
public class ForEachStatement extends TokenPair{
    private    Generic_Type generic_type;
    private String var;
    private Expression inExpression;
    private State state;

    /**
     * @return the var
     */
    public String getVar() {
        return var;
    }

    /**
     * @param var the var to set
     */
    public void setVar(String var) {
        this.var = var;
    }

    /**
     * @return the inExpression
     */
    public Expression getInExpression() {
        return inExpression;
    }

    /**
     * @param inExpression the inExpression to set
     */
    public void setInExpression(Expression inExpression) {
        this.inExpression = inExpression;
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
     * @return the generic_type
     */
    public Generic_Type getGeneric_type() {
        return generic_type;
    }

    /**
     * @param generic_type the generic_type to set
     */
    public void setGeneric_type(Generic_Type generic_type) {
        this.generic_type = generic_type;
    }
}
