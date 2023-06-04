using Enterwell.Clients.Wpf.Notifications;
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

        public List<AlbumTrackApi> AlbumTrack
        {
            get => albumTrack;
            set
            {
                albumTrack = value;
                SignalChanged("AlbumTrack");
            }
        }
        public List<TrackApi> Tracks 
        {
            get => tracks;
            set
            {
                tracks = value;
                SignalChanged("Tracks");
            }
        }

        public INotificationMessageManager Manager { get; } = new NotificationMessageManager();
        public static Queue<TrackApi> test = new Queue<TrackApi>();
        public CustomCommand NewAlbum { get; set; }
        public AlbumApi Album;
        private List<AlbumTrackApi> albumTrack;
        private List<TrackApi> tracks;

        public UserApi ProfileUser { get; set; }
        public CustomCommand PlayAlbum { get; set; }
        public CustomCommand Edit { get; set; }
        public CustomCommand EditAlbum { get; set; }
        public CustomCommand DeleteAlbum { get; set; }
        public CustomCommand Refresh { get; set; }

        public ProfilePageViewModel()
        {
            Task.Run(GetUserId);
            Task.Run(GetAlbumsList);
            Task.Run(GetAlbumsTrack);

            Refresh = new CustomCommand(() =>
            {
                Task.Run(GetUserId);
                GetAlbums();
            });

            PlayAlbum = new CustomCommand(() =>
            {
                try
                {
                    test.Clear();
                    if (SelectedUserAlbum == null)
                    {
                        MessageBox.Show("Album don't selected");
                    }
                    else
                    {
                        foreach (var al in Albums)
                            if (SelectedUserAlbum.IdAlbum == al.Id)
                                foreach (var altra in AlbumTrack)
                                    if (al.Id == altra.IdAlbum)
                                        foreach (var track in Tracks)
                                            if (altra.IdTrack == track.Id)
                                                test.Enqueue(track);

                        Components.Track.GetInstance().UpdateTrack(test.Peek());

                    }
                }
                catch
                {
                    MessageBox.Show("Возможно альбом пуст");
                }
            });

            DeleteAlbum = new CustomCommand(() =>
            {
                MessageBoxResult result = MessageBox.Show("Удалить альбом?", "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Task.Run(DeleteAlbumMethod);
                        DeleteAlbumNotification();
                        Thread.Sleep(200);
                        GetAlbums();
                    }
                    catch (Exception e)
                    {
                        ErrorNotification();
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
                EditAlbumNotification();
                Task.Run(GetAlbumsList);
            });

            Edit = new CustomCommand(() =>
            {
                EditUserWindow euw = new EditUserWindow();
                euw.ShowDialog();
                EditUserNotification();
                Thread.Sleep(200);
                Task.Run(GetUserId);

            });

            NewAlbum = new CustomCommand(() =>
            {
                AddAlbumWindow albumWindow = new AddAlbumWindow();
                albumWindow.ShowDialog();
                AddAlbumNotification();
                Task.Run(GetAlbumsList);
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

        public async Task GetAlbumsTrack()
        {
            var result = await Api.GetListAsync<AlbumTrackApi[]>("AlbumTrack");
            AlbumTrack = new List<AlbumTrackApi>(result);
            SignalChanged("AlbumTrack");

            var result2 = await Api.GetListAsync<TrackApi[]>("Track");
            Tracks = new List<TrackApi>(result2);
            SignalChanged("Tracks");
        }


        public void AddAlbumNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#327d0b")
                .Background("#48a818")
                .HasMessage("Альбом успешно создан.")
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
        }
        public void EditUserNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#b36910")
                .Background("#b38410")
                .HasMessage("Профиль успешно изменён.")
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
        }
        public void EditAlbumNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#b36910")
                .Background("#b38410")
                .HasMessage("Альбом успешно изменён.")
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
        }
        public void DeleteAlbumNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#700d04")
                .Background("#bf1a0b")
                .HasMessage("Альбом успешно удалён.")
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
        }
        public void ErrorNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#700d04")
                .Background("#bf1a0b")
                .HasMessage("Непредвиденная ошибка")
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
        }
    }
}
