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
using JXHighWay.WatchHouse.Bll.Client;
using JXHighWay.WatchHouse.Bll.Client.GanTing;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// MenChuang.xaml 的交互逻辑
    /// </summary>
    public partial class MenChuang : Page
    {
        public MenChuang()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            m_Monitoring = new WatchHouseMonitoring();
            RefreshState();
        }

        async void RefreshState()
        {
            await Task.Run(() =>
            {
                while (true)
                {

                    Action action1 = () =>
                    {
                        initMenChaung();
                    };
                    Dispatcher.BeginInvoke(action1);
                    Thread.Sleep(App.RefreshTime * 1000);
                }
            });
        }

        WatchHouseMonitoring m_Monitoring = null;
        bool m_IsInit = false;
        bool m_Switch_Men = true;
        bool m_Switch_Suo = true;
        bool m_Switch_FMD = true;
        bool m_Switch_FM = true;
        bool m_Switch_ZDC = true;
        bool m_Switch_BJ = true;
        void initMenChaung()
        {
            MenChuangStateInfo vMenChuangStateModel =  m_Monitoring.MenChuangState(App.WatchHouseID);
            CheckBox_BaoJingQi.IsChecked = vMenChuangStateModel.BaoJinQi;
            CheckBox_Chuang.IsChecked = vMenChuangStateModel.Chuang;
            CheckBox_FengMu.IsChecked = vMenChuangStateModel.FengMu;
            CheckBox_FengMuDeng.IsChecked = vMenChuangStateModel.FengMuDeng;
            CheckBox_Men.IsChecked = vMenChuangStateModel.Men;
            CheckBox_ZiDongChuang.IsChecked = vMenChuangStateModel.ZiDonGChuang;
            changeSwitchColor_FM();
            changeSwitchColor_FMD();
            changeSwitchColor_Men();
            changeSwitchColor_Suo();
            changeSwitchColor_ZDC();
            changeSwitchColor_BJQ();
            m_IsInit = true;
        }


        private async void Button_QCL_Shen_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit)
            {
                bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.QianChuanLSS);
                if (!vResult)
                    Xceed.Wpf.Toolkit.MessageBox.Show("前窗帘上升失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Button_QCL_Jiang_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit)
            {
                bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.QianChuanLXJ);
                if (!vResult)
                    Xceed.Wpf.Toolkit.MessageBox.Show("前窗帘下降失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void button_QCL_Sheng_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit)
            {
                bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.YouChuanLSS);
                if (!vResult)
                    Xceed.Wpf.Toolkit.MessageBox.Show("右窗帘上升失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void button_QCL_Jiang_Click_1(object sender, RoutedEventArgs e)
        {
            if (m_IsInit)
            {
                bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.YouChuanLXJ);
                if (!vResult)
                    Xceed.Wpf.Toolkit.MessageBox.Show("右窗帘下降失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #region 门控制
        private async void CheckBox_Men_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_Men)
            {
                m_Switch_Men = false;
                bool vOldValue = !(CheckBox_Men.IsChecked ?? false);
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanMen);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiMen);
                if (!vResult)
                {
                    CheckBox_Men.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("门开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_Men();
                m_Switch_Men = true;
            }
        }

        void changeSwitchColor_Men()
        {
            if (CheckBox_Men.IsChecked ?? false)
            {
                label_Men_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_Men_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_Men_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_Men_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }

        #endregion

        #region 锁控制
        private async void CheckBox_Chuang_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit )
            {
                //CheckBox_Chuang.IsEnabled = false;
                m_Switch_Suo = false;
                bool vOldValue = !(CheckBox_Chuang.IsChecked ?? false);
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.ShangShuo);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiShuo);
                if (!vResult)
                {
                    CheckBox_Chuang.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("锁开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_Suo();
                m_Switch_Suo = true;
                //CheckBox_Chuang.IsEnabled = true;
            }
        }


        void changeSwitchColor_Suo()
        {
            if (CheckBox_Chuang.IsChecked ?? false)
            {
                label_Suo_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_Suo_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_Suo_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_Suo_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }

        #endregion

        #region 风幕灯
        private async void CheckBox_FengMuDeng_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_FMD)
            {
                m_Switch_FMD = false;
                bool vOldValue = !(CheckBox_FengMuDeng.IsChecked ?? false);
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanChuangDeng_Qian);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiChuangDeng_Qian);
                if (!vResult)
                {
                    CheckBox_FengMuDeng.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("风幕灯开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_FMD();
                m_Switch_FMD = true;
            }
        }

        void changeSwitchColor_FMD()
        {
            if (CheckBox_FengMuDeng.IsChecked ?? false)
            {
                label_FMD_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_FMD_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_FMD_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_FMD_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }
        #endregion

        #region 风幕
        private async void CheckBox_FengMu_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_FM)
            {
                m_Switch_FM = false;
                bool vOldValue = !(CheckBox_FengMu.IsChecked ?? false);
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanFengMu_Qian);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiFengMu_Qian);
                if (!vResult)
                {
                    CheckBox_FengMu.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("风幕开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_FM();
                m_Switch_FM = true;
            }
        }


        void changeSwitchColor_FM()
        {
            if (CheckBox_FengMu.IsChecked ?? false)
            {
                label_FM_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_FM_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_FM_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_FM_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }

        #endregion

        #region 自动窗
        private async void CheckBox_ZiDongChuang_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_ZDC)
            {
                m_Switch_ZDC = false;
                bool vOldValue = !(CheckBox_ZiDongChuang.IsChecked ?? false);
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanChaugn_Qian);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiChuang_Qian);
                if (!vResult)
                { 
                    CheckBox_ZiDongChuang.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("自动窗开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_FM();
                m_Switch_ZDC = true;
            }
        }

        void changeSwitchColor_ZDC()
        {
            if (CheckBox_ZiDongChuang.IsChecked ?? false)
            {
                label_ZDC_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_ZDC_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_ZDC_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_ZDC_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }
        #endregion

        #region 报警器
        void changeSwitchColor_BJQ()
        {
            if (CheckBox_BaoJingQi.IsChecked ?? false)
            {
                label_BJQ_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_BJQ_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_BJQ_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_BJQ_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }
        #endregion

        private async void CheckBox_BaoJingQi_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_BJ)
            {

                m_Switch_BJ = false;
                bool vOldValue = !(CheckBox_BaoJingQi.IsChecked ?? false);
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanBaoJing);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiBaoJing);
                if (!vResult)
                {
                    CheckBox_BaoJingQi.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("报警开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_FM();
                m_Switch_BJ = true;
            }
        }
    }
}
