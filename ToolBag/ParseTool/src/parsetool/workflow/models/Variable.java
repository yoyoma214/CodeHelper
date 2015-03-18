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
public class Variable extends TokenPair {
    private List<Field> fields = new ArrayList<Field>();
    private List<Clz> clzes = new ArrayList<Clz>();

    /**
     * @return the fields
     */
    public List<Field> getFields() {
        return fields;
    }

    /**
     * @param fields the fields to set
     */
    public void setFields(List<Field> fields) {
        this.fields = fields;
    }

    /**
     * @return the clzes
     */
    public List<Clz> getClzes() {
        return clzes;
    }

    /**
     * @param clzes the clzes to set
     */
    public void setClzes(List<Clz> clzes) {
        this.clzes = clzes;
    }
}
