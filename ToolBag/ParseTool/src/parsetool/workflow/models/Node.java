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
public class Node extends TokenPair {
    private String name;
    private Variable variable;
    private Init init;
    private Form form;
    private Action action;
    private Translation translation;
    private Ref_Workflow ref_Workflow;

    /**
     * @return the name
     */
    public String getName() {
        return name;
    }

    /**
     * @param name the name to set
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * @return the variable
     */
    public Variable getVariable() {
        return variable;
    }

    /**
     * @param variable the variable to set
     */
    public void setVariable(Variable variable) {
        this.variable = variable;
    }

    /**
     * @return the init
     */
    public Init getInit() {
        return init;
    }

    /**
     * @param init the init to set
     */
    public void setInit(Init init) {
        this.init = init;
    }

    /**
     * @return the form
     */
    public Form getForm() {
        return form;
    }

    /**
     * @param form the form to set
     */
    public void setForm(Form form) {
        this.form = form;
    }

    /**
     * @return the action
     */
    public Action getAction() {
        return action;
    }

    /**
     * @param action the action to set
     */
    public void setAction(Action action) {
        this.action = action;
    }

    /**
     * @return the translation
     */
    public Translation getTranslation() {
        return translation;
    }

    /**
     * @param translation the translation to set
     */
    public void setTranslation(Translation translation) {
        this.translation = translation;
    }

    /**
     * @return the ref_Workflow
     */
    public Ref_Workflow getRef_Workflow() {
        return ref_Workflow;
    }

    /**
     * @param ref_Workflow the ref_Workflow to set
     */
    public void setRef_Workflow(Ref_Workflow ref_Workflow) {
        this.ref_Workflow = ref_Workflow;
    }
}
