/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.workflow.models.statements;

import parsetool.models.common.TokenPair;
import parsetool.workflow.models.Generic_Type;
import parsetool.workflow.models.expressions.Expression;

/**
 *
 * @author cqy
 */
public class Declare extends TokenPair{
    private Generic_Type generic_type;
    private String name;
    private Expression default_value;

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
     * @return the default_value
     */
    public Expression getDefault_value() {
        return default_value;
    }

    /**
     * @param default_value the default_value to set
     */
    public void setDefault_value(Expression default_value) {
        this.default_value = default_value;
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
