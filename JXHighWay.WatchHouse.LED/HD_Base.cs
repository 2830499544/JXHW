using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Drawing;
using System.Xml;
using System.IO;
using System.Drawing.Text;

namespace JXHighWay.WatchHouse.LED
{
    public enum HDErrorCode
    {
        kSuccess,                               ///< 成功
        kProcessException,
        kRecvDataFail,                          ///< 接受数据失败.
        kDeviceOccupa,
        kSpaceNotEnough,
        kFileNotFound,
        kReadFileFail,
        kSystemError,
        kRemoveFileFail,
        kSendFinish,
        kCreateFileFail,
        kWriteFileFail,
        kCloseFileFail,
        kNewObjectFail,
        kSendDataFail,                          ///< 发送数据失败.
        kDeviceConnectFail,
        kDeviceDisconnect,
        kCancelSend,
        kOpenFileFail,                          ///< 打开文件失败.
        kInitFail,
        kSetTimeFail,
        kIDNotFound,
        kUpgradeFail,
        kParseDataFail,
        kVersionTooLow,
        kUnPackageFail,
        kUpgradePacketError,
        kSetDeviceRebootFail,
        kPluginNotExeist,                       ///< 插件不存在
        kNodeAttrMustBeSet,                     ///< 节点的属性必须设置
        kParentNodeMustBeSet,                   ///< 节点必须设置父节点
        kDeviceTypeNotSuport,                   ///< 设备类型不支持
        kScreenSizeInvalid,                     ///< 显示屏大小有误
        kAreaSizeInvalid,                       ///< 区域大小有误
        kGetMemoryFail,                         ///< 申请内存失败.
        kPortUsed,                              ///< 端口被占用.
        kHostNotExist,                          ///< 控制卡不存在.
        kHostReject,                            ///< 控制卡拒绝连接.
        kConnectTimeout,                        ///< 连接超时.
        kGetFileInfoFail,                       ///< 获取文件信息失败.
        kNotFoundFile,                          ///< 未找到文件.
        kStopSend,                              ///< 停止发送.
        kUnknow,                                ///< 未知的错误.
        kDeviceNotMatch,                        ///< 设备部匹配.
        kContentTooLarge,                       ///< 显示屏添加的内容>300M(控制卡未插入U盘等存储介质).
        kIDNotExist,                            ///< 指定的id未找到.
        kParamInvalid,                          ///< 参数错误.
        kLackOfSpace                            ///< 空间不足
    };

    public struct HDScreenNodeAttr
    {
        public int Width;                              ///< 显示屏宽度
        public int Height;                             ///< 显示屏高度
                                                       ///
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public char[] DeviceType;       //设备类型
        public int Synchronous;                       ///< 多屏同步
    };

    // ------------------------------------------------------------------------------------------------------

