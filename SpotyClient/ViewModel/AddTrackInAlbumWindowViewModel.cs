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
    public class AddTrackInAlbumWindowViewModel : Notify
    {
        private List<UserAlbumApi> userAlbums;
        private List<AlbumApi> albums;
        private AlbumTrackApi albumsTrack;
        private UserAlbumApi selectedAlbumsUser;

        private string searchText = "";
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                SearchAlbumMethod();
            }
        }

        

        public List<UserAlbumApi> AlbumsUser
        {
            get => userAlbums;
            set
            {
                userAlbums = value;
                SignalChanged("UserAlbums");
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

        public UserAlbumApi SelectedAlbumsUser 
        { 
            get => selectedAlbumsUser;
            set
            {
                selectedAlbumsUser = value;
                SignalChanged("SelectedAlbumsUser");
            }
        }

        public ObservableCollection<string> TestItems { get; set; }
        public List<UserAlbumApi> searchResultAlbum;
        public List<UserAlbumApi> mysearchAlbum { get; set; }
        public CustomCommand Exit { get; set; }
        public CustomCommand ExitCommand { get; set; }
        public CustomCommand AddTrackInAlbum { get; set; }


        public AddTrackInAlbumWindowViewModel(TrackApi track)
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

            ExitCommand = new CustomCommand(() =>
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
                    IdAlbum = SelectedAlbumsUser.IdAlbum
                };
                Task.Run(PostAlbumTrack);
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });
        }

        public async Task GetAlbumsList()
        {
            var result = await Api.GetListAsync<UserAlbumApi[]>("UserAlbum");
            AlbumsUser = new List<UserAlbumApi>(result);
            SignalChanged("AlbumsUser");

            var result2 = await Api.GetListAsync<AlbumApi[]>("Album");
            Albums = new List<AlbumApi>(result2);
            SignalChanged("Albums");


            foreach (var userAlbum in AlbumsUser)
            {
                userAlbum.Albums = Albums.First(s => s.Id == userAlbum.IdAlbum);
            }

            foreach (var usr in AlbumsUser.ToArray())
            {
                if (usr.IdUser != SingInWindowViewModel.UsId)
                {
                    AlbumsUser.Remove(usr);
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

            searchResultAlbum = new List<UserAlbumApi>(AlbumsUser);
            mysearchAlbum = new List<UserAlbumApi>(AlbumsUser);
        }

        private void SearchAlbumMethod()
        {
            var searchAlbum = SearchText.ToLower();
            searchResultAlbum = mysearchAlbum.Where(c => c.Albums.Name.ToLower().Contains(searchAlbum)).ToList();

            AlbumsUser = searchResultAlbum;
            SignalChanged(nameof(AlbumsUser));
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
