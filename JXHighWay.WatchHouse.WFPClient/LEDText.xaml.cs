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

        public string RichText { get; set; }
        public string ImagePath { get; set; }

        public LEDText()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RTFBox1.RichWidth = RichWidth;
            RTFBox1.RichHeight = RichHeigth;
            RTFBox1.Text = RichText;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            RichText = RTFBox1.Text;
            ImagePath = RTFBox1.GetImageFromControl();
            DialogResult = true;
        }
    }
}
