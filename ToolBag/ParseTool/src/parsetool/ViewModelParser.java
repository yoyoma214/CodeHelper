/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool;

import org.antlr.v4.runtime.ANTLRInputStream;
import org.antlr.v4.runtime.CommonTokenStream;
import org.antlr.v4.runtime.ConsoleErrorListener;
import org.antlr.v4.runtime.tree.ParseTree;
import parsetool.error.ErrorListener;
import parsetool.error.ErrorStrategy;
import parsetool.viewmodel.MyViewModelVisitor;
import parsetool.viewmodel.ViewModelLexer;
import parsetool.viewmodel.models.Program;
import parsetool.xmlmodel.MyXmlModelVisitor;
import parsetool.xmlmodel.XmlModelLexer;
import parsetool.xmlmodel.models.ModelDB;

/**
 *
 * @author Administrator
 */
public class ViewModelParser {
        public static Program Parse(String text) throws Exception 
    {
        try{
            ANTLRInputStream input = new ANTLRInputStream(text);

            ViewModelLexer lexer = new ViewModelLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            parsetool.viewmodel.ViewModelParser parser = new parsetool.viewmodel.ViewModelParser(tokens);
            ErrorListener errorListener = new ErrorListener();
            lexer.addErrorListener(errorListener);     
            parser.addErrorListener(errorListener);

            ParseTree tree = parser.program();       
            
            MyViewModelVisitor loader = new MyViewModelVisitor();
            loader.visit(tree);

            Program db = loader.Root;
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
