using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace JXHighWay.WatchHouse.Bll.Client.LED
{
    public class TextInfo
    {
        public string FullPath { get; set; }

        public bool IsSelected { get; set; } = true;

        public BitmapImage Image { get; set;}
    }
}
