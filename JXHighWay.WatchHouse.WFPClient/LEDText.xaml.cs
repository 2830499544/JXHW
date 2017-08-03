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

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// LEDText.xaml 的交互逻辑
    /// </summary>
    public partial class LEDText : Window
    {
        public int RichWidth { get; set; }
        public int RichHeigth { get; set; }
        public LEDText()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RTFBox1.RichWidth = RichWidth;
            RTFBox1.RichHeight = RichHeigth;
        }
    }
}
