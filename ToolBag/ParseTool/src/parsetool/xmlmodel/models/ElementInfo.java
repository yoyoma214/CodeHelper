/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.xmlmodel.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.Token;
import parsetool.models.common.TokenPair;


/**
 *
 * @author Administrator
 */
public class ElementInfo extends TokenPair{
    private String name;
    private List<AttributeInfo> xmlAttributes = new ArrayList<AttributeInfo>();
    private List<FieldInfo> fields = new ArrayList<FieldInfo>();
    private List<AttributeGroupInfo> attrGroups = new ArrayList<AttributeGroupInfo>();
    private List<FieldGroupInfo> fieldGroups = new ArrayList<FieldGroupInfo>();
        
    public void AddAttr(AttributeInfo attr)
    {
        this.xmlAttributes.add(attr);
    }
    
    public void AddField(FieldInfo field)
    {
        this.fields.add(field);
    }
    
    public void AddAttrGroup(AttributeGroupInfo attrGroup)
    {
        this.attrGroups.add(attrGroup);
    }
    
    public void AddFieldGroup(FieldGroupInfo fieldGroup)
    {
        this.fieldGroups.add(fieldGroup);
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
     * @return the xmlAttributes
     */
    public List<AttributeInfo> getXmlAttributes() {
        return xmlAttributes;
    }

    /**
     * @param xmlAttributes the xmlAttributes to set
     */
    public void setXmlAttributes(List<AttributeInfo> xmlAttributes) {
        this.xmlAttributes = xmlAttributes;
    }

    /**
     * @return the fields
     */
    public List<FieldInfo> getFields() {
        return fields;
    }

    /**
     * @param fields the fields to set
     */
    public void setFields(List<FieldInfo> fields) {
        this.fields = fields;
    }

    /**
     * @return the attrGroups
     */
    public List<AttributeGroupInfo> getAttrGroups() {
        return attrGroups;
    }

    /**
     * @param attrGroups the attrGroups to set
     */
    public void setAttrGroups(List<AttributeGroupInfo> attrGroups) {
        this.attrGroups = attrGroups;
    }

    /**
     * @return the fieldGroups
     */
    public List<FieldGroupInfo> getFieldGroups() {
        return fieldGroups;
    }

    /**
     * @param fieldGroups the fieldGroups to set
     */
    public void setFieldGroups(List<FieldGroupInfo> fieldGroups) {
        this.fieldGroups = fieldGroups;
    }
}
