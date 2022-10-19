using ModelsApi;
using System;


namespace SpotifyServer.db
{
    public partial class TrackHistory
    {
        public static explicit operator TrackHistoryApi(TrackHistory trackHistory)
        {
            if (trackHistory == null)
                return null;
            return new TrackHistoryApi
            {
                Id = trackHistory.Id,
                IdTrack = trackHistory.IdTrack,
                IdAlbum = trackHistory.IdAlbum,
            };
        }

        public static explicit operator TrackHistory(TrackHistoryApi trackHistory)
        {
            if (trackHistory == null)
                return null;
            return new TrackHistory
            {
                Id = trackHistory.Id,
                IdTrack = trackHistory.IdTrack,
                IdAlbum = trackHistory.IdAlbum,
            };
        }

    }
}
