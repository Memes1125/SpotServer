using ModelsApi;
using System;

namespace SpotifyServer.db
{
    public partial class Album
    {
        public static explicit operator AlbumApi(Album album)
        {
            if (album == null)
                return null;
            return new AlbumApi
            {
                Id = album.Id,
                Duration = album.Duration,
                Name = album.Name,
                TrackNumber = album.TrackNumber,
            };
        }

        public static explicit operator Album(AlbumApi album)
        {
            if (album == null)
                return null;
            return new Album
            {
                Id = album.Id,
                Duration = album.Duration,
                Name = album.Name,
                TrackNumber = album.TrackNumber,
            };
        }
    }
}
