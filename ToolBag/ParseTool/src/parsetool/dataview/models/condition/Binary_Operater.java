/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.condition;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Binary_Operater extends TokenPair{
    private String operater;

    /**
     * @return the operater
     */
    public String getOperater() {
        return operater;
    }

    /**
     * @param operater the operater to set
     */
    public void setOperater(String operater) {
        this.operater = operater;
    }
}