    public enum HDEffectType
    {
        kIMMEDIATE_SHOW = 0,               ///< 直接显示.
        kLEFT_PARALLEL_MOVE = 1,               ///< 向左平移.
        kRIGHT_PARALLEL_MOVE = 2,              ///< 向右平移.
        kUP_PARALLEL_MOVE = 3,               ///< 向上平移.
        kDOWN_PARALLEL_MOVE = 4,               ///< 向下平移.
        kLEFT_COVER = 5,               ///< 向左覆盖.
        kRIGHT_COVER = 6,               ///< 向右覆盖.
        kUP_COVER = 7,               ///< 向上覆盖.
        kDOWN_COVER = 8,               ///< 向下覆盖.
        kLEFT_TOP_COVER = 9,               ///< 左上覆盖.
        kLEFT_BOTTOM_COVER = 10,              ///< 左下覆盖.
        kRIGHT_TOP_COVER = 11,              ///< 右上覆盖.
        kRIGHT_BOTTOM_COVER = 12,              ///< 右下覆盖.
        kHORIZONTAL_DIVIDE = 13,              ///< 水平对开.
        kVERTICAL_DIVIDE = 14,              ///< 垂直对开.
        kHORIZONTAL_CLOSE = 15,              ///< 水平闭合.
        kVERTICAL_CLOSE = 16,              ///< 垂直闭合.
        kFADE = 17,              ///< 淡入淡出.
        kHORIZONTAL_SHUTTER = 18,              ///< 水平百叶窗.
        kVERTICAL_SHUTTER = 19,              ///< 垂直百叶窗.
        kNOT_CLEAR_AREA = 20,              ///< 不清屏.
        kLEFT_SERIES_MOVE = 21,              ///< 连续左移.
        kRIGHT_SERIES_MOVE = 22,              ///< 连续右移.
        kUP_SERIES_MOVE = 23,              ///< 连续上移.
        kDOWN_SERIES_MOVE = 24,              ///< 连续下移.
        kRANDOM = 25,              ///< 随机特效.
        kHT_LEFT_SERIES_MOVE = 26,              ///< 首尾相接连续左移.
        kHT_RIGHT_SERIES_MOVE = 27,              ///< 首尾相接连续右移.
        kHT_UP_SERIES_MOVE = 28,              ///< 首尾相接连续上移.
        kHT_DOWN_SERIES_MOVE = 29,              ///< 首尾相接连续下移.
    };

    public enum ProgramBgMode
    {
        kProgramBgPhoto,                        //图片节目背景
        kProgramBgColor                         //颜色节目背景
    }

    public enum HDFrameType
    {
        kMotleyFrame,                           ///< 花色边框
        kTricolorFrame,                         ///< 三基色边框
        kPurityColorFrame                       ///< 纯色边框
    }

    public enum HDFrameEffect
    {
        kRotateFrame,                           //花色边框
        kTwinkleFrame,                          //三基色边框
        kStaticFrame                            //纯色边框
    }

    public struct HDFrameAttr
    {
        public int Enable;                             //是否使用边框，0表示不使用，其他值表示使用
        public HDFrameType FrameType;                  //边框类型
        public int Speed;                              //边框速度，取值范围0-9，数值越大，速度越快
        public HDFrameEffect Effect;                   //边框特效
        //    union
        //    {
        //        int MotleyIndex;                    //花色边框类型，参考HDPlayer软件上的显示
        //        int TricolorIndex;                  //三基色边框类型，参考HDPlayer软件上的显示
        //        HDColor PurityColor;                //纯色边框颜色
        //}
        public int union;
    }

    public struct HDProgramNodeAttr
    {
        public IntPtr Parent;
        public int Alpha;
        public ProgramBgMode BgMode;//枚举
        public HDFrameAttr FrameAttr;//结构体
        //union
        //{
        //    HDColor BgColor;                   //节目背景色
        //    string BgPhoto;                    //节目背景图片
        //};
        public int union;
    }

    public struct HDRect
    {
        public int X;                                  //x坐标
        public int Y;                                  //y坐标
        public int Width;                              //宽度
        public int Height;                             //高度
    }

    public struct HDAreaNodeAttr
    {
        public IntPtr Parent;                          //节目节点
        public HDRect Rect;                            //区域大小及位置
        public int Alpha;                              //区域透明度(目前只有A60X、A30、A30+支持)
    }

    public enum HDTextType
    {
        kTextTypeNull,                          ///< 无文本
        kRtfString,                             ///< RTF字符串
        kRtfFile,                               ///< RTF文件
        kPlainTextString,                       ///< 纯文本字符串
        kTxtFile,                               ///< TXT文件
        kHtmlFile,                              ///< HTML文件
        kHtmlString,                            ///< HTML字符串
    }

    public struct HDColor
    {
        public uint Color;
        public HDColor(uint r, uint g, uint b, uint a)
        {
            Color = r | (g << 8) | (b << 16) | (a << 24);
        }

