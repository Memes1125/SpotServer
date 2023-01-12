using ModelsApi;
using SpotyClient.Tools;
using SpotyClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpotyClient.ViewModel
{
    public class MainWindowViewModel : Notify
    {
        public CustomCommand RegUser { get; set; }
        public CustomCommand RegArtist { get; set; }
        public CustomCommand SingIn { get; set; }

        public MainWindowViewModel(UserApi user)
        {
            RegUser = new CustomCommand(() =>
            {
                RegisterUserWindow RegUserWin = new RegisterUserWindow();
                RegUserWin.ShowDialog();
            });

            RegArtist = new CustomCommand(() =>
            {
                RegisterArtistWindow RegArtistWin = new RegisterArtistWindow();
                RegArtistWin.ShowDialog();
            });

            SingIn = new CustomCommand(() =>
            {
                SingInWindow SingInWin = new SingInWindow();
                SingInWin.ShowDialog();
            });
        }
    }
}
