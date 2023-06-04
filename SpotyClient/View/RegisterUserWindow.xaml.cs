using ModelsApi;
using SpotyClient.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;

namespace SpotyClient.View
{
    /// <summary>
    /// Логика взаимодействия для RegisterUserWindow.xaml
    /// </summary>
    public partial class RegisterUserWindow : Window
    {
        public static RegisterUserWindow Window;
        public RegisterUserWindow()
        {
            InitializeComponent();
            DataContext = new RegisterUserWindowViewModel(null);
            Window = this;
        }
        public RegisterUserWindow(UserApi user)
        {
            InitializeComponent();
            DataContext = new RegisterUserWindowViewModel(user);
            Window = this;
        }

        private void MouseDrag(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                RegisterUserWindow.Window.DragMove();
            }
        }
    }
}
