/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.datamodel.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.AtomTokenPair;
import parsetool.models.common.TokenPair;

/**
 *
 * @author cqy
 */
public class Mapping  extends TokenPair {
    private AtomTokenPair fromModel;
    private AtomTokenPair targetModel;
    private AtomTokenPair fromField;
    private AtomTokenPair fromNavigateProperty;
    private AtomTokenPair targetField;    
    private AtomTokenPair relation;
    private List<AtomTokenPair> showFields = new ArrayList<AtomTokenPair>();
    private AtomTokenPair splitTag;
    
    /**
     * @return the fromModel
     */
    public AtomTokenPair getFromModel() {
        return fromModel;
    }

    /**
     * @param fromModel the fromModel to set
     */
    public void setFromModel(AtomTokenPair fromModel) {
        this.fromModel = fromModel;
    }

    /**
     * @return the targetModel
     */
    public AtomTokenPair getTargetModel() {
        return targetModel;
    }

    /**
     * @param targetModel the targetModel to set
     */
    public void setTargetModel(AtomTokenPair targetModel) {
        this.targetModel = targetModel;
    }

    /**
     * @return the fromField
     */
    public AtomTokenPair getFromField() {
        return fromField;
    }

    /**
     * @param fromField the fromField to set
     */
    public void setFromField(AtomTokenPair fromField) {
        this.fromField = fromField;
    }

    /**
     * @return the targetField
     */
    public AtomTokenPair getTargetField() {
        return targetField;
    }

    /**
     * @param targetField the targetField to set
     */
    public void setTargetField(AtomTokenPair targetField) {
        this.targetField = targetField;
    }

    /**
     * @return the relation
     */
    public AtomTokenPair getRelation() {
        return relation;
    }

    /**
     * @param relation the relation to set
     */
    public void setRelation(AtomTokenPair relation) {
        this.relation = relation;
    }

    /**
     * @return the fromNavigateProperty
     */
    public AtomTokenPair getFromNavigateProperty() {
        return fromNavigateProperty;
    }

    /**
     * @return the showFields
     */
    public List<AtomTokenPair> getShowFields() {
        return showFields;
    }

    /**
     * @param fromNavigateProperty the fromNavigateProperty to set
     */
    public void setFromNavigateProperty(AtomTokenPair fromNavigateProperty) {
        this.fromNavigateProperty = fromNavigateProperty;
    }

    /**
     * @param showFields the showFields to set
     */
    public void setShowFields(List<AtomTokenPair> showFields) {
        this.showFields = showFields;
    }

    /**
     * @return the splitTag
     */
    public AtomTokenPair getSplitTag() {
        return splitTag;
    }

    /**
     * @param splitTag the splitTag to set
     */
    public void setSplitTag(AtomTokenPair splitTag) {
        this.splitTag = splitTag;
    }
}
