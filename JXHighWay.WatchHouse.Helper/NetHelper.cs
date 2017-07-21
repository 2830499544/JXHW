using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace JXHighWay.WatchHouse.Helper
{
    public class NetHelper
    {
        /// <summary>  
        /// 由结构体转换为byte数组  
        /// </summary>  
        public static byte[] StructureToByte<T>(T structure)
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] buffer = new byte[size];
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(structure, bufferIntPtr, true);
                Marshal.Copy(bufferIntPtr, buffer, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(bufferIntPtr);
            }
            return buffer;
        }

        /// <summary>  
        /// 由byte数组转换为结构体  
        /// </summary>  
        public static T ByteToStructure<T>(byte[] dataBuffer)
        {
            object structure = null;
            int size = Marshal.SizeOf(typeof(T));
            IntPtr allocIntPtr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(dataBuffer, 0, allocIntPtr, size);
                structure = Marshal.PtrToStructure(allocIntPtr, typeof(T));
            }
            finally
            {
                Marshal.FreeHGlobal(allocIntPtr);
            }
            return (T)structure;
        }

        public static byte[] MarkSN()
        {
            byte[] vResult = new byte[2];
            Random vRD = new Random();
            vRD.NextBytes(vResult);
            return vResult;
        }

        public static byte MarkSN_Byte()
        {
            byte[] vResult = new byte[2];
            Random vRD = new Random();
            vRD.NextBytes(vResult);
            return vResult[0];
        }

        public static string BytesToString_MAC(byte[] MAC)
        {
            string vResult = "00-00-00-00-00-00";
            try
            {
                if (MAC.Length == 6)
                {
                    vResult = string.Format("{0:X}-{1:X}-{2:X}-{3:X}-{4:X}-{5:X}", MAC[0], MAC[1], MAC[2], MAC[3], MAC[4], MAC[5]);
                }
            }
            catch { }
            return vResult;
        }

        /// <summary>
        /// MAC字符串转Bytes
        /// </summary>
        /// <param name="StrBytes"></param>
        /// <returns></returns>
        public static byte[] StringToBytes_MAC( string MacStr)
        {
            byte[] vResult = new byte[6];
            try
            {
                string[] vStrBytesArray = MacStr.Split('-');
                if (vStrBytesArray.Length == 6)
                {
                    for(int i=0;i<6;i++)
                    {
                        vResult[i] = byte.Parse(vStrBytesArray[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                    }
                }
            }
            catch
            {
                vResult = new byte[6];
            }
            return vResult;
        }


        public static string BytesToString_IP( byte[] IP)
        {
            string vResult = "127.0.0.1";
            try
            {
                if (IP.Length == 4)
                {
                    vResult = string.Format("{0:D}.{1:D}.{2:D}.{3:D}", IP[0], IP[1], IP[2], IP[3]);
                }
            }
            catch { }
            return vResult;
        }


        public static byte[] StringToBytes_IP (string IPStr )
        {
            byte[] vResult = new byte[4];
            try
            {
                string[] vStrBytesArray = IPStr.Split('.');
                if (vStrBytesArray.Length == 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        vResult[i] = byte.Parse(vStrBytesArray[i], System.Globalization.NumberStyles.AllowHexSpecifier);
                    }
                }
            }
            catch
            {
                vResult = new byte[4];
            }
            return vResult;
        }

        public static byte StringToByte (string StrByte)
        {
            byte vResult = 0x00;
            try
            {
                vResult = byte.Parse(StrByte, System.Globalization.NumberStyles.AllowHexSpecifier);
            }
            catch
            {

            }
            return vResult;
        }
    }
}
