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

namespace SpotyClient.ViewModel
{
    public class ProfilePageViewModel : Notify
    {
        private UserAlbumApi selectedUserAlbum;
        private List<UserAlbumApi> userAlbums;
        private List<AlbumApi> albums;

        public UserAlbumApi SelectedUserAlbum
        {
            get => selectedUserAlbum;
            set
            {
                selectedUserAlbum = value;
                
               
                SignalChanged();
            }
        }

        public List<UserAlbumApi> UserAlbums
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
        
        public CustomCommand NewAlbum { get; set; }
        public AlbumApi Album;
        public UserApi ProfileUser { get; set; }
        public CustomCommand Edit { get; set; }
        public CustomCommand EditAlbum { get; set; }
        public CustomCommand DeleteAlbum { get; set; }
        public CustomCommand Refresh { get; set; }

        public ProfilePageViewModel()
        {
            Task.Run(GetUserId);
            Task.Run(GetAlbumsList);

            Refresh = new CustomCommand(() =>
            {
                Task.Run(GetUserId);
                GetAlbums();
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
                        GetAlbums();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                else return;
            });
            
            EditAlbum = new CustomCommand(() =>
            {
                if (SelectedUserAlbum == null)
                    return;
                Album = SelectedUserAlbum.Albums;
                AddAlbumWindow edit = new AddAlbumWindow(Album);
                edit.ShowDialog();
                Task.Run(GetAlbumsList);
            });

            Edit = new CustomCommand(() =>
            {
                EditUserWindow euw = new EditUserWindow();
                euw.ShowDialog();
                Thread.Sleep(200);
                Task.Run(GetUserId);
                
            });

            NewAlbum = new CustomCommand(() =>
            {
                AddAlbumWindow albumWindow = new AddAlbumWindow();
                albumWindow.ShowDialog();
            });
        }

        public async Task DeleteAlbumMethod()
        {
            await Api.DeleteAsync<UserAlbumApi>(SelectedUserAlbum, "UserAlbum");
        }

        public async Task GetUserId()
        {
            var t = SingInWindowViewModel.UsId;
            var result = await Api.GetAsync<UserApi>(t, "User");
            ProfileUser = result;
            SignalChanged("ProfileUser");
        }

        public async Task GetAlbumsList()
        {
            var result = await Api.GetListAsync<UserAlbumApi[]>("UserAlbum");
            UserAlbums = new List<UserAlbumApi>(result);
            SignalChanged("UserAlbums");

            var result2 = await Api.GetListAsync<AlbumApi[]>("Album");
            Albums = new List<AlbumApi>(result2);
            SignalChanged("Albums");


            foreach (var userAlbum in UserAlbums)
            {
                userAlbum.Albums = Albums.First(s => s.Id == userAlbum.IdAlbum);
            }

            foreach (var usr in UserAlbums.ToArray())
            {
                if (usr.IdUser != SingInWindowViewModel.UsId)
                {
                    UserAlbums.Remove(usr);
                    SignalChanged("AlbumsArtist");
                }
            }
        }

        public void GetAlbums()
        {
            Task.Run(GetAlbumsList);
        }
    }
}
