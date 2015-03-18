/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.viewmodel.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;
import parsetool.viewmodel.models.statements.Statement;

/**
 *
 * @author cqy
 */
public class State extends TokenPair{
    private List<Statement> statements = new ArrayList<Statement>();

    /**
     * @return the statements
     */
    public List<Statement> getStatements() {
        return statements;
    }

    /**
     * @param statements the statements to set
     */
    public void setStatements(List<Statement> statements) {
        this.statements = statements;
    }
    
}