        /// <summary>
        /// 文本背景透明色，用于设置文本生成时的背景透明
        /// </summary>
        /// <returns></returns>
        public static HDColor TextBackGroundTransparent()
        {
            HDColor transparent = new HDColor();
            transparent.Color = 0x1FFFFFFF;
            return transparent;
        }
    }

    public struct HDFont
    {
        public string FontName;                         ///< 字体名字
        public int FontSize;                          ///< 字体大小
        public HDColor TextColor;                      ///< 字体颜色
        public HDColor TextBackgroundColor;            ///< 文字背景色
        public int Underline;                          ///< 下划线
        public int Bold;                               ///< 粗体
        public int Italic;                             ///< 斜体
    }

    public struct HDEffectAttr
    {
        public HDEffectType DispEffect;                         ///< 特效类型，参考HDEffectType
        public int DispSpeed;                          ///< 特效出场速度，取值范围0-9，建议4
        public int HoldTime;                           ///< 特效停留时间，单位0.1秒
        public HDEffectType ClearEffect;                        ///< 特效退场类型，参考HDEffectType
        public int ClearSpeed;                         ///< 特效退场速度，取值范围0-9，建议4
    }

    public struct HDTextNodeAttr
    {
        public IntPtr Parent;                      ///< 区域节点
        public HDTextType TextType;                    ///< 文本类型
        public uint BackgroundColor;                ///< 区域背景色
        public int Alignment;                                     ///
        public int Multiline;                     ///< 0 是单行文本，其它为多行文本
        //union {
        //    char* RtfString;                    ///< RTF字符串
        //    char* RtfFile;                      ///< RTF文件
        //    char* HtmlString;                   ///< HTML字符串
        //    char* HtmlFile;                     ///< HTML文件
        //    HDTxtFile TxtFile;                  ///< TXT文本
        //    HDPlainText PlainText;              ///< 纯文本字符串
        //};
        public HDFont font;
        public string text;

        public HDEffectAttr Effect;                    ///< 文本特效
    }

    public struct HDPhotoNodeAttr
    {
        public IntPtr Parent;                      ///< 区域节点
        public string Path;                             ///< 图像路径，图像格式支持:BMP、GIF、JPG、
                                                        ///< JPEG、MNG、PNG、PBM、PGM、PPM、TIFF、XBM、XPM、SVG、TGA
        int AspectRatio;                        ///< 保持宽高比
        HDEffectAttr Effect;                    ///< 图像特效
    };

    public class HDFileListItem
    {
        public string path;
        public string key;
    }

    public class HDFileList
    {
        public HDFileListItem[] FileList;
    }

    public enum HDRealtimeItemType
    {
        kText,                  // 文本
        kContinuousText,        // 连续移动文本
        kImage                  // 图片
    }

    public class HDRealtimeItem
    {
        public HDFileList FileList;      // 文件列表
        public string Guid;              // guid
        public HDRealtimeItemType type;          // 是否为连续左移节点
    }

    public class HD_Base
    {
        private static bool mInited = false;

        public static void HD_Init()
        {
            if (!mInited)
            {
                HDSDK_Initialize();
                mInited = true;
            }
        }

        [DllImport("HDSDK.dll")]
        private static extern HDErrorCode HDSDK_Initialize();

        [DllImport("HDSDK.dll")]
        public static extern HDErrorCode HDSDK_UnInitialize();

        [DllImport("HDSDK.dll")]
        public static extern HDErrorCode HDSDK_CreateScreen(out IntPtr node, ref HDScreenNodeAttr attr);

        [DllImport("HDSDK.dll")]
        public static extern HDErrorCode HDSDK_CreateProgram(out IntPtr node, ref HDProgramNodeAttr attr);

        [DllImport("HDSDK.dll")]
        public static extern HDErrorCode HDSDK_CreateArea(out IntPtr node, ref HDAreaNodeAttr attr);

        [DllImport("HDSDK.dll")]
        public static extern HDErrorCode HDSDK_CreateText(out IntPtr node, ref HDTextNodeAttr attr);

