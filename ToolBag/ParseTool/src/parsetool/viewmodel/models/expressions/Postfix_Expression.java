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
public class Postfix_Expression extends TokenPair{
    private Primary_Expression primary_expression;
    private List<Postfix_Part> postfix_parts = new ArrayList<Postfix_Part>();

    /**
     * @return the primary_expression
     */
    public Primary_Expression getPrimary_expression() {
        return primary_expression;
    }

    /**
     * @param primary_expression the primary_expression to set
     */
    public void setPrimary_expression(Primary_Expression primary_expression) {
        this.primary_expression = primary_expression;
    }

    /**
     * @return the postfix_parts
     */
    public List<Postfix_Part> getPostfix_parts() {
        return postfix_parts;
    }

    /**
     * @param postfix_parts the postfix_parts to set
     */
    public void setPostfix_parts(List<Postfix_Part> postfix_parts) {
        this.postfix_parts = postfix_parts;
    }
}
