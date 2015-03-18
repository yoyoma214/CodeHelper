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
public class Logical_And_Expression extends TokenPair{
    private List<Inclusive_Or_Expression> inclusive_or_expressions = new ArrayList<Inclusive_Or_Expression>();

    /**
     * @return the inclusive_or_expressions
     */
    public List<Inclusive_Or_Expression> getInclusive_or_expressions() {
        return inclusive_or_expressions;
    }

    /**
     * @param inclusive_or_expressions the inclusive_or_expressions to set
     */
    public void setInclusive_or_expressions(List<Inclusive_Or_Expression> inclusive_or_expressions) {
        this.inclusive_or_expressions = inclusive_or_expressions;
    }
}
