using ModelsApi;
using SpotyClient.Tools;
using SpotyClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SpotyClient.ViewModel
{
    public class MainWindowViewModel : Notify
    {
        public CustomCommand Exit { get; set; }
        public CustomCommand RegUser { get; set; }
        public CustomCommand RegArtist { get; set; }
        public CustomCommand SingIn { get; set; }
        public CustomCommand Test { get; set; }

        public MainWindowViewModel(UserApi user)
        {
            Exit = new CustomCommand(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });

            RegUser = new CustomCommand(() =>
            {
                RegisterUserWindow RegUserWin = new RegisterUserWindow();
                RegUserWin.Show();
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });

            RegArtist = new CustomCommand(() =>
            {
                RegisterArtistWindow RegArtistWin = new RegisterArtistWindow();
                RegArtistWin.Show();
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });

            SingIn = new CustomCommand(() =>
            {
                SingInWindow SingInWin = new SingInWindow();
                SingInWin.Show();
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });
            Test = new CustomCommand(() =>
            {
                Test t = new Test();
                t.Show();
            });
        }

        public void CloseWin(object obj)
        {
            Window win = obj as Window;
            win.Close();
        }
    }
}
