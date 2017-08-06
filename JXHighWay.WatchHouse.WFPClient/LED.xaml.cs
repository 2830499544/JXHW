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
using System.Windows.Navigation;
using System.Windows.Shapes;
using JXHighWay.WatchHouse.Bll.Client;
using JXHighWay.WatchHouse.LED;
using System.Xml.Serialization;
using System.IO;
using JXHighWay.WatchHouse.Bll.Client.LED;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// LED.xaml 的交互逻辑
    /// </summary>
    public partial class LED : Page
    {
        LEDControl m_LEDControl;
        string m_RichText;
        Dictionary<int, string> m_Eff = new Dictionary<int, string>()
        {
            {0,"直接显示"},
            {1,"向左平移"},
            {2,"向右平移"},
            {3,"向上平移"},
            {4,"向下平移"},
            {5,"向左覆盖"},
            {6,"向右覆盖"},
            {7,"向上覆盖"},
            {8,"向下覆盖"},
            {9,"左上覆盖"},
            {10,"左下覆盖"},
            {11,"右上覆盖"},
            {12,"右下覆盖"},
            {13,"水平对开"},
            {14,"垂直对开"},
            {15,"水平闭合"},
            {16,"垂直闭合"},
            {17,"淡入淡出"},
            {18,"水平百叶窗"},
            {19,"垂直百叶窗"},
            {20,"不清屏"},
            {25,"随机"},
        };
        public LED()
        {
            InitializeComponent();
        }

        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            //LEDControl vLEDControl = new LEDControl("192.168.0.113", 64, 64);
            //vLEDControl.SendText(TextBox_Text.Text);
        }

        private void button_Test_Click(object sender, RoutedEventArgs e)
        {
            
        }

      
        private void button_ShiPing_ShangChuang_Click(object sender, RoutedEventArgs e)
        {
           
            //if (System.IO.File.Exists(textBox_ShiPing.Text))
            //    m_LEDControl.SendVideo( App.AdminUser, textBox_ShiPing.Text);
            //else
            //    Xceed.Wpf.Toolkit.MessageBox.Show("视频文件不存在", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void button_ShiPing_LiuLan_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog vOpenFile = new Microsoft.Win32.OpenFileDialog();
            vOpenFile.Filter = "视频文件|*.mp4;*.avi;";
            if (vOpenFile.ShowDialog().Value)
            {
                textBox_ShiPing_SPLJ.Text = vOpenFile.FileName;
            }
        }

        private void button_TuPian_LiuLan_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog vOpenFile = new Microsoft.Win32.OpenFileDialog();
            vOpenFile.Filter = "图片文件|*.jpg;*.png;";
            if (vOpenFile.ShowDialog().Value)
            {
                textBox_TuPian_TPLJ.Text = vOpenFile.FileName;
            }
        }

        private void button_Text_ShangChuang_Click(object sender, RoutedEventArgs e)
        {
            //if (textBox_Text.Text != "")
            //    m_LEDControl.SendText( App.AdminUser, textBox_Text.Text);
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("请输入方字", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
            //    textBox_Text.Focus();
            //}
        }

        private void button_TuPian_ShangChuang_Click(object sender, RoutedEventArgs e)
        {
            //if (System.IO.File.Exists(textBox_TuPian.Text))
            //    m_LEDControl.SendImage( App.AdminUser, textBox_TuPian.Text);
            //else
            //    Xceed.Wpf.Toolkit.MessageBox.Show("图片文件不存在", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void button_Text_QunFa_Click(object sender, RoutedEventArgs e)
        {
            //if (textBox_Text.Text != "")
            //    m_LEDControl.SendTextQF(App.AdminUser, textBox_Text.Text);
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("请输入方字", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
            //    textBox_Text.Focus();
            //}
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            m_LEDControl = new LEDControl(App.WatchHouseID);
            if (m_LEDControl.Width != 0 && m_LEDControl.Heigth != 0)
            {
                RTFBox1.RichWidth = m_LEDControl.Width;
                RTFBox1.RichHeight = m_LEDControl.Heigth;
            }
            else
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("未设置LED广告屏的分辨率", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                tabControl.IsEnabled = false;
                RTFBox1.Visibility = Visibility.Hidden;
            }
            //文本
            comboBox_Text_XianShi1.ItemsSource = m_Eff;
            comboBox_Text_XianShi1.SelectedValuePath = "Key";
            comboBox_Text_XianShi1.DisplayMemberPath = "Value";
            comboBox_Text_XianShi1.SelectedValue = 25;

            comboBox_Text_QinPing1.ItemsSource = m_Eff;
            comboBox_Text_QinPing1.SelectedValuePath = "Key";
            comboBox_Text_QinPing1.DisplayMemberPath = "Value";
            comboBox_Text_QinPing1.SelectedValue = 25;
            integerUpDown_Text.Value = 0;

            //视频下接列表绑定
            comboBox_ShiPing_QinPing1.ItemsSource = m_Eff;
            comboBox_ShiPing_QinPing1.SelectedValuePath = "Key";
            comboBox_ShiPing_QinPing1.DisplayMemberPath = "Value";
            comboBox_ShiPing_QinPing1.SelectedValue = 25;

            comboBox_ShiPing_XianShi1.ItemsSource = m_Eff;
            comboBox_ShiPing_XianShi1.SelectedValuePath = "Key";
            comboBox_ShiPing_XianShi1.DisplayMemberPath = "Value";
            comboBox_ShiPing_XianShi1.SelectedValue = 25;

            integerUpDown_ShiPing.Value = 0;


            //图片下接列表绑定
            comboBox_TuPian_QinPing1.ItemsSource = m_Eff;
            comboBox_TuPian_QinPing1.SelectedValuePath = "Key";
            comboBox_TuPian_QinPing1.DisplayMemberPath = "Value";
            comboBox_TuPian_QinPing1.SelectedValue = 25;

            comboBox_TuPian_XianShi1.ItemsSource = m_Eff;
            comboBox_TuPian_XianShi1.SelectedValuePath = "Key";
            comboBox_TuPian_XianShi1.DisplayMemberPath = "Value";
            comboBox_TuPian_XianShi1.SelectedValue = 25;
            integerUpDown_TuPian.Value = 0;
        }


        private void button_ShiPing_QunFa_Click(object sender, RoutedEventArgs e)
        {
            //if (System.IO.File.Exists(textBox_ShiPing.Text))
            //    m_LEDControl.SendVideoQF(App.AdminUser, textBox_ShiPing.Text);
            //else
            //    Xceed.Wpf.Toolkit.MessageBox.Show("视频文件不存在", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void button_TuPian_QunFa_Click(object sender, RoutedEventArgs e)
        {
            //if (System.IO.File.Exists(textBox_TuPian.Text))
            //    m_LEDControl.SendImageQF(App.AdminUser, textBox_TuPian.Text);
            //else
            //    Xceed.Wpf.Toolkit.MessageBox.Show("图片文件不存在", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LEDText vLEDText = new LEDText();
            vLEDText.RichHeigth = m_LEDControl.Heigth;
            vLEDText.RichWidth = m_LEDControl.Width;
            vLEDText.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LEDControl vLEDControl = new LEDControl( App.WatchHouseID);
            vLEDControl.Test();
        }

        private void button_Text_BianJi_Click(object sender, RoutedEventArgs e)
        {
            if (m_LEDControl.Width != 0 && m_LEDControl.Heigth != 0)
            {
                LEDText vLEDText = new LEDText();
                vLEDText.RichHeigth = m_LEDControl.Heigth;
                vLEDText.RichWidth = m_LEDControl.Width;
                vLEDText.RichText = m_RichText;
                if (vLEDText.ShowDialog() ?? true)
                {
                    m_RichText = vLEDText.RichText;
                    Console.WriteLine("LED图片->{0}",vLEDText.ImagePath);
                }
            }
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("未设置LED广告屏的分辨率", "错误", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        string[] m_SelectedIPArray = new string[0];
        private void button_FaShong_Click(object sender, RoutedEventArgs e)
        {

            // vLEDControl.SendImage("aa", @"E:\a.jpg");
            LEDSend vLEDSend = new LEDSend();
            vLEDSend.SelectedIPArray = m_SelectedIPArray;
            if ( vLEDSend.ShowDialog()??false )
            {
                List<LEDChannelInfo> vLEDChannelInfoList = new List<LEDChannelInfo>();
                LEDControl vLEDControl = new LEDControl(App.WatchHouseID);

                if (RTFBox1.ImagePath != null && RTFBox1.ImagePath != "")
                {
                    LEDChannelInfo vTextChannelInfo = new LEDChannelInfo()
                    {
                        ChannelType = LEDChanneTypeEnum.Text,
                        Content = RTFBox1.ImagePath,
                        InEff = (int)comboBox_Text_XianShi1.SelectedValue,
                        OutEff = (int)comboBox_Text_QinPing1.SelectedValue,
                        HoldTime = (integerUpDown_Text.Value ?? 0) * 10
                    };
                    vLEDChannelInfoList.Add(vTextChannelInfo);
                }

                if (textBox_TuPian_TPLJ.Text != "")
                {
                    LEDChannelInfo vTuPianChannelInfo = new LEDChannelInfo()
                    {
                        ChannelType = LEDChanneTypeEnum.Image,
                        Content = textBox_TuPian_TPLJ.Text,
                        InEff = (int)comboBox_TuPian_XianShi1.SelectedValue,
                        OutEff = (int)comboBox_TuPian_QinPing1.SelectedValue,
                        HoldTime = (integerUpDown_TuPian.Value ?? 0) * 10
                    };
                    vLEDChannelInfoList.Add(vTuPianChannelInfo);
                }

                if (textBox_ShiPing_SPLJ.Text != "")
                {
                    LEDChannelInfo vShiPingChannelInfo = new LEDChannelInfo()
                    {
                        ChannelType = LEDChanneTypeEnum.Video,
                        Content = textBox_ShiPing_SPLJ.Text,
                        InEff = (int)comboBox_ShiPing_XianShi1.SelectedValue,
                        OutEff = (int)comboBox_ShiPing_QinPing1.SelectedValue,
                        HoldTime = (integerUpDown_ShiPing.Value ?? 0) * 10
                    };
                    vLEDChannelInfoList.Add(vShiPingChannelInfo);
                }
                m_SelectedIPArray = vLEDSend.SelectedIPArray;
                vLEDControl.SendMultiChannel(vLEDChannelInfoList, m_SelectedIPArray);
            }
        }
    }
}