        [DllImport("HDSDK.dll")]
        public static extern HDErrorCode HDSDK_CreatePhoto(out IntPtr node, ref HDPhotoNodeAttr attr);

        [DllImport("HDSDK.dll")]
        public static extern HDErrorCode HDSDK_GetNodeFileList(IntPtr node, out IntPtr json);

        [DllImport("HDSDK.dll")]
        public static extern HDErrorCode HDSDK_FreePtr(IntPtr json);

        [DllImport("HDSDK.dll")]
        public static extern HDErrorCode HDSDK_FreeNode(IntPtr node);

        public static HDFileList GetTextMaterials(string deviceType, Size areaSize, HDFont font, string s,
            bool consecutive, bool alignCenter = false)
        {

            HD_Init();

            if (consecutive) alignCenter = false;
            if (alignCenter) consecutive = true;

            HDScreenNodeAttr screenNodeAttr = new HDScreenNodeAttr();
            screenNodeAttr.Width = 128;
            screenNodeAttr.Height = 64;
            screenNodeAttr.DeviceType = new char[20];

            for (int i = 0; i < deviceType.Length; i++)
            {
                screenNodeAttr.DeviceType[i] = deviceType[i];
            }

            //IntPtr screen = Marshal.AllocHGlobal(4);
            IntPtr screen;
            HDErrorCode code = HD_Base.HDSDK_CreateScreen(out screen, ref screenNodeAttr);

            IntPtr program;// = Marshal.AllocHGlobal(4);
            HDProgramNodeAttr ProgramNodeAttr = new HDProgramNodeAttr();
            ProgramNodeAttr.Parent = screen;
            code = HD_Base.HDSDK_CreateProgram(out program, ref ProgramNodeAttr);

            IntPtr area;// = Marshal.AllocHGlobal(4);
            HDAreaNodeAttr AreaNodeAttr = new HDAreaNodeAttr();
            AreaNodeAttr.Parent = program;
            AreaNodeAttr.Alpha = 0xFF;
            AreaNodeAttr.Rect.X = 0;
            AreaNodeAttr.Rect.Y = 0;
            AreaNodeAttr.Rect.Width = areaSize.Width;
            AreaNodeAttr.Rect.Height = areaSize.Height;
            code = HD_Base.HDSDK_CreateArea(out area, ref AreaNodeAttr);

            IntPtr text;// = Marshal.AllocHGlobal(4);
            HDTextNodeAttr PlainTextStringTextNodeAttr1 = new HDTextNodeAttr();

            PlainTextStringTextNodeAttr1.Parent = area;
            PlainTextStringTextNodeAttr1.TextType = HDTextType.kPlainTextString;
            //PlainTextStringTextNodeAttr1.BackgroundColor = 0x00000000;
            PlainTextStringTextNodeAttr1.Alignment = 1;//0、1、2对齐方式
            PlainTextStringTextNodeAttr1.Multiline = consecutive ? 0 : 1;
            PlainTextStringTextNodeAttr1.font = font;
            PlainTextStringTextNodeAttr1.text = s;
            PlainTextStringTextNodeAttr1.Effect.DispEffect = consecutive ? HDEffectType.kHT_LEFT_SERIES_MOVE : HDEffectType.kLEFT_TOP_COVER;
            PlainTextStringTextNodeAttr1.Effect.DispSpeed = 1;
            PlainTextStringTextNodeAttr1.Effect.HoldTime = 50;
            PlainTextStringTextNodeAttr1.Effect.ClearEffect = consecutive ? HDEffectType.kNOT_CLEAR_AREA : HDEffectType.kLEFT_TOP_COVER;
            PlainTextStringTextNodeAttr1.Effect.ClearSpeed = 1;
            code = HD_Base.HDSDK_CreateText(out text, ref PlainTextStringTextNodeAttr1);

            IntPtr init = Marshal.AllocHGlobal(4);
            code = HD_Base.HDSDK_GetNodeFileList(text, out init);

            HD_Base.HDSDK_FreeNode(screen);

            string json = Marshal.PtrToStringAnsi(init);

            HD_Base.HDSDK_FreePtr(init);

            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(HDFileList));
            HDFileList t = o as HDFileList;

