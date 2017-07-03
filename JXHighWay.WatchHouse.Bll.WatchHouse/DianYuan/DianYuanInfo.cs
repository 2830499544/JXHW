using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Client.DianYuan
{
    public class DianYuanInfo
    {
        /// <summary>
        /// 路号
        /// </summary>
        public int LuHao { get; set; }
        /// <summary>
        /// 电流
        /// </summary>
        public int DianLiu { get; set; }

        public int DianYa { get; set; }
        /// <summary>
        /// 开关状态
        /// </summary>
        public bool ZhuangTai { get; set; }

    }
}
