﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MXKJ.DBMiddleWareLib;
using JXHighWay.WatchHouse.EFModel;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class Administrator
    {
        BasicDBClass m_BasicDBClass = null;
        public Administrator()
        {
            m_BasicDBClass = new BasicDBClass(DataBaseType.MySql);
        }

        public bool Add(string ZhangHao, string MiMa,
            bool GangTingGZ,bool LEDGongZhi,bool DianYuanGZ)
        {
            ManagerEFModel vModel = new ManagerEFModel()
            {
                DianYuanGZ = DianYuanGZ,
                GangTingGZ = GangTingGZ,
                LEDGongZhi = LEDGongZhi,
                MiMa = MiMa,
                ZhangHao = ZhangHao
            };
            return m_BasicDBClass.InsertRecord(vModel) > 1 ? true : false;
        }

        public bool Del( int ID)
        {
            return m_BasicDBClass.DeleteRecordByPrimaryKey<ManagerEFModel>(ID);
        }

        public bool Update( int ID,string ZhangHao, string MiMa,
            bool GangTingGZ, bool LEDGongZhi, bool DianYuanGZ)
        {
            ManagerEFModel vModel = new ManagerEFModel()
            {
                ID = ID,
                DianYuanGZ = DianYuanGZ,
                GangTingGZ = GangTingGZ,
                LEDGongZhi = LEDGongZhi,
                MiMa = MiMa,
                ZhangHao = ZhangHao
            };
            return m_BasicDBClass.UpdateRecord(vModel);
        }
    }
}
