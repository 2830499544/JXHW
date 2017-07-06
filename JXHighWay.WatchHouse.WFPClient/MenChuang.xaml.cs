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
        void initMenChaung()
        {
            MenChuangStateInfo vMenChuangStateModel =  m_Monitoring.MenChuangState(App.WatchHouseID);
            CheckBox_BaoJingQi.IsChecked = vMenChuangStateModel.BaoJinQi;
            CheckBox_Chuang.IsChecked = vMenChuangStateModel.Chuang;
            CheckBox_FengMu.IsChecked = vMenChuangStateModel.FengMu;
            CheckBox_FengMuDeng.IsChecked = vMenChuangStateModel.FengMuDeng;
            CheckBox_Men.IsChecked = vMenChuangStateModel.Men;
            CheckBox_ZiDongChuang.IsChecked = vMenChuangStateModel.ZiDonGChuang;
        }

        private async void CheckBox_Men_Checked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiMen);
            
        }

        private async void CheckBox_Men_Unchecked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanMen);
            
        }

        private async void CheckBox_Chuang_Checked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiChuang);
            
        }

        private async void CheckBox_Chuang_Unchecked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanChaugn);
            
        }

        private async void Button_QCL_Shen_Click(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.QianChuanLSS);
            if (!vResult)
                MessageBox.Show("前窗帘上升失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async void Button_QCL_Jiang_Click(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.QianChuanLXJ);
            if (!vResult)
                MessageBox.Show("前窗帘下降失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async void button_QCL_Sheng_Click(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.YouChuanLSS);
            if (!vResult)
                MessageBox.Show("右窗帘上升失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private async void button_QCL_Jiang_Click_1(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.YouChuanLXJ);
            if (!vResult)
                MessageBox.Show("右窗帘下降失败", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CheckBox_ZiDongChuang_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private async void CheckBox_FengMuDeng_Checked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiChuangDeng);
            
        }

        private async void CheckBox_FengMuDeng_Unchecked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanChuangDeng);
            
        }

        private async void CheckBox_FengMu_Checked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.KaiFengMu);
            
        }

        private async void CheckBox_FengMu_Unchecked(object sender, RoutedEventArgs e)
        {
            bool vResult = await m_Monitoring.AsyncSendCommandToDB(App.WatchHouseID, Net.WatchHouseDataPack_Send_CommandEnmu.GuanFengMu);
            
        }
    }
}
