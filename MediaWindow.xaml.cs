using Microsoft.VisualBasic;
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

namespace MultipleMediaPlayer
{
    /// <summary>
    /// MediaWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MediaWindow : Window
    {
        public MediaWindow()
        {
            InitializeComponent();
        }

        public MainWindow main { get; set; }

        public string mediaUri { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mediaElement.LoadedBehavior = MediaState.Manual;
            mediaElement.Source = new Uri(mediaUri);
            mediaElement.Pause();
            main.mediaElements.Add(mediaElement);
            main.MediaVolume.Value = (double)mediaElement.Volume;
            main.MediaVolume.IsEnabled = true;
        }

        bool windowMaximizedFlag = false;
        private void doubleClickControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!windowMaximizedFlag)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
                windowMaximizedFlag= true;
            }
            else
            {
                this.WindowStyle = WindowStyle.ThreeDBorderWindow;
                this.WindowState = WindowState.Normal;
                windowMaximizedFlag= false;
            }
            
        }

        private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            mediaElement.Pause();
        }
    }
}
