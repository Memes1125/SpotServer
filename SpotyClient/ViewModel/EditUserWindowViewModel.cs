using Microsoft.Win32;
using ModelsApi;
using SpotyClient.Components;
using SpotyClient.Tools;
using SpotyClient.View;
using SpotyClient.View.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace SpotyClient.ViewModel
{
    public class EditUserWindowViewModel : Notify
    {
        private BitmapImage image;
        public BitmapImage Image 
        { 
            get => image;
            set 
            {
                image = value;
                SignalChanged("Image");
            } 
        }

        public UserApi EditUser { get; set; }
        public CustomCommand SelectImage { get; set; }
        public CustomCommand SaveUser { get; set; }

        public EditUserWindowViewModel()
        {
            Task.Run(GetUserId);

            SaveUser = new CustomCommand(() =>
            {
                Task.Run(EditUsers);
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                    {
                        
                        CloseWin(window);
                    }
                }
                
            });

            string directory = Environment.CurrentDirectory;
            SelectImage = new CustomCommand(() =>
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == true)
                {
                    try
                    {
                        var info = new FileInfo(ofd.FileName);
                        Image = GetImageFromPath(ofd.FileName);
                        EditUser.Image = $"/Resource/{info.Name}";
                        var newPath = directory.Substring(0, directory.Length) + EditUser.Image;
                        if (!File.Exists(newPath))
                            File.Copy(ofd.FileName, newPath, true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Код ошибки: Image Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            });
        }

        public void CloseWin(object obj)
        {
            Window win = obj as Window;
            win.Close();
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

        public async Task EditUsers()
        {
            await Api.PutAsync<UserApi>(EditUser, "User");
            UserProfile.GetInstance().UpdateUser(EditUser);
        }

        public async Task GetUserId()
        {
            var t = SingInWindowViewModel.UsId;
            var result = await Api.GetAsync<UserApi>(t, "User");
            EditUser = result;
            SignalChanged("EditUser");
        }

        
        
    }
}
