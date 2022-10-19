using ModelsApi;
using System;

namespace SpotifyServer.db
{
    public partial class TrackLine
    {
        public static explicit operator TrackLineApi(TrackLine trackLine)
        {
            if (trackLine == null)
                return null;
            return new TrackLineApi
            {
                Id = trackLine.Id,
                IdAlbum = trackLine.IdAlbum,
                IdTrack = trackLine.IdTrack,
                IdUser = trackLine.IdUser, 
            };
        }

        public static explicit operator TrackLine(TrackLineApi trackLine)
        {
            if (trackLine == null)
                return null;
            return new TrackLine
            {
                Id = trackLine.Id,
                IdAlbum = trackLine.IdAlbum,
                IdTrack = trackLine.IdTrack,
                IdUser = trackLine.IdUser,
            };
        }
    }
}
