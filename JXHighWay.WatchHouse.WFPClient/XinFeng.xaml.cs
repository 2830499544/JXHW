using JXHighWay.WatchHouse.Bll.Client;
using JXHighWay.WatchHouse.Bll.Client.GanTing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// XinFeng.xaml 的交互逻辑
    /// </summary>
    public partial class XinFeng : Page
    {
        public XinFeng()
        {
            InitializeComponent();
        }

        private void image_FL_1J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (m_IsInit) 
                xinfengFL_1J();
        }

        async void xinfengFL_1J()
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.TiaoJieFL, 0x01);
            if (vResult)
            {
                image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j_a.jpg", UriKind.Relative));
                image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j.jpg", UriKind.Relative));
                image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j.jpg", UriKind.Relative));
                image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j.jpg", UriKind.Relative));
                image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j.jpg", UriKind.Relative));
                Label_DengJi.Content = "1级";
            }
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("新风风量调节失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void image_FL_2J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (m_IsInit)
                xinFengFL_2J();
        }

        async void xinFengFL_2J()
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.TiaoJieFL, 0x02);
            if (vResult)
            {
                image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j.jpg", UriKind.Relative));
                image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j_a.jpg", UriKind.Relative));
                image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j.jpg", UriKind.Relative));
                image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j.jpg", UriKind.Relative));
                image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j.jpg", UriKind.Relative));
                Label_DengJi.Content = "2级";
            }
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("新风风量调节失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void image_FL_3J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (m_IsInit)
                xinFengFL_3J();
        }

        async void xinFengFL_3J()
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.TiaoJieFL, 0x03);
            if (vResult)
            {
                image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j.jpg", UriKind.Relative));
                image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j.jpg", UriKind.Relative));
                image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j_a.jpg", UriKind.Relative));
                image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j.jpg", UriKind.Relative));
                image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j.jpg", UriKind.Relative));
                Label_DengJi.Content = "3级";
            }
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("新风风量调节失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void image_FL_4J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (m_IsInit)
                xinFengFL_4J();
        }

        async void xinFengFL_4J()
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.TiaoJieFL, 0x04);
            if (vResult)
            {
                image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j.jpg", UriKind.Relative));
                image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j.jpg", UriKind.Relative));
                image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j.jpg", UriKind.Relative));
                image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j_a.jpg", UriKind.Relative));
                image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j.jpg", UriKind.Relative));
                Label_DengJi.Content = "4级";
            }
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("新风风量调节失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void image_FL_5J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (m_IsInit)
                xinFengFL_5J();
        }

        async void xinFengFL_5J()
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.TiaoJieFL, 0x05);
            if (vResult)
            {
                image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j.jpg", UriKind.Relative));
                image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j.jpg", UriKind.Relative));
                image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j.jpg", UriKind.Relative));
                image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j.jpg", UriKind.Relative));
                image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j_a.jpg", UriKind.Relative));
                Label_DengJi.Content = "5级";
            }
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("新风风量调节失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        WatchHouseMonitoring m_Monitoring = null;
        bool m_IsInit = false;
        bool m_IsSwitch = true;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            m_Monitoring = new WatchHouseMonitoring();
            RefreshState();
        }

        void initXinFeng()
        {
            XinFengStateInfo vXinFengStateModel =  m_Monitoring.XinFengState(App.WatchHouseID);
            CheckBox_XinFeng.IsChecked = vXinFengStateModel.IsOpen;
            Label_DengJi.Content = string.Format("{0}级",vXinFengStateModel.DengJi);
            Label_WenDu.Content = vXinFengStateModel.WenDu.ToString();
            Label_ShiDu.Content = vXinFengStateModel.ShiDu.ToString();
            Label_APM_RK.Content = vXinFengStateModel.RuKouAPM.ToString();
            Label_APM_CK.Content = vXinFengStateModel.ChuKouAPM.ToString();
            m_IsInit = true;
        }

        async void RefreshState()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    Action action1 = () =>
                    {
                        initXinFeng();
                    };
                    Dispatcher.BeginInvoke(action1);
                    Thread.Sleep(App.RefreshTime * 1000);
                }
            });
        }

        private async void CheckBox_XinFeng_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_IsSwitch)
            {
                m_IsSwitch = false;
                bool vOldValue = !(CheckBox_XinFeng.IsChecked ?? false);
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanXinFeng);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiXinFeng);
                if (!vResult)
                {
                    CheckBox_XinFeng.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("新风开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor();
                m_IsSwitch = true;
            }
        }

        void changeSwitchColor()
        {
            if (CheckBox_XinFeng.IsChecked ?? false)
            {

                label_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF0190F"));
                label_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }
    }
}
