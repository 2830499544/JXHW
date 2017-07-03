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
    }
}
