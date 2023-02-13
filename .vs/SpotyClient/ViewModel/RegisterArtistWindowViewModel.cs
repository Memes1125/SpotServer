using Microsoft.Win32;
using ModelsApi;
using SpotyClient.Tools;
using SpotyClient.View;
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
    public class RegisterArtistWindowViewModel : Notify
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

        public List<ArtistApi> artists { get; set; }
        public ArtistApi AddArtist { get; set; }
        public CustomCommand SaveArtist { get; set; }
        public CustomCommand SelectImage { get; set; }
        public CustomCommand Back { get; set; }
        public string PasswordConfirm { get; set; }



        public RegisterArtistWindowViewModel(ArtistApi artist)
        {
            Task.Run(GetListArtists);

            if (artist == null)
            {
                AddArtist = new ArtistApi();
            }
            else
            {
                AddArtist = new ArtistApi
                {
                    Id = artist.Id,
                    Email = artist.Email,
                    Name = artist.Name,
                    Password = artist.Password,
                    Image = artist.Image
                };
            }

            SaveArtist = new CustomCommand(() =>
            {
                if (AddArtist.Password == PasswordConfirm)
                {
                    if (AddArtist.Id == 0)
                    {
                        Task.Run(CreateNewArtist);
                        Thread.Sleep(200);
                        Task.Run(GetListArtists);
                    }
                    else
                        Task.Run(EditArtists);

                    BackWindow();
                }
                else
                    MessageBox.Show("Чёт с паролем не так");
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
                        AddArtist.Image = $"/Resource/{info.Name}";
                        var newPath = directory.Substring(0, directory.Length) + AddArtist.Image;
                        if (!File.Exists(newPath))
                            File.Copy(ofd.FileName, newPath, true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Код ошибки: Image Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error); ;
                    }
                }

            });

            Back = new CustomCommand(() =>
            {
                BackWindow();
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

        public void BackWindow()
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                    CloseWin(window);
            }
        }


        public void CloseWin(object obj)
        {
            Window win = obj as Window;
            win.Close();
        }

        public async Task EditArtists()
        {
            await Api.PutAsync<ArtistApi>(AddArtist, "Artist");
        }

        public async Task CreateNewArtist()
        {
            await Api.PostAsync<ArtistApi>(AddArtist, "Artist");
        }

        public async Task GetListArtists()
        {
            var result = await Api.GetListAsync<ArtistApi[]>("Artist");
            artists = new List<ArtistApi>(result);
            SignalChanged("artists");
        }
    }
}
