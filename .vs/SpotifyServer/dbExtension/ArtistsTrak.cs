using ModelsApi;
using System;


namespace SpotifyServer.db
{
    public partial class ArtistsTrak
    {
        public static explicit operator ArtistsTrakApi(ArtistsTrak artistsTrak)
        {
            if (artistsTrak == null)
                return null;
            return new ArtistsTrakApi
            {
                Id = artistsTrak.Id,
                IdArtist = artistsTrak.IdArtist,
                IdTrack = artistsTrak.IdTrack,
            };
        }

        public static explicit operator ArtistsTrak(ArtistsTrakApi artistsTrak)
        {
            if (artistsTrak == null)
                return null;
            return new ArtistsTrak
            {
                Id = artistsTrak.Id,
                IdArtist = artistsTrak.IdArtist,
                IdTrack = artistsTrak.IdTrack,
            };
        }
    }
}
