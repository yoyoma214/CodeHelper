/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Select extends TokenPair{
    private List<Select_Atom> select_atoms = new ArrayList<Select_Atom>();
    private List<Union_Type> union_types = new ArrayList<Union_Type>();

    /**
     * @return the select_atoms
     */
    public List<Select_Atom> getSelect_atoms() {
        return select_atoms;
    }

    /**
     * @param select_atoms the select_atoms to set
     */
    public void setSelect_atoms(List<Select_Atom> select_atoms) {
        this.select_atoms = select_atoms;
    }

    /**
     * @return the union_types
     */
    public List<Union_Type> getUnion_types() {
        return union_types;
    }

    /**
     * @param union_types the union_types to set
     */
    public void setUnion_types(List<Union_Type> union_types) {
        this.union_types = union_types;
    }
}
