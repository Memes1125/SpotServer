using ModelsApi;
using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpotyClient.ViewModel
{
    public class AddTrackInAlbumArtistWindowViewModel : Notify
    {
        private string searchText = "";
        private List<AlbumsArtistApi> userAlbums;
        private List<AlbumApi> albums;
        private AlbumTrackApi albumsTrack;
        private AlbumsArtistApi selectedAlbumsArtist;

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                SearchAlbumMethod();
            }
        }

        public List<AlbumsArtistApi> AlbumsArtist
        {
            get => userAlbums;
            set
            {
                userAlbums = value;
                SignalChanged("AlbumsArtist");
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

        public AlbumTrackApi AlbumsTrack
        {
            get => albumsTrack;
            set
            {
                albumsTrack = value;
                SignalChanged("AlbumsTrack");
            }
        }

        public AlbumsArtistApi SelectedAlbumsArtist
        {
            get => selectedAlbumsArtist;
            set
            {
                selectedAlbumsArtist = value;
                SignalChanged("SelectedAlbumsArtist");
            }
        }

        public ObservableCollection<string> TestItems { get; set; }
        public List<AlbumsArtistApi> searchResultAlbum;
        public List<AlbumsArtistApi> mysearchAlbum { get; set; }
        public CustomCommand Exit { get; set; }
        public CustomCommand ExitCommand { get; set; }
        public CustomCommand AddTrackInAlbum { get; set; }

        public AddTrackInAlbumArtistWindowViewModel(TrackApi track)
        {
            Task.Run(GetAlbumsList);

            Exit = new CustomCommand(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });

            AddTrackInAlbum = new CustomCommand(() =>
            {
                AlbumsTrack = new AlbumTrackApi
                {
                    IdTrack = track.Id,
                    IdAlbum = SelectedAlbumsArtist.IdAlbums
                };
                Task.Run(PostAlbumTrack);
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });

            ExitCommand = new CustomCommand(() =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });
        }

        private void SearchAlbumMethod()
        {
            var searchAlbum = SearchText.ToLower();
            searchResultAlbum = mysearchAlbum.Where(c => c.Albums.Name.ToLower().Contains(searchAlbum)).ToList();

            AlbumsArtist = searchResultAlbum;
            SignalChanged(nameof(AlbumsArtist));
        }

        public async Task GetAlbumsList()
        {
            var result = await Api.GetListAsync<AlbumsArtistApi[]>("AlbumsArtist");
            AlbumsArtist = new List<AlbumsArtistApi>(result);
            SignalChanged("AlbumsArtist");

            var result2 = await Api.GetListAsync<AlbumApi[]>("Album");
            Albums = new List<AlbumApi>(result2);
            SignalChanged("Albums");


            foreach (var userAlbum in AlbumsArtist)
            {
                userAlbum.Albums = Albums.First(s => s.Id == userAlbum.IdAlbums);
            }

            foreach (var usr in AlbumsArtist.ToArray())
            {
                if (usr.IdArtists != SingInWindowViewModel.ArtId)
                {
                    AlbumsArtist.Remove(usr);
                    SignalChanged("AlbumsArtist");
                }
            }

            TestItems = new ObservableCollection<string>();
            foreach (var a in Albums)
            {
                TestItems.Add(a.Name.ToLower());
                TestItems.Add(a.Name);
            }
            SignalChanged("TestItems");

            searchResultAlbum = new List<AlbumsArtistApi>(AlbumsArtist);
            mysearchAlbum = new List<AlbumsArtistApi>(AlbumsArtist);
        }

        public async Task PostAlbumTrack()
        {
            await Api.PostAsync<AlbumTrackApi>(AlbumsTrack, "AlbumTrack");
        }

        public void CloseWin(object obj)
        {
            Window win = obj as Window;
            win.Close();
        }
    }
}
