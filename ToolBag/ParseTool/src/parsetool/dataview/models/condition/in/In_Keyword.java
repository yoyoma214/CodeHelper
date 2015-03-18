/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.condition.in;

import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class In_Keyword extends TokenPair{
    private String keyworkd;

    /**
     * @return the keyworkd
     */
    public String getKeyworkd() {
        return keyworkd;
    }

    /**
     * @param keyworkd the keyworkd to set
     */
    public void setKeyworkd(String keyworkd) {
        this.keyworkd = keyworkd;
    }
}
