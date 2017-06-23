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
                pageFrame.Source = new Uri("GanTingMingXi.xaml", UriKind.Relative);
                Image vImage = (Image)sender;
                Window vWin = Window.GetWindow(this);
                App.ChangeNavigation(2,vWin, (string)vImage.Tag);
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

            Monitoring vMonitoring = new Monitoring();
            List<WatchHouseInfoModel> WatchHouseInfoList = vMonitoring.GetAllWatchHouseInfo();
            for(int i=0;i<=7;i++)
            {
                if (i<WatchHouseInfoList.Count)
                {
                    Image vImage = (Image)FindName(string.Format("Image_WH{0}",i+1));
                    if (WatchHouseInfoList[i].LeiXin=="入口")
                        vImage.Source = new BitmapImage(new Uri(@"Images/Main/Ru.jpg", UriKind.Relative));
                    else
                        vImage.Source = new BitmapImage(new Uri(@"Images/Main/Chu.jpg", UriKind.Relative));
                    vImage.Tag = WatchHouseInfoList[i].GangTingMC;

                    Label vLabelName = (Label)FindName(string.Format("Label_Name_WH{0}", i + 1));
                    vLabelName.Content = WatchHouseInfoList[i].GangTingMC;

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

        private void Image_WH1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
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
