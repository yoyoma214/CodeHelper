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
public class Multiplicative_Expression extends TokenPair{
    private List<Cast_Expression> cast_expressions = new ArrayList<Cast_Expression>();
    private List<String> operators = new ArrayList<String>();

    /**
     * @return the cast_expressions
     */
    public List<Cast_Expression> getCast_expressions() {
        return cast_expressions;
    }

    /**
     * @param cast_expressions the cast_expressions to set
     */
    public void setCast_expressions(List<Cast_Expression> cast_expressions) {
        this.cast_expressions = cast_expressions;
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
