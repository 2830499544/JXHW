using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Bll.Client.GanTing
{
    public class MenChuangStateInfo
    {
        /// <summary>
        /// 报警器
        /// </summary>
        public bool BaoJinQi { get; set; }
        /// <summary>
        /// 门
        /// </summary>
        public bool Men { get; set; }
        /// <summary>
        /// 锁
        /// </summary>
        public bool Shuo { get; set; }


        /// <summary>
        /// 风幕灯(单向)
        /// </summary>
        public bool FengMuDeng { get; set; }
        /// <summary>
        /// 风幕(单向)
        /// </summary>
        public bool FengMu { get; set; }
       /// <summary>
       /// 自动窗(单向)
       /// </summary>
        public bool ZiDonGChuang { get; set; }
        /// <summary>
        /// 窗(单向)
        /// </summary>
        public bool Chuang { get; set; }


        /// <summary>
        /// 风幕灯(双向)
        /// </summary>
        public bool FengMuDeng2 { get; set; }
        /// <summary>
        /// 风幕(双向)
        /// </summary>
        public bool FengMu2 { get; set; }
        /// <summary>
        /// 自动窗(双向)
        /// </summary>
        public bool ZiDonGChuang2 { get; set; }
        /// <summary>
        /// 窗(双向)
        /// </summary>
        public bool Chuang2 { get; set; }

    }
}
