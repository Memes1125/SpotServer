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
    public class ProfilePageViewModel : Notify
    {
        private CustomCommand selectedAlbum;
        private List<AlbumApi> albums;

        public CustomCommand SelectedAlbum
        {
            get => selectedAlbum;
            set
            {
                selectedAlbum = value;
                SignalChanged();
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
                Task.Run(GetAlbumsList);
            });


            Edit = new CustomCommand(() =>
            {
                EditUserWindow euw = new EditUserWindow();
                euw.ShowDialog();
                Thread.Sleep(1000);
                Task.Run(GetUserId);
                
            });

            NewAlbum = new CustomCommand(() =>
            {
                AddAlbumWindow albumWindow = new AddAlbumWindow();
                albumWindow.Show();
            });
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
            var result = await Api.GetListAsync<AlbumApi[]>("Album");
            Albums = new List<AlbumApi>(result);
            SignalChanged("Albums");
        }

        public void Load()
        {
            Task.Run(GetUserId);
            Task.Run(GetAlbumsList);
        }
    }
}
