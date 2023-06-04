﻿using ModelsApi;
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
    /// Логика взаимодействия для AddTrackInAlbumWindow.xaml
    /// </summary>
    public partial class AddTrackInAlbumWindow : Window
    {
        public static AddTrackInAlbumWindow Window;
        public AddTrackInAlbumWindow()
        {
            InitializeComponent();
            DataContext = new AddTrackInAlbumWindowViewModel(null);
            Window = this;
        }

        public AddTrackInAlbumWindow(TrackApi track)
        {
            InitializeComponent();
            DataContext = new AddTrackInAlbumWindowViewModel(track);
            Window = this;
        }

        private void MouseDrag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                AddTrackInAlbumWindow.Window.DragMove();
            }
        }
    }
}
