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

        private void image_25_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            luminance25();
        }

        void luminance25()
        {
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25_A.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100.jpg", UriKind.Relative));
        }

        private void image_50_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            luminance50();
        }
        
        void luminance50()
        {
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50_A.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100.jpg", UriKind.Relative));
        }

        private void image_75_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            luminance75();
        }

        void luminance75()
        {
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75_A.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100.jpg", UriKind.Relative));
        }

        private void image_100_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            luminance100();
        }

        void luminance100()
        {
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100_A.jpg", UriKind.Relative));
        }

        void luminance0()
        {
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100.jpg", UriKind.Relative));
        }

        WatchHouseMonitoring m_Monitoring = null;
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
                        DengGuanStateModel vState = m_Monitoring.DuangGuanState(App.WatchHouseID);
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

        private void CheckBox_Switch_Checked(object sender, RoutedEventArgs e)
        {

            Action action1 = async () =>
            {
                bool vResult;
                if (CheckBox_Switch.IsChecked.Value)
                {
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, WatchHouseDataPack_Send_CommandEnmu.KaiDeng);
                }
                else
                {
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, WatchHouseDataPack_Send_CommandEnmu.GuanDeng);
                }

                if (!vResult)
                    CheckBox_Switch.IsChecked = !CheckBox_Switch.IsChecked;
                
            };
            Dispatcher.BeginInvoke(action1);

        }
    }
}
