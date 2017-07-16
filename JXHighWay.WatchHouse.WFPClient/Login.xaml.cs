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
using Xceed.Wpf.Toolkit;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, RoutedEventArgs e)
        {
            User vLogin = new User();
            bool vGangTing = false, vDianYuan = false, vLED = false;
            if (vLogin.Login(textBox_UserName.Text, passwordBox_Password.Password, ref vGangTing, ref vDianYuan, ref vLED))
            {
                App.Power_GangTing = vGangTing;
                App.Power_DianYuan = vDianYuan;
                App.Power_LED = vLED;

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
                    pageFrame.Source = new Uri("MainPage.xaml", UriKind.Relative);

                    Window vWin = Window.GetWindow(this);
                    App.ChangeNavigation(1, vWin, "主界面");
                }
            }
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("用户名或密码错误", "错误",MessageBoxButton.OK,MessageBoxImage.Error);
            
        }
    }
}
