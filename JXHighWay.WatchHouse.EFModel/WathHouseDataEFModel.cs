﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;

namespace JXHighWay.WatchHouse.EFModel
{
    [TableAttrib("岗亭数据", "ID")]
    public struct WathHouseDataEFModel
    {
        [ColumnAttrib("ID")]
        public int? ID { get; set; }
        [ColumnAttrib("WatchHouseID")]
        public int? WatchHouseID { get; set; }
        [ColumnAttrib("MenZhuanTai")]
        public String MenZhuanTai { get; set; }
        [ColumnAttrib("DianChiSuo")]
        public String DianChiSuo { get; set; }
        [ColumnAttrib("JiXieSuo")]
        public String JiXieSuo { get; set; }
        [ColumnAttrib("BaoJingQi")]
        public String BaoJingQi { get; set; }
        [ColumnAttrib("Chuang")]
        public String Chuang { get; set; }
        [ColumnAttrib("FengMu")]
        public String FengMu { get; set; }
        [ColumnAttrib("ChuangDeng")]
        public String ChuangDeng { get; set; }

        [ColumnAttrib("Chuang2")]
        public String Chuang2 { get; set; }
        [ColumnAttrib("FengMu2")]
        public String FengMu2 { get; set; }
        [ColumnAttrib("ChuangDeng2")]
        public String ChuangDeng2 { get; set; }

        [ColumnAttrib("XinFeng")]
        public String XinFeng { get; set; }
        [ColumnAttrib("Deng")]
        public String Deng { get; set; }
        [ColumnAttrib("DiNuan")]
        public String DiNuan { get; set; }
        [ColumnAttrib("ZuoNuanJQ")]
        public String ZuoNuanJQ { get; set; }
        [ColumnAttrib("YouNuanJQ")]
        public String YouNuanJQ { get; set; }
        [ColumnAttrib("ShiLeiWD")]
        public Int16? ShiLeiWD { get; set; }
        [ColumnAttrib("ShiLeiSD")]
        public Int16? ShiLeiSD { get; set; }
        [ColumnAttrib("KongTiao")]
        public String KongTiao { get; set; }
        [ColumnAttrib("KongTiaoGZMS")]
        public String KongTiaoGZMS { get; set; }
        [ColumnAttrib("KongTiaoGZFL")]
        public String KongTiaoGZFL { get; set; }
        [ColumnAttrib("KongQiZL")]
        public String KongQiZL { get; set; }
        [ColumnAttrib("XinFengXTKQZL")]
        public Int16? XinFengXTKQZL { get; set; }

        [ColumnAttrib("XinFengDJ")]
        public Int16? XinFengDJ { get; set; }

        [ColumnAttrib("XinFengWD")]
        public Int16? XinFengWD { get; set; }

        [ColumnAttrib("RuKouAPM")]
        public Int16? RuKouAPM { get; set; }

        [ColumnAttrib("ChuKouAPM")]
        public Int16? ChuKouAPM { get; set; }

        [ColumnAttrib("CaiLuanKZWD")]
        public Int16? CaiLuanKZWD { get; set; }
        [ColumnAttrib("CaiLuanKZWBWD")]
        public Int16? CaiLuanKZWBWD { get; set; }
        [ColumnAttrib("CaiLuanKZDBWD")]
        public Int16? CaiLuanKZDBWD { get; set; }
        [ColumnAttrib("DianLiuJK")]
        public String DianLiuJK { get; set; }
        [ColumnAttrib("MenKongCKQ")]
        public String MenKongCKQ { get; set; }

        [ColumnAttrib("ChuangKongCKQ")]
        public String ChuangKongCKQ { get; set; }
        [ColumnAttrib("GongKongJSC")]
        public String GongKongJSC { get; set; }
        [ColumnAttrib("GongKongJSR")]
        public String GongKongJSR { get; set; }


        [ColumnAttrib("ChuangKongCKQ2")]
        public String ChuangKongCKQ2 { get; set; }
        [ColumnAttrib("GongKongJSC2")]
        public String GongKongJSC2 { get; set; }
        [ColumnAttrib("GongKongJSR2")]
        public String GongKongJSR2 { get; set; }


        [ColumnAttrib("DengGuanLD")]
        public Int16? DengGuanLD { get; set; }
        [ColumnAttrib("XieRuSJ")]
        public DateTime? XieRuSJ { get; set; }
    }


}
