using Enterwell.Clients.Wpf.Notifications;
using ModelsApi;
using SpotyClient.Tools;
using SpotyClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpotyClient.ViewModel
{
    public class MainPageViewModel : Notify
    {
        private AlbumApi selectedAlbum;
        private List<AlbumTrackApi> albumsTrack;
        private List<TrackApi> traks;
        private List<AlbumApi> albums;
        private List<ArtistApi> artists;

        public List<TrackApi> Tracks
        {
            get => traks;
            set
            {
                traks = value;
                SignalChanged("Traks");
            }
        }

        public List<AlbumApi> Albums
        {
            get => albums;
            set
            {
                albums = value;
                SignalChanged("Albums");
            }
        }

        public List<ArtistApi> Artists
        {
            get => artists;
            set
            {
                artists = value;
                SignalChanged("Artists");
            }
        }

        public AlbumApi SelectedAlbum
        {
            get => selectedAlbum;
            set
            {
                selectedAlbum = value;
                SignalChanged();
            }
        }

        public List<AlbumTrackApi> AlbumsTrack
        {
            get => albumsTrack;
            set
            {
                albumsTrack = value;
                SignalChanged("AlbumsTrack");
            }
        }

        public LikesTrackApi AddLikesTrack
        {
            get => addLikesTrack;
            set
            {
                addLikesTrack = value;
                SignalChanged("AddLikesTrack");
            }
        }

        public LikesAlbumApi AddLikesAlbum
        {
            get => addLikesAlbum;
            set
            {
                addLikesAlbum = value;
                SignalChanged("AddLikesAlbum");
            }
        }
        public TrackApi SelectedTrack
        { 
            get => selectedTrack;
            set
            {
                selectedTrack = value;
                SignalChanged();
            }
        }
        public INotificationMessageManager Manager { get; } = new NotificationMessageManager();
        public static Queue<TrackApi> test = new Queue<TrackApi>();
        private LikesTrackApi addLikesTrack;
        private LikesAlbumApi addLikesAlbum;
        private TrackApi selectedTrack;

        public CustomCommand AddLikesAlbumCommand { get; set; }
        public CustomCommand AddLikesTrackCommand { get; set; }
        public CustomCommand AddInAlbum { get; set; }
        public CustomCommand Play { get; set; }
        public CustomCommand PlayAlbum { get; set; }

        public MainPageViewModel()
        {
            Task.Run(GetTrack).Wait();
            Task.Run(GetAlbum).Wait();
            Task.Run(GetArtist).Wait();
            Task.Run(Gets).Wait();

            AddInAlbum = new CustomCommand(() =>
            {
                if (SingInWindowViewModel.UsId != 0)
                {
                    AddTrackInAlbumWindow addTrackIn = new AddTrackInAlbumWindow(SelectedTrack);
                    addTrackIn.ShowDialog();
                    AddTrackInAlbumNotification();
                }
                else if (SingInWindowViewModel.ArtId != 0)
                {
                    AddTrackInAlbumArtistWindow add = new AddTrackInAlbumArtistWindow(SelectedTrack);
                    add.ShowDialog();
                    AddTrackInAlbumNotification();
                }
            });

            PlayAlbum = new CustomCommand(() =>
            {
                try
                {
                    test.Clear();
                    if (SelectedAlbum == null)
                    {
                        MessageBox.Show("Album don't selected");
                    }
                    else
                    {
                        foreach (var al in Albums)
                            if (SelectedAlbum.Id == al.Id)
                                foreach (var altra in AlbumsTrack)
                                    if (al.Id == altra.IdAlbum)
                                        foreach (var track in Tracks)
                                            if (altra.IdTrack == track.Id)
                                                test.Enqueue(track);

                        Components.Track.GetInstance().UpdateTrack(test.Peek());
                    }
                }
                catch
                {
                    MessageBox.Show("Возможно альбом пуст");
                }
            });

            Play = new CustomCommand(() =>
            {
                try
                {
                    if (MasterArtistWindowViewModel.listTracks != null)
                        MasterArtistWindowViewModel.listTracks.Clear();
                    else if (MasterWinViewModel.listTracks != null)
                        MasterWinViewModel.listTracks.Clear();

                    if (test.Count != 0)
                        test.Clear();

                    if (SelectedTrack == null)
                        return;
                    foreach (var track in Tracks)
                    {
                        if (SelectedTrack.Id == track.Id)
                        {
                            Components.Track.GetInstance().UpdateTrack(track);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Простите", "Возникла непредвиденная ошибка, обратитесь к разработчику", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            AddLikesAlbumCommand = new CustomCommand(() =>
            {
                AddLikesAlbum = new LikesAlbumApi
                {
                    IdAlbum = SelectedAlbum.Id,
                    IdUser = SingInWindowViewModel.UsId,
                    Albums = Top2()
                };
                AddAlbumNotification();
                Task.Run(PostLikesAlbum);
            });

            AddLikesTrackCommand = new CustomCommand(() =>
            {
                AddLikesTrack = new LikesTrackApi
                {
                    IdTrack = SelectedTrack.Id,
                    IdUser = SingInWindowViewModel.UsId,
                    traksL = Top()
                };
                AddTrackNotification();
                Task.Run(PostLikesTrak);
            });
        }


        public async Task GetTrack()
        {
            var result = await Api.GetListAsync<TrackApi[]>("Track");
            Tracks = new List<TrackApi>(result);
            SignalChanged("Traks");
        }

        public async Task PostLikesTrak()
        {
            await Api.PostAsync<LikesTrackApi>(AddLikesTrack, "LikesTrack");
        }

        public async Task PostLikesAlbum()
        {
            await Api.PostAsync<LikesAlbumApi>(AddLikesAlbum, "LikesAlbum");
        }

        public async Task GetArtist()
        {
            var result = await Api.GetListAsync<ArtistApi[]>("Artist");
            Artists = new List<ArtistApi>(result);
            SignalChanged("Artists");
        }

        public async Task Gets()
        {
            var result = await Api.GetListAsync<AlbumTrackApi[]>("AlbumTrack");
            AlbumsTrack = new List<AlbumTrackApi>(result);
            SignalChanged("AlbumTrack");
        }

        public async Task GetAlbum()
        {
            var result1 = await Api.GetListAsync<AlbumApi[]>("Album");
            Albums = new List<AlbumApi>(result1);
            SignalChanged("Albums");
        }

        public TrackApi Top()
        {
            TrackApi result = null;
            foreach (var track in Tracks)
                if (SelectedTrack.Id == track.Id)
                    result = track;
            return result;
        }

        public AlbumApi Top2()
        {
            AlbumApi result = null;
            foreach (var album in Albums)
                if (SelectedAlbum.Id == album.Id)
                    result = album;
            return result;
        }

        public void AddTrackInAlbumNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#327d0b")
                .Background("#48a818")
                .HasMessage("Трек успешно добавлен в альбом.")
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
        }
        public void ErrorNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#700d04")
                .Background("#bf1a0b")
                .HasMessage("Непредвиденная ошибка")
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
        }
        public void AddTrackNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#327d0b")
                .Background("#48a818")
                .HasMessage("Трек успешно добавлен.")
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
        }
        public void AddAlbumNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#327d0b")
                .Background("#48a818")
                .HasMessage("Альбом успешно добавлен.")
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
        }

    }
}
