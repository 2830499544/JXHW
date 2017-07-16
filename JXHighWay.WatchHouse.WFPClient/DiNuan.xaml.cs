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
    /// DiNuan.xaml 的交互逻辑
    /// </summary>
    public partial class DiNuan : Page
    {
        public DiNuan()
        {
            InitializeComponent();
        }

        bool m_IsInit = false;
        bool m_Switch_DiNuan = true;
        bool m_Switch_You = true;
        bool m_Switch_Zhuo = true;
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
                        initDiNuan();
                    };
                    Dispatcher.BeginInvoke(action1);
                    Thread.Sleep(App.RefreshTime * 1000);
                }
            });
        }

        WatchHouseMonitoring m_Monitoring = null;
        void initDiNuan()
        {
            m_Monitoring = new WatchHouseMonitoring();
            DiNuanStateInfo vDiNuanStateModel =  m_Monitoring.DiNuan(App.WatchHouseID);
            CheckBox_DiNuan.IsChecked = vDiNuanStateModel.DiNuan;
            CheckBox_YouJiao.IsChecked = vDiNuanStateModel.YouNuanJQ;
            CheckBox_ZuoJiao.IsChecked = vDiNuanStateModel.ZuoNuanJQ;

            Label_DanQianWD.Content = string.Format("{0}℃", vDiNuanStateModel.DanQianWD) ;
            Label_DanQianWD.Tag = vDiNuanStateModel.DanQianWD;
            Label_SheZiWenDu.Content = vDiNuanStateModel.SheZhiWD;
            changeSwitchColor_DiNuan();
            changeSwitchColor_YouJiao();
            changeSwitchColor_ZuoJiao();
            m_IsInit = true;
        }


        private  async void Button_Shen_Click(object sender, RoutedEventArgs e)
        {
            int vDanQianWD = (int)Label_DanQianWD.Tag;
            vDanQianWD++;
            if (vDanQianWD<15 || vDanQianWD>35 )
                Xceed.Wpf.Toolkit.MessageBox.Show("超出地暖温度区间范围15至35度", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.TiaoJieSW, (byte)(vDanQianWD>>0));
                if ( !vResult )
                    Xceed.Wpf.Toolkit.MessageBox.Show("地暖温度设置失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    Label_DanQianWD.Tag = vDanQianWD;
                    Label_DanQianWD.Content = string.Format("{0}℃", vDanQianWD);
                }

            }
        }

        private async void Button_Jian_Click(object sender, RoutedEventArgs e)
        {
            int vDanQianWD = (int)Label_DanQianWD.Tag;
            vDanQianWD--;
            if (vDanQianWD < 15 || vDanQianWD > 35)
                Xceed.Wpf.Toolkit.MessageBox.Show("超出地暖温度区间范围15至35度", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.TiaoJieSW, (byte)(vDanQianWD >> 0));
                if (!vResult)
                    Xceed.Wpf.Toolkit.MessageBox.Show("地暖温度设置失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    Label_DanQianWD.Tag = vDanQianWD;
                    Label_DanQianWD.Content = string.Format("{0}℃", vDanQianWD);
                }
            }
        }

        private async void CheckBox_DiNuan_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_DiNuan)
            {
                m_Switch_DiNuan = false;
                bool vOldValue = CheckBox_DiNuan.IsChecked ?? false;
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiDiNuan);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanDiNuan);
                if (!vResult)
                {
                    CheckBox_DiNuan.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("地暖开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_DiNuan();
                m_Switch_DiNuan = true;
            }
        }

        void changeSwitchColor_DiNuan()
        {
            if (CheckBox_DiNuan.IsChecked ?? false)
            {
                label_DiNuan_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_DiNuan_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_DiNuan_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF0190F"));
                label_DiNuan_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }

        private async void CheckBox_ZuoJiao_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_Zhuo)
            {
                m_Switch_DiNuan = false;
                bool vOldValue = CheckBox_ZuoJiao.IsChecked ?? false;
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiZuoNJ);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanZuoNJ);
                if (!vResult)
                {
                    CheckBox_ZuoJiao.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("左暖脚开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_ZuoJiao();
                m_Switch_DiNuan = true;
            }
        }

        void changeSwitchColor_ZuoJiao()
        {
            if (CheckBox_ZuoJiao.IsChecked ?? false)
            {
                label_Zhuo_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_Zhuo_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_Zhuo_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF0190F"));
                label_Zhuo_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }

        private async void CheckBox_YouJiao_Click(object sender, RoutedEventArgs e)
        {
            if (m_IsInit && m_Switch_You)
            {
                m_Switch_DiNuan = false;
                bool vOldValue = CheckBox_YouJiao.IsChecked ?? false;
                bool vResult;
                if (vOldValue)
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiYouNJ);
                else
                    vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanYouNJ);
                if (!vResult)
                {
                    CheckBox_YouJiao.IsChecked = !vOldValue;
                    Xceed.Wpf.Toolkit.MessageBox.Show("右暖脚开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                changeSwitchColor_YouJiao();
                m_Switch_DiNuan = true;
            }
        }

        void changeSwitchColor_YouJiao()
        {
            if (CheckBox_YouJiao.IsChecked ?? false)
            {
                label_You_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
                label_You_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF079E23"));
            }
            else
            {
                label_You_Guan.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF0190F"));
                label_You_Kai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF777877"));
            }
        }
    }
}
