using Enterwell.Clients.Wpf.Notifications;
using ModelsApi;
using SpotyClient.Tools;
using SpotyClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SpotyClient.ViewModel
{
    public class MyMediaLibraryPageViewModel : Notify
    {
        private List<LikesTrackApi> userTracks;
        private List<TrackApi> traks;
        private List<ArtistsTrakApi> artistsTrack;
        private List<AlbumApi> albums;
        private List<ArtistApi> artist;
        private List<AlbumTrackApi> albumsTrack;
        private List<LikesAlbumApi> likesAlbums;
        private LikesTrackApi selectedUserTrack;
        private LikesAlbumApi selectedLikesAlbum;
        

        public List<LikesTrackApi> UserTracks
        {
            get => userTracks;
            set
            {
                userTracks = value;
                SignalChanged("UserTracks");
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

        public List<ArtistApi> Artist
        {
            get => artist;
            set
            {
                artist = value;
                SignalChanged("Artist");
            }
        }

        public List<ArtistsTrakApi> ArtistsTrack
        {
            get => artistsTrack;
            set
            {
                artistsTrack = value;
                SignalChanged("ArtistsTrack");
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

        public List<AlbumTrackApi> AlbumsTrack
        {
            get => albumsTrack;
            set
            {
                albumsTrack = value;
                SignalChanged("AlbumsTrack");
            }
        }

        public List<LikesAlbumApi> LikesAlbums
        {
            get => likesAlbums;
            set
            {
                likesAlbums = value;
                SignalChanged("LikesAlbums");
            }
        }

        public LikesTrackApi SelectedUserTrack
        {
            get => selectedUserTrack;
            set
            {
                selectedUserTrack = value;
                SignalChanged();
            }
        }
        public LikesAlbumApi SelectedLikesAlbum
        {
            get => selectedLikesAlbum;
            set
            {
                selectedLikesAlbum = value;
                SignalChanged();
            }
        }

        public static Queue<TrackApi> test = new Queue<TrackApi>();
        public INotificationMessageManager Manager { get; } = new NotificationMessageManager();
        public int Number { get; set; }
        public UserApi User { get; set; }
        public CustomCommand DeleteTrack { get; set; }
        public CustomCommand DeleteAlbum { get; set; }
        public CustomCommand AddInAlbum { get; set; }
        public CustomCommand PlayAlbum { get; set; }
        public CustomCommand Play { get; set; }
        public CustomCommand Update { get; set; }

        public MyMediaLibraryPageViewModel()
        {
            Update = new CustomCommand(() =>
            {
                Task.Run(GetLikesTrack);
                Task.Run(GetLikesAlbum);
            });
            Task.Run(GetUserId);
            Thread.Sleep(300);
            Task.Run(GetLikesTrack);
            Task.Run(GetLikesAlbum);
            Task.Run(GetAlbumsTrack);


            AddInAlbum = new CustomCommand(() =>
            {

                if (SingInWindowViewModel.UsId != 0)
                {
                    AddTrackInAlbumWindow add = new AddTrackInAlbumWindow();
                    add.ShowDialog();
                    AddTrackInAlbumNotification();
                }
            });

            Play = new CustomCommand(() =>
            {
                try
                {
                    if (MasterWinViewModel.listTracks != null)
                        MasterWinViewModel.listTracks.Clear();

                    if (test.Count != 0)
                        test.Clear();
                    if (SelectedUserTrack == null)
                        return;
                    foreach (var trackqwqw in Traks)
                    {
                        if (SelectedUserTrack.IdTrack == trackqwqw.Id)
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

            DeleteAlbum = new CustomCommand(() =>
            {
                MessageBoxResult result = MessageBox.Show("Удалить альбом?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Task.Run(DeleteLikesAlbum);
                        DeleteAlbumNotification();
                        Thread.Sleep(200);
                        Task.Run(GetLikesAlbum);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Упс, произошли технические шоколадки");
                    }
                }
                else return;
            });

            DeleteTrack = new CustomCommand(() =>
            {
                MessageBoxResult result = MessageBox.Show("Удалить трек?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Task.Run(DeleteLikesTrack);
                        DeleteTrackNotification();
                        Thread.Sleep(200);
                        Task.Run(GetLikesTrack);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Упс, произошли технические шоколадки");
                    }
                }
                else return;
            });

            PlayAlbum = new CustomCommand(() =>
            {
                try
                {
                    test.Clear();
                    if (SelectedLikesAlbum == null)
                    {
                        MessageBox.Show("Album don't selected");
                    }
                    else
                    {
                        foreach (var al in Albums)
                            if (SelectedLikesAlbum.IdAlbum == al.Id)
                                foreach (var altra in AlbumsTrack)
                                    if (al.Id == altra.IdAlbum)
                                        foreach (var track in Traks)
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
        }

        public async Task GetUserId()
        {
            var t = SingInWindowViewModel.UsId;
            var result = await Api.GetAsync<UserApi>(t, "User");
            User = result;
            SignalChanged("User");
        }

        public async Task GetLikesTrack()
        {
            var result = await Api.GetListAsync<LikesTrackApi[]>("LikesTrack");
            UserTracks = new List<LikesTrackApi>(result);
            SignalChanged("UserTracks");

            var result2 = await Api.GetListAsync<TrackApi[]>("Track");
            Traks = new List<TrackApi>(result2);
            SignalChanged("Traks");

            #region артист и альбом
            //var result3 = await Api.GetListAsync<ArtistsTrakApi[]>("ArtistsTrak");
            //ArtistsTrack = new List<ArtistsTrakApi>(result3);
            //SignalChanged("ArtistsTrack");

            //var result4 = await Api.GetListAsync<ArtistApi[]>("Artist");
            //Artist = new List<ArtistApi>(result4);
            //SignalChanged("Artist");

            //var result5 = await Api.GetListAsync<AlbumTrackApi[]>("AlbumTrack");
            //AlbumsTrack = new List<AlbumTrackApi>(result5);
            //SignalChanged("AlbumsTrack");

            //var result6 = await Api.GetListAsync<AlbumApi[]>("Album");
            //Albums = new List<AlbumApi>(result6);
            //SignalChanged("Albums");
            #endregion

            foreach (var userTrack in UserTracks)
            {
                if (userTrack.traksL == null)
                    userTrack.traksL = Traks.First(s => s.Id == userTrack.IdTrack);
                else
                    userTrack.traksL = userTrack.traksL;

                #region артист и альбом
                //foreach (var idArtistForTrack in ArtistsTrack)
                //{
                //    if (idArtistForTrack.IdTrack == userTrack.IdTrack)
                //    {
                //        foreach (var artistQ in Artist)
                //        {
                //            if (idArtistForTrack.IdArtist == artistQ.Id)
                //            {
                //                userTrack.artistL = artistQ;
                //            }
                //        }
                //    }
                //}

                //foreach (var idAlbumForTrack in AlbumsTrack)
                //{
                //    if (idAlbumForTrack.IdTrack == userTrack.IdTrack)
                //    {
                //        foreach (var albumQ in Albums)
                //        {
                //            if (idAlbumForTrack.IdAlbum == albumQ.Id)
                //            {
                //                userTrack.albumL = albumQ;
                //                albumL = albumQ;
                //                Thread.Sleep(1000);
                //            }
                //        }
                //    }
                //}
                #endregion
            }


            foreach (var tra in UserTracks.ToArray())
            {

                if (tra.IdUser != SingInWindowViewModel.UsId)
                {
                    UserTracks.Remove(tra);
                    SignalChanged("UserTracks");
                }

            }
        }

        public async Task GetLikesAlbum()
        {
            var result = await Api.GetListAsync<LikesAlbumApi[]>("LikesAlbum");
            LikesAlbums = new List<LikesAlbumApi>(result);
            SignalChanged("LikesAlbums");

            var result6 = await Api.GetListAsync<AlbumApi[]>("Album");
            Albums = new List<AlbumApi>(result6);
            SignalChanged("Albums");

            foreach (var userAlbum in LikesAlbums)
            {
                if (userAlbum.Albums == null)
                    userAlbum.Albums = Albums.First(s => s.Id == userAlbum.IdAlbum);
                else
                    userAlbum.Albums = userAlbum.Albums;
            }

            foreach (var alb in LikesAlbums.ToArray())
            {
                if (alb.IdUser != SingInWindowViewModel.UsId)
                {
                    LikesAlbums.Remove(alb);
                    SignalChanged("LikesAlbums");
                }
            }
        }

        public async Task GetAlbumsTrack()
        {
            var result = await Api.GetListAsync<AlbumTrackApi[]>("AlbumTrack");
            AlbumsTrack = new List<AlbumTrackApi>(result);
            SignalChanged("AlbumTrack");

            var result2 = await Api.GetListAsync<TrackApi[]>("Track");
            Traks = new List<TrackApi>(result2);
            SignalChanged("Tracks");
        }

        public async Task DeleteLikesAlbum()
        {
            await Api.DeleteAsync<LikesAlbumApi>(SelectedLikesAlbum, "LikesAlbum");
        }

        public async Task DeleteLikesTrack()
        {
            await Api.DeleteAsync<LikesTrackApi>(SelectedUserTrack, "LikesTrack");
        }


        public void DeleteAlbumNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#700d04")
                .Background("#bf1a0b")
                .HasMessage("Альбом успешно удалён.")
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
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
        public void DeleteTrackNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#700d04")
                .Background("#bf1a0b")
                .HasMessage("Трек успешно удалён.")
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
    }
}
