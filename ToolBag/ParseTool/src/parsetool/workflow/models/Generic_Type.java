/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.workflow.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Generic_Type extends TokenPair {
    private String long_name;
    private Generic_Type header;
    private List<Generic_Type> parameters = 
            new ArrayList<Generic_Type>();

    /**
     * @return the long_name
     */
    public String getLong_name() {
        return long_name;
    }

    /**
     * @param long_name the long_name to set
     */
    public void setLong_name(String long_name) {
        this.long_name = long_name;
    }

    /**
     * @return the header
     */
    public Generic_Type getHeader() {
        return header;
    }

    /**
     * @param header the header to set
     */
    public void setHeader(Generic_Type header) {
        this.header = header;
    }

    /**
     * @return the parameters
     */
    public List<Generic_Type> getParameters() {
        return parameters;
    }

    /**
     * @param parameters the parameters to set
     */
    public void setParameters(List<Generic_Type> parameters) {
        this.parameters = parameters;
    }
}
