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

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// XinFeng.xaml 的交互逻辑
    /// </summary>
    public partial class XinFeng : Page
    {
        public XinFeng()
        {
            InitializeComponent();
        }

        private void image_FL_1J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j_a.jpg", UriKind.Relative));
            image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j.jpg", UriKind.Relative));
            image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j.jpg", UriKind.Relative));
            image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j.jpg", UriKind.Relative));
            image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j.jpg", UriKind.Relative));
        }

        private void image_FL_2J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j.jpg", UriKind.Relative));
            image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j_a.jpg", UriKind.Relative));
            image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j.jpg", UriKind.Relative));
            image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j.jpg", UriKind.Relative));
            image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j.jpg", UriKind.Relative));
        }

        private void image_FL_3J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j.jpg", UriKind.Relative));
            image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j.jpg", UriKind.Relative));
            image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j_a.jpg", UriKind.Relative));
            image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j.jpg", UriKind.Relative));
            image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j.jpg", UriKind.Relative));
        }

        private void image_FL_4J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j.jpg", UriKind.Relative));
            image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j.jpg", UriKind.Relative));
            image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j.jpg", UriKind.Relative));
            image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j_a.jpg", UriKind.Relative));
            image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j.jpg", UriKind.Relative));
        }

        private void image_FL_5J_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_FL_1J.Source = new BitmapImage(new Uri(@"Images/XinFeng/1j.jpg", UriKind.Relative));
            image_FL_2J.Source = new BitmapImage(new Uri(@"Images/XinFeng/2j.jpg", UriKind.Relative));
            image_FL_3J.Source = new BitmapImage(new Uri(@"Images/XinFeng/3j.jpg", UriKind.Relative));
            image_FL_4J.Source = new BitmapImage(new Uri(@"Images/XinFeng/4j.jpg", UriKind.Relative));
            image_FL_5J.Source = new BitmapImage(new Uri(@"Images/XinFeng/5j_a.jpg", UriKind.Relative));
        }
    }
}
