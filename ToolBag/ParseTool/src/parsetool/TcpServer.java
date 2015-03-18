/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package parsetool;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.net.SocketAddress;
import java.nio.CharBuffer;

/**
 *
 * @author cqy
 */
public class TcpServer {
   
    Socket socket = null;
    
    ServerSocket server=null;
    
    public TcpServer(){
 
       
    }
    
    public void Start() throws Exception
    {
     
         try{
            
            try{

                server=new ServerSocket(4701);

            }catch(Exception e) {

                System.out.println("can not listen to:"+e);

            }

            Socket socket=null;
            while(true){
                try{

                socket=server.accept();

                
                TcpClient client = new TcpClient(socket);
                 new Thread(client).start();
              

                }catch(Exception e) {

                    System.out.println("Error."+e);

   
                }
            }

        }catch(Exception e){

            System.out.println("Error:"+e);           

            socket.close(); 

            server.close(); 
        }            
    }
    
    public void Stop()
    {
        try
        {
            this.server.close();
        }
        catch(Exception e)
        {
            
        }
    }
}
