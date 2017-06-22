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
    /// KongTiao.xaml 的交互逻辑
    /// </summary>
    public partial class KongTiao : Page
    {
        public KongTiao()
        {
            InitializeComponent();
        }

        private void image_FS_DF_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_FS_DF.Source = new BitmapImage(new Uri(@"Images/KongTiao/df_a.jpg", UriKind.Relative));
            image_FS_ZF.Source = new BitmapImage(new Uri(@"Images/KongTiao/zf.jpg", UriKind.Relative));
            image_FS_GF.Source = new BitmapImage(new Uri(@"Images/KongTiao/gf.jpg", UriKind.Relative));
        }

        private void image_FS_ZF_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_FS_DF.Source = new BitmapImage(new Uri(@"Images/KongTiao/df.jpg", UriKind.Relative));
            image_FS_ZF.Source = new BitmapImage(new Uri(@"Images/KongTiao/zf_a.jpg", UriKind.Relative));
            image_FS_GF.Source = new BitmapImage(new Uri(@"Images/KongTiao/gf.jpg", UriKind.Relative));
        }

        private void image_FS_GF_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_FS_DF.Source = new BitmapImage(new Uri(@"Images/KongTiao/df.jpg", UriKind.Relative));
            image_FS_ZF.Source = new BitmapImage(new Uri(@"Images/KongTiao/zf.jpg", UriKind.Relative));
            image_FS_GF.Source = new BitmapImage(new Uri(@"Images/KongTiao/gf_a.jpg", UriKind.Relative));
        }

        private void image_MS_CS_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_MS_CS.Source = new BitmapImage(new Uri(@"Images/KongTiao/cs_a.jpg", UriKind.Relative));
            image_MS_ZL.Source = new BitmapImage(new Uri(@"Images/KongTiao/zl.jpg", UriKind.Relative));
            image_MS_ZR.Source = new BitmapImage(new Uri(@"Images/KongTiao/zr.jpg", UriKind.Relative));
            image_MS_SF.Source = new BitmapImage(new Uri(@"Images/KongTiao/sf.jpg", UriKind.Relative));
            image_MS_ZD.Source = new BitmapImage(new Uri(@"Images/KongTiao/zd.jpg", UriKind.Relative));
        }

        private void image_MS_ZR_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            image_MS_CS.Source = new BitmapImage(new Uri(@"Images/KongTiao/cs.jpg", UriKind.Relative));
            image_MS_ZL.Source = new BitmapImage(new Uri(@"Images/KongTiao/zl.jpg", UriKind.Relative));
            image_MS_ZR.Source = new BitmapImage(new Uri(@"Images/KongTiao/zr_a.jpg", UriKind.Relative));
            image_MS_SF.Source = new BitmapImage(new Uri(@"Images/KongTiao/sf.jpg", UriKind.Relative));
            image_MS_ZD.Source = new BitmapImage(new Uri(@"Images/KongTiao/zd.jpg", UriKind.Relative));

        }

        private void image_MS_ZL_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_MS_CS.Source = new BitmapImage(new Uri(@"Images/KongTiao/cs.jpg", UriKind.Relative));
            image_MS_ZL.Source = new BitmapImage(new Uri(@"Images/KongTiao/zl_a.jpg", UriKind.Relative));
            image_MS_ZR.Source = new BitmapImage(new Uri(@"Images/KongTiao/zr.jpg", UriKind.Relative));
            image_MS_SF.Source = new BitmapImage(new Uri(@"Images/KongTiao/sf.jpg", UriKind.Relative));
            image_MS_ZD.Source = new BitmapImage(new Uri(@"Images/KongTiao/zd.jpg", UriKind.Relative));
        }

        private void image_MS_SF_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_MS_CS.Source = new BitmapImage(new Uri(@"Images/KongTiao/cs.jpg", UriKind.Relative));
            image_MS_ZL.Source = new BitmapImage(new Uri(@"Images/KongTiao/zl.jpg", UriKind.Relative));
            image_MS_ZR.Source = new BitmapImage(new Uri(@"Images/KongTiao/zr.jpg", UriKind.Relative));
            image_MS_SF.Source = new BitmapImage(new Uri(@"Images/KongTiao/sf_a.jpg", UriKind.Relative));
            image_MS_ZD.Source = new BitmapImage(new Uri(@"Images/KongTiao/zd.jpg", UriKind.Relative));
        }

        private void image_MS_ZD_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            image_MS_CS.Source = new BitmapImage(new Uri(@"Images/KongTiao/cs.jpg", UriKind.Relative));
            image_MS_ZL.Source = new BitmapImage(new Uri(@"Images/KongTiao/zl.jpg", UriKind.Relative));
            image_MS_ZR.Source = new BitmapImage(new Uri(@"Images/KongTiao/zr.jpg", UriKind.Relative));
            image_MS_SF.Source = new BitmapImage(new Uri(@"Images/KongTiao/sf.jpg", UriKind.Relative));
            image_MS_ZD.Source = new BitmapImage(new Uri(@"Images/KongTiao/zd_a.jpg", UriKind.Relative));
        }
    }
}
