using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyClient.ViewModel
{
    public class HelpPageViewModel
    {
        public CustomCommand TG { get; set; }
        public CustomCommand GIT { get; set; }
        public CustomCommand VK { get; set; }


        public HelpPageViewModel()
        {
            TG = new CustomCommand(() =>
            {
                var ps = new ProcessStartInfo("https://t.me/demes_memess")
                {
                    UseShellExecute = true,
                    Verb = "open"
                };
                Process.Start(ps);
            });

            GIT = new CustomCommand(() =>
            {
                var ps = new ProcessStartInfo("https://github.com/Memes1125")
                {
                    UseShellExecute = true,
                    Verb = "open"
                };
                Process.Start(ps);
            });

            VK = new CustomCommand(() =>
            {
                var ps = new ProcessStartInfo("https://vk.com/demes_memes")
                {
                    UseShellExecute = true,
                    Verb = "open"
                };
                Process.Start(ps);
            });
        }
    }
}
