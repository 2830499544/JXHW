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
using JXHighWay.WatchHouse.Bll.Client;
using System.Text.RegularExpressions;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// ConfigWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            Config vConfig = new Config();
            vConfig.DBSource = TextBox_Address.Text;
            vConfig.DBName = TextBox_DBName.Text;
            vConfig.DBPassword = passwordBox.Password;
            vConfig.DBPort = int.Parse( TextBox_Port.Text );
            vConfig.DBUserName = TextBox_UserName.Text;
            vConfig.RefreshTime = int.Parse( TextBox_RefreshTime.Text );
            vConfig.OfflineTime = int.Parse(TextBox_OfflineTime.Text);
            vConfig.Save();
            DialogResult = true;
            Close();
        }

        private void TextBox_RefreshTime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex(@"^\+?[1-9][0-9]*$");
            e.Handled = !re.IsMatch(e.Text);
        }

        private void TextBox_OfflineTime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex(@"^\+?[1-9][0-9]*$");
            e.Handled = !re.IsMatch(e.Text);
        }

        private void TextBox_Port_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex(@"^\+?[1-9][0-9]*$");
            e.Handled = !re.IsMatch(e.Text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Config vConfig = new Config();
            TextBox_Address.Text = vConfig.DBSource;
            TextBox_DBName.Text = vConfig.DBName;
            passwordBox.Password = vConfig.DBPassword;
            TextBox_Port.Text = vConfig.DBPort.ToString();
            TextBox_UserName.Text = vConfig.DBUserName;
            TextBox_RefreshTime.Text = vConfig.RefreshTime.ToString();
            TextBox_OfflineTime.Text = vConfig.OfflineTime.ToString();
            vConfig.Save();
        }
    }
}
