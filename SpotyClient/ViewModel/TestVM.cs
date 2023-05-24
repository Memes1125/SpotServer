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

        public CustomCommand button { get; set; }
                

        public TestVM(AlbumApi album)
        {

            
            button = new CustomCommand(() =>
            {
                
            });
        }
        

    }
}
