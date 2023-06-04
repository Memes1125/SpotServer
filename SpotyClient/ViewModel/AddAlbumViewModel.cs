using Microsoft.Win32;
using ModelsApi;
using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        
        private UserApi userId;
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
        public List<UserAlbumApi> albums { get; set; }
        public List<AlbumsArtistApi> albumsArtist { get; set; }
        public AlbumApi AddAlbum { get; set; }
        public CustomCommand Back { get; set;  }
        public CustomCommand Exit { get; set; }
        public CustomCommand SelectImage { get; set; }
        public CustomCommand SaveAlbum { get; set; }
        public UserApi UserId
        { 
            get => userId;
            set 
            {
                userId = value;
                SignalChanged("UserId");
            } 
        }


        public AddAlbumViewModel(AlbumApi album)
        {
            Task.Run(GetListAlbums);
            Task.Run(GetListArtistAlbums);

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

            Back = new CustomCommand(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });

            Exit = new CustomCommand(()=>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });

            SaveAlbum = new CustomCommand(() =>
            {
                if (AddAlbum.Id == 0)
                {
                    try
                    {
                        if(AddAlbum.Name != null && AddAlbum.Image != null)
                        {
                            Task.Run(CreateNewAlbum);
                            Thread.Sleep(300);
                            Load();
                        }
                        else
                        {
                            MessageBox.Show("Код ошибки: Value Error; \nНе все данные были введены", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Код ошибки: Value Error; \nПроверьте заполненность данных!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    Task.Run(EditAlbums);
                    Thread.Sleep(300);
                    Load();
                }

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
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
            var result = await Api.GetListAsync<UserAlbumApi[]>("UserAlbum");
            albums = new List<UserAlbumApi>(result);
            SignalChanged("albums");
        }

        public async Task GetListArtistAlbums()
        {
            var result = await Api.GetListAsync<AlbumsArtistApi[]>("AlbumsArtist");
            albumsArtist = new List<AlbumsArtistApi>(result);
            SignalChanged("albumsArtist");
        }


        public void Load()
        {
            Task.Run(GetListAlbums);
        }
    }
}
