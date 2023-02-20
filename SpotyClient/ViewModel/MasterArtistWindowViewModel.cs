using ModelsApi;
using SpotyClient.Components;
using SpotyClient.Tools;
using SpotyClient.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ArtistProfile ProfileArtist
        {
            get => profileArtist;
            set
            {
                profileArtist = value;
                SignalChanged("ProfileArtist");
            }
        }
        public CustomCommand Main { get; set; }
        public CustomCommand Help { get; set; }
        public CustomCommand Search { get; set; }
        public CustomCommand MyMediaLibrary { get; set; }
        public CustomCommand Profile { get; set; }

        private ArtistProfile profileArtist;
        private Dispatcher dispatcher;

        public MasterArtistWindowViewModel(Dispatcher dispatcher)
        {
            Main = new CustomCommand(() =>
            {
                CurentPageArt = new MainPage();
                SignalChanged("CurentPage");
            });

            Help = new CustomCommand(() =>
            {
                CurentPageArt = new HelpPage();
                SignalChanged("CurentPage");
            });

            Search = new CustomCommand(() =>
            {
                CurentPageArt = new SearchPage();
                SignalChanged("CurentPage");
            });

            MyMediaLibrary = new CustomCommand(() =>
            {
                CurentPageArt = new MyMediaLibraryPage();
                SignalChanged("CurentPage");
            });

            Profile = new CustomCommand(() =>
            {
                CurentPageArt = new ProfileArtistPage();
                SignalChanged("CurentPage");
            });

            Task.Run(GetArtistId);
            this.dispatcher = dispatcher;
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
    }
}
