/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.workflow.models.expressions;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Shift_Expression extends TokenPair{
    private List<Additive_Expression> additive_expressions = new ArrayList<Additive_Expression>();
    private List<String> operators = new ArrayList<String>();

    /**
     * @return the additive_expressions
     */
    public List<Additive_Expression> getAdditive_expressions() {
        return additive_expressions;
    }

    /**
     * @param additive_expressions the additive_expressions to set
     */
    public void setAdditive_expressions(List<Additive_Expression> additive_expressions) {
        this.additive_expressions = additive_expressions;
    }

    /**
     * @return the operators
     */
    public List<String> getOperators() {
        return operators;
    }

    /**
     * @param operators the operators to set
     */
    public void setOperators(List<String> operators) {
        this.operators = operators;
    }

   
}
