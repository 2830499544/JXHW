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
using System.Xml;

namespace JXHighWay.WatchHouse.Bll.Client.LED
{
    public class LEDControl
    {
        readonly string m_IPAddress;
        readonly int m_Heigth;
        public int Heigth
        {
            get
            {
                return m_Heigth;
            }
        }

        readonly int m_Width;
        public int Width
        {
            get
            {
                return m_Width;
            }
        }

        BasicDBClass m_BasicDBClass = null;

        static System.IntPtr mInstance = System.IntPtr.Zero;
        static DateTime m_Time;
        static Semaphore m_Semaphore = new Semaphore(1, 1);

        ConfigbooXml m_ConfigbooXml = new ConfigbooXml();

        public LEDControl(int WatchHouseID)
        {
          
            Config vConfig = new Config();
            BasicDBClass.DataSource = vConfig.DBSource;
            BasicDBClass.DBName = vConfig.DBName;
            BasicDBClass.Port = vConfig.DBPort;
            BasicDBClass.UserID = vConfig.DBUserName;
            BasicDBClass.Password = vConfig.DBPassword;
            m_BasicDBClass = new BasicDBClass( DataBaseType.MySql);
            getLEDInfo(WatchHouseID,ref m_IPAddress,ref m_Width,ref m_Heigth);
            //m_Heigth = Heigth;
            //m_Width = Width;
            HD_Transmit.InitTransmit();
        }

