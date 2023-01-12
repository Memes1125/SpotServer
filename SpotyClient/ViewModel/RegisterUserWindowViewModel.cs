﻿using Microsoft.Win32;
using ModelsApi;
using SpotyClient.Components;
using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;



namespace SpotyClient.ViewModel
{
    public class RegisterUserWindowViewModel : Notify
    {
        private ImageSource image;
        public ImageSource Image
        {
            get => image;
            set
            {
                image = value;
                SignalChanged();
            }
        }



        public List<UserApi> users { get; set; }
        public UserApi AddUser { get; set; }
        public CustomCommand SaveUser { get; set; }
        public CustomCommand SelectImage { get; set; }
        public string PasswordConfirm { get; set; }


        public RegisterUserWindowViewModel(UserApi user)
        {
            string directory = Environment.CurrentDirectory;
            Task.Run(GetListUsers);
            if (user == null)
            {
                AddUser = new UserApi();
            }
            else
            {
                AddUser = new UserApi
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Password = user.Password,
                    Image = user.Image
                };
            }

            SaveUser = new CustomCommand(() =>
            {
                if (AddUser.Password == PasswordConfirm)
                {
                    if (AddUser.Id == 0)
                    {
                        Task.Run(CreateNewUser);
                        Thread.Sleep(200);
                        Task.Run(GetListUsers);
                    }
                    else
                        Task.Run(EditUsers);

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.DataContext == this)
                            CloseWin(window);
                    }
                }
                else
                    MessageBox.Show("Чёт с паролем не так");
            });

            SelectImage = new CustomCommand(() =>
            {
                OpenFileDialog ofd = new OpenFileDialog();

                if (ofd.ShowDialog() == true)
                {
                    try
                    {
                        Image = LoadImage(ofd.FileName);
                        //var newPath = directory.Substring(0, directory.Length - 25) + AddUser.Image;
                        //File.Copy(ofd.FileName, newPath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Код ошибки: Image Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error); 
                    }
                }
            });
        }

        #region
        public static ImageSource LoadImage(string url)
        {
            var img = new BitmapImage();
            using (var stream = new FileStream(url, FileMode.Open))
            {
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad;
                img.StreamSource = stream;
                //img.UriSource = new Uri(url, UriKind.Absolute);
                img.EndInit();
            }
            return img;
        }

        


        #endregion




        public void CloseWin(object obj)
        {
            Window win = obj as Window;
            win.Close();
        }

        public async Task EditUsers()
        {
            await Api.PutAsync<UserApi>(AddUser, "User");
        }

        public async Task CreateNewUser()
        {
            await Api.PostAsync<UserApi>(AddUser, "User");
        }

        public async Task GetListUsers()
        {
            var result = await Api.GetListAsync<UserApi[]>("User");
            users = new List<UserApi>(result);
            SignalChanged("users");
        }
    }
}
