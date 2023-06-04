using Enterwell.Clients.Wpf.Notifications;
using ModelsApi;
using SpotyClient.Components;
using SpotyClient.Tools;
using SpotyClient.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SpotyClient.ViewModel
{
    public class SearchPageViewModel : Notify
    {
        private List<TrackApi> traks;
        private TrackApi selectedTrak;
        private LikesTrackApi addLikesTrack;
        private List<AlbumApi> albums;
        private LikesAlbumApi addLikesAlbum;
        private AlbumApi selectedAlbum;
        private AlbumApi album;

        private string searchTrack = "";
        public string SearchTrack
        {
            get => searchTrack;
            set
            {
                searchTrack = value;
                SearchTrackMethod();
            }
        }



        private string searchAlbum = "";
        public string SearchAlbum
        {
            get => searchAlbum;
            set
            {
                searchAlbum = value;
                SearchAlbumMethod();
            }
        }



        public List<TrackApi> Traks
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

        public TrackApi SelectedTrak
        {
            get => selectedTrak;
            set
            {
                selectedTrak = value;
                SignalChanged();
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

        public List<LikesAlbumApi> LikesAlbumL
        {
            get => likesAlbum;
            set
            {
                likesAlbum = value;
                SignalChanged("LikesAlbum");
            }
        }
        public List<LikesTrackApi> LikesTrackL
        {
            get => likesTrack;
            set
            {
                likesTrack = value;
                SignalChanged("LikesTrack");
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

        public ObservableCollection<string> TracksItems { get; set; }
        public ObservableCollection<string> AlbumsItems { get; set; }
        public INotificationMessageManager Manager { get; } = new NotificationMessageManager();
        public static Queue<TrackApi> test = new Queue<TrackApi>();
        public Track PlayingTrack { get; set; }
        public List<TrackApi> searchResultTrack;
        public List<AlbumApi> searchResultAlbum;
        private List<LikesAlbumApi> likesAlbum;
        private List<LikesTrackApi> likesTrack;
        private List<AlbumTrackApi> albumsTrack;

        public List<TrackApi> mysearchTrack { get; set; }
        public List<AlbumApi> mysearchAlbum { get; set; }
        public CustomCommand AddInAlbum { get; set; }
        public CustomCommand PlayAlbum { get; set; }
        public CustomCommand Play { get; set; }
        public CustomCommand AddLikes { get; set; }
        public CustomCommand AddLikesAlbumCommand { get; set; }

        public SearchPageViewModel()
        {
            Task.Run(GetTacks);
            Task.Run(GetAlbums);
            Task.Run(Gets);
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

                    if (SelectedTrak == null)
                        return;
                    foreach (var trackqwqw in Traks)
                    {
                        if (SelectedTrak.Id == trackqwqw.Id)
                        {
                            Components.Track.GetInstance().UpdateTrack(trackqwqw);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Простите", "Возникла непредвиденная ошибка, обратитесь к разработчику", MessageBoxButton.OK, MessageBoxImage.Error);
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
                                        foreach (var track in Traks)
                                            if (altra.IdTrack == track.Id)
                                                test.Enqueue(track);

                        Components.Track.GetInstance().UpdateTrack(test.Peek());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Возможно альбом пуст \n ");
                }
            });

            AddInAlbum = new CustomCommand(() =>
            {
                if (SingInWindowViewModel.UsId != 0)
                {
                    AddTrackInAlbumWindow addTrackIn = new AddTrackInAlbumWindow(SelectedTrak);
                    addTrackIn.ShowDialog();
                    AddTrackInAlbumNotification();
                }
                else if (SingInWindowViewModel.ArtId != 0)
                {
                    AddTrackInAlbumArtistWindow add = new AddTrackInAlbumArtistWindow(SelectedTrak);
                    add.ShowDialog();
                    AddTrackInAlbumNotification();
                }
            });

            AddLikes = new CustomCommand(() =>
            {
                AddLikesTrack = new LikesTrackApi
                {
                    IdTrack = SelectedTrak.Id,
                    IdUser = SingInWindowViewModel.UsId,
                    traksL = Top()
                };
                AddTrackNotification();
                Task.Run(PostLikesTrak);
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
        }

        public async Task GetTacks()
        {
            var result4 = await Api.GetListAsync<TrackApi[]>("Track");
            Traks = new List<TrackApi>(result4);
            SignalChanged("Traks");

            TracksItems = new ObservableCollection<string>();
            foreach (var a in Traks)
            {
                TracksItems.Add(a.Name.ToLower());
                TracksItems.Add(a.Name);
            }
            SignalChanged("TracksItems");

            searchResultTrack = new List<TrackApi>(Traks);
            mysearchTrack = new List<TrackApi>(Traks);
        }

        public async Task GetAlbums()
        {
            var result = await Api.GetListAsync<AlbumApi[]>("Album");
            Albums = new List<AlbumApi>(result);
            SignalChanged("Album");

            AlbumsItems = new ObservableCollection<string>();
            foreach (var a in Albums)
            {
                AlbumsItems.Add(a.Name.ToLower());
                AlbumsItems.Add(a.Name);
            }
            SignalChanged("AlbumsItems");

            searchResultAlbum = new List<AlbumApi>(Albums);
            mysearchAlbum = new List<AlbumApi>(Albums);
        }

        public async Task Gets()
        {
            var result = await Api.GetListAsync<AlbumTrackApi[]>("AlbumTrack");
            AlbumsTrack = new List<AlbumTrackApi>(result);
            SignalChanged("AlbumTrack");
        }

        public TrackApi Top()
        {
            TrackApi result = null;
            foreach (var track in Traks)
                if (SelectedTrak.Id == track.Id)
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

        public async Task PostLikesTrak()
        {
            await Api.PostAsync<LikesTrackApi>(AddLikesTrack, "LikesTrack");
        }

        public async Task PostLikesAlbum()
        {
            await Api.PostAsync<LikesAlbumApi>(AddLikesAlbum, "LikesAlbum");
        }

        private void SearchTrackMethod()
        {
            var searchTrack = SearchTrack.ToLower();
            searchResultTrack = mysearchTrack.Where(c => c.Name.ToLower().Contains(searchTrack)).ToList();

            Traks = searchResultTrack;
            SignalChanged(nameof(Traks));
        }

        private void SearchAlbumMethod()
        {
            var searchAlbum = SearchAlbum.ToLower();
            searchResultAlbum = mysearchAlbum.Where(c => c.Name.ToLower().Contains(searchAlbum)).ToList();

            Albums = searchResultAlbum;
            SignalChanged(nameof(Albums));
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
