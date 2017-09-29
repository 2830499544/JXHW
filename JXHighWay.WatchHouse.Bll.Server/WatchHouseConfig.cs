using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MXKJ.DBMiddleWareLib;
using JXHighWay.WatchHouse.EFModel;

namespace JXHighWay.WatchHouse.Bll.Server
{
    public class WatchHouseConfig
    {
        BasicDBClass m_BasicDBClass = null;
        public WatchHouseConfig()
        {
            Config vConfig = new Config();
            BasicDBClass.DataSource = vConfig.DBSource;
            BasicDBClass.DBName = vConfig.DBName;
            BasicDBClass.Port = vConfig.DBPort;
            BasicDBClass.UserID = vConfig.DBUserName;
            BasicDBClass.Password = vConfig.DBPassword;
            m_BasicDBClass = new BasicDBClass(DataBaseType.MySql);
        }

        bool findGanTing(int GangTingID,string DianYuanID)
        {
            string vSql = string.Format("Select *From `岗亭配置` Where GangTingID={0} or DianYuan1ID='{1}'", GangTingID, DianYuanID);
            return m_BasicDBClass.SelectCustomEx<WatchHouseConfigEFModel>(vSql).Length > 0 ? true : false;
        }

        public DataTable GetAll()
        {
            DataTable vTable = m_BasicDBClass.SelectAllRecords<WatchHouseConfigEFModel>();
            vTable.Columns.Add("XuHao", typeof(int));
            vTable.AcceptChanges();
            for(int i=0;i<vTable.Rows.Count;i++)
            {
                vTable.Rows[i]["XuHao"] = i + 1;
            }
            vTable.AcceptChanges();

            return vTable;
        }

        public DataTable GetSwitchTable( string DianYuanID )
        {
            PowerSwithConfigEFModel vPowerSwithConfigEFModel = new PowerSwithConfigEFModel()
            {
                DianYuanID = DianYuanID
            };
            return m_BasicDBClass.SelectRecords(vPowerSwithConfigEFModel);
        }

        public void SaveSwitchTable( DataTable SwitchTable )
        {

            foreach (  DataRow vTempRow in SwitchTable.Rows  )
            {
                PowerSwithConfigEFModel vModel = new PowerSwithConfigEFModel();
                CommClass.ConvertDataRowToStruct(ref vModel, vTempRow);
                switch ( vTempRow.RowState )
                {
                    case DataRowState.Added:
                        m_BasicDBClass.InsertRecord(vModel);
                        break;
                    case DataRowState.Deleted:
                        m_BasicDBClass.DeleteRecordByPrimaryKey<PowerSwithConfigEFModel>(vModel.ID);
                        break;
                    case DataRowState.Modified:
                        m_BasicDBClass.UpdateRecord(vModel);
                        break;
                }
            }
        }

        public bool Del(int ID)
        {
            return m_BasicDBClass.DeleteRecordByPrimaryKey< WatchHouseConfigEFModel>(ID);
        }

