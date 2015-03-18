/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.workflow.models.statements;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;
import parsetool.workflow.models.expressions.CaseExpression;
import parsetool.workflow.models.expressions.Expression;

/**
 *
 * @author Administrator
 */
public class SwitchStatement extends TokenPair {
    private Expression key;
    private List<CaseExpression> caseExpressions = new ArrayList<CaseExpression>();

    /**
     * @return the key
     */
    public Expression getKey() {
        return key;
    }

    /**
     * @param key the key to set
     */
    public void setKey(Expression key) {
        this.key = key;
    }

    /**
     * @return the caseExpressions
     */
    public List<CaseExpression> getCaseExpressions() {
        return caseExpressions;
    }

    /**
     * @param caseExpressions the caseExpressions to set
     */
    public void setCaseExpressions(List<CaseExpression> caseExpressions) {
        this.caseExpressions = caseExpressions;
    }
}
