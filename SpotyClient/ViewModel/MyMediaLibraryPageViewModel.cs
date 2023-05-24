using ModelsApi;
using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public int Number { get; set; }
        public UserApi User { get; set; }
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
                if(alb.IdUser != SingInWindowViewModel.UsId)
                {
                    LikesAlbums.Remove(alb);
                    SignalChanged("LikesAlbums");
                }
            }
        }
    }
}
