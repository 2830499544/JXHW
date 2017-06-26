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
            DiNuanStateModel vDiNuanStateModel =  m_Monitoring.DiNuan(App.WatchHouseID);
            CheckBox_DiNuan.IsChecked = vDiNuanStateModel.DiNuan;
            CheckBox_YouJiao.IsChecked = vDiNuanStateModel.YouNuanJQ;
            CheckBox_ZuoJiao.IsChecked = vDiNuanStateModel.ZuoNuanJQ;

            Label_DanQianWD.Content = vDiNuanStateModel.DanQianWD;
            Label_SheZiWenDu.Content = vDiNuanStateModel.SheZhiWD;
        }
    }
}
