using ModelsApi;
using System;

namespace SpotifyServer.db
{
    public partial class AlbumTrack
    {
        public static explicit operator AlbumTrackApi(AlbumTrack albumTrack)
        {
            if (albumTrack == null)
                return null;
            return new AlbumTrackApi
            {
                Id = albumTrack.Id,
                IdAlbum = albumTrack.IdAlbum,
                IdTrack = albumTrack.IdTrack,
            };
        }

        public static explicit operator AlbumTrack(AlbumTrackApi albumTrack)
        {
            if (albumTrack == null)
                return null;
            return new AlbumTrack
            {
                Id = albumTrack.Id,
                IdAlbum = albumTrack.IdAlbum,
                IdTrack = albumTrack.IdTrack,
            };
        }
    }
}