            if (alignCenter)
            {
                foreach (var item in t.FileList)
                {
                    Bitmap b = new Bitmap(item.path);
                    Bitmap a = new Bitmap(areaSize.Width, areaSize.Height);
                    Graphics g = Graphics.FromImage(a);
                    g.DrawImage(b, (areaSize.Width - b.Width) / 2, 0);
                    g.Save();
                    b.Dispose();
                    a.Save(item.path);
                }
            }
            return null;
        }

        public static HDFileList GetTextMaterials(Size areaSize, HDFont font, string s,
           bool consecutive, bool alignCenter = false, bool colorKey = false)
        {
            FontStyle fontStyle = FontStyle.Regular;
            if (font.Bold == 1)
                fontStyle |= FontStyle.Bold;
            if (font.Italic == 1)
                fontStyle |= FontStyle.Italic;
            if (font.Underline == 1)
                fontStyle |= FontStyle.Underline;

            Font drawFont = new Font(font.FontName, (float)(font.FontSize), fontStyle, GraphicsUnit.Pixel);
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            StringFormat drawFormat = StringFormat.GenericTypographic;
            drawFormat.Alignment = alignCenter ? StringAlignment.Center : StringAlignment.Near;

            if (consecutive)
            {
                Graphics g = Graphics.FromHwnd(IntPtr.Zero);
                SizeF size = g.MeasureString(s, drawFont, new PointF(0, 0), drawFormat);
                areaSize.Width = (int)Math.Ceiling(size.Width);
            }

            List<HDFileListItem> list = new List<HDFileListItem>();
            string pathPrefix = Environment.CurrentDirectory + "\\temp\\" + GetTimeStamp();

            if (!Directory.Exists(Environment.CurrentDirectory + "\\temp\\"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\temp\\");
            }

            while (s != string.Empty)
            {
                HDFileListItem item = new HDFileListItem();
                item.path = pathPrefix + "-" + list.Count.ToString() + ".png";
                s = DrawPage(drawFont, drawBrush, areaSize, drawFormat, s, item.path, consecutive, colorKey);
                list.Add(item);
            }

            HDFileList fileList = new HDFileList();
            fileList.FileList = list.ToArray();

            return fileList;
        }

        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        public static string DrawPage(Font font, Brush brush, Size size, StringFormat stringFormat,
            string text, string imagePath, bool consecutive, bool colorKey)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(bitmap);
            //g.TranslateTransform(0, 0); 
            if (colorKey)
                g.Clear(Color.FromArgb(1, 2, 1));
            else
                g.Clear(Color.Transparent);

            if (font.Size <= 16)
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            else
                g.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

            int charactersOnPage = 0;
            int linesPerPage = 0;


            RectangleF layoutRectangle = new RectangleF(0, 0, size.Width, font.Height);

            if (consecutive)
            {
                layoutRectangle.Y = (size.Height - (int)Math.Ceiling(font.Size)) / 2;
            }
            else
            {
                if (size.Height >= (int)Math.Ceiling(font.Size))
                {
                    layoutRectangle.Y = (size.Height % (int)Math.Ceiling(font.Size)) / 2.0f;
                }
                else
                {
                    layoutRectangle.Y = -((int)Math.Ceiling(font.Size) % size.Height) / 2.0f;
                }
            }
            //layoutRectangle.Y = consecutive ? (size.Height - (int)Math.Ceiling(font.Size)) / 2 : (size.Height % (int)Math.Ceiling(font.Size)) / 2;

            do
            {
                //Size ss = TextRenderer.MeasureText(g, text, font, size, TextFormatFlags.NoPadding);
                ////TextRenderer.DrawText(g, text, font, new Rectangle(0, 0, 64, 32), Color.Red, Color.Transparent, TextFormatFlags.NoPadding);
                //TextRenderer.DrawText(g, text, font,
                //      new Rectangle(0, 0, 64, 32), Color.GreenYellow, Color.Transparent,
                //      TextFormatFlags.HorizontalCenter | TextFormatFlags.NoPadding |
                //      TextFormatFlags.TextBoxControl |
                //      TextFormatFlags.WordBreak);
                //g.DrawString
                SizeF sf = g.MeasureString(text, font, layoutRectangle.Size, stringFormat,
                out charactersOnPage, out linesPerPage);

                g.DrawString(text, font, brush, layoutRectangle, stringFormat);
                text = text.Substring(charactersOnPage);
                layoutRectangle.Y += font.Size;
            }
            while (((layoutRectangle.Y + font.Size) <= size.Height) && !consecutive);

            g.Save();
            bitmap.Save(imagePath);
            return text;
        }

