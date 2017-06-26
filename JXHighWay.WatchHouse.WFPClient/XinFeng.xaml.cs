using JXHighWay.WatchHouse.Bll.Client;
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
            xinfengFL_1J();
        }

        void xinfengFL_1J()
        {
            image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j_a.jpg", UriKind.Relative));
            image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j.jpg", UriKind.Relative));
            image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j.jpg", UriKind.Relative));
            image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j.jpg", UriKind.Relative));
            image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j.jpg", UriKind.Relative));
        }

        private void image_FL_2J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            xinFengFL_2J();
        }

        void xinFengFL_2J()
        {
            image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j.jpg", UriKind.Relative));
            image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j_a.jpg", UriKind.Relative));
            image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j.jpg", UriKind.Relative));
            image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j.jpg", UriKind.Relative));
            image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j.jpg", UriKind.Relative));
        }

        private void image_FL_3J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            xinFengFL_3J();
        }

        void xinFengFL_3J()
        {
            image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j.jpg", UriKind.Relative));
            image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j.jpg", UriKind.Relative));
            image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j_a.jpg", UriKind.Relative));
            image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j.jpg", UriKind.Relative));
            image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j.jpg", UriKind.Relative));
        }

        private void image_FL_4J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            xinFengFL_4J();
        }

        void xinFengFL_4J()
        {
            image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j.jpg", UriKind.Relative));
            image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j.jpg", UriKind.Relative));
            image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j.jpg", UriKind.Relative));
            image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j_a.jpg", UriKind.Relative));
            image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j.jpg", UriKind.Relative));
        }

        private void image_FL_5J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            xinFengFL_5J();
        }

        void xinFengFL_5J()
        {
            image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j.jpg", UriKind.Relative));
            image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j.jpg", UriKind.Relative));
            image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j.jpg", UriKind.Relative));
            image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j.jpg", UriKind.Relative));
            image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j_a.jpg", UriKind.Relative));
        }

        WatchHouseMonitoring m_Monitoring = null;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            m_Monitoring = new WatchHouseMonitoring();
            RefreshState();
        }

        void initXinFeng()
        {
            XinFengStateModel vXinFengStateModel =  m_Monitoring.XinFengState(App.WatchHouseID);
            CheckBox_XinFeng.IsChecked = vXinFengStateModel.IsOpen;
            Label_DengJi.Content = string.Format("{0}级",vXinFengStateModel.DengJi);
            Label_WenDu.Content = vXinFengStateModel.WenDu.ToString();
            Label_ShiDu.Content = vXinFengStateModel.ShiDu.ToString();
            Label_APM_RK.Content = vXinFengStateModel.RuKouAPM.ToString();
            Label_APM_CK.Content = vXinFengStateModel.ChuKouAPM.ToString();
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
    }
}
