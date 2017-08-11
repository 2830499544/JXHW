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
using JXHighWay.WatchHouse.Bll.Client.GanTing;

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
                if (vTagInfo.Length == 6)
                {
                    int vWatchHouseID;
                    if (int.TryParse(vTagInfo[0], out vWatchHouseID) )
                    {
                        App.WatchHouseID = vWatchHouseID;
                        App.WatchHouseName = vTagInfo[1];
                        App.WatchHouseType = vTagInfo[5];
                        App.PowerID1 = vTagInfo[2];
                        App.PowerID2 = vTagInfo[3];
                        App.LEDIP = vTagInfo[4];
                        pageFrame.Source = new Uri("GanTingMingXi.xaml", UriKind.Relative);
                        App.ChangeNavigation(2, vWin, App.WatchHouseName);
                    }
                    else
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("岗亭ID转换错误", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("岗亭信息错误", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
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
            //站点名称
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

        int m_PageIndex = 1;
        int m_Count = 0;
        void initWatchHouse()
        {
            //初始化岗亭信息
            WatchHouseMonitoring vMonitoring = new WatchHouseMonitoring();
            List<WatchHouseInfo> WatchHouseInfoList = vMonitoring.GetAllWatchHouseInfo();
            m_Count = WatchHouseInfoList.Count;
            if (WatchHouseInfoList.Count<=8)
            {
                image_ShanYei.Visibility = Visibility.Hidden;
                image_XiaYei.Visibility = Visibility.Hidden;
            }
            else
            {
                image_ShanYei.Visibility = Visibility.Visible;
                image_XiaYei.Visibility = Visibility.Visible;
            }
            int vStartIndex = (m_PageIndex * 8) - 8;
            int vEndIndex = m_PageIndex * 8;
            for (int i = vStartIndex; i < vEndIndex; i++)
            {
                if (i < WatchHouseInfoList.Count)
                {
                    Image vImage = (Image)FindName(string.Format("Image_WH{0}", i + 1-vStartIndex));
                    int vRowIndex = (int)vImage.GetValue(Grid.RowProperty);
                    int vColumnIndex = (int)vImage.GetValue(Grid.ColumnProperty);
                    vImage.Visibility = Visibility.Visible;

                    switch (WatchHouseInfoList[i].LeiXin)
                    {
                        case "入口":
                            // vImage.Source = new BitmapImage(new Uri(@"Images/Main/Ru.jpg", UriKind.Relative));
                            Style vRuStyle = (Style)this.FindResource("RuStyle");
                            vImage.Style = vRuStyle;
                            break;
                        case "出口":
                            //vImage.Source = new BitmapImage(new Uri(@"Images/Main/Chu.jpg", UriKind.Relative));
                            Style vChuStyle = (Style)this.FindResource("ChuStyle");
                            vImage.Style = vChuStyle;
                            break;
                        case "双向":
                            //vImage.Source = new BitmapImage(new Uri(@"Images/Main/ShuanXiang.jpg", UriKind.Relative));
                            Style vSuanXiangStyle = (Style)this.FindResource("SuanXiangStyle");
                            vImage.Style = vSuanXiangStyle;
                            break;
                    }


                    //在线状态
                    Image vImage_BJ = FindName(string.Format("Image_BJ{0}", i + 1-vStartIndex))==null?null: (Image)FindName(string.Format("Image_BJ{0}", i + 1-vStartIndex));
                    if (vImage_BJ==null )
                    {
                        //报警图标
                        vImage_BJ = new Image()
                        {
                            Source = new BitmapImage(new Uri(@"Images/Main/BaoJing.png", UriKind.Relative)),
                            Width = 47,
                            Height = 47,
                            Name = string.Format("Image_BJ{0}", i + 1-vStartIndex)
                        };
                        vImage_BJ.SetValue(Grid.RowProperty, vRowIndex);
                        vImage_BJ.SetValue(Grid.ColumnProperty, vColumnIndex);
                        vImage_BJ.Margin = new Thickness(144, -159, 0, 0);
                        Grid_GanTing.Children.Add(vImage_BJ);
                        Grid_GanTing.RegisterName(vImage_BJ.Name, vImage_BJ);
                    }
                    vImage_BJ.Visibility = WatchHouseInfoList[i].IsOnline ? Visibility.Hidden : Visibility.Visible;

                    Label vLabelName = (Label)FindName(string.Format("Label_Name_WH{0}", i + 1-vStartIndex));
                    vLabelName.Content = WatchHouseInfoList[i].GangTingMC;
                    vImage.Tag = string.Format("{0}&{1}&{2}&{3}&{4}&{5}", WatchHouseInfoList[i].GangTingID, WatchHouseInfoList[i].GangTingMC, WatchHouseInfoList[i].DianYuan1ID, WatchHouseInfoList[i].DianYuan2ID, WatchHouseInfoList[i].GuanGaoPing1IP, WatchHouseInfoList[i].LeiXin);
                    vLabelName.Visibility = Visibility.Visible;

                    Label vLabelJob = (Label)FindName(string.Format("Label_JobNo_{0}", i + 1-vStartIndex));
                    vLabelJob.Content = WatchHouseInfoList[i].GongHao;
                    vLabelName.Visibility = Visibility.Visible;
                }
                else
                {
                    Image vImage = (Image)FindName(string.Format("Image_WH{0}", i + 1-vStartIndex));
                    vImage.Visibility = Visibility.Hidden;

                    Label vLabelName = (Label)FindName(string.Format("Label_Name_WH{0}", i + 1-vStartIndex));
                    vLabelName.Visibility = Visibility.Hidden;

                    Label vLabelJob = (Label)FindName(string.Format("Label_JobNo_{0}", i + 1-vStartIndex));
                    vLabelJob.Visibility = Visibility.Hidden;

                    //在线状态
                    Image vImage_BJ = FindName(string.Format("Image_BJ{0}", i + 1 - vStartIndex)) == null ? null : (Image)FindName(string.Format("Image_BJ{0}", i + 1 - vStartIndex));
                    vImage_BJ.Visibility = Visibility.Hidden;
                }
            }
        }

        private void image_ShanYei_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (m_PageIndex > 1)
            {
                m_PageIndex--;
                initWatchHouse();
            }
            
        }

        private void image_XiaYei_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            double vPageCount_Double = m_Count / (double)8;
            int vPageCount_int =  (int)(m_Count / (double)8);
            int vPageCount = 0;
            if (vPageCount_Double - vPageCount_int > 0)
                vPageCount = vPageCount_int + 1;
            else
                vPageCount = vPageCount_int;
            if (m_PageIndex < vPageCount)
            {
                m_PageIndex++;
                initWatchHouse();
            }
        }
    }
}
