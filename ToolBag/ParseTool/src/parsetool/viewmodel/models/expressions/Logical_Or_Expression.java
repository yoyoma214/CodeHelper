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
public class Logical_Or_Expression extends TokenPair{
    private List<Logical_And_Expression> logical_and_expressions =
            new ArrayList<Logical_And_Expression>();

    /**
     * @return the logical_and_expressions
     */
    public List<Logical_And_Expression> getLogical_and_expressions() {
        return logical_and_expressions;
    }

    /**
     * @param logical_and_expressions the logical_and_expressions to set
     */
    public void setLogical_and_expressions(List<Logical_And_Expression> logical_and_expressions) {
        this.logical_and_expressions = logical_and_expressions;
    }
}
