/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.workflow.models;

import java.util.ArrayList;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Parallel extends TokenPair {
    private String name;
    private Variable variable;
    private Init init;    
    private Action action;
    private Translation translation;
    private ArrayList<Execute_Line> execute_Lines = new ArrayList<Execute_Line>();

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
     * @return the execute_Lines
     */
    public ArrayList<Execute_Line> getExecute_Lines() {
        return execute_Lines;
    }

    /**
     * @param execute_Lines the execute_Lines to set
     */
    public void setExecute_Lines(ArrayList<Execute_Line> execute_Lines) {
        this.execute_Lines = execute_Lines;
    }
}
