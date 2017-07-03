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
using JXHighWay.WatchHouse.Bll.Client.DianYuan;

namespace JXHighWay.WatchHouse.WFPClient.Images
{
    /// <summary>
    /// DianYuan.xaml 的交互逻辑
    /// </summary>
    public partial class DianYuan : Page
    {
        public DianYuan()
        {
            InitializeComponent();
        }

        private async void checkBox_Switch1_Checked(object sender, RoutedEventArgs e)
        {
            PowerMonitoring vPowerMonitoring = new PowerMonitoring();
            bool aa = await vPowerMonitoring.SendCMD_Switch(11, 0x01, 0x02, true);
            MessageBox.Show(aa.ToString());
        }

        private async void checkBox_Switch1_Unchecked(object sender, RoutedEventArgs e)
        {
            PowerMonitoring vPowerMonitoring = new PowerMonitoring();
            bool aa = await vPowerMonitoring.SendCMD_Switch(11, 0x01, 0x02, false);
            MessageBox.Show(aa.ToString());
        }
    }
}