        void getLEDInfo( int watchHouseID,ref string ipAddress,ref int width,ref int height )
        {
            WatchHouseConfigEFModel vWatchHouseConfigEFModel = new WatchHouseConfigEFModel()
            {
                GangTingID = watchHouseID
            };

            WatchHouseConfigEFModel[] vSelectResult = m_BasicDBClass.SelectRecordsEx(vWatchHouseConfigEFModel);
            if (vSelectResult != null && vSelectResult.Length > 0)
            {
                ipAddress = vSelectResult[0].GuanGaoPing1IP;
                width = vSelectResult[0].GuanGao1Kuang ?? 0;
                height = vSelectResult[0].GuanGao1Gao ?? 0;
            }
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

        public void Test()
        {
            HDFont font = new HDFont();
            font.FontName = "SimSun";
            font.FontSize = 16;
            font.TextColor = new HDColor(255, 255, 255, 128);
            byte[] vTextRead = HD_Base.GenerateSinglelineTextXml(new Size(m_Width, m_Heigth),"test", font);
            System.IO.MemoryStream vMemoryStream = new MemoryStream(vTextRead);
            //System.IO.FileStream vFileStream = new FileStream(@"c:\2.xml", FileMode.CreateNew);

            //vFileStream.Write(vTextRead, 0, vTextRead.Length);
            XmlDocument vXmlDocument = new XmlDocument();
            vXmlDocument.Load(vMemoryStream);
            XmlNodeList vList =  vXmlDocument.SelectNodes("/config.boo/content/channel/area/rectangle/materials/");
            string aa = vList.ToString();
            
            //vFileStream.Flush();
            //vFileStream.Close();
        }

        #region 发送多频道节目
        public void SendMultiChannel(List<LEDChannelInfo> ChannelList, string[] IPList)
        {
            string vMD5 = ""; //CommHelper.GetMD5HashFromFile(ImagePath);
            long vFileSize = 0;// CommHelper.FileSize(ImagePath);

            //清空原有节目
            configbooChannel vClearChannel = new configbooChannel()
            {
                setSize = 0,
                setSizeSpecified = true
            };
            List<configbooChannel> vConfigbooChannelList = new List<configbooChannel>();
            vConfigbooChannelList.Add(vClearChannel);

            foreach (LEDChannelInfo vTempChannel in ChannelList)
            {
                //新节目
                configbooChannel vNewChannel = new configbooChannel();
                vNewChannel.action = "add";
                vConfigbooChannelList.Add(vNewChannel);


                //新节目节目第一区域
                configbooChannelArea vNewChannel_Area = new configbooChannelArea()
                {
                    action = "add"
                };
                vNewChannel.area = new configbooChannelArea[] { vNewChannel_Area };

                configbooChannelAreaRectangle vNewChannel_Area_Rectangle = new configbooChannelAreaRectangle()
                {
                    x = 0,
                    y = 0,
                    height = m_Heigth,
                    width = m_Width
                };
                vNewChannel_Area.rectangle = vNewChannel_Area_Rectangle;
                vNewChannel_Area.materials = new configbooChannelAreaMaterials();
                vMD5 = CommHelper.GetMD5HashFromFile(vTempChannel.Content);
                vFileSize = CommHelper.FileSize(vTempChannel.Content);
                switch (vTempChannel.ChannelType)
                {
                    case LEDChanneTypeEnum.Image:
                        configbooChannelAreaMaterialsImage vNewImage = new configbooChannelAreaMaterialsImage()
                        {
                            action = "add"
                        };
                        vNewChannel_Area.materials.image = new configbooChannelAreaMaterialsImage[]
                        {
                            vNewImage
                        };
                        vNewImage.effect = new configbooChannelAreaMaterialsImageEffect()
                        {
                            @in = vTempChannel.InEff,
                            @out = vTempChannel.OutEff,
                            inSpeed = 1,
                            outSpeed = 1
                            //holdTime = vTempChannel.HoldTime
                        };

                        if (vTempChannel.HoldTime != 0)
                            vNewImage.effect.holdTime = vTempChannel.HoldTime;

                        vNewImage.file = new configbooChannelAreaMaterialsImageFile()
                        {
                            md5 = vMD5,
                            size = vFileSize,
                            path = vTempChannel.Content
                        };
                        break;
                    case LEDChanneTypeEnum.Text:
                        configbooChannelAreaMaterialsText vNewText = new configbooChannelAreaMaterialsText()
                        {
                            action = "add"
                        };

                        vNewChannel_Area.materials.text = new configbooChannelAreaMaterialsText();
                        vNewChannel_Area.materials.text.action = "add";
                        vNewChannel_Area.materials.text.effect = new configbooChannelAreaMaterialsImageEffect()
                        {
                            @in = vTempChannel.InEff,
                            @out = vTempChannel.OutEff,
                            inSpeed = 1,
                            outSpeed = 1
                            //holdTime = vTempChannel.HoldTime
                        };
                        vNewChannel_Area.materials.text.pageCount = 1;
                        vNewChannel_Area.materials.text.singleMode = 0;

                        if (vTempChannel.HoldTime != 0)
                            vNewChannel_Area.materials.text.effect.holdTime = vTempChannel.HoldTime;

                        vNewChannel_Area.materials.text.file = new configbooChannelAreaMaterialsTextFile()
                        {
                            md5 = vMD5,
                            size = vFileSize,
                            path = vTempChannel.Content
                        };

                        break;
                    case LEDChanneTypeEnum.Video:
                        configbooChannelAreaMaterialsVideo vNewVideo = new configbooChannelAreaMaterialsVideo()
                        {
                            action = "add"
                        };

                        vNewChannel_Area.materials.video = new configbooChannelAreaMaterialsVideo[]
                        {
                            vNewVideo
                        };

                        vNewVideo.effect = new configbooChannelAreaMaterialsVideoEffect()
                        {
                            @in = vTempChannel.InEff,
                            @out = vTempChannel.OutEff,
                            inSpeed = 1,
                            outSpeed = 1
                            //holdTime = vTempChannel.HoldTime
                        };
                        if (vTempChannel.HoldTime != 0)
                            vNewVideo.effect.holdTime = vTempChannel.HoldTime;

                        vNewVideo.file = new configbooChannelAreaMaterialsVideoFile()
                        {
                            md5 = vMD5,
                            size = vFileSize,
                            path = vTempChannel.Content
                        };
                        break;
                }
            }

            m_ConfigbooXml.content = vConfigbooChannelList.ToArray();
            StringWriter sw = new StringWriter();
            MemoryStream ms = new MemoryStream();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigbooXml));
            serializer.Serialize(ms, m_ConfigbooXml, ns);
            sw.Close();
            ms.Close();

            Console.WriteLine(sw.ToString());
            HdTransmitTool t = HdTransmitTool.GetInstance();
            //t.Send(m_IPAddress, ms.ToArray(), true);
            foreach (string vTempIP in IPList)
            {
                t.Send(vTempIP, ms.ToArray(), true);
            }
        }
        #endregion

        #region 发送图像
        public void SendImageQF(string UserName, string ImagePath)
        {
            WatchHouseConfigEFModel[] vSelectResult = m_BasicDBClass.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            foreach (WatchHouseConfigEFModel vTempResult in vSelectResult)
            {
                if (vTempResult.GuanGaoPing1IP != null && vTempResult.GuanGaoPing1IP != "")
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
        #endregion

        #region 发送视频
        public void SendVideoQF(string UserName,string VideoPath)
        {
            WatchHouseConfigEFModel[] vSelectResult = m_BasicDBClass.SelectAllRecordsEx<WatchHouseConfigEFModel>();
            foreach (WatchHouseConfigEFModel vTempResult in vSelectResult)
            {
                if (vTempResult.GuanGaoPing1IP != null && vTempResult.GuanGaoPing1IP != "")
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
        #endregion

        #region 发送文字
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
                if ( vTempResult.GuanGaoPing1IP!=null && vTempResult.GuanGaoPing1IP!="")
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
        #endregion

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
