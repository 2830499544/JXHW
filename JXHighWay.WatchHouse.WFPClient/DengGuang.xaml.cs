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
using JXHighWay.WatchHouse.Bll.WatchHouse;

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
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25_A.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100.jpg", UriKind.Relative));
            
        }

        private void image_50_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50_A.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100.jpg", UriKind.Relative));
        }

        private void image_75_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75_A.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100.jpg", UriKind.Relative));
        }

        private void image_100_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_25.Source = new BitmapImage(new Uri(@"Images/DengGuang/25.jpg", UriKind.Relative));
            image_50.Source = new BitmapImage(new Uri(@"Images/DengGuang/50.jpg", UriKind.Relative));
            image_75.Source = new BitmapImage(new Uri(@"Images/DengGuang/75.jpg", UriKind.Relative));
            image_100.Source = new BitmapImage(new Uri(@"Images/DengGuang/100_A.jpg", UriKind.Relative));
        }

        void init()
        {
            Monitoring vMonitoring = new Monitoring();
            DengGuanStateModel vState = vMonitoring.DuangGuanState(App.WatchHouseID);
            CheckBox_Switch.IsChecked = vState.IsOpen;
            Label_LD.Content = string.Format("{0}%",vState.LianDu);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }
    }
}
