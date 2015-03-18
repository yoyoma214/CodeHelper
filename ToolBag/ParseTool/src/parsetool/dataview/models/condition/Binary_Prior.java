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
public class Binary_Prior extends TokenPair{
    private Binary binary;

    /**
     * @return the binary
     */
    public Binary getBinary() {
        return binary;
    }

    /**
     * @param binary the binary to set
     */
    public void setBinary(Binary binary) {
        this.binary = binary;
    }
}
