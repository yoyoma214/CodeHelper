/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.fields.casewhen;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Case_Expression extends TokenPair{
    private List<Case_When_Expression> case_when_expressions = new ArrayList<Case_When_Expression>();
    private Case_Else_Expression case_else_expression;

    /**
     * @return the case_when_expressions
     */
    public List<Case_When_Expression> getCase_when_expressions() {
        return case_when_expressions;
    }

    /**
     * @param case_when_expressions the case_when_expressions to set
     */
    public void setCase_when_expressions(List<Case_When_Expression> case_when_expressions) {
        this.case_when_expressions = case_when_expressions;
    }

    /**
     * @return the case_else_expression
     */
    public Case_Else_Expression getCase_else_expression() {
        return case_else_expression;
    }

    /**
     * @param case_else_expression the case_else_expression to set
     */
    public void setCase_else_expression(Case_Else_Expression case_else_expression) {
        this.case_else_expression = case_else_expression;
    }
}
