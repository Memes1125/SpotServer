using System;
using System.Collections.Generic;

#nullable disable

namespace SpotifyServer.db
{
    public partial class Artist
    {
        public Artist()
        {
            AlbumsArtists = new HashSet<AlbumsArtist>();
            ArtistsTraks = new HashSet<ArtistsTrak>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }

        public virtual ICollection<AlbumsArtist> AlbumsArtists { get; set; }
        public virtual ICollection<ArtistsTrak> ArtistsTraks { get; set; }
    }
}
