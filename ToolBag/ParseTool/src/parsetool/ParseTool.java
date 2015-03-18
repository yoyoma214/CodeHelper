/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool;

import com.google.gson.Gson;
import java.io.FileInputStream;
import java.io.InputStream;
import org.antlr.v4.runtime.ANTLRInputStream;
import org.antlr.v4.runtime.CommonTokenStream;
import org.antlr.v4.runtime.tree.ParseTree;
import org.antlr.v4.runtime.tree.ParseTreeListener;
import org.antlr.v4.runtime.tree.ParseTreeWalker;
//import org.apache.logging.log4j.Logger;
//import org.apache.log4j.slf4j.Logger;

import parsetool.datamodel.DataModelLexer;
import parsetool.datamodel.DataModelParser;
import parsetool.datamodel.MyDataModelVisitor;
import parsetool.datamodel.models.Program;
import parsetool.dataview.DataViewLexer;
import parsetool.dataview.DataViewParser;
import parsetool.viewmodel.ViewModelLexer;
import parsetool.viewmodel.ViewModelParser;
import parsetool.workflow.MyWorkflowVisitor;
import parsetool.workflow.WorkflowLexer;
import parsetool.workflow.WorkflowParser;
import parsetool.xmlmodel.XmlModelLexer;
import parsetool.xmlmodel.XmlModelParser;

/**
 *
 * @author cqy
 */
public class ParseTool {
    //private static final Logger logger = (Logger) LogManager.getLogger(ParseTool.class);
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws Exception  {
        // TODO code application logic here
         //Logger logger = (Logger) LogManager.getLogger(ParseTool.class);
       //
        for(int i = 0 ; i < 10 ;i ++){
            //logger.info("zhujiadun");
        }
       
        //test_dataview();
        //test_viewmodel();
        test_workflow();
                
        String inputFile = null;
        if ( args.length>0 ) inputFile = args[0];
        InputStream is = System.in;
        if ( inputFile!=null ) {
            //is = new FileInputStream(inputFile);
        }
        //test_test();
        //test_datamodel();
        //test_xmlmode();
        
        TcpServer server = new TcpServer();
        server.Start();
        
        //System.out.println("properties result = "+evalProp.exitS(tree.));
    }              
    private static void test_datamodel() throws Exception 
    {
        try{
        //FileInputStream is = new FileInputStream("C:\\Users\\cqy\\Desktop\\antlr\\test.txt");
        FileInputStream is = new FileInputStream("C:\\Users\\cqy\\Desktop\\antlr\\testDataModel.txt");
        
        String s = "aaaa a.b\n" +
"\n" +
"class Student \n" +
"     {\n" +
"          Id(\"Guid\",\"varchar(500)\",true,true),Id2(\"Guid\",\"varchar(500)\",true,true)\n" +
"     }\n" +
"\n" +
" class  Class\n" +
"     {\n" +
"          \n" +
"     }\n" +
"\n" +
"Student.map(ClassId,Class.Id,\"One_Many\");";
        
        ANTLRInputStream input = new ANTLRInputStream(is);
        
        DataModelLexer lexer = new DataModelLexer(input);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        DataModelParser parser = new DataModelParser(tokens);
        ParseTree tree = parser.program();
        
        //ParseTreeWalker walker = new ParseTreeWalker();
        /*
        MyTestListener evalProp = new MyTestListener();
        walker.walk((ParseTreeListener) evalProp, tree);
        int i = evalProp.result;
        */
        
        MyDataModelVisitor loader = new MyDataModelVisitor();
        loader.visit(tree);
        
        Program db = loader.getModelDb();
        int i = 1;
        
        }
        catch(Exception e)
        {
            String s = e.getLocalizedMessage();
        }
    }
    private static void test_xmlmode() throws Exception 
    {
try{
        //FileInputStream is = new FileInputStream("C:\\Users\\cqy\\Desktop\\antlr\\test.txt");
        FileInputStream is = new FileInputStream("D:\\study\\antlr\\xmlModel.test");
                
        ANTLRInputStream input = new ANTLRInputStream(is);
        
        XmlModelLexer lexer = new XmlModelLexer(input);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        XmlModelParser parser = new XmlModelParser(tokens);
        ParseTree tree = parser.program();
        
        //ParseTreeWalker walker = new ParseTreeWalker();
        /*
        MyTestListener evalProp = new MyTestListener();
        walker.walk((ParseTreeListener) evalProp, tree);
        int i = evalProp.result;
        */
        
        parsetool.xmlmodel.MyXmlModelVisitor loader = new parsetool.xmlmodel.MyXmlModelVisitor();
        loader.visit(tree);
        
        parsetool.xmlmodel.models.ModelDB db = loader.getModelDb();
        int i = 1;
        
        }
        catch(Exception e)
        {
            String s = e.getLocalizedMessage();
        }
    } 
    
    private static void test_dataview() throws Exception 
    {
       try{
         FileInputStream is = new FileInputStream("D:\\study\\antlr\\dataview.test");
                
        ANTLRInputStream input = new ANTLRInputStream(is);
        
        DataViewLexer lexer = new DataViewLexer(input);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        DataViewParser parser = new DataViewParser(tokens);
        ParseTree tree = parser.program();
        
        parsetool.dataview.MyDataViewVisitor loader = new parsetool.dataview.MyDataViewVisitor();
        loader.visit(tree);
        
        parsetool.dataview.models.Program db = loader.Root;
        int i = 1;
        Gson gson = new Gson();
        String json = gson.toJson(db);
        System.out.print(json);
        }
        catch(Exception e)
        {
            String s = e.getLocalizedMessage();
            e.printStackTrace();
        }
    }
    
    private static void test_viewmodel() throws Exception 
    {
       try{
         FileInputStream is = new FileInputStream("D:\\workspace\\viewmodel.test");
                
        ANTLRInputStream input = new ANTLRInputStream(is);
        
        ViewModelLexer lexer = new ViewModelLexer(input);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        ViewModelParser parser = new ViewModelParser(tokens);
        ParseTree tree = parser.program();
        
        parsetool.viewmodel.MyViewModelVisitor loader = new parsetool.viewmodel.MyViewModelVisitor();
        loader.visit(tree);
        
        parsetool.viewmodel.models.Program db = loader.Root;
        int i = 1;
        Gson gson = new Gson();
        String json = gson.toJson(db);
        System.out.print(json);
        }
        catch(Exception e)
        {
            String s = e.getLocalizedMessage();
            e.printStackTrace();
        }
    }
    
    private static void test_workflow() throws Exception 
    {
       try{
         FileInputStream is = new FileInputStream("e:\\antlr\\workflow.test");
         //FileInputStream is = new FileInputStream("D:\\workspace\\workflow.test");
                
        ANTLRInputStream input = new ANTLRInputStream(is);
        
        WorkflowLexer lexer = new WorkflowLexer(input);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        WorkflowParser parser = new WorkflowParser(tokens);
        ParseTree tree = parser.state();
        
        MyWorkflowVisitor loader = new MyWorkflowVisitor();
        loader.visit(tree);
        
        parsetool.workflow.models.Program db = loader.Root;
        int i = 1;
        Gson gson = new Gson();
        String json = gson.toJson(db);
        System.out.print(json);
        }
        catch(Exception e)
        {
            String s = e.getLocalizedMessage();
            e.printStackTrace();
        }
    }
}
