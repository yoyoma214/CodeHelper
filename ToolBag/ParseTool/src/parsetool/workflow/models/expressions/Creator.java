/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.workflow.models.expressions;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;
import parsetool.workflow.models.Generic_Type;

/**
 *
 * @author Administrator
 */
public class Creator extends TokenPair {
    private Generic_Type generic_type;
    private List<Assignment_Expression> assignment_expressions =
            new ArrayList<Assignment_Expression>();

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

    /**
     * @return the generic_type
     */
    public Generic_Type getGeneric_type() {
        return generic_type;
    }

    /**
     * @param generic_type the generic_type to set
     */
    public void setGeneric_type(Generic_Type generic_type) {
        this.generic_type = generic_type;
    }
}
