/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.utils;

import java.util.ArrayList;
import java.util.List;
import org.antlr.v4.runtime.tree.ParseTree;

/**
 *
 * @author cqy
 */
public class TreeUtil {
    
    public static ParseTree getChild(ParseTree context, String name)
    {
        ParseTree child = null;
        for(int i = 0 ;i < context.getChildCount() ; i ++)
        {
            child =  context.getChild(i);
            if (child.getClass().getSimpleName().equalsIgnoreCase(name + "context"))
            {
                return child;
            }
        }
        return null;
    }
    
    public static ParseTree getChild(ParseTree context, String name , int index)
    {
        ParseTree child = null;
        int index_tmp = 0;
        for(int i = 0 ;i < context.getChildCount() ; i ++)
        {
            child =  context.getChild(i);
            if (child.getClass().getSimpleName().equalsIgnoreCase(name + "context"))
            {                            
                if ( index_tmp ++ == index )
                {
                    return child;
                }       
            }
        }
        return null;
    }
    
    public static List<ParseTree> getChildren(ParseTree context, String name)
    {
        List<ParseTree> result = new ArrayList<ParseTree>();
        ParseTree child = null;
        for(int i = 0 ;i < context.getChildCount() ; i ++)
        {
            child =  context.getChild(i);
            if (child.getClass().getSimpleName().equalsIgnoreCase(name + "context"))
            {
                result.add(child);
            }
        }
        return result;
    }
    
    public static ParseTree getLastChild(ParseTree context, int index)
    {
        ParseTree child = null;
        int index_tmp = 0;
        if ( index < context.getChildCount())
        {
            return context.getChild(context.getChildCount() - index);
        }
        
        return null;
    }
    
    
}
