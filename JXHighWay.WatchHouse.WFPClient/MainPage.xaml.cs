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
using System.Threading;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// MainPage.xaml 的交互逻辑
    /// </summary>
    public partial class MainPage : Page
    {
        public MainWindow ParentWindow { get; set; }
        
        public MainPage()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }
            // Change the page of the frame.
            if (pageFrame != null)
            {
                Image vImage = (Image)sender;
                Window vWin = Window.GetWindow(this);
                string[] vTagInfo = ((string)vImage.Tag).Split('&');
                if (vTagInfo.Length == 2)
                {
                    int vWatchHouseID ;
                    if (int.TryParse(vTagInfo[0], out vWatchHouseID))
                    {
                        App.WatchHouseID = vWatchHouseID;
                        App.WatchHouseName = vTagInfo[1];
                        pageFrame.Source = new Uri("GanTingMingXi.xaml", UriKind.Relative);
                        App.ChangeNavigation(2, vWin, App.WatchHouseName);
                    }
                    else
                    {
                        MessageBox.Show("岗亭ID转换错误", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("岗亭信息错误", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Image_WH1.MouseLeftButtonDown += Image_MouseLeftButtonDown;
            Image_WH2.MouseLeftButtonDown += Image_MouseLeftButtonDown;
            Image_WH3.MouseLeftButtonDown += Image_MouseLeftButtonDown;
            Image_WH4.MouseLeftButtonDown += Image_MouseLeftButtonDown;
            Image_WH5.MouseLeftButtonDown += Image_MouseLeftButtonDown;
            Image_WH6.MouseLeftButtonDown += Image_MouseLeftButtonDown;
            Image_WH7.MouseLeftButtonDown += Image_MouseLeftButtonDown;
            Image_WH8.MouseLeftButtonDown += Image_MouseLeftButtonDown;

            Label_Title.Content = App.TollStationName;

            m_Monitoring = new WatchHouseMonitoring();
            RefreshState();
        }
        WatchHouseMonitoring m_Monitoring = null;
        async void RefreshState()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    
                    Action action1 = () =>
                    {

                        initWatchHouse();
                    };
                    this.Dispatcher.BeginInvoke(action1);
                    Thread.Sleep(App.RefreshTime * 1000);
                }
            });
        }

        void initWatchHouse()
        {
            //初始化岗亭信息
            WatchHouseMonitoring vMonitoring = new WatchHouseMonitoring();
            List<WatchHouseInfo> WatchHouseInfoList = vMonitoring.GetAllWatchHouseInfo();
            for (int i = 0; i <= 7; i++)
            {
                if (i < WatchHouseInfoList.Count)
                {
                    Image vImage = (Image)FindName(string.Format("Image_WH{0}", i + 1));
                    if (WatchHouseInfoList[i].IsOnline)
                    {
                        
                        if (WatchHouseInfoList[i].LeiXin == "入口")
                            vImage.Source = new BitmapImage(new Uri(@"Images/Main/Ru.jpg", UriKind.Relative));
                        else
                            vImage.Source = new BitmapImage(new Uri(@"Images/Main/Chu.jpg", UriKind.Relative));
                    }
                    else
                    {
                        if (WatchHouseInfoList[i].LeiXin == "入口")
                            vImage.Source = new BitmapImage(new Uri(@"Images/Main/Ru_L.jpg", UriKind.Relative));
                        else
                            vImage.Source = new BitmapImage(new Uri(@"Images/Main/Chu_L.jpg", UriKind.Relative));
                    }
                    Label vLabelName = (Label)FindName(string.Format("Label_Name_WH{0}", i + 1));
                    vLabelName.Content = WatchHouseInfoList[i].GangTingMC;
                    vImage.Tag = string.Format("{0}&{1}", WatchHouseInfoList[i].GangTingID, WatchHouseInfoList[i].GangTingMC);

                    Label vLabelJob = (Label)FindName(string.Format("Label_JobNo_{0}", i + 1));
                    vLabelJob.Content = WatchHouseInfoList[i].GongHao;
                }
                else
                {
                    Image vImage = (Image)FindName(string.Format("Image_WH{0}", i + 1));
                    vImage.Visibility = Visibility.Hidden;

                    Label vLabelName = (Label)FindName(string.Format("Label_Name_WH{0}", i + 1));
                    vLabelName.Visibility = Visibility.Hidden;

                    Label vLabelJob = (Label)FindName(string.Format("Label_JobNo_{0}", i + 1));
                    vLabelJob.Visibility = Visibility.Hidden;
                }
            }
        }

        void setWathHouse( int index ,int watchHouseID,string watchHouseName,string jobNo)
        {
            switch( index)
            {
                case 0:
                    
                    break;
            }
        }
    }
}
