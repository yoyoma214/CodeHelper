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
public class Argument_Expression_List extends TokenPair{
    private List<Assignment_Expression> assignment_expressions = new ArrayList<Assignment_Expression>();

    /**
     * @return the assignment_expressions
     */
    public List<Assignment_Expression> getAssignment_expressions() {
        return assignment_expressions;
    }

    /**
     * @param assignment_expressions the assignment_expressions to set
     */
    public void setAssignment_expressions(List<Assignment_Expression> assignment_expressions) {
        this.assignment_expressions = assignment_expressions;
    }
}
