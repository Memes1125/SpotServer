using SpotyClient.Components;
using SpotyClient.ViewModel;
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
using System.Windows.Threading;

namespace SpotyClient.View
{
    /// <summary>
    /// Логика взаимодействия для MasterWindow.xaml
    /// </summary>
    public partial class MasterWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MasterWindow()
        {
            InitializeComponent();
            DataContext = new MasterWinViewModel(Dispatcher);
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += timer_tick;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            time.Text = media1.Position.ToString(@"mm\:ss");
            sliderback2.Value = media1.Position.TotalSeconds;
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            media1.Pause();
            media1.Position = TimeSpan.FromSeconds(slider2.Value);
            media1.Play();
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (media1 != null)
            {
                media1.Volume = slider1.Value;
            }
        }

        private void media1_MediaOpened(object sender, RoutedEventArgs e)
        {
            slider2.Maximum = media1.NaturalDuration.TimeSpan.TotalSeconds;
            sliderback2.Maximum = media1.NaturalDuration.TimeSpan.TotalSeconds;
        }
        public bool check;
        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            if (media1.CanPause == false)
            {
                media1.Source = new Uri(Track.resultPath, UriKind.Absolute);
                media1.Play();
                timer.Start();
                check = true;
            }
            else
            {
                Uri uri = new Uri(Track.resultPath, UriKind.Absolute);
                if (check == true)
                {
                    media1.Pause();
                    timer.Stop();
                    check = false;
                    if (media1.Source != uri)
                    {
                        media1.Source = new Uri(Track.resultPath, UriKind.Absolute);
                        media1.Play();
                        timer.Start();
                        check = true;
                    }
                }
                else if (check == false)
                {
                    media1.Play();
                    timer.Start();
                    check = true;
                    if (media1.Source != uri)
                    {
                        media1.Source = new Uri(Track.resultPath, UriKind.Absolute);
                        media1.Play();
                        timer.Start();
                        check = true;
                    }
                }
            }
        }
    }
}
