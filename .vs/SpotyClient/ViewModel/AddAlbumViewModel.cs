using Microsoft.Win32;
using ModelsApi;
using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SpotyClient.ViewModel
{
    public class AddAlbumViewModel : Notify
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
        public List<UserApi> users { get; set; }
        public List<AlbumApi> albums { get; set; }
        public AlbumApi AddAlbum { get; set; }
        public CustomCommand SelectImage { get; set; }
        public CustomCommand SaveAlbum { get; set; }

        public AddAlbumViewModel(AlbumApi album)
        {
            Task.Run(GetListAlbums);
            

            if (album == null)
            {
                AddAlbum = new AlbumApi();
            }
            else
            {
                AddAlbum = new AlbumApi
                {
                    Id = album.Id,
                    Name = album.Name,
                    Image = album.Image
                };
            }

            SaveAlbum = new CustomCommand(() =>
            {
                
                if (AddAlbum.Id == 0)
                {
                    Task.Run(CreateNewAlbum);
                    Thread.Sleep(200);
                    Task.Run(GetListAlbums);
                    Thread.Sleep(200);
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.DataContext == this)
                            CloseWin(window);
                    }
                }
                else
                    Task.Run(EditAlbums);
                
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
                        AddAlbum.Image = $"/Resource/{info.Name}";
                        var newPath = directory.Substring(0, directory.Length) + AddAlbum.Image;
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


        public async Task EditAlbums()
        {
            await Api.PutAsync<AlbumApi>(AddAlbum, "Album");
        }

        public async Task CreateNewAlbum()
        {
            await Api.PostAsync<AlbumApi>(AddAlbum, "Album");
        }

        public async Task GetListAlbums()
        {
            var result = await Api.GetListAsync<AlbumApi[]>("Album");
            albums = new List<AlbumApi>(result);
            SignalChanged("albums");
        }

        public async Task GetListUsers()
        {
            var result = await Api.GetListAsync<UserApi[]>("User");
            users = new List<UserApi>(result);
            SignalChanged("users");
        }
    }
}
