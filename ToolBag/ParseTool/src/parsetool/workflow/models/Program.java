/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.workflow.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.error.ParseErrorInfo;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Program extends TokenPair{
    private String nameSpace;
    private Variable variable;
    private Init init = null;
    private List<Unit> units = new ArrayList<Unit>();
    private List<ParseErrorInfo> errors = new ArrayList<ParseErrorInfo>();


    /**
     * @return the errors
     */
    public List<ParseErrorInfo> getErrors() {
        return errors;
    }

    /**
     * @param errors the errors to set
     */
    public void setErrors(List<ParseErrorInfo> errors) {
        this.errors = errors;
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
     * @return the nameSpace
     */
    public String getNameSpace() {
        return nameSpace;
    }

    /**
     * @param nameSpace the nameSpace to set
     */
    public void setNameSpace(String nameSpace) {
        this.nameSpace = nameSpace;
    }

    /**
     * @return the units
     */
    public List<Unit> getUnits() {
        return units;
    }

    /**
     * @param units the units to set
     */
    public void setUnits(List<Unit> units) {
        this.units = units;
    }
}
