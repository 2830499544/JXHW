﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MXKJ.DBMiddleWareLib;
using JXHighWay.WatchHouse.EFModel;

namespace JXHighWay.WatchHouse.Manager
{
    public class Employee
    {
        BasicDBClass m_BasicDBClass = null;
        public Employee()
        {
            m_BasicDBClass = new BasicDBClass(DataBaseType.MySql);
        }


        bool findGonHaoKaoHao(string gongHao,string kaHao)
        {
            bool vResult = false;
            string vSql = string.Format("Select *From [员工信息] Where KaHao='{0}' or GongHao='{1}'",kaHao,gongHao);
            EmployeeEFModel[] vSelectResult = m_BasicDBClass.SelectCustomEx<EmployeeEFModel>(vSql);
            if (vSelectResult == null && vSelectResult.Length == 0)
                vResult = true;
            return vResult;
        }

        public bool Add( string XingMing,string XingBie,string GongHao,
            string KaHao,string ZhaoPian)
        {
            string vPath = System.Environment.CurrentDirectory;
            string vNewPhotoName = string.Format("{0:yyyymmddhhMMss}.jpg",DateTime.Now);
            File.Copy(ZhaoPian, string.Format("{0}{1}",vPath, vNewPhotoName));
            ZhaoPian = vNewPhotoName;
            EmployeeEFModel vModel = new EmployeeEFModel()
            {
                XingMing = XingMing,
                XingBie = XingBie,
                GongHao = GongHao,
                KaHao = KaHao,
                ZhaoPian = ZhaoPian
            };
            return m_BasicDBClass.InsertRecord(vModel) > 1 ? true : false;
        }

        public bool Del(int ID)
        {
            return m_BasicDBClass.DeleteRecordByPrimaryKey<EmployeeEFModel>(ID);
        }

        public bool Update(int ID,string XingMing, string XingBie, string GongHao,
            string KaHao, string ZhaoPian)
        {
            EmployeeEFModel vModel = new EmployeeEFModel()
            {
                ID=ID,
                XingMing = XingMing,
                XingBie = XingBie,
                GongHao = GongHao,
                KaHao = KaHao,
                ZhaoPian = ZhaoPian
            };
            return m_BasicDBClass.UpdateRecord(vModel);
        }
    }
}
