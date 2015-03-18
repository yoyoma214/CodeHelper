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
public class Equality_Expression  extends TokenPair{
    private List<Relational_Expression> relational_expressions = new ArrayList<Relational_Expression>();
    private List<String> operators = new ArrayList<String>();
    /**
     * @return the relational_expressions
     */
    public List<Relational_Expression> getRelational_expressions() {
        return relational_expressions;
    }

    /**
     * @param relational_expressions the relational_expressions to set
     */
    public void setRelational_expressions(List<Relational_Expression> relational_expressions) {
        this.relational_expressions = relational_expressions;
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
