using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHighWay.WatchHouse.LED;
using System.Threading;
using System.Drawing;

namespace JXHighWay.WatchHouse.Bll.Client
{
    public class LEDControl
    {
        readonly string m_IPAddress;
        readonly int m_Heigth;
        readonly int m_Width;

        static System.IntPtr mInstance = System.IntPtr.Zero;
        static DateTime m_Time;
        static Semaphore m_Semaphore = new Semaphore(1, 1);

        public LEDControl(string IPAddress,int Heigth,int Width)
        {
            m_IPAddress = IPAddress;
            m_Heigth = Heigth;
            m_Width = Width;
            HD_Transmit.InitTransmit();
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

        public void SendText(string Text)
        {
            HdTransmitTool t = HdTransmitTool.GetInstance();
            //t.Send(txtIP.Text, "D:\\HDSDK1.1_DEMO\\Temp\\singleline.xml", false);

            HDFont font = new HDFont();
            font.FontName = "SimSun";
            font.FontSize = 16;
            font.TextColor = new HDColor(255, 255, 255, 128);
            byte[] data = HD_Base.GenerateSinglelineTextXml(new Size(m_Width,m_Heigth), Text, font);
            t.Send(m_IPAddress, data, true);
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
                    //MessageBox.Show("Error : CreateSendInstance failed!");
                    Console.WriteLine("Error : CreateSendInstance failed!");
                }

                HD_Transmit.InitSendInstance(mInstance, null, m_IPAddress);
                //txt_ip.Enabled = false;
            }
        }

    }
}
