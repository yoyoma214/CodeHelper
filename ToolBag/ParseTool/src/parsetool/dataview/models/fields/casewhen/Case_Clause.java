/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.fields.casewhen;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Case_Clause extends TokenPair{
    private Case_Have_Target_Expression case_have_target_expression;
    private Case_Expression case_expression;

    /**
     * @return the case_have_target_expression
     */
    public Case_Have_Target_Expression getCase_have_target_expression() {
        return case_have_target_expression;
    }

    /**
     * @param case_have_target_expression the case_have_target_expression to set
     */
    public void setCase_have_target_expression(Case_Have_Target_Expression case_have_target_expression) {
        this.case_have_target_expression = case_have_target_expression;
    }

    /**
     * @return the case_expression
     */
    public Case_Expression getCase_expression() {
        return case_expression;
    }

    /**
     * @param case_expression the case_expression to set
     */
    public void setCase_expression(Case_Expression case_expression) {
        this.case_expression = case_expression;
    }
}
