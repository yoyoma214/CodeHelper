/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.workflow.models;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Form extends TokenPair{
    private String id;
    private String dataId;

    /**
     * @return the id
     */
    public String getId() {
        return id;
    }

    /**
     * @param id the id to set
     */
    public void setId(String id) {
        this.id = id;
    }

    /**
     * @return the dataId
     */
    public String getDataId() {
        return dataId;
    }

    /**
     * @param dataId the dataId to set
     */
    public void setDataId(String dataId) {
        this.dataId = dataId;
    }
}
