/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.viewmodel.models.statements;

import parsetool.models.common.TokenPair;
import parsetool.viewmodel.models.expressions.Expression;

/**
 *
 * @author cqy
 */
public class Declare extends TokenPair{
    private String type_name;
    private String name;
    private Expression default_value;

    /**
     * @return the type_name
     */
    public String getType_name() {
        return type_name;
    }

    /**
     * @param type_name the type_name to set
     */
    public void setType_name(String type_name) {
        this.type_name = type_name;
    }

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
}
