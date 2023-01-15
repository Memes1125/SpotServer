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
    public class SingInWindowViewModel : Notify
    {
        private UserApi entry;
        public UserApi Entry
        {
            get => entry;
            set
            {
                entry = value;
                SignalChanged();
            }
        }
        public List<UserApi> users { get; set; }
        public CustomCommand SingIn { get; set; }
        public CustomCommand Back { get; set; }


        public SingInWindowViewModel(UserApi user)
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


            SingIn = new CustomCommand(() =>
            {
                try
                {
                    Task.Run(GetListUsers);
                    Thread.Sleep(200);
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
                        }
                        else if (Users.Password != Entry.Password && Users.Email != Entry.Email)
                        {
                            continue;
                        }
                    }
                    if (Application.Current.MainWindow?.IsActive == true)
                        MessageBox.Show("Пароль или логин неверны, давай по новой");
                }
                catch(Exception e)
                {
                    MessageBox.Show("Пользователи не загрузились, пожалуйста подождите");
                    
                }
            });

            Back = new CustomCommand(() =>
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });
        }


        public async Task GetListUsers()
        {
            var result = await Api.GetListAsync<UserApi[]>("User");
            users = new List<UserApi>(result);
            SignalChanged("users");
        }

        public void CloseWin(object obj)
        {
            Window win = obj as Window;
            win.Close();
        }
    }
}
