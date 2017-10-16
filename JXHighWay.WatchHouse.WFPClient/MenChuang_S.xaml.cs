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
using JXHighWay.WatchHouse.Bll.Client.GanTing;
using System.Threading;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// MenChuang_S.xaml 的交互逻辑
    /// </summary>
    public partial class MenChuang_S : Page
    {
        WatchHouseMonitoring m_Monitoring = null;
        bool m_IsInit = false;
        bool m_Switch_Men = true;
        bool m_Switch_Suo = true;
        bool m_Switch_BJ = true;

        //前风幕灯、前风幕、前自动窗
        bool m_Switch_QFMD = true;
        bool m_Switch_QFM = true;
        bool m_Switch_QZDC = true;
        //后风幕灯、后风幕、后风幕灯
        bool m_Switch_HFMD = true;
        bool m_Switch_HFM = true;
        bool m_Switch_HZDC = true;


        public MenChuang_S()
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
                        initMenChaung();
                    };
                    Dispatcher.BeginInvoke(action1);
                    Thread.Sleep(App.RefreshTime * 1000);
                }
            });
        }

        void initMenChaung()
        {
            MenChuangStateInfo vMenChuangStateModel = m_Monitoring.MenChuangStateSX(App.WatchHouseID);

            CheckBox_Men.IsChecked = vMenChuangStateModel.Men;
            CheckBox_BaoJing.IsChecked = vMenChuangStateModel.BaoJinQi;
            CheckBox_Shuo.IsChecked = vMenChuangStateModel.Shuo;
            changeSwitchColor_Men();
            changeSwitchColor_Suo();
            changeSwitchColor_BaoJingQi();

            //前
            CheckBox_QianFengMD.IsChecked = vMenChuangStateModel.FengMuDeng;
            CheckBox_QianFengMu.IsChecked = vMenChuangStateModel.FengMu;
            CheckBox_QianZhiDC.IsChecked = vMenChuangStateModel.ZiDonGChuang;
            changeSwitchColor_QFM();
            changeSwitchColor_QFMD();
            changeSwitchColor_QZDC();

            //后
            CheckBox_HouFengMD.IsChecked = vMenChuangStateModel.FengMuDeng2;
            CheckBox_HouFengMu.IsChecked = vMenChuangStateModel.FengMu2;
            CheckBox_HouZhiDC.IsChecked = vMenChuangStateModel.ZiDonGChuang2;
            changeSwitchColor_HFM();
            changeSwitchColor_HFMD();
            changeSwitchColor_HZDC();

            m_IsInit = true;
        }

        #region 前窗帘 
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
        #endregion

        #region 右窗帘
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
        #endregion

        #region 门控制
        private async void CheckBox_Men_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_Men)
            {
                m_Switch_Men = false;
                bool vOldValue = CheckBox_Men.IsChecked ?? false;
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

        private async void CheckBox_Shuo_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_Suo)
            {
                m_Switch_Suo = false;
                bool vOldValue = CheckBox_Shuo.IsChecked ?? false;
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiShuo);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.ShangShuo);
                if (!vResult)
                {
                    CheckBox_Shuo.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("锁开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_Suo();
                m_Switch_Suo = true;
            }
        }

      

        void changeSwitchColor_Suo()
        {
            if (CheckBox_Men.IsChecked ?? false)
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
            if (m_IsInit && m_Switch_QFMD)
            {
                m_Switch_QFMD = false;
                bool vOldValue = CheckBox_QianFengMD.IsChecked ?? false;
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanChuangDeng_Qian);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiChuangDeng_Qian);
                if (!vResult)
                {
                    CheckBox_QianFengMD.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("风幕灯开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_QFMD();
                m_Switch_QFMD = true;
            }
        }

        private async void CheckBox_HouFengMD_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_HFMD)
            {
                m_Switch_HFMD = false;
                bool vOldValue = CheckBox_HouFengMD.IsChecked ?? false;
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanChuangDeng_Hou);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiChuangDeng_Hou);
                if (!vResult)
                {
                    CheckBox_HouFengMD.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("风幕灯开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_HFMD();
                m_Switch_HFMD = true;
            }
        }

        void changeSwitchColor_HFMD()
        {
            if (CheckBox_HouFengMD.IsChecked ?? false)
            {
                label_HFMD_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_HFMD_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_HFMD_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_HFMD_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }

        void changeSwitchColor_QFMD()
        {
            if (CheckBox_QianFengMD.IsChecked ?? false)
            {
                label_QFMD_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_QFMD_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_QFMD_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_QFMD_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }
        #endregion

        #region 风幕
        private async void CheckBox_FengMu_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_QFM)
            {
                m_Switch_QFM = false;
                bool vOldValue = CheckBox_QianFengMu.IsChecked ?? false;
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanFengMu_Qian);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiFengMu_Qian);
                if (!vResult)
                {
                    CheckBox_QianFengMu.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("风幕开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_QFM();
                m_Switch_QFM = true;
            }
        }

        private async void CheckBox_HouFengMu_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_HFM)
            {
                m_Switch_HFM = false;
                bool vOldValue = CheckBox_HouFengMu.IsChecked ?? false;
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanFengMu_Hou);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiFengMu_Hou);
                if (!vResult)
                {
                    CheckBox_HouFengMu.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("风幕开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_HFM();
                m_Switch_HFM = true;
            }
        }

        void changeSwitchColor_HFM()
        {
            if (CheckBox_HouFengMu.IsChecked ?? false)
            {
                label_HFM_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_HFM_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_HFM_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_HFM_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }

        void changeSwitchColor_QFM()
        {
            if (CheckBox_QianFengMu.IsChecked ?? false)
            {
                label_QFM_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_QFM_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_QFM_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_QFM_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }

        #endregion

        #region 自动窗
        private async void CheckBox_ZiDongChuang_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_QZDC)
            {
                m_Switch_QZDC = false;
                bool vOldValue = CheckBox_QianZhiDC.IsChecked ?? false;
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanChaugn_Qian);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiChuang_Hou);
                if (!vResult)
                {
                    CheckBox_QianZhiDC.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("自动窗开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_QZDC();
                m_Switch_QZDC = true;
            }
        }

        private async void CheckBox_HouZhiDC_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_HZDC)
            {
                m_Switch_HZDC = false;
                bool vOldValue = CheckBox_HouZhiDC.IsChecked ?? false;
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanChaugn_Hou);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiChuang_Hou);
                if (!vResult)
                {
                    CheckBox_HouZhiDC.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("自动窗开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_HZDC();
                m_Switch_HZDC = true;
            }
        }

        void changeSwitchColor_HZDC()
        {
            if (CheckBox_HouZhiDC.IsChecked ?? false)
            {
                label_HZDC_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_HZDC_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_HZDC_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_HZDC_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }

        void changeSwitchColor_QZDC()
        {
            if (CheckBox_QianZhiDC.IsChecked ?? false)
            {
                label_QZDC_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_QZDC_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_QZDC_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_QZDC_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }

        #endregion

        #region 报警器
        private async void CheckBox_BaoJing_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_BJ)
            {

                m_Switch_BJ = false;
                bool vOldValue = !(CheckBox_BaoJing.IsChecked ?? false);
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanBaoJing);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiBaoJing);
                if (!vResult)
                {
                    CheckBox_BaoJing.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("报警开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_BaoJingQi();
                m_Switch_BJ = true;
            }
        }

        void changeSwitchColor_BaoJingQi()
        {
            if (CheckBox_BaoJing.IsChecked ?? false)
            {
                label_BJ_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_BJ_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_BJ_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E22"));
                label_BJ_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }



        #endregion

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            m_Monitoring = new WatchHouseMonitoring();
            RefreshState();
        }
    }
}
