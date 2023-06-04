using Enterwell.Clients.Wpf.Notifications;
using Microsoft.VisualStudio.PlatformUI;
using ModelsApi;
using Prism.Commands;
using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SpotyClient.ViewModel
{
    public class TestVM : Notify
    {

        public string add = "dima614@bk.ru";

        public CustomCommand Test { get; set; }
        public INotificationMessageManager Manager { get; } = new NotificationMessageManager();

        public TestVM(AlbumApi album)
        {


            Test = new CustomCommand(() =>
            {
                DeleteProductNotification();
            });
        }

        public void DeleteProductNotification()
        {
            Manager
                .CreateMessage()
                .Animates(true)
                .AnimationInDuration(0.75)
                .AnimationOutDuration(2)
                .Accent("#700d04")
                .Background("#bf1a0b")
                .HasMessage("Трек успешно добавлен в альбом")
                .Dismiss().WithDelay(TimeSpan.FromSeconds(5))
                .Queue();
        }
    }
}