        public bool Update(int ID, int GanTingID, string GanTingMC, string GanTingLX,
            string Led1IP, int LED1Gao,int LED1Kuan,string Led2IP,int Led2Gao,int Led2Kuan,
            string DianYuanID1,string DianYuanID2,
            DataTable SwitchInfoTable1,DataTable SwitchInfoTable2,
            ref string OutInfo)
        {
            bool vResult = false;
            WatchHouseConfigEFModel  vSelectRecord = m_BasicDBClass.SelectRecordByPrimaryKeyEx<WatchHouseConfigEFModel>(ID);
            string vOldDianYuanID1 = vSelectRecord.DianYuan1ID;
            string vOldDianYuanID2 = vSelectRecord.DianYuan2ID;

            WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
            {
                GangTingID = GanTingID,
                GangTingMC = GanTingMC,
                GangTingLX = GanTingLX,

                GuanGaoPing1IP = Led1IP,
                GuanGao1Gao = LED1Gao,
                GuanGao1Kuang = LED1Kuan,

                GuanGaoPing2IP = Led2IP,
                GuanGao2Gao = Led2Gao,
                GuanGao2Kuang = Led2Kuan,

                DianYuan1ID = DianYuanID1,
                DianYuan2ID = DianYuanID2,
                ID = ID,
                OrderID = convertWatchHouseLXToOrderID(GanTingLX)
            };
            m_BasicDBClass.TransactionBegin();
            if (vResult = m_BasicDBClass.UpdateRecord(vWatchHouseConfigEFModel))
            {
                if (DianYuanID1 != vOldDianYuanID1)
                {
                    m_BasicDBClass.DeleteRecordCustom<PowerSwithConfigEFModel>(string.Format("DianYuanID='{0}'", vOldDianYuanID1));
                    if (SwitchInfoTable1 != null)
                    {
                        foreach (DataRow vTempSwitch in SwitchInfoTable1.Rows)
                        {
                            PowerSwithConfigEFModel vModel = new PowerSwithConfigEFModel();
                            vModel.DianYuanID = DianYuanID1;
                            CommClass.ConvertDataRowToStruct(ref vModel, vTempSwitch);
                            vResult = m_BasicDBClass.InsertRecord(vModel) > 0 ? true : false;

                            if (!vResult)
                            {
                                m_BasicDBClass.TransactionRollback();
                                break;
                            }
                        }
                    }
                    else if (SwitchInfoTable1 != null)
                    {
                        foreach (DataRow vTempSwitch in SwitchInfoTable1.Rows)
                        {
                            PowerSwithConfigEFModel vModel = new PowerSwithConfigEFModel();
                            vModel.DianYuanID = DianYuanID1;

                            switch (vTempSwitch.RowState)
                            {
                                case DataRowState.Added:
                                    CommClass.ConvertDataRowToStruct(ref vModel, vTempSwitch);
                                    vResult = m_BasicDBClass.InsertRecord(vModel) > 0 ? true : false;
                                    break;
                                case DataRowState.Deleted:
                                    vTempSwitch.RejectChanges();
                                    int vID = (int)vTempSwitch["ID"];
                                    vResult = m_BasicDBClass.DeleteRecordByPrimaryKey<PowerSwithConfigEFModel>(vID);
                                    vTempSwitch.Delete();
                                    break;
                                case DataRowState.Modified:
                                    CommClass.ConvertDataRowToStruct(ref vModel, vTempSwitch);
                                    vResult = m_BasicDBClass.UpdateRecord(vModel);
                                    break;
                            }
                            if (!vResult)
                            {
                                m_BasicDBClass.TransactionRollback();
                                break;
                            }
                        }
                    }

                    if (DianYuanID2 != vOldDianYuanID2)
                    {
                        m_BasicDBClass.DeleteRecordCustom<PowerSwithConfigEFModel>(string.Format("DianYuanID='{0}'", vOldDianYuanID2));
                        foreach (DataRow vTempSwitch in SwitchInfoTable2.Rows)
                        {
                            PowerSwithConfigEFModel vModel = new PowerSwithConfigEFModel();
                            vModel.DianYuanID = DianYuanID1;
                            CommClass.ConvertDataRowToStruct(ref vModel, vTempSwitch);
                            vResult = m_BasicDBClass.InsertRecord(vModel) > 0 ? true : false;
                            if (!vResult)
                            {
                                m_BasicDBClass.TransactionRollback();
                                break;
                            }
                        }
                    }
                    else if (SwitchInfoTable2 != null)
                    {
                        foreach (DataRow vTempSwitch in SwitchInfoTable2.Rows)
                        {
                            PowerSwithConfigEFModel vModel = new PowerSwithConfigEFModel();
                            vModel.DianYuanID = DianYuanID1;
                            CommClass.ConvertDataRowToStruct(ref vModel, vTempSwitch);
                            switch (vTempSwitch.RowState)
                            {
                                case DataRowState.Added:
                                    vResult = m_BasicDBClass.InsertRecord(vModel) > 0 ? true : false;
                                    break;
                                case DataRowState.Deleted:
                                    vResult = m_BasicDBClass.DeleteRecordByPrimaryKey<PowerSwithConfigEFModel>(vModel.ID);
                                    break;
                                case DataRowState.Modified:
                                    vResult = m_BasicDBClass.UpdateRecord(vModel);
                                    break;
                            }
                            if (!vResult)
                            {
                                m_BasicDBClass.TransactionRollback();
                                break;
                            }
                        }
                    }

                    if (vResult)
                    {
                        m_BasicDBClass.TransactionCommit();
                        if (SwitchInfoTable1 != null)
                            SwitchInfoTable1.AcceptChanges();
                        if (SwitchInfoTable2 != null)
                            SwitchInfoTable2.AcceptChanges();
                    }
                }
                else
                {
                    OutInfo = "修改岗亭数据失败";
                }
            }
            return vResult;
        }

