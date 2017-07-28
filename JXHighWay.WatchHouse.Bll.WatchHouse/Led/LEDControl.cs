using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHighWay.WatchHouse.LED;
using System.Threading;
using System.Drawing;
using JXHighWay.WatchHouse.Helper;
using System.IO;
using System.Xml.Serialization;
using MXKJ.DBMiddleWareLib;
using JXHighWay.WatchHouse.EFModel;

namespace JXHighWay.WatchHouse.Bll.Client.LED
{
    public class LEDControl
    {
        readonly string m_IPAddress;
        readonly int m_Heigth;
        readonly int m_Width;
        BasicDBClass m_BasicDBClass = null;

        static System.IntPtr mInstance = System.IntPtr.Zero;
        static DateTime m_Time;
        static Semaphore m_Semaphore = new Semaphore(1, 1);

        ConfigbooXml m_ConfigbooXml = new ConfigbooXml();

        public LEDControl(int WatchHouseID,int Heigth,int Width)
        {
          
            Config vConfig = new Config();
            BasicDBClass.DataSource = vConfig.DBSource;
            BasicDBClass.DBName = vConfig.DBName;
            BasicDBClass.Port = vConfig.DBPort;
            BasicDBClass.UserID = vConfig.DBUserName;
            BasicDBClass.Password = vConfig.DBPassword;
            m_BasicDBClass = new BasicDBClass( DataBaseType.MySql);
            m_IPAddress = getLEDIPAddress(WatchHouseID);


            m_Heigth = Heigth;
            m_Width = Width;
            HD_Transmit.InitTransmit();
        }

        string getLEDIPAddress( int WatchHouseID)
        {
            string vResult = "";
            WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
            {
                GangTingID = WatchHouseID
            };

            WatchHouseConfigEFModel[] vSelectResult = m_BasicDBClass.SelectRecordsEx(vWatchHouseConfigEFModel);
            if (vSelectResult != null && vSelectResult.Length > 0)
            {
                vResult = vSelectResult[0].GuanGaoPingIP;
            }
            return vResult;
        }

        public void Init()
        {
            transmitInit();
        }

        public void Send(byte[] buffer, bool containFile)
        {
            m_Time = DateTime.Now;

            if (containFile)
            {
                HD_Transmit.SendExternCmdBuff(mInstance, buffer, buffer.Length, true);
            }
            else
            {
                HD_Transmit.SendToBoxPlayer(mInstance, buffer, buffer.Length/*, containFile*/);
            }
        }
        public void SendImageQF(string UserName, string ImagePath)
        {
            WatchHouseConfigEFModel[] vSelectResult = m_BasicDBClass.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            foreach (WatchHouseConfigEFModel vTempResult in vSelectResult)
            {
                if (vTempResult.GuanGaoPingIP != null && vTempResult.GuanGaoPingIP != "")
                {
                    SendImage(UserName, ImagePath);
                }
            }
        }

        public void SendImage(string UserName,string ImagePath)
        {
            string vMD5 = CommHelper.GetMD5HashFromFile(ImagePath);
            long vFileSize = CommHelper.FileSize(ImagePath);

            
            //清空原有节目
            configbooChannel vClearChannel = new configbooChannel()
            {
                setSize = 0,
                setSizeSpecified = true
            };
            

            //第一个节目
            configbooChannel v1Changel = new configbooChannel();
            v1Changel.action = "add";
            m_ConfigbooXml.content = new configbooChannel[] { vClearChannel, v1Changel };

            //第一个节目第一区域
            configbooChannelArea v1Changel_Area = new configbooChannelArea()
            {
                action = "add"
            };
            v1Changel.area = new configbooChannelArea[] { v1Changel_Area };

            configbooChannelAreaRectangle v1Changel_Area_Rectangle = new configbooChannelAreaRectangle()
            {
                x = 0,
                y = 0,
                height = m_Heigth,
                width = m_Width
            };
            v1Changel_Area.rectangle = v1Changel_Area_Rectangle;
            v1Changel_Area.materials = new configbooChannelAreaMaterials();
            configbooChannelAreaMaterialsImage vImage1 = new configbooChannelAreaMaterialsImage()
            {
                action = "add"
            };

            v1Changel_Area.materials.image = new configbooChannelAreaMaterialsImage[]{
                vImage1
            };
            vImage1.effect = new configbooChannelAreaMaterialsImageEffect()
            { 
                @in = 0,
                @out = 20,
                inSpeed =1,
                outSpeed =1,
                holdTime = 8
            };

            vImage1.file = new configbooChannelAreaMaterialsImageFile()
            {
                md5 = vMD5,
                size = vFileSize,
                path = ImagePath
            };

            //StringWriter sw = new StringWriter();
            MemoryStream ms = new MemoryStream();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigbooXml));
            serializer.Serialize(ms, m_ConfigbooXml, ns);
            //sw.Close();
            ms.Close();

            //Console.WriteLine(sw.ToString());
            HdTransmitTool t = HdTransmitTool.GetInstance();
            t.Send(m_IPAddress, ms.ToArray(), true);

            LEDDataEFModel vLEDDataEFModel = new LEDDataEFModel()
            {
                UserName = UserName,
                Time = DateTime.Now,
                Pic = ImagePath
            };

