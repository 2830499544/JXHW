using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class WHQueueModel
    {
        
        public byte[] Data { get; set; }
        public string IPAddress { get; set; }
        public WHQueueModel(byte[] InData, string InIPAddress)
        {
            Data = InData;
            IPAddress = InIPAddress;
        }
    }
}
