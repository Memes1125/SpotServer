using ModelsApi;
using SpotyClient.Components;
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
using System.Windows.Threading;

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

        public UserProfile ProfileUser
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

        private UserProfile profileUser;
        private Dispatcher dispatcher;

        public MasterWinViewModel(Dispatcher dispatcher)
        {

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

            Task.Run(GetUserId);
            this.dispatcher = dispatcher;
        }

        public async Task GetUserId()
        {
            Task.Delay(200).Wait();
            var t = SingInWindowViewModel.UsId;
            var result = await Api.GetAsync<UserApi>(t, "User");
            ProfileUser = UserProfile.GetInstance();
            ProfileUser.UpdateUser(result);
            SignalChanged("ProfileUser");

            dispatcher.Invoke(() => Profile.Execute(null));
        }
       
        

    }
}
