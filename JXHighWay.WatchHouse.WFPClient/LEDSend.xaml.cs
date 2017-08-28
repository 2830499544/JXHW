using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using JXHighWay.WatchHouse.Bll.Client.GanTing;
using JXHighWay.WatchHouse.Bll.Client.LED;
using System.IO;
using JXHighWay.WatchHouse.Helper;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// LEDSend.xaml 的交互逻辑
    /// </summary>
    public partial class LEDSend : Window
    {
        public LEDSend()
        {
            InitializeComponent();
        }

        private void button_QuXiao_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }

        List<CheckBox> m_CheckBoxList = null;

        void init()
        {
            //岗亭初始化
            m_CheckBoxList = new List<CheckBox>();
            WatchHouseMonitoring vWatchHouseMonitoring = new WatchHouseMonitoring();
            List<WatchHouseInfo> vWatchHouseInfoList = vWatchHouseMonitoring.GetAllWatchHouseInfo();

            double vCount_Double = vWatchHouseInfoList.Count / (double)4;
            int vCount_int = (int)(vCount_Double / (double)8);

            for (int i = 0; i < vWatchHouseInfoList.Count; i++)
            {
                CheckBox vNewCheckBox = new CheckBox()
                {
                    Content = vWatchHouseInfoList[i].GangTingMC,
                    Tag = string.Format("{0}|{1}", vWatchHouseInfoList[i].GuanGaoPing1IP, vWatchHouseInfoList[i].GuanGaoPing2IP) 
                };

                string vIsSelected = SelectedIPArray.Where(m => m == vWatchHouseInfoList[i].GuanGaoPing1IP).FirstOrDefault();
                if (vIsSelected != null && vIsSelected != "")
                    vNewCheckBox.IsChecked = true;

                listBox_GangTing.Items.Add(vNewCheckBox);
                m_CheckBoxList.Add(vNewCheckBox);
                
            }

            //文本内容初始化
            List<TextInfo> vTextInfoList = new List<TextInfo>();
            foreach (string vText in TextArray )
            {
                BitmapImage vBitmapImage = new BitmapImage();
                vBitmapImage.BeginInit();
                vBitmapImage.StreamSource = CommHelper.ByteToStream(CommHelper.SetImageToByteArray(vText));
                vBitmapImage.EndInit();
                vTextInfoList.Add(new TextInfo() { FullPath = vText,Image= vBitmapImage });
            }
            listBox_Text.ItemsSource = vTextInfoList;

            //图片内容初始化
            List<TextInfo> vPicInfoList = new List<TextInfo>();
            foreach( string vPic in PicArray)
            {
                vPicInfoList.Add(new TextInfo() { FullPath=vPic } );
            }
            listBox_Pic.ItemsSource = vPicInfoList;


            //视频内容初始化
            List<TextInfo> vVideoInfoList = new List<TextInfo>();
            foreach( string vVideo in VideoArray )
            {
                vVideoInfoList.Add(new TextInfo() { FullPath = vVideo });
            }
            listBox_Video.ItemsSource = vVideoInfoList;

        }

        /// <summary>
        /// 选择的岗亭IP
        /// </summary>
        public string[] SelectedIPArray { get; set; } = new string[0];
        /// <summary>
        /// 文本内容
        /// </summary>
        public string[] TextArray { get; set; }
        /// <summary>
        /// 选择的文本内容
        /// </summary>
        public string[] SelectedTextArray { get; set; } = new string[0];

        /// <summary>
        /// 图片内容
        /// </summary>
        public string[] PicArray { get; set; }
        /// <summary>
        /// 选择的图片
        /// </summary>
        public string[] SelectedPicArray { get; set; } = new string[0];

        /// <summary>
        /// 视频内容
        /// </summary>
        public string[] VideoArray { get; set; }
        /// <summary>
        /// 选择的视频
        /// </summary>
        public string[] SelectedVideoArray { get; set; } = new string[0];

        private void button_XuanDing_Click(object sender, RoutedEventArgs e)
        {
            //岗亭
            List<string> vSelectedIP = new List<string>();
            foreach ( CheckBox vTempCheckBox in m_CheckBoxList )
            {
                if (vTempCheckBox.IsChecked ?? false)
                {
                    string vTag = (string)vTempCheckBox.Tag;
                    string[] vTagArray = vTag.Split('|');
                    if ( vTagArray[0]!=null && vTagArray[0]!="")
                        vSelectedIP.Add(vTagArray[0]);
                    if (vTagArray[1] != null && vTagArray[1] != "")
                        vSelectedIP.Add(vTagArray[1]);
                }
            }
            SelectedIPArray = vSelectedIP.ToArray();


            //文字
            List<string> vSelectedText = new List<string>();
            foreach ( TextInfo vTempItem in listBox_Text.Items )
            {
                if (vTempItem.IsSelected)
                {
                    
                    vSelectedText.Add(vTempItem.FullPath);
                }

            }
            SelectedTextArray = vSelectedText.ToArray();

            //图片
            List<string> vSelectedPic = new List<string>();
            foreach( TextInfo vTempItem in listBox_Pic.Items )
            {
                if (vTempItem.IsSelected)
                    vSelectedPic.Add(vTempItem.FullPath);
            }
            SelectedPicArray = vSelectedPic.ToArray();

            //视频
            List<string> vSelectedVideo = new List<string>();
            foreach( TextInfo vTempItem in listBox_Video.Items )
            {
                if (vTempItem.IsSelected)
                    vSelectedVideo.Add(vTempItem.FullPath);
            }
            SelectedVideoArray = vSelectedVideo.ToArray();

            DialogResult = true;
        }

        private void checkBox_SelectedAll_Checked(object sender, RoutedEventArgs e)
        {
            if (m_CheckBoxList!=null)
            {
                foreach(CheckBox vTempCheckBox in m_CheckBoxList)
                {
                    vTempCheckBox.IsChecked = true;
                }
            }
        }

        private void checkBox_SelectedAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (m_CheckBoxList != null)
            {
                foreach (CheckBox vTempCheckBox in m_CheckBoxList)
                {
                    vTempCheckBox.IsChecked = false;
                }
            }
        }

        private void Image_Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
