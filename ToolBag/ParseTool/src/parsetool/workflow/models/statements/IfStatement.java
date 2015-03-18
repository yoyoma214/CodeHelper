/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.workflow.models.statements;

import parsetool.models.common.TokenPair;
import parsetool.workflow.models.State;
import parsetool.workflow.models.expressions.Expression;

/**
 *
 * @author Administrator
 */
public class IfStatement extends TokenPair {
    private Expression condition;
    private State trueState;
    private IfStatement elseIf;
    private State elseState;

    /**
     * @return the condition
     */
    public Expression getCondition() {
        return condition;
    }

    /**
     * @param condition the condition to set
     */
    public void setCondition(Expression condition) {
        this.condition = condition;
    }

    /**
     * @return the trueState
     */
    public State getTrueState() {
        return trueState;
    }

    /**
     * @param trueState the trueState to set
     */
    public void setTrueState(State trueState) {
        this.trueState = trueState;
    }

    /**
     * @return the elseIf
     */
    public IfStatement getElseIf() {
        return elseIf;
    }

    /**
     * @param elseIf the elseIf to set
     */
    public void setElseIf(IfStatement elseIf) {
        this.elseIf = elseIf;
    }

    /**
     * @return the elseState
     */
    public State getElseState() {
        return elseState;
    }

    /**
     * @param elseState the elseState to set
     */
    public void setElseState(State elseState) {
        this.elseState = elseState;
    }
}
