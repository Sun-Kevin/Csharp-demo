using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Management;
using System.Net;

namespace CsharpDemo
{
    class XmlSocket
    {
        /*
        //异步socket侦听从客户端传来的数据
        public static string data=null;
        //Threadsignal.线程用一个指示是否将初始状态设置为终止的布尔值初始化ManualResetEvent类的新实例。
        public static ManualResetEventallDone = new ManualResetEvent(false);

        public static void StartListening()
        {
        //传入数据缓冲
        byte[] bytes = new Byte[1024];
        //建立本地端口
        IPAddress ipAddress;
        String ipString = ConfigurationManager.AppSettings.Get("SocketIP");
        if(ipString == null || ipString == String.Empty)
        {
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        ipAddress = ipHostInfo.AddressList[0];
        }
        else
        {
        ipAddress = IPAddress.Parse(ipString);
        }
        int port;
        String portString = ConfigurationManager.AppSettings.Get("SocketPort");
        if(portString == null || portString == String.Empty)
        {
        port=11001;
        }
        else
        {
        port=int.Parse(portString);
        }
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
        Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //绑定端口和数据
        listener.Bind(localEndPoint);
        listener.Listen(100);
        while(true)
        {//设置无信号状态的事件
        allDone.Reset();
        //重启异步连接
        listener.BeginAccept(new AsyncCallback(AcceptCallback),listener);
        //等待连接创建后继续
        allDone.WaitOne();
        }
        public static void AcceptCallback(IAsyncResult ar)
        {
        //接受回调方法。该方法的此节向主应用程序线程发出信号，让它继续处理并建立与客户端的连接
        allDone.Set();
        //获取客户端请求句柄
        Socket listener = (Socket)ar.AsyncState;
        Socket handler = listener.EndAccept(ar);
        StateObject state = new StateObject();
        state.workSocket = handler;
        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback),state);
        }
        //与接受回调方法一样，读取回调方法也是一个AsyncCallback委托。该方法将来自客户端套接字的一个或多个字节读入数据缓冲区，然后再次调用BeginReceive方法，直到客户端发送的数据完成为止。从客户端读取整个消息后，在控制台上显示字符串，并关闭处理与客户端的连接的服务器套接字。
        public static void ReadCallback(IAsyncResult ar)
        {
        String content = String.Empty;
        //创建自定义的状态对象
        StateObject state = (StateObject)ar.AsyncState;
        Socket handler = state.workSocket;//处理的句柄
        //读出
        int bytesRead = handler.EndReceive(ar);
        if(bytesRead>0)
        {
        String len = Encoding.UTF8.GetBytes(result).Length.ToString().PadLeft(8，’0′）;
        log.writeLine(len);
        Send(len + result, handler);
        }
        }
        private static void Send(string data, Socket handler)
        {
        byte[] byteData = Encoding.UTF8.GetBytes(data);
        handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler);
        }
        private static void SendCallback(IAsyncResult ar)
        {
        Socket handler = (Socket)ar.AsyncState;
        //向远端发送数据
        int bytesSent = handler.EndSend(ar);
        StateObject state = new StateObject();
        state.workSocket = handler;
        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback),state);
        handler.Shutdown(SocketShutdown.Both);
        handler.Close();
        }
        public static void StopListening()
        {
            allDone.Close();
            log.close();
        }
        */
    }
}
