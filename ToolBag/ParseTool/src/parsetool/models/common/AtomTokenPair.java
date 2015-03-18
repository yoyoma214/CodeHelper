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
public class AtomTokenPair extends TokenPair{
    private String name;
    private String value;
    private boolean is_Id;
    private boolean is_String;
    private boolean is_Int;
    private boolean is_Float;
    private boolean is_Double;
    private boolean is_Decimal;
    
    public AtomTokenPair()
    {    
    }
    public AtomTokenPair(String name)
    {    
        this.name = name;
    }
    public AtomTokenPair(String name,String value)
    {    
        this.name = name;
        this.value = value;
    }
 
    //private boolean is_Null;
    //private boolean is_Unkown;

    /**
     * @return the name
     */
    public String getName() {
        return name;
    }

    /**
     * @param name the name to set
     */
    public void setName(String name) {
        this.name = name;
    }

    /**
     * @return the value
     */
    public String getValue() {
        return value;
    }

    /**
     * @param value the value to set
     */
    public void setValue(String value) {
        this.value = value;
    }

    /**
     * @return the is_Id
     */
    public boolean isIs_Id() {
        return is_Id;
    }

    /**
     * @param is_Id the is_Id to set
     */
    public void setIs_Id(boolean is_Id) {
        this.is_Id = is_Id;
    }

    /**
     * @return the is_String
     */
    public boolean isIs_String() {
        return is_String;
    }

    /**
     * @param is_String the is_String to set
     */
    public void setIs_String(boolean is_String) {
        this.is_String = is_String;
    }

    /**
     * @return the is_Int
     */
    public boolean isIs_Int() {
        return is_Int;
    }

    /**
     * @param is_Int the is_Int to set
     */
    public void setIs_Int(boolean is_Int) {
        this.is_Int = is_Int;
    }

    /**
     * @return the is_Float
     */
    public boolean isIs_Float() {
        return is_Float;
    }

    /**
     * @param is_Float the is_Float to set
     */
    public void setIs_Float(boolean is_Float) {
        this.is_Float = is_Float;
    }

    /**
     * @return the is_Double
     */
    public boolean isIs_Double() {
        return is_Double;
    }

    /**
     * @param is_Double the is_Double to set
     */
    public void setIs_Double(boolean is_Double) {
        this.is_Double = is_Double;
    }

    /**
     * @return the is_Decimal
     */
    public boolean isIs_Decimal() {
        return is_Decimal;
    }

    /**
     * @param is_Decimal the is_Decimal to set
     */
    public void setIs_Decimal(boolean is_Decimal) {
        this.is_Decimal = is_Decimal;
    }
}
