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
public class Exclusive_Or_Expression extends TokenPair{
    private List<And_Expression> and_expressions = new ArrayList<And_Expression>();

    /**
     * @return the and_expressions
     */
    public List<And_Expression> getAnd_expressions() {
        return and_expressions;
    }

    /**
     * @param and_expressions the and_expressions to set
     */
    public void setAnd_expressions(List<And_Expression> and_expressions) {
        this.and_expressions = and_expressions;
    }
}
