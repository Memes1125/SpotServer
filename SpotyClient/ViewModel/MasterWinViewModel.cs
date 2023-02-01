using ModelsApi;
using SpotyClient.Tools;
using SpotyClient.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public CustomCommand Main { get; set; }
        public CustomCommand Help { get; set; }
        public CustomCommand Search { get; set; }
        public CustomCommand MyMediaLibrary { get; set; }
        public CustomCommand Profile { get; set; }


        public MasterWinViewModel()
        {
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

        
    }
}
