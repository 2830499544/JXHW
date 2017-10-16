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
        //int m_LS = 0;
        List<int> m_LuoHaoList = null;
        public DianYuan()
        {
            InitializeComponent();
        }

        void init()
        {
            m_PowerMonitoring = new PowerMonitoring();
            m_LuoHaoList = new List<int>();
            PowerInfo[] vPowerInfoArray = m_PowerMonitoring.GetPowerLuSu(App.PowerID1);
            // m_LS = vPowerInfoArray == null ? 0 : vPowerInfoArray.Length;

            for (int i = 1; i <= 14; i++)
            {

                if (i <= vPowerInfoArray.LongLength)
                {
                    PowerInfo vPowerInfo = vPowerInfoArray[i - 1];

                    m_LuoHaoList.Add(vPowerInfo.LuHao);

                    GroupBox vGroupBox = (GroupBox)FindName(string.Format("groupBox_{0}", i));
                    vGroupBox.Visibility = Visibility.Visible;
                    vGroupBox.Header = vPowerInfo.MingCheng;
                    vGroupBox.Tag = vPowerInfo.LuHao;

                    
                    Image vImageSZ = (Image)FindName(string.Format("image_SZ{0}", i));
                    vImageSZ.Visibility = Visibility.Visible;
                    vImageSZ.Tag = vPowerInfo.LuHao;

                    Label vLabelSZ = (Label)FindName(string.Format("label_SZ{0}", i));
                    vLabelSZ.Visibility = Visibility.Visible;
                    vLabelSZ.Tag = vPowerInfo.LuHao;

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
                    vCheckBox.Tag = (byte)vPowerInfo.LuHao;

                    Label vlabel_Guan = (Label)FindName(string.Format("label_Guan_{0}", i));
                    vlabel_Guan.Visibility = Visibility.Visible;

                    Label vlabel_Kai = (Label)FindName(string.Format("label_Kai_{0}", i));
                    vlabel_Kai.Visibility = Visibility.Visible;
                }
                else
                {
                    GroupBox vGroupBox = (GroupBox)FindName(string.Format("groupBox_{0}", i));
                    vGroupBox.Visibility = Visibility.Hidden;

                    Image vImageSZ = (Image)FindName(string.Format("image_SZ{0}", i));
                    vImageSZ.Visibility = Visibility.Hidden;

                    Label vLabelSZ = (Label)FindName(string.Format("label_SZ{0}", i));
                    vLabelSZ.Visibility = Visibility.Hidden;

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

                    Label vlabel_Guan = (Label)FindName(string.Format("label_Guan_{0}", i));
                    vlabel_Guan.Visibility = Visibility.Hidden;

                    Label vlabel_Kai = (Label)FindName(string.Format("label_Kai_{0}", i));
                    vlabel_Kai.Visibility = Visibility.Hidden;
                }
            }
            m_IsInit = true;
        }

        async void RefreshState()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    Action action1 = () =>
                    {
                        for (int i = 1; i <= m_LuoHaoList.Count; i++)
                        {
                            PowerInfo vPowerInfo = m_PowerMonitoring.GetNewPowerInfo(App.PowerID1, m_LuoHaoList[i - 1]);
                            if (vPowerInfo != null)
                            {
                                Label vLabel_DY = (Label)FindName(string.Format("label_DY_{0}", i));
                                vLabel_DY.Content = string.Format("{0}V", vPowerInfo.DianYa);

                                Label vLabel_DL = (Label)FindName(string.Format("label_DL_{0}", i));
                                vLabel_DL.Content = string.Format("{0}A", vPowerInfo.DianLiu);

                                CheckBox vCheckBox = (CheckBox)FindName(string.Format("checkBox_Switch{0}", i));
                                vCheckBox.IsChecked = vPowerInfo.ZhuangTai;

                                changeSwitchColor(vCheckBox, i);
                            }
                        }
                    };
                    Dispatcher.BeginInvoke(action1);
                    Thread.Sleep(App.RefreshTime * 1000);
                }
            });
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            init();
            RefreshState();
        }

        void changeSwitchColor(CheckBox checkBox, int luHao)
        {
            Label vlabel_Guan = (Label)FindName(string.Format("label_Guan_{0}", luHao));

            Label vlabel_Kai = (Label)FindName(string.Format("label_Kai_{0}", luHao));

            if (checkBox.IsChecked ?? false)
            {
                vlabel_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                vlabel_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                vlabel_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                vlabel_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }



        private void groupBox_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GroupBox vGroupBox = (GroupBox)sender;
            DianYuanMingXi vDianYuanMingXi = new DianYuanMingXi();
            vDianYuanMingXi.Owner = Application.Current.MainWindow;
            vDianYuanMingXi.LuHao = (int)vGroupBox.Tag;
            vDianYuanMingXi.DianYuanID = App.PowerID1;
            vDianYuanMingXi.Owner = Application.Current.MainWindow;
            vDianYuanMingXi.ShowDialog();

        }

        bool m_Switch = true;
        bool m_IsInit = false;
        private async void checkBox_Switch1_Click(object sender, RoutedEventArgs e)
        {
            CheckBox vCheckBox_Switch = (CheckBox)sender;
            byte vLuHao = (byte)vCheckBox_Switch.Tag;
            ParamInfo vSwitchInfo = m_PowerMonitoring.GetSwitchParamInfo(App.PowerID1, vLuHao);
            if (vSwitchInfo.ZhuangTai == null || vSwitchInfo.ZhuangTai == "" || vSwitchInfo.ZhuangTai == "正常")
            {
                if (m_IsInit && m_Switch)
                {
                    m_Switch = false;
                    bool vOldValue = vCheckBox_Switch.IsChecked ?? false;
                    bool vResult;
                    if (vOldValue)
                        vResult = await m_PowerMonitoring.SendCMD_Switch(App.PowerID1, 0x01, vLuHao, true);
                    else
                        vResult = await m_PowerMonitoring.SendCMD_Switch(App.PowerID1, 0x01, vLuHao, false);
                    if (!vResult)
                    {
                        vCheckBox_Switch.IsChecked = !vOldValue;
                        Xceed.Wpf.Toolkit.MessageBox.Show("开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    changeSwitchColor(vCheckBox_Switch, vLuHao);
                    m_Switch = true;
                }
            }
            else if (vSwitchInfo.ZhuangTai == "应急")
            {
                vCheckBox_Switch.IsChecked = !vCheckBox_Switch.IsChecked;
                Xceed.Wpf.Toolkit.MessageBox.Show("开关状态为应急，不能操作", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            else if (vSwitchInfo.ZhuangTai == "锁定")
            {
                vCheckBox_Switch.IsChecked = !vCheckBox_Switch.IsChecked;
                Xceed.Wpf.Toolkit.MessageBox.Show("开关状态为锁定，不能操作", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Image_XYSZ6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image vImage = (Image)sender;
            DianYuanMingXi vDianYuanMingXi = new DianYuanMingXi();
            vDianYuanMingXi.Owner = Application.Current.MainWindow;
            vDianYuanMingXi.LuHao = (int)vImage.Tag;
            vDianYuanMingXi.DianYuanID = App.PowerID1;
            vDianYuanMingXi.Owner = Application.Current.MainWindow;
            vDianYuanMingXi.ShowDialog();
        }

        private void label_SZ1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label vLabel = (Label)sender;
            DianYuanMingXi vDianYuanMingXi = new DianYuanMingXi();
            vDianYuanMingXi.Owner = Application.Current.MainWindow;
            vDianYuanMingXi.LuHao = (int)vLabel.Tag;
            vDianYuanMingXi.DianYuanID = App.PowerID1;
            vDianYuanMingXi.Owner = Application.Current.MainWindow;
            vDianYuanMingXi.ShowDialog();
        }

        private void image_SZ1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image vImage = (Image)sender;
            DianYuanMingXi vDianYuanMingXi = new DianYuanMingXi();
            vDianYuanMingXi.Owner = Application.Current.MainWindow;
            vDianYuanMingXi.LuHao = (int)vImage.Tag;
            vDianYuanMingXi.DianYuanID = App.PowerID1;
            vDianYuanMingXi.Owner = Application.Current.MainWindow;
            vDianYuanMingXi.ShowDialog();
        }
    }
}
