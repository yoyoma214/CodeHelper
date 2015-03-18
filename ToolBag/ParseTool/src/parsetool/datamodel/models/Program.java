/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.datamodel.models;

import java.util.ArrayList;
import java.util.Dictionary;
import java.util.List;
import java.util.Map;
import org.antlr.v4.misc.OrderedHashMap;
import parsetool.error.ParseErrorInfo;
import parsetool.models.common.TokenPair;
import parsetool.models.context.InputContext;

/**
 *
 * @author cqy
 */
public class Program  extends TokenPair{
    
    private List<String> usingNameSpaces = new ArrayList<String>();
    private Map<String,Model> models = new OrderedHashMap<String,Model>();
    private List<Mapping> mapings = new ArrayList<Mapping>();
    private String nameSpace = null;
     private List<ParseErrorInfo> errors = new ArrayList<ParseErrorInfo>();
     
    public void AddModel(Model modelInfo)
    {
        models.put(modelInfo.getName(), modelInfo);
    }
    
    public void GetModel(String name)
    {
        models.get(name);
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
     * @return the mapings
     */
    public List<Mapping> getMapings() {
        return mapings;
    }

    /**
     * @param mapings the mapings to set
     */
    public void setMapings(List<Mapping> mapings) {
        this.mapings = mapings;
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
}
