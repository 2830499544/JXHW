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

        void init()
        {
            PowerMonitoring vPowerMonitoring = new PowerMonitoring();
            int vLS = vPowerMonitoring.GetPowerLuSu(App.WatchHouseID);
            for (int i= 1;i <= 12;i++)
            {
                if ( i<=vLS)
                {
                    GroupBox vGroupBox = (GroupBox)FindName(string.Format("groupBox_{0}",i));
                    vGroupBox.Visibility = Visibility.Visible;

                    Image vImageDY = (Image)FindName(string.Format("image_DY{0}", i));
                    vImageDY.Visibility = Visibility.Visible;

                    Label vLabelDY = (Label)FindName(string.Format("label_DY{0}", i));
                    vLabelDY.Visibility = Visibility.Visible;

                    Label vLabel_DY = (Label)FindName(string.Format("label_DY_{0}", i));
                    vLabel_DY.Visibility = Visibility.Visible;

                    Image vImageDL = (Image)FindName(string.Format("image_DL{0}", i));
                    vImageDL.Visibility = Visibility.Visible;

                    Label vLabelDL = (Label)FindName(string.Format("label_DL{0}", i));
                    vLabelDL.Visibility = Visibility.Visible;

                    Label vLabel_DL = (Label)FindName(string.Format("label_DL_{0}", i));
                    vLabel_DL.Visibility = Visibility.Visible;

                    CheckBox vCheckBox = (CheckBox)FindName(string.Format("checkBox_Switch{0}", i));
                    vCheckBox.Visibility = Visibility.Visible;
                    
                }
                else
                {
                    GroupBox vGroupBox = (GroupBox)FindName(string.Format("groupBox_{0}", i));
                    vGroupBox.Visibility = Visibility.Hidden;

                    Image vImageDY = (Image)FindName(string.Format("image_DY{0}", i));
                    vImageDY.Visibility = Visibility.Hidden;

                    Label vLabelDY = (Label)FindName(string.Format("label_DY{0}", i));
                    vLabelDY.Visibility = Visibility.Hidden;

                    Label vLabel_DY = (Label)FindName(string.Format("label_DY_{0}", i));
                    vLabel_DY.Visibility = Visibility.Hidden;

                    Image vImageDL = (Image)FindName(string.Format("image_DL{0}", i));
                    vImageDL.Visibility = Visibility.Hidden;

                    Label vLabelDL = (Label)FindName(string.Format("label_DL{0}", i));
                    vLabelDL.Visibility = Visibility.Hidden;

                    Label vLabel_DL = (Label)FindName(string.Format("label_DL_{0}", i));
                    vLabel_DL.Visibility = Visibility.Hidden;

                    CheckBox vCheckBox = (CheckBox)FindName(string.Format("checkBox_Switch{0}", i));
                    vCheckBox.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }
    }
}
