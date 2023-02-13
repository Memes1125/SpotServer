using ModelsApi;
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

namespace SpotyClient.View
{
    /// <summary>
    /// Логика взаимодействия для SingInWindow.xaml
    /// </summary>
    public partial class SingInWindow : Window
    {
        private ArtistApi entry;
        public ArtistApi Entry
        {
            get => entry;
            set
            {
                entry = value;
            }
        }

        public SingInWindow()
        {
            InitializeComponent();
            DataContext = new SingInWindowViewModel(null, null);
        }

        public SingInWindow(UserApi user, ArtistApi artist)
        {
            InitializeComponent();
            DataContext = new SingInWindowViewModel(user, artist);
            
        }
    }
}
