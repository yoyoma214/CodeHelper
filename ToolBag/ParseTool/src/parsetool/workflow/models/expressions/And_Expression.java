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
public class And_Expression extends TokenPair{
        private List<Equality_Expression> equality_expressions = new ArrayList<Equality_Expression>();

    /**
     * @return the equality_expressions
     */
    public List<Equality_Expression> getEquality_expressions() {
        return equality_expressions;
    }

    /**
     * @param equality_expressions the equality_expressions to set
     */
    public void setEquality_expressions(List<Equality_Expression> equality_expressions) {
        this.equality_expressions = equality_expressions;
    }
}
