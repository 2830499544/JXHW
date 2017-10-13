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

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Frame1.Source = new Uri("/Page1.xaml", UriKind.Relative);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Frame1.Source = new Uri("/Page2.xaml", UriKind.Relative);
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch { }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Label_Navigation1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Source = new Uri("MainPage.xaml", UriKind.Relative);
            Window vWin = Window.GetWindow(this);
            App.ChangeNavigation(1, vWin, "主界面");
        }

        private void Label_Navigation2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Source = new Uri("GanTingMingXi.xaml", UriKind.Relative);
            Window vWin = Window.GetWindow(this);
            App.ChangeNavigation(2, vWin, App.WatchHouseName);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Window vWin = Window.GetWindow(this);
            App.ChangeNavigation(0, vWin, "主界面");
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            ConfigWindow vConfigWindow = new ConfigWindow();
            vConfigWindow.Owner = Application.Current.MainWindow;
            vConfigWindow.ShowDialog();
        }

        private void image_DengGuan_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Source = new Uri("DengGuang.xaml", UriKind.Relative);
            Window vWin = Window.GetWindow(this);
            App.ChangeNavigation(3, vWin, "灯光");
        }

        private void image_ZhiDongMC_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Source = new Uri("MenChuang.xaml", UriKind.Relative);
            Window vWin = Window.GetWindow(this);
            App.ChangeNavigation(3, vWin, "自动门窗");
        }

        private void image_DianYuan_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Source = new Uri("DianYuan.xaml", UriKind.Relative);
            Window vWin = Window.GetWindow(this);
            App.ChangeNavigation(3, vWin, "电源");
        }

        private void image_LED_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Source = new Uri("LED.xaml", UriKind.Relative);
            Window vWin = Window.GetWindow(this);
            App.ChangeNavigation(3, vWin, "LED显示屏");
        }

        private void image_XinFeng_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Source = new Uri("XinFeng.xaml", UriKind.Relative);
            Window vWin = Window.GetWindow(this);
            App.ChangeNavigation(3, vWin, "新风");
        }

        private void image_KongTiao_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Source = new Uri("KongTiao.xaml", UriKind.Relative);
            Window vWin = Window.GetWindow(this);
            App.ChangeNavigation(3, vWin, "空调");
        }

        private void image_DiNuan_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Source = new Uri("DiNuan.xaml", UriKind.Relative);
            Window vWin = Window.GetWindow(this);
            App.ChangeNavigation(3, vWin, "地暖");
        }

        private void image_GongHao_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Source = new Uri("GongHao.xaml", UriKind.Relative);
            Window vWin = Window.GetWindow(this);
            App.ChangeNavigation(3, vWin, "电子工号牌");
        }
    }
}
