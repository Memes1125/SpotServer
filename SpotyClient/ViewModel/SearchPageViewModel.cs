using ModelsApi;
using SpotyClient.Components;
using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public Track PlayingTrack { get; set; }
        public List<TrackApi> searchResultTrack;
        public List<AlbumApi> searchResultAlbum;
        public List<TrackApi> mysearchTrack { get; set; }
        public List<AlbumApi> mysearchAlbum { get; set; }
        public CustomCommand Play { get; set; }
        public CustomCommand AddLikes { get; set; }
        public CustomCommand AddLikesAlbumCommand { get; set; }

        public SearchPageViewModel()
        {
            Task.Run(GetTacks);
            Task.Run(GetAlbums);

            Play = new CustomCommand(() =>
            {
                if (SelectedTrak == null)
                    return;
                foreach (var trackqwqw in Traks)
                {
                    if (SelectedTrak.Id == trackqwqw.Id)
                    {
                        Components.Track.GetInstance().UpdateTrack(trackqwqw);
                    }
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
                Task.Run(PostLikesAlbum);
            });
        }

        public async Task GetTacks()
        {
            var result4 = await Api.GetListAsync<TrackApi[]>("Track");
            Traks = new List<TrackApi>(result4);
            SignalChanged("Traks");
            searchResultTrack = new List<TrackApi>(Traks);
            mysearchTrack = new List<TrackApi>(Traks);
        }

        public async Task GetAlbums()
        {
            var result = await Api.GetListAsync<AlbumApi[]>("Album");
            Albums = new List<AlbumApi>(result);
            SignalChanged("Album");
            searchResultAlbum = new List<AlbumApi>(Albums);
            mysearchAlbum = new List<AlbumApi>(Albums);
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
    }
}
