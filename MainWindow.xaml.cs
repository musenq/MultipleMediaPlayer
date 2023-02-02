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
using Microsoft.WindowsAPICodePack;

namespace MultipleMediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddWindowButton_Click(object sender, RoutedEventArgs e)
        {
            MediaWindow mediaWindow = new MediaWindow();
            mediaWindow.main = this;
            mediaWindow.mediaUri = URITextBox.Text;
            mediaWindow.Show();
        }

        public List<MediaElement> mediaElements = new List<MediaElement>();


        public void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            /*Parallel.ForEach(mediaElements, element =>
            {
                element.Play();
            });*/
            foreach (MediaElement element in mediaElements)
            {
                element.Play();
            }

        }

        private void BrowseBotton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.WindowsAPICodePack.Dialogs.CommonOpenFileDialog();
            if (dlg.ShowDialog() == Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.Ok)
            {
                URITextBox.Text= dlg.FileName;
                PlayButton.IsEnabled=true;
                StopButton.IsEnabled=true;
                AddWindowButton.IsEnabled=true;
            }
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(MediaElement element in mediaElements)
            {
                element.Stop();
                element.Pause();
            }
        }

        private void MediaVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            foreach(MediaElement element in mediaElements)
            {
                element.Volume = (double)MediaVolume.Value;
            }
        }
    }
}
