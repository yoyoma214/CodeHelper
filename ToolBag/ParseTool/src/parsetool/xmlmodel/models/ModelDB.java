/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.xmlmodel.models;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import org.antlr.v4.misc.OrderedHashMap;
import parsetool.error.ParseErrorInfo;
import parsetool.models.common.TokenPair;


/**
 *
 * @author Administrator
 */
public class ModelDB extends TokenPair{
    private List<String> usingNameSpaces = new ArrayList<String>();
    private String nameSpace = null;
    //private Map<String,ElementInfo> elements = new OrderedHashMap<String,ElementInfo>();
    private List<ElementInfo> elements = new ArrayList<ElementInfo>();
    private List<ParseErrorInfo> errors = new ArrayList<ParseErrorInfo>();
    
    public void AddElement(ElementInfo element)
    {
        //this.getElements().put(element.getName(), element);
        elements.add(element);
    }

    /**
     * @return the elements
     */
    public List<ElementInfo> getElements() {
        return elements;
    }

    /**
     * @param elements the elements to set
     */
    public void setElements(List<ElementInfo> elements) {
        this.elements = elements;
    }

    /**
     * @return the errors
     */
    public List<ParseErrorInfo> getErrors() {
        return errors;
    }

    /**
     * @param errors the errors to set
     */
    public void setErrors(List<ParseErrorInfo> errors) {
        this.errors = errors;
    }


    /**
     * @return the nameSpace
     */
    public String getNameSpace() {
        return nameSpace;
    }

    /**
     * @param nameSpace the nameSpace to set
     */
    public void setNameSpace(String nameSpace) {
        this.nameSpace = nameSpace;
    }

    /**
     * @return the usingNameSpaces
     */
    public List<String> getUsingNameSpaces() {
        return usingNameSpaces;
    }

    /**
     * @param usingNameSpaces the usingNameSpaces to set
     */
    public void setUsingNameSpaces(List<String> usingNameSpaces) {
        this.usingNameSpaces = usingNameSpaces;
    }
}
