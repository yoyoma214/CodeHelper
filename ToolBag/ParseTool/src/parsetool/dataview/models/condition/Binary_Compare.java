/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.dataview.models.condition;

import parsetool.dataview.models.fields.Table_Field;
import parsetool.dataview.models.fields.Table_Field_Atom;
import parsetool.models.common.TokenPair;

/**
 *
 * @author Administrator
 */
public class Binary_Compare extends TokenPair{
    private Table_Field left_table_field;
    private Binary_Operater binary_operater;
    private Table_Field right_table_field;
    private Predication predication;
    /**
     * @return the left_table_field
     */
    public Table_Field getLeft_table_field() {
        return left_table_field;
    }

    /**
     * @param left_table_field the left_table_field to set
     */
    public void setLeft_table_field(Table_Field left_table_field) {
        this.left_table_field = left_table_field;
    }

    /**
     * @return the binary_operater
     */
    public Binary_Operater getBinary_operater() {
        return binary_operater;
    }

    /**
     * @param binary_operater the binary_operater to set
     */
    public void setBinary_operater(Binary_Operater binary_operater) {
        this.binary_operater = binary_operater;
    }

    /**
     * @return the right_table_field
     */
    public Table_Field getRight_table_field() {
        return right_table_field;
    }

    /**
     * @param right_table_field the right_table_field to set
     */
    public void setRight_table_field(Table_Field right_table_field) {
        this.right_table_field = right_table_field;
    }

    /**
     * @return the predication
     */
    public Predication getPredication() {
        return predication;
    }

    /**
     * @param predication the predication to set
     */
    public void setPredication(Predication predication) {
        this.predication = predication;
    }
}
