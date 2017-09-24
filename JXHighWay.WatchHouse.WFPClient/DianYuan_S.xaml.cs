using JXHighWay.WatchHouse.Bll.Client.DianYuan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// DianYuan_S.xaml 的交互逻辑
    /// </summary>
    public partial class DianYuan_S : Page
    {
        PowerMonitoring m_PowerMonitoring = null;
        /// <summary>
        /// 电源总共路数(电源1)
        /// </summary>
        //int m_LS = 0;
        List<int> m_LuoHaoList1 = null;
        /// <summary>
        /// 电源总共路数(电源2)
        /// </summary>
        List<int> m_LuoHaoList2 = null;

        public DianYuan_S()
        {
            InitializeComponent();
        }

        async void RefreshState()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    Action action1 = () =>
                    {
                        for (int i = 1; i <= m_LuoHaoList1.Count; i++)
                        {
                            PowerInfo vPowerInfo = m_PowerMonitoring.GetNewPowerInfo(App.PowerID1, m_LuoHaoList1[i - 1]);
                            if (vPowerInfo != null)
                            {
                                Label vLabel_DY = (Label)FindName(string.Format("label_DY1_DY_{0}", i));
                                vLabel_DY.Content = string.Format("{0}V", vPowerInfo.DianYa);

                                Label vLabel_DL = (Label)FindName(string.Format("label_DY1_DL_{0}", i));
                                vLabel_DL.Content = string.Format("{0}A", vPowerInfo.DianLiu);

                                CheckBox vCheckBox = (CheckBox)FindName(string.Format("checkBox_DY1_Switch{0}", i));
                                vCheckBox.IsChecked = vPowerInfo.ZhuangTai;

                                changeSwitchColor(vCheckBox,1, i);
                            }
                        }

                        for (int i = 1; i <= m_LuoHaoList2.Count; i++)
                        {
                            PowerInfo vPowerInfo = m_PowerMonitoring.GetNewPowerInfo(App.PowerID2, m_LuoHaoList2[i - 1]);
                            if (vPowerInfo != null)
                            {
                                Label vLabel_DY = (Label)FindName(string.Format("label_DY2_DY_{0}", i));
                                vLabel_DY.Content = string.Format("{0}V", vPowerInfo.DianYa);

                                Label vLabel_DL = (Label)FindName(string.Format("label_DY2_DL_{0}", i));
                                vLabel_DL.Content = string.Format("{0}A", vPowerInfo.DianLiu);

                                CheckBox vCheckBox = (CheckBox)FindName(string.Format("checkBox_DY2_Switch{0}", i));
                                vCheckBox.IsChecked = vPowerInfo.ZhuangTai;

                                changeSwitchColor(vCheckBox, 2, i);
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
            m_LuoHaoList1 = new List<int>();
            m_LuoHaoList2 = new List<int>();
            PowerInfo[] vPower1InfoArray = m_PowerMonitoring.GetPowerLuSu(App.PowerID1);
            init_DianYuan(1, vPower1InfoArray, m_LuoHaoList1);

            PowerInfo[] vPower2InfoArray = m_PowerMonitoring.GetPowerLuSu(App.PowerID2);
            init_DianYuan(2, vPower2InfoArray, m_LuoHaoList2);

            m_IsInit = true;
        }

        void init_DianYuan(int powerNum, PowerInfo[] powerInfo, List<int> LuoHaoList)
        {
            for (int i = 1; i <= 14; i++)
            {
                if (i <= powerInfo.LongLength)
                {
                    PowerInfo vPowerInfo = powerInfo[i - 1];

                    LuoHaoList.Add(vPowerInfo.LuHao);

                    GroupBox vGroupBox = (GroupBox)FindName(string.Format("groupBox_DY{0}_{1}", powerNum, i));
                    vGroupBox.Visibility = Visibility.Visible;
                    vGroupBox.Header = vPowerInfo.MingCheng;
                    vGroupBox.Tag = new int[] { powerNum,vPowerInfo.LuHao };

                    Image vImageDY = (Image)FindName(string.Format("image_DY{0}_DY{1}", powerNum,i));
                    vImageDY.Visibility = Visibility.Visible;

                    Label vLabelDY = (Label)FindName(string.Format("label_DY{0}_DY{1}", powerNum,i));
                    vLabelDY.Visibility = Visibility.Visible;

                    Label vLabel_DY = (Label)FindName(string.Format("label_DY{0}_DY_{1}",powerNum, i));
                    vLabel_DY.Visibility = Visibility.Visible;

                    Image vImageDL = (Image)FindName(string.Format("image_DY{0}_DL{1}",powerNum, i));
                    vImageDL.Visibility = Visibility.Visible;

                    Label vLabelDL = (Label)FindName(string.Format("label_DY{0}_DL{1}",powerNum, i));
                    vLabelDL.Visibility = Visibility.Visible;

                    Label vLabel_DL = (Label)FindName(string.Format("label_DY{0}_DL_{1}",powerNum, i));
                    vLabel_DL.Visibility = Visibility.Visible;

                    CheckBox vCheckBox = (CheckBox)FindName(string.Format("checkBox_DY{0}_Switch{1}",powerNum, i));
                    vCheckBox.Visibility = Visibility.Visible;
                    vCheckBox.Tag = new int[] { powerNum, vPowerInfo.LuHao };

                    Label vlabel_Guan = (Label)FindName(string.Format("label_DY{0}_Guan_{1}", powerNum, i));
                    vlabel_Guan.Visibility = Visibility.Visible;

                    Label vlabel_Kai = (Label)FindName(string.Format("label_DY{0}_Kai_{1}",powerNum, i));
                    vlabel_Kai.Visibility = Visibility.Visible;
                }
                else
                {
                    GroupBox vGroupBox = (GroupBox)FindName(string.Format("groupBox_DY{0}_{1}", powerNum, i));
                    vGroupBox.Visibility = Visibility.Hidden;

                    Image vImageDY = (Image)FindName(string.Format("image_DY{0}_DY{1}", powerNum, i));
                    vImageDY.Visibility = Visibility.Hidden;

                    Label vLabelDY = (Label)FindName(string.Format("label_DY{0}_DY{1}", powerNum, i));
                    vLabelDY.Visibility = Visibility.Hidden;

                    Label vLabel_DY = (Label)FindName(string.Format("label_DY{0}_DY_{1}", powerNum, i));
                    vLabel_DY.Visibility = Visibility.Hidden;
                    Image vImageDL = (Image)FindName(string.Format("image_DY{0}_DL{1}", powerNum, i));
                    vImageDL.Visibility = Visibility.Hidden;

                    Label vLabelDL = (Label)FindName(string.Format("label_DY{0}_DL{1}", powerNum, i));
                    vLabelDL.Visibility = Visibility.Hidden;

                    Label vLabel_DL = (Label)FindName(string.Format("label_DY{0}_DL_{1}", powerNum, i));
                    vLabel_DL.Visibility = Visibility.Hidden;

                    CheckBox vCheckBox = (CheckBox)FindName(string.Format("checkBox_DY{0}_Switch{1}", powerNum, i));
                    vCheckBox.Visibility = Visibility.Hidden;

                    Label vlabel_Guan = (Label)FindName(string.Format("label_DY{0}_Guan_{1}", powerNum, i));
                    vlabel_Guan.Visibility = Visibility.Hidden;

                    Label vlabel_Kai = (Label)FindName(string.Format("label_DY{0}_Kai_{1}", powerNum, i));
                    vlabel_Kai.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            init();
            RefreshState();
        }

        void changeSwitchColor(CheckBox checkBox,int powerNum, int luHao)
        {
            Label vlabel_Guan = (Label)FindName(string.Format("label_DY{0}_Guan_{1}",powerNum, luHao));

            Label vlabel_Kai = (Label)FindName(string.Format("label_DY{0}_Kai_{1}",powerNum, luHao));

            if (checkBox.IsChecked ?? false)
            {
                vlabel_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                vlabel_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                vlabel_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF0190F"));
                vlabel_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }

        private void groupBox_1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GroupBox vGroupBox = (GroupBox)sender;
            DianYuanMingXi vDianYuanMingXi = new DianYuanMingXi();
            vDianYuanMingXi.LuHao = ( (int[])vGroupBox.Tag )[1];
            if (((int[])vGroupBox.Tag)[0] == 1)
                vDianYuanMingXi.DianYuanID = App.PowerID1;
            else if (((int[])vGroupBox.Tag)[0] == 2)
                vDianYuanMingXi.DianYuanID = App.PowerID2;
            vDianYuanMingXi.ShowDialog();
            //Xceed.Wpf.Toolkit.Xceed.Wpf.Toolkit.MessageBox.Show("OK");
        }

        bool m_Switch = true;
        bool m_IsInit = false;
        private async void checkBox_Switch1_Click(object sender, RoutedEventArgs e)
        {
            CheckBox vCheckBox_Switch = (CheckBox)sender;
            int[] vTagData = (int[])vCheckBox_Switch.Tag;
            int vPowerNum = vTagData[0];
            byte vLuHao = (byte)(vTagData[1]>>0);
            ParamInfo vSwitchInfo = m_PowerMonitoring.GetSwitchParamInfo(App.PowerID2, vLuHao);
            if (vSwitchInfo.ZhuangTai==null || vSwitchInfo.ZhuangTai=="" || vSwitchInfo.ZhuangTai == "正常")
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
                    changeSwitchColor(vCheckBox_Switch, vPowerNum, vLuHao);
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

        private async void checkBox_Switch2_Click(object sender, RoutedEventArgs e)
        {
            CheckBox vCheckBox_Switch = (CheckBox)sender;
            int[] vTagData = (int[])vCheckBox_Switch.Tag;
            int vPowerNum = vTagData[0];
            byte vLuHao = (byte)(vTagData[1] >> 0);
            ParamInfo vSwitchInfo = m_PowerMonitoring.GetSwitchParamInfo(App.PowerID2, vLuHao);
            if (vSwitchInfo.ZhuangTai == null || vSwitchInfo.ZhuangTai == "" || vSwitchInfo.ZhuangTai == "正常")
            {
                if (m_IsInit && m_Switch)
                {
                    m_Switch = false;
                    bool vOldValue = vCheckBox_Switch.IsChecked ?? false;
                    bool vResult;
                    if (vOldValue)
                        vResult = await m_PowerMonitoring.SendCMD_Switch(App.PowerID2, 0x01, vLuHao, true);
                    else
                        vResult = await m_PowerMonitoring.SendCMD_Switch(App.PowerID2, 0x01, vLuHao, false);
                    if (!vResult)
                    {
                        vCheckBox_Switch.IsChecked = !vOldValue;
                        Xceed.Wpf.Toolkit.MessageBox.Show("开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    changeSwitchColor(vCheckBox_Switch, vPowerNum, vLuHao);
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
    }


}
