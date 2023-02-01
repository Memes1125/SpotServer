using ModelsApi;
using SpotyClient.Tools;
using SpotyClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpotyClient.ViewModel
{
    public class ProfilePageViewModel : Notify
    {

        public CustomCommand NewAlbum { get; set; }
        public UserApi ProfileUser { get; set; }
        public CustomCommand Edit { get; set; }

        public ProfilePageViewModel()
        {
            Task.Run(GetUserId);

            Edit = new CustomCommand(() =>
            {
                EditUserWindow euw = new EditUserWindow();
                euw.Show();
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


    }
}
