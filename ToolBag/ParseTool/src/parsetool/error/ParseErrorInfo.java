/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool.error;

/**
 *
 * @author Administrator
 */
public class ParseErrorInfo {
    private int errorType;
    private int line;
    private int charPositionInLine;
    private String message;

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

    /**
     * @return the message
     */
    public String getMessage() {
        return message;
    }

    /**
     * @param message the message to set
     */
    public void setMessage(String message) {
        this.message = message;
    }

    /**
     * @return the errorType
     */
    public int getErrorType() {
        return errorType;
    }

    /**
     * @param errorType the errorType to set
     */
    public void setErrorType(int errorType) {
        this.errorType = errorType;
    }
}
