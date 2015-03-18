/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.viewmodel.models.statements;

import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Declare_Statement extends TokenPair{
    private Declare declare;

    /**
     * @return the declare
     */
    public Declare getDeclare() {
        return declare;
    }

    /**
     * @param declare the declare to set
     */
    public void setDeclare(Declare declare) {
        this.declare = declare;
    }
}
