/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.models.common;

/**
 *
 * @author Administrator
 */
public class Token {
    
    private int line ;
    private int charPositionInLine;
    
    public Token()
    {
        
    }
    
    public Token(org.antlr.v4.runtime.Token token)
    {
        this.line = token.getLine();
        this.charPositionInLine = token.getCharPositionInLine();
    }

    public Token(int line, int charPositionInLine) {
        
        this.line =line;
        this.charPositionInLine = charPositionInLine;
    }
    
     /**
     * @return the line
     */
    public int getLine() {
        return line;
    }

    /**
     * @param line the line to set
     */
    public void setLine(int line) {
        this.line = line;
    }

    /**
     * @return the charPositionInLine
     */
    public int getCharPositionInLine() {
        return charPositionInLine;
    }

    /**
     * @param charPositionInLine the charPositionInLine to set
     */
    public void setCharPositionInLine(int charPositionInLine) {
        this.charPositionInLine = charPositionInLine;
    }
}
