/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.condition;

import java.util.ArrayList;
import java.util.List;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Compare_Complex_Mix extends TokenPair{
    private List<Compare_Complex> compare_complexs = new ArrayList<Compare_Complex>();
    private List<String> relations = new ArrayList<String>();

    /**
     * @return the compare_complexs
     */
    public List<Compare_Complex> getCompare_complexs() {
        return compare_complexs;
    }

    /**
     * @param compare_complexs the compare_complexs to set
     */
    public void setCompare_complexs(List<Compare_Complex> compare_complexs) {
        this.compare_complexs = compare_complexs;
    }

    /**
     * @return the relations
     */
    public List<String> getRelations() {
        return relations;
    }

    /**
     * @param relations the relations to set
     */
    public void setRelations(List<String> relations) {
        this.relations = relations;
    }
}
