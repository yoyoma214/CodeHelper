/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool.models.common;

import java.util.ArrayList;
import java.util.List;
import org.antlr.v4.runtime.ParserRuleContext;

/**
 *
 * @author cqy
 */
public class TokenPair {
    private Token beginToken;
    private Token endToken;
    private TokenPair parent;
    private List<TokenPair> children = new ArrayList<TokenPair>();

    /**
     * @return the beginToken
     */
    public Token getBeginToken() {
        return beginToken;
    }

    /**
     * @param beginToken the beginToken to set
     */
    public void setBeginToken(Token beginToken) {
        this.beginToken = beginToken;
    }

    /**
     * @return the endToken
     */
    public Token getEndToken() {
        return endToken;
    }

    /**
     * @param endToken the endToken to set
     */
    public void setEndToken(Token endToken) {
        this.endToken = endToken;
    }
    
    public void parse(ParserRuleContext ctx, Object parent)
    {
        TokenPair par = null;
        if ( parent instanceof TokenPair)
        {
            par = (TokenPair)parent;
        }
        
        parse(ctx,par);
    }
    
    public void parse(ParserRuleContext ctx, TokenPair parent)
    {
        this.beginToken = new Token(ctx.start.getLine(),ctx.start.getCharPositionInLine());
        this.endToken = new Token(ctx.stop.getLine(),ctx.stop.getCharPositionInLine());
        if ( parent != null )
        {
            //this.setParent(parent);
        }
    }

    /**
     * @return the children
     */
    public List<TokenPair> getChildren()
    {
        return this.children;
    }     

    /**
     * @return the parent
     */
    public TokenPair getParent() {
        return parent;
    }

    /**
     * @param parent the parent to set
     */
    public void setParent(TokenPair parent) {
        this.parent = parent;
        this.parent.getChildren().add(this);
    }
}
