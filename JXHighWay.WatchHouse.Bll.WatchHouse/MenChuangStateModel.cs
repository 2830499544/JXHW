using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Client
{
    public class MenChuangStateModel
    {
        /// <summary>
        /// 风幕灯
        /// </summary>
        public bool FengMuDeng { get; set; }
        /// <summary>
        /// 风幕
        /// </summary>
        public bool FengMu { get; set; }
       /// <summary>
       /// 自动窗
       /// </summary>
        public bool ZiDonGChuang { get; set; }
        /// <summary>
        /// 报警器
        /// </summary>
        public bool BaoJinQi { get; set; }
        /// <summary>
        /// 门
        /// </summary>
        public bool Men { get; set; }
        /// <summary>
        /// 窗
        /// </summary>
        public bool Chuang { get; set; }
    }
}