            m_BasicDBClass.InsertRecord(vLEDDataEFModel);
        }

        public void SendVideoQF(string UserName,string VideoPath)
        {
            WatchHouseConfigEFModel[] vSelectResult = m_BasicDBClass.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            foreach (WatchHouseConfigEFModel vTempResult in vSelectResult)
            {
                if (vTempResult.GuanGaoPingIP != null && vTempResult.GuanGaoPingIP != "")
                {
                    SendVideo(UserName, VideoPath);
                }
            }
        }

        public void SendVideo( string UserName, string VideoPath )
        {
            string vMD5 = CommHelper.GetMD5HashFromFile(VideoPath);
            long vFileSize = CommHelper.FileSize(VideoPath);


            //清空原有节目
            configbooChannel vClearChannel = new configbooChannel()
            {
                setSize = 0,
                setSizeSpecified = true
            };


            //第一个节目
            configbooChannel v1Changel = new configbooChannel();
            v1Changel.action = "add";
            m_ConfigbooXml.content = new configbooChannel[] { vClearChannel, v1Changel };

            //第一个节目第一区域
            configbooChannelArea v1Changel_Area = new configbooChannelArea()
            {
                action = "add"
            };
            v1Changel.area = new configbooChannelArea[] { v1Changel_Area };

            configbooChannelAreaRectangle v1Changel_Area_Rectangle = new configbooChannelAreaRectangle()
            {
                x = 0,
                y = 0,
                height = m_Heigth,
                width = m_Width
            };
            v1Changel_Area.rectangle = v1Changel_Area_Rectangle;
            v1Changel_Area.materials = new configbooChannelAreaMaterials();

            configbooChannelAreaMaterialsVideo vVideo1 = new configbooChannelAreaMaterialsVideo()
            {
                action = "add",
            };
            
            v1Changel_Area.materials.video = new configbooChannelAreaMaterialsVideo[]
            {
                vVideo1
            };


            vVideo1.file = new configbooChannelAreaMaterialsVideoFile()
            {
                md5 = vMD5,
                size = vFileSize,
                path = VideoPath
            };

            StringWriter sw = new StringWriter();
            MemoryStream ms = new MemoryStream();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigbooXml));
            serializer.Serialize(ms, m_ConfigbooXml, ns);
            sw.Close();
            ms.Close();

            Console.WriteLine(sw.ToString());
            HdTransmitTool t = HdTransmitTool.GetInstance();
            t.Send(m_IPAddress, ms.ToArray(), true);

            LEDDataEFModel vLEDDataEFModel = new LEDDataEFModel()
            {
                UserName = UserName,
                Time = DateTime.Now,
                Pic = VideoPath
            };

            m_BasicDBClass.InsertRecord(vLEDDataEFModel);
        }

        /// <summary>
        /// 文字群发
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Text"></param>
        public void SendTextQF(string UserName,string Text )
        {
            WatchHouseConfigEFModel[] vSelectResult = m_BasicDBClass.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            foreach(WatchHouseConfigEFModel vTempResult in vSelectResult)
            {
                if ( vTempResult.GuanGaoPingIP!=null && vTempResult.GuanGaoPingIP!="")
                {
                    SendText(UserName, Text);
                }
            }
        }

        public void SendText(string UserName,string Text)
        {
            HdTransmitTool t = HdTransmitTool.GetInstance();
            //t.Send("192.168.0.114", "E:\\1.xml", true);

            HDFont font = new HDFont();
            font.FontName = "SimSun";
            font.FontSize = 16;
            font.TextColor = new HDColor(255, 255, 255, 128);
            byte[] data = HD_Base.GenerateSinglelineTextXml(new Size(m_Width, m_Heigth), Text, font);
            t.Send(m_IPAddress, data, true);

            LEDDataEFModel vLEDDataEFModel = new LEDDataEFModel()
            {
                UserName = UserName,
                Time = DateTime.Now,
                Pic = Text
            };

            m_BasicDBClass.InsertRecord(vLEDDataEFModel);
        }

        static HD_Callback callback = (x, y) =>
        {
            //if (mInstance != System.IntPtr.Zero)
            //{
            //    HD_Transmit.DestroySendInstance(mInstance);
            //    mInstance = System.IntPtr.Zero;
            //}

            switch (x)
            {
                case HErrCode.kDevAddressError:
                case HErrCode.kConnectError:
                case HErrCode.kDisconnectError:
                case HErrCode.kSocketInitFailed:
                case HErrCode.kSocketExecp:
                case HErrCode.kPacketLenError:
                case HErrCode.kTimerInitFailed:
                case HErrCode.kProcessExecp:
                case HErrCode.kConnectTimeOut:
                    if (mInstance != IntPtr.Zero)
                    {
                        HD_Transmit.DestroySendInstance(mInstance);
                        mInstance = IntPtr.Zero;
                    }
                    break;
                case HErrCode.kHeartbeatTimeOut:
                    break;
            }

            TimeSpan span = DateTime.Now.Subtract(m_Time);
            if (x != HErrCode.kHeartbeatTimeOut)
            {
                Console.WriteLine(x.ToString() + " time : " + span.Milliseconds.ToString());
                try
                {
                    m_Semaphore.Release();
                }
                catch (SemaphoreFullException e)
                {
                    // ...
                }
            }
        };

        //Transmit库初始化
        private void transmitInit()
        {
            if (mInstance == IntPtr.Zero)
            {
                mInstance = HD_Transmit.CreateSendInstance(callback, IntPtr.Zero);
                if (mInstance == IntPtr.Zero)
                {
                    //Xceed.Wpf.Toolkit.Xceed.Wpf.Toolkit.MessageBox.Show("Error : CreateSendInstance failed!");
                    Console.WriteLine("Error : CreateSendInstance failed!");
                }

                HD_Transmit.InitSendInstance(mInstance, null, m_IPAddress);
                //txt_ip.Enabled = false;
            }
        }

    }
}
