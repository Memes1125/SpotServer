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
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpotyClient.ViewModel
{
    public class AddTrackViewModel : Notify
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
        private MediaElement track1;
        public MediaElement Track1
        { 
            get => track1; 
            set
            {
                track1 = value;
                SignalChanged("Track1");
            }
        }

        public List<ArtistsTrakApi> tracks { get; set; }
        public TrackApi AddTrack { get; set; }
        public CustomCommand Back { get; set; }
        public CustomCommand SaveTrack { get; set; }
        public CustomCommand SelectImage { get; set; }
        public CustomCommand SelectTrack { get; set; }

        public AddTrackViewModel(TrackApi track)
        {

            if (SingInWindowViewModel.ArtId != 0)
            {
                Task.Run(GetListTracks);
                FailArtist();
            }

            if (track == null)
            {
                AddTrack = new TrackApi();
            }
            else
            {
                AddTrack = new TrackApi
                {
                    Id = track.Id,
                    Name = track.Name,
                    Image = track.Image,
                    Duration = track.Duration,
                    Track1 = track.Track1
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

            SaveTrack = new CustomCommand(() =>
            {

                if (AddTrack.Id == 0)
                {
                    try
                    {
                        if (AddTrack.Name != null && AddTrack.Image != null)
                        {
                            Task.Run(CreateNewTrack);
                            Thread.Sleep(200);
                            Task.Run(GetListTracks);
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
                    Task.Run(EditTracks);
                    Thread.Sleep(200);
                    Task.Run(GetListTracks);
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
                        AddTrack.Image = $"/Resource/{info.Name}";
                        var newPath = directory.Substring(0, directory.Length) + AddTrack.Image;
                        if (!File.Exists(newPath))
                            File.Copy(ofd.FileName, newPath, true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Код ошибки: Image Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            });


            SelectTrack = new CustomCommand(() =>
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == true)
                {
                    try
                    {
                        var info = new FileInfo(ofd.FileName);
                        Track1 = GetTrackFromPath(ofd.FileName);
                        AddTrack.Track1 = $"/Resource/{info.Name}";
                        var newPath = directory.Substring(0, directory.Length) + AddTrack.Track1;
                        if (!File.Exists(newPath))
                            File.Copy(ofd.FileName, newPath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Код ошибки: File Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            });
        }

        private MediaElement GetTrackFromPath(string url)
        {
            MediaElement track = new MediaElement();
            track.BeginInit();
            track.LoadedBehavior = MediaState.Manual;
            track.Source = new Uri(url, UriKind.Absolute);
            track.EndInit();
            return track;
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

        #region Костыль для Артиста
        static string path = "D:\\HiddenFolder";
        static string path2 = "D:\\HiddenFolder\\Artist.txt";
        

        public static int UsArtist()
        {
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
            }
            int result;
            string str = File.ReadAllText(path2);
            result = Convert.ToInt32(str);
            return result;
        }

        public void FailArtist()
        {
            var t = SingInWindowViewModel.ArtId;
            File.WriteAllText(path2, t.ToString());
        }
        #endregion

        public async Task EditTracks()
        {
            await Api.PutAsync<TrackApi>(AddTrack, "Track");
        }

        public async Task CreateNewTrack()
        {
            await Api.PostAsync<TrackApi>(AddTrack, "Track");
        }

        public async Task GetListTracks()
        {
            var result = await Api.GetListAsync<ArtistsTrakApi[]>("ArtistsTrak");
            tracks = new List<ArtistsTrakApi>(result);
            SignalChanged("tracks");
        }
    }
}
