using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using JXHighWay.WatchHouse.Bll.Client;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Config vConfig = new Config();
            DBSource = vConfig.DBSource;
            DBName = vConfig.DBName;
            DBPort = vConfig.DBPort;
            DBUserName = vConfig.DBUserName;
            DBPassword = vConfig.DBPassword;
            RefreshTime = vConfig.RefreshTime;
            OfflineTime = vConfig.OfflineTime;
            TollStationName = vConfig.TollStationName;
        }

        public static string TollStationName { get; set; }

        /// <summary>
        /// 数据库地址
        /// </summary>
        public static string DBSource { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public static string DBName { get; set; }
        /// <summary>
        /// 数据库端口
        /// </summary>
        public static int DBPort { get; set; }
        /// <summary>
        /// 数据库用户名
        /// </summary>
        public static string DBUserName { get; set; }
        /// <summary>
        /// 数据库密码
        /// </summary>
        public static string DBPassword { get; set; }
        /// <summary>
        /// 刷新时间
        /// </summary>
        public static int RefreshTime { get; set; }
        /// <summary>
        /// 离线时间
        /// </summary>
        public static int OfflineTime { get; set; }

        /// <summary>
        /// 当前岗亭ID
        /// </summary>
        public static int WatchHouseID { get; set; }
        /// <summary>
        /// 当前岗亭名称
        /// </summary>
        public static string WatchHouseName { get; set; }
        /// <summary>
        /// 岗亭类型
        /// </summary>
        public static string WatchHouseType { get; set; }
        /// <summary>
        /// 当前电源ID(单向)
        /// </summary>
        public static string PowerID1 { get; set; }
        /// <summary>
        /// 当前电源ID(双向)
        /// </summary>
        public static string PowerID2 { get; set; }
        /// <summary>
        /// 广告屏IP
        /// </summary>
        public static string LEDIP { get; set; }

        /// <summary>
        /// 当前登陆管理员
        /// </summary>
        public static string AdminUser { get; set; }
        /// <summary>
        /// 岗亭权限
        /// </summary>
        public static bool Power_GangTing { get; set; }
        /// <summary>
        /// 电源权限
        /// </summary>
        public static bool Power_DianYuan { get; set; }
        /// <summary>
        /// LED控制权限
        /// </summary>
        public static bool Power_LED { get; set; }

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

            Label vLabel_Title = (Label)Win.FindName("Label_Title");
            Image vImage_Logo = (Image)Win.FindName("Image_Logo");

            Label vLabel_Navigation1 = (Label)Win.FindName("Label_Navigation1");
            Image vImage_Navigation1 = (Image)Win.FindName("Image_Navigation1");

            Label vLabel_Navigation2 = (Label)Win.FindName("Label_Navigation2");
            Image vImage_Navigation2 = (Image)Win.FindName("Image_Navigation2");

            Label vLabel_Navigation3 = (Label)Win.FindName("Label_Navigation3");
            Image vImage_Navigation3 = (Image)Win.FindName("Image_Navigation3");

            Image vImage_DengGuan = (Image)Win.FindName("image_DengGuan");
            Image vImage_ZhiDongMC = (Image)Win.FindName("image_ZhiDongMC");
            Image vImage_DianYuan = (Image)Win.FindName("image_DianYuan");
            Image vImage_LED = (Image)Win.FindName("image_LED");
            Image vImage_XinFeng = (Image)Win.FindName("image_XinFeng");
            Image vImage_KongTiao = (Image)Win.FindName("image_KongTiao");
            Image vImage_DiNuan = (Image)Win.FindName("image_DiNuan");
            Image vImage_GongHao = (Image)Win.FindName("image_GongHao");
            

            switch ( Level)
            {
                case 0:
                    vLabel_Title.Visibility = Visibility.Hidden;
                    vImage_Logo.Visibility = Visibility.Hidden;

                    vLabel_Navigation1.Content = "主界面";
                    vLabel_Navigation1.Visibility = Visibility.Hidden;
                    vImage_Navigation1.Visibility = Visibility.Hidden;

                    vLabel_Navigation2.Visibility = Visibility.Hidden;
                    vImage_Navigation2.Visibility = Visibility.Hidden;

                    vLabel_Navigation3.Visibility = Visibility.Hidden;
                    vImage_Navigation3.Visibility = Visibility.Hidden;

                    vImage_DengGuan.Visibility = Visibility.Hidden;
                    vImage_ZhiDongMC.Visibility = Visibility.Hidden;
                    vImage_DianYuan.Visibility = Visibility.Hidden;
                    vImage_LED.Visibility = Visibility.Hidden;
                    vImage_XinFeng.Visibility = Visibility.Hidden;
                    vImage_KongTiao.Visibility = Visibility.Hidden;
                    vImage_DiNuan.Visibility = Visibility.Hidden;
                    vImage_GongHao.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    vLabel_Title.Visibility = Visibility.Visible;
                    vImage_Logo.Visibility = Visibility.Visible;

                    vLabel_Navigation1.Content = "主界面";
                    vLabel_Navigation1.Visibility = Visibility.Hidden;
                    vImage_Navigation1.Visibility = Visibility.Hidden;

                    vLabel_Navigation2.Visibility = Visibility.Hidden;
                    vImage_Navigation2.Visibility = Visibility.Hidden;

                    vLabel_Navigation3.Visibility = Visibility.Hidden;
                    vImage_Navigation3.Visibility = Visibility.Hidden;

                    vImage_DengGuan.Visibility = Visibility.Hidden;
                    vImage_ZhiDongMC.Visibility = Visibility.Hidden;
                    vImage_DianYuan.Visibility = Visibility.Hidden;
                    vImage_LED.Visibility = Visibility.Hidden;
                    vImage_XinFeng.Visibility = Visibility.Hidden;
                    vImage_KongTiao.Visibility = Visibility.Hidden;
                    vImage_DiNuan.Visibility = Visibility.Hidden;
                    vImage_GongHao.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    vLabel_Title.Visibility = Visibility.Visible;
                    vImage_Logo.Visibility = Visibility.Visible;

                    vLabel_Navigation1.Visibility = Visibility.Visible;
                    vImage_Navigation1.Visibility = Visibility.Visible;

                    vLabel_Navigation2.Content = Title;
                    vLabel_Navigation2.Visibility = Visibility.Visible;
                    vImage_Navigation2.Visibility = Visibility.Hidden;

                    vLabel_Navigation3.Visibility = Visibility.Hidden;
                    vImage_Navigation3.Visibility = Visibility.Hidden;

                    vImage_DengGuan.Visibility = Visibility.Visible;
                    vImage_ZhiDongMC.Visibility = Visibility.Visible;
                    vImage_DianYuan.Visibility = Visibility.Visible;
                    vImage_LED.Visibility = Visibility.Visible;
                    vImage_XinFeng.Visibility = Visibility.Visible;
                    vImage_KongTiao.Visibility = Visibility.Visible;
                    vImage_DiNuan.Visibility = Visibility.Visible;
                    vImage_GongHao.Visibility = Visibility.Visible;
                    break;
                case 3:
                    vLabel_Title.Visibility = Visibility.Visible;
                    vImage_Logo.Visibility = Visibility.Visible;

                    vLabel_Navigation1.Visibility = Visibility.Visible;
                    vImage_Navigation1.Visibility = Visibility.Visible;

                    vLabel_Navigation2.Visibility = Visibility.Visible;
                    vImage_Navigation2.Visibility = Visibility.Visible;

                    vLabel_Navigation3.Content = Title;
                    vLabel_Navigation3.Visibility = Visibility.Visible;
                    vImage_Navigation3.Visibility = Visibility.Visible;

                    vImage_DengGuan.Visibility = Visibility.Visible;
                    vImage_ZhiDongMC.Visibility = Visibility.Visible;
                    vImage_DianYuan.Visibility = Visibility.Visible;
                    vImage_LED.Visibility = Visibility.Visible;
                    vImage_XinFeng.Visibility = Visibility.Visible;
                    vImage_KongTiao.Visibility = Visibility.Visible;
                    vImage_DiNuan.Visibility = Visibility.Visible;
                    vImage_GongHao.Visibility = Visibility.Visible;
                    break;
            }
            
        }
    }
}

