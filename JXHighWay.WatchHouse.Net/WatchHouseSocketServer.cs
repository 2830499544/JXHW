using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace JXHighWay.WatchHouse.Net
{
    public class WatchHouseSocketServer
    {
        bool m_StartListen = false;
        readonly string m_IP;
        readonly int m_Port;
        Socket m_Socket = null;
        static Mutex m_maxNumberAcceptedClients = new Mutex();
        public WatchHouseSocketServer(string IP,int Port)
        {
            m_IP = IP;
            m_Port = Port;
        }


        public void  StartLListen()
        {
            IPAddress vIP = IPAddress.Parse(m_IP);
            IPEndPoint vIPE = new IPEndPoint(vIP,m_Port);
            m_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            m_Socket.Bind(vIPE);
            m_Socket.Listen(0);
            m_StartListen = true;
            while(m_StartListen)
            {
                 m_Socket.AcceptAsync(new SocketAsyncEventArgs());
            }
        }

        void StartAccept(SocketAsyncEventArgs acceptEventArgs)
        {
            if (acceptEventArgs == null)
            {
                acceptEventArgs = new SocketAsyncEventArgs();
                acceptEventArgs.Completed += AcceptEventArgs_Completed;
            }
            else
            {
                acceptEventArgs.AcceptSocket = null; //释放上次绑定的Socket，等待下一个Socket连接  
            }

            m_maxNumberAcceptedClients.WaitOne(); //获取信号量  
            bool willRaiseEvent = m_Socket.AcceptAsync(acceptEventArgs);
            if (!willRaiseEvent)
            {
                ProcessAccept(acceptEventArgs);
            }
        }

        private void AcceptEventArgs_Completed(object sender, SocketAsyncEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ProcessAccept(SocketAsyncEventArgs acceptEventArgs)
        {
            acceptEventArgs.AcceptSocket.LocalEndPoint, acceptEventArgs.AcceptSocket.RemoteEndPoint);

            AsyncSocketUserToken userToken = m_asyncSocketUserTokenPool.Pop();
            m_asyncSocketUserTokenList.Add(userToken); //添加到正在连接列表  
            userToken.ConnectSocket = acceptEventArgs.AcceptSocket;
            userToken.ConnectDateTime = DateTime.Now;

            try
            {
                bool willRaiseEvent = userToken.ConnectSocket.ReceiveAsync(userToken.ReceiveEventArgs); //投递接收请求  
                if (!willRaiseEvent)
                {
                    lock (userToken)
                    {
                        ProcessReceive(userToken.ReceiveEventArgs);
                    }
                }
            }
            catch (Exception E)
            {
                Program.Logger.ErrorFormat("Accept client {0} error, message: {1}", userToken.ConnectSocket, E.Message);
                Program.Logger.Error(E.StackTrace);
            }

            StartAccept(acceptEventArgs); //把当前异步事件释放，等待下次连接  
        }
    }
}