        public static void TextMaterialsMiddle(HDFileList list, Size areaSize)
        {
            foreach (var item in list.FileList)
            {
                Bitmap b = new Bitmap(item.path);
                Bitmap a = new Bitmap(areaSize.Width, areaSize.Height);
                Graphics g = Graphics.FromImage(a);

                g.DrawImage(b, (areaSize.Width - b.Width) / 2, 0);
                g.Save();
                b.Dispose();
                a.Save(item.path);
            }
        }

        public static byte[] GenerateSinglelineTextXml(Size areaSize, string text, HDFont font)
        {
            MemoryStream stream = new MemoryStream();
            XmlTextWriter xml = new XmlTextWriter(stream, Encoding.UTF8);
            xml.Formatting = System.Xml.Formatting.Indented;
            xml.WriteStartDocument();
            xml.WriteStartElement("config.boo");
            xml.WriteStartElement("content");

            xml.WriteStartElement("channel");
            xml.WriteAttributeString("setSize", "0");
            xml.WriteEndElement();

            xml.WriteStartElement("channel");
            xml.WriteAttributeString("action", "add");

            xml.WriteStartElement("area");
            xml.WriteAttributeString("action", "add");

            xml.WriteStartElement("rectangle");
            xml.WriteAttributeString("x", "0");
            xml.WriteAttributeString("y", "0");
            xml.WriteAttributeString("width", areaSize.Width.ToString());
            xml.WriteAttributeString("height", areaSize.Height.ToString());
            xml.WriteEndElement(); // rectangle

            xml.WriteStartElement("materials");

            HDRealtimeItem item = new HDRealtimeItem();
            item.FileList = GetTextMaterials(areaSize, font, text, true);
            item.Guid = "abc";
            item.type = HDRealtimeItemType.kContinuousText;
            WriteContinousTextItem(xml, item, true);

            xml.WriteEndElement(); // materials

            xml.WriteEndElement(); // area
            xml.WriteEndElement(); // channel

            xml.WriteEndElement(); // end content
            xml.WriteEndElement(); // end config.boo
            xml.Close();
            //FileStream s = File.Create("D:\\t.xml");
            //s.Write(stream.ToArray(), 0, stream.ToArray().Count());
            //s.Close();
            return stream.ToArray();
        }

        public static string GenerateRealtimeXml(string image, string guid)
        {

            FileStream file = new FileStream(image, FileMode.Open);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }

