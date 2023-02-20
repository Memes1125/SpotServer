using ModelsApi;
using SpotyClient.Components;
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
    public class SingInWindowViewModel : Notify
    {

        private dynamic entry; // так не делать, выхода другого небыло 
        public dynamic Entry   // так не делать, Думай ещё, так делать нельзя
        {                      // (Нельзя использовать тако тип) 
            get => entry;
            set
            {
                entry = value;
                SignalChanged();
            }
        }

        public List<UserApi> users { get; set; }
        public List<ArtistApi> artists { get; set; }
        public CustomCommand SingIn { get; set; }
        public CustomCommand Back { get; set; }
        public ArtistApi Artist;
        public static int UsId;
        public static int ArtId;

        public SingInWindowViewModel(UserApi user, ArtistApi artist)
        {

            Task.Run(GetListUsers).ContinueWith(s =>
            {
                if (user == null)
                {
                    Entry = new UserApi();
                }
                else
                {
                    Entry = new UserApi
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Password = user.Password,
                    };
                }
            });

            Task.Run(GetListArtists).ContinueWith(s =>
            {
                if (artist == null)
                {
                    Entry = new ArtistApi();
                }
                else
                {
                    Entry = new ArtistApi
                    {
                        Id = artist.Id,
                        Email = artist.Email,
                        Password = artist.Password,
                    };
                }
            });

            SingIn = new CustomCommand(() =>
            {
                try
                {
                    Task.Run(GetListUsers);
                    Thread.Sleep(200);
                    Task.Run(GetListArtists);
                    Thread.Sleep(200);

                    Login();
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Сервера отключены");

                }
            });

            Back = new CustomCommand(() =>
            {
                BackWindow();
            });
        }

        public void Login()
        {
            foreach (var Users in users)
            {
                if (Users.Email == Entry.Email && Users.Password == Entry.Password)
                {
                    MasterWindow qq = new MasterWindow();
                    qq.Show();
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.DataContext == this)
                            CloseWin(window);
                    }
                    UsId = Users.Id;
                }
                else if (Users.Password != Entry.Password && Users.Email != Entry.Email)
                {
                    continue;
                }
            }

            foreach (var Artists in artists)
            {

                if (Artists.Email == Entry.Email && Artists.Password == Entry.Password)
                {
                    MasterArtistWindow qq = new MasterArtistWindow();
                    qq.Show();

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.DataContext == this)
                            CloseWin(window);
                    }
                    ArtId = Artists.Id;
                }
                else if (Artists.Password != Entry.Password && Artists.Email != Entry.Email)
                {
                    continue;
                }
            }
            if (Application.Current.MainWindow?.IsActive == false)
                MessageBox.Show("Пароль или логин неверны, давай по новой");

        }

        private void BackWindow()
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                    CloseWin(window);
            }
        }

        public async Task GetListUsers()
        {
            var result = await Api.GetListAsync<UserApi[]>("User");
            users = new List<UserApi>(result);
            SignalChanged("users");
        }

        public async Task GetListArtists()
        {
            var result = await Api.GetListAsync<ArtistApi[]>("Artist");
            artists = new List<ArtistApi>(result);
            SignalChanged("artists");
        }

        public void CloseWin(object obj)
        {
            Window win = obj as Window;
            win.Close();
        }
    }
}
