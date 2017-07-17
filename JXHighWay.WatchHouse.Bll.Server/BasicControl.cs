using JXHighWay.WatchHouse.Net;
using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class BasicControl
    {
        protected SocketManager m_SocketManager;
        protected BasicDBClass m_BasicDBClass_Receive;
        protected BasicDBClass m_BasicDBClass_Send;
        protected BasicDBClass m_BasicDBClass_Return;

        protected  int Port;

        /// <summary>
        /// 缓冲区大小
        /// </summary>
        protected const int BufferSize = 1024;
        /// <summary>
        /// 最大连接数
        /// </summary>
        protected const int MaxConnNum = 100;


        /// <summary>
        /// 接收岗亭状态数据队列
        /// </summary>
        public Queue<WHQueueModel> ReceiveQueue { get; set; }

        /// <summary>
        /// 客户端字典表
        /// </summary>
        protected Dictionary<string, string> m_ClientDict { get; set; }

        public BasicControl()
        {
            Config vConfig = new Config();
            //Port = vConfig.WatchHousePort;
            BasicDBClass.DataSource = vConfig.DBSource;
            BasicDBClass.DBName = vConfig.DBName;
            BasicDBClass.Port = vConfig.DBPort;
            BasicDBClass.UserID = vConfig.DBUserName;
            BasicDBClass.Password = vConfig.DBPassword;
            m_BasicDBClass_Receive = new BasicDBClass(DataBaseType.MySql);
            m_BasicDBClass_Send = new BasicDBClass(DataBaseType.MySql);
            m_BasicDBClass_Return = new BasicDBClass(DataBaseType.MySql);
            m_ClientDict = new Dictionary<string, string>();

        }

        protected virtual AsyncUserToken findAsyncUserToken(string id)
        {
            AsyncUserToken vResult = null;
            if (m_ClientDict.ContainsKey(id))
            {
                string vIPAddress = m_ClientDict[id];
                vResult = m_SocketManager.ClientList.Where(m => m.IPAddress.ToString() == vIPAddress).FirstOrDefault();
            }

            return vResult;
        }

        

    }
}
