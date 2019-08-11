using ElectMediaCenter_Project;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;


namespace Client
{
    /*class Program
    {
        static void Main(string[] args)
        {
            MyClient myClient = new MyClient();
            myClient.StarUp();
            while (true)
            {
                string str = Console.ReadLine();
                myClient.Send(str);
            }
        }
    }*/

    public class MyClient
    {
        //客户端的套接字
        private Socket _client;
        //接收服务器消息的线程
        private Thread _acceptServerMsg;
        /// <summary>
        /// 启动客户端
        /// </summary>
        public void StarUp()
        {
            
            //建立套接字
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //连接到服务器
            
            _client.Connect(Storage.FileLocationStorage.IP_dress, 10000);
            //开启接收消息的线程
            _acceptServerMsg = new Thread(AcceptServerMsg);
            _acceptServerMsg.Start();

        }
        /// <summary>
        /// 接收服务器的消息
        /// </summary>
        public void AcceptServerMsg()
        {
            //声明一个接收消息的字节数组
            byte[] buffer = new byte[1024 * 64];
            while (true)
            {
                try
                {
                    //接收消息
                    int len = _client.Receive(buffer);
                    string str = Encoding.UTF8.GetString(buffer, 0, len);
                    MessageBox.Show(str);
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        /// <summary>
        /// 发消息
        /// </summary>        
        public void Send(string str)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            _client.Send(buffer);
        }
    }
}
