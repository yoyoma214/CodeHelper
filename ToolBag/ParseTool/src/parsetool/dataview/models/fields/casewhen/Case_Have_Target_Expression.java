/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.dataview.models.fields.casewhen;

import java.util.ArrayList;
import java.util.List;
import parsetool.dataview.models.fields.Table_Field;
import parsetool.dataview.models.fields.Table_Field_Atom;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Case_Have_Target_Expression extends TokenPair{
    private Table_Field table_field;
    private List<Case_Have_Target_When_Expression> case_have_target_when_expressions 
            = new ArrayList<Case_Have_Target_When_Expression>(); 
    private Case_Else_Expression case_else_expression;

    /**
     * @return the table_field
     */
    public Table_Field getTable_field() {
        return table_field;
    }

    /**
     * @param table_field the table_field to set
     */
    public void setTable_field(Table_Field table_field) {
        this.table_field = table_field;
    }

    /**
     * @return the case_have_target_when_expressions
     */
    public List<Case_Have_Target_When_Expression> getCase_have_target_when_expressions() {
        return case_have_target_when_expressions;
    }

    /**
     * @param case_have_target_when_expressions the case_have_target_when_expressions to set
     */
    public void setCase_have_target_when_expressions(List<Case_Have_Target_When_Expression> case_have_target_when_expression) {
        this.case_have_target_when_expressions = case_have_target_when_expression;
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
