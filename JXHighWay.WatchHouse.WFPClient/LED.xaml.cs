﻿using System;
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
using JXHighWay.WatchHouse.Bll.Client;
using JXHighWay.WatchHouse.LED;
using System.Xml.Serialization;
using System.IO;

namespace JXHighWay.WatchHouse.WFPClient
{
    /// <summary>
    /// LED.xaml 的交互逻辑
    /// </summary>
    public partial class LED : Page
    {
        LEDControl m_LEDControl;
        public LED()
        {
            InitializeComponent();
        }

        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            //LEDControl vLEDControl = new LEDControl("192.168.0.113", 64, 64);
            //vLEDControl.SendText(TextBox_Text.Text);
        }

        private void button_Test_Click(object sender, RoutedEventArgs e)
        {
            
        }

      
        private void button_ShiPing_ShangChuang_Click(object sender, RoutedEventArgs e)
        {
            m_LEDControl = new LEDControl(App.WatchHouseID, 64, 64);
            if (System.IO.File.Exists(textBox_ShiPing.Text))
                m_LEDControl.SendVideo(textBox_ShiPing.Text);
            else
                MessageBox.Show("视频文件不存在", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void button_ShiPing_LiuLan_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog vOpenFile = new Microsoft.Win32.OpenFileDialog();
            vOpenFile.Filter = "视频文件|*.mp4;*.avi;";
            if (vOpenFile.ShowDialog().Value)
            {
                textBox_ShiPing.Text = vOpenFile.FileName;
            }
        }

        private void button_TuPian_LiuLan_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog vOpenFile = new Microsoft.Win32.OpenFileDialog();
            vOpenFile.Filter = "视频文件|*.mp4;*.avi;";
            if (vOpenFile.ShowDialog().Value)
            {
                textBox_TuPian.Text = vOpenFile.FileName;
            }
        }

        private void button_Text_ShangChuang_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_Text.Text != "")
                m_LEDControl.SendText(textBox_Text.Text);
            else
            {
                MessageBox.Show("请输入方字", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox_Text.Focus();
            }
        }

        private void button_TuPian_ShangChuang_Click(object sender, RoutedEventArgs e)
        {
            m_LEDControl = new LEDControl(App.WatchHouseID, 64, 64);
            if (System.IO.File.Exists(textBox_TuPian.Text))
                m_LEDControl.SendVideo(textBox_TuPian.Text);
            else
                MessageBox.Show("图片文件不存在", "信息", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}