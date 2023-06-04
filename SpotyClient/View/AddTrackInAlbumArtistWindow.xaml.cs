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
using ModelsApi;
using SpotyClient.ViewModel;

namespace SpotyClient.View
{
    /// <summary>
    /// Логика взаимодействия для AddTrackInAlbumArtistWindow.xaml
    /// </summary>
    public partial class AddTrackInAlbumArtistWindow : Window
    {
        public static AddTrackInAlbumArtistWindow Window;
        public AddTrackInAlbumArtistWindow()
        {
            InitializeComponent();
            DataContext = new AddTrackInAlbumArtistWindowViewModel(null);
            Window = this;
        }

        public AddTrackInAlbumArtistWindow(TrackApi track)
        {
            InitializeComponent();
            DataContext = new AddTrackInAlbumArtistWindowViewModel(track);
            Window = this;
        }

        private void MouseDrag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                AddTrackInAlbumArtistWindow.Window.DragMove();
            }
        }
    }
}
