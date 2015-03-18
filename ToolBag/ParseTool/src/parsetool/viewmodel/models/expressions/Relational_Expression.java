/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.viewmodel.models.expressions;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Relational_Expression extends TokenPair{
    private List<Shift_Expression> shift_expressions = new ArrayList<Shift_Expression>();
    private List<String> Operators = new ArrayList<String>();

    /**
     * @return the shift_expressions
     */
    public List<Shift_Expression> getShift_expressions() {
        return shift_expressions;
    }

    /**
     * @param shift_expressions the shift_expressions to set
     */
    public void setShift_expressions(List<Shift_Expression> shift_expressions) {
        this.shift_expressions = shift_expressions;
    }

    /**
     * @return the Operators
     */
    public List<String> getOperators() {
        return Operators;
    }

    /**
     * @param Operators the Operators to set
     */
    public void setOperators(List<String> Operators) {
        this.Operators = Operators;
    }
}
