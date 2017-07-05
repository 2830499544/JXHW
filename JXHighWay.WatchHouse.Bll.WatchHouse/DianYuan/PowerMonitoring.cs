using MXKJ.DBMiddleWareLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHighWay.WatchHouse.EFModel;
using JXHighWay.WatchHouse.Net;
using JXHighWay.WatchHouse.Net.DataPack;
using JXHighWay.WatchHouse.Helper;
using System.Threading;

namespace JXHighWay.WatchHouse.Bll.Client.DianYuan
{
    public class PowerMonitoring:BasicMonitoring
    {

        public PowerMonitoring()
        {

        }

        /// <summary>
        /// 控制分路开关
        /// </summary>
        /// <param name="DianYuanID">电源ID</param>
        /// <param name="SheBieLX">设备类型</param>
        /// <param name="LuHao">路号</param>
        /// <param name="IsOn">开或关</param>
        /// <returns></returns>
        public async Task<bool> SendCMD_Switch(int DianYuanID, byte SheBieLX, byte LuHao, bool IsOn)
        {
            PowerDataPack_Send_Switch vData = new PowerDataPack_Send_Switch()
            {
                LuHao = LuHao,
                SheBeiLX = SheBieLX,
                Switch = IsOn ? (byte)0x01 : (byte)0x00
            };
            bool vResult = await asyncSendCommandToDB(DianYuanID, PowerDataPack_Send_CommandEnum.Send_Switch, vData);
            return vResult;
        }

        async Task<bool> asyncSendCommandToDB<T>(int dianYuanID, PowerDataPack_Send_CommandEnum command, T SendData)
        {
            return await Task.Run(() =>
            {
                string vDataStr = System.Text.Encoding.Default.GetString(NetHelper.StructureToByte(SendData));
                PowerSendCMDEFModel vSendCMDEFModel = new PowerSendCMDEFModel()
                {
                    State = false,
                    IsSend = false,
                    IsReply = false,
                    CMD = (byte)command,
                    DianYuanID = dianYuanID,
                    SendTime = DateTime.Now,
                    SN = NetHelper.MarkSN_Byte(),
                    Data = vDataStr
                };
                int vID = m_BasicDBClass.InsertRecord(vSendCMDEFModel);

                DateTime vStartTime = DateTime.Now;
                bool vResult = false;
                do
                {
                    PowerSendCMDEFModel vSelectResult = m_BasicDBClass.SelectRecordByPrimaryKeyEx<PowerSendCMDEFModel>(vID);
                    vResult = vSelectResult.State ?? false;
                    if (!vResult && (DateTime.Now - vStartTime).TotalMilliseconds >= 2000)
                        break;
                    Thread.Sleep(200);
                } while (!vResult);
                //m_BasicDBClass.DeleteRecordByPrimaryKey<PowerSendCMDEFModel>(vID);
                return vResult;
            });
        }

        
        public int GetPowerLuSu( int WatchHouseId )
        {
            int vResult = 0;
            WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
            {
                GangTingID = WatchHouseId
            };
            WatchHouseConfigEFModel[] vSelectResult = m_BasicDBClass.SelectRecordsEx(vWatchHouseConfigEFModel);
            if ( vSelectResult != null && vSelectResult.Length>0)
            {
                vResult = vSelectResult[0].DianYuanLS ?? 0;
            }
            return vResult;
        }

        /// <summary>
        /// 获取指定路号的最新数据
        /// </summary>
        /// <param name="DianYuanID"></param>
        /// <param name="LuShu"></param>
        /// <returns></returns>
        public PowerInfo GetNewPowerInfo( int DianYuanID ,int LuHao )
        {
            PowerInfo vResult = null;
            string vSql = string.Format("Select *From `电源数据` Where DianYuanID={0} and LuHao={1} order by id desc LIMIT 1",DianYuanID,LuHao);
            PowerDataEFModel[] vSelectResult = m_BasicDBClass.SelectCustomEx<PowerDataEFModel>(vSql);
            if (vSelectResult != null && vSelectResult.Length > 0)
            {
                vResult = new PowerInfo();
                vResult = new PowerInfo()
                {
                    DianLiu = vSelectResult[0].DianLiu ?? 0,
                    DianYa = vSelectResult[0].DianYa ?? 0,
                    LuHao = LuHao,
                    ZhuangTai = (vSelectResult[0].DianYa ?? 0) == 0 ? false : true
                };
            }
            return vResult;
        }
    }
}
