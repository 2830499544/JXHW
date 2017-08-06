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
using System.Windows.Shapes;
using JXHighWay.WatchHouse.Bll.Client.GanTing;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// LEDSend.xaml 的交互逻辑
    /// </summary>
    public partial class LEDSend : Window
    {
        public LEDSend()
        {
            InitializeComponent();
        }

        private void button_QuXiao_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            init();
        }

        List<CheckBox> m_CheckBoxList = null;

        void init()
        {
            
            m_CheckBoxList = new List<CheckBox>();
            WatchHouseMonitoring vWatchHouseMonitoring = new WatchHouseMonitoring();
            List<WatchHouseInfo> vWatchHouseInfoList = vWatchHouseMonitoring.GetAllWatchHouseInfo();

            double vCount_Double = vWatchHouseInfoList.Count / (double)4;
            int vCount_int = (int)(vCount_Double / (double)8);

            for (int i = 0; i < vWatchHouseInfoList.Count; i++)
            {
                CheckBox vNewCheckBox = new CheckBox()
                {
                    Content = vWatchHouseInfoList[i].GangTingMC,
                    Tag = vWatchHouseInfoList[i].GuanGaoPingIP
                };

                string vIsSelected = SelectedIPArray.Where(m => m == vWatchHouseInfoList[i].GuanGaoPingIP).FirstOrDefault();
                if (vIsSelected != null && vIsSelected != "")
                    vNewCheckBox.IsChecked = true;

                listBox_GangTing.Items.Add(vNewCheckBox);
                m_CheckBoxList.Add(vNewCheckBox);
                //for (int j = 1; j <= 4; j++)
                //{
                //    CheckBox vNewCheckBox = new CheckBox()
                //    {
                //        Content = vWatchHouseInfoList[i].GangTingMC,
                //        Tag = vWatchHouseInfoList[i].GuanGaoPingIP
                //        //Margin = new Thickness(10 * j + 30, )
                //    };
                //}
            }
        }

        public string[] SelectedIPArray { get; set; } = new string[0];
        private void button_XuanDing_Click(object sender, RoutedEventArgs e)
        {
            List<string> vSelectedIP = new List<string>();
            foreach ( CheckBox vTempCheckBox in m_CheckBoxList )
            {
                if (vTempCheckBox.IsChecked ?? false)
                    vSelectedIP.Add((string)vTempCheckBox.Tag);
            }
            SelectedIPArray = vSelectedIP.ToArray();
            DialogResult = true;
        }
    }
}
