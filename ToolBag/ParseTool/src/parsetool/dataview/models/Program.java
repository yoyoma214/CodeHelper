/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.dataview.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.error.ParseErrorInfo;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Program extends TokenPair{
    private Select select;
    private Search_Option search_option;
    private List<ParseErrorInfo> errors = new ArrayList<ParseErrorInfo>();
    

    /**
     * @return the search_option
     */
    public Search_Option getSearch_option() {
        return search_option;
    }

    /**
     * @param search_option the search_option to set
     */
    public void setSearch_option(Search_Option search_option) {
        this.search_option = search_option;
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
