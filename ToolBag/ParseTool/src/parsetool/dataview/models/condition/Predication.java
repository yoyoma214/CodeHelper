/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.dataview.models.condition;

import parsetool.dataview.models.Select;
import parsetool.dataview.models.Select_Atom;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Predication extends TokenPair{
    private String predicate;
    private Select select;
    
    /**
     * @return the predicate
     */
    public String getPredicate() {
        return predicate;
    }

    /**
     * @param predicate the predicate to set
     */
    public void setPredicate(String predicate) {
        this.predicate = predicate;
    }

    /**
     * @return the select
     */
    public Select getSelect() {
        return select;
    }

    /**
     * @param select the select to set
     */
    public void setSelect(Select select) {
        this.select = select;
    }

}
