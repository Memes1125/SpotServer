using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace SpotyClient.Components
{
    public class TrackPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                value = @"\Resource\NoTrack.mp3";
            }
            string path = Environment.CurrentDirectory + value.ToString();
            if (!File.Exists(path))
                path = Environment.CurrentDirectory + @"\Resource\NoTrack.mp3";
            return GetTrackFromPath(path);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
        public static string fullpath;
        private MediaElement GetTrackFromPath(string url)
        {
            MediaElement track = new MediaElement();
            track.BeginInit();
            track.LoadedBehavior = MediaState.Manual;
            track.Source = new Uri(url, UriKind.Absolute);
            track.EndInit();
            fullpath = track.Source.ToString();
            return track;
        }
    }
}
