using ModelsApi;
using SpotyClient.Tools;
using SpotyClient.View;
using SpotyClient.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SpotyClient.ViewModel
{
    public class MasterWinViewModel : Notify
    {
        private object _curentPage;

        public object CurentPage
        {
            get { return _curentPage; }
            set
            {
                _curentPage = value;
                SignalChanged("CurentPage");
            }
        }

        public UserApi ProfileUser
        { 
            get => profileUser;
            set 
            {
                profileUser = value;
                SignalChanged("ProfileUser");
            } 
        }
        public CustomCommand Main { get; set; }
        public CustomCommand Help { get; set; }
        public CustomCommand Search { get; set; }
        public CustomCommand MyMediaLibrary { get; set; }
        public CustomCommand Profile { get; set; }
        public CustomCommand Test { get; set; }

        private UserApi profileUser;

        public MasterWinViewModel()
        {

            Task.Run(GetUserId);

           


            Test = new CustomCommand(() =>
            {
                Test nn = new Test();
                nn.Show();
            });

            Main = new CustomCommand(() =>
            {
                CurentPage = new MainPage();
                SignalChanged("CurentPage");
            });

            Help = new CustomCommand(() =>
            {
                CurentPage = new HelpPage();
                SignalChanged("CurentPage");
            });

            Search = new CustomCommand(() =>
            {
                CurentPage = new SearchPage();
                SignalChanged("CurentPage");
            });

            MyMediaLibrary = new CustomCommand(() =>
            {
                CurentPage = new MyMediaLibraryPage();
                SignalChanged("CurentPage");
            });

            Profile = new CustomCommand(() =>
            {
                CurentPage = new ProfilePage();
                SignalChanged("CurentPage");
            });
        }

        public async Task GetUserId()
        {
            Task.Delay(200).Wait();
            var t = SingInWindowViewModel.UsId;
            var result = await Api.GetAsync<UserApi>(t, "User");
            ProfileUser = result;
            SignalChanged("ProfileUser");
        }
       
        

    }
}
