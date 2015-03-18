/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.xmlmodel.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class FieldGroupInfo extends TokenPair{
    private List<FieldInfo> fields = new ArrayList<FieldInfo>();
    private boolean isOrder;

    public void AddField(FieldInfo field)
    {
        fields.add(field);
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
     * @return the isOrder
     */
    public boolean isIsOrder() {
        return isOrder;
    }

    /**
     * @param isOrder the isOrder to set
     */
    public void setIsOrder(boolean isOrder) {
        this.isOrder = isOrder;
    }
    
}
