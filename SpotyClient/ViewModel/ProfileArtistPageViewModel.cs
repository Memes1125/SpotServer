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

        public Track PlayingTrack { get; set; }

        public CustomCommand NewAlbum { get; set; }
        public ArtistApi ProfileArtist { get; set; }
        public TrackApi Track { get; set; }
        public AlbumApi Album { get; set; }
        public CustomCommand Edit { get; set; }
        public CustomCommand EditAlbum { get; set; }
        public CustomCommand Play { get; set; }
        public CustomCommand DeleteAlbum { get; set; }
        public CustomCommand EditTrack { get; set; }
        public CustomCommand DeleteTrack { get; set; }
        public CustomCommand AddTrack { get; set; }
        public MediaElement Track1;

        public static int IdTrackForGet;

        public ProfileArtistPageViewModel()
        {
            Task.Run(GetArtistId);
            Task.Run(GetAlbumsList);
            Task.Run(GetTaskList);

            Play = new CustomCommand(() =>
            {
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
            });

            AddTrack = new CustomCommand(() =>
            {
                AddTrackWindow atw = new AddTrackWindow();
                atw.ShowDialog();
            });


            EditTrack = new CustomCommand(() =>
            {
                if (SelectedTrack == null)
                    return;
                Track = SelectedTrack.Tracks;
                AddTrackWindow edit = new AddTrackWindow(Track);
                edit.ShowDialog();
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
                        Thread.Sleep(200);
                        GetTrack();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                else return;
            });

            NewAlbum = new CustomCommand(() =>
            {
                AddAlbumWindow albumWindow = new AddAlbumWindow();
                albumWindow.Show();
                Task.Run(GetAlbumsList);
            });

            EditAlbum = new CustomCommand(() =>
            {
                if (SelectedAlbumsArtist == null)
                    return;
                Album = SelectedAlbumsArtist.Albums;
                AddAlbumWindow edit = new AddAlbumWindow(Album);
                edit.ShowDialog();
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
                        Thread.Sleep(200);
                        GetAlbum();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                else return;
            });

            Edit = new CustomCommand(() =>
            {
                EditArtistWindow euw = new EditArtistWindow();
                euw.ShowDialog();
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

        public void GetTrack()
        {
            Task.Run(GetTaskList);
        }

        public void GetAlbum()
        {
            Task.Run(GetAlbumsList);
        }
    }
}
