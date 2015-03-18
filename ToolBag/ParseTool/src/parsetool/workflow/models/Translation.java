/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.workflow.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;
import parsetool.workflow.models.statements.Translation_statement;

/**
 *
 * @author Administrator
 */
public class Translation extends TokenPair {
    private List<Translation_statement> Translation_statements 
            = new ArrayList<Translation_statement>();

    /**
     * @return the Translation_statements
     */
    public List<Translation_statement> getTranslation_statements() {
        return Translation_statements;
    }

    /**
     * @param Translation_statements the Translation_statements to set
     */
    public void setTranslation_statements(List<Translation_statement> Translation_statements) {
        this.Translation_statements = Translation_statements;
    }
}
