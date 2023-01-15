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
    /// Логика взаимодействия для SingInWindow.xaml
    /// </summary>
    public partial class SingInWindow : Window
    {
        public SingInWindow()
        {
            InitializeComponent();
            DataContext = new SingInWindowViewModel(null);
        }

        public SingInWindow(UserApi user)
        {
            InitializeComponent();
            DataContext = new SingInWindowViewModel(user);
        }
    }
}
