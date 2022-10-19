using ModelsApi;
using System;

namespace SpotifyServer.db
{
    public partial class Artist
    {
        public static explicit operator ArtistApi(Artist artist)
        {
            if (artist == null)
                return null;
            return new ArtistApi
            {
                Id = artist.Id,
                Email = artist.Email,
                Image = artist.Image,
                Name = artist.Name,
                Password = artist.Password
            };
        }

        public static explicit operator Artist(ArtistApi artist)
        {
            if (artist == null)
                return null;
            return new Artist
            {
                Id = artist.Id,
                Email = artist.Email,
                Image = artist.Image,
                Name = artist.Name,
                Password = artist.Password
            };
        }
    }
}
