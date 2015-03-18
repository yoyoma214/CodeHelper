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
public class AttributeGroupInfo extends TokenPair{
    private List<AttributeInfo> attributes = new ArrayList<AttributeInfo>();
    private boolean isOrder;

    public void AddAttribute(AttributeInfo attr)
    {
        getAttributes().add(attr);
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

    /**
     * @return the attributes
     */
    public List<AttributeInfo> getAttributes() {
        return attributes;
    }

    /**
     * @param attributes the attributes to set
     */
    public void setAttributes(List<AttributeInfo> attributes) {
        this.attributes = attributes;
    }
    
    
}
