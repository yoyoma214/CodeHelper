using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Net.Sockets;

namespace CodeHelper.Parser
{
    public class ConnectProxy
    {
        private string serverIp = null;
        private int serverPort = 0;
        private TcpClient tcpClient = new TcpClient();  

        //public Dictionary<string, IParser> Paerser = new Dictionary<string, IParser>();

        private static ConnectProxy _Instance = null;

        public static ConnectProxy Instance()
        {
            if (_Instance == null)
            {
                _Instance = new ConnectProxy();
            }

            if (!_Instance.tcpClient.Connected)
            {
                _Instance.Connect(); 
            }
            return _Instance;
        }

        private ConnectProxy()
        {
            Configuration cfa =
                ConfigurationManager.OpenExeConfiguration(this.GetType().Assembly.Location);
            
            serverIp = cfa.AppSettings.Settings["ServerIp"].Value;
            
            serverPort = int.Parse(cfa.AppSettings.Settings["ServerPort"].Value);                       
          
        }

        private void Connect()
        {
            try
            {
                if (tcpClient.Client.Connected)
                {
                    tcpClient.Close();
                }
                tcpClient = new TcpClient();
                tcpClient.Client.ReceiveTimeout = 20 * 1000;
                tcpClient.Connect(this.serverIp, this.serverPort);
            }
            catch (Exception e)
            {
            }
        }

        public bool Send(string msg)
        {           
            try
            {
                var stream = tcpClient.GetStream();
                var buff = System.Text.ASCIIEncoding.UTF8.GetBytes(msg);
                stream.Write(buff, 0, buff.Length);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string Read()
        {
            var buff = new byte[0];
            try
            {
                var newBuff = new Byte[1024 * 8];

                var l = tcpClient.Client.Receive(newBuff);
                buff = buff.Concat(newBuff.Take((int)l)).ToArray();

                while (tcpClient.Client.Available > 0)
                {

                    newBuff = new Byte[1024 * 8];
                    l = tcpClient.Client.Receive(newBuff);

                    buff = buff.Concat(newBuff.Take((int)l)).ToArray();
                }

                return ASCIIEncoding.UTF8.GetString(buff);

            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
