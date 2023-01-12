using ModelsApi;
using SpotyClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SpotyClient.View
{
    /// <summary>
    /// Логика взаимодействия для RegisterArtistWindow.xaml
    /// </summary>
    public partial class RegisterArtistWindow : Window
    {
        public RegisterArtistWindow()
        {
            InitializeComponent();
            DataContext = new RegisterArtistWindowViewModel(null);
        }
        public RegisterArtistWindow(ArtistApi artist)
        {
            InitializeComponent();
            DataContext = new RegisterArtistWindowViewModel(artist);
        }
    }
}
