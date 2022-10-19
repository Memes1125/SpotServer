using ModelsApi;
using System;

namespace SpotifyServer.db
{
    public partial class AlbumsArtist
    {
        public static explicit operator AlbumsArtistApi(AlbumsArtist albumsArtist)
        {
            if (albumsArtist == null)
                return null;
            return new AlbumsArtistApi
            {
                Id = albumsArtist.Id,
                IdAlbums = albumsArtist.IdAlbums,
                IdArtists = albumsArtist.IdArtists,
            };
        }

        public static explicit operator AlbumsArtist(AlbumsArtistApi albumsArtist)
        {
            if (albumsArtist == null)
                return null;
            return new AlbumsArtist
            {
                Id = albumsArtist.Id,
                IdAlbums = albumsArtist.IdAlbums,
                IdArtists = albumsArtist.IdArtists,
            };
        }
    }
}
