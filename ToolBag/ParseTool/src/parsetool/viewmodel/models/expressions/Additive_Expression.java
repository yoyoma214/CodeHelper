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
public class Additive_Expression extends TokenPair{
    private List<Multiplicative_Expression> multiplicative_expressions = new ArrayList<Multiplicative_Expression>();
    private List<String> operators = new ArrayList<String>();

    /**
     * @return the multiplicative_expressions
     */
    public List<Multiplicative_Expression> getMultiplicative_expressions() {
        return multiplicative_expressions;
    }

    /**
     * @param multiplicative_expressions the multiplicative_expressions to set
     */
    public void setMultiplicative_expressions(List<Multiplicative_Expression> multiplicative_expressions) {
        this.multiplicative_expressions = multiplicative_expressions;
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
