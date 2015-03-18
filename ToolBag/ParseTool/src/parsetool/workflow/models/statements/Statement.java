/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.workflow.models.statements;

import parsetool.models.common.TokenPair;
import parsetool.workflow.models.expressions.Expression;

/**
 *
 * @author cqy
 */
public class Statement extends TokenPair{
    private Expression_Statement expression;
    private Declare_Statement declare_statement;
    private IfStatement ifStatement;
    private SwitchStatement switchStatement;
    private WhileStatement whileStatement;
    private DoWhileStatement doWhileStatement;
    private ForStatement forStatement;
    private ForEachStatement forEachStatement;
    private GotoStatement gotoStatement;
    private BreakStatement breakStatement;
    private ContinueStatement continueStatement;


    /**
     * @return the declare_statement
     */
    public Declare_Statement getDeclare_statement() {
        return declare_statement;
    }

    /**
     * @param declare_statement the declare_statement to set
     */
    public void setDeclare_statement(Declare_Statement declare_statement) {
        this.declare_statement = declare_statement;
    }

    /**
     * @return the ifStatement
     */
    public IfStatement getIfStatement() {
        return ifStatement;
    }

    /**
     * @param ifStatement the ifStatement to set
     */
    public void setIfStatement(IfStatement ifStatement) {
        this.ifStatement = ifStatement;
    }

    /**
     * @return the switchStatement
     */
    public SwitchStatement getSwitchStatement() {
        return switchStatement;
    }

    /**
     * @param switchStatement the switchStatement to set
     */
    public void setSwitchStatement(SwitchStatement switchStatement) {
        this.switchStatement = switchStatement;
    }

    /**
     * @return the whileStatement
     */
    public WhileStatement getWhileStatement() {
        return whileStatement;
    }

    /**
     * @param whileStatement the whileStatement to set
     */
    public void setWhileStatement(WhileStatement whileStatement) {
        this.whileStatement = whileStatement;
    }

    /**
     * @return the doWhileStatement
     */
    public DoWhileStatement getDoWhileStatement() {
        return doWhileStatement;
    }

    /**
     * @param doWhileStatement the doWhileStatement to set
     */
    public void setDoWhileStatement(DoWhileStatement doWhileStatement) {
        this.doWhileStatement = doWhileStatement;
    }

    /**
     * @return the forStatement
     */
    public ForStatement getForStatement() {
        return forStatement;
    }

    /**
     * @param forStatement the forStatement to set
     */
    public void setForStatement(ForStatement forStatement) {
        this.forStatement = forStatement;
    }

    /**
     * @return the forEachStatement
     */
    public ForEachStatement getForEachStatement() {
        return forEachStatement;
    }

    /**
     * @param forEachStatement the forEachStatement to set
     */
    public void setForEachStatement(ForEachStatement forEachStatement) {
        this.forEachStatement = forEachStatement;
    }

    /**
     * @return the gotoStatement
     */
    public GotoStatement getGotoStatement() {
        return gotoStatement;
    }

    /**
     * @param gotoStatement the gotoStatement to set
     */
    public void setGotoStatement(GotoStatement gotoStatement) {
        this.gotoStatement = gotoStatement;
    }

    /**
     * @return the breakStatement
     */
    public BreakStatement getBreakStatement() {
        return breakStatement;
    }

    /**
     * @param breakStatement the breakStatement to set
     */
    public void setBreakStatement(BreakStatement breakStatement) {
        this.breakStatement = breakStatement;
    }

    /**
     * @return the continueStatement
     */
    public ContinueStatement getContinueStatement() {
        return continueStatement;
    }

    /**
     * @param continueStatement the continueStatement to set
     */
    public void setContinueStatement(ContinueStatement continueStatement) {
        this.continueStatement = continueStatement;
    }

    /**
     * @return the expression
     */
    public Expression_Statement getExpression() {
        return expression;
    }

    /**
     * @param expression the expression to set
     */
    public void setExpression(Expression_Statement expression) {
        this.expression = expression;
    }

  

}