        int convertWatchHouseLXToOrderID( string leiXing)
        {
            int vResult = 1;
            switch ( leiXing )
            {
                case "入口":
                    vResult = 1;
                    break;
                case "双向":
                    vResult = 2;
                    break;
                case "出口":
                    vResult = 3;
                    break;
            }
            return vResult;
        }

        public bool Add(int GanTingID,string GanTingMC,string GanTingLX,
            string Led1IP,int LED1Gao,int LED1Kuan,string Led2IP,int LED2Gao,int LED2Kuan,
            string DianYuanID1,string DianYuanID2,DataTable SwitchInfoTable1,DataTable SwitchInfoTable2,
            ref string OutInfo )
        {
            bool vResult = false;
            if ( !findGanTing(GanTingID,DianYuanID1) )
            {
                m_BasicDBClass.TransactionBegin();
                WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
                {
                    GangTingID = GanTingID,
                    GangTingMC = GanTingMC,
                    GangTingLX = GanTingLX,

                    GuanGaoPing1IP = Led1IP,
                    GuanGao1Gao = LED1Gao,
                    GuanGao1Kuang = LED1Kuan,

                    GuanGaoPing2IP = Led2IP,
                    GuanGao2Gao = LED2Gao,
                    GuanGao2Kuang = LED2Kuan,

                    DianYuan1ID = DianYuanID1,
                    DianYuan2ID = DianYuanID2,
                    ShouFeiZhangID = 1,
                     OrderID = convertWatchHouseLXToOrderID(GanTingLX)
                };
                vResult = m_BasicDBClass.InsertRecord(vWatchHouseConfigEFModel) > 0;
                //开关1
                if (vResult && SwitchInfoTable1 != null)
                {
                    foreach (DataRow vTempSwitch in SwitchInfoTable1.Rows)
                    {
                        PowerSwithConfigEFModel vModel = new PowerSwithConfigEFModel();
                        vModel.DianYuanID = DianYuanID1;
                        CommClass.ConvertDataRowToStruct(ref vModel, vTempSwitch);
                        switch (vTempSwitch.RowState)
                        {
                            case DataRowState.Added:
                                vResult = m_BasicDBClass.InsertRecord(vModel) > 0 ? true : false;
                                break;
                            case DataRowState.Deleted:
                                vResult = m_BasicDBClass.DeleteRecordByPrimaryKey<PowerSwithConfigEFModel>(vModel.ID);
                                break;
                            case DataRowState.Modified:
                                vResult = m_BasicDBClass.UpdateRecord(vModel);
                                break;
                        }
                        if (!vResult)
                        {
                            break;
                        }
                    }
                }
                //开关2
                if (vResult && SwitchInfoTable2 != null)
                {
                    foreach (DataRow vTempSwitch in SwitchInfoTable2.Rows)
                    {
                        PowerSwithConfigEFModel vModel = new PowerSwithConfigEFModel();
                        vModel.DianYuanID = DianYuanID1;
                        CommClass.ConvertDataRowToStruct(ref vModel, vTempSwitch);
                        switch (vTempSwitch.RowState)
                        {
                            case DataRowState.Added:
                                vResult = m_BasicDBClass.InsertRecord(vModel) > 0 ? true : false;
                                break;
                            case DataRowState.Deleted:
                                vResult = m_BasicDBClass.DeleteRecordByPrimaryKey<PowerSwithConfigEFModel>(vModel.ID);
                                break;
                            case DataRowState.Modified:
                                vResult = m_BasicDBClass.UpdateRecord(vModel);
                                break;
                        }
                        if (!vResult)
                        {
                            break;
                        }
                    }
                }

                if (vResult)
                {
                    m_BasicDBClass.TransactionCommit();
                    if ( SwitchInfoTable1 != null)
                        SwitchInfoTable1.AcceptChanges();
                }
                else
                {
                    m_BasicDBClass.TransactionRollback();
                    OutInfo = "增加岗亭数据失败";
                }
            }
            else
            {
                OutInfo = "存在相同编号的岗亭或者电源";
            }
            return vResult;
        }

    }
}
