using ModelsApi;
using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyClient.ViewModel
{
    public class TestVM : Notify
    {
        //private ArtistApi _selectedUser;
        //public ArtistApi SelectedUser
        //{
        //    get => _selectedUser;
        //    set
        //    {
        //        _selectedUser = value;
        //        SignalChanged();
        //    }
        //}

        //public List<AlbumApi> users;
        //public List<AlbumApi> Users
        //{
        //    get => users;
        //    set
        //    {
        //        users = value;
        //        SignalChanged();
        //    }
        //}


        public UserApi ProfileUser { get; set; }

        public TestVM(AlbumApi album)
        {
            Task.Run(GetUserId);

           
        }


        //public async Task ProductsList()
        //{
        //    var result = await Api.GetListAsync<AlbumApi[]>("Album");
        //    Users = new List<AlbumApi>(result);
        //    SignalChanged("Users");

        //}


        //public async Task GetUserId()
        //{
        //    var t = SingInWindowViewModel.UsId;
        //    var result = await Api.GetAsync<UserApi>(5, "User");
        //    SignalChanged("result");

        //}


        public async Task GetUserId()
        {
            var t = SingInWindowViewModel.UsId;
            var result = await Api.GetAsync<UserApi>(t, "User");
            ProfileUser = result;
            SignalChanged("ProfileUser");
        }
    }
}
