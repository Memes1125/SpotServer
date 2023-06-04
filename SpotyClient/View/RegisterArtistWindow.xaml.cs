using ModelsApi;
using SpotyClient.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SpotyClient.View
{
    /// <summary>
    /// Логика взаимодействия для RegisterArtistWindow.xaml
    /// </summary>
    public partial class RegisterArtistWindow : Window
    {
        public static RegisterArtistWindow Window;
        public RegisterArtistWindow()
        {
            InitializeComponent();
            DataContext = new RegisterArtistWindowViewModel(null);
            Window = this;
        }
        public RegisterArtistWindow(ArtistApi artist)
        {
            InitializeComponent();
            DataContext = new RegisterArtistWindowViewModel(artist);
            Window = this;
        }

        private void MouseDrag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                RegisterArtistWindow.Window.DragMove();
            }
        }
    }
}
