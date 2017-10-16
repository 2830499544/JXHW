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
using JXHighWay.WatchHouse.Net;
using System.Threading;
using JXHighWay.WatchHouse.Bll.Client.GanTing;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// DengGuang.xaml 的交互逻辑
    /// </summary>
    public partial class DengGuang : Page
    {
        public DengGuang()
        {
            InitializeComponent();
        }

        private async void image_25_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, WatchHouseDataPack_Send_CommandEnmu.SheZhiLD,0x19);
            if (vResult)
                luminance25();
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("调节亮度失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        void luminance25()
        {
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25_A.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100.jpg", UriKind.Relative));
            Label_LD.Content = "25%";
        }

        private async void image_50_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, WatchHouseDataPack_Send_CommandEnmu.SheZhiLD, 0x32);
            if (vResult)
                luminance50();
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("调节亮度失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        
        void luminance50()
        {
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50_A.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100.jpg", UriKind.Relative));
            Label_LD.Content = "50%";
        }

        private async void image_75_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, WatchHouseDataPack_Send_CommandEnmu.SheZhiLD, 0x4b);
            if (vResult)
                luminance75();
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("调节亮度失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        void luminance75()
        {
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75_A.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100.jpg", UriKind.Relative));
            Label_LD.Content = "75%";
        }

        private async void image_100_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, WatchHouseDataPack_Send_CommandEnmu.SheZhiLD, 0x64);
            if (vResult)
                luminance100();
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("调节亮度失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        void luminance100()
        {
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100_A.jpg", UriKind.Relative));
            Label_LD.Content = "100%";
        }

        void luminance0()
        {
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100.jpg", UriKind.Relative));
        }

        WatchHouseMonitoring m_Monitoring = null;
        bool m_IsInit = false;
        void init()
        {
            m_Monitoring = new WatchHouseMonitoring();
            RefreshState();
        }


        async void RefreshState()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    
                    Action action1 = () =>
                    {
                        DengGuanStateInfo vState = m_Monitoring.DuangGuanState(App.WatchHouseID);
                        CheckBox_Switch.IsChecked = vState.IsOpen;
                        Label_LD.Content = string.Format("{0}%", vState.LianDu);
                        switch( vState.LianDu )
                        {
                            case 25:
                                luminance25();
                                break;
                            case 50:
                                luminance50();
                                break;
                            case 75:
                                luminance75();
                                break;
                            case 100:
                                luminance100();
                                break;
                            default:
                                luminance0();
                                break;
                        }
                        changeSwitchColor();
                        m_IsInit = true;
                    };
                    Dispatcher.BeginInvoke(action1);
                    Thread.Sleep(App.RefreshTime*1000);
                }
            });
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }

        bool m_Switch = true;
        private async void CheckBox_Switch_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch)
            {
                CheckBox_Switch.IsEnabled = false;
                m_Switch = false;
                bool vOldValue = !(CheckBox_Switch.IsChecked ?? false);
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, WatchHouseDataPack_Send_CommandEnmu.GuanDeng);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, WatchHouseDataPack_Send_CommandEnmu.KaiDeng);
                if (!vResult)
                {
                    CheckBox_Switch.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("灯光开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor();
                CheckBox_Switch.IsEnabled = true;
                m_Switch = true;
            }
        }

        void changeSwitchColor()
        {
            if (CheckBox_Switch.IsChecked ?? false)
            {
                label_GuanDeng.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_KaiDeng.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_GuanDeng.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_KaiDeng.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }
    }
}
