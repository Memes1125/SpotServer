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

        public List<ArtistApi> users;
        public List<ArtistApi> Users
        {
            get => users;
            set
            {
                users = value;
                SignalChanged();
            }
        }


        public TestVM()
        {
            Task.Run(ProductsList);
        }


        public async Task ProductsList()
        {
            var result = await Api.GetListAsync<ArtistApi[]>("Artist");
            Users = new List<ArtistApi>(result);
            SignalChanged("Users");

        }
    }
}
