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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SpotyClient.ViewModel
{
    public class MasterArtistWindowViewModel : Notify
    {
        private object _curentPageArt;

        public object CurentPageArt
        {
            get { return _curentPageArt; }
            set
            {
                _curentPageArt = value;
                SignalChanged("CurentPageArt");
            }
        }


        public Track PlayingTrack
        {
            get => playingTrack;
            set
            {
                playingTrack = value;
                SignalChanged("PlayingTrack");
            }
        }
        
        public ArtistProfile ProfileArtist
        {
            get => profileArtist;
            set
            {
                profileArtist = value;
                SignalChanged("ProfileArtist");
            }
        }
        private static List<TrackApi> listTracks1;
        public static List<TrackApi> listTracks
        {
            get => listTracks1;
            set
            {
                listTracks1 = value;
                
            }
        }
        public int index = 0;
        public CustomCommand Main { get; set; }
        public CustomCommand Help { get; set; }
        public CustomCommand Search { get; set; }
        public CustomCommand MyMediaLibrary { get; set; }
        public CustomCommand NextTrack { get; set; }
        public CustomCommand LastTrack { get; set; }
        public CustomCommand Profile { get; set; }
      
        public CustomCommand SingOut { get; set; }
        public CustomCommand Exit { get; set; }
        public CustomCommand Play { get; set; }

        private ArtistProfile profileArtist;
        private Dispatcher dispatcher;
        private Track playingTrack;

        public MasterArtistWindowViewModel(Dispatcher dispatcher)
        {
            if (SingInWindowViewModel.ArtId != 0)
            {
                FailArtist();
            }

            SingOut = new CustomCommand(() =>
            {
                SingInWindowViewModel.ArtId = 0;
                MainWindow mw = new MainWindow();
                mw.Show();
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });

            

            NextTrack = new CustomCommand(() =>
            {
                try
                {
                    if (ProfileArtistPageViewModel.test.Count != 0)
                    {
                        listTracks = new List<TrackApi>(ProfileArtistPageViewModel.test);
                        SignalChanged("listTracks");
                    }
                    else if (SearchPageViewModel.test.Count != 0)
                    {
                        listTracks = new List<TrackApi>(SearchPageViewModel.test);
                        SignalChanged("listTracks");
                    }
                    else if (MainPageViewModel.test.Count != 0)
                    {
                        listTracks = new List<TrackApi>(MainPageViewModel.test);
                        SignalChanged("listTracks");
                    }

                    if (index < listTracks.Count - 1)
                    {
                        index++;
                        UpdateInfo();
                    }
                }
                catch { }
                
            });

            LastTrack = new CustomCommand(() =>
            {
                if (index > 0)
                {
                    index--;
                    UpdateInfo();
                }
            });

            Exit = new CustomCommand(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });

            Main = new CustomCommand(() =>
            {
                CurentPageArt = new MainPage();
                SignalChanged("CurentPageArt");
            });

            Help = new CustomCommand(() =>
            {
                CurentPageArt = new HelpPage();
                SignalChanged("CurentPageArt");
            });

            Search = new CustomCommand(() =>
            {
                CurentPageArt = new SearchPage();
                SignalChanged("CurentPageArt");
            });

            MyMediaLibrary = new CustomCommand(() =>
            {
                CurentPageArt = new MyMediaLibraryPage();
                SignalChanged("CurentPageArt");
            });

            Profile = new CustomCommand(() =>
            {
                CurentPageArt = new ProfileArtistPage();
                SignalChanged("CurentPageArt");
            });

            Play = new CustomCommand(() =>
            {

            });

            Task.Run(GetArtistId);
            this.dispatcher = dispatcher;
            Task.Run(GetTrackId);
            //timer.Interval = TimeSpan.FromSeconds(0.1);
            //timer.Tick += TimerTick;
        }


        public async Task GetArtistId()
        {
            Task.Delay(200).Wait();
            var t = SingInWindowViewModel.ArtId;
            var result = await Api.GetAsync<ArtistApi>(t, "Artist");
            ProfileArtist = ArtistProfile.GetInstance();
            ProfileArtist.UpdateArtist(result);
            SignalChanged("ProfileArtist");

            dispatcher.Invoke(() => Profile.Execute(null));
        }

        public async Task GetTrackId()
        {
            Task.Delay(200).Wait();
            PlayingTrack = Track.GetInstance();
            SignalChanged("PlayingTrack");
        }

        public void CloseWin(object obj)
        {
            Window win = obj as Window;
            win.Close();
        }

        public void UpdateInfo()
        {
            try
            {
                TrackApi api = listTracks[index];
                Components.Track.GetInstance().UpdateTrack(api);
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
            
        }

        #region Костыль для Артиста
        static string path = "c:\\HiddenFolder";
        static string pathArtist = "c:\\HiddenFolder\\Artist.txt";
        

        public static int UsArtist()
        {

            int result;
            string str = File.ReadAllText(pathArtist);
            result = Convert.ToInt32(str);
            return result;
        }

        public void FailArtist()
        {

            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            var t = SingInWindowViewModel.ArtId;
            File.WriteAllText(pathArtist, t.ToString());
        }
        #endregion
    }
}
