/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool;

import java.io.FileInputStream;
import org.antlr.v4.runtime.ANTLRInputStream;
import org.antlr.v4.runtime.CommonTokenStream;
import org.antlr.v4.runtime.tree.ParseTree;
import parsetool.datamodel.DataModelLexer;
import parsetool.datamodel.MyDataModelVisitor;
import parsetool.datamodel.models.Program;
import parsetool.error.ErrorListener;

/**
 *
 * @author Administrator
 */
public class DataModelParser {
    
    public static Program Parse(String text) throws Exception 
    {
        try{
            ANTLRInputStream input = new ANTLRInputStream(text);

            DataModelLexer lexer = new DataModelLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            parsetool.datamodel.DataModelParser parser = new parsetool.datamodel.DataModelParser(tokens);
            ErrorListener errorListener = new ErrorListener();
            lexer.addErrorListener(errorListener);
            //parser.removeErrorListeners();
            parser.addErrorListener(errorListener);
            
            ParseTree tree = parser.program();       

            MyDataModelVisitor loader = new MyDataModelVisitor();
            loader.visit(tree);

            Program db = loader.getModelDb();
            db.setErrors(errorListener.getErrors());
            return db;        
        }
        catch(Exception e)
        {
            String s = e.getLocalizedMessage();
            System.err.println(e);
            throw e;
        }        
    }
}
