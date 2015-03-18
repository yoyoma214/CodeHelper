/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.workflow.models;

import java.util.ArrayList;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Execute_Line extends TokenPair {
    private String name ;
    
    private ArrayList<Unit> units = new ArrayList<Unit>();


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
     * @return the units
     */
    public ArrayList<Unit> getUnits() {
        return units;
    }

    /**
     * @param units the units to set
     */
    public void setUnits(ArrayList<Unit> units) {
        this.units = units;
    }
}

