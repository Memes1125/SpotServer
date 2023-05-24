using ModelsApi;
using SpotyClient.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotyClient.Components
{
    public class Track : Notify
    {
        public TimeSpan Duration { get => result.Duration; set => result.Duration = value; }
        public string Name { get => result.Name; set => result.Name = value; }
        public string Track1 { get => result.Track1; set => result.Track1 = value; }
        public string Image { get => result.Image; set => result.Image = value; }
        static Track instance;
        internal static Track GetInstance()
        {
            if (instance == null)
                instance = new Track();
            return instance;
        }

        TrackApi result;
        private string str = "";
        public static string resultPath = "";
        internal void UpdateTrack(TrackApi result)
        {
            this.result = result;
            SignalChanged(nameof(Name));
            SignalChanged(nameof(Image));
            SignalChanged(nameof(Duration));
            SignalChanged(nameof(Track1));

            if(TrackPathConverter.fullpath != null)
            {
                str = TrackPathConverter.fullpath.Remove(TrackPathConverter.fullpath.LastIndexOf("/"));
                str = str.Remove(str.LastIndexOf("/"));
                resultPath = $"{str + Track1}";
            } 
        }
    }
}
