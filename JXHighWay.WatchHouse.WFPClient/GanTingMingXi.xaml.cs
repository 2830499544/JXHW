﻿using System;
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
using JXHighWay.WatchHouse.Bll.Client.GanTing;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// GanTingMingXi.xaml 的交互逻辑
    /// </summary>
    public partial class GanTingMingXi : Page
    {
        public GanTingMingXi()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            init();
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
                pageFrame.Source = new Uri("DengGuang.xaml", UriKind.Relative);

                Window vWin = Window.GetWindow(this);
                App.ChangeNavigation(3, vWin, "灯光");
            }
           
        }

        private void image_Copy4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                pageFrame.Source = new Uri("KongTiao.xaml", UriKind.Relative);

                Window vWin = Window.GetWindow(this);
                App.ChangeNavigation(3, vWin, "空调");
            }
        }

        private void image_Copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                if ( App.WatchHouseType == "双向")
                    pageFrame.Source = new Uri("MenChuang_S.xaml", UriKind.Relative);
                else
                    pageFrame.Source = new Uri("MenChuang.xaml", UriKind.Relative);

                Window vWin = Window.GetWindow(this);
                App.ChangeNavigation(3, vWin, "自动门窗");
            }
        }

        private void image_Copy3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                pageFrame.Source = new Uri("XinFeng.xaml", UriKind.Relative);

                Window vWin = Window.GetWindow(this);
                App.ChangeNavigation(3, vWin, "新风");
            }
        }

        private void image_Copy5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                pageFrame.Source = new Uri("DiNuan.xaml", UriKind.Relative);

                Window vWin = Window.GetWindow(this);
                App.ChangeNavigation(3, vWin, "地暖");
            }
        }

        private void Image_LED_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                pageFrame.Source = new Uri("LED.xaml", UriKind.Relative);

                Window vWin = Window.GetWindow(this);
                App.ChangeNavigation(3, vWin, "LED显示屏");
            }
        }

        private void Image_DianYuan_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                if (App.WatchHouseType == "双向")
                    pageFrame.Source = new Uri("DianYuan_S.xaml", UriKind.Relative);
                else
                    pageFrame.Source = new Uri("DianYuan.xaml", UriKind.Relative);
                Window vWin = Window.GetWindow(this);
                App.ChangeNavigation(3, vWin, "电源");
            }
        }

        private void Image_GongHao_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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
                pageFrame.Source = new Uri("GongHao.xaml", UriKind.Relative);

                Window vWin = Window.GetWindow(this);
                App.ChangeNavigation(3, vWin, "电子工号牌");
            }
        }

       

        void init()
        {
            WatchHouseMonitoring vWatchHouseMonitoring = new WatchHouseMonitoring();
            bool vGangTingState = false, vDianYuanState = false, vLedState = false;
            vWatchHouseMonitoring.GetWatchHouseState(App.WatchHouseID, ref vGangTingState, ref vDianYuanState,ref vLedState);
            //岗亭在线状态
            if (!vGangTingState)
            {
                Image_DengGuan.Source = new BitmapImage(new Uri(@"Images/GanTingMingXi/DengGuan_L.jpg", UriKind.Relative));
                Image_MenChuang.Source = new BitmapImage(new Uri(@"Images/GanTingMingXi/Men_L.jpg", UriKind.Relative));
                Image_XinFeng.Source = new BitmapImage(new Uri(@"Images/GanTingMingXi/XingFeng_L.jpg", UriKind.Relative));
                Image_KongTiao.Source = new BitmapImage(new Uri(@"Images/GanTingMingXi/KongTiao_L.jpg", UriKind.Relative));
                Image_DiNuan.Source = new BitmapImage(new Uri(@"Images/GanTingMingXi/DiRuan_L.jpg", UriKind.Relative));
                Image_GongHao.Source = new BitmapImage(new Uri(@"Images/GanTingMingXi/DianZhiPai_L.jpg", UriKind.Relative));
            }
            //电源在线状态
            if ( !vDianYuanState)
                Image_DianYuan.Source = new BitmapImage(new Uri(@"Images/GanTingMingXi/DianYuan_L.jpg", UriKind.Relative));
            //LED在线状态
            if (!vLedState)
                Image_LED.Source = new BitmapImage(new Uri(@"Images/GanTingMingXi/LED_L.jpg", UriKind.Relative));

            //权限控制
            if ( !App.Power_GangTing )
            {
                Image_DengGuan.IsEnabled = false;
                Image_MenChuang.IsEnabled = false;
                Image_XinFeng.IsEnabled = false;
                Image_KongTiao.IsEnabled = false;
                Image_DiNuan.IsEnabled = false;
                Image_GongHao.IsEnabled = false;
            }
            if (!App.Power_LED)
                Image_LED.IsEnabled = false;
            if (!App.Power_DianYuan)
                Image_DianYuan.IsEnabled = false;

        }
    }
}
