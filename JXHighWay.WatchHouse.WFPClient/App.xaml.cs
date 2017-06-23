using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 当前岗亭ID
        /// </summary>
        public static int WatchHouseID { get; set; }
        /// <summary>
        /// 一级导航名称
        /// </summary>
        public string Navigation1_Name { get; set; }
        /// <summary>
        /// 二级导航名称
        /// </summary>
        public string Navigation2_Name { get; set; }
        /// <summary>
        /// 三级导航名称
        /// </summary>
        public string Navigation3_Name { get; set; }

        public static void ChangeNavigation( int Level,Window Win,string Title)
        {
            //更改导航

            Label vLabel_Navigation1 = (Label)Win.FindName("Label_Navigation1");
            Image vImage_Navigation1 = (Image)Win.FindName("Image_Navigation1");

            Label vLabel_Navigation2 = (Label)Win.FindName("Label_Navigation2");
            Image vImage_Navigation2 = (Image)Win.FindName("Image_Navigation2");

            Label vLabel_Navigation3 = (Label)Win.FindName("Label_Navigation3");
            Image vImage_Navigation3 = (Image)Win.FindName("Image_Navigation3");

            switch ( Level)
            {
                case 1:
                    vLabel_Navigation1.Content = "主界面";
                    vImage_Navigation1.Visibility = Visibility.Hidden;

                    vLabel_Navigation2.Visibility = Visibility.Hidden;
                    vImage_Navigation2.Visibility = Visibility.Hidden;

                    vLabel_Navigation3.Visibility = Visibility.Hidden;
                    vImage_Navigation3.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    
                    vImage_Navigation1.Visibility = Visibility.Visible;

                    vLabel_Navigation2.Content = Title;
                    vLabel_Navigation2.Visibility = Visibility.Visible;
                    vImage_Navigation2.Visibility = Visibility.Hidden;

                    vLabel_Navigation3.Visibility = Visibility.Hidden;
                    vImage_Navigation3.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    vImage_Navigation1.Visibility = Visibility.Visible;

                    vLabel_Navigation2.Visibility = Visibility.Visible;
                    vImage_Navigation2.Visibility = Visibility.Visible;

                    vLabel_Navigation3.Content = Title;
                    vLabel_Navigation3.Visibility = Visibility.Visible;
                    vImage_Navigation3.Visibility = Visibility.Visible;
                    break;
            }
            
        }
    }
}
