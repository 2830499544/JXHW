using System;
using System.Runtime.InteropServices;

namespace JXHighWay.WatchHouse.LED
{
    public enum HErrCode
    {
        kSuccess = 0,            ///< 正常状态
        kDevAddressError,        ///< 设备地址错误
        kConnectError,           ///< 连接出错
        kDisconnectError,        ///< 设备断开连接
        kSocketInitFailed,       ///< socket初始化出错
        kSocketExecp,            ///< socket异常
        kPacketLenError,         ///< tcp数据包长度错误
        kTimerInitFailed,        ///< 定时器初始化错误
        kProcessExecp,           ///< 协议流程错误
        kHeartbeatTimeOut,       ///< 心跳包超时
        kConnectTimeOut,         ///< 连接超时

        kDeviceOccupa,           ///< 设备被占用
        kSpaceNotEnough,         ///< 设备空间不足
        kRemoveFileFail,         ///< 删除文件失败
        kOpenFileFail,           ///< 打开文件失败
        kReadFileFail,           ///< 读取文件失败
        kWritefileFail,          ///< 写文件失败
        kCloseFileFail,          ///< 关闭文件失败
        kRecvInvalidCMD,         ///< 接收到错误的命令

        kAppExternInSuccess,     ///< 进入app扩展协议成功
        kConfigFileIsNull,       ///< 配置文件为空
        kConfigFileError,        ///< 配置文件错误
        kAppExternSendSuccess,   ///< app扩展发送成功
        kFileNotFound,           ///< 文件不存在

        kCreateSendInstanceFailed = 0x100,  ///< 创建发送实例出错.
        kNotFoundSendInstance,              ///< 未找到发送实例.
        kDeviceIDIsNull,
        kNotFoundDeviceID,
    };

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void HD_Callback(HErrCode errCode, System.IntPtr userData);

    public class HD_Transmit
    {

        private static bool inited = false;

        public static void InitTransmit()
        {
            if (!inited)
            {
                HD_Transmit.Init();
                inited = true;
            }
        }

        [DllImport("Transmit.dll", EntryPoint = "Init")]
        private static extern void Init();

        [DllImport("Transmit.dll", EntryPoint = "CreateSendInstance")]
        public static extern System.IntPtr CreateSendInstance([MarshalAs(UnmanagedType.FunctionPtr)]HD_Callback callback, System.IntPtr userData);

        [DllImport("Transmit.dll", EntryPoint = "InitSendInstance")]
        public static extern void InitSendInstance(System.IntPtr sendInstance, String id, String ip);

        [DllImport("Transmit.dll", EntryPoint = "SendExternCmd")]
        public static extern void SendExternCmd(System.IntPtr sendInstance, String configFile, bool transFile);

        [DllImport("Transmit.dll", EntryPoint = "DestroySendInstance")]
        public static extern void DestroySendInstance(System.IntPtr sendInstance);

        [DllImport("Transmit.dll", EntryPoint = "GetErrorCode")]
        public static extern HErrCode GetErrorCode(System.IntPtr sendInstance);

        [DllImport("Transmit.dll", EntryPoint = "GetDevIDBegin")]
        public static extern void GetDevIDBegin();

        [DllImport("Transmit.dll", EntryPoint = "GetDeviceID")]
        public static extern bool GetDeviceID(byte[] buff);

        [DllImport("Transmit.dll", EntryPoint = "GetDevIDEnd")]
        public static extern void GetDevIDEnd();

        [DllImport("Transmit.dll", EntryPoint = "SendExternCmdBuff")]
        public static extern void SendExternCmdBuff(IntPtr sendInstance, byte[] configBuff, int buffLen, bool transFile);

        [DllImport("Transmit.dll", EntryPoint = "SendToBoxPlayer")]
        public static extern void SendToBoxPlayer(IntPtr sendInstance, byte[] configBuff, int buffLen);

        [DllImport("Transmit.dll", EntryPoint = "GreenLightsOn")]
        public static extern void GreenLightsOn(IntPtr sendInstance);
        [DllImport("Transmit.dll", EntryPoint = "GreenLightsOff")]
        public static extern void GreenLightsOff(IntPtr sendInstance);
        [DllImport("Transmit.dll", EntryPoint = "RedLightsOn")]
        public static extern void RedLightsOn(IntPtr sendInstance);
        [DllImport("Transmit.dll", EntryPoint = "RedLightsOff")]
        public static extern void RedLightsOff(IntPtr sendInstance);
        [DllImport("Transmit.dll", EntryPoint = "SirenOpen")]
        public static extern void SirenOpen(IntPtr sendInstance);
        [DllImport("Transmit.dll", EntryPoint = "SirenClose")]
        public static extern void SirenClose(IntPtr sendInstance);
    }
}
