using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hostsmanager
{
    public class Proxy
    {
        public Proxy()
        {
        }

        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;

        public void setProxy(string proxyhost, bool proxyEnabled)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
            const string keyName = userRoot + "\\" + subkey;

            Registry.SetValue(keyName, "ProxyServer", proxyhost);
            Registry.SetValue(keyName, "ProxyEnable", proxyEnabled ? 1 : 0);

            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
        }


  

        private static int attempts = 0;
        private static int MAXFILESIZE = 200 * 1024 * 1024; //MB 

        private static string readData(TcpClient tcpClient)
        {
            var clientStream = tcpClient.GetStream();
            var dataFromClient = string.Empty;
            var buffer = new byte[MAXFILESIZE];
            if (!clientStream.CanRead)
                return "";
            tcpClient.ReceiveTimeout = 20;
            try
            {
                int readCount;
                while ((readCount = clientStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    dataFromClient += Encoding.ASCII.GetString(buffer, 0, readCount);
                    
                    
                } 
                return dataFromClient.ToString();
            }
            catch (Exception ex)
            {
                var socketExept = ex.InnerException as SocketException; 
                return dataFromClient.ToString();
            }
        }


        public void AcceptSockets()
        {


              setProxy("127.0.0.1:8881", true);
            TcpListener listener = new TcpListener(IPAddress.Any, 8881);
            listener.Start();
            while (true) {
                TcpClient client = listener.AcceptTcpClient();
                readData(client);
                client.Close();
            }
            //while (true)
            //{
                
            //    setProxy("127.0.0.1:8881", true);
                 
            //    TcpListener listener = new TcpListener(IPAddress.Any, 8881);
            //    listener.Start();
                 
            //    Socket sock = listener.AcceptSocket();
                 
            //    sock.DontFragment = true;
            //    Byte[] fromIE = null;
            //    fromIE = new Byte[MAXFILESIZE];
            //    int length = sock.Receive(fromIE, 0, MAXFILESIZE, SocketFlags.None);
            //    Byte[] GET = new Byte[length];
            //    for (int i = 0; i < length; i++)
            //    {
            //        GET[i] = fromIE[i];
            //    } 
                
            //    String input = Encoding.ASCII.GetString(GET);
            //    TcpClient outServer = new TcpClient(); 
            //    String ServerIP = getReceivingIP(input);
            //    try
            //    {
            //        IPAddress ipAddr = Dns.GetHostEntry(ServerIP).AddressList[0];

            //        outServer.Connect(ipAddr, 80);
            //        NetworkStream stream = outServer.GetStream();
            //        Encoding encode = System.Text.Encoding.GetEncoding("ks_c_5601-1987");
            //        StreamReader readerSream = new StreamReader(stream, encode);
            //        for (int i = 0; i < length; i++)
            //        {
            //            stream.WriteByte(GET[i]);
            //        } 
            //        //Recieve response containing webpage and pictures from
            //        //Destination server
            //        byte[] fromServer = null;
            //        fromServer = new byte[MAXFILESIZE];
            //        if (stream.CanRead)
            //        {
            //            length = stream.Read(fromServer, 0, fromServer.Length); 
            //            sock.Send(fromServer, length, SocketFlags.None);
            //        }
            //    }
            //    catch { 
                
            //    }
            //    sock.Close();
            //    listener.Stop();
            //    //setProxy("", false);

            //    break;

            //}
            //Console.WriteLine("메서드 끝");
            //AcceptSockets();
            //try
            //{  
            //    TcpListener listener = new TcpListener(IPAddress.Any,8881);
            //    listener.Start();
            //    while (true)
            //    { 
            //        Socket sock =  listener.AcceptSocket();

            //        sock.DontFragment = true;
            //        Byte[] fromIE = null;
            //        fromIE = new Byte[MAXFILESIZE];
            //        flag = 1;
            //        //Recievies the GET command from IE
            //        int length = sock.Receive(fromIE, 0, MAXFILESIZE, SocketFlags.None);
            //        Byte[] GET = new Byte[length];
            //        for (int i = 0; i < length; i++)
            //        {
            //            GET[i] = fromIE[i];
            //        }
            //        flag = 2;
            //        //Translates Bytes -> string
            //        String input = Encoding.ASCII.GetString(GET);
            //        flag = 3;
            //        TcpClient outServer = new TcpClient();
            //        //Extracts destination server from GET command
            //        String ServerIP = getReceivingIP(input);
            //        flag = 4;
            //        //Connects to Destination Server 
            //        if (ServerIP.Contains("443"))break;
            //        IPAddress ipAddr = Dns.GetHostEntry(ServerIP).AddressList[0];

            //        Console.WriteLine(ipAddr);

            //        //outServer.Connect(ipAddr, 80); 
            //        //flag = 5;
            //        //Retrieves Stream and writes entire
            //        //NetworkStream stream = outServer.GetStream(); 
            //        //for (int i = 0; i < length; i++)
            //        //{
            //        //    stream.WriteByte(GET[i]);
            //        //}
            //        //flag = 6;
            //        ////Recieve response containing webpage and pictures from
            //        ////Destination server
            //        //byte[] fromServer = null;
            //        //fromServer = new byte[MAXFILESIZE];
            //        //if (stream.CanRead)
            //        //{
            //        //    length = stream.Read(fromServer, 0, fromServer.Length);
            //        //    flag = 7;
            //        //    sock.Send(fromServer, length, SocketFlags.None);
            //        //}
            //        //attempts = 0;
            //        sock.Close();
            //    }
            //}
            //catch (Exception ex)
            //{ //Connection Errors
            //    Console.WriteLine(ex.ToString());
            //    Console.WriteLine();
            //    Console.WriteLine("Last Successful Flag at: " + flag);
            //    //3 consecutive failed attempts before stopping connection.
            //    if (++attempts <= 3)
            //    {
            //        Console.WriteLine("Attempts: " + attempts);
            //        Console.WriteLine();
            //        AcceptSockets();
            //    }
            //    //Infinite loop so any errors remain
            //    //On screen to be read
            //    while (true) { }
            //}

        }
        private static String getReceivingIP(String input)
        {
            //Example of Input:
            //GET http://www.google.com/ HTTP/1.1
            //Accept: image/gif ....
            //.
            //.
            //.
            //Host: www.google.com
            //...
            //This returns www.google.com from host line
            //Find beginning of host in host line
            int begin = input.IndexOf("\r\nHost: ") + 8;
            //find ending of host
            int end = input.IndexOf("\r\n", begin);
            int length = end - begin;
            //get host
            String url = input.Substring(begin, length);
            Console.WriteLine(url);
            Console.WriteLine();
            //return host
            return url;
        }
    }
}
