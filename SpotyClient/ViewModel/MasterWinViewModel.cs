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
using System.Windows.Threading;

namespace SpotyClient.ViewModel
{
    public class MasterWinViewModel : Notify
    {
        private object _curentPage;


        public object CurentPage
        {
            get { return _curentPage; }
            set
            {
                _curentPage = value;
                SignalChanged("CurentPage");
            }
        }

        public UserProfile ProfileUser
        {
            get => profileUser;
            set
            {
                profileUser = value;
                SignalChanged("ProfileUser");
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
        public CustomCommand NextTrack { get; set; }
        public CustomCommand LastTrack { get; set; }
        public CustomCommand Exit { get; set; }
        public CustomCommand SingOut { get; set; }
        public CustomCommand MyMediaLibrary { get; set; }
        public CustomCommand Profile { get; set; }
        public CustomCommand Test { get; set; }

        private UserProfile profileUser;
        private Dispatcher dispatcher;
        private Track playingTrack;
        private static List<TrackApi> listTracks1;

        public MasterWinViewModel(Dispatcher dispatcher)
        {

            

            Test = new CustomCommand(() =>
            {
                Test nn = new Test();
                nn.Show();
            });

            SingOut = new CustomCommand(() =>
            {
                SingInWindowViewModel.UsId = 0;
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
                    if (ProfilePageViewModel.test.Count != 0)
                    {
                        listTracks = new List<TrackApi>(ProfilePageViewModel.test);
                        SignalChanged("listTracks");
                    }
                    else if (MyMediaLibraryPageViewModel.test.Count != 0)
                    {
                        listTracks = new List<TrackApi>(MyMediaLibraryPageViewModel.test);
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
                CurentPage = new MainPage();
                SignalChanged("CurentPage");
            });

            Help = new CustomCommand(() =>
            {
                CurentPage = new HelpPage();
                SignalChanged("CurentPage");
            });

            Search = new CustomCommand(() =>
            {
                CurentPage = new SearchPage();
                SignalChanged("CurentPage");
            });

            MyMediaLibrary = new CustomCommand(() =>
            {
                CurentPage = new MyMediaLibraryPage();
                SignalChanged("CurentPage");
            });

            Profile = new CustomCommand(() =>
            {
                CurentPage = new ProfilePage();
                SignalChanged("CurentPage");
            });

            Task.Run(GetUserId);
            this.dispatcher = dispatcher;
            Task.Run(GetTrackId);
        }

        public async Task GetUserId()
        {
            Task.Delay(200).Wait();
            var t = SingInWindowViewModel.UsId;
            var result = await Api.GetAsync<UserApi>(t, "User");
            ProfileUser = UserProfile.GetInstance();
            ProfileUser.UpdateUser(result);
            SignalChanged("ProfileUser");

            dispatcher.Invoke(() => Profile.Execute(null));

            if (SingInWindowViewModel.UsId != 0)
            {
                FailUser();
            }
        }

        #region Костыль для Юзера

        static string path = "c:\\HiddenFolder";
        static string pathUser = "c:\\HiddenFolder\\User.txt";
        public static int Us()
        {
            int result;
            string str = File.ReadAllText(pathUser);
            result = Convert.ToInt32(str);
            return result;
        }

        public void FailUser()
        {

            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }
            var t = SingInWindowViewModel.UsId;
            File.WriteAllText(pathUser, t.ToString());
        }
        #endregion

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
    }
}
