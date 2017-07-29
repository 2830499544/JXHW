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
using JXHighWay.WatchHouse.Bll.Client.DianYuan;
using JXHighWay.WatchHouse.Helper;
using System.Windows.Controls.DataVisualization.Charting;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit;
using System.IO;
using Microsoft.Win32;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// DianYuanMingXi.xaml 的交互逻辑
    /// </summary>
    public partial class DianYuanMingXi : Window
    {
        byte m_LuHao;
        /// <summary>
        /// 路号
        /// </summary>
        public int LuHao {
            get
            {
                return m_LuHao;
            }
            set
            {
                m_LuHao = (byte)(value >> 0);
            }
        }
        /// <summary>
        /// 电源编号
        /// </summary>
        public string DianYuanID { get; set;}
        //是否初始化
        bool m_IsInit = false;
        /// <summary>
        /// 定时组数据
        /// </summary>
        List<TimingInfo> m_TimingInfoList = null;
        /// <summary>
        /// 正在编辑的定时组号
        /// </summary>
        int m_EditZhuHao = -1;
        /// <summary>
        /// 设置信息
        /// </summary>
        ParamInfo m_ParamInfo;


        PowerMonitoring m_PowerMonitoring { get; set; }
        public DianYuanMingXi()
        {
            InitializeComponent();
        }

       
        void init()
        {
            m_IsInit = false;
            m_PowerMonitoring = new PowerMonitoring();
            init_ZhuanTai();
            init_DingShi();
            init_SheZhi();
            init_RiZi();
            m_IsInit = true;
        }

        /// <summary>
        /// 初始化日志
        /// </summary>
        void init_RiZi()
        {
            LogInfo[] vLogInfoArray = m_PowerMonitoring.GetLog(DianYuanID, LuHao, "操作类");
            dataGrid_Log.ItemsSource = vLogInfoArray;
        }

        /// <summary>
        /// 初始化设置
        /// </summary>
        void init_SheZhi()
        {
            m_ParamInfo =  m_PowerMonitoring.GetSwitchParamInfo(DianYuanID, LuHao);
            integerUpDown_XDDN.Value = m_ParamInfo.XianDingDN;
            integerUpDown_XDGL.Value = m_ParamInfo.XianDingGL;
            integerUpDown_DLNLZ.Value = m_ParamInfo.DianLiuLLZ;
            integerUpDown_CWBH.Value = m_ParamInfo.ChaoWenBHZ;
            integerUpDown_CWYJZ.Value = m_ParamInfo.ChaoWenYJZ;
            integerUpDown_GYSX.Value = m_ParamInfo.GuoYaSX;
            integerUpDown_QYXX.Value = m_ParamInfo.QianYaXX;
            integerUpDown_EDLD.Value = m_ParamInfo.EDingLDDZDL;
            integerUpDown_LDYJZ.Value = m_ParamInfo.LouDianLYJZ;
        }

        /// <summary>
        /// 初始化状态
        /// </summary>
        void init_ZhuanTai()
        {
            PowerInfo vPowerInfo = m_PowerMonitoring.GetNewPowerInfo(DianYuanID, LuHao);
            label_ZT_DL.Content = string.Format("{0}A", vPowerInfo.DianLiu );
            label_ZT_DN.Content = string.Format("{0}kWh" ,vPowerInfo.DianNeng);
            label_ZT_DY.Content = string.Format("{0}V", vPowerInfo.DianYa);
            label_ZT_GLYS.Content = string.Format("{0}",vPowerInfo.GongLuYinShu);
            label_ZT_LDL.Content = string.Format("{0}mA", vPowerInfo.LouDianLiu);
            label_ZT_PL.Content = string.Format("{0}Hz", vPowerInfo.PinLu);
            label_ZT_WD.Content = string.Format("{0}℃", vPowerInfo.WenDu);
            label_ZT_WGGL.Content = string.Format("{0}var", vPowerInfo.WuGongGL);
            label_ZT_YGGL.Content = string.Format("{0}W", vPowerInfo.YouGongGL);
        }

        void bindTimingInfo(TimingInfo timingInfo,int zhuHao)
        {
            if (timingInfo != null && timingInfo.DianYuanID != null && timingInfo.DianYuanID != "")
            {
                Label vLabel_DS_CZ = (Label)FindName(string.Format("label_DS_CZ{0}", zhuHao));
                Label vLabel_DS_ZQ = (Label)FindName(string.Format("label_DS_ZQ{0}", zhuHao));
                Label vLabel_DS_SJ = (Label)FindName(string.Format("label_DS_SJ{0}", zhuHao));
                //操作
                if (timingInfo.YunXuKZ == 0x00)
                {
                    vLabel_DS_CZ.Content = "禁止";
                    vLabel_DS_CZ.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EA3B3A"));
                }
                else
                {
                    vLabel_DS_CZ.Content = "允许";
                    vLabel_DS_CZ.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1BA261"));
                }
                byte vWeek, vHour, vMinute, vDay;
                switch (timingInfo.ZhouQi)
                {
                    case 0:
                        //vLabel_DS_ZQ.Content = "单次";
                        vLabel_DS_SJ.Content = CommHelper.TimestampToDateTime(timingInfo.TimeData).ToString("yyyy-MM-dd hh:mm:ss");
                        break;
                    case 1:
                        //vLabel_DS_ZQ.Content = "每天";
                        vHour = (byte)(timingInfo.TimeData >> 8);
                        vMinute = (byte)(timingInfo.TimeData >> 0);
                        vLabel_DS_SJ.Content = string.Format("{0}:{1}", vHour, vMinute);
                        break;
                    case 2:
                        //vLabel_DS_ZQ.Content = "每周";
                        vWeek = (byte)(timingInfo.TimeData >> 16);
                        vHour = (byte)(timingInfo.TimeData >> 8);
                        vMinute = (byte)(timingInfo.TimeData >> 0);
                        vLabel_DS_SJ.Content = string.Format("周{0} {1}:{2}", vWeek, vHour, vMinute);
                        break;
                    case 3:
                        //vLabel_DS_ZQ.Content = "每月";
                        vDay = (byte)(timingInfo.TimeData >> 16);
                        vHour = (byte)(timingInfo.TimeData >> 8);
                        vMinute = (byte)(timingInfo.TimeData >> 0);
                        vLabel_DS_SJ.Content = string.Format("{0}日 {1}:{2}", vDay, vHour, vMinute);
                        break;
                }
                vLabel_DS_ZQ.Content = m_PowerMonitoring.ConvertTimingZQToStr(timingInfo.ZhouQi);
            }
        }
       
        /// <summary>
        /// 初始化定时
        /// </summary>
        void init_DingShi()
        {
            createComboBox();
            createDatePicker();
            createValueRangeTextBox();
            timePicker_Time.Value = DateTime.Now;
            for(int i=0;i<4;i++)
            {
                byte vLuHao = (byte)(i >> 0);
                m_TimingInfoList =  m_PowerMonitoring.GetTimingInfo(DianYuanID, vLuHao);
                TimingInfo vTimingInfo = m_TimingInfoList.Where(m => m.LuHao == i).FirstOrDefault();
                bindTimingInfo(vTimingInfo,i);
            }
        }

        /// <summary>
        /// 初始化用电
        /// </summary>
        void yongDianTongJi( PowerInfo[] dataSource,string title)
        {
            Chart_YD.Series.Clear();
            LineSeries vLineSeries = new LineSeries();
            //LS.Title = "图例2";
            vLineSeries.ItemsSource = dataSource;
            vLineSeries.IndependentValueBinding = new System.Windows.Data.Binding("ShiJianStr");
            vLineSeries.DependentValueBinding = new System.Windows.Data.Binding("DianNeng");
            Chart_YD.Title = title;
            Chart_YD.Series.Add(vLineSeries);
            Chart_YD.UpdateLayout();
        }


        private void button_YD_RYD_Click(object sender, RoutedEventArgs e)
        {
            PowerInfo[] vDataSource = m_PowerMonitoring.GetYongDianLiang_Ri(DianYuanID, LuHao);
            yongDianTongJi(vDataSource, string.Format("日用电量统计(总计:{0}kwh)", vDataSource.Sum(m => m.DianNeng)));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }

        private void button_YD_YYD_Click(object sender, RoutedEventArgs e)
        {
            PowerInfo[] vDataSource = m_PowerMonitoring.GetYongDianLiang_Yue(DianYuanID, LuHao);
            yongDianTongJi(vDataSource, string.Format("月用电量统计(总计:{0}kwh)", vDataSource.Sum(m => m.DianNeng)));
        }

        private void button_YD_NYD_Click(object sender, RoutedEventArgs e)
        {
            PowerInfo[] vDataSource = m_PowerMonitoring.GetYongDianLiang_Nian(DianYuanID, LuHao);
            yongDianTongJi(vDataSource, string.Format("年用电量统计(总计:{0}kwh)", vDataSource.Sum(m => m.DianNeng)));
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Xceed.Wpf.Toolkit.MessageBox.Show("OK");
        }

        DatePicker m_DatePicker = null;
        void createDatePicker()
        {
            m_DatePicker = new DatePicker();
            m_DatePicker.HorizontalAlignment = HorizontalAlignment.Left;
            m_DatePicker.VerticalAlignment = VerticalAlignment.Top;
            m_DatePicker.Width = 134;
            m_DatePicker.Height = 30;
            m_DatePicker.SetValue(Grid.RowProperty, 1);
            m_DatePicker.Margin = new Thickness(59, 10, 0, 0);
            m_DatePicker.Visibility = Visibility.Hidden;
            m_DatePicker.Name = "DataPicker_Date";
            Grid_CS.Children.Add(this.m_DatePicker);
            Grid_CS.RegisterName(m_DatePicker.Name, this.m_DatePicker);
        }

        ComboBox m_ComboBox = null;
        void createComboBox()
        {
            m_ComboBox = new ComboBox();
            m_ComboBox.HorizontalAlignment = HorizontalAlignment.Left;
            m_ComboBox.Width = 134;
            m_ComboBox.Height = 30;
            m_ComboBox.SetValue(Grid.RowProperty, 1);
            m_ComboBox.VerticalAlignment = VerticalAlignment.Top;
            m_ComboBox.Margin = new Thickness(59, 10, 0, 0);
            m_ComboBox.Items.Add("周一");
            m_ComboBox.Items.Add("周二");
            m_ComboBox.Items.Add("周三");
            m_ComboBox.Items.Add("周四");
            m_ComboBox.Items.Add("周五");
            m_ComboBox.Items.Add("周六");
            m_ComboBox.Items.Add("周天");
            m_ComboBox.Visibility = Visibility.Hidden;
            m_ComboBox.Name = "ComboBox_Week";
            Grid_CS.Children.Add(m_ComboBox);
            Grid_CS.RegisterName(m_ComboBox.Name, m_ComboBox);
        }

        IntegerUpDown m_IntegerUpDown = null;
        void createValueRangeTextBox()
        {
            m_IntegerUpDown = new IntegerUpDown();
            m_IntegerUpDown.HorizontalAlignment = HorizontalAlignment.Left;
            m_IntegerUpDown.VerticalAlignment = VerticalAlignment.Top;
            m_IntegerUpDown.Width = 50;
            m_IntegerUpDown.Height = 30;
            m_IntegerUpDown.SetValue(Grid.RowProperty, 1);
            m_IntegerUpDown.Margin = new Thickness(59, 10, 0, 0);
            m_IntegerUpDown.Name = "IntegerUpDown_Day";
            m_IntegerUpDown.Maximum = 31;
            m_IntegerUpDown.Minimum = 1;
            m_IntegerUpDown.Value = 1;
            m_IntegerUpDown.Visibility = Visibility.Hidden;
            Grid_CS.Children.Add(m_IntegerUpDown);
            Grid_CS.RegisterName(m_IntegerUpDown.Name, m_IntegerUpDown);
        }
        private void comboBox_ZQ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (m_IsInit && e.AddedItems.Count>0)
            {
                ComboBoxItem obj = (ComboBoxItem)e.AddedItems[0];
                string str = (string)obj.Content;
                switch (str)
                {
                    case "单次":
                        m_DatePicker.Visibility = Visibility.Visible;
                        m_ComboBox.Visibility = Visibility.Hidden;
                        m_IntegerUpDown.Visibility = Visibility.Hidden;
                        break;
                    case "每天":
                        m_DatePicker.Visibility = Visibility.Hidden;
                        m_ComboBox.Visibility = Visibility.Hidden;
                        m_IntegerUpDown.Visibility = Visibility.Hidden;
                        break;
                    case "每周":
                        m_DatePicker.Visibility = Visibility.Hidden;
                        m_ComboBox.Visibility = Visibility.Visible;
                        m_IntegerUpDown.Visibility = Visibility.Hidden;
                        break;
                    case "每月":
                        m_DatePicker.Visibility = Visibility.Hidden;
                        m_ComboBox.Visibility = Visibility.Hidden;
                        m_IntegerUpDown.Visibility = Visibility.Visible;
                        break;
                    default:
                        m_DatePicker.Visibility = Visibility.Visible;
                        m_ComboBox.Visibility = Visibility.Hidden;
                        m_IntegerUpDown.Visibility = Visibility.Hidden;
                        break;
                }
            }
            
        }

        private void button_BianJi1_Click(object sender, RoutedEventArgs e)
        {
            Button vButton = (Button)sender;
            int vZhuHao = Convert.ToInt32( vButton.Tag );
            m_EditZhuHao = vZhuHao;
            label_DS_Title.Content = string.Format("定时参数（{0}组）", vZhuHao);

            Label vLabel_DS_CZ = (Label)FindName(string.Format("label_DS_CZ{0}", m_EditZhuHao));
            TimingInfo vTimingInfo = m_TimingInfoList.Where(m => m.LuHao == m_EditZhuHao).FirstOrDefault();
            if (vTimingInfo!=null && vTimingInfo.DianYuanID != null && vTimingInfo.DianYuanID!="")
            {
                //comboBox_ZQ.Text = m_PowerMonitoring.ConvertTimingZQ(vTimingInfo.ZhouQi);
               
                DateTime vDateTime = CommHelper.TimestampToDateTime(vTimingInfo.TimeData);
                switch (vTimingInfo.ZhouQi)
                {
                    case 0:
                        comboBox_ZQ.SelectedValue = "单次";
                        m_DatePicker.DisplayDate = vDateTime;
                        break;
                    case 1:
                        comboBox_ZQ.SelectedValue = "每天";
                        break;
                    case 2:
                        byte vWeek = (byte)(vTimingInfo.TimeData >> 16);
                        m_ComboBox.Text = string.Format("周{0}", vWeek);
                        comboBox_ZQ.SelectedValue = "每周";
                        break;
                    case 3:
                        byte vDay = (byte)(vTimingInfo.TimeData >> 16);
                        m_IntegerUpDown.Value = vDay;
                        comboBox_ZQ.SelectedValue = "每月";
                        break;
                    
                }
                timePicker_Time.Value = vDateTime;
                CheckBox_ChaoZhuo.IsChecked = vTimingInfo.YunXuKZ == 0 ? false : true;
            }
        }

        private async void button_BaoChun_Click(object sender, RoutedEventArgs e)
        {
            if ( m_EditZhuHao!=-1 )
            {
                byte vLuHao = (byte)(LuHao >> 0);

                //int vZhuHaoInt = (int)vButton.Tag;
                byte vZhuHao = (byte)(m_EditZhuHao >> 0);
                byte vRenWuLeiXin = CheckBox_ChaoZhuo.IsChecked.Value?(byte)0x01:(byte)0x00;
                byte vZhouQi = (byte)m_PowerMonitoring.ConvertTimingStrToZQ(comboBox_ZQ.Text);
                byte vTimeData1=0x00, vTimeData2=0x00, vTimeData3=0x00, vTimeData4=0x00;
                int vTimeData = 0;
                switch( vZhouQi )
                {
                    //单次
                    case 0x00:
                        DateTime vDate = new DateTime(m_DatePicker.SelectedDate.Value.Year, m_DatePicker.SelectedDate.Value.Month, m_DatePicker.SelectedDate.Value.Day, timePicker_Time.Value.Value.Hour, timePicker_Time.Value.Value.Minute, timePicker_Time.Value.Value.Second);
                        vTimeData = CommHelper.DateTimeToTimestamp(vDate);
                        break;
                    //每天
                    case 0x01:
                        vTimeData3 = (byte)(timePicker_Time.Value.Value.Hour>>0);
                        vTimeData4 = (byte)(timePicker_Time.Value.Value.Minute >> 0);
                        vTimeData = BitConverter.ToInt32(new byte[] { vTimeData4,vTimeData3,vTimeData2,vTimeData1 },0);
                        break;
                    //每周
                    case 0x02:
                        switch ( m_ComboBox.Text )
                        {
                            case "周一":
                                vTimeData2 = 0x01;
                                break;
                            case "周二":
                                vTimeData2 = 0x02;
                                break;
                            case "周三":
                                vTimeData2 = 0x03;
                                break;
                            case "周四":
                                vTimeData2 = 0x04;
                                break;
                            case "周五":
                                vTimeData2 = 0x05;
                                break;
                            case "周六":
                                vTimeData2 = 0x06;
                                break;
                            case "周日":
                                vTimeData2 = 0x07;
                                break;
                        }
                        vTimeData3 = (byte)(timePicker_Time.Value.Value.Hour >> 0);
                        vTimeData4 = (byte)(timePicker_Time.Value.Value.Minute >> 0);
                        vTimeData = BitConverter.ToInt32(new byte[] { vTimeData4, vTimeData3, vTimeData2, vTimeData1 },0);
                        break;
                }
                bool vResult = await m_PowerMonitoring.SendCMD_Timing(DianYuanID, 0x01, vLuHao, vZhuHao, vRenWuLeiXin, vZhouQi, 0x01, vTimeData);
                if (vResult)
                {
                    TimingInfo vTimingInfo = m_TimingInfoList.Where(m => m.ZhuHao == m_EditZhuHao).FirstOrDefault();
                    if (vTimingInfo!=null )
                    {
                        vTimingInfo = new TimingInfo()
                        {
                            DianYuanID = DianYuanID,
                            LeiXing = 0x01,
                            RenWuLX = vRenWuLeiXin,
                            TimeData = vTimeData,
                            YunXuKZ = 0x01,
                            ZhouQi = vZhouQi,
                            ZhuHao = vZhuHao
                        };
                    }
                    else
                    {
                        vTimingInfo = new TimingInfo()
                        {
                            DianYuanID = DianYuanID,
                            LeiXing = 0x01,
                            RenWuLX = vRenWuLeiXin,
                            TimeData = vTimeData,
                            YunXuKZ = 0x01,
                            ZhouQi = vZhouQi,
                            ZhuHao = vZhuHao
                        };
                        m_TimingInfoList.Add(vTimingInfo);
                    }
                    bindTimingInfo(vTimingInfo, m_EditZhuHao);
                }
                else
                    Xceed.Wpf.Toolkit.MessageBox.Show("保存失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("请选择需要编辑定时组", "错误", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private async void button_SheZhi_XDDN_Click(object sender, RoutedEventArgs e)
        {
            //byte vLuHao = (byte)(LuHao >> 0);
            //short vData = Convert.ToInt16(integerUpDown_XDDN.Value);
            //bool vResult = await m_PowerMonitoring.SendCMD_SetSwitchParam(DianYuanID, 0x01, vLuHao, Net.DataPack.PowerDataPack_Send_SwitchParam_CommandEnum.XianDingDN,
            //    vData);
            //if (vResult)
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置成功", "信息", MessageBoxButton.OK, MessageBoxImage.Information);
            //    m_ParamInfo.XianDingDN = vData;
            //}
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置失败", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
            //    integerUpDown_XDDN.Value = m_ParamInfo.XianDingDN;
            //}
        }

        private async void button_SheZhi_XDGL_Click(object sender, RoutedEventArgs e)
        {
            //byte vLuHao = (byte)(LuHao >> 0);
            //short vData = Convert.ToInt16(integerUpDown_XDGL.Value);
            //bool vResult = await m_PowerMonitoring.SendCMD_SetSwitchParam(DianYuanID, 0x01, vLuHao, Net.DataPack.PowerDataPack_Send_SwitchParam_CommandEnum.XianDingGL, vData);
            //if (vResult)
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置成功", "信息", MessageBoxButton.OK, MessageBoxImage.Information);
            //    m_ParamInfo.XianDingGL = vData;
            //}
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置失败", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
            //    integerUpDown_XDGL.Value = m_ParamInfo.XianDingGL;
            //}
        }

        private async void button_SheZhi_DLNLZ_Click(object sender, RoutedEventArgs e)
        {
            //byte vLuHao = (byte)(LuHao >> 0);
            //short vData = Convert.ToInt16(integerUpDown_DLNLZ.Value);
            //bool vResult = await m_PowerMonitoring.SendCMD_SetSwitchParam(DianYuanID, 0x01, vLuHao, Net.DataPack.PowerDataPack_Send_SwitchParam_CommandEnum.DianLiuLLZ, vData);
            //if (vResult)
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置成功", "信息", MessageBoxButton.OK, MessageBoxImage.Information);
            //    m_ParamInfo.DianLiuLLZ = vData;
            //}
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置失败", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
            //    integerUpDown_DLNLZ.Value = m_ParamInfo.DianLiuLLZ;
            //}
        }

        private async void button_SheZhi_CWBH_Click(object sender, RoutedEventArgs e)
        {
            //byte vLuHao = (byte)(LuHao >> 0);
            //short vData = Convert.ToInt16(integerUpDown_CWBH.Value);
            //bool vResult = await m_PowerMonitoring.SendCMD_SetSwitchParam(DianYuanID, 0x01, vLuHao, Net.DataPack.PowerDataPack_Send_SwitchParam_CommandEnum.ChaoWenBHZ, vData);
            //if (vResult)
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置成功", "信息", MessageBoxButton.OK, MessageBoxImage.Information);
            //    m_ParamInfo.ChaoWenBHZ = vData;
            //}
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置失败", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
            //    integerUpDown_CWBH.Value = m_ParamInfo.ChaoWenBHZ;
            //}
        }

        private async void button_SheZhi_CWYJZ_Click(object sender, RoutedEventArgs e)
        {
            //byte vLuHao = (byte)(LuHao >> 0);
            //short vData = Convert.ToInt16(integerUpDown_CWYJZ.Value);
            //bool vResult = await m_PowerMonitoring.SendCMD_SetSwitchParam(DianYuanID, 0x01, vLuHao, Net.DataPack.PowerDataPack_Send_SwitchParam_CommandEnum.ChaoWenYJZ, vData);
            //if (vResult)
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置成功", "信息", MessageBoxButton.OK, MessageBoxImage.Information);
            //    m_ParamInfo.ChaoWenYJZ = vData;
            //}
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置失败", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
            //    integerUpDown_CWYJZ.Value = m_ParamInfo.ChaoWenYJZ;
            //}
        }

        private async void button_SheZhi_GYSX_Click(object sender, RoutedEventArgs e)
        {
            //byte vLuHao = (byte)(LuHao >> 0);
            //short vData = Convert.ToInt16(integerUpDown_GYSX.Value);
            //bool vResult = await m_PowerMonitoring.SendCMD_SetSwitchParam(DianYuanID, 0x01, vLuHao, Net.DataPack.PowerDataPack_Send_SwitchParam_CommandEnum.GuoYaSX, vData);
            //if (vResult)
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置成功", "信息", MessageBoxButton.OK, MessageBoxImage.Information);
            //    m_ParamInfo.GuoYaSX = vData;
            //}
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置失败", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
            //    integerUpDown_GYSX.Value = m_ParamInfo.GuoYaSX;
            //}
        }

        private async void button_SheZhi_QYXX_Click(object sender, RoutedEventArgs e)
        {
            //byte vLuHao = (byte)(LuHao >> 0);
            //short vData = Convert.ToInt16(integerUpDown_QYXX.Value);
            //bool vResult = await m_PowerMonitoring.SendCMD_SetSwitchParam(DianYuanID, 0x01, vLuHao, Net.DataPack.PowerDataPack_Send_SwitchParam_CommandEnum.QianYaXX, vData);
            //if (vResult)
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置成功", "信息", MessageBoxButton.OK, MessageBoxImage.Information);
            //    m_ParamInfo.QianYaXX = vData;
            //}
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置失败", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
            //    integerUpDown_QYXX.Value = m_ParamInfo.QianYaXX;
            //}
        }

        private async void button_SheZhi_EDLD_Click(object sender, RoutedEventArgs e)
        {
            //byte vLuHao = (byte)(LuHao >> 0);
            //short vData = Convert.ToInt16(integerUpDown_EDLD.Value);
            //bool vResult = await m_PowerMonitoring.SendCMD_SetSwitchParam(DianYuanID, 0x01, vLuHao, Net.DataPack.PowerDataPack_Send_SwitchParam_CommandEnum.EDingLDDZDL, vData);
            //if (vResult)
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置成功", "信息", MessageBoxButton.OK, MessageBoxImage.Information);
            //    m_ParamInfo.EDingLDDZDL = vData;
            //}
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置失败", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
            //    integerUpDown_EDLD.Value = m_ParamInfo.EDingLDDZDL;
            //}
        }

        private async void button_SheZhi_LDYJZ_Click(object sender, RoutedEventArgs e)
        {
            //byte vLuHao = (byte)(LuHao >> 0);
            //short vData = Convert.ToInt16(integerUpDown_LDYJZ.Value);
            //bool vResult = await m_PowerMonitoring.SendCMD_SetSwitchParam(DianYuanID, 0x01, vLuHao, Net.DataPack.PowerDataPack_Send_SwitchParam_CommandEnum.EDingLDDZDL, vData);
            //if (vResult)
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置成功", "信息", MessageBoxButton.OK, MessageBoxImage.Information);
            //    m_ParamInfo.LouDianLYJZ = vData;
            //}
            //else
            //{
            //    Xceed.Wpf.Toolkit.MessageBox.Show("设置失败", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
            //    integerUpDown_LDYJZ.Value = m_ParamInfo.LouDianLYJZ;
            //}
        }

        private void image_Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch { }
        }

        private void button_RZ_ZCL_Click(object sender, RoutedEventArgs e)
        {
            LogInfo[] vLogInfoArray = m_PowerMonitoring.GetLog(DianYuanID, LuHao, "操作类");
            dataGrid_Log.ItemsSource = vLogInfoArray;
        }

        private void button_RZ_BJL_Click(object sender, RoutedEventArgs e)
        {
            LogInfo[] vLogInfoArray = m_PowerMonitoring.GetLog(DianYuanID, LuHao, "报警类");
            dataGrid_Log.ItemsSource = vLogInfoArray;
        }

        private void button_RZ_GZL_Click(object sender, RoutedEventArgs e)
        {
            LogInfo[] vLogInfoArray = m_PowerMonitoring.GetLog(DianYuanID, LuHao, "故障类");
            dataGrid_Log.ItemsSource = vLogInfoArray;
        }

        private void button_RZ_DC_Click(object sender, RoutedEventArgs e)
        {
            LogInfo[] vDataSource= (LogInfo[])dataGrid_Log.ItemsSource;
            if ( vDataSource != null && vDataSource.Length>0 )
            {
                SaveFileDialog vSaveFileDialog = new SaveFileDialog();
                vSaveFileDialog.Filter = " Excel文件|*.csv ";
                if ( vSaveFileDialog.ShowDialog().Value )
                {
                    ExportDataGridToCSV(vDataSource, vSaveFileDialog.FileName);
                }
            }
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("没有可以导出的日志数据", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="logInfo"></param>
        /// <param name="filePath"></param>
        void ExportDataGridToCSV(LogInfo[] logInfo ,string filePath)
        {
            FileStream vFile = new FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter vStreamWriter = new StreamWriter(vFile, new System.Text.UnicodeEncoding());
            
            vStreamWriter.Write("事件类型\t");
            vStreamWriter.Write("事件内容\t");
            vStreamWriter.Write("时间\t");
            vStreamWriter.WriteLine("");
            //Table body
            for (int i = 0; i < logInfo.Length; i++)
            {
                vStreamWriter.Write(logInfo[i].ShiJianLX+"\t");
                vStreamWriter.Write(logInfo[i].NeiRong + "\t");
                vStreamWriter.Write(logInfo[i].Time.ToString("yyyy-MM-dd HH:mm:ss" + "\t") );
                vStreamWriter.WriteLine("");
            }
            vStreamWriter.Flush();
            vStreamWriter.Close();
        }

        private async void button_SZ_HuoQu_Click(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_PowerMonitoring.SendCMD_GetSwitchParam(DianYuanID, 0x01, m_LuHao);
            if (vResult)
            {
                init_SheZhi();
                Xceed.Wpf.Toolkit.MessageBox.Show("刷新配电参数成功", "信息", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("刷新配电参数失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private async void button_SZ_SheZhi_Click(object sender, RoutedEventArgs e)
        {
            short vXianDingDN = (short)integerUpDown_XDDN.Value;
            short vXianDingGL = (short)integerUpDown_XDGL.Value;
            short vDianLiuLLZ = (short)integerUpDown_DLNLZ.Value;
            UInt16 vChaoWenBHZ = (UInt16)integerUpDown_CWBH.Value;
            UInt16 vChaoWenYJZ =  (UInt16)integerUpDown_CWYJZ.Value;
            short vGuoYaSX =  (short)integerUpDown_GYSX.Value;
            short vQianYaXX = (short)integerUpDown_QYXX.Value;
            short vEDingLDDZDL = (short)integerUpDown_EDLD.Value;
            short vLouDianLYJZ = (short)integerUpDown_LDYJZ.Value;

            bool vResult = await m_PowerMonitoring.SendCMD_SetSwitchParam(DianYuanID, 0x01, m_LuHao, vXianDingDN, vXianDingGL, vDianLiuLLZ, vChaoWenBHZ, vChaoWenYJZ,
                vGuoYaSX, vQianYaXX, vEDingLDDZDL, vLouDianLYJZ);
            if ( vResult )
            {
                m_ParamInfo.XianDingDN = (short)integerUpDown_XDDN.Value;
                m_ParamInfo.XianDingGL = (short)integerUpDown_XDGL.Value;
                m_ParamInfo.DianLiuLLZ = (short)integerUpDown_DLNLZ.Value;
                m_ParamInfo.ChaoWenBHZ = (UInt16)integerUpDown_CWBH.Value;
                m_ParamInfo.ChaoWenYJZ = (UInt16)integerUpDown_CWYJZ.Value;
                m_ParamInfo.GuoYaSX = (short)integerUpDown_GYSX.Value;
                m_ParamInfo.QianYaXX= (short)integerUpDown_QYXX.Value;
                m_ParamInfo.EDingLDDZDL = (short)integerUpDown_EDLD.Value;
                m_ParamInfo.LouDianLYJZ = (short)integerUpDown_LDYJZ.Value;
                Xceed.Wpf.Toolkit.MessageBox.Show("设置配电参数成功", "信息", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                integerUpDown_XDDN.Value = m_ParamInfo.XianDingDN;
                integerUpDown_XDGL.Value = m_ParamInfo.XianDingGL;
                integerUpDown_DLNLZ.Value = m_ParamInfo.DianLiuLLZ;
                integerUpDown_CWBH.Value = m_ParamInfo.ChaoWenBHZ;
                integerUpDown_CWYJZ.Value = m_ParamInfo.ChaoWenYJZ;
                integerUpDown_GYSX.Value = m_ParamInfo.GuoYaSX;
                integerUpDown_QYXX.Value = m_ParamInfo.QianYaXX;
                integerUpDown_EDLD.Value = m_ParamInfo.EDingLDDZDL;
                integerUpDown_LDYJZ.Value = m_ParamInfo.LouDianLYJZ;
                Xceed.Wpf.Toolkit.MessageBox.Show("设置配电参数操作失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
