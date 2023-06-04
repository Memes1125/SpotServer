using Enterwell.Clients.Wpf.Notifications;
using ModelsApi;
using SpotyClient.Components;
using SpotyClient.Tools;
using SpotyClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SpotyClient.ViewModel
{
    public class ProfileArtistPageViewModel : Notify
    {

        private AlbumsArtistApi selectedAlbumsArtist;
        private List<AlbumApi> albums;
        private List<AlbumsArtistApi> albumsArtist;
        private List<ArtistsTrakApi> artistTracks;
        private List<TrackApi> traks;
        private ArtistsTrakApi selectedTrack;

        public AlbumsArtistApi SelectedAlbumsArtist
        {
            get => selectedAlbumsArtist;
            set
            {
                selectedAlbumsArtist = value;
                SignalChanged();
            }
        }
        public ArtistsTrakApi SelectedTrack
        {
            get => selectedTrack;
            set
            {
                selectedTrack = value;
                SignalChanged("SelectedTrack");
            }
        }


        public List<ArtistsTrakApi> ArtistTracks
        {
            get => artistTracks;
            set
            {
                artistTracks = value;
                SignalChanged("ArtistTracks");
            }
        }

        public List<AlbumsArtistApi> AlbumsArtist
        {
            get => albumsArtist;
            set
            {
                albumsArtist = value;
                SignalChanged("AlbumsArtist");
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

        public List<AlbumTrackApi> AlbumTrack 
        { 
            get => albumTrack;
            set
            {
                albumTrack = value;
                SignalChanged("AlbumTrack");
            }
        }

        public Track PlayingTrack { get; set; }
        public INotificationMessageManager Manager { get; } = new NotificationMessageManager();
        public static Queue<TrackApi> test = new Queue<TrackApi>();
        public CustomCommand NewAlbum { get; set; }
        public ArtistApi ProfileArtist { get; set; }
        public TrackApi Track { get; set; }
        public AlbumApi Album { get; set; }
        public CustomCommand Edit { get; set; }
        public CustomCommand EditAlbum { get; set; }
        public CustomCommand PlayAlbum { get; set; }
        public CustomCommand Play { get; set; }
        public CustomCommand AddInAlbum { get; set; }
        public CustomCommand DeleteAlbum { get; set; }
        public CustomCommand EditTrack { get; set; }
        public CustomCommand DeleteTrack { get; set; }
        public CustomCommand AddTrack { get; set; }

        public MediaElement Track1;

        public static int IdTrackForGet;
        private List<AlbumTrackApi> albumTrack;

        public ProfileArtistPageViewModel()
        {
            Task.Run(GetArtistId);
            Task.Run(GetAlbumsList);
            Task.Run(GetTaskList);
            Task.Run(GetAlbumTrack);

            Play = new CustomCommand(() =>
            {
                try
                {
                    if (MasterArtistWindowViewModel.listTracks != null)
                        MasterArtistWindowViewModel.listTracks.Clear();

                    if (test.Count != 0)
                        test.Clear();

                    if (SelectedTrack == null)
                        return;
                    foreach (var track in Traks)
                    {
                        if (SelectedTrack.IdTrack == track.Id)
                        {
                            IdTrackForGet = track.Id;
                            Components.Track.GetInstance().UpdateTrack(track);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Простите", "Возникла непредвиденная ошибка, обратитесь к разработчику",  MessageBoxButton.OK ,MessageBoxImage.Error);
                }
                
            });

            PlayAlbum = new CustomCommand(() =>
            {
                try
                {
                    test.Clear();
                    if (SelectedAlbumsArtist == null)
                    {
                        MessageBox.Show("Album don't selected");
                    }
                    else
                    {
                        foreach (var al in Albums)
                            if (SelectedAlbumsArtist.IdAlbums == al.Id)
                                foreach (var altra in AlbumTrack)
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
                    ErrorNotification();
                }
            });

            AddInAlbum = new CustomCommand(() =>
            {
                
                if (SingInWindowViewModel.ArtId != 0)
                {
                    AddTrackInAlbumArtistWindow add = new AddTrackInAlbumArtistWindow();
                    add.ShowDialog();
                    AddTrackInAlbumNotification();
                }
            });

            AddTrack = new CustomCommand(() =>
            {
                AddTrackWindow atw = new AddTrackWindow();
                atw.ShowDialog();
                AddTrackNotification();
                Task.Run(GetTaskList);
            });


            EditTrack = new CustomCommand(() =>
            {
                if (SelectedTrack == null)
                    return;
                Track = SelectedTrack.Tracks;
                AddTrackWindow edit = new AddTrackWindow(Track);
                edit.ShowDialog();
                EditTrackNotification();
                Task.Run(GetTaskList);
            });

            DeleteTrack = new CustomCommand(() =>
            {
                MessageBoxResult result = MessageBox.Show("Удалить трек?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Task.Run(DeleteTrackMethod);
                        DeleteTrackNotification();
                        Thread.Sleep(200);
                        GetTrack();
                    }
                    catch 
                    {
                        ErrorNotification();
                    }
                }
                else return;
            });

            NewAlbum = new CustomCommand(() =>
            {
                AddAlbumWindow albumWindow = new AddAlbumWindow();
                albumWindow.Show();
                AddAlbumNotification();
                Task.Run(GetAlbumsList);
            });

            EditAlbum = new CustomCommand(() =>
            {
                if (SelectedAlbumsArtist == null)
                    return;
                Album = SelectedAlbumsArtist.Albums;
                AddAlbumWindow edit = new AddAlbumWindow(Album);
                edit.ShowDialog();
                EditAlbumNotification();
                Task.Run(GetAlbumsList);
            });

            DeleteAlbum = new CustomCommand(() =>
            {
                MessageBoxResult result = MessageBox.Show("Удалить альбом?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Task.Run(DeleteAlbumMethod);
                        DeleteAlbumNotification();
                        Thread.Sleep(200);
                        GetAlbum();
                    }
                    catch
                    {
                        ErrorNotification();
                    }
                }
                else return;
            });

            Edit = new CustomCommand(() =>
            {
                EditArtistWindow euw = new EditArtistWindow();
                euw.ShowDialog();
                EditArtistNotification();
                Thread.Sleep(200);
                Task.Run(GetArtistId);

            });
        }


        public async Task GetArtistId()
        {
            var t = SingInWindowViewModel.ArtId;
            var result = await Api.GetAsync<ArtistApi>(t, "Artist");
            ProfileArtist = result;
            SignalChanged("ProfileArtist");
        }

        public async Task GetAlbumsList()
        {
            #region Альбомы 
            var result = await Api.GetListAsync<AlbumsArtistApi[]>("AlbumsArtist");
            AlbumsArtist = new List<AlbumsArtistApi>(result);
            SignalChanged("AlbumsArtist");

            var result2 = await Api.GetListAsync<AlbumApi[]>("Album");
            Albums = new List<AlbumApi>(result2);
            SignalChanged("Albums");

            foreach (var artistAlbum in AlbumsArtist)
            {
                artistAlbum.Albums = Albums.First(s => s.Id == artistAlbum.IdAlbums);
            }

            foreach (var art in AlbumsArtist.ToArray())
            {
                if (art.IdArtists != SingInWindowViewModel.ArtId)
                {
                    AlbumsArtist.Remove(art);
                    SignalChanged("AlbumsArtist");
                }
            }
            #endregion
        }

        public async Task GetTaskList()
        {
            #region Треки 
            var result3 = await Api.GetListAsync<ArtistsTrakApi[]>("ArtistsTrak");
            ArtistTracks = new List<ArtistsTrakApi>(result3);
            SignalChanged("ArtistTracks");

            var result4 = await Api.GetListAsync<TrackApi[]>("Track");
            Traks = new List<TrackApi>(result4);
            SignalChanged("Traks");

            foreach (var artistTrack in ArtistTracks)
            {
                artistTrack.Tracks = Traks.First(s => s.Id == artistTrack.IdTrack);
            }

            foreach (var tra in ArtistTracks.ToArray())
            {
                if (tra.IdArtist != SingInWindowViewModel.ArtId)
                {
                    ArtistTracks.Remove(tra);
                    SignalChanged("ArtistTracks");
                }
            }
            #endregion
        }

        public async Task DeleteTrackMethod()
        {
            await Api.DeleteAsync<ArtistsTrakApi>(SelectedTrack, "ArtistsTrak");
            TrackApi track = null;
            foreach (var tracks in Traks)
                if (tracks.Id == SelectedTrack.IdTrack)
                    track = tracks;
            await Api.DeleteAsync<TrackApi>(track, "Track");
        }

        public async Task DeleteAlbumMethod()
        {
            await Api.DeleteAsync<AlbumsArtistApi>(SelectedAlbumsArtist, "AlbumsArtist");
            AlbumApi album = null;
            foreach (var albums in Albums)
                if (albums.Id == SelectedAlbumsArtist.IdAlbums)
                    album = albums;
            await Api.DeleteAsync<AlbumApi>(album, "Album");
        }

        public async Task GetAlbumTrack()
        {
            var result = await Api.GetListAsync<AlbumTrackApi[]>("AlbumTrack");
            AlbumTrack = new List<AlbumTrackApi>(result);
            SignalChanged("AlbumTrack");

        }

        public void GetTrack()
        {
            Task.Run(GetTaskList);
        }

        public void GetAlbum()
        {
            Task.Run(GetAlbumsList);
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
                .HasMessage("Альбом успешно создан.")
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
        public void AddTrackNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#327d0b")
                .Background("#48a818")
                .HasMessage("Трек успешно создан.")
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
        public void EditAlbumNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#b36910")
                .Background("#b38410")
                .HasMessage("Альбом успешно изменён.")
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
        }
        public void EditTrackNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#b36910")
                .Background("#b38410")
                .HasMessage("Трек успешно изменён.")
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
        }
        public void EditArtistNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#b36910")
                .Background("#b38410")
                .HasMessage("Профиль успешно изменён.")
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
