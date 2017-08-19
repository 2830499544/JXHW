using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using MXKJ.DBMiddleWareLib;
using JXHighWay.WatchHouse.EFModel;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class Employee
    {
        BasicDBClass m_BasicDBClass = null;
        public Employee()
        {
            Config vConfig = new Config();
            BasicDBClass.DataSource = vConfig.DBSource;
            BasicDBClass.DBName = vConfig.DBName;
            BasicDBClass.Port = vConfig.DBPort;
            BasicDBClass.UserID = vConfig.DBUserName;
            BasicDBClass.Password = vConfig.DBPassword;
            m_BasicDBClass = new BasicDBClass(DataBaseType.MySql);
        }


        bool findGonHaoKaoHao(int gongHao,string kaHao)
        {
            bool vResult = false;
            string vSql = string.Format("Select *From `员工信息` Where KaHao='{0}' or GongHao={1}",kaHao,gongHao);
            EmployeeEFModel[] vSelectResult = m_BasicDBClass.SelectCustomEx<EmployeeEFModel>(vSql);
            if (vSelectResult == null || vSelectResult.Length > 0)
                vResult = true;
            return vResult;
        }

        public bool Add( string XingMing,string XingBie,int GongHao,
            string KaHao,string ZhaoPian,string XingJi,string GeYan,ref string OutInfo)
        {
            bool vResult = false;
            if (!findGonHaoKaoHao(GongHao, KaHao))
            {
                if (ZhaoPian != "")
                {
                    string vPath = System.Environment.CurrentDirectory;
                    string vNewPhotoName = string.Format("{0}.png", GongHao);
                    File.Copy(ZhaoPian, string.Format(@"{0}\Photo\{1}", vPath, vNewPhotoName),true);
                    ZhaoPian = vNewPhotoName;
                }
                EmployeeEFModel vModel = new EmployeeEFModel()
                {
                    XingMing = XingMing,
                    XingBie = XingBie,
                    GongHao = GongHao,
                    KaHao = KaHao,
                    ZhaoPian = ZhaoPian,
                    XingJi = XingJi,
                    GeYan = GeYan
                };
                vResult = m_BasicDBClass.InsertRecord(vModel) > 1 ? true : false;
            }
            else
            {
                OutInfo = "工号或卡号已经系统中存在";
            }
            return vResult;
        }

        public bool Del(int ID)
        {
            return m_BasicDBClass.DeleteRecordByPrimaryKey<EmployeeEFModel>(ID);
        }

        public bool Update(int ID,string XingMing, string XingBie, int GongHao,
            string KaHao, string ZhaoPian,string XingJi,string GeYan)
        {
            if (ZhaoPian != null)
            {
                string vPath = System.Environment.CurrentDirectory;
                string vNewPhotoName = string.Format("{0}.png", GongHao);
                if (ZhaoPian!="")
                    File.Copy(ZhaoPian, string.Format(@"{0}\Photo\{1}", vPath, vNewPhotoName),true);
                ZhaoPian = vNewPhotoName;
            }
            EmployeeEFModel vModel = new EmployeeEFModel()
            {
                ID=ID,
                XingMing = XingMing,
                XingBie = XingBie,
                GongHao = GongHao,
                KaHao = KaHao,
                ZhaoPian = ZhaoPian,
                XingJi = XingJi,
                GeYan = GeYan
            };
            return m_BasicDBClass.UpdateRecord(vModel);
        }

        public DataTable GetAllEmplyees()
        {
            return m_BasicDBClass.SelectAllRecords<EmployeeEFModel>();
        }

    }
}