            string configPath = "D:\\HDSDK1.1_DEMO\\Temp\\" + DateTime.Now.ToString("yyyy-MM-dd_hhmmss") + ".xml";
            XmlTextWriter xml = new XmlTextWriter(configPath, Encoding.UTF8);
            xml.Formatting = System.Xml.Formatting.Indented;
            xml.WriteStartDocument();
            xml.WriteStartElement("config.boo");
            xml.WriteStartElement("content");
            xml.WriteAttributeString("realTime", "1");
            xml.WriteStartElement("materials");
            xml.WriteStartElement("image");
            xml.WriteAttributeString("action", "update");
            xml.WriteAttributeString("guid", guid);
            xml.WriteStartElement("file");
            xml.WriteAttributeString("size", file.Length.ToString());
            xml.WriteAttributeString("path", image);
            xml.WriteAttributeString("md5", sb.ToString());
            xml.WriteEndElement(); // end file
            xml.WriteEndElement(); // end image
            xml.WriteEndElement(); // end materials
            xml.WriteEndElement(); // end content
            xml.WriteEndElement(); // end config.boo
            xml.Close();
            file.Close();
            return configPath;
        }

        public static string GenerateRealtimeXml(List<HDRealtimeItem> items)
        {
            string configPath = "D:\\HDSDK1.1_DEMO\\Temp\\" + DateTime.Now.ToString("yyyy-MM-dd_hhmmss") + ".xml";
            XmlTextWriter xml = new XmlTextWriter(configPath, Encoding.UTF8);
            xml.Formatting = System.Xml.Formatting.Indented;
            xml.WriteStartDocument();

            xml.WriteStartElement("config.boo");
            xml.WriteStartElement("content");
            xml.WriteAttributeString("realTime", "1");
            xml.WriteStartElement("materials");

            foreach (var item in items)
            {
                switch (item.type)
                {
                    case HDRealtimeItemType.kContinuousText:
                        WriteContinousTextItem(xml, item);
                        break;
                    case HDRealtimeItemType.kText:
                        WriteTextItem(xml, item);
                        break;
                    case HDRealtimeItemType.kImage:
                        WriteImageItem(xml, item);
                        break;
                }
            }

            xml.WriteEndElement(); // end materials
            xml.WriteEndElement(); // end content
            xml.WriteEndElement(); // end config.boo
            xml.Close();

            return configPath;
        }

        private static void WriteImageItem(XmlTextWriter xml, HDRealtimeItem data)
        {
            xml.WriteStartElement("image");
            xml.WriteAttributeString("action", "update");
            xml.WriteAttributeString("guid", data.Guid);

            foreach (HDFileListItem item in data.FileList.FileList)
            {
                FileStream file = new FileStream(item.path, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                xml.WriteStartElement("file");
                xml.WriteAttributeString("size", file.Length.ToString());
                xml.WriteAttributeString("path", item.path);
                xml.WriteAttributeString("md5", sb.ToString());
                xml.WriteEndElement(); // end file
                file.Close();
            }

            xml.WriteEndElement(); // end image
        }

        private static void WriteTextItem(XmlTextWriter xml, HDRealtimeItem data)
        {
            xml.WriteStartElement("text");
            xml.WriteAttributeString("action", "update");
            xml.WriteAttributeString("guid", data.Guid);

            foreach (HDFileListItem item in data.FileList.FileList)
            {
                FileStream file = new FileStream(item.path, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                xml.WriteStartElement("file");
                xml.WriteAttributeString("size", file.Length.ToString());
                xml.WriteAttributeString("path", item.path);
                xml.WriteAttributeString("md5", sb.ToString());
                xml.WriteEndElement(); // end file
                file.Close();
            }

            xml.WriteEndElement(); // end text
        }

        private static void WriteContinousTextItem(XmlTextWriter xml, HDRealtimeItem data, bool create = false)
        {
            xml.WriteStartElement("text");

            xml.WriteAttributeString("action", create ? "add" : "update");
            xml.WriteAttributeString("guid", data.Guid);

            xml.WriteStartElement("singleMode");
            xml.WriteValue(1);
            xml.WriteEndElement();
            xml.WriteStartElement("pageCount");
            xml.WriteValue(data.FileList.FileList.Length);
            xml.WriteEndElement();

            // <continuousMove headCloseToTail="0" speed ="4" playType ="ByCount" byCount ="2000"/>
            xml.WriteStartElement("continuousMove");
            xml.WriteAttributeString("headCloseToTail", "0");
            xml.WriteAttributeString("speed", "4");
            xml.WriteAttributeString("playType", "ByCount");
            xml.WriteAttributeString("byCount", "2000");
            xml.WriteEndElement();

            foreach (HDFileListItem item in data.FileList.FileList)
            {
                FileStream file = new FileStream(item.path, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                xml.WriteStartElement("file");
                xml.WriteAttributeString("size", file.Length.ToString());
                xml.WriteAttributeString("path", item.path);
                xml.WriteAttributeString("md5", sb.ToString());
                xml.WriteEndElement(); // end file
                file.Close();
            }

            xml.WriteEndElement(); // end image
        }

        public static string GenerateRealtimeXml(HDFileList list, string guid)
        {
            string configPath = "D:\\HDSDK1.1_DEMO\\Temp\\" + DateTime.Now.ToString("yyyy-MM-dd_hhmmss") + ".xml";
            XmlTextWriter xml = new XmlTextWriter(configPath, Encoding.UTF8);
            xml.Formatting = System.Xml.Formatting.Indented;
            xml.WriteStartDocument();
            xml.WriteStartElement("config.boo");
            xml.WriteStartElement("content");
            xml.WriteAttributeString("realTime", "1");
            xml.WriteStartElement("materials");
            xml.WriteStartElement("text");
            xml.WriteAttributeString("action", "update");
            xml.WriteAttributeString("guid", guid);

            foreach (HDFileListItem item in list.FileList)
            {
                FileStream file = new FileStream(item.path, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                xml.WriteStartElement("file");
                xml.WriteAttributeString("size", file.Length.ToString());
                xml.WriteAttributeString("path", item.path);
                xml.WriteAttributeString("md5", sb.ToString());
                xml.WriteEndElement(); // end file
                file.Close();
            }

            xml.WriteEndElement(); // end image
            xml.WriteEndElement(); // end materials
            xml.WriteEndElement(); // end content
            xml.WriteEndElement(); // end config.boo
            xml.Close();
            return configPath;
        }

        public static string GenerateMoveLiftRealtimeXml(HDFileList list, string guid)
        {
            string configPath = "D:\\HDSDK1.1_DEMO\\Temp\\" + DateTime.Now.ToString("yyyy-MM-dd_hhmmss") + ".xml";
            XmlTextWriter xml = new XmlTextWriter(configPath, Encoding.UTF8);
            xml.Formatting = System.Xml.Formatting.Indented;
            xml.WriteStartDocument();
            xml.WriteStartElement("config.boo");
            xml.WriteStartElement("content");
            xml.WriteAttributeString("realTime", "1");
            xml.WriteStartElement("materials");
            xml.WriteStartElement("text");
            xml.WriteAttributeString("action", "update");
            xml.WriteAttributeString("guid", guid);

            xml.WriteStartElement("singleMode");
            xml.WriteValue(1);
            xml.WriteEndElement();
            xml.WriteStartElement("pageCount");
            xml.WriteValue(list.FileList.Length);
            xml.WriteEndElement();

            // <continuousMove headCloseToTail="0" speed ="4" playType ="ByCount" byCount ="2000"/>
            xml.WriteStartElement("continuousMove");
            xml.WriteAttributeString("headCloseToTail", "0");
            xml.WriteAttributeString("speed", "4");
            xml.WriteAttributeString("playType", "ByCount");
            xml.WriteAttributeString("byCount", "2000");
            xml.WriteEndElement();

            foreach (HDFileListItem item in list.FileList)
            {
                FileStream file = new FileStream(item.path, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                xml.WriteStartElement("file");
                xml.WriteAttributeString("size", file.Length.ToString());
                xml.WriteAttributeString("path", item.path);
                xml.WriteAttributeString("md5", sb.ToString());
                xml.WriteEndElement(); // end file
                file.Close();
            }

            xml.WriteEndElement(); // end image
            xml.WriteEndElement(); // end materials
            xml.WriteEndElement(); // end content
            xml.WriteEndElement(); // end config.boo
            xml.Close();
            return configPath;
        }
    }
}
