using ModelsApi;
using System;

namespace SpotifyServer.db
{
    public partial class Track
    {
        public static explicit operator TrackApi(Track track)
        {
            if (track == null)
                return null;
            return new TrackApi
            {
                Id = track.Id,
                Duration = track.Duration,
                Image = track.Image,
                Name = track.Name,
                Track1 = track.Track1,
            };
        }

        public static explicit operator Track(TrackApi track)
        {
            if (track == null)
                return null;
            return new Track
            {
                Id = track.Id,
                Duration = track.Duration,
                Image = track.Image,
                Name = track.Name,
                Track1 = track.Track1,
            };
        }
    }
}
