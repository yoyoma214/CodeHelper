/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package parsetool;

import com.google.gson.Gson;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.nio.CharBuffer;
import parsetool.datamodel.models.Program;
import parsetool.models.context.ParseInfo;
import parsetool.models.context.ParseType;

/**
 *
 * @author Administrator
 */
public class TcpClient implements Runnable {
    
    Socket socket  = null;
    
    public TcpClient(Socket socket)
    {
        this.socket = socket;
    }
    
    @Override
    public void run()
    {        
        BufferedReader is= null;
        PrintWriter os= null;
           try{           

           is=new BufferedReader(new InputStreamReader(socket.getInputStream(),"UTF8"));

            //由Socket对象得到输入流，并构造相应的BufferedReader对象

           os=new PrintWriter(socket.getOutputStream());

            while(true){
                
                CharBuffer cb = CharBuffer.allocate(1024*1024);

                int l= is.read(cb);
                if ( l == -1 )
                {
                    System.out.println("Error. no data");                    
                    break;
                }
                else if ( l >= cb.capacity() )
                {
                    os.println("must limit by 1M");
                    os.flush();
                    break;
                }
                else
                {        
                   cb.position(0);
                   char[] buff = new char[l];
                   cb.get(buff);
                   String text = new String(buff);       
                   //String text = cb.
                   
                   try{
                       Gson gson = new Gson();
                       ParseInfo parseInfo = gson.fromJson(text, ParseInfo.class);
                       
                       if(parseInfo.getType() == ParseType.DataModel)
                       {
                            Program db = DataModelParser.Parse(parseInfo.getContent());
                            if(db != null){
                                gson = new Gson();
                                String json = gson.toJson(db);
                                System.out.println(json);
                                if ( json.startsWith("com.google.gson"))
                                {
                                    String s = "";
                                }
                                os.println(json);
                            }
                       }
                       else if(parseInfo.getType() == ParseType.XmlModel)
                       {
                            parsetool.xmlmodel.models.ModelDB db = XmlModelParser.Parse(parseInfo.getContent());
                            if(db != null){
                                gson = new Gson();
                                
                                String json = gson.toJson(db);
                                 System.out.println(json);
                                if ( json.startsWith("com.google.gson"))
                                {
                                    String s = "";
                                }
                                os.println(json);
                            }
                       }
                       else if(parseInfo.getType() == ParseType.DataView)
                       {
                            parsetool.dataview.models.Program db = DataViewParser.Parse(parseInfo.getContent());
                            if(db != null){
                                gson = new Gson();
                                
                                String json = gson.toJson(db);
                                //System.out.println(json);
         
                                os.println(json);
                            }
                       }
                       else if(parseInfo.getType() == ParseType.ViewModel)
                       {
                            parsetool.viewmodel.models.Program db = ViewModelParser.Parse(parseInfo.getContent());

                            if(db != null){
                                gson = new Gson();
                                
                                String json = gson.toJson(db);
                                //System.out.println(json);
         
                                os.println(json);
                            }
                       }
                       else if(parseInfo.getType() == ParseType.WorkFlow)
                       {
                            parsetool.workflow.models.Program db = WorkflowParser.Parse(parseInfo.getContent());

                            if(db != null){
                                gson = new Gson();
                                
                                String json = gson.toJson(db);
                                //System.out.println(json);
         
                                os.println(json);
                            }
                       }
                       else if(parseInfo.getType() == ParseType.Statements)
                       {
                            parsetool.workflow.models.State db = WorkflowParser.ParseStatements(parseInfo.getContent());

                            if(db != null){
                                gson = new Gson();
                                
                                String json = gson.toJson(db);
                                //System.out.println(json);
         
                                os.println(json);
                            }
                       }
                       else if(parseInfo.getType() == ParseType.Expression )
                       {
                            parsetool.workflow.models.Program db = WorkflowParser.Parse(parseInfo.getContent());

                            if(db != null){
                                gson = new Gson();
                                
                                String json = gson.toJson(db);
                                //System.out.println(json);
         
                                os.println(json);
                            }
                       }
                   }
                   catch(Exception e)
                   {
                        os.println(e.getMessage());
                        os.flush();
                        break;
                   }
                                     
                   os.flush();
                }                
            }
 
            }
            catch(Exception e)
            {
                System.out.println("Error."+e);
            }
           
           try{
               if (is != null){
                    is.close();
               }
           }catch(Exception e)
                   {
           }
           
           try{
               if(os != null){
                    os.close();
               }
           }catch(Exception e)
                   {
           }
           
           try{
               if(socket!= null){
                    socket.close();
               }
           }catch(Exception e)
                   {
           }       
        }
    
    
    }

