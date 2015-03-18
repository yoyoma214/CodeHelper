/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.workflow.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.error.ParseErrorInfo;
import parsetool.models.common.TokenPair;
import parsetool.workflow.models.statements.Statement;

/**
 *
 * @author cqy
 */
public class State extends TokenPair{
    private List<Statement> statements = new ArrayList<Statement>();
    private List<ParseErrorInfo> errors = new ArrayList<ParseErrorInfo>();
    
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

    /**
     * @return the errors
     */
    public List<ParseErrorInfo> getErrors() {
        return errors;
    }

    /**
     * @param errors the errors to set
     */
    public void setErrors(List<ParseErrorInfo> errors) {
        this.errors = errors;
    }
    
}
