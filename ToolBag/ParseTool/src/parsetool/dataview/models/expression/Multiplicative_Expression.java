/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.expression;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Multiplicative_Expression extends TokenPair{
    private List<Positive_Expression> positive_expressions = new ArrayList<Positive_Expression>();
    private List<String> operators= new ArrayList<String>();
    
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

    /**
     * @return the positive_expressions
     */
    public List<Positive_Expression> getPositive_expressions() {
        return positive_expressions;
    }

    /**
     * @param positive_expressions the positive_expressions to set
     */
    public void setPositive_expressions(List<Positive_Expression> positive_expressions) {
        this.positive_expressions = positive_expressions;
    }
}
