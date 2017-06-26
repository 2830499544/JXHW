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

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// LED.xaml 的交互逻辑
    /// </summary>
    public partial class LED : Page
    {
        public LED()
        {
            InitializeComponent();
        }

        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            LEDControl vLEDControl = new LEDControl("192.168.0.113", 64, 64);
            vLEDControl.SendText(TextBox_Text.Text);
        }
    }
}
