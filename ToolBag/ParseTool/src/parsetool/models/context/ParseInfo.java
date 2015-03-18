/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.models.context;

/**
 *
 * @author Administrator
 */
public class ParseInfo {
    
      public int Type ;
      public int Index;
      public String Content;
       
    /**
     * @return the type
     */
    public ParseType getType() {
        if ( Type == 1)
            return ParseType.XmlModel;
        if ( Type == 2)
            return ParseType.DataModel;
        if ( Type == 3)
            return ParseType.DataView;
        if ( Type == 4)
            return ParseType.ViewModel;
        if ( Type == 5)
            return ParseType.WorkFlow;
        
        return ParseType.Unknown;
    }

    /**
     * @return the index
     */
    public int getIndex() {
        return Index;
    }

    /**
     * @param index the index to set
     */
    public void setIndex(int index) {
        this.Index = index;
    }

    /**
     * @return the content
     */
    public String getContent() {
        return Content;
    }

    /**
     * @param content the content to set
     */
    public void setContent(String content) {
        this.Content = content;
    }
}
