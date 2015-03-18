/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.utils;

import java.util.Stack;

/**
 *
 * @author Administrator
 */
public class StackUtil {
    
    Stack stack = new Stack();
    
    public <T> T peekCtx(Class<T> clz)
    {
        if ( this.stack.empty() )
            return null;
        
       try{
            T t= (T)this.stack.peek();     
            if(!clz.isInstance(t) )
            {
                return null;
            }
            return t;
       }
       catch(Exception e)
       {
           return null;
       }
       
    }
    
    public void push(Object obj)
    {
        this.stack.push(obj);
    }
    
    public void pop()
    {
        this.stack.pop();
    }
    
    public Object peek()
    {
        return this.stack.peek();
    }
    
    public Object peekPrev()
    {
        int count = this.stack.size();
        if ( count > 1)
        {
            return this.stack.get(count-2);
        }
        return null;
    }
}
