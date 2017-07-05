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
using System.Threading;

namespace JXHighWay.WatchHouse.WFPClient.Images
{
    /// <summary>
    /// DianYuan.xaml 的交互逻辑
    /// </summary>
    public partial class DianYuan : Page
    {
        PowerMonitoring m_PowerMonitoring = null;
        /// <summary>
        /// 电源总共路数
        /// </summary>
        int m_LS = 0;
        public DianYuan()
        {
            InitializeComponent();
        }

        private async void checkBox_Switch1_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox vCheckBox = (CheckBox)sender;
            byte vLuHao = (byte)vCheckBox.Tag;
            bool vResult = await m_PowerMonitoring.SendCMD_Switch(App.PowerID, 0x01, vLuHao, true);
            if (!vResult)
            {
                MessageBox.Show("开关失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                vCheckBox.IsChecked = false;
            }
        }

        private async void checkBox_Switch1_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox vCheckBox = (CheckBox)sender;
            byte vLuHao = (byte)vCheckBox.Tag;
            bool vResult = await m_PowerMonitoring.SendCMD_Switch(App.PowerID, 0x01, 0x02, false);
            if (!vResult)
            {
                MessageBox.Show("开关失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                vCheckBox.IsChecked = true;
            }
        }

        async void RefreshState()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    Action action1 = () =>
                    {
                        for (int i = 1; i <= m_LS; i++)
                        {
                            PowerInfo vPowerInfo = m_PowerMonitoring.GetNewPowerInfo(App.PowerID, i);
                            if (vPowerInfo != null)
                            {
                                Label vLabel_DY = (Label)FindName(string.Format("label_DY_{0}", i));
                                vLabel_DY.Content = string.Format("{0}V", vPowerInfo.DianYa);

                                Label vLabel_DL = (Label)FindName(string.Format("label_DL_{0}", i));
                                vLabel_DL.Content = string.Format("{0}A", vPowerInfo.DianLiu);
                            }
                        }
                    };
                    Dispatcher.BeginInvoke(action1);
                    Thread.Sleep(App.RefreshTime * 1000);
                }
            });
        }


       
        void init()
        {
            m_PowerMonitoring = new PowerMonitoring();
            m_LS = m_PowerMonitoring.GetPowerLuSu(App.WatchHouseID);
            for (int i= 1;i <= 12;i++)
            {
                if ( i<=m_LS)
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
                    vCheckBox.Tag = (byte)i;
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
            RefreshState();
        }
    }
}
