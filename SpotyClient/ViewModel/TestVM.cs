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
        private ArtistApi _selectedUser;
        

        public ArtistApi SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                SignalChanged();
            }
        }

        //public List<UserApi> users;
        //public List<UserApi> Users
        //{
        //    get => users;
        //    set
        //    {
        //        users = value;
        //        SignalChanged();
        //    }
        //}

        private UserApi users;
        public UserApi Users 
        { 
            get => users; 
            set 
            {
                users = value;
                SignalChanged("Users");
            }
        }

        public TestVM(UserApi user)
        {
            //Task.Run(ProductsList);

            Task.Run(GetUserId).ContinueWith(s =>
            {
                
            });
        }


        //public async Task ProductsList()
        //{
        //    var result = await Api.GetListAsync<ArtistApi[]>("Artist");
        //    Users = new List<ArtistApi>(result);
        //    SignalChanged("Users");

        //}


        public async Task GetUserId()
        {
            var t = SingInWindowViewModel.UsId;
            var result = await Api.GetAsync<UserApi>(5, "User");
            SignalChanged("result");
            
        }
    }
}
