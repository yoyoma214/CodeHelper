/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.viewmodel.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.error.ParseErrorInfo;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Program extends TokenPair{
    private List<Model> models = new ArrayList<Model>();
    private List<ParseErrorInfo> errors = new ArrayList<ParseErrorInfo>();
    /**
     * @return the models
     */
    public List<Model> getModels() {
        return models;
    }

    /**
     * @param models the models to set
     */
    public void setModels(List<Model> models) {
        this.models = models;
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
