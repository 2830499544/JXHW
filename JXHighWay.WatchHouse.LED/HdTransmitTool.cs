using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace JXHighWay.WatchHouse.LED
{
    class HdTransmitObj
    {
        public IntPtr ptr;
        public IntPtr transmitInstance;
        public Semaphore semaphore;
        public DateTime time;
        private string ip;

        public HdTransmitObj(String ip)
        {
            ptr = Marshal.StringToHGlobalAnsi(ip);
            this.ip = ip;
            semaphore = new Semaphore(1, 1);
            //transmitInstance = HD_Transmit.CreateSendInstance(HdTransmitTool.sCallback, ptr);
            transmitInstance = IntPtr.Zero;
            time = DateTime.Now;
            this.ResetInstance();


            //try
            //{
            //    this.semaphore.Release();
            //}
            //catch (SemaphoreFullException e)
            //{
            //    // ...
            //}
        }

        public void ResetInstance()
        {
            if (transmitInstance == System.IntPtr.Zero)
            {
                transmitInstance = HD_Transmit.CreateSendInstance(HdTransmitTool.sCallback, ptr);

                if (transmitInstance == IntPtr.Zero)
                {
                    Console.WriteLine("CreateSendInstance failed!");
                }

                HD_Transmit.InitSendInstance(transmitInstance, null, ip);
            }
        }
    }

    public class HdTransmitTool
    {
        static List<HdTransmitObj> sTransObjs = new List<HdTransmitObj>();

        static Mutex sMutex = new Mutex();

        public static HD_Callback sCallback = (errCode, userData) =>
        {
            //Console.WriteLine(Marshal.PtrToStringAnsi(userData) + " : " + errCode.ToString());

            if (errCode == HErrCode.kHeartbeatTimeOut)
                return;

            //sTransObjsSemaphore.WaitOne();
            //sMutex.WaitOne();
            for (int i = 0; i < sTransObjs.Count; i++)
            {
                var trans = sTransObjs[i];

                if (trans.ptr == userData)
                {
                    if (trans.transmitInstance != System.IntPtr.Zero && errCode == HErrCode.kSocketExecp)
                    {
                        HD_Transmit.DestroySendInstance(trans.transmitInstance);
                        trans.transmitInstance = System.IntPtr.Zero;
                    }
                    TimeSpan span = DateTime.Now.Subtract(trans.time);
                    Console.WriteLine(errCode.ToString() + " time : " + span.Milliseconds.ToString() + " " + DateTime.Now.ToString("HH:mm:ss.fff"));
                    //MessageBox.Show(errCode.ToString() + " time : " + span.Milliseconds.ToString() + " " + DateTime.Now.ToString("HH:mm:ss.fff"));
                    try
                    {
                        trans.semaphore.Release();
                    }
                    catch (SemaphoreFullException e)
                    {
                        // ...
                    }
                }
            }

            //sTransObjs.Remove(sTransObjs.Where(p => p.ptr == userData).FirstOrDefault());
            //sMutex.ReleaseMutex();
            //try
            //{
            //    sTransObjsSemaphore.Release();
            //}
            //catch (SemaphoreFullException e)
            //{

            //}
        };

        static HdTransmitTool sInstance = null;

        private HdTransmitTool()
        {
            HD_Transmit.InitTransmit();
        }

        public void Send(String ip, String file, bool transFile)
        {
            HdTransmitObj trans;
            if (GetTransmitObjFromIP(ip, out trans))
            {
                trans.semaphore.WaitOne();
                //trans = new HdTransmitObj(ip);
            }

            //trans.semaphore.WaitOne();
            trans.time = DateTime.Now;
            HD_Transmit.SendExternCmd(trans.transmitInstance, file, transFile);
            //sTransObjs.Add(trans);

            Console.WriteLine(">>" + ip);
        }

        public void Send(string ip, byte[] buffer, bool transFile)
        {
            HdTransmitObj trans;
            if (GetTransmitObjFromIP(ip, out trans))
            {
                trans.semaphore.WaitOne();
                //trans = new HdTransmitObj(ip);
            }
            trans.time = DateTime.Now;
            Console.WriteLine(">>" + ip + " : " + trans.time.ToString("HH:mm:ss.fff"));
            HD_Transmit.SendExternCmdBuff(trans.transmitInstance, buffer, buffer.Length, transFile);
        }

        public void SendCommand(string ip, string cmd)
        {
            HdTransmitObj trans;
            if (GetTransmitObjFromIP(ip, out trans))
            {
                trans.semaphore.WaitOne();
                //trans = new HdTransmitObj(ip);
            }

            //trans.semaphore.WaitOne();
            trans.time = DateTime.Now;
            switch (cmd)
            {
                case "GreenLightsOn":
                    HD_Transmit.GreenLightsOn(trans.transmitInstance);
                    break;
                case "GreenLightsOff":
                    HD_Transmit.GreenLightsOff(trans.transmitInstance);
                    break;
                case "RedLightsOn":
                    HD_Transmit.RedLightsOn(trans.transmitInstance);
                    break;
                case "RedLightsOff":
                    HD_Transmit.RedLightsOff(trans.transmitInstance);
                    break;
                case "SirenOpen":
                    HD_Transmit.SirenOpen(trans.transmitInstance);
                    break;
                default:
                    HD_Transmit.SirenClose(trans.transmitInstance);
                    break;
            }

            //sTransObjs.Add(trans);

            Console.WriteLine(">>" + ip + " : " + cmd);
        }

        private bool GetTransmitObjFromIP(String ip, out HdTransmitObj t)
        {
            //sMutex.WaitOne();
            for (int i = 0; i < sTransObjs.Count; i++)
            {
                var trans = sTransObjs[i];
                if (Marshal.PtrToStringAnsi(trans.ptr) == ip)
                {
                    t = trans;
                    //sMutex.ReleaseMutex();
                    t.ResetInstance();
                    return true;
                }
            }
            //sMutex.ReleaseMutex();
            t = new HdTransmitObj(ip);
            sTransObjs.Add(t);
            return false;
        }

        public static HdTransmitTool GetInstance()
        {
            if (sInstance == null)
            {
                sInstance = new HdTransmitTool();
            }
            return sInstance;
        }
    }
}
