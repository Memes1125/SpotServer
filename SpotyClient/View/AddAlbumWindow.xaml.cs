using ModelsApi;
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

namespace SpotyClient.View
{
    /// <summary>
    /// Логика взаимодействия для AddAlbumWindow.xaml
    /// </summary>
    public partial class AddAlbumWindow : Window
    {
        public static AddAlbumWindow Window;
        public AddAlbumWindow()
        {
            InitializeComponent();
            DataContext = new AddAlbumViewModel(null);
            Window = this;
        }
        public AddAlbumWindow(AlbumApi album)
        {
            InitializeComponent();
            DataContext = new AddAlbumViewModel(album);
            Window = this;
        }

        private void MouseDrag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                AddAlbumWindow.Window.DragMove();
            }
        }
    }
}
