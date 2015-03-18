/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.models.context;

import parsetool.models.common.Token;


/**
 *
 * @author Administrator
 */
public class InputContext extends Token {
    /**
    *
    * @author Administrator
    */
   public enum ContextType {
       Begin,In
   }

    private String syntax = null;
    private ContextType type = null;    

    /**
     * @return the type
     */
    public ContextType getType() {
        return type;
    }

    /**
     * @param type the type to set
     */
    public void setType(ContextType type) {
        this.type = type;
    }

    /**
     * @return the syntax
     */
    public String getSyntax() {
        return syntax;
    }

    /**
     * @param syntax the syntax to set
     */
    public void setSyntax(String syntax) {
        this.syntax = syntax;
    }
      
}
