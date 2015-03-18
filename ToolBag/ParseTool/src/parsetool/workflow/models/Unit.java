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
public class Unit extends TokenPair {
    private Node node;
    private Parallel parallel;

    /**
     * @return the node
     */
    public Node getNode() {
        return node;
    }

    /**
     * @param node the node to set
     */
    public void setNode(Node node) {
        this.node = node;
    }

    /**
     * @return the parallel
     */
    public Parallel getParallel() {
        return parallel;
    }

    /**
     * @param parallel the parallel to set
     */
    public void setParallel(Parallel parallel) {
        this.parallel = parallel;
    }
}
