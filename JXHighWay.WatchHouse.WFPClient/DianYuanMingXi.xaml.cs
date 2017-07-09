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
using System.Windows.Controls.DataVisualization.Charting;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// DianYuanMingXi.xaml 的交互逻辑
    /// </summary>
    public partial class DianYuanMingXi : Window
    {
        /// <summary>
        /// 路号
        /// </summary>
        public int LuHao { get; set; }

        PowerMonitoring m_PowerMonitoring { get; set; }
        public DianYuanMingXi()
        {
            InitializeComponent();
        }

        bool m_IsInit = false;
        void init()
        {
            m_IsInit = false;
            m_PowerMonitoring = new PowerMonitoring();
            init_ZhuanTai();
            init_DingShi();
            m_IsInit = true;
        }

        /// <summary>
        /// 初始化状态
        /// </summary>
        void init_ZhuanTai()
        {
            PowerInfo vPowerInfo = m_PowerMonitoring.GetNewPowerInfo(App.PowerID, LuHao);
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

        /// <summary>
        /// 初始化定时
        /// </summary>
        void init_DingShi()
        {
            createComboBox();
            createDatePicker();
            createValueRangeTextBox();
            timePicker_Time.Value = DateTime.Now;
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
            PowerInfo[] vDataSource = m_PowerMonitoring.GetYongDianLiang_Ri(App.PowerID, LuHao);
            yongDianTongJi(vDataSource, string.Format("日用电量统计(总计:{0}kwh)", vDataSource.Sum(m => m.DianNeng)));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }

        private void button_YD_YYD_Click(object sender, RoutedEventArgs e)
        {
            PowerInfo[] vDataSource = m_PowerMonitoring.GetYongDianLiang_Yue(App.PowerID, LuHao);
            yongDianTongJi(vDataSource, string.Format("月用电量统计(总计:{0}kwh)", vDataSource.Sum(m => m.DianNeng)));
        }

        private void button_YD_NYD_Click(object sender, RoutedEventArgs e)
        {
            PowerInfo[] vDataSource = m_PowerMonitoring.GetYongDianLiang_Nian(App.PowerID, LuHao);
            yongDianTongJi(vDataSource, string.Format("年用电量统计(总计:{0}kwh)", vDataSource.Sum(m => m.DianNeng)));
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("OK");
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
            if (m_IsInit)
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
    }
}
