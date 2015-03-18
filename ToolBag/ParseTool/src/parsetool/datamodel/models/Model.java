/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.datamodel.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;
import parsetool.models.context.InputContext;

/**
 *
 * @author cqy
 */
public class Model  extends TokenPair{
    private String name;
    private List<Field> fields = new ArrayList<Field>();
    private List<Model> models = new ArrayList<Model>();
    private List<Attribute> attributes = new ArrayList<Attribute>();
    /**
     * @return the fields
     */
    public List<Field> getFields() {
        return fields;
    }

    /**
     * @param fields the fields to set
     */
    public void setFields(List<Field> fields) {
        this.fields = fields;
    }

    /**
     * @return the models
     */
    public List<Model> getModels() {
        return models;
    }

    /**
     * @return the name
     */
    public String getName() {
        return name;
    }

    /**
     * @param name the name to set
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * @return the attributes
     */
    public List<Attribute> getAttributes() {
        return attributes;
    }

    /**
     * @param attributes the attributes to set
     */
    public void setAttributes(List<Attribute> attributes) {
        this.attributes = attributes;
    }


}
