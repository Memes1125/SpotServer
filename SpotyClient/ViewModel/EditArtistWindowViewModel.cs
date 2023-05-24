using Microsoft.Win32;
using ModelsApi;
using SpotyClient.Components;
using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SpotyClient.ViewModel
{
    public class EditArtistWindowViewModel : Notify
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

        public ArtistApi EditArtist { get; set; }
        public CustomCommand SelectImage { get; set; }
        public CustomCommand SaveArtist { get; set; }

        public EditArtistWindowViewModel()
        {
            Task.Run(GetArtistId);

            SaveArtist = new CustomCommand(() =>
            {
                Task.Run(EditArtists);
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
                        EditArtist.Image = $"/Resource/{info.Name}";
                        var newPath = directory.Substring(0, directory.Length) + EditArtist.Image;
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

        public async Task EditArtists()
        {
            await Api.PutAsync<ArtistApi>(EditArtist, "Artist");
            ArtistProfile.GetInstance().UpdateArtist(EditArtist);
        }

        public async Task GetArtistId()
        {
            var t = SingInWindowViewModel.ArtId;
            var result = await Api.GetAsync<ArtistApi>(t, "Artist");
            EditArtist = result;
            SignalChanged("EditArtist");
        }
    }
}
