/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool;

import com.google.gson.Gson;
import java.io.FileInputStream;
import org.antlr.v4.runtime.ANTLRInputStream;
import org.antlr.v4.runtime.CommonTokenStream;
import org.antlr.v4.runtime.tree.ParseTree;
import parsetool.error.ErrorListener;
import static parsetool.models.context.ParseType.Statements;
import parsetool.workflow.MyWorkflowVisitor;
import parsetool.workflow.WorkflowLexer;
import parsetool.workflow.models.Program;
import parsetool.workflow.models.State;

/**
 *
 * @author Administrator
 */
public class WorkflowParser {

    public static Program Parse(String text) throws Exception {
        try {        
            
            ANTLRInputStream input = new ANTLRInputStream(text);
            WorkflowLexer lexer = new WorkflowLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            parsetool.workflow.WorkflowParser parser = new parsetool.workflow.WorkflowParser(tokens);
            
             ErrorListener errorListener = new ErrorListener();
            lexer.addErrorListener(errorListener);     
            parser.addErrorListener(errorListener);
            
            ParseTree tree = parser.program();

            MyWorkflowVisitor loader = new MyWorkflowVisitor();
            loader.visit(tree);

            parsetool.workflow.models.Program db = loader.Root;
            db.setErrors(errorListener.getErrors());
            
            int i = 1;
            Gson gson = new Gson();
            String json = gson.toJson(db);
            System.out.print(json);
            return db;
        } catch (Exception e) {
            String s = e.getLocalizedMessage();
            e.printStackTrace();
        }
        return null;
    }
    
    public static State ParseStatements(String text) throws Exception {                       
        try {        
            
            ANTLRInputStream input = new ANTLRInputStream(text);
            WorkflowLexer lexer = new WorkflowLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            parsetool.workflow.WorkflowParser parser = new parsetool.workflow.WorkflowParser(tokens);
            
             ErrorListener errorListener = new ErrorListener();
            lexer.addErrorListener(errorListener);     
            parser.addErrorListener(errorListener);
            
            ParseTree tree = parser.state();

            MyWorkflowVisitor loader = new MyWorkflowVisitor();
            loader.Statements = new State();
            loader.visit(tree);
            
            loader.Statements.setErrors(errorListener.getErrors());
            
            int i = 1;
            Gson gson = new Gson();
            String json = gson.toJson(loader.Statements);
            System.out.print(json);
            return loader.Statements;
        } catch (Exception e) {
            String s = e.getLocalizedMessage();
            e.printStackTrace();
        }
        return null;
    }
}
