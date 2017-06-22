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
    /// GanTingMingXi.xaml 的交互逻辑
    /// </summary>
    public partial class GanTingMingXi : Page
    {
        public GanTingMingXi()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }
            // Change the page of the frame.
            if (pageFrame != null)
            {
                pageFrame.Source = new Uri("DengGuang.xaml", UriKind.Relative);
            }
        }

        private void image_Copy4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }
            // Change the page of the frame.
            if (pageFrame != null)
            {
                pageFrame.Source = new Uri("KongTiao.xaml", UriKind.Relative);
            }
        }

        private void image_Copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }
            // Change the page of the frame.
            if (pageFrame != null)
            {
                pageFrame.Source = new Uri("MenChuang.xaml", UriKind.Relative);
            }
        }

        private void image_Copy3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }
            // Change the page of the frame.
            if (pageFrame != null)
            {
                pageFrame.Source = new Uri("XinFeng.xaml", UriKind.Relative);
            }
        }
    }
}
