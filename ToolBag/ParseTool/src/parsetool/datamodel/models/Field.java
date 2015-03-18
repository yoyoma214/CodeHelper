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
public class Field extends TokenPair {
    private String name;
    private String system_type;
    private String db_type;
    private Boolean is_null = true;
    private Boolean is_pk = false;
    private List<Attribute> attributes = new ArrayList<Attribute>();
    /**
     * @return the system_type
     */
    public String getSystem_type() {
        return system_type;
    }

    /**
     * @param system_type the system_type to set
     */
    public void setSystem_type(String system_type) {
        this.system_type = system_type;
    }

    /**
     * @return the db_type
     */
    public String getDb_type() {
        return db_type;
    }

    /**
     * @param db_type the db_type to set
     */
    public void setDb_type(String db_type) {
        this.db_type = db_type;
    }

    /**
     * @return the is_null
     */
    public Boolean getIs_null() {
        return is_null;
    }

    /**
     * @param is_null the is_null to set
     */
    public void setIs_null(Boolean is_null) {
        this.is_null = is_null;
    }

    /**
     * @return the is_pk
     */
    public Boolean getIs_pk() {
        return is_pk;
    }

    /**
     * @param is_pk the is_pk to set
     */
    public void setIs_pk(Boolean is_pk) {
        this.is_pk = is_pk;
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
