using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Client
{
    public class DiNuanStateModel
    {
        public bool DiNuan { get; set; }

        public bool ZuoNuanJQ { get; set; }
        public bool YouNuanJQ { get; set; }

        /// <summary>
        /// 当前温度
        /// </summary>
        public int DanQianWD { get; set; }
        /// <summary>
        /// 设置温度
        /// </summary>
        public int SheZhiWD { get; set; }
    }
}
