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
public class Inclusive_Or_Expression extends TokenPair{
    private List<Exclusive_Or_Expression> exclusive_or_expressions 
            = new ArrayList<Exclusive_Or_Expression>();

    /**
     * @return the exclusive_or_expressions
     */
    public List<Exclusive_Or_Expression> getExclusive_or_expressions() {
        return exclusive_or_expressions;
    }

    /**
     * @param exclusive_or_expressions the exclusive_or_expressions to set
     */
    public void setExclusive_or_expressions(List<Exclusive_Or_Expression> exclusive_or_expressions) {
        this.exclusive_or_expressions = exclusive_or_expressions;
    }
}
