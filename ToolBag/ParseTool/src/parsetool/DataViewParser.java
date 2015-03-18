/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool;

import com.google.gson.Gson;
import java.io.FileInputStream;
import org.antlr.v4.runtime.ANTLRInputStream;
import org.antlr.v4.runtime.CommonTokenStream;
import org.antlr.v4.runtime.tree.ParseTree;
import parsetool.dataview.DataViewLexer;
import parsetool.dataview.models.Program;
import parsetool.error.ErrorListener;

/**
 *
 * @author cqy
 */
public class DataViewParser {
    public static Program Parse(String text) throws Exception
    {
        try{
            
           ANTLRInputStream input = new ANTLRInputStream(text);
           DataViewLexer lexer = new DataViewLexer(input);
           CommonTokenStream tokens = new CommonTokenStream(lexer);
           parsetool.dataview.DataViewParser parser = new parsetool.dataview.DataViewParser(tokens);
            ErrorListener errorListener = new ErrorListener();
            lexer.addErrorListener(errorListener);     
            parser.addErrorListener(errorListener);
            
           ParseTree tree = parser.program();

           parsetool.dataview.MyDataViewVisitor loader = new parsetool.dataview.MyDataViewVisitor();
           loader.visit(tree);

           parsetool.dataview.models.Program db = loader.Root;
           db.setErrors(errorListener.getErrors());
           int i = 1;
           Gson gson = new Gson();
           String json = gson.toJson(db);
           System.out.print(json);
           return db;
        }
        catch(Exception e)
        {
            String s = e.getLocalizedMessage();
            e.printStackTrace();
        }
        return null;
    }
}
