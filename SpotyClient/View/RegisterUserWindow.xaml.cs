using ModelsApi;
using SpotyClient.ViewModel;
using System;
using System.Windows;


namespace SpotyClient.View
{
    /// <summary>
    /// Логика взаимодействия для RegisterUserWindow.xaml
    /// </summary>
    public partial class RegisterUserWindow : Window
    {
        public RegisterUserWindow()
        {
            InitializeComponent();
            DataContext = new RegisterUserWindowViewModel(null);
        }
        public RegisterUserWindow(UserApi user)
        {
            InitializeComponent();
            DataContext = new RegisterUserWindowViewModel(user);
        }
    }
}
