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

namespace CapybaraClicker
{
    /// <summary>
    /// Logika interakcji dla klasy SoundPanel.xaml
    /// </summary>
    public partial class SoundPanel : Window
    {
        public MainWindow window { get; set; }
        public SoundPanel(MainWindow CapybaraWindow)
        {
            InitializeComponent();
            window = CapybaraWindow;
            this.Width = window.Width - 15;
            this.Height = window.Height - 7;
            this.Left = window.Left + 7;
            this.Top = window.Top;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            double[] properties = new double[2];
            properties[0] = sliderMusic.Value/100;
            properties[1] = sliderSounds.Value/100;
            MySettings.WriteMusicProperties(properties);
            Close();
        }
        private void sliderMusic_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SoundBoard.player.Volume = sliderMusic.Value / 100;
        }

        private void sliderSounds_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SoundBoard.volumeSound = sliderSounds.Value / 100;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double[] properties = new double[2];
            properties = MySettings.ReadMusicProperties();
            sliderMusic.Value = properties[0] * 100;
            sliderSounds.Value = properties[1] * 100;
        }
    }
}
