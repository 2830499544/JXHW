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
        }

        private async void CheckBox_DiNuan_Checked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiDiNuan);
            if (!vResult)
                MessageBox.Show("地暖开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async void CheckBox_DiNuan_Unchecked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanDiNuan);
            if (!vResult)
                MessageBox.Show("地暖开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async void CheckBox_ZuoJiao_Checked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiZuoNJ);
            if (!vResult)
                MessageBox.Show("左暖脚开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async void CheckBox_ZuoJiao_Unchecked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanZuoNJ);
            if (!vResult)
                MessageBox.Show("左暖脚开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async void CheckBox_YouJiao_Checked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiYouNJ);
            if (!vResult)
                MessageBox.Show("右暖脚开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async void CheckBox_YouJiao_Unchecked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanYouNJ);
            if (!vResult)
                MessageBox.Show("右暖脚开关失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private  async void Button_Shen_Click(object sender, RoutedEventArgs e)
        {
            int vDanQianWD = (int)Label_DanQianWD.Tag;
            vDanQianWD++;
            if (vDanQianWD<15 || vDanQianWD>35 )
                MessageBox.Show("超出地暖温度区间范围15至35度", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.TiaoJieSW, (byte)(vDanQianWD>>0));
                if ( !vResult )
                    MessageBox.Show("地暖温度设置失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("超出地暖温度区间范围15至35度", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.TiaoJieSW, (byte)(vDanQianWD >> 0));
                if (!vResult)
                    MessageBox.Show("地暖温度设置失效", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    Label_DanQianWD.Tag = vDanQianWD;
                    Label_DanQianWD.Content = string.Format("{0}℃", vDanQianWD);
                }
            }
        }
    }
}
