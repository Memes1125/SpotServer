﻿using Microsoft.Win32;
using ModelsApi;
using SpotyClient.Components;
using SpotyClient.Tools;
using SpotyClient.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;



namespace SpotyClient.ViewModel
{
    public class RegisterUserWindowViewModel : Notify
    {

        private BitmapImage imageBitMap;
        public BitmapImage ImageBitMap
        {
            get => imageBitMap;
            set
            {
                imageBitMap = value;
                SignalChanged("ImageBitMap");
            }
        }

        Regex regexMail = new Regex(@"^([a-z\d\.-]+)@([a-z\d-]+)\.([a-z]{2,8})(\.[a-z]{2,8})?$");
        Regex regexPassword = new Regex(@"^[\w@-]{8,20}");

        public List<UserApi> users { get; set; }
        public UserApi AddUser { get; set; }
        public CustomCommand Exit { get; set; }
        public CustomCommand SaveUser { get; set; }
        public CustomCommand SelectImage { get; set; }
        public CustomCommand Back { get; set; }
        public string PasswordConfirm { get; set; }

        public RegisterUserWindowViewModel(UserApi user)
        {
            
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

            Exit = new CustomCommand(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });

            SaveUser = new CustomCommand(() =>
            {
                if (AddUser.Email == null)
                {
                    MessageBox.Show("Email не введен");
                    return;
                }
                if (regexMail.IsMatch(AddUser.Email))
                {
                    if (AddUser.Password == null)
                    {
                        MessageBox.Show("Пароль не введен");
                        return;
                    }
                    if (regexPassword.IsMatch(AddUser.Password))
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

                            BackWindow();
                        }
                        else
                            MessageBox.Show("Пароли не совпадают");
                    }
                    else
                        MessageBox.Show("Пароль не соответсвует требованиям");
                }
                else
                    MessageBox.Show("Почта не соответсвует требованиям");
            });

            string directory = Environment.CurrentDirectory;
            SelectImage = new CustomCommand(() =>
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (ofd.ShowDialog() == true)
                {
                    try
                    {
                        var info = new FileInfo(ofd.FileName);
                        ImageBitMap = GetImageFromPath(ofd.FileName);
                        AddUser.Image = $"/Resource/{info.Name}";
                        var newPath = directory.Substring(0, directory.Length ) + AddUser.Image;
                        if(!File.Exists(newPath))
                            File.Copy(ofd.FileName, newPath, true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Код ошибки: Image Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            });

            Back = new CustomCommand(() =>
            {
                BackWindow();
            });
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
        
        private BitmapImage GetImageFromPath(string url)
        {
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.CacheOption = BitmapCacheOption.OnLoad;
            img.UriSource = new Uri(url, UriKind.Absolute);
            img.EndInit();
            return img;
        }

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
